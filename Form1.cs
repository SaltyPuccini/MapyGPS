using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Linq;
using System.Net.Sockets;
using System.Text;

using Ghostware.NMEAParser.Enums;
using System.IO.Ports;
using Ghostware.NMEAParser.NMEAMessages;

namespace MapyGPS
{

    public partial class Form1 : Form
    {

        bool nadawanie = true;
        double latidute = 0;
        double longtidute = 0;

        static BluetoothClient bluetoothClient = new BluetoothClient();

        public Form1()
        {
            InitializeComponent();
            gMapMap.ShowCenter = false;


        }
        
        BluetoothDeviceInfo[] devices;

        private void buttonShowOnMap_Click(object sender, EventArgs e)
        {
            gMapMap.DragButton = MouseButtons.Left;
            gMapMap.MapProvider = GMapProviders.GoogleMap;

            if (!string.IsNullOrWhiteSpace(textBoxLong.Text))
                latidute = Convert.ToDouble(textBoxLati.Text);
            if (!string.IsNullOrWhiteSpace(textBoxLong.Text))
                longtidute = Convert.ToDouble(textBoxLong.Text);

            gMapMap.Position = new GMap.NET.PointLatLng(latidute, longtidute);
            gMapMap.MinZoom = 0;
            gMapMap.MaxZoom = 18;
            gMapMap.Zoom = 10;

            PointLatLng point = new PointLatLng(latidute, longtidute);
            GMapMarker marker;
            marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            gMapMap.Overlays.Add(markers);
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            //gdyby jednak trzbea pracować na comportach
            string[] ports = SerialPort.GetPortNames();
            comboBoxCOMPORT.Items.AddRange(ports);

            devices = bluetoothClient.DiscoverDevices();
            for (int i = 0; i < devices.Length; i++)
            {
                listBoxBT.Items.Add(devices[i].DeviceName);
            }
        }


        //część dotycząca pracy na serial portach

        string dataIN;

        //otwiera port
        private void buttonOpenSerial(object sender, EventArgs e)
        {
            //https://en.wikipedia.org/wiki/NMEA_0183

            try
            {
                serialPort1.PortName = comboBoxCOMPORT.Text;
                serialPort1.BaudRate = 4800;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;

                serialPort1.Open();               
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }            

        //sprawdza co dostał
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIN = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(ShowData));
        }
        //wypisuje co dostał na label
        private void ShowData(object sender, EventArgs e)
        {
            NMEAlabel.Text = dataIN;
            
        }


        //część dotycząca BT


        //paruje z wybranym urządzeniem - docelowo jest zrobione tak, że paruje się to z GPSEM i potem od razu wywołuje funkcje do parsowania NMEA na lati i long
        private void buttonBTDevices_Click(object sender, EventArgs e)
        {
            Paruj();
        }


        public void Paruj()
        {
            BluetoothDeviceInfo deviceToPair;
            var devices = bluetoothClient.DiscoverDevices();
            deviceToPair = devices.Where(x => x.DeviceName.Equals(listBoxBT.SelectedItem)).FirstOrDefault();
            if (deviceToPair != null)
            {

                //136 - 145 opcjonalne
                var blueToothInfo = string.Format(                      
                    "- DeviceName: {0}{1}  Connected: {2}{1}  Address: {3}{1}  Last seen: {4}{1}  Last used: {5}{1}", deviceToPair.DeviceName, Environment.NewLine, deviceToPair.Connected, deviceToPair.DeviceAddress, deviceToPair.LastSeen, deviceToPair.LastUsed);

                blueToothInfo += string.Format(
                    "  Class of device{0}   Device: {1}{0}   Major Device: {2}{0}   Service: {3}", Environment.NewLine, deviceToPair.ClassOfDevice.Device, deviceToPair.ClassOfDevice.MajorDevice, deviceToPair.ClassOfDevice.Service);
                
                
                
                MessageBox.Show(string.Format("Urządzenie z którym się parujemy:\n{0}", blueToothInfo));
                
                deviceToPair.Update();
                deviceToPair.Refresh();
                deviceToPair.SetServiceState(BluetoothService.ObexObjectPush, true);
                
                bool isPaired = BluetoothSecurity.PairRequest(deviceToPair.DeviceAddress, "0000");

                if (isPaired)
                {
                    MessageBox.Show("Urządzenie sparowane");
                    bluetoothClient.BeginConnect(deviceToPair.DeviceAddress, BluetoothService.SerialPort, new AsyncCallback(Connect), deviceToPair);
                }
                else
                {
                    MessageBox.Show("Nie udało się sparować urządzenia.");
                }
            }
            else
            {
                Console.WriteLine("device to Par = null");
            }
        }

        private void Dummy(IAsyncResult ar)
        {
            Console.WriteLine("połączone i nic więcej");
        }

        //tłumaczy NMEA na dane i wpisuje do textboxów lati i long.
        private void Connect(IAsyncResult result)
        {

            if (result.IsCompleted)
            {
                var myNetworkStream = bluetoothClient.GetStream();
                while (true)
                {
                    if (myNetworkStream.CanRead)
                    {
                        byte[] myReadBuffer = new byte[256];
                        StringBuilder myCompleteMessage = new StringBuilder();
                        int numberOfBytesRead = 0;

                        do
                        {
                            numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);

                            myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));

                        }
                        while (myNetworkStream.DataAvailable);

                        try
                        {
                            Ghostware.NMEAParser.NmeaParser parser = new Ghostware.NMEAParser.NmeaParser();
                            GpggaMessage parsedMessage = (GpggaMessage)parser.Parse(myCompleteMessage.ToString());
                            Console.WriteLine("You received the following message : " + myCompleteMessage.ToString());

                            nadawanie = true;

                            textBoxLati.Text = parsedMessage.Latitude.ToString();
                            textBoxLong.Text = parsedMessage.Longitude.ToString();

                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine("Wystapil blad, ponowna proba pobrania danych");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry.  You cannot read from this NetworkStream.");
                    }
                }
            }
        }

        private void listBoxBT_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(listBoxBT.SelectedItem);
        }

        //jeśli zaszły zmiany w textboxach, pojawia się pin na mapie. Może nie zadziałać i się sfreezować, tu coś z wątkami możliwe trzeba będzie porobić, albo ograniczyć się do np. nasłuchiwania tylko jednego komunikatu z BT na przycisk zamiast w pętli.

        private void textBoxLong_TextChanged(object sender, EventArgs e)// ???
        {

            gMapMap.DragButton = MouseButtons.Left;
            gMapMap.MapProvider = GMapProviders.GoogleMap;

            if (nadawanie)
            {
                if (!string.IsNullOrWhiteSpace(textBoxLong.Text))
                    latidute = Convert.ToDouble(textBoxLati.Text);
                if (!string.IsNullOrWhiteSpace(textBoxLong.Text))
                    longtidute = Convert.ToDouble(textBoxLong.Text);

                gMapMap.Position = new GMap.NET.PointLatLng(latidute, longtidute);
                gMapMap.MinZoom = 0;
                gMapMap.MaxZoom = 18;
                gMapMap.Zoom = 10;

                PointLatLng point = new PointLatLng(latidute, longtidute);
                GMapMarker marker;
                marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
                GMapOverlay markers = new GMapOverlay("markers");
                markers.Markers.Add(marker);
                gMapMap.Overlays.Add(markers);
                //nadawanie = false;
            }
        }
    }
}
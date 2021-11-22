using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Ghostware.NMEAParser.NMEAMessages;

namespace MapyGPS
{
    class Program
    {

        SerialPort port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}

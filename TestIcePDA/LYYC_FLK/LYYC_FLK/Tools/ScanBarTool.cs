using System;
using System.Threading;
using MotoSDL;
using Invengo.Audio;
using Fusion.LYYC.PDA.Scanner.Interface;

namespace Fusion.LYYC.PDA.Scanner.Tools
{
    public class ScanBarTool : IScanBar
    {
        private delegate void InvokeDelegate();
        SDLScanner scanner = null;

        public ScanBarTool()
        {
            scanner = SDLScanner.CreateInstance();
            scanner.Decoded += new EventHandler(scanner_Decoded);
        }
        public void Close()
        {
            scanner.Decoded -= new EventHandler(scanner_Decoded);
            scanner.Dispose();
        }
        public string ScanBarcode()
        {
            string BarCode = "";
            if (scanner.fInSession)
            {
                scanner.Trigger = false;
            }
            scanner.DecodeMode();
            scanner.Trigger = true;
            int no = 0;
            while (no < 10 && (DecodeData.text == null || DecodeData.text[0] == '\0'))
            {
                Thread.Sleep(200);
                no++;
            }
            BarCode = DecodeData.text;
            DecodeData.text = null;
            scanner.Trigger = false;
            SoundPlayer.PlayWAV(@"\Windows\recend.wav");
            return BarCode;

        }
        void scanner_Decoded(object sender, EventArgs e)
        {
            scanner.Trigger = false;
        }

        #region IDisposable 成员

        public void Dispose()
        {
            scanner.Dispose();
        }

        #endregion
    }
}

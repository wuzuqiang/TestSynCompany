using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseClassUtils
{
    public class WinFormUtil
    {
        public static string ShowOpenFileDialog()
        {
            string result = "";
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                result = dlg.FileName;
            }
            else
            {
                result = null;
            }
            return result;
        }

        public static string ShowFolderBrowserDialog()
        {
            string result = "";
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                result = dlg.SelectedPath;
            }
            else
            {
                result = null;
            }
            return result;
        }
        
        private void CopyToClipboard(string sSource)
        {
            Clipboard.Clear();
            if (!string.IsNullOrEmpty(sSource))
            {
                Clipboard.SetText(sSource);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using JASLogLibrary;

namespace COG.Controls
{
    public partial class CtrlLogViewer : UserControl
    {
        private string _logTitle = "";

        public CtrlLogViewer(string logTitle = "")
        {
            InitializeComponent();
            _logTitle = logTitle;
        }

        private void CtrlLogViewer_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            //if (_logTitle == "")
            //    lblLogTitle.Text = "LOG";
            //else
            //    lblLogTitle.Text = _logTitle + " LOG";
        }

        private delegate void AddLogDelegate(string message);

        public void AddLog(string message)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    AddLogDelegate callBack = AddLog;
                    BeginInvoke(callBack, message);
                    return;
                }
                
                if (lstLogMessage.Items.Count >= 2000)
                    lstLogMessage.Items.Clear();

                string content = "[ " + Logger.GetTimeString(DateTime.Now) + " ] ";
                content += message;

                lstLogMessage.Items.Add(content);
                lstLogMessage.SelectedIndex = lstLogMessage.Items.Count - 1;
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        public void ClearLog()
        {
            lstLogMessage.Items.Clear();
        }
    }
}

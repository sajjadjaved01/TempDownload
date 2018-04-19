using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace frmDownTemp
{
    public partial class frmMain : Form
    {
        FileDown down = new FileDown();
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width - Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height - Height;
            Location = new Point(x, y);
            down.DownloadComplete += new EventHandler(Down_DownloadComplete);
            down.ProgressChanged += new FileDown.DownloadProgressHandler(Down_ProgressChanged);
            down.AsyncDownload("docs.googleusercontent.com/docs/securesc/ha0ro937gcuc7l7deffksulhg5h7mbp1/d1d7081j82dhgmtgpicfi21qh0h5l41d/1476187200000/12429020242186261639/*/0B_mrqPTrlu-2NVFRaVY4cXVoVjA?e=download");
        }

        private void Down_ProgressChanged(object sender, FileDown.DownloadEventArgs e)
        {
            lblStatus.Invoke(new MethodInvoker(delegate { lblStatus.Text = e.PercentDone + "%"; }));
            //Invoke(new MethodInvoker(delegate { Text = e.PercentDone + "%"; }));
            progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.Value = e.PercentDone; }));
        }

        private void Down_DownloadComplete(object sender, EventArgs e)
        {
            lblStatus.Invoke(new MethodInvoker(delegate { lblStatus.Text = "Download Completed" ; }));
            progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.Value = 100; }));
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //var window = MessageBox.Show("Close the window","",buttons: MessageBoxButtons.YesNo);
            //if (window == DialogResult.No) e.Cancel = true;
            //else e.Cancel = false;
            if (progressBar1.Value == 100)
            {
                e.Cancel = false;
            }
            else { e.Cancel = true; }
        }

        //protected override void WndProc(ref Message message)
        //{
        //    if (message.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE)
        //    {
        //        ShowWindow();
        //    }
        //    base.WndProc(ref message);
        //}
        //public void ShowWindow()
        //{
        //    // Insert code here to make your form show itself.
        //    WinApi.ShowToFront(Handle);
        //}
    }
}

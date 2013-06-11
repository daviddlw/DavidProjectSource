using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace ProcessStartStop
{
    public partial class ProcessStartStopForm : Form
    {
        private int fileIndex = 0;
        private string fileName = @"notepad.exe";
        private Process p = new Process();

        public ProcessStartStopForm()
        {
            InitializeComponent();
            InitListView();
        }



        /// <summary>
        /// 初始化ListView
        /// </summary>
        private void InitListView()
        {
            string[] headerNames = new string[] { "进程ID", "进程名字", "占用内存", "启动时间", "文件名" };
            int index = 0;
            lvProcessManage.View = View.Details;
            foreach (string header in headerNames)
            {
                lvProcessManage.Columns.Add(header, index == headerNames.Length - 1 ? 280 : 70, HorizontalAlignment.Left);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string arguments = Application.StartupPath + "\\myfile" + fileName + ".txt";
            if (File.Exists(arguments) == false)
                File.CreateText(arguments);

            ProcessStartInfo psi = new ProcessStartInfo(fileName, arguments);
            psi.WindowStyle = ProcessWindowStyle.Normal;
            fileIndex++;
            Process pi = new Process();
            pi.StartInfo = psi;
            pi.Start();
            RefreshListView();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Process[] myProcesses;
            myProcesses = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(fileName));
            
            foreach (Process proc in myProcesses)
            {
                
                proc.CloseMainWindow();
                Thread.Sleep(1000);
                proc.Close();
            }

            fileIndex = 0;
            RefreshListView();
            this.Cursor = Cursors.Default;
        }

        private void RefreshListView()
        {
            lvProcessManage.Items.Clear();

            Process[] processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(fileName));
            foreach (Process proc in processes)
            {
                ListViewItem newlsv = new ListViewItem(
                    new string[]{
                        proc.Id.ToString(),
                        proc.ProcessName.ToString(),
                        string.Format("{0}KB",(proc.WorkingSet64 / 1024f).ToString("n2")),
                        proc.StartTime.ToShortTimeString(),
                        proc.MainModule.FileName
                    }
                );
                lvProcessManage.Items.Add(newlsv);
            }
        }
    }
}

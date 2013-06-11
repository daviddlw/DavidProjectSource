using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProcessManagement
{
    public partial class ProcessManagementForm : Form
    {
        public ProcessManagementForm()
        {
            InitializeComponent();
            InitDataGridView();
        }

        /// <summary>
        /// 初始化gridview
        /// </summary>
        private void InitDataGridView()
        {
            dgvProcessLs.AutoSize = false;
            dgvProcessLs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProcessLs.AutoGenerateColumns = false;
            dgvProcessLs.AllowUserToAddRows = false;
            dgvProcessLs.AllowUserToDeleteRows = false;
            dgvProcessLs.AllowUserToResizeColumns = false;

            DataGridViewColumn[] dgvColumns = new DataGridViewColumn[]{
                new DataGridViewColumn(){ Name="ProcessId", HeaderText="进程ID"},
                new DataGridViewColumn(){ Name="ProcessName", HeaderText="进程名称"},
                new DataGridViewColumn(){ Name="ProcessMemory", HeaderText="物理内存"},
                new DataGridViewColumn(){ Name="ProcessStartTime", HeaderText="启动时间"},
                new DataGridViewColumn(){ Name="ProcessFileName", HeaderText="文件名"},
            };

            foreach (DataGridViewColumn column in dgvColumns)
            {
                dgvProcessLs.Columns.Add(column.Name, column.HeaderText);
            }

            GetAllProcess();
        }

        /// <summary>
        /// 获取所有进程
        /// </summary>
        private void GetAllProcess()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process proc in processes)
            {
                int newRowId = dgvProcessLs.Rows.Add();
                DataGridViewRow newRow = dgvProcessLs.Rows[newRowId];

                newRow.Cells["ProcessId"].Value = proc.Id;
                newRow.Cells["ProcessName"].Value = proc.ProcessName;
                newRow.Cells["ProcessMemory"].Value = string.Format("{0}MB", proc.WorkingSet64 / 1024.0f / 1024.0f);

                try
                {
                    newRow.Cells["ProcessStartTime"].Value = proc.StartTime.ToString();
                    newRow.Cells["ProcessFileName"].Value = proc.MainModule.FileName;
                }
                catch (Exception)
                {
                    newRow.Cells["ProcessStartTime"].Value = string.Empty;
                    newRow.Cells["ProcessFileName"].Value = string.Empty;
                }
            }
        }

        /// <summary>
        /// 显示当前进程详情
        /// </summary>
        /// <param name="processId"></param>
        private void ShowProcessDetail(int processId)
        {
            Process proc = Process.GetProcessById(processId);
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.AppendLine("进程ID：" + proc.Id);
                sb.AppendLine("进程名称：" + proc.ProcessName);
                sb.AppendLine("进程优先级：" + proc.BasePriority + "进程类别：" + proc.PriorityClass.ToString());
                sb.AppendLine("物理内存：" + proc.WorkingSet64 / 1024f / 1024f);
                sb.AppendLine("开始时间：" + proc.StartTime.ToString());
                sb.AppendLine("文件名：" + proc.MainModule != null ? proc.MainModule.FileName : string.Empty);
                sb.AppendLine("版本号：" + proc.MainModule != null ? proc.MainModule.FileVersionInfo.FileVersion : string.Empty);
                sb.AppendLine("描述：" + proc.MainModule != null ? proc.MainModule.FileVersionInfo.FileDescription : string.Empty);
                sb.AppendLine("语言：" + proc.MainModule != null ? proc.MainModule.FileVersionInfo.Language : string.Empty);

                if (proc.Modules.Count > 0)
                {
                    sb.AppendLine("调用的模块（.dll）");
                    ProcessModuleCollection item = proc.Modules;

                    for (int i = 1; i < item.Count; i++)
                    {
                        sb.AppendLine(string.Format("模块名：{0}，版本：{1}，描述：{1}", item[i].ModuleName, item[i].FileVersionInfo.FileVersion, item[i].FileVersionInfo.Language));
                    }
                }
            }
            catch (Exception)
            {
                sb.Clear();
                sb.AppendLine("无法获取信息！");
            }

            rtbProcessDetails.Text = sb.ToString();
        }

        /// <summary>
        /// 刷新进程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetAllProcess();
        }

        private void dgvProcessLs_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTest = dgvProcessLs.HitTest(e.X, e.Y);
            if (hitTest.Type == DataGridViewHitTestType.Cell || hitTest.Type == DataGridViewHitTestType.RowHeader)
            {
                dgvProcessLs.Rows[hitTest.RowIndex].Selected = true;
                int processId = (int)dgvProcessLs.CurrentRow.Cells["ProcessId"].Value;
                ShowProcessDetail(processId);
            }


        }
    }
}

namespace ProcessManagement
{
    partial class ProcessManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvProcessLs = new System.Windows.Forms.DataGridView();
            this.rtbProcessDetails = new System.Windows.Forms.RichTextBox();
            this.lbProcessInfo = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessLs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProcessLs
            // 
            this.dgvProcessLs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcessLs.Location = new System.Drawing.Point(28, 12);
            this.dgvProcessLs.Name = "dgvProcessLs";
            this.dgvProcessLs.RowTemplate.Height = 23;
            this.dgvProcessLs.Size = new System.Drawing.Size(618, 297);
            this.dgvProcessLs.TabIndex = 0;
            this.dgvProcessLs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvProcessLs_MouseClick);
            // 
            // rtbProcessDetails
            // 
            this.rtbProcessDetails.Location = new System.Drawing.Point(28, 354);
            this.rtbProcessDetails.Name = "rtbProcessDetails";
            this.rtbProcessDetails.Size = new System.Drawing.Size(618, 96);
            this.rtbProcessDetails.TabIndex = 1;
            this.rtbProcessDetails.Text = "";
            // 
            // lbProcessInfo
            // 
            this.lbProcessInfo.AutoSize = true;
            this.lbProcessInfo.Location = new System.Drawing.Point(26, 327);
            this.lbProcessInfo.Name = "lbProcessInfo";
            this.lbProcessInfo.Size = new System.Drawing.Size(53, 12);
            this.lbProcessInfo.TabIndex = 2;
            this.lbProcessInfo.Text = "进程信息";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(287, 472);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新进程";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ProcessManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 516);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lbProcessInfo);
            this.Controls.Add(this.rtbProcessDetails);
            this.Controls.Add(this.dgvProcessLs);
            this.Name = "ProcessManagementForm";
            this.Text = "进程管理信息";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessLs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProcessLs;
        private System.Windows.Forms.RichTextBox rtbProcessDetails;
        private System.Windows.Forms.Label lbProcessInfo;
        private System.Windows.Forms.Button btnRefresh;
    }
}


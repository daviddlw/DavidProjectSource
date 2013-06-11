namespace DavidWinform
{
    partial class DavidForm
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
            this.lblChineseName = new System.Windows.Forms.Label();
            this.lblEnglishName = new System.Windows.Forms.Label();
            this.lblBirth = new System.Windows.Forms.Label();
            this.lblIsStudent = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblCellphone = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.tabRegisterLs = new System.Windows.Forms.TabControl();
            this.tabRegisterInfo = new System.Windows.Forms.TabPage();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtBirth = new System.Windows.Forms.DateTimePicker();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtFilepath = new System.Windows.Forms.TextBox();
            this.picHead = new System.Windows.Forms.PictureBox();
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCellphone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtEnglishName = new System.Windows.Forms.TextBox();
            this.txtChineseName = new System.Windows.Forms.TextBox();
            this.rdBtnNo = new System.Windows.Forms.RadioButton();
            this.rdBtnYes = new System.Windows.Forms.RadioButton();
            this.tabRegisterList = new System.Windows.Forms.TabPage();
            this.dataGridLs = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabRegisterLs.SuspendLayout();
            this.tabRegisterInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).BeginInit();
            this.tabRegisterList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLs)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChineseName
            // 
            this.lblChineseName.AutoSize = true;
            this.lblChineseName.Location = new System.Drawing.Point(31, 34);
            this.lblChineseName.Name = "lblChineseName";
            this.lblChineseName.Size = new System.Drawing.Size(53, 12);
            this.lblChineseName.TabIndex = 0;
            this.lblChineseName.Text = "中文名：";
            // 
            // lblEnglishName
            // 
            this.lblEnglishName.AutoSize = true;
            this.lblEnglishName.Location = new System.Drawing.Point(31, 68);
            this.lblEnglishName.Name = "lblEnglishName";
            this.lblEnglishName.Size = new System.Drawing.Size(53, 12);
            this.lblEnglishName.TabIndex = 1;
            this.lblEnglishName.Text = "英文名：";
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Location = new System.Drawing.Point(31, 105);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(65, 12);
            this.lblBirth.TabIndex = 2;
            this.lblBirth.Text = "出生年月：";
            // 
            // lblIsStudent
            // 
            this.lblIsStudent.AutoSize = true;
            this.lblIsStudent.Location = new System.Drawing.Point(31, 218);
            this.lblIsStudent.Name = "lblIsStudent";
            this.lblIsStudent.Size = new System.Drawing.Size(65, 12);
            this.lblIsStudent.TabIndex = 3;
            this.lblIsStudent.Text = "是否在读：";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(31, 256);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(65, 12);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "电子邮箱：";
            // 
            // lblCellphone
            // 
            this.lblCellphone.AutoSize = true;
            this.lblCellphone.Location = new System.Drawing.Point(31, 179);
            this.lblCellphone.Name = "lblCellphone";
            this.lblCellphone.Size = new System.Drawing.Size(65, 12);
            this.lblCellphone.TabIndex = 8;
            this.lblCellphone.Text = "联系手机：";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(31, 141);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(65, 12);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "家庭住址：";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(33, 297);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(41, 12);
            this.lblDesc.TabIndex = 9;
            this.lblDesc.Text = "备注：";
            // 
            // tabRegisterLs
            // 
            this.tabRegisterLs.Controls.Add(this.tabRegisterInfo);
            this.tabRegisterLs.Controls.Add(this.tabRegisterList);
            this.tabRegisterLs.Location = new System.Drawing.Point(27, 23);
            this.tabRegisterLs.Name = "tabRegisterLs";
            this.tabRegisterLs.SelectedIndex = 0;
            this.tabRegisterLs.Size = new System.Drawing.Size(558, 472);
            this.tabRegisterLs.TabIndex = 10;
            this.tabRegisterLs.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabRegisterLs_Selected);
            // 
            // tabRegisterInfo
            // 
            this.tabRegisterInfo.Controls.Add(this.btnSubmit);
            this.tabRegisterInfo.Controls.Add(this.txtBirth);
            this.tabRegisterInfo.Controls.Add(this.btnUpload);
            this.tabRegisterInfo.Controls.Add(this.txtFilepath);
            this.tabRegisterInfo.Controls.Add(this.picHead);
            this.tabRegisterInfo.Controls.Add(this.txtDesc);
            this.tabRegisterInfo.Controls.Add(this.txtEmail);
            this.tabRegisterInfo.Controls.Add(this.txtCellphone);
            this.tabRegisterInfo.Controls.Add(this.txtAddress);
            this.tabRegisterInfo.Controls.Add(this.txtEnglishName);
            this.tabRegisterInfo.Controls.Add(this.txtChineseName);
            this.tabRegisterInfo.Controls.Add(this.rdBtnNo);
            this.tabRegisterInfo.Controls.Add(this.rdBtnYes);
            this.tabRegisterInfo.Controls.Add(this.lblChineseName);
            this.tabRegisterInfo.Controls.Add(this.lblDesc);
            this.tabRegisterInfo.Controls.Add(this.lblEnglishName);
            this.tabRegisterInfo.Controls.Add(this.lblCellphone);
            this.tabRegisterInfo.Controls.Add(this.lblBirth);
            this.tabRegisterInfo.Controls.Add(this.lblAddress);
            this.tabRegisterInfo.Controls.Add(this.lblIsStudent);
            this.tabRegisterInfo.Controls.Add(this.lblEmail);
            this.tabRegisterInfo.Location = new System.Drawing.Point(4, 22);
            this.tabRegisterInfo.Name = "tabRegisterInfo";
            this.tabRegisterInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegisterInfo.Size = new System.Drawing.Size(550, 446);
            this.tabRegisterInfo.TabIndex = 0;
            this.tabRegisterInfo.Text = "注册信息";
            this.tabRegisterInfo.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(114, 401);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 23;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtBirth
            // 
            this.txtBirth.Location = new System.Drawing.Point(114, 101);
            this.txtBirth.Name = "txtBirth";
            this.txtBirth.Size = new System.Drawing.Size(178, 21);
            this.txtBirth.TabIndex = 22;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(323, 346);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 21;
            this.btnUpload.Text = "上传";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtFilepath
            // 
            this.txtFilepath.Location = new System.Drawing.Point(323, 308);
            this.txtFilepath.Name = "txtFilepath";
            this.txtFilepath.Size = new System.Drawing.Size(204, 21);
            this.txtFilepath.TabIndex = 20;
            // 
            // picHead
            // 
            this.picHead.Location = new System.Drawing.Point(323, 31);
            this.picHead.Name = "picHead";
            this.picHead.Size = new System.Drawing.Size(204, 251);
            this.picHead.TabIndex = 19;
            this.picHead.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(114, 297);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(178, 82);
            this.txtDesc.TabIndex = 18;
            this.txtDesc.Text = "";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(114, 253);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(178, 21);
            this.txtEmail.TabIndex = 17;
            // 
            // txtCellphone
            // 
            this.txtCellphone.Location = new System.Drawing.Point(114, 176);
            this.txtCellphone.MaxLength = 11;
            this.txtCellphone.Name = "txtCellphone";
            this.txtCellphone.Size = new System.Drawing.Size(178, 21);
            this.txtCellphone.TabIndex = 16;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(114, 138);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(178, 21);
            this.txtAddress.TabIndex = 15;
            // 
            // txtEnglishName
            // 
            this.txtEnglishName.Location = new System.Drawing.Point(114, 65);
            this.txtEnglishName.Name = "txtEnglishName";
            this.txtEnglishName.Size = new System.Drawing.Size(178, 21);
            this.txtEnglishName.TabIndex = 13;
            // 
            // txtChineseName
            // 
            this.txtChineseName.Location = new System.Drawing.Point(114, 31);
            this.txtChineseName.Name = "txtChineseName";
            this.txtChineseName.Size = new System.Drawing.Size(178, 21);
            this.txtChineseName.TabIndex = 12;
            // 
            // rdBtnNo
            // 
            this.rdBtnNo.AutoSize = true;
            this.rdBtnNo.Location = new System.Drawing.Point(165, 218);
            this.rdBtnNo.Name = "rdBtnNo";
            this.rdBtnNo.Size = new System.Drawing.Size(35, 16);
            this.rdBtnNo.TabIndex = 11;
            this.rdBtnNo.TabStop = true;
            this.rdBtnNo.Text = "否";
            this.rdBtnNo.UseVisualStyleBackColor = true;
            // 
            // rdBtnYes
            // 
            this.rdBtnYes.AutoSize = true;
            this.rdBtnYes.Location = new System.Drawing.Point(114, 218);
            this.rdBtnYes.Name = "rdBtnYes";
            this.rdBtnYes.Size = new System.Drawing.Size(35, 16);
            this.rdBtnYes.TabIndex = 10;
            this.rdBtnYes.TabStop = true;
            this.rdBtnYes.Text = "是";
            this.rdBtnYes.UseVisualStyleBackColor = true;
            // 
            // tabRegisterList
            // 
            this.tabRegisterList.Controls.Add(this.btnDelete);
            this.tabRegisterList.Controls.Add(this.btnUpdate);
            this.tabRegisterList.Controls.Add(this.dataGridLs);
            this.tabRegisterList.Location = new System.Drawing.Point(4, 22);
            this.tabRegisterList.Name = "tabRegisterList";
            this.tabRegisterList.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegisterList.Size = new System.Drawing.Size(550, 446);
            this.tabRegisterList.TabIndex = 1;
            this.tabRegisterList.Text = "注册信息列表";
            this.tabRegisterList.UseVisualStyleBackColor = true;
            // 
            // dataGridLs
            // 
            this.dataGridLs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLs.Location = new System.Drawing.Point(18, 19);
            this.dataGridLs.Name = "dataGridLs";
            this.dataGridLs.RowTemplate.Height = 23;
            this.dataGridLs.Size = new System.Drawing.Size(511, 352);
            this.dataGridLs.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(125, 395);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "提交修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(299, 395);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // DavidForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 524);
            this.Controls.Add(this.tabRegisterLs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "DavidForm";
            this.Text = "DavidForm";
            this.tabRegisterLs.ResumeLayout(false);
            this.tabRegisterInfo.ResumeLayout(false);
            this.tabRegisterInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).EndInit();
            this.tabRegisterList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblChineseName;
        private System.Windows.Forms.Label lblEnglishName;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.Label lblIsStudent;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblCellphone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TabControl tabRegisterLs;
        private System.Windows.Forms.TabPage tabRegisterInfo;
        private System.Windows.Forms.TabPage tabRegisterList;
        private System.Windows.Forms.RadioButton rdBtnNo;
        private System.Windows.Forms.RadioButton rdBtnYes;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtFilepath;
        private System.Windows.Forms.PictureBox picHead;
        private System.Windows.Forms.RichTextBox txtDesc;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCellphone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtEnglishName;
        private System.Windows.Forms.TextBox txtChineseName;
        private System.Windows.Forms.DateTimePicker txtBirth;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView dataGridLs;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
    }
}


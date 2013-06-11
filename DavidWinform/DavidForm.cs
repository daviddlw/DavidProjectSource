using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Data.Linq;
using System.Xml.Linq;

namespace DavidWinform
{
    public partial class DavidForm : Form
    {
        public DavidForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 上传图片方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] picExtensionLs = new string[] { ".jpg", ".png", ".gif" };
                string fileExtension = Path.GetExtension(fileDialog.FileName);

                if (picExtensionLs.Contains(fileExtension))
                {
                    Image image = Image.FromStream(fileDialog.OpenFile());
                    picHead.SizeMode = PictureBoxSizeMode.Zoom;
                    picHead.Image = image;
                    txtFilepath.Text = fileDialog.FileName;
                }
                else
                    MessageBox.Show("上传文件格式不为图片类型", "警告框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 提交注册方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            RegisterInfo registerInfo = new RegisterInfo();
            bool isSubmit = true;
            registerInfo.Id = Guid.NewGuid();
            if (string.IsNullOrEmpty(txtChineseName.Text.Trim()))
            {
                MessageBox.Show("中文名不能为空", "警告框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChineseName.Text = string.Empty;
                txtChineseName.Focus();
                txtChineseName.BackColor = Color.Red;
                isSubmit = false;
            }
            else
                registerInfo.ChineseName = txtChineseName.Text;
            registerInfo.EnglishName = txtEnglishName.Text;
            registerInfo.Birth = !string.IsNullOrEmpty(txtBirth.Text.Trim()) ? Convert.ToDateTime(txtBirth.Text) : DateTime.Now;

            registerInfo.Address = txtAddress.Text;
            registerInfo.Cellphone = txtCellphone.Text;
            if (rdBtnYes.Checked)
                registerInfo.IsStudent = true;
            else if (rdBtnNo.Checked)
                registerInfo.IsStudent = false;
            else
                registerInfo.IsStudent = false;

            registerInfo.Email = txtEmail.Text;
            registerInfo.Description = txtDesc.Text;

            try
            {

                FileStream fs = new FileStream(txtFilepath.Text, FileMode.Open, FileAccess.Read);
                byte[] fileBuffer = new byte[fs.Length];
                fs.Read(fileBuffer, 0, fileBuffer.Length);
                registerInfo.PicHead = fileBuffer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告框", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (isSubmit)
                SerializeObj(registerInfo, "持久化");

            MessageBox.Show("提交成功！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 序列化存储对象
        /// </summary>
        /// <param name="obj"></param>
        private void SerializeObj(object obj, string fileName)
        {
            //Xml序列化规则必须创建一个唯一的根节点，就好比此处的StoreInfo
            //string tempPath = @"J:\DavidTest\DavidWinform\bin\Debug";
            string filePath = Directory.GetCurrentDirectory() + "/" + fileName + ".xml";
            //string filePath = tempPath + "/" + fileName + ".xml";
            XmlDocument doc = new XmlDocument();
            if (!File.Exists(filePath))
            {
                XmlNode declarationNode = doc.CreateNode(XmlNodeType.XmlDeclaration, string.Empty, string.Empty);
                XmlElement root = doc.CreateElement("StoreInfo");
                doc.AppendChild(declarationNode);
                doc.AppendChild(root);
                AddStoreNode(doc, obj);
                doc.Save(filePath);
            }
            else
            {
                //doc.LoadXml(xmlString)传入xml格式的参数
                doc.Load(filePath);
                AddStoreNode(doc, obj);
                doc.Save(filePath);
            }
        }

        /// <summary>
        /// 反射添加属性节点
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="obj"></param>
        private void AddStoreNode(XmlDocument doc, object obj)
        {
            Type type = obj.GetType();
            string node = type.Name;
            string byteStr = string.Empty;
            XmlNode root = doc.DocumentElement;
            XmlNode subNode = doc.CreateNode(XmlNodeType.Element, node, null);
            //XmlElement subNode = doc.CreateElement(node);            
            foreach (var item in type.GetProperties())
            {
                if (!item.PropertyType.Name.ToLower().Contains("byte[]"))
                {
                    XmlNode currentNode = doc.CreateNode(XmlNodeType.Element, item.Name.ToString(), null);
                    XmlNode currentNodeText = doc.CreateTextNode(item.GetValue(obj, null).ToString());
                    currentNode.AppendChild(currentNodeText);
                    subNode.AppendChild(currentNode);
                }
            }
            root.AppendChild(subNode);
        }

        private void tabRegisterLs_Selected(object sender, TabControlEventArgs e)
        {
            //linq to xml
            //string tempPath = @"J:\DavidTest\DavidWinform\bin\Debug";
            string storePath = Directory.GetCurrentDirectory() + "/持久化.xml";
            //string storePath = tempPath + "/持久化.xml";
            XElement root = XElement.Load(storePath);

            IEnumerable<XElement> query = from ele in root.Elements("RegisterInfo")
                                          select ele;

            XElement obj = query.ToList<XElement>().First<XElement>();

            DataTable sourceTb = new DataTable();

            foreach (var col in obj.Elements())
            {
                DataColumn column = new DataColumn(col.Name.ToString());
                if (col.Name.ToString() != "PicHeadByteStr")
                    sourceTb.Columns.Add(column);
            }

            foreach (var item in query)
            {
                DataRow row = sourceTb.NewRow();
                foreach (var col in item.Elements())
                {
                    if (col.Name.ToString() != "PicHeadByteStr")
                    row[col.Name.ToString()] = col.Value;
                }
                sourceTb.Rows.Add(row);
            }

            dataGridLs.DataSource = sourceTb;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void DeleteObj(RegisterInfo info)
        {
            string storePath = Directory.GetCurrentDirectory() + "/持久化.xml";
            XElement root = XElement.Load(storePath);

            //XElement delObj = root.Elements("RegisterInfo").Elements().Where(n=>n.Value==string.Empty)
        }
    }
}

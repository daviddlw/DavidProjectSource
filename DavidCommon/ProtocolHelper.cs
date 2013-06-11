using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DavidCommon
{
    public class ProtocolHelper
    {
        private XmlNode fileNode;
        private XmlNode root;

        public ProtocolHelper()
        {

        }

        public ProtocolHelper(string protocol)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(protocol);
            root = doc.DocumentElement;
            fileNode = root.SelectSingleNode("file");
        }

        private FileRequestMode GetRequestMode()
        {
            string mode = fileNode.Attributes["mode"].Value;
            mode = mode.ToLower();

            if (mode == FileRequestMode.Send.ToString().ToLower())
                return FileRequestMode.Send;
            else
                return FileRequestMode.Receive;
        }

        /// <summary>
        /// 获取文件协议
        /// </summary>
        /// <returns></returns>
        public FileProtocol GetFileProtocol()
        {
            string filename = fileNode.Attributes["name"].Value;
            int port = Convert.ToInt32(fileNode.Attributes["port"].Value);
            FileRequestMode mode = GetRequestMode();

            return new FileProtocol(filename, port, mode);
        }
    }
}

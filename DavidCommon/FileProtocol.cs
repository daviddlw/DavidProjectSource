using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DavidCommon
{
    /// <summary>
    /// 文件协议类
    /// </summary>
    public struct FileProtocol
    {
        private readonly string filename;
        private readonly int port;
        private readonly FileRequestMode mode;

        public FileProtocol(string filename, int port, FileRequestMode mode)
        {
            this.filename = filename;
            this.port = port;
            this.mode = mode;
        }

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get { return filename; } }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get { return port; } }

        /// <summary>
        /// 模式
        /// </summary>
        public FileRequestMode Mode { get { return mode; } }

        /// <summary>
        /// 重写ToString()方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("<protocol><file name=\"{0}\" port=\"{1}\" mode=\"{2}\"/></protocol>", filename, port, mode);
        }
    }
}

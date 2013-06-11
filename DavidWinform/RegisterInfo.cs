using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DavidWinform
{
    public class RegisterInfo
    {
        public RegisterInfo() { }

        public Guid Id { get; set; }

        public string ChineseName { get; set; }

        public string EnglishName { get; set; }

        public DateTime Birth { get; set; }

        public string Address { get; set; }

        public string Cellphone { get; set; }

        public bool IsStudent { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public byte[] PicHead { get; set; }

        public string PicHeadByteStr
        {
            get 
            {
                string byteStr = Convert.ToBase64String(this.PicHead);
                return byteStr;
            }
        }
    }
}

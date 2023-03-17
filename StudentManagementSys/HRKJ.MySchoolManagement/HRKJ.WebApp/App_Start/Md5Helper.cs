using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HRKJ.WebApp.App_Start
{
    public class Md5Helper
    {
        public static string Encryption(string str)
        {
            var md5 = MD5.Create();

            byte[] bytes = Encoding.UTF8.GetBytes(str);

            var buffers = md5.ComputeHash(bytes);
            var bufferStr = "";

            for (var i = 0; i < buffers.Length; i++)
            {
                bufferStr += buffers[i].ToString("x2");
            }

            return bufferStr;

        }
    }
}
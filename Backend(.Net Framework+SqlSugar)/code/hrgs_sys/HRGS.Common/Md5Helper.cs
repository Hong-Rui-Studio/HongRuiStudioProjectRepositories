using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;

namespace HRGS.Commons
{
    public class Md5Helper
    {
        public static string Encryption(string str) 
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = Encoding.Default.GetBytes(str);
            byte[] buffer = md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++) 
            {
                sb.Append(buffer[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}

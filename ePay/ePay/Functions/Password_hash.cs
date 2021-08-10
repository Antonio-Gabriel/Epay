using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ePay.Functions
{
    public static class Password_hash
    {
        public static string Hash(string pass) 
        {
            MD5 crypt = MD5.Create();
            byte[] bytes = crypt.ComputeHash(Encoding.ASCII.GetBytes(pass));
            string final_Hash = BitConverter.ToString(bytes);
            return final_Hash.Replace("-", "").ToLower();
        }
    }
}

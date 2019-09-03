using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;  

namespace MeusLembretes.com.Utils
{
    public class Hash
    {
        public static string GerarHash(string texto)
        {
            SHA256 sHA256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            byte[] hash = sHA256.ComputeHash(bytes);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                stringBuilder.Append(hash[i].ToString("X"));
            }
            return stringBuilder.ToString();
        }
    }
}
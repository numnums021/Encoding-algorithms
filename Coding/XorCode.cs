using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Кодирование
{
    class XorCode : Code_Decode
    {
        public void EncryptOrDecrypt(string text, string key, string path)
        {
            var enc = Encoding.Default;
            var bytes = enc.GetBytes(text);
            var bytesKey = enc.GetBytes(key);

            for (int i = 0; i < bytes.Length; i++)
                bytes[i] ^= bytesKey[i % bytesKey.Length];
            string txt = enc.GetString(bytes);
            System.IO.File.WriteAllText(path, txt);
            //return enc.GetString(bytes);
        }
    
        
    }
}

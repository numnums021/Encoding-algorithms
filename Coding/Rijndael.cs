using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Кодирование
{
    class Rijndael : Code_Decode
    {
        public readonly string SALT = @"akfv#oVfktRhrjo!hjm5t";
        string NK = "8", NB = "4", Nr = "14";


        private string SubBytes(object rotl)
        {
            throw new NotImplementedException();
        }

        private object Rotl(string v)
        {
            throw new NotImplementedException();
        }

        private void AddRoundKey(string state, string[] expandedKey)
        {
            throw new NotImplementedException();
        }

        private void FinalRound(string state, string tmp2)
        {
            throw new NotImplementedException();
        }

        private void Round(string state, string tmp)
        {

        }

        private string XOR(string source, string key)
        {
            string final = "";
            string local_key = key;
            while (source.Length > key.Length)
            {
                key = key + local_key;
            }

            for (int i = 0; i < source.Length; i++)
            {
                bool text = Convert.ToBoolean(Convert.ToInt32(source[i].ToString()));
                bool logic_key = Convert.ToBoolean(Convert.ToInt32(key[i].ToString()));

                if (text ^ logic_key)
                    final += "1";
                else
                    final += "0";
            }

            return final;
        }
        public void KeyExpansion(string[] CipherKey, string[] W) // для расширения ключа #1
        {
            for (int i = 0; i < Convert.ToInt32(NK); i += Convert.ToInt32(NK))
            {
                W[i] = CipherKey[i];
            }
            
            for (int j = Convert.ToInt32(NK); j < Convert.ToInt32(NB) * (Convert.ToInt32(NK) - 1); j++)
            {
                W[j] = XOR(W[j - Convert.ToInt32(NK)], SubBytes(XOR(W[j - 1], CipherKey[j])));

                for (int i = 0; i < Convert.ToInt32(NK) && i + j < Convert.ToInt32(NB) * (Convert.ToInt32(NK) + 1); i++)
                {
                    W[i + j] = XOR(W[i + j - Convert.ToInt32(NK)], W[i+j-1]);
                }
            }


        }
        public void KeyExpansion2(string[] CipherKey, string[] W) // для расширения ключа #2
        {
            for (int i = 0; i < Convert.ToInt32(NK); i += Convert.ToInt32(NK))
            {
                W[i] = CipherKey[i];
            }
            for (int j = Convert.ToInt32(NK); j < Convert.ToInt32(NB) * (Convert.ToInt32(NK) - 1); j++)
            {
                int tmp = Convert.ToInt32(NK) - Convert.ToInt32(W[j]);

                W[j] = XOR(W[j - Convert.ToInt32(NK)], SubBytes(XOR(W[j - 1], CipherKey[j])));

                for (int i = 1; i < 4; i++)
                {
                    W[j + i] = XOR(W[j + i - Convert.ToInt32(NK)], W[i + j - 1]);
                }

                W[j + 4] = XOR(W[j + 4 - Convert.ToInt32(NK)], SubBytes(W[j + 3]));

                for (int i = 5; i < Convert.ToInt32(NK); i++)
                {
                    W[i + j] = XOR(W[i + j - Convert.ToInt32(NK)], W[i + j - 1]);
                }
            }

        }

        public void Rjindaeel(string State, string []CipherKey) 
        {
            string[] ExpandedKey = { };
            KeyExpansion(CipherKey ,ExpandedKey);
            AddRoundKey(State, ExpandedKey);
            for (int i = 0; i < Convert.ToInt32(NK); i++)
            {
                string tmp = ExpandedKey[i] + Convert.ToInt32(NB) * i;
                Round(State, tmp);
            }
                string tmp2 = ExpandedKey[0] + Convert.ToInt32(NB) * Convert.ToInt32(NK);
                FinalRound(State, tmp2);
        }

        public void InitializeRijndael(string password, RijndaelManaged rijndael)
        {
            rijndael.KeySize = 128;
            rijndael.BlockSize = 128;
            rijndael.Mode = CipherMode.CBC;
            rijndael.Padding = PaddingMode.PKCS7;

            var bSalt = Encoding.UTF8.GetBytes(SALT);
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, bSalt);
            deriveBytes.IterationCount = 1000;

            rijndael.Key = deriveBytes.GetBytes(rijndael.KeySize / 8);
            rijndael.IV = deriveBytes.GetBytes(rijndael.BlockSize / 8);
        }













        public void Encrypt(string source, string password, string path)
        {
            string encryptedSource;
            using (var rijndael = new RijndaelManaged())
            {
                InitializeRijndael(password, rijndael);
                using (var encryptor = rijndael.CreateEncryptor())
                {
                    var bSorce = Encoding.UTF8.GetBytes(source);
                    encryptedSource = Convert.ToBase64String(encryptor.TransformFinalBlock(bSorce, 0, bSorce.Length));
                }
            }
            System.IO.File.WriteAllText(path, encryptedSource);
            //return encryptedSource;
        }

        public void Decrypt(string source, string password, string path)
        {
            string decryptedSource;
            using (var rijndael = new RijndaelManaged())
            {
                InitializeRijndael(password, rijndael);
                using (var decryptor = rijndael.CreateDecryptor())
                {
                    try
                    {
                        var bSorce = Convert.FromBase64String(source);
                        decryptedSource = Encoding.UTF8.GetString(decryptor.TransformFinalBlock(bSorce, 0, bSorce.Length));
                    }
                    catch (FormatException e)
                    {
                        System.Diagnostics.Trace.WriteLine(e.Message);
                        decryptedSource = null;
                    }
                    catch (CryptographicException e)
                    {
                        System.Diagnostics.Trace.WriteLine(e.Message);
                        decryptedSource = null;
                    }
                }
            }
            System.IO.File.WriteAllText(path, decryptedSource);
            //return decryptedSource;
        }

        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Кодирование
{
    class Simple_DeCode : Code_Decode
    {
        public void Check(string text, string path)
        {

            String[] txt = new String[text.Length]; int t = 0;
            foreach (char c in text)
            {
                Console.Write(c);
                txt[t] = c.ToString();
                t++;
            }

            int key = 5;
            String[,] decode = new String[key, (text.Length / key) + (text.Length % key)];

            Conv(text.Length, decode, txt, key);

            SaveDec(text.Length, decode, key, path);

        }
        private void Conv(int len, String[,] code, String[] txt, int key) // Переносим из одномерного в двумерный массив
        {
            int tmp = 0;
            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < (len / key) + (len % key); j++)
                {
                    if (tmp != txt.Length)
                    {
                        code[i, j] = txt[tmp];
                        tmp++;
                    }
                }
            }
        }

        private void SaveDec(int len, String[,] code, int key, string path)
        {
            string txt = ""; string[,] array_full = new String[(len / key) + (len % key), key];
            int i = 0;
            for (int j = 0; j < (len / key) + (len % key); j++)
            {
                if (j == key)
                {
                    i++; j = 0;
                }
                if (i != (len / key) + (len % key))
                {
                    txt += code[j, i];
                }
                else
                    break;
            }
            txt.Replace("_", " ");
            System.IO.File.WriteAllText(path, txt);
        }
    }
}

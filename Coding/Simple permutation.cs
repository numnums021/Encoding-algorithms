using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Кодирование
{
    class Simple_permutation : Code_Decode
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
            
            int key = 5;////////////////////////КЛЮЧ

            String[,] code = new String[(text.Length / key) + (text.Length % key), key];

            Conv(text.Length, code, txt, key);

            SaveDec(text.Length, code, key, path);

        }

        private void Conv(int len, String[,] code, String[] txt, int key) // Переносим из одномерного в двумерный массив
        {
            int tmp = 0;
            for (int i = 0; i < (len / key) + (len % key); i++)
            {
                for (int j = 0; j < key; j++)
                {
                    if (tmp != txt.Length)
                    {
                        code[i, j] = txt[tmp];
                        tmp++;
                    }
                    else code[i, j] = "_";
                }
            }
        }

        private void SaveDec(int len, String[,] code, int key, string path)
        {
            string txt = "";
            //string[,] array_full = new String[key, (len / key) + (len % key)];
            Console.WriteLine('\n' + "Происходит кодирование...");
            for (int i = 0; i < key; i++)
                for (int j = 0; j < (len / key) + (len % key); j++)
                {
                    //array_full[i, j] = code[j, i];
                    txt += code[j, i];
                }

            //string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(path, txt);
            

        }

    }
}

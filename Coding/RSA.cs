using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Кодирование
{
    class RSA
    {
        char[] characters = new char[] { '#', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                        'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                        'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                        'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                        '8', '9', '0'};

        public void code(string s, string key, string path) 
        {
            string[] tmp = key.Split(new char[] { ' ' });
            long e_ = Convert.ToInt64(tmp[0]),
                        n = Convert.ToInt64(tmp[1]);
            s = s.ToUpper();

            List<string> result = RSA_Endoce(s, e_, n);

            //foreach (string item in result)
            //    txt += item;

            StreamWriter sw = new StreamWriter(path);
            foreach (string item in result)
                sw.WriteLine(item);
            sw.Close();

            //System.IO.File.WriteAllText(path, txt);
        }

        public void decode(string s, string key, string path, string path2) 
        {
            string[] tmp = key.Split(new char[] { ' ' });
            long d = Convert.ToInt64(tmp[0]),
                        n = Convert.ToInt64(tmp[1]);

            List<string> input = new List<string>();
            StreamReader sr = new StreamReader(path2);
            while (!sr.EndOfStream)
            {
                input.Add(sr.ReadLine());
            }

            sr.Close();

            string result = RSA_Dedoce(input, d, n);

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(result);
            sw.Close();

        }
        private List<string> RSA_Endoce(string s, long e, long n)
        {
            List<string> result = new List<string>();

            BigInteger bi;

            for (int i = 0; i < s.Length; i++)
            {
                int index = Array.IndexOf(characters, s[i]);

                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                result.Add(bi.ToString());
            }

            return result;
        }

        private string RSA_Dedoce(List<string> input, long d, long n)
        {
            string result = "";

            BigInteger bi;

            foreach (string item in input)
            {
                bi = new BigInteger(Convert.ToDouble(item));
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                int index = Convert.ToInt32(bi.ToString());

                result += characters[index].ToString();
            }

            return result;
        }

    }
}

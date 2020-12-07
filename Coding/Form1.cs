using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace Кодирование
{
    public partial class Code_Decode : Form
    {

        static string code, decode, path1, path2, key, path3, hideKey, path4;
        public Code_Decode()
        {
            InitializeComponent();
            Lkey.Visible = false;
            btnk.Visible = false;
            p3.Visible = false;
            crkey.Visible = false;
            crkey2.Visible = false;
            sym.Visible = false;
            symb.Visible = false;

            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            
        }

        

        private void p_decode_Click(object sender, EventArgs e) // DeCode
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Thread.Sleep(10000);
            
            if (cb.Text == "Простая перестановка")
            {
                Simple_DeCode Barsik = new Simple_DeCode();
                Barsik.Check(decode, path1);
                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;
                timer.Text = ts.ToString();
                MessageBox.Show("Файл декодирован");
            }
            if (cb.Text == "XOR")
            {
                XorCode Barsik = new XorCode();
                Barsik.EncryptOrDecrypt(decode, key, path1);
                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;
                timer.Text = ts.ToString();
                MessageBox.Show("Файл декодирован");
            }
            if (cb.Text == "DES")
            {
                //
                DES64 des = new DES64();
                des.Decipher(decode, key, path1, code);

                TimeSpan ts = stopWatch.Elapsed;
                timer.Text = ts.ToString();
                MessageBox.Show("Файл декодирован");
            }
            if (cb.Text == "Rijndael")
            {
                //
                Rijndael barsik = new Rijndael();
                barsik.Decrypt(decode, key, path1);
                
                TimeSpan ts = stopWatch.Elapsed;
                timer.Text = ts.ToString();
                MessageBox.Show("Файл декодирован");
            }
            if (cb.Text == "RSA")
            {
                //
                RSA barsik = new RSA();
                barsik.decode(decode, key, path1, path2);
                
                TimeSpan ts = stopWatch.Elapsed;
                timer.Text = ts.ToString();
                MessageBox.Show("Файл декодирован");
            }
        }

        private void p_code_Click(object sender, EventArgs e) // code
        { 
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (cb.Text == "Простая перестановка") {
                Simple_permutation Barsik = new Simple_permutation();
                Barsik.Check(code, path2);
                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;
                timer.Text = ts.ToString();
                MessageBox.Show("Файл закодирован");
            }
            if (cb.Text == "XOR") {
                XorCode Barsik = new XorCode();
                Barsik.EncryptOrDecrypt(code, key, path2);
                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;
                timer.Text = ts.ToString();
                MessageBox.Show("Файл закодирован");
            }
            if (cb.Text == "DES")
            {
                DES64 des = new DES64();
                des.Encrypt(code, key, path2);
                //
                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;
                timer.Text = ts.ToString();
                MessageBox.Show("Файл закодирован");
            }
            if (cb.Text == "Rijndael")
            {
                //
                Rijndael barsik = new Rijndael();
                barsik.Encrypt(code, key, path2);

                TimeSpan ts = stopWatch.Elapsed;
                timer.Text = ts.ToString();
                MessageBox.Show("Файл закодирован");
            }
            if (cb.Text == "RSA")
            {
                //
                RSA barsik = new RSA();
                barsik.code(code, key, path2);

                TimeSpan ts = stopWatch.Elapsed;
                timer.Text = ts.ToString();
                MessageBox.Show("Файл закодирован");
            }
        }

        private void Code_Decode_Load(object sender, EventArgs e)
        {

        }

        private void crkey_Click(object sender, EventArgs e) // создаём ключ для метода XOR
        {
            if (cb.Text == "DES")
            {

                if ((sym.Text != "") && (Convert.ToInt32(sym.Text)) > 0)
                {
                    key = "";
                    double n = 24, mm = 2, a = 0, b = 0, c0 = 0;
                    double m = Math.Pow(mm, n);
                    int tmp = Convert.ToInt32(sym.Text);
                    DateTime dt = DateTime.Now;
                    c0 = (dt.DayOfYear - 1) / 7 + 1; ;
                    key = c0.ToString(); // последовательность псевдослучайных чисел
                    double end = 0;
                    for (int i = 1; i < tmp; i++)
                    {
                        a = Cursor.Position.X;
                        b = Cursor.Position.Y;

                        double t = c0;
                        end = (a * b * t) % m;
                        c0 = (a * b * t) % m;
                        key += end.ToString();
                    }
                    System.IO.File.WriteAllText(path3, key);
                    MessageBox.Show("Ключ создан и записан в выбранный файл!");
                }
                else MessageBox.Show("Введите числа >0");
            }
            if (cb.Text == "RSA")
            {
                if (sym.Text != "")
                {
                    string[] words = sym.Text.Split(new char[] { ' ' });
                    int p = Convert.ToInt32(words[0]), // 101
                        q = Convert.ToInt32(words[1]); // 103

                    if (IsTheNumberSimple(p) && IsTheNumberSimple(q))
                    {
                        long n = p * q;
                        long m = (p - 1) * (q - 1);
                        long d = Calculate_d(m);
                        long e_ = Calculate_e(d, m);

                        txt.Text = "Скрытый ключ - d = " + d.ToString() + ";   n = " + n.ToString();
                        //txt.Text += "Открытый ключ - e = " + e_.ToString() + ";   n = " + n.ToString();

                        string tmp = d.ToString() + " " + n.ToString();
                        System.IO.File.WriteAllText(path4, tmp); // записали скрытый ключ

                        tmp = e_.ToString() + " " + n.ToString();
                        System.IO.File.WriteAllText(path3, tmp); // записали открытый ключ

                        MessageBox.Show("Ключ создан и записан в выбранный файл!");
                    }
                    else
                        MessageBox.Show("p и q не простые числа");
                }
                else MessageBox.Show("Введите числа >0");
            }
        }

        //проверка: простое ли число?
        private bool IsTheNumberSimple(long n)
        {
            if (n < 2)
                return false;

            if (n == 2)
                return true;

            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        private long Calculate_d(long m)
        {
            long d = m - 1;

            for (long i = 2; i <= m; i++)
                if ((m % i == 0) && (d % i == 0)) //если имеют общие делители
                {
                    d--;
                    i = 1;
                }

            return d;
        }

        //вычисление параметра e
        private long Calculate_e(long d, long m)
        {
            long e = 10;

            while (true)
            {
                if ((e * d) % m == 1)
                    break;
                else
                    e++;
            }

            return e;
        }

        private void crkey2_Click(object sender, EventArgs e) // выбираем файл для записи скрытого клюса RSA
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            path4 = openFileDialog1.FileName;
            // читаем файл в строку
            hideKey = System.IO.File.ReadAllText(path4);
            txt.Text = hideKey;
            
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e) // переключение списка
        {
            if (cb.Text == "XOR")
            {
                Lkey.Visible = true;
                btnk.Visible = true;
                p3.Visible = true;
                crkey.Visible = true;
                sym.Visible = true;
                symb.Visible = true;
            }
            if (cb.Text == "DES")
            {
                Lkey.Visible = true;
                btnk.Visible = true;
                p3.Visible = true;

                crkey.Visible = false;
                sym.Visible = false;
                symb.Visible = false;
            }
            if ((cb.Text != "DES") && (cb.Text != "XOR"))
                {
                Lkey.Visible = false;
                btnk.Visible = false;
                p3.Visible = false;
                crkey.Visible = false;
                sym.Visible = false;
                symb.Visible = false;
            }
            if (cb.Text == "Rijndael") 
            {
                Lkey.Visible = true;
                btnk.Visible = true;
                p3.Visible = true;

                crkey.Visible = false;
                sym.Visible = false;
                symb.Visible = false;
            }
            if (cb.Text == "RSA")
            {
                Lkey.Visible = true;
                btnk.Visible = true;
                p3.Visible = true;

                crkey2.Visible = true;
                crkey.Visible = true;
                sym.Visible = true;
                symb.Visible = true;
            }
        }

        private void btnk_Click(object sender, EventArgs e) // открытие ключа для XOR
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            path3 = openFileDialog1.FileName;
            // читаем файл в строку
            key = System.IO.File.ReadAllText(path3);
            txt.Text = key;
            p3.Load(@"C:\Users\User\Desktop\4 курс 1 сем\Зищита информации\Кодирование\img\2.png");
        }
        private void btn_code_Click(object sender, EventArgs e) // открытие 1 файла
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            path1 = openFileDialog1.FileName;
            // читаем файл в строку
            code = System.IO.File.ReadAllText(path1);
            txt.Text = code;
            p1.Load(@"C:\Users\User\Desktop\4 курс 1 сем\Зищита информации\Кодирование\img\2.png");
        }
        private void button1_Click(object sender, EventArgs e) // открытие 2 файла
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            path2 = openFileDialog1.FileName;
            // читаем файл в строку
            decode = System.IO.File.ReadAllText(path2);
            txt.Text = decode;
            p2.Load(@"C:\Users\User\Desktop\4 курс 1 сем\Зищита информации\Кодирование\img\2.png");
        }
        private void p_clear_Click(object sender, EventArgs e) // Полная очистка string и textbox
        {
            txt.Clear();
            code = "";  decode = ""; 
            path1 = "";  path2 = "";  path3 = "";
            key = "";
            p1.Load(@"C:\Users\User\Desktop\4 курс 1 сем\Зищита информации\Кодирование\img\1.png");
            p2.Load(@"C:\Users\User\Desktop\4 курс 1 сем\Зищита информации\Кодирование\img\1.png");
            p3.Load(@"C:\Users\User\Desktop\4 курс 1 сем\Зищита информации\Кодирование\img\1.png");
        }
    }
}

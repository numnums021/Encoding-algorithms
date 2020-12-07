﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Кодирование
{
    public delegate void CreatingKey(ref string key);
    public partial class DES64 : Code_Decode
    {

 #region StartIn
        public CreatingKey key_create;
        int byteSize; 
        int byteSizeDES; 
        int Blocksize;
        int Key_Lenght; 
        int[] ip; 
        int[] ip_reverse; 
        int[] expansion; 
        int[] key_form; 
        int[] shiftkey; //массив для окончательного формирования ключа длиной 48 бит
        int[] p_set; //перестановка блока
        int[] cycle_move; 
        byte[,,] s_block;
        public String Encode_Text{ get; set; } //текст
        public String Decode_Text{ get; set; } //шифр
    public String Decode_Key; //ключ
        public String[] Block_S { get; set; } //блоки сообщения
        public String[] Message_Block { get; set; } //блоки строки
        public String[,] Key_Array { get; set; }
        #endregion

        public DES64() 
        {
            //инициализация переменных
            byteSize = 8;
            byteSizeDES = 64;
            Blocksize = byteSizeDES / byteSize;
            Key_Lenght = 48;
            #region Array
            ip = new int[64] { 58, 50, 42, 34, 26, 18, 10, 2,
                               60, 52, 44, 36, 28, 20, 12, 4,
                               62, 54, 46, 38, 30, 22, 14, 6,
                               64, 56, 48, 40, 32, 24, 16, 8,
                               57, 49, 41, 33, 25, 17,  9, 1,
                               59, 51, 43, 35, 27, 19, 11, 3,
                               61, 53, 45, 37, 29, 21, 13, 5,
                               63, 55, 47, 39, 31, 23, 15, 7 };
            ip_reverse = new int[64] {  40, 8, 48, 16, 56, 24, 64, 32,
                                        39, 7, 47, 15, 55, 23, 63, 31,
                                        38, 6, 46, 14, 54, 22, 62, 30,
                                        37, 5, 45, 13, 53, 21, 61, 29,
                                        36, 4, 44, 12, 52, 20, 60, 28,
                                        35, 3, 43, 11, 51, 19, 59, 27,
                                        34, 2, 42, 10, 50, 18, 58, 26,
                                        33, 1, 41,  9, 49, 17, 57, 25 };
            expansion = new int[48] { 32, 1, 2, 3, 4, 5, 4, 5,
                                       6, 7, 8, 9, 8, 9, 10, 11,
                                      12, 13, 12, 13, 14, 15, 16, 17,
                                      16, 17, 18, 19, 20, 21, 20, 21,
                                      22, 23, 24, 25, 24, 25, 26, 27,
                                      28, 29, 28, 29, 30, 31, 32, 1 };
            key_form = new int[56] { 57, 49, 41, 33, 25, 17, 9,
                                      1, 58, 50, 42, 34, 26, 18,
                                     10,  2, 59, 51, 43, 35, 27,
                                     19, 11,  3, 60, 52, 44, 36,
                                     63, 55, 47, 39, 31, 23, 15,
                                      7, 62, 54, 46, 38, 30, 22,
                                     14,  6, 61, 53, 45, 37, 29,
                                     21, 13,  5, 28, 20, 12,  4 };
            s_block = new byte[8, 4, 16]{
                               {{0x0e, 0x04, 0x0d, 0x01, 0x02, 0x0f, 0x0b, 0x08, 0x03, 0x0a, 0x06, 0x0c, 0x05, 0x09, 0x00, 0x07},
                                {0x00, 0x0f, 0x07, 0x04, 0x0e, 0x02, 0x0d, 0x01, 0x0a, 0x06, 0x0c, 0x0b, 0x09, 0x05, 0x03, 0x08},
                                {0x04, 0x01, 0x04, 0x08, 0x0d, 0x06, 0x02, 0x0b, 0x0f, 0x0c, 0x09, 0x07, 0x03, 0x0a, 0x05, 0x00},
                                {0x0f, 0x0c, 0x08, 0x02, 0x04, 0x09, 0x01, 0x07, 0x05, 0x0b, 0x03, 0x0e, 0x0a, 0x00, 0x06, 0x0d}},
                               {{0x0f, 0x01, 0x08, 0x0e, 0x06, 0x0b, 0x03, 0x04, 0x09, 0x07, 0x02, 0x0d, 0x0c, 0x00, 0x05, 0x0a},
                                {0x03, 0x0d, 0x04, 0x07, 0x0f, 0x02, 0x08, 0x0e, 0x0c, 0x00, 0x01, 0x0a, 0x06, 0x09, 0x0b, 0x05},
                                {0x00, 0x0e, 0x07, 0x0b, 0x0a, 0x04, 0x0d, 0x01, 0x05, 0x08, 0x0c, 0x06, 0x09, 0x03, 0x02, 0x0f},
                                {0x0d, 0x08, 0x0a, 0x01, 0x03, 0x0f, 0x04, 0x02, 0x0b, 0x06, 0x07, 0x0c, 0x00, 0x05, 0x0e, 0x09}},
                               {{0x0a, 0x00, 0x09, 0x0e, 0x06, 0x03, 0x0f, 0x05, 0x01, 0x0d, 0x0c, 0x07, 0x0b, 0x04, 0x02, 0x08},
                                {0x0d, 0x07, 0x00, 0x09, 0x03, 0x04, 0x06, 0x0a, 0x02, 0x08, 0x05, 0x0e, 0x0c, 0x0b, 0x0f, 0x01},
                                {0x0d, 0x06, 0x04, 0x09, 0x08, 0x0f, 0x03, 0x00, 0x0b, 0x01, 0x02, 0x0c, 0x05, 0x0a, 0x0e, 0x07},
                                {0x01, 0x0a, 0x0d, 0x00, 0x06, 0x09, 0x08, 0x07, 0x04, 0x0f, 0x0e, 0x03, 0x0b, 0x05, 0x02, 0x0c}},
                               {{0x07, 0x0d, 0x0e, 0x03, 0x00, 0x06, 0x09, 0x0a, 0x01, 0x02, 0x08, 0x05, 0x0b, 0x0c, 0x04, 0x0f},
                                {0x0d, 0x08, 0x0b, 0x05, 0x06, 0x0f, 0x00, 0x03, 0x04, 0x07, 0x02, 0x0c, 0x01, 0x0a, 0x0e, 0x09},
                                {0x0a, 0x06, 0x09, 0x00, 0x0c, 0x0b, 0x07, 0x0d, 0x0f, 0x01, 0x03, 0x0e, 0x05, 0x02, 0x08, 0x04},
                                {0x03, 0x0f, 0x00, 0x06, 0x0a, 0x01, 0x0d, 0x08, 0x09, 0x04, 0x05, 0x0b, 0x0c, 0x07, 0x02, 0x0e}},
                               {{0x02, 0x0c, 0x04, 0x01, 0x07, 0x0a, 0x0b, 0x06, 0x08, 0x05, 0x03, 0x0f, 0x0d, 0x00, 0x0e, 0x09},
                                {0x0e, 0x0b, 0x02, 0x0c, 0x04, 0x07, 0x0d, 0x01, 0x05, 0x00, 0x0f, 0x0a, 0x03, 0x09, 0x08, 0x06},
                                {0x04, 0x02, 0x01, 0x0b, 0x0a, 0x0d, 0x07, 0x08, 0x0f, 0x09, 0x0c, 0x05, 0x06, 0x03, 0x00, 0x0e},
                                {0x0b, 0x08, 0x0c, 0x07, 0x01, 0x0e, 0x02, 0x0d, 0x06, 0x0f, 0x00, 0x09, 0x0a, 0x04, 0x05, 0x03}},
                               {{0x0c, 0x01, 0x0a, 0x0f, 0x09, 0x02, 0x06, 0x08, 0x00, 0x0d, 0x03, 0x04, 0x0e, 0x07, 0x05, 0x0b},
                                {0x0a, 0x0f, 0x04, 0x02, 0x07, 0x0c, 0x09, 0x05, 0x06, 0x01, 0x0d, 0x0e, 0x00, 0x0b, 0x03, 0x08},
                                {0x09, 0x0e, 0x0f, 0x05, 0x02, 0x08, 0x0c, 0x03, 0x07, 0x00, 0x04, 0x0a, 0x01, 0x0d, 0x01, 0x06},
                                {0x04, 0x03, 0x02, 0x0c, 0x09, 0x05, 0x0f, 0x0a, 0x0b, 0x0e, 0x01, 0x07, 0x06, 0x00, 0x08, 0x0d}},
                               {{0x04, 0x0b, 0x02, 0x0e, 0x0f, 0x00, 0x08, 0x0d, 0x03, 0x0c, 0x09, 0x07, 0x05, 0x0a, 0x06, 0x01},
                                {0x0d, 0x00, 0x0b, 0x07, 0x04, 0x09, 0x01, 0x0a, 0x0e, 0x03, 0x05, 0x0c, 0x02, 0x0f, 0x08, 0x06},
                                {0x01, 0x04, 0x0b, 0x0d, 0x0c, 0x03, 0x07, 0x0e, 0x0a, 0x0f, 0x06, 0x08, 0x00, 0x05, 0x09, 0x02},
                                {0x06, 0x0b, 0x0d, 0x08, 0x01, 0x04, 0x0a, 0x07, 0x09, 0x05, 0x00, 0x0f, 0x0e, 0x02, 0x03, 0x0c}},
                               {{0x0d, 0x02, 0x08, 0x04, 0x06, 0x0f, 0x0b, 0x01, 0x0a, 0x09, 0x03, 0x0e, 0x05, 0x00, 0x0c, 0x07},
                                {0x01, 0x0f, 0x0d, 0x08, 0x0a, 0x03, 0x07, 0x04, 0x0c, 0x05, 0x06, 0x0b, 0x00, 0x0e, 0x09, 0x02},
                                {0x07, 0x0b, 0x04, 0x01, 0x09, 0x0c, 0x0e, 0x02, 0x00, 0x06, 0x0a, 0x0d, 0x0f, 0x03, 0x05, 0x08},
                                {0x02, 0x01, 0x0e, 0x07, 0x04, 0x0a, 0x08, 0x0d, 0x0f, 0x0c, 0x09, 0x00, 0x03, 0x05, 0x06, 0x0b}}};
            p_set = new int[32] {   16,  7, 20, 21, 29, 12, 28, 17,
                                         1, 15, 23, 26,  5, 18, 31, 10,
                                         2,  8, 24, 14, 32, 27,  3,  9,
                                         19, 13, 30,  6, 22, 11,  4, 25};
            shiftkey = new int[48] { 14, 17, 11, 24, 1, 5,
                                      3, 28, 15, 6, 21, 10,
                                     23, 19, 12, 4, 26, 8,
                                     16, 7, 27, 20, 13, 2,
                                     41, 52, 31, 37, 47, 55,
                                     30, 40, 51, 45, 33, 48,
                                     44, 49, 39,56, 34, 53,
                                     46, 42, 50, 36, 29, 32};
            cycle_move = new int[16] { 1, 1, 2, 2,
                                       2, 2, 2, 2,
                                       1, 2, 2, 2,
                                       2, 2, 2, 1 };
            #endregion
            Key_Array = new string[1000, 16];

            // инициализация функций, создающих ключ
            key_create = new CreatingKey(KeyNormalLenght);
            key_create += Create_Key;
            key_create += CD_Form;
        }

        #region OthersFun
        
        private string FormatSourceText(string in_string) // перевод текста в двоичное представление
        {
            byte[] byteString = Encoding.GetEncoding(1251).GetBytes(in_string);// преобразуем строку в нужную нам кодировку
            string out_string = "";
            for (int i = 0; i < in_string.Length; i++)
            {
                string bin_char = Convert.ToString(byteString[i], 2);
                while (bin_char.Length < byteSize)
                    bin_char = "0" + bin_char;
                out_string += bin_char;
            }
            return out_string;
        }

       
        private string FormatEncodedText(string in_string) // перевод текста из двоичной формы в символьную
        {
            byte[] byteString = new byte[Blocksize];
            int index = 0;

            string out_string = "";

            while (in_string.Length > 0)
            {
                string bin_char = in_string.Substring(0, byteSize);
                in_string = in_string.Remove(0, byteSize);
                byteString[index] = Convert.ToByte(bin_char, 2);
                index++;
            }
            out_string = Encoding.GetEncoding(1251).GetString(byteString);
            return out_string;
        }

        
        private string StringNormalLenght(string in_string) //приведение строки к нужной длине
        {
            while (in_string.Length % Blocksize != 0)
            {
                in_string += "#";
            }
            return in_string;
        }

        
        private void KeyNormalLenght(ref string key) // приведение ключа к нужной длине
        {
            while (key.Length < Blocksize)
            {
                key = "D" + key;
            }
            
            if (key.Length > Blocksize) key = key.Substring(0, Blocksize); //если длина ключа нам не подходит, то обрезаем его
            key = FormatSourceText(key);
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

        
        private void CutString(string in_string) // разбитие строки на блоки и перевод их в двоичный формат
        {
            Message_Block = new string[in_string.Length / Blocksize];
            for (int i = 0; i < Message_Block.Length; i++)
            {
                Message_Block[i] = in_string.Substring(i * Blocksize, Blocksize);
                Message_Block[i] = FormatSourceText(Message_Block[i]);
            }
        }
        #endregion

        #region DES
        
        private string IP(string in_string, bool direction) // битовая перестановка
        {
            StringBuilder output = new StringBuilder(in_string); 

            if (direction == true) //в зависимости от второго параметра выбираем либо прямую либо обратную перестановку
            {
                
                for (int i = 0; i < byteSizeDES; i++) // прямая перестановка
                {
                    output[i] = in_string[ip[i] - 1]; // осуществляем перестановку
                }
            }
            else
            {
                // обратная перестановка
                for (int i = 0; i < byteSizeDES; i++)
                {
                    output[i] = in_string[ip_reverse[i] - 1];
                }
            }

            string out_string = output.ToString();
            return out_string;
        }

        
        private string Expansion_Func(string in_string)//функция расширения
        {
            
            StringBuilder output = new StringBuilder(in_string + in_string);// создаем строку в два раза больше из-за разницы в размерах
            for (int i = 0; i < Key_Lenght; i++)
            {
                output[i] = in_string[expansion[i] - 1];
            }
            string out_string = output.ToString();
            return out_string.Substring(0, Key_Lenght);
        }

        private void Create_Key(ref string key_input) // добавление контрольных битов в ключ
        {
            FormatSourceText(key_input);
            int counter = 0, index = 7, i = 0;
            StringBuilder key_string = new StringBuilder(key_input);
            while (i < byteSizeDES)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (key_string[i + j] == 1) counter++;
                }
                if (counter % 2 == 0) key_string[index] = '1';
                else key_string[index] = '0';
                i += 8; index += 8;
            }
            string out_string = key_string.ToString();
            //return out_string;
        }

        
        private void CD_Form(ref string key_input) // формирование блоков C и D
        {
            StringBuilder change_key = new StringBuilder(key_input);
            for (int i = 0; i < byteSizeDES - 8; i++)
            {
                change_key[i] = key_input[key_form[i] - 1];
            }
            //change_key = change_key.Remove(byteSizeDES - 8, 8);
            string out_key = change_key.ToString();
            //return out_key;
        }

        
        private string Cyclic(string key_input, int counter) // левый циклический сдвиг
        {
            string C_key = key_input.Substring(0, key_input.Length / 2);
            string D_key = key_input.Remove(0, key_input.Length / 2);

            for (int i = 0; i < cycle_move[counter]; i++)
            {
                C_key = C_key + C_key[0];
                C_key = C_key.Remove(0, 1);
                D_key = D_key + D_key[0];
                D_key = D_key.Remove(0, 1);
            }

            return C_key + D_key;
        }

        
        private string NextKey(string key_input) // формирование следующего ключа
        {
            StringBuilder out_key = new StringBuilder(key_input);
            for (int i = 0; i < 48; i++)
            {
                out_key[i] = key_input[shiftkey[i] - 1];
            }
            string out_string = out_key.ToString();
            //return out_string.Substring(0, Key_Lenght);
            return out_string;
        }

        
        private string Key_Byte(string in_string)//перестановка битов в ключе
        {
            StringBuilder output = new StringBuilder(in_string);
            for (int i = 0; i < Key_Lenght; i++)
            {
                output[i] = in_string[shiftkey[i] - 1];
            }
            return output.ToString();
        }

        //работа с блоками сообщения

        
        private void CutToBlocks(string in_string)//разбивка сообщения длиной 64 бит на блоки
        {
            Block_S = new string[in_string.Length / 6]; //шесть - потому что блок длиной 6 бит
            for (int i = 0; i < Block_S.Length; i++)
            {
                Block_S[i] = in_string.Substring(i * 6, 6);
            }
        }
        
        private string Block_Code(string in_string, int number)//кодирование одного блока S
        {
            string out_string = in_string[0].ToString() + in_string[5].ToString();
            int row = Convert.ToInt32(out_string, 2);
            int column = Convert.ToInt32(in_string.Substring(1, 4), 2);
            //int row = Convert.ToInt32(in_string.Substring(0, 2), 2);
            //int column = Convert.ToInt32(in_string.Substring(2, 4), 2);

            row = s_block[number, row, column];
            out_string = Convert.ToString(row, 2);

            //на случай, если блок получился меньше 4 бит
            while (out_string.Length < 4)
            {
                out_string = "0" + out_string;
            }

            return out_string;
        }

        
        private string p_shifting(string in_string) // преобразование блоков S после кодирования
        {
            StringBuilder out_string = new StringBuilder(in_string);

            for (int i = 0; i < byteSizeDES / 2; i++)
            {
                out_string[i] = in_string[p_set[i] - 1];
            }
            string final_string = out_string.ToString();
            return final_string;
        }

       
        private string Cipher(string in_string, string key) //функция шифрования сообщения
        {
            string out_string;
            in_string = Expansion_Func(in_string);
            out_string = XOR(in_string, key);
            CutToBlocks(out_string);
            out_string = "";

            for (int i = 0; i < 8; i++)
            {
                Block_S[i] = Block_Code(Block_S[i], i);
                out_string += Block_S[i];
            }
            out_string = p_shifting(out_string);
            return out_string;
        }

        
        private string DES_OneIter_Forward(string in_string, string key_string)//одна итерация кодирования DES
        {
            string Left = in_string.Substring(0, in_string.Length / 2);
            string Right = in_string.Remove(0, in_string.Length / 2);
            string out_string = Right + XOR(Left, Cipher(Right, key_string));
            return out_string;
        }

        
        private string DES_OneIter_Backward(string in_string, string key_string)//одна итерация декодирования DES
        {
            string Left = in_string.Substring(0, in_string.Length / 2);
            string Right = in_string.Remove(0, in_string.Length / 2);
            string out_string = XOR(Cipher(Left, key_string), Right) + Left;
            return out_string;
        }

        //
        #endregion

        public void Encrypt(string ms, string key, string path) 
        {
            // Encode_Text = SourceText.Text; ms
            // Decode_Key = Key.Text; key
            //ByteText.Text = FormatSourceText(Encode_Text);
            Encode_Text = ms; Decode_Key = key;
            string ByteText = FormatSourceText(Encode_Text);

            Encode_Text = StringNormalLenght(Encode_Text);
            CutString(Encode_Text);
            key_create(ref Decode_Key);

            Encode_Text = "";

            for (int i = 0; i < Message_Block.Length; i++)
            {
                Message_Block[i] = IP(Message_Block[i], true); // прямая битовая перестановка
                for (int j = 0; j < 16; j++)
                {
                    Decode_Key = NextKey(Decode_Key); // новый ключ
                    Key_Array[i, j] = Decode_Key;
                    Message_Block[i] = DES_OneIter_Forward(Message_Block[i], Decode_Key); // i итерация кодировки DES
                    Decode_Key = Cyclic(Decode_Key, j); // сдвигаем левый
                }
                Message_Block[i] = IP(Message_Block[i], false); // обратная битовая перестановка
                Encode_Text += FormatEncodedText(Message_Block[i]);
            }
            //EncodedText.Text = Encode_Text;
            string txt = Encode_Text;
            System.IO.File.WriteAllText(path, txt);
        }

        public void Decipher(string ms, string key, string path, string code) 
        {
            Encode_Text = code; Decode_Key = key;
            string ByteText = FormatSourceText(Encode_Text);
            Encode_Text = StringNormalLenght(Encode_Text);
            CutString(Encode_Text);
            key_create(ref Decode_Key);
            Encode_Text = "";

            for (int i = 0; i < Message_Block.Length; i++)
            {
                Message_Block[i] = IP(Message_Block[i], true); // прямая перест.
                for (int j = 0; j < 16; j++)
                {
                    Decode_Key = NextKey(Decode_Key);
                    Key_Array[i, j] = Decode_Key;
                    Message_Block[i] = DES_OneIter_Forward(Message_Block[i], Decode_Key); // i итерация кодировки DES
                    Decode_Key = Cyclic(Decode_Key, j); // сдвиглевый
                }
                Message_Block[i] = IP(Message_Block[i], false); // обр.бит.перест.
                Encode_Text += FormatEncodedText(Message_Block[i]);
            }

            //Decode_Key = Key.Text;
            //Decode_Text = EncodedText.Text;
            //Encode_Text = EncodedText.Text;
            Encode_Text = ms; Decode_Key = key;

            CutString(Encode_Text); // в 2 формат и в блоки
            key_create(ref Decode_Key);
            Encode_Text = "";

            for (int i = 0; i < Message_Block.Length; i++)
            {
                Message_Block[i] = IP(Message_Block[i], true);

                for (int j = 0; j < 16; j++)
                {
                    //Decode_Key = NextKey(Decode_Key); // ?
                    //Key_Array[i, j] = Decode_Key;   // ?
                    Message_Block[i] = DES_OneIter_Backward(Message_Block[i], Key_Array[i, 15 - j]); // i итерация кодировки 
                    Decode_Key = Cyclic(Decode_Key, j); // Левый сдвиг
                }
                Message_Block[i] = IP(Message_Block[i], false);
                Encode_Text += FormatEncodedText(Message_Block[i]); // из 2 в символы
            }

            for (int i = 0; i < Encode_Text.Length; i++)
            {
                if (Encode_Text[i] == '#')
                {
                    Encode_Text = Encode_Text.Remove(i);
                }
            }

            //DecodedText.Text = Encode_Text;
            string txt = Encode_Text;
            System.IO.File.WriteAllText(path, txt);
        }

    }

}

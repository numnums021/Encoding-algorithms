namespace Кодирование
{
    partial class Code_Decode
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Code_Decode));
            this.txt = new System.Windows.Forms.TextBox();
            this.btn_code = new System.Windows.Forms.Button();
            this.lb1 = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.p_clear = new System.Windows.Forms.PictureBox();
            this.p_decode = new System.Windows.Forms.PictureBox();
            this.p_code = new System.Windows.Forms.PictureBox();
            this.p2 = new System.Windows.Forms.PictureBox();
            this.p1 = new System.Windows.Forms.PictureBox();
            this.pB = new System.Windows.Forms.PictureBox();
            this.cb = new System.Windows.Forms.ComboBox();
            this.lb3 = new System.Windows.Forms.Label();
            this.Lkey = new System.Windows.Forms.Label();
            this.btnk = new System.Windows.Forms.Button();
            this.p3 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.TextBox();
            this.crkey = new System.Windows.Forms.Button();
            this.symb = new System.Windows.Forms.Label();
            this.sym = new System.Windows.Forms.TextBox();
            this.crkey2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.p_clear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_decode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p3)).BeginInit();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt.BackColor = System.Drawing.Color.White;
            this.txt.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt.Location = new System.Drawing.Point(26, 28);
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(387, 382);
            this.txt.TabIndex = 1;
            // 
            // btn_code
            // 
            this.btn_code.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_code.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_code.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_code.Location = new System.Drawing.Point(680, 117);
            this.btn_code.Name = "btn_code";
            this.btn_code.Size = new System.Drawing.Size(95, 33);
            this.btn_code.TabIndex = 3;
            this.btn_code.Text = "*Клац*";
            this.btn_code.UseVisualStyleBackColor = true;
            this.btn_code.Click += new System.EventHandler(this.btn_code_Click);
            // 
            // lb1
            // 
            this.lb1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb1.Location = new System.Drawing.Point(419, 122);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(255, 23);
            this.lb1.TabIndex = 4;
            this.lb1.Text = "Выбрать с исходным текстом";
            // 
            // lb2
            // 
            this.lb2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb2.AutoSize = true;
            this.lb2.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb2.Location = new System.Drawing.Point(419, 175);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(223, 23);
            this.lb2.TabIndex = 6;
            this.lb2.Text = "Выбрать файл для записи";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(680, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "*Клац*";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // p_clear
            // 
            this.p_clear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p_clear.Image = global::Кодирование.Properties.Resources.clear;
            this.p_clear.Location = new System.Drawing.Point(744, 235);
            this.p_clear.Name = "p_clear";
            this.p_clear.Size = new System.Drawing.Size(66, 52);
            this.p_clear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p_clear.TabIndex = 11;
            this.p_clear.TabStop = false;
            this.p_clear.Click += new System.EventHandler(this.p_clear_Click);
            // 
            // p_decode
            // 
            this.p_decode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_decode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p_decode.Image = global::Кодирование.Properties.Resources.decode;
            this.p_decode.Location = new System.Drawing.Point(589, 235);
            this.p_decode.Name = "p_decode";
            this.p_decode.Size = new System.Drawing.Size(66, 52);
            this.p_decode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p_decode.TabIndex = 10;
            this.p_decode.TabStop = false;
            this.p_decode.Click += new System.EventHandler(this.p_decode_Click);
            // 
            // p_code
            // 
            this.p_code.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_code.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p_code.Image = global::Кодирование.Properties.Resources.code;
            this.p_code.Location = new System.Drawing.Point(423, 235);
            this.p_code.Name = "p_code";
            this.p_code.Size = new System.Drawing.Size(66, 52);
            this.p_code.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p_code.TabIndex = 9;
            this.p_code.TabStop = false;
            this.p_code.Click += new System.EventHandler(this.p_code_Click);
            // 
            // p2
            // 
            this.p2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p2.Image = global::Кодирование.Properties.Resources._1;
            this.p2.Location = new System.Drawing.Point(787, 165);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(35, 33);
            this.p2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.p2.TabIndex = 8;
            this.p2.TabStop = false;
            // 
            // p1
            // 
            this.p1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p1.Image = global::Кодирование.Properties.Resources._1;
            this.p1.Location = new System.Drawing.Point(787, 117);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(35, 33);
            this.p1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.p1.TabIndex = 7;
            this.p1.TabStop = false;
            // 
            // pB
            // 
            this.pB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pB.Image = global::Кодирование.Properties.Resources.Wallpapers;
            this.pB.Location = new System.Drawing.Point(0, 0);
            this.pB.Name = "pB";
            this.pB.Size = new System.Drawing.Size(822, 466);
            this.pB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB.TabIndex = 0;
            this.pB.TabStop = false;
            // 
            // cb
            // 
            this.cb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb.FormattingEnabled = true;
            this.cb.Items.AddRange(new object[] {
            "Простая перестановка",
            "XOR",
            "DES",
            "Rijndael",
            "RSA"});
            this.cb.Location = new System.Drawing.Point(423, 65);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(297, 31);
            this.cb.TabIndex = 12;
            this.cb.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // lb3
            // 
            this.lb3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb3.AutoSize = true;
            this.lb3.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb3.Location = new System.Drawing.Point(419, 28);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(301, 23);
            this.lb3.TabIndex = 13;
            this.lb3.Text = "Выбрать алгоритм для кодирования";
            // 
            // Lkey
            // 
            this.Lkey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lkey.AutoSize = true;
            this.Lkey.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lkey.Location = new System.Drawing.Point(419, 343);
            this.Lkey.Name = "Lkey";
            this.Lkey.Size = new System.Drawing.Size(179, 23);
            this.Lkey.TabIndex = 14;
            this.Lkey.Text = "Выбрать файл-ключ";
            // 
            // btnk
            // 
            this.btnk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnk.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnk.Location = new System.Drawing.Point(680, 338);
            this.btnk.Name = "btnk";
            this.btnk.Size = new System.Drawing.Size(95, 33);
            this.btnk.TabIndex = 15;
            this.btnk.Text = "*Клац*";
            this.btnk.UseVisualStyleBackColor = true;
            this.btnk.Click += new System.EventHandler(this.btnk_Click);
            // 
            // p3
            // 
            this.p3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p3.Image = global::Кодирование.Properties.Resources._1;
            this.p3.Location = new System.Drawing.Point(787, 338);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(35, 33);
            this.p3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.p3.TabIndex = 16;
            this.p3.TabStop = false;
            // 
            // timer
            // 
            this.timer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timer.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timer.Location = new System.Drawing.Point(26, 416);
            this.timer.Multiline = true;
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(387, 38);
            this.timer.TabIndex = 17;
            // 
            // crkey
            // 
            this.crkey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.crkey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.crkey.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.crkey.Location = new System.Drawing.Point(419, 421);
            this.crkey.Name = "crkey";
            this.crkey.Size = new System.Drawing.Size(142, 33);
            this.crkey.TabIndex = 18;
            this.crkey.Text = "Создать ключ";
            this.crkey.UseVisualStyleBackColor = true;
            this.crkey.Click += new System.EventHandler(this.crkey_Click);
            // 
            // symb
            // 
            this.symb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.symb.AutoSize = true;
            this.symb.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.symb.Location = new System.Drawing.Point(419, 386);
            this.symb.Name = "symb";
            this.symb.Size = new System.Drawing.Size(181, 23);
            this.symb.TabIndex = 19;
            this.symb.Text = "Количество символов";
            // 
            // sym
            // 
            this.sym.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sym.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sym.Location = new System.Drawing.Point(606, 386);
            this.sym.Multiline = true;
            this.sym.Name = "sym";
            this.sym.Size = new System.Drawing.Size(204, 23);
            this.sym.TabIndex = 20;
            this.sym.Text = "101 103";
            // 
            // crkey2
            // 
            this.crkey2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.crkey2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.crkey2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.crkey2.Location = new System.Drawing.Point(567, 421);
            this.crkey2.Name = "crkey2";
            this.crkey2.Size = new System.Drawing.Size(243, 33);
            this.crkey2.TabIndex = 21;
            this.crkey2.Text = "Скрытый ключ";
            this.crkey2.UseVisualStyleBackColor = true;
            this.crkey2.Click += new System.EventHandler(this.crkey2_Click);
            // 
            // Code_Decode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 466);
            this.Controls.Add(this.crkey2);
            this.Controls.Add(this.sym);
            this.Controls.Add(this.symb);
            this.Controls.Add(this.crkey);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.p3);
            this.Controls.Add(this.btnk);
            this.Controls.Add(this.Lkey);
            this.Controls.Add(this.lb3);
            this.Controls.Add(this.cb);
            this.Controls.Add(this.p_clear);
            this.Controls.Add(this.p_decode);
            this.Controls.Add(this.p_code);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.lb2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.btn_code);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.pB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Code_Decode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code-DeCode";
            this.Load += new System.EventHandler(this.Code_Decode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p_clear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_decode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pB;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.Button btn_code;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox p1;
        private System.Windows.Forms.PictureBox p2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox p_code;
        private System.Windows.Forms.PictureBox p_decode;
        private System.Windows.Forms.PictureBox p_clear;
        private System.Windows.Forms.ComboBox cb;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.Label Lkey;
        private System.Windows.Forms.Button btnk;
        private System.Windows.Forms.PictureBox p3;
        private System.Windows.Forms.TextBox timer;
        private System.Windows.Forms.Button crkey;
        private System.Windows.Forms.Label symb;
        private System.Windows.Forms.TextBox sym;
        private System.Windows.Forms.Button crkey2;
    }
}


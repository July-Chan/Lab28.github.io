namespace Lab28
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            listBox3 = new ListBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            button5 = new Button();
            listBox4 = new ListBox();
            button6 = new Button();
            listBox5 = new ListBox();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 33;
            listBox1.Location = new Point(18, 16);
            listBox1.Margin = new Padding(4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(213, 334);
            listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 33;
            listBox2.Location = new Point(239, 16);
            listBox2.Margin = new Padding(4);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(730, 334);
            listBox2.TabIndex = 0;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 33;
            listBox3.Location = new Point(977, 82);
            listBox3.Margin = new Padding(4);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(650, 268);
            listBox3.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(18, 358);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(213, 103);
            button1.TabIndex = 1;
            button1.Text = "Властивості диску";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(18, 469);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(213, 103);
            button2.TabIndex = 1;
            button2.Text = "Перемістити файл";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(240, 358);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(730, 103);
            button3.TabIndex = 1;
            button3.Text = "Властивості каталогу/файлу";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(240, 470);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(730, 103);
            button4.TabIndex = 1;
            button4.Text = "Отримати каталог";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(977, 30);
            label1.Name = "label1";
            label1.Size = new Size(97, 33);
            label1.TabIndex = 2;
            label1.Text = "Фільтр";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1080, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(547, 40);
            textBox1.TabIndex = 3;
            // 
            // button5
            // 
            button5.Location = new Point(978, 358);
            button5.Margin = new Padding(4);
            button5.Name = "button5";
            button5.Size = new Size(649, 103);
            button5.TabIndex = 1;
            button5.Text = "Фільтрувати";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // listBox4
            // 
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 33;
            listBox4.Location = new Point(19, 596);
            listBox4.Margin = new Padding(4);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(952, 334);
            listBox4.TabIndex = 0;
            // 
            // button6
            // 
            button6.Location = new Point(21, 938);
            button6.Margin = new Padding(4);
            button6.Name = "button6";
            button6.Size = new Size(951, 103);
            button6.TabIndex = 1;
            button6.Text = "Переглянути вміст текстового файлу";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // listBox5
            // 
            listBox5.FormattingEnabled = true;
            listBox5.ItemHeight = 33;
            listBox5.Location = new Point(979, 596);
            listBox5.Margin = new Padding(4);
            listBox5.Name = "listBox5";
            listBox5.Size = new Size(648, 334);
            listBox5.TabIndex = 0;
            // 
            // button7
            // 
            button7.Location = new Point(979, 938);
            button7.Margin = new Padding(4);
            button7.Name = "button7";
            button7.Size = new Size(648, 103);
            button7.TabIndex = 1;
            button7.Text = "Переглянути атрибути безпеки";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(978, 470);
            button8.Margin = new Padding(4);
            button8.Name = "button8";
            button8.Size = new Size(649, 103);
            button8.TabIndex = 1;
            button8.Text = "Створити каталог";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(21, 1049);
            button9.Margin = new Padding(4);
            button9.Name = "button9";
            button9.Size = new Size(950, 103);
            button9.TabIndex = 1;
            button9.Text = "Копіювати файл";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(979, 1049);
            button10.Margin = new Padding(4);
            button10.Name = "button10";
            button10.Size = new Size(648, 103);
            button10.TabIndex = 1;
            button10.Text = "Видалити файл";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(21, 1160);
            button11.Margin = new Padding(4);
            button11.Name = "button11";
            button11.Size = new Size(950, 103);
            button11.TabIndex = 1;
            button11.Text = "Редагувати атрибути";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(979, 1160);
            button12.Margin = new Padding(4);
            button12.Name = "button12";
            button12.Size = new Size(648, 103);
            button12.TabIndex = 1;
            button12.Text = "Редагувати текстові файли";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(15F, 33F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1640, 1282);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button12);
            Controls.Add(button10);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button11);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(listBox3);
            Controls.Add(listBox5);
            Controls.Add(listBox4);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "Form1";
            ShowIcon = false;
            Text = "Лабораторна 28 Кривонос";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private ListBox listBox2;
        private ListBox listBox3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private TextBox textBox1;
        private Button button5;
        private ListBox listBox4;
        private Button button6;
        private ListBox listBox5;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
    }
}

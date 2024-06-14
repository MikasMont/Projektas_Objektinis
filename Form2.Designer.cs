using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Projektas
{
    partial class Form2
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
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            sumos = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            label4 = new Label();
            comboBox2 = new ComboBox();
            label5 = new Label();
            pateikimas = new Button();
            dataGridView1 = new DataGridView();
            Trinimas = new Button();
            uzdarimas = new Button();
            keitimas = new Button();
            rodymas = new Button();
            listBox1 = new ListBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 30);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "Data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 68);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Suma";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarMonthBackground = Color.AliceBlue;
            dateTimePicker1.Location = new Point(112, 30);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(218, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // sumos
            // 
            sumos.BackColor = Color.AliceBlue;
            sumos.Location = new Point(112, 65);
            sumos.Name = "sumos";
            sumos.Size = new Size(132, 23);
            sumos.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 254);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 4;
            label3.Text = "Pastaba";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.AliceBlue;
            textBox1.Location = new Point(112, 251);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(216, 123);
            textBox1.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.AliceBlue;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(114, 172);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(218, 23);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 175);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 9;
            label4.Text = "Kategorija";
            // 
            // comboBox2
            // 
            comboBox2.BackColor = Color.AliceBlue;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(114, 211);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(161, 23);
            comboBox2.TabIndex = 10;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 214);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 11;
            label5.Text = "Šaltinis";
            // 
            // pateikimas
            // 
            pateikimas.BackColor = Color.CornflowerBlue;
            pateikimas.Location = new Point(12, 572);
            pateikimas.Name = "pateikimas";
            pateikimas.Size = new Size(125, 43);
            pateikimas.TabIndex = 12;
            pateikimas.Text = "PATEIKTI";
            pateikimas.UseVisualStyleBackColor = false;
            pateikimas.Click += pateikimas_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(371, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(809, 194);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Trinimas
            // 
            Trinimas.BackColor = Color.CornflowerBlue;
            Trinimas.Location = new Point(1021, 244);
            Trinimas.Name = "Trinimas";
            Trinimas.Size = new Size(159, 34);
            Trinimas.TabIndex = 14;
            Trinimas.Text = "TRINTI ĮRAŠĄ";
            Trinimas.UseVisualStyleBackColor = false;
            Trinimas.Click += Trinimas_Click_1;
            // 
            // uzdarimas
            // 
            uzdarimas.BackColor = Color.GhostWhite;
            uzdarimas.Location = new Point(1051, 570);
            uzdarimas.Name = "uzdarimas";
            uzdarimas.Size = new Size(159, 45);
            uzdarimas.TabIndex = 15;
            uzdarimas.Text = "UŽDARYTI";
            uzdarimas.UseVisualStyleBackColor = false;
            uzdarimas.Click += uzdarimas_Click_1;
            // 
            // keitimas
            // 
            keitimas.BackColor = Color.CornflowerBlue;
            keitimas.Location = new Point(856, 244);
            keitimas.Name = "keitimas";
            keitimas.Size = new Size(159, 34);
            keitimas.TabIndex = 16;
            keitimas.Text = "KEISTI ĮRAŠĄ";
            keitimas.UseVisualStyleBackColor = false;
            keitimas.Click += keitimas_Click;
            // 
            // rodymas
            // 
            rodymas.BackColor = Color.CornflowerBlue;
            rodymas.Location = new Point(371, 244);
            rodymas.Name = "rodymas";
            rodymas.Size = new Size(215, 34);
            rodymas.TabIndex = 17;
            rodymas.Text = "Rodyti duomenų bazę";
            rodymas.UseVisualStyleBackColor = false;
            rodymas.Click += rodymas_Click_1;
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.AliceBlue;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(114, 106);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(100, 49);
            listBox1.TabIndex = 18;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            label6.Location = new Point(371, 20);
            label6.Name = "label6";
            label6.Size = new Size(457, 21);
            label6.TabIndex = 19;
            label6.Text = "Duomenų bazėje duomenys yra rodomi dviejų savaičių intervale.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 186);
            label7.Location = new Point(371, 292);
            label7.Name = "label7";
            label7.Size = new Size(130, 20);
            label7.TabIndex = 20;
            label7.Text = "Sąskaitos likutis -";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            label8.Location = new Point(371, 329);
            label8.Name = "label8";
            label8.Size = new Size(76, 19);
            label8.TabIndex = 21;
            label8.Text = "Pajamos -";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            label9.Location = new Point(371, 366);
            label9.Name = "label9";
            label9.Size = new Size(69, 19);
            label9.TabIndex = 22;
            label9.Text = "Išlaidos -";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI", 10F);
            label10.Location = new Point(507, 294);
            label10.Name = "label10";
            label10.Size = new Size(53, 19);
            label10.TabIndex = 23;
            label10.Text = "label10";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Segoe UI", 10F);
            label11.Location = new Point(448, 329);
            label11.Name = "label11";
            label11.Size = new Size(53, 19);
            label11.TabIndex = 24;
            label11.Text = "label11";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Segoe UI", 10F);
            label12.Location = new Point(446, 366);
            label12.Name = "label12";
            label12.Size = new Size(53, 19);
            label12.TabIndex = 25;
            label12.Text = "label12";
            // 
            // button1
            // 
            button1.BackColor = Color.CornflowerBlue;
            button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 186);
            button1.Location = new Point(1021, 292);
            button1.Name = "button1";
            button1.Size = new Size(159, 54);
            button1.TabIndex = 26;
            button1.Text = "PDF kūrimas";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FloralWhite;
            ClientSize = new Size(1222, 627);
            Controls.Add(button1);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(listBox1);
            Controls.Add(rodymas);
            Controls.Add(keitimas);
            Controls.Add(uzdarimas);
            Controls.Add(Trinimas);
            Controls.Add(dataGridView1);
            Controls.Add(pateikimas);
            Controls.Add(label5);
            Controls.Add(comboBox2);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(sumos);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private TextBox sumos;
        private Label label3;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label4;
        private ComboBox comboBox2;
        private Label label5;
        private Button pateikimas;
        private DataGridView dataGridView1;
        private Button Trinimas;
        private Button uzdarimas;
        private Button keitimas;
        private Button rodymas;
        private ListBox listBox1;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Button button1;
    }
}
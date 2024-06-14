namespace Projektas
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            dateTimePicker3 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label15 = new Label();
            label14 = new Label();
            GavimasPDF = new Button();
            label13 = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            listBox1 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Location = new Point(311, 53);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(140, 23);
            dateTimePicker3.TabIndex = 38;
            dateTimePicker3.ValueChanged += dateTimePicker3_ValueChanged;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(135, 53);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(142, 23);
            dateTimePicker2.TabIndex = 37;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10F);
            label15.Location = new Point(283, 53);
            label15.Name = "label15";
            label15.Size = new Size(22, 19);
            label15.TabIndex = 36;
            label15.Text = "iki";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10F);
            label14.Location = new Point(23, 53);
            label14.Name = "label14";
            label14.Size = new Size(103, 19);
            label14.TabIndex = 35;
            label14.Text = "Laikotarpis nuo";
            // 
            // GavimasPDF
            // 
            GavimasPDF.BackColor = Color.CornflowerBlue;
            GavimasPDF.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 186);
            GavimasPDF.Location = new Point(23, 203);
            GavimasPDF.Name = "GavimasPDF";
            GavimasPDF.Size = new Size(141, 38);
            GavimasPDF.TabIndex = 34;
            GavimasPDF.Text = "Spausdinti PDF";
            GavimasPDF.UseVisualStyleBackColor = false;
            GavimasPDF.Click += GavimasPDF_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label13.Location = new Point(23, 18);
            label13.Name = "label13";
            label13.Size = new Size(119, 28);
            label13.TabIndex = 33;
            label13.Text = "ATASKAITA";
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chart1.Legends.Add(legend3);
            chart1.Location = new Point(487, 18);
            chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chart1.Series.Add(series3);
            chart1.Size = new Size(569, 536);
            chart1.TabIndex = 40;
            chart1.Text = "chart1";
            chart1.Click += chart1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 539);
            button1.Name = "button1";
            button1.Size = new Size(134, 44);
            button1.TabIndex = 41;
            button1.Text = "Uždaryti langą";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(23, 360);
            button2.Name = "button2";
            button2.Size = new Size(114, 23);
            button2.TabIndex = 42;
            button2.Text = "Lėšų diagrama";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(23, 319);
            label1.Name = "label1";
            label1.Size = new Size(114, 28);
            label1.TabIndex = 43;
            label1.Text = "Diagramos";
            label1.Click += label1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(26, 164);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(178, 23);
            comboBox1.TabIndex = 47;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(26, 94);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 49);
            listBox1.TabIndex = 48;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1096, 595);
            Controls.Add(listBox1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(chart1);
            Controls.Add(dateTimePicker3);
            Controls.Add(dateTimePicker2);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(GavimasPDF);
            Controls.Add(label13);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dateTimePicker3;
        private DateTimePicker dateTimePicker2;
        private Label label15;
        private Label label14;
        private Button GavimasPDF;
        private Label label13;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button button1;
        private Button button2;
        private Label label1;
        private ComboBox comboBox1;
        private ListBox listBox1;
    }
}
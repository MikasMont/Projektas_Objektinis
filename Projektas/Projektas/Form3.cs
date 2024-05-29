using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;

namespace Projektas
{
    public partial class Form3 : Form
    {
        // Prisijungimas
        public SqlConnection cnn;
        string con = @"Data Source=localhost;Initial Catalog=Projektas;User ID=sa;Password=sa";
        public Form3()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Formos uždarymas 
            DialogResult ats;
            ats = MessageBox.Show("Ar norite uždaryti šį langą?", "Uždarymas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ats == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Diagramos kūrimas, skritulinė diagrama
            DataTable dt = new DataTable();

            string query = @"SELECT SUM(Suma) AS Visos_Lėšos, 
                                    SUM(CASE WHEN Suma > 0 THEN Suma ELSE 0 END) AS Pajamos, 
                                    SUM(CASE WHEN Suma < 0 THEN Suma ELSE 0 END) AS Išlaidos FROM Pinigai";

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            da.Fill(dt);

            chart1.DataSource = dt;

            chart1.Series.Clear();
            Series series = chart1.Series.Add("Pinigai");
            series.ChartType = SeriesChartType.Pie;

            foreach (DataRow row in dt.Rows)
            {
                series.Points.AddXY("Visos_Lėšos", row["Visos_Lėšos"]);
                series.Points.AddXY("Pajamos", row["Pajamos"]);
                series.Points.AddXY("Išlaidos", row["Išlaidos"]);
            }

            chart1.DataBind();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(con);
            {
                connection.Open();

                //  Kategorija ComboBox (comboBox1)
                string queryKategorija = "SELECT ID, Pavadinimas FROM Klasifikatorius";
                SqlCommand cmd = new SqlCommand(queryKategorija, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable kategorijaTable = new DataTable();
                kategorijaTable.Load(reader);
                comboBox1.DataSource = kategorijaTable;
                comboBox1.DisplayMember = "Pavadinimas";
                comboBox1.ValueMember = "ID";


                //  Tipas ListBox1 (listBox1)
                string queryTipas = "SELECT ID, Tipo_pav, Daugiklis FROM Tipas";
                SqlCommand cmdas = new SqlCommand(queryTipas, connection);
                SqlDataReader readeras = cmdas.ExecuteReader();

                DataTable TipasTable = new DataTable();
                TipasTable.Load(readeras);
                listBox1.DataSource = TipasTable;
                listBox1.DisplayMember = "Tipo_pav";
                listBox1.ValueMember = "ID";

                listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
                comboBox1.DataSource = null;





            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue != null)
            {
                DataRowView selectedRow = listBox1.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    int selectedTipasId = Convert.ToInt32(selectedRow["ID"]);

                    SqlConnection connection = new SqlConnection(con);
                    {
                        connection.Open();

                        // Query gauti geras kategorijas pagal pasirinktą tipą (pajamos ar išlaidos)
                        string queryKategorija = "SELECT ID, Pavadinimas FROM Klasifikatorius WHERE Tipas_ID = @TipasID";
                        SqlCommand cmd = new SqlCommand(queryKategorija, connection);
                        {
                            cmd.Parameters.AddWithValue("@TipasID", selectedTipasId);
                            SqlDataReader reader = cmd.ExecuteReader();
                            {
                                DataTable kategorijaTable = new DataTable();
                                kategorijaTable.Load(reader);
                                comboBox1.DataSource = kategorijaTable;
                                comboBox1.DisplayMember = "Pavadinimas";
                                comboBox1.ValueMember = "ID";
                            }
                        }
                    }
                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void GavimasPDF_Click(object sender, EventArgs e)
        {
            // PDF saugojimas rankiniu būdų
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Save report as PDF";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                GeneratePdfReport(saveFileDialog.FileName);
            }
        }

        private void GeneratePdfReport(string filePath)
        {
            PdfWriter writer = new PdfWriter(filePath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            // Failo header
            Paragraph title = new Paragraph("Ataskaita")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(20);
            document.Add(title);

            // Ataskaitos laikotarpis
            Paragraph dateRange = new Paragraph($"Laikotarpis nuo: {dateTimePicker2.Value.ToShortDateString()} iki: {dateTimePicker3.Value.ToShortDateString()}")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(12);
            document.Add(dateRange);

            // Kategorija
            Paragraph category = new Paragraph($"Kategorija: {comboBox1.Text}")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(12);
            document.Add(category);

            // Tipas
            Paragraph type = new Paragraph($"Tipas: {listBox1.Text}")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .SetFontSize(12);
            document.Add(type);

            // SQL užklausa
            string query = @" SELECT Data, Suma, Pastaba, Saltinis.Saltinis FROM Pinigai JOIN Saltinis ON Pinigai.Saltinis_ID = Saltinis.ID WHERE Data BETWEEN @startDate AND @endDate AND Klasif_ID = @categoryID";

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(con);
            
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@startDate", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@endDate", dateTimePicker3.Value);
                cmd.Parameters.AddWithValue("@categoryID", comboBox1.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            

            // Pridedama į PDF
            Table table = new Table(UnitValue.CreatePercentArray(new float[] { 1, 2, 2, 2 })).UseAllAvailableWidth();
            table.AddHeaderCell("Data");
            table.AddHeaderCell("Suma");
            table.AddHeaderCell("Pastaba");
            table.AddHeaderCell("Saltinis");

            foreach (DataRow row in dt.Rows)
            {
                table.AddCell(new Cell().Add(new Paragraph(row["Data"].ToString())));
                table.AddCell(new Cell().Add(new Paragraph(row["Suma"].ToString())));
                table.AddCell(new Cell().Add(new Paragraph(row["Pastaba"].ToString())));
                table.AddCell(new Cell().Add(new Paragraph(row["Saltinis"].ToString())));
            }

            document.Add(table);

            document.Close();
        }

    }
}

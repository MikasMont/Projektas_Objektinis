using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Projektas
{
    public partial class Form2 : Form
    {
        // Prisijungimas į Microsoft SQL ir į duomenų 
        public SqlConnection cnn;
        string connectionString = @"Data Source=localhost;Initial Catalog=Projektas;User ID=sa;Password=sa";
        private System.Windows.Forms.Timer timer;
        public Form2()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10000;
            timer.Tick += new EventHandler(Keitimassum);
            timer.Start();
        }

        private void Keitimassum(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Update label10 sąskaitos likutis
                string sumQuery = "SELECT SUM(Suma) FROM Pinigai";
                using (SqlCommand sumCmd = new SqlCommand(sumQuery, connection))
                {
                    label10.Text = sumCmd.ExecuteScalar()?.ToString() ?? "0";
                }

                // Update label11 pajamos
                string positiveSumQuery = "SELECT SUM(Suma) FROM Pinigai WHERE Suma > 0";
                using (SqlCommand positiveSumCmd = new SqlCommand(positiveSumQuery, connection))
                {
                    label11.Text = positiveSumCmd.ExecuteScalar()?.ToString() ?? "0";
                }

                // Update label12 išlaidos
                string negativeSumQuery = "SELECT SUM(Suma) FROM Pinigai WHERE Suma < 0";
                using (SqlCommand negativeSumCmd = new SqlCommand(negativeSumQuery, connection))
                {
                    label12.Text = negativeSumCmd.ExecuteScalar()?.ToString() ?? "0";
                }
            }
        }


        private void rodymas_Click_1(object sender, EventArgs e)
        {
            // Rodyti duomenų bazę
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            string Query = "SELECT Pinigai.ID, Data, Suma, Pastaba, Pavadinimas, Saltinis, Tipo_pav from Pinigai inner join Klasifikatorius on Pinigai.Klasif_ID=Klasifikatorius.ID inner join Saltinis on Pinigai.Saltinis_ID=Saltinis.ID inner join Tipas on Klasifikatorius.Tipas_ID=Tipas.ID Where Data BETWEEN DATEADD(DAY, -14, GETDATE()) AND GETDATE()";
            SqlCommand cmd = new SqlCommand(Query, cnn);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            cnn.Close();
        }

        private void Trinimas_Click_1(object sender, EventArgs e)
        {
            //Trinti irasa (pasirenkant visą eilutę per DataGridView1)
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            string sql = "DELETE FROM Pinigai WHERE ID = @rowID";
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand deleteRecord = new SqlCommand(sql, cnn);
            {
                cnn.Open();

                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                int rowID = Convert.ToInt32(dataGridView1[0, selectedIndex].Value);

                deleteRecord.Parameters.Add("@rowID", SqlDbType.Int).Value = rowID;
                deleteRecord.ExecuteNonQuery();

                dataGridView1.Rows.RemoveAt(selectedIndex);

            }
        }

        private void keitimas_Click(object sender, EventArgs e)
        {
            // Keisti įrašą (atnaujinti pasirinktą įrašą)
            // Keičiant įrašą reikia pasirinkti visą eilutę per DataGridView ir surašyti norimus naujinimus į langelius ir spausti KEISTI ĮRAŠĄ.
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int rowID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

            string query = "UPDATE Pinigai SET Data = @Data, Suma = @Suma, Pastaba = @Pastaba, Klasif_ID = @Klasif_ID, Saltinis_ID = @Saltinis_ID WHERE ID = @ID";


            String suma = sumos.Text;
            int sumaskai;
            int.TryParse(suma, out sumaskai);
            DataRowView selectedRows = listBox1.SelectedItem as DataRowView;
            int daugiklis = Convert.ToInt32(selectedRows["Daugiklis"]);
            sumaskai *= daugiklis;

            SqlConnection connection = new SqlConnection(connectionString);
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Data", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Suma", sumaskai);
                cmd.Parameters.AddWithValue("@Pastaba", textBox1.Text);
                cmd.Parameters.AddWithValue("@Klasif_ID", (int)comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@Saltinis_ID", (int)comboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@ID", rowID);

                connection.Open();
                cmd.ExecuteNonQuery();
            }

            // Atnaujinti DataGrindView1
            rodymas_Click_1(sender, e);
            MessageBox.Show("Įrašas sėkmingai atnaujintas.", "Patvirtinimas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void uzdarimas_Click_1(object sender, EventArgs e)
        {
            // Programos uždarymas (Form1 ir Form2)
            DialogResult ats;
            ats = MessageBox.Show("Ar norite uždaryti programą?", "Uždarymas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ats == DialogResult.Yes)
            {
                this.Close();
                Environment.Exit(1);
            }
        }

        private void pateikimas_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null || listBox1.SelectedValue == null)
            {
                MessageBox.Show("Prašau pasirinkti tinkamą šaltinį ir kategorija", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlConnection connection = new SqlConnection(connectionString);
            {
                connection.Open();

                DataRowView selectedRow = listBox1.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    int daugiklis = Convert.ToInt32(selectedRow["Daugiklis"]);


                    string query = "INSERT INTO Pinigai (Data, Suma, Pastaba, Klasif_ID, Saltinis_ID) " +
                                   "VALUES (@Data, @Suma, @Pastaba, @Klasif_ID, @Saltinis_ID)";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    {
                        // Pakeisti suma į kitą formatą/value
                        if (!decimal.TryParse(sumos.Text, out decimal suma))
                        {
                            MessageBox.Show("Netinkamas formatas.", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        suma *= daugiklis;

                        // Parametrai
                        cmd.Parameters.AddWithValue("@Data", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@Suma", suma);
                        cmd.Parameters.AddWithValue("@Pastaba", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Klasif_ID", (int)comboBox1.SelectedValue);
                        cmd.Parameters.AddWithValue("@Saltinis_ID", (int)comboBox2.SelectedValue);

                        // Padaryti komandą
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Viskas įkelta sėkmingai", "Patvirtinimas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Nepavyko įkelti įrašus:  " + ex.Message, "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(connectionString);
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


                //  Saltinis ComboBox (comboBox2)
                string querySaltinis = "SELECT ID, Saltinis FROM Saltinis";
                SqlCommand cmda = new SqlCommand(querySaltinis, connection);
                SqlDataReader readera = cmda.ExecuteReader();

                DataTable saltinisTable = new DataTable();
                saltinisTable.Load(readera);
                comboBox2.DataSource = saltinisTable;
                comboBox2.DisplayMember = "Saltinis";
                comboBox2.ValueMember = "ID";



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

                    SqlConnection connection = new SqlConnection(connectionString);
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Įrašyti į laukus
                dateTimePicker1.Value = Convert.ToDateTime(selectedRow.Cells["Data"].Value);
                sumos.Text = selectedRow.Cells["Suma"].Value.ToString();
                textBox1.Text = selectedRow.Cells["Pastaba"].Value.ToString();
                comboBox1.SelectedValue = selectedRow.Cells["Klasif_ID"].Value;
                comboBox2.SelectedValue = selectedRow.Cells["Saltinis_ID"].Value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var forma3 = new Form3();
            forma3.Show();
        }
    }
}

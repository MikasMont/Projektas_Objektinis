using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projektas
{
    public partial class Form1 : Form
    {
        // Prisijungimas � baz�
        private string connectionString = @"Data Source=localhost;Initial Catalog=Projektas;User ID=sa;Password=sa";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            {
                // Tikrinimas, pasi�i�ri ar jau yra toks vartotojas duomen� bazes lentel�je
                // Prisijungimai du: Mikas, mikas123 arba Jonas, jonas123
                string query = "SELECT COUNT(1) FROM Prisijungimai WHERE Vardas=@Vardas AND Slaptazodis=@Slaptazodis";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Vardas", textBox2.Text);
                cmd.Parameters.AddWithValue("@Slaptazodis", textBox1.Text);
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    // Pasl�pti prisijungimo form�
                    this.Hide();
                    // Rodyti pagrindin� form�
                    Form2 mainForm = new Form2();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("�vestas neteisingas naudotojo vardas arba slapta�odis.", "�sp�jimas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Pakei�ia simbolius � �vaig�dutes
            textBox1.PasswordChar = '*';
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Курсач_1._0
{
    public partial class Form7 : Form
    {
        SqlConnection con;
        public Form7()
        {
            InitializeComponent();
            string ass = @"Data Source = DESKTOP-E8UQAJI\SQLEXPRESS; Initial Catalog = Курсач 1.1; Integrated Security = True";
            con = new SqlConnection(ass);
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (textBox1.Text != string.Empty)
            {
                string sa = "select count(*) from Children where squad_id = '" + textBox1.Text + "'";
                string s = "select Children.FIO, Children.age, Children.pol, Squads.squadname," +
                "Smena.season, Children.begin_date, Children.end_date, Children.number, Children.police, " +
                "Children.snilce,Parents.FIO, Parents.number," +
                "Cooperator.FIO, Cooperator.number from Children " +
                "inner join Smena on Children.smena_id = Smena.id " +
                "inner join Squads on Children.squad_id = Squads.id " +
                "inner join Cooperator on Children.Cooperator_id = Cooperator.id " +
                "inner join Parents on Children.Parent_id = Parents.id " +
                "where squad_id = @id and verification = 1";

                SqlCommand c2 = new SqlCommand(sa, con);
                SqlParameter p1 = new SqlParameter("@id", textBox1.Text);
                SqlCommand c = new SqlCommand(s, con);
                con.Open();
                if (Convert.ToInt32(c2.ExecuteScalar()) >= 1)
                {
                    c.Parameters.Add(p1);
                    SqlDataReader read = c.ExecuteReader();
                    List<string[]> data = new List<string[]>();
                    while (read.Read())
                    {
                        data.Add(new string[14]);

                        data[data.Count - 1][0] = read[0].ToString();
                        data[data.Count - 1][1] = read[1].ToString();
                        data[data.Count - 1][2] = read[2].ToString();
                        data[data.Count - 1][3] = read[3].ToString();
                        data[data.Count - 1][4] = read[4].ToString();
                        data[data.Count - 1][5] = read[5].ToString();
                        data[data.Count - 1][6] = read[6].ToString();
                        data[data.Count - 1][7] = read[7].ToString();
                        data[data.Count - 1][8] = read[8].ToString();
                        data[data.Count - 1][9] = read[9].ToString();
                        data[data.Count - 1][10] = read[10].ToString();
                        data[data.Count - 1][11] = read[11].ToString();
                        data[data.Count - 1][12] = read[12].ToString();
                        data[data.Count - 1][13] = read[13].ToString();
                    }
                    read.Close();
                    
                    foreach (string[] a in data)
                        dataGridView1.Rows.Add(a);
                }
                else
                {
                    MessageBox.Show("Такого отряда не существует", "Внимание!", MessageBoxButtons.OK);
                }
                con.Close();


            }
            else
                MessageBox.Show("Заполните поля!", "Внимание!");
        }
    }
}

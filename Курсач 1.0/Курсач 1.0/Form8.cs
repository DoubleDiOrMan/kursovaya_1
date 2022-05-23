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
    public partial class Form8 : Form
    {
        SqlConnection con;
        int f = 0;
        public Form8(int n)
        {
            InitializeComponent();
            string ass = @"Data Source = DESKTOP-E8UQAJI\SQLEXPRESS; Initial Catalog = Курсач 1.1; Integrated Security = True";
            con = new SqlConnection(ass);
            f = n;
            button5.Hide();
            if (f == 1)
            {
                panel1.Hide();
                button4.Hide();
                button5.Show();
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Курсач_1_1DataSet.Squads". При необходимости она может быть перемещена или удалена.
            this.squadsTableAdapter.Fill(this._Курсач_1_1DataSet.Squads);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s1 = "insert into Squads values ('" + textBox2.Text + "')";
            SqlCommand c1 = new SqlCommand(s1, con);

            con.Open();

            if (textBox2.Text != string.Empty)
            {
                if (c1.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Отряж добавлен успешно!", "Внимание", MessageBoxButtons.OK);
                    this.squadsTableAdapter.Fill(this._Курсач_1_1DataSet.Squads);
                }
                else
                {
                    MessageBox.Show("Не удалось", "Внимание!", MessageBoxButtons.OK);
                    this.squadsTableAdapter.Fill(this._Курсач_1_1DataSet.Squads);
                }
            }
            else
            {
                MessageBox.Show("Заполните поля для заполнения", "Внимание!", MessageBoxButtons.OK);
                this.squadsTableAdapter.Fill(this._Курсач_1_1DataSet.Squads);
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = "delete from Squads where id = '" + textBox1.Text + "'";
            string s2 = "select count(*) from Children where squad_id = '" + textBox1.Text + "'";
            string s3 = "delete from Children where squad_id = '" + textBox1.Text + "'";
            SqlCommand c1 = new SqlCommand(s1, con);
            SqlCommand c2 = new SqlCommand(s2, con);
            SqlCommand c3 = new SqlCommand(s3, con);

            con.Open();

            if (textBox1.Text != string.Empty)
            {
                if (Convert.ToInt32(c2.ExecuteScalar()) >= 1)
                {
                    DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить отряд? Удаление произойдет в таблице Children в первую очередь", "Внимание!", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (c3.ExecuteNonQuery() >= 1)
                        {
                            if (c1.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Отряд успешно удален!", "Внимание!", MessageBoxButtons.OK);
                                this.squadsTableAdapter.Fill(this._Курсач_1_1DataSet.Squads);
                            }
                            else
                            {
                                MessageBox.Show("Не удалось удалить", "Внимание!", MessageBoxButtons.OK);
                                this.squadsTableAdapter.Fill(this._Курсач_1_1DataSet.Squads);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не удалось удалить", "Внимание!", MessageBoxButtons.OK);
                            this.squadsTableAdapter.Fill(this._Курсач_1_1DataSet.Squads);
                        }
                            
                    }
                }
                else
                {
                    if (c1.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Отряд успешно удален!", "Внимание!", MessageBoxButtons.OK);
                        this.squadsTableAdapter.Fill(this._Курсач_1_1DataSet.Squads);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось удалить", "Внимание!", MessageBoxButtons.OK);
                        this.squadsTableAdapter.Fill(this._Курсач_1_1DataSet.Squads);
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните поле id для удаления", "Внимание!", MessageBoxButtons.OK);
                this.squadsTableAdapter.Fill(this._Курсач_1_1DataSet.Squads);
            }

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s1 = "update Squads set squadname = '" + textBox2.Text + "' where id = '" + textBox1.Text + "'";
            SqlCommand c1 = new SqlCommand(s1, con);

            con.Open();

            if ((textBox1.Text != string.Empty) && (textBox2.Text != string.Empty))
            {
                if (c1.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Данные обновлены", "Внимание!", MessageBoxButtons.OK);
                    this.squadsTableAdapter.Fill(this._Курсач_1_1DataSet.Squads);
                }
                else
                {
                    MessageBox.Show("Не удалось", "Внимание!", MessageBoxButtons.OK);
                    this.squadsTableAdapter.Fill(this._Курсач_1_1DataSet.Squads);
                }
            }
            else
            {
                MessageBox.Show("Заполните поле id для изменения данных", "Внимание!", MessageBoxButtons.OK);
                this.squadsTableAdapter.Fill(this._Курсач_1_1DataSet.Squads);
            }

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

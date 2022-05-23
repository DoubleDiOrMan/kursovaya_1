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
    public partial class Form4 : Form
    {
        int f;
        SqlConnection con;
        public Form4(int n)
        {
            InitializeComponent();
            string ass = @"Data Source = DESKTOP-E8UQAJI\SQLEXPRESS; Initial Catalog = Курсач 1.1; Integrated Security = True";
            con = new SqlConnection(ass);
            f = n;
            button5.Hide();
            if (f == 1)
            {
                button4.Hide();
                panel1.Hide();
                button5.Show();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Курсач_1_1DataSet1.Parents". При необходимости она может быть перемещена или удалена.
            this.parentsTableAdapter.Fill(this._Курсач_1_1DataSet1.Parents);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s1 = "select count(*) from Children where Parent_id = '" + textBox1.Text + "'";
            string s2 = "delete from Children where Parent_id = '" + textBox1.Text + "'";
            string s3 = "delete from Parents where id = '" + textBox1.Text + "'";

            SqlCommand c1 = new SqlCommand(s1, con);
            SqlCommand c2 = new SqlCommand(s2, con);
            SqlCommand c3 = new SqlCommand(s3, con);

            con.Open();
            if (textBox1.Text != string.Empty)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить Родителя? Будет произведено удаление из еще одной таблицы [Children]", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (Convert.ToInt32(c1.ExecuteScalar()) >= 1)
                    {
                        c2.ExecuteNonQuery();
                        if (Convert.ToInt32(c3.ExecuteNonQuery()) == 1)
                        {
                            MessageBox.Show("Родитель удален!", "ВАЙЯ", MessageBoxButtons.OK);
                            this.parentsTableAdapter.Fill(this._Курсач_1_1DataSet1.Parents);
                        }  
                        else
                        {
                            MessageBox.Show("Не удалось удалить", "Внимание!", MessageBoxButtons.OK);
                            this.parentsTableAdapter.Fill(this._Курсач_1_1DataSet1.Parents);
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(c3.ExecuteNonQuery()) == 1) {
                            MessageBox.Show("Родитель удален!", "ВАЙЯ", MessageBoxButtons.OK);
                            this.parentsTableAdapter.Fill(this._Курсач_1_1DataSet1.Parents);
                        }
                        else
                        {
                            MessageBox.Show("Не удалось удалить", "Внимание!", MessageBoxButtons.OK);
                            this.parentsTableAdapter.Fill(this._Курсач_1_1DataSet1.Parents);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните поле id!", "Внимание!", MessageBoxButtons.OK);
                this.parentsTableAdapter.Fill(this._Курсач_1_1DataSet1.Parents);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = "insert into Parents values ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + maskedTextBox1.Text + "')";
            SqlCommand com = new SqlCommand(s1, con);

            con.Open();

            if ((textBox2.Text != string.Empty)&& (textBox3.Text != string.Empty) && (maskedTextBox1.Text != string.Empty))
            {
                DialogResult result = MessageBox.Show("Вы уверены, в правильности данных?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (Convert.ToInt32(com.ExecuteNonQuery()) == 1)
                    {
                        MessageBox.Show("Данные внесены", "Внимание!", MessageBoxButtons.OK);
                        this.parentsTableAdapter.Fill(this._Курсач_1_1DataSet1.Parents);
                    }
                    else
                    {
                        MessageBox.Show("Перепроверьте данные", "Видимо, что-то пошло не так", MessageBoxButtons.OK);
                        this.parentsTableAdapter.Fill(this._Курсач_1_1DataSet1.Parents);
                    }
                }
            }

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s1 = "update Parents set FIO = '" + textBox2.Text + "', work = '" + textBox3.Text + "', number = '" + maskedTextBox1.Text + "' where id = '" + textBox1.Text + "'";
            SqlCommand c1 = new SqlCommand(s1, con);

            con.Open();

            if ((textBox1.Text != string.Empty) && (textBox2.Text != string.Empty) && (textBox3.Text != string.Empty) && (maskedTextBox1.Text != string.Empty))
            {
                c1.ExecuteNonQuery();
                MessageBox.Show("Данные обновлены", "Внимание!", MessageBoxButtons.OK);
                this.parentsTableAdapter.Fill(this._Курсач_1_1DataSet1.Parents);
            }
            else
            {
                MessageBox.Show("Заполните все поля для изменения данных!", "Внимание!", MessageBoxButtons.OK);
                this.parentsTableAdapter.Fill(this._Курсач_1_1DataSet1.Parents);
            }

            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class Form11 : Form
    {
        int n;
        SqlConnection con;
        int id;
        
        public Form11()
        {
            InitializeComponent();
            string ass = @"Data Source = DESKTOP-E8UQAJI\SQLEXPRESS; Initial Catalog = Курсач 1.1; Integrated Security = True";
            con = new SqlConnection(ass);
            textBox4.Text = "2022-03-25";
            textBox8.Text = "2022-04-15";
            textBox7.Text = "2021-12-04";
            textBox11.Text = "2021-12-25";
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Курсач_1_1DataSet3.Children". При необходимости она может быть перемещена или удалена.
            this.childrenTableAdapter.Fill(this._Курсач_1_1DataSet3.Children);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            n = 1;
            Form4 f4 = new Form4(n);
            f4.Show();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = "delete from Children where id = '" + textBox1.Text + "'";
            string s2 = "select Parent_id from Children where id = '" + textBox1.Text + "'";
            
            SqlCommand c1 = new SqlCommand(s1, con);
            SqlCommand c2 = new SqlCommand(s2, con);

            con.Open();

            if (textBox1.Text != string.Empty)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить ребенка?", "Внимание!", MessageBoxButtons.YesNo);
                DialogResult result1 = MessageBox.Show("Удалить запись о его родителе?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (result1 == DialogResult.Yes)
                    {
                        id = Convert.ToInt32(c2.ExecuteScalar());
                        string s3 = "delete from Parents where id = @id";
                        SqlCommand c3 = new SqlCommand(s3, con);
                        SqlParameter p1 = new SqlParameter("@id", id);
                        c3.Parameters.Add(p1);

                        
                        if (c1.ExecuteNonQuery() == 1)
                        {
                            if (c3.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Записи удалены!", "Внимание!", MessageBoxButtons.OK);
                                this.childrenTableAdapter.Fill(this._Курсач_1_1DataSet3.Children);
                            }
                            else
                            {
                                MessageBox.Show("Не удалось", "Внимание!", MessageBoxButtons.OK);
                                this.childrenTableAdapter.Fill(this._Курсач_1_1DataSet3.Children);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не удалось", "Внимание!", MessageBoxButtons.OK);
                            this.childrenTableAdapter.Fill(this._Курсач_1_1DataSet3.Children);
                        }
                        
                        
                    }
                    else
                    {
                        if (c1.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Запись удалена!", "Внимание!", MessageBoxButtons.OK);
                            this.childrenTableAdapter.Fill(this._Курсач_1_1DataSet3.Children);
                        }
                        else
                        {
                            MessageBox.Show("Не удалось", "Внимание!", MessageBoxButtons.OK);
                            this.childrenTableAdapter.Fill(this._Курсач_1_1DataSet3.Children);
                        }
                    }
                    

                }
            }
            else
            {
                MessageBox.Show("Заполните поле id для удаления записи", "Внимание!", MessageBoxButtons.OK);
                this.childrenTableAdapter.Fill(this._Курсач_1_1DataSet3.Children);
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s1 = "insert into Children values ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + maskedTextBox6.Text + "', '" + textBox5.Text + "', '" + textBox6.Text +
                "', '" + maskedTextBox2.Text + "', '" + maskedTextBox3.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + maskedTextBox1.Text + "', '" +
                maskedTextBox4.Text + "', '" + maskedTextBox5.Text + "')";
            SqlCommand c1 = new SqlCommand(s1, con);

            con.Open();

            if ((textBox2.Text != string.Empty) && (textBox3.Text != string.Empty) && (textBox5.Text != string.Empty) && (textBox6.Text != string.Empty) &&
                (textBox9.Text != string.Empty) && (textBox10.Text != string.Empty) && (maskedTextBox1.Text != string.Empty) && (maskedTextBox2.Text != string.Empty) &&
                (maskedTextBox3.Text != string.Empty) && (maskedTextBox4.Text != string.Empty) && (maskedTextBox5.Text != string.Empty) && (maskedTextBox6.Text != string.Empty))
            {
                DialogResult result = MessageBox.Show("Вы уверены в правильность данных?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {                    
                    if (c1.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Данные внесены!", "Внимание!", MessageBoxButtons.OK);
                        this.childrenTableAdapter.Fill(this._Курсач_1_1DataSet3.Children);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось", "Внимание!", MessageBoxButtons.OK);
                        this.childrenTableAdapter.Fill(this._Курсач_1_1DataSet3.Children);
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля для внесения данных", "Внимание", MessageBoxButtons.OK);
                this.childrenTableAdapter.Fill(this._Курсач_1_1DataSet3.Children);
            }

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            n = 1;
            Form9 f9 = new Form9(n);
            f9.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            n = 1;
            Form8 f8 = new Form8(n);
            f8.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            n = 1;
            Form10 f10 = new Form10(n);
            f10.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "update Children set FIO = '" + textBox2.Text + "', age = '" + textBox3.Text + "', pol = '" + maskedTextBox6.Text + "', squad_id = '" + textBox5.Text +
                "', smena_id = '" + textBox6.Text + "', begin_date = '" + maskedTextBox2.Text + "', end_date = '" + maskedTextBox3.Text + "', Parent_id = '" + textBox9.Text +
                "', Cooperator_id = '" + textBox10.Text + "', number = '" + maskedTextBox1.Text + "', police = '" + maskedTextBox4.Text + "', snilce = '" + maskedTextBox5.Text + 
                "' where id = '" + textBox1.Text + "'";

            SqlCommand c1 = new SqlCommand(s, con);

            con.Open();

            if ((textBox1.Text != string.Empty) && (textBox2.Text != string.Empty) && (textBox3.Text != string.Empty) && (textBox5.Text != string.Empty) && (textBox6.Text != string.Empty) &&
                (textBox9.Text != string.Empty) && (textBox10.Text != string.Empty) && (maskedTextBox1.Text != string.Empty) && (maskedTextBox2.Text != string.Empty) &&
                (maskedTextBox3.Text != string.Empty) && (maskedTextBox4.Text != string.Empty) && (maskedTextBox5.Text != string.Empty) && (maskedTextBox6.Text != string.Empty))
            {
                DialogResult result = MessageBox.Show("Вы уверены в правильности данных?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (c1.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Данные успешно изменены!", "Внимание!", MessageBoxButtons.OK);
                        this.childrenTableAdapter.Fill(this._Курсач_1_1DataSet3.Children);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось", "Внимание!", MessageBoxButtons.OK);
                        this.childrenTableAdapter.Fill(this._Курсач_1_1DataSet3.Children);
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля, в том числе id, чтобы изменить данные", "Внимание!", MessageBoxButtons.OK);
                this.childrenTableAdapter.Fill(this._Курсач_1_1DataSet3.Children);
            }
            
            con.Close();
        }
    }
}

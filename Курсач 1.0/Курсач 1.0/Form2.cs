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
    public partial class Form2 : Form
    {
        SqlConnection con;
        public Form2()
        {
            InitializeComponent();
            string asscon = @"Data Source = DESKTOP-E8UQAJI\SQLEXPRESS; Initial Catalog = Курсач 1.1; Integrated Security = True";
            con = new SqlConnection(asscon);
            textBox4.Hide();
            label5.Hide();
            button3.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ass2 = "insert into users values (@login, @name, 'par', HASHBYTES('SHA2_256', convert(varchar(50), @pass)))";
            string ass1 = "select count(*) from users where login = @login";

            SqlParameter p1 = new SqlParameter("@login", textBox1.Text);

            SqlParameter p2_1 = new SqlParameter("@login", textBox1.Text);
            SqlParameter p2_2 = new SqlParameter("@name", textBox2.Text);
            SqlParameter p2_3 = new SqlParameter("@pass", textBox3.Text);

            SqlCommand cm = new SqlCommand(ass1, con);
            
            SqlCommand cm2 = new SqlCommand(ass2, con);

            cm.Parameters.Add(p1);

            cm2.Parameters.Add(p2_1);
            cm2.Parameters.Add(p2_2);
            cm2.Parameters.Add(p2_3);

            con.Open();

            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (comboBox1.Text == string.Empty))
            {
                MessageBox.Show("Поля должны быть заполнены!", "Айяйяй");
            }
            else
            {
                if (Convert.ToInt32(cm.ExecuteScalar()) == 0)
                {
                    if (comboBox1.Text == "Работник")
                    {
                        button1.Hide();
                        button2.Hide();
                        button3.Show();
                        label1.Hide();
                        label2.Hide();
                        label3.Hide();
                        label4.Hide();
                        textBox1.Hide();
                        textBox2.Hide();
                        textBox3.Hide();
                        comboBox1.Hide();
                        checkBox1.Hide();
                        label5.Show();
                        textBox4.Show();
                                
                        
                    }
                    else
                    {
                        if (Convert.ToInt32(cm2.ExecuteNonQuery()) == 1)
                        {
                            MessageBox.Show("К сожалению, вы зарегестрировались", "Успех!");
                            Form1 f1 = new Form1();
                            f1.Show();
                            this.Hide();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("К счастью, такой логин занят)", "ОЙойой!");
                }
            }
            con.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ass = "insert into users values (@login, @name, 'user', HASHBYTES('SHA2_256', convert(varchar(50), @pass)))";
            SqlParameter p1_1 = new SqlParameter("@login", textBox1.Text);
            SqlParameter p1_2 = new SqlParameter("@name", textBox2.Text);
            SqlParameter p1_3 = new SqlParameter("@pass", textBox3.Text);
            SqlCommand cm1 = new SqlCommand(ass, con);

            cm1.Parameters.Add(p1_1);
            cm1.Parameters.Add(p1_2);
            cm1.Parameters.Add(p1_3);

            con.Open();

            if (textBox4.Text == "киса")
                if (cm1.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Вы успешно зарегестрировались!", "Успех!");
                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Hide();
                }
            con.Close();
        }
    }
}

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
    public partial class Form1 : Form
    {
        SqlConnection con;
        string n = "";
        int s;
        public Form1()
        {
            InitializeComponent();
            string ass = @"Data Source = DESKTOP-E8UQAJI\SQLEXPRESS; Initial Catalog = Курсач 1.1; Integrated Security = True";
            con = new SqlConnection(ass);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kia5 = "select id from users where login = @login";
            
            string kia = "select count(*) from users where login = @login and hashpass = HASHBYTES('SHA2_256', convert(varchar(50), @pass))";
            string kia1 = "select name from users where login = @login";
            string kia2 = "select count(*) from users where login = @login and role = 'admin'";
            string kia3 = "select count(*) from users where login = @login and role = 'par'";
            string kia4 = "select count(*) from users where login = @login and role = 'user'";
            SqlParameter p1 = new SqlParameter("@login", textBox1.Text);
            SqlParameter p2 = new SqlParameter("@login", textBox1.Text);
            SqlParameter p3 = new SqlParameter("@login", textBox1.Text);

            SqlParameter p5 = new SqlParameter("@login", textBox1.Text);
            SqlParameter p6 = new SqlParameter("@login", textBox1.Text);

            SqlParameter p4 = new SqlParameter("@pass", textBox2.Text);

            SqlParameter p10 = new SqlParameter("@login", textBox1.Text);

            SqlCommand cm1 = new SqlCommand(kia, con);
            SqlCommand cm2 = new SqlCommand(kia1, con);
            SqlCommand cm3 = new SqlCommand(kia2, con);
            
            SqlCommand cm4 = new SqlCommand(kia3, con);
            SqlCommand cm5 = new SqlCommand(kia4, con);

            SqlCommand cm6 = new SqlCommand(kia5, con);
            
            cm1.Parameters.Add(p1);
            cm1.Parameters.Add(p4);
            cm2.Parameters.Add(p2);
            cm3.Parameters.Add(p3);

            cm4.Parameters.Add(p5);
            cm5.Parameters.Add(p6);

            cm6.Parameters.Add(p10);


            con.Open();
            if (Convert.ToInt32(cm1.ExecuteScalar()) == 1)
            {
                if (Convert.ToInt32(cm3.ExecuteScalar()) == 1)
                {
                    MessageBox.Show("Привет, админ " + Convert.ToString(cm2.ExecuteScalar()) + "!", "Добро пожаловать!");
                    n = Convert.ToString(cm2.ExecuteScalar());
                    Form3 f3 = new Form3();
                   
                    f3.Show();
                    this.Hide();
                }
                else
                {
                    if (Convert.ToInt32(cm4.ExecuteScalar()) == 1)
                    {
                        MessageBox.Show("Здравствуйте, " + Convert.ToString(cm2.ExecuteScalar()) + "!", "Добро пожаловать!");
                        Form5 f5 = new Form5();
                        f5.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Привет, снова здесь, " + Convert.ToString(cm2.ExecuteScalar()) + "?", "Удачи тебе...");
                        Form7 f7 = new Form7();
                        f7.Show();
                        this.Hide();
                    }
                }

            }
            else
            {
                if ((textBox1.Text == "") || (textBox2.Text == ""))
                {
                    MessageBox.Show("Что же ты тут делаешь тогда?", "Я рад, что ты даже не пытаешься");
                }
                else
                {
                    MessageBox.Show("Логин/Пароль НеВерный!!!", "Как так-то, ну...");
                }

            }
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            s = 0;
            Form10 f10 = new Form10(s);
            f10.Show();
            this.Hide();
        }
    }
}

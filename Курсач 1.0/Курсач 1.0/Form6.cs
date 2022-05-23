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
   
    public partial class Form6 : Form
    {
        SqlConnection con;
        int n = 0;
        int s = 0;
        public Form6()
        {
            InitializeComponent();
            string ass = @"Data Source = DESKTOP-E8UQAJI\SQLEXPRESS; Initial Catalog = Курсач 1.1; Integrated Security = True";
            con = new SqlConnection(ass);
            textBox4.Hide();
            textBox6.Hide();
            
            
            button2.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label12.Hide();
            textBox3.Hide();
            textBox5.Hide();
            maskedTextBox2.Hide();
            maskedTextBox3.Hide();
            maskedTextBox4.Hide();
            maskedTextBox5.Hide();
            
            label13.Hide();
            comboBox1.Hide();
            label14.Hide();
            label15.Hide();
            label16.Hide();

            button3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != string.Empty) && (textBox2.Text != string.Empty) && (maskedTextBox1.Text != string.Empty))
            {
                if (n == 0)
                {
                    string s1 = "insert into Parents values ( convert(nvarchar(75), @fio), convert(nvarchar(50), @work), convert(nvarchar(16), @number) )";
                    SqlParameter p1 = new SqlParameter("@fio", textBox1.Text);
                    SqlParameter p2 = new SqlParameter("@work", textBox2.Text);
                    SqlParameter p3 = new SqlParameter("@number", maskedTextBox1.Text);
                    SqlCommand c2 = new SqlCommand(s1, con);

                    c2.Parameters.Add(p1);
                    c2.Parameters.Add(p2);
                    c2.Parameters.Add(p3);
                    con.Open();
                    if (s == 0)
                    {
                        s = c2.ExecuteNonQuery();
                    }
                    con.Close();

                    textBox1.Hide();
                    textBox2.Hide();
                    maskedTextBox1.Hide();
                    label1.Hide();
                    label2.Hide();
                    label3.Hide();
                    label11.Hide();

                    label4.Show();
                    label5.Show();
                    label6.Show();
                    label7.Show();
                    label8.Show();
                    label9.Show();
                    label10.Show();
                    label12.Show();
                    textBox3.Show();
                    textBox5.Show();
                    maskedTextBox2.Show();
                    maskedTextBox3.Show();
                    maskedTextBox4.Show();
                    maskedTextBox5.Show();
                    button2.Show();
                    n = 1;

                }
                else
                    if ((textBox3.Text != string.Empty) && (textBox5.Text != string.Empty) && (maskedTextBox2.Text != string.Empty) &&
                    (maskedTextBox3.Text != string.Empty) && (maskedTextBox4.Text != string.Empty) && (maskedTextBox5.Text != string.Empty))
                {
                    label4.Hide();
                    label5.Hide();
                    label6.Hide();
                    label7.Hide();
                    label8.Hide();
                    label9.Hide();
                    label10.Hide();
                    label12.Hide();
                    textBox3.Hide();
                    textBox5.Hide();
                    maskedTextBox2.Hide();
                    maskedTextBox3.Hide();
                    maskedTextBox4.Hide();
                    maskedTextBox5.Hide();

                    label13.Show();
                    comboBox1.Show();
                    label14.Show();
                    label15.Show();
                    label16.Show();

                    button1.Hide();
                    button3.Show();

                    n = 2;
                }
                else
                    MessageBox.Show("Заполните поля!", "Внимание!");
            }
            else
                MessageBox.Show("Заполните поля!", "Внимание!");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (n == 1)
            {
                label4.Hide();
                label5.Hide();
                label6.Hide();
                label7.Hide();
                label8.Hide();
                label9.Hide();
                label10.Hide();
                label12.Hide();
                textBox3.Hide();
                textBox5.Hide();
                maskedTextBox2.Hide();
                maskedTextBox3.Hide();
                maskedTextBox4.Hide();
                maskedTextBox5.Hide();
                button2.Hide();

                textBox1.Show();
                textBox2.Show();
                maskedTextBox1.Show();
                label1.Show();
                label2.Show();
                label3.Show();
                label11.Show();
                n = 0;
            }
            if (n == 2)
            {
                label13.Hide();
                comboBox1.Hide();
                label14.Hide();
                label15.Hide();
                label16.Hide();
                button3.Hide();

                label4.Show();
                label5.Show();
                label6.Show();
                label7.Show();
                label8.Show();
                label9.Show();
                label10.Show();
                label12.Show();
                textBox3.Show();
                textBox5.Show();
                maskedTextBox2.Show();
                maskedTextBox3.Show();
                maskedTextBox4.Show();
                maskedTextBox5.Show();
                button2.Show();
                button1.Show();

                n = 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int squad = 0;
            int squad1 = 0;
            int squad2 = 0;
            int smena = 0;
            int coop = 0;
            int par_id = 0;

            int age = Convert.ToInt32(textBox5.Text);
            int sm = Convert.ToInt32(comboBox1.Text);

            string begindate = "";
            string enddate = "";

            string begindate2 = "2021-12-04";
            string enddate2 = "2021-12-25";

            string begindate1 = "2022-03-25";
            string enddate1 = "2022-04-15";

            string s2 = "insert into Children values (\'" + textBox3.Text + "\', \'" + textBox5.Text + "\', \'" + maskedTextBox3.Text + "\', " +
                "\'" + squad + "\', \'" + smena + "\', \'" + begindate + "\', \'" + enddate + "\', \'" + par_id + "\', " +
                "\'" + coop + "\', \'" + maskedTextBox2.Text + "\', \'" + maskedTextBox4.Text + "\', \'" + maskedTextBox5.Text + "\')";

            string s3 = "select id from Parents where FIO = @fio";
            SqlParameter p3 = new SqlParameter("@fio", textBox1.Text);

            

            SqlCommand c2 = new SqlCommand(s2, con);
            SqlCommand c3 = new SqlCommand(s3, con);
            c3.Parameters.Add(p3);

           

            con.Open();

            if (sm == 2)
            {
                if ((sm == 2) && (age == 6))
                {
                    smena = 2;

                    begindate = begindate2;
                    enddate = enddate2;
                    squad = 4;
                    par_id = Convert.ToInt32(c3.ExecuteScalar());
                    coop = 1;
                    s2 = "insert into Children values (\'" + textBox3.Text + "\', \'" + textBox5.Text + "\', \'" + maskedTextBox3.Text + "\', " +
               "\'" + squad + "\', \'" + smena + "\', \'" + begindate + "\', \'" + enddate + "\', \'" + par_id + "\', " +
               "\'" + coop + "\', \'" + maskedTextBox2.Text + "\', \'" + maskedTextBox4.Text + "\', \'" + maskedTextBox5.Text + "\')";
                    c2 = new SqlCommand(s2, con);
                    if (Convert.ToInt32(c2.ExecuteNonQuery()) == 1)
                    {
                        MessageBox.Show("Его отряд номер " + squad, "И вот...");
                        Form7 f7 = new Form7();
                        f7.Show();
                        this.Hide();
                    }
                       
                }
                else
                {
                    if ((sm == 2) && (age == 7))
                    {
                        smena = 2;

                        begindate = begindate2;
                        enddate = enddate2;
                        string s4 = "select count(*) from Children where smena_id = @smena and squad_id = @squad";
                        SqlCommand c4 = new SqlCommand(s4, con);

                        SqlParameter p1 = new SqlParameter("@smena", smena);
                        SqlParameter p2 = new SqlParameter("@squad", textBox4.Text);

                        c4.Parameters.Add(p1);
                        c4.Parameters.Add(p2);

                        squad = 3;
                        squad1 = Convert.ToInt32(c4.ExecuteScalar());
                        squad = 4;
                        squad2 = Convert.ToInt32(c4.ExecuteScalar());
                        if (squad1 > squad2)
                        {
                            squad = 4;
                            par_id = Convert.ToInt32(c3.ExecuteScalar());
                            coop = 1;
                            s2 = "insert into Children values (\'" + textBox3.Text + "\', \'" + textBox5.Text + "\', \'" + maskedTextBox3.Text + "\', " +
               "\'" + squad + "\', \'" + smena + "\', \'" + begindate + "\', \'" + enddate + "\', \'" + par_id + "\', " +
               "\'" + coop + "\', \'" + maskedTextBox2.Text + "\', \'" + maskedTextBox4.Text + "\', \'" + maskedTextBox5.Text + "\', 'false')";
                            c2 = new SqlCommand(s2, con);
                            if (c2.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Его отряд номер " + squad, "И вот...");
                                Form7 f7 = new Form7();
                                f7.Show();
                                this.Hide();
                            }

                        }
                        if (squad1 < squad2)
                        {
                            squad = 3;
                            par_id = Convert.ToInt32(c3.ExecuteScalar());
                            coop = 5;
                            s2 = "insert into Children values (\'" + textBox3.Text + "\', \'" + textBox5.Text + "\', \'" + maskedTextBox3.Text + "\', " +
               "\'" + squad + "\', \'" + smena + "\', \'" + begindate + "\', \'" + enddate + "\', \'" + par_id + "\', " +
               "\'" + coop + "\', \'" + maskedTextBox2.Text + "\', \'" + maskedTextBox4.Text + "\', \'" + maskedTextBox5.Text + "\', 'false')";
                            c2 = new SqlCommand(s2, con);
                            if (c2.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Его отряд номер " + squad, "И вот...");
                                Form7 f7 = new Form7();
                                f7.Show();
                                this.Hide();
                            }
                        }
                        if (squad1 == squad2)
                        {
                            squad = 4;
                            par_id = Convert.ToInt32(c3.ExecuteScalar());
                            coop = 1;
                            s2 = "insert into Children values (\'" + textBox3.Text + "\', \'" + textBox5.Text + "\', \'" + maskedTextBox3.Text + "\', " +
                "\'" + squad + "\', \'" + smena + "\', \'" + begindate + "\', \'" + enddate + "\', \'" + par_id + "\', " +
                "\'" + coop + "\', \'" + maskedTextBox2.Text + "\', \'" + maskedTextBox4.Text + "\', \'" + maskedTextBox5.Text + "\', 'false')";
                            c2 = new SqlCommand(s2, con);
                            if (c2.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Его отряд номер " + squad, "И вот...");
                                Form7 f7 = new Form7();
                                f7.Show();
                                this.Hide();
                            }
                        }

                    }
                }

            }
            else
            {
                if ((sm == 1) && (age >= 10) && (age <= 11))
                {
                    smena = 1;
                    begindate = begindate1;
                    enddate = enddate1;
                    squad = 2;
                    par_id = Convert.ToInt32(c3.ExecuteScalar());
                    coop = 4;
                    s2 = "insert into Children values (\'" + textBox3.Text + "\', \'" + textBox5.Text + "\', \'" + maskedTextBox3.Text + "\', " +
               "\'" + squad + "\', \'" + smena + "\', \'" + begindate + "\', \'" + enddate + "\', \'" + par_id + "\', " +
               "\'" + coop + "\', \'" + maskedTextBox2.Text + "\', \'" + maskedTextBox4.Text + "\', \'" + maskedTextBox5.Text + "\', 'false')";
                    c2 = new SqlCommand(s2, con);
                    if (c2.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Его отряд номер " + squad, "И вот...");
                        Form7 f7 = new Form7();
                        f7.Show();
                        this.Hide();
                    }
                }
                if ((sm == 1) && (age >= 12) && (age <= 14))
                {
                    smena = 1;
                    begindate = begindate1;
                    enddate = enddate1;
                    squad = 1;
                    par_id = Convert.ToInt32(c3.ExecuteScalar());
                    coop = 3;
                    s2 = "insert into Children values (\'" + textBox3.Text + "\', \'" + textBox5.Text + "\', \'" + maskedTextBox3.Text + "\', " +
               "\'" + squad + "\', \'" + smena + "\', \'" + begindate + "\', \'" + enddate + "\', \'" + par_id + "\', " +
               "\'" + coop + "\', \'" + maskedTextBox2.Text + "\', \'" + maskedTextBox4.Text + "\', \'" + maskedTextBox5.Text + "\', 'false')";
                    c2 = new SqlCommand(s2, con);
                    if (c2.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Его отряд номер " + squad, "И вот...");
                        Form7 f7 = new Form7();
                        f7.Show();
                        this.Hide();
                    }
                }
            }
            con.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

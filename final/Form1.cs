using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace final
{
    public partial class Form1 : Form
    {
        private Form2 f;
        public Form1()
        {
            InitializeComponent();
            string pathString = @"final2\";
            System.IO.Directory.CreateDirectory(pathString);
            f = new Form2();
            f.parent = this;
            f.Hide();

        }

        public void refresh()
        {
            //label3.Text = val;

            DateTime v = dateTimePicker1.Value;
            v = v.AddDays(-(v.Day - 1));
            int days = DateTime.DaysInMonth(v.Year, v.Month);


            int sumhour = 0;
            int summin = 0;
            for (int ii = 0; ii < days; ii++)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(@"final2\" + v.AddDays(ii).ToString("yyyy-MM-dd") + ".txt"))
                    {
                        for (int i = 0; i < 8; i++)
                            sr.ReadLine();

                        //listBox1.Items.Clear();
                        for (int i = 0; i < 3; i++)
                        {
                            if (i < 2)
                            {
                                String line = sr.ReadLine();
                            }
                            else
                            {
                                String line = sr.ReadLine();
                                int hour;
                                int min;
                                string[] lineP = line.Split(new char[] { ':' });
                                int.TryParse(lineP[0], out hour);
                                int.TryParse(lineP[1], out min);
                                sumhour += hour;
                                summin += min;
                                if (summin >= 60)
                                {
                                    summin = summin - 60;
                                    sumhour = sumhour + 1;
                                }

                            }
                        }
                    }
                }
                catch
                {
                }
            }
            label1.Text = sumhour.ToString() + ":" + summin.ToString();
            listBox1.Items.Clear();
            try
            {
                using (StreamReader sr = new StreamReader(@"final2\" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + ".txt"))
                {
                    for (int i = 0; i < 8; i++)
                        sr.ReadLine();

                    
                    for (int i = 0; i < 3; i++)
                    {
                        String line = sr.ReadLine();
                        switch (i)
                        {
                            case 0:
                                {
                                    listBox1.Items.Add("早上工時:" + line);
                                }
                                break;
                            case 1:
                                {
                                    listBox1.Items.Add("下午工時:" + line);
                                }
                                break;
                            case 2:
                                {
                                    listBox1.Items.Add(" 總工時 :" + line);
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refresh();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //f.label3.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            f.val = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            f.Show();
            this.Hide();
            f.refresh();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int sixing;
            int.TryParse(textBox1.Text, out sixing);
            int workhour;
            int workmin;
            string[] lineP = label1.Text.Split(new char[] { ':' });
            int.TryParse(lineP[0], out workhour);
            int.TryParse(lineP[1], out workmin);
            int totalPay = workhour * sixing + workmin * sixing / 60;
            label5.Text = totalPay.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

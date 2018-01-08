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
    public partial class Form2 : Form
    {
        public Form1 parent;
        private bool reading = false;

        public Form2()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
           

            for (int i = 1;i<25;i++)
            {
                //string[] hour = new string[] { i.ToString() };
                string hour = i.ToString();
                comboBox1.Items.Add(hour);
                comboBox8.Items.Add(hour);
                comboBox4.Items.Add(hour);
                comboBox6.Items.Add(hour);
            }

            for (int i = 1; i < 60; i++)
            {
                string min = i.ToString();
                comboBox2.Items.Add(min);
                comboBox7.Items.Add(min);
                comboBox3.Items.Add(min);
                comboBox5.Items.Add(min);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public string val;

        private void button1_Click(object sender, EventArgs e)
        {

            parent.Show();
            this.Hide();
            parent.refresh();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            save();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            save();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            save();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            save();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            save();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            save();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            save();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            save();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void refresh()
        {
            label3.Text = val;

            reading = true;
            try

            {
                using (StreamReader sr = new StreamReader(@"final2\" + val + ".txt"))
                {
                    ComboBox[] array = new ComboBox[8] { comboBox1, comboBox2, comboBox7, comboBox8, comboBox4, comboBox3, comboBox6, comboBox5 };
                    Label[] label567 = new Label[3] { label5, label6, label7 };
                       
                    for (int i = 0; i < array.Length; i++)
                    {
                        int index;
                        String line = sr.ReadLine();
                        int.TryParse(line, out index);
                        array[i].SelectedIndex = index;
                    }

                    for (int i = 0;i<3;i++)
                    {
                        String line = sr.ReadLine();
                        label567[i].Text=line;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
            reading = false;
        }


        private void save()
        {
            ComboBox[] array = new ComboBox[8] { comboBox1, comboBox2, comboBox7, comboBox8, comboBox4, comboBox3, comboBox6, comboBox5 };
            Label[] label567 = new Label[3] { label5, label6, label7 };

            if (reading) return;
            using (StreamWriter outputFile = new StreamWriter(@"final2\" + val + ".txt"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    string[] lines = { array[i].SelectedIndex.ToString() };

                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }

                for (int i = 0; i < 3; i++)
                {
                    outputFile.WriteLine(label567[i].Text);
                }
            }
        }

        public int hourMorn;
        public int minMorn;
        public int hourAft;
        public int minAft;
        public int totalHour;
        public int totalMin;

        private void button2_Click(object sender, EventArgs e)
        {
            //上午下班時間
            //HR
            int H8;
            int S8;            
            S8 =comboBox8.SelectedIndex;
            //MIN
            int M7;
            int S7;
            S7 =comboBox7.SelectedIndex;

            //上午上班時間
            //HR
            int H1;
            int S1;
            S1 = comboBox1.SelectedIndex;
            //MIN
            int S2;
            int M2;
            S2 = comboBox2.SelectedIndex;

            //下午下班時間
            //HR
            int H6;
            int S6;
            S6 = comboBox6.SelectedIndex;

            //MIN
            int M5;
            int S5;
            S5 = comboBox5.SelectedIndex;

            //下午上班時間
            //HR
            int H4;
            int S4;
            S4 = comboBox4.SelectedIndex;

            //MIN
            int M3;
            int S3;
            S3 = comboBox3.SelectedIndex;

           

            if (S1 != -1 && S2!= -1 && S7!= -1 && S8 != -1 && S3 != -1 && S4 != -1 && S5 != -1 && S6 != -1)
            {
                int.TryParse(comboBox8.Items[comboBox8.SelectedIndex] as string, out H8);
                int.TryParse(comboBox7.Items[comboBox7.SelectedIndex] as string, out M7);
                int.TryParse(comboBox1.Items[comboBox1.SelectedIndex] as string, out H1);
                int.TryParse(comboBox2.Items[comboBox2.SelectedIndex] as string, out M2);
                int.TryParse(comboBox6.Items[comboBox6.SelectedIndex] as string, out H6);
                int.TryParse(comboBox5.Items[comboBox5.SelectedIndex] as string, out M5);
                int.TryParse(comboBox4.Items[comboBox4.SelectedIndex] as string, out H4);
                int.TryParse(comboBox3.Items[comboBox3.SelectedIndex] as string, out M3);

                if (M7 - M2 < 0)
                {
                    hourMorn = H8 - H1 - 1;
                    minMorn = M7 - M2 + 60;
                    if (hourMorn<0)
                    {
                        MessageBox.Show("勿填入不合理的值");
                        hourMorn = 0;
                        minMorn = 0;
                    }
                }
                else
                {
                    hourMorn = H8 - H1;
                    minMorn = M7 - M2;
                    if (hourMorn < 0)
                    {
                        MessageBox.Show("勿填入不合理的值");
                        hourMorn = 0;
                        minMorn = 0;
                        comboBox1.SelectedIndex = -1;
                        comboBox2.SelectedIndex = -1;
                        comboBox7.SelectedIndex = -1;
                        comboBox8.SelectedIndex = -1;
                    }
                }

                label5.Text = hourMorn.ToString() + ":" + minMorn.ToString();
                if (H8>H4)
                {
                    MessageBox.Show("哥，求你重填了");
                    comboBox3.SelectedIndex = -1;
                    comboBox4.SelectedIndex = -1;
                    comboBox5.SelectedIndex = -1;
                    comboBox6.SelectedIndex = -1;

                    H4 = 0;
                    M3 = 0;
                    H6 = 0;
                    M5 = 0;
                    // Tryparse.comboBox4.Items[int -1];   
                }

                if (M5 - M3 < 0)
                {
                    hourAft = H6 - H4 - 1;
                    minAft = M5 - M3 + 60;
                    if (hourAft < 0)
                    {
                        MessageBox.Show("勿填入不合理的值");
                        hourAft = 0;
                        minAft = 0;
                        comboBox3.SelectedIndex = -1;
                        comboBox4.SelectedIndex = -1;
                        comboBox5.SelectedIndex = -1;
                        comboBox6.SelectedIndex = -1;
                    }
                }
                else
                {
                    hourAft = H6 - H4;
                    minAft = M5 - M3;
                    if (hourAft < 0)
                    {
                        MessageBox.Show("勿填入不合理的值");
                        hourAft = 0;
                        minAft = 0;
                    }
                }

                label6.Text = hourAft.ToString() + ":" + minAft.ToString();
            }
            else
            {
                MessageBox.Show("勿填空值");
                
            }
            
            if (minMorn + minAft>=60)
            {
                totalHour = hourMorn + hourAft + 1;
                totalMin = minMorn + minAft-60;
            }
            else
            {
                totalHour = hourMorn + hourAft;
                totalMin = minMorn + minAft;
            }

            label7.Text = totalHour.ToString() + ":" + totalMin.ToString();

            save();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

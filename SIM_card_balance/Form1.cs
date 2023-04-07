using System;
using System.IO;
using System.Windows.Forms;

namespace SIM_card_balance
{
    public partial class Form1 : Form
    {
        public string nomer;
        public string ism;
        public string familya;
        public string parol;
        public string old;
        public string old_tarix;
        public int summa;
        public int mb;
        public int sms;
        public int min;
        public int yigindi = 0;
        Label tarix = new Label();
        public Form1()
        {
            InitializeComponent();
            StreamReader output = new StreamReader(@"profil.txt");
            old = output.ReadToEnd();
            output.Close();
            StreamReader t_output = new StreamReader(@"tarix.txt");
            old_tarix = t_output.ReadToEnd();
            t_output.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            oynalar.SelectedIndex = 0;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            oynalar.SelectedIndex = 1;
            textBox1.Clear();
            textBox2.Clear();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) label4.Text = "HUMANS UZ";
            if (comboBox1.SelectedIndex == 1) label4.Text = "Mobi UZ";
            if (comboBox1.SelectedIndex == 2 || comboBox1.SelectedIndex == 3) label4.Text = "BeeLine UZ";
            if (comboBox1.SelectedIndex == 4 || comboBox1.SelectedIndex == 5) label4.Text = "Ucell UZ";
            if (comboBox1.SelectedIndex == 6) label4.Text = "Mobi UZ";
            if (comboBox1.SelectedIndex == 7) label4.Text = "UzMobile";



        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader output = new StreamReader(@"profil.txt");
            string[] s = output.ReadToEnd().Split();
            output.Close();
            int k = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (textBox1.Text == s[i]) k = i;

            }
            if (textBox1.Text.Length == 9 && k != 0)
            {
                nomer = "+998 " + s[k];
                ism = s[k - 2];
                familya = s[k - 1];
                parol = s[k + 1];
                summa = int.Parse(s[k + 2]);
                mb = int.Parse(s[k + 3]);
                min = int.Parse(s[k + 4]);
                sms = int.Parse(s[k + 5]);
                if (textBox2.Text == parol)
                {
                    label6.Text = ism + " " + familya;
                    nomer1.Text = nomer;
                    oynalar.SelectedIndex = 2;
                    summa1.Text = summa + " So'm";
                    mb1.Text = mb + " GB";
                    min1.Text = min + " Min";
                    sms1.Text = sms + " SMS";
                }
                else
                {
                    DialogResult d;
                    d = MessageBox.Show("Parolni unutdingizmi?", "Parol noto'g'ri!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        oynalar.SelectedIndex = 6;
                    }
                }
            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Bunday hisob mavjud emas!\nRo'yxatdan o'tishni istaysizmi?", "Kechirasiz.", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (d == DialogResult.Yes)
                {
                    oynalar.SelectedIndex = 1;
                }
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Chiqishni istaysizmi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes) oynalar.SelectedIndex = 0;

            StreamReader output = new StreamReader(@"profil.txt");
            string[] s = output.ReadToEnd().Split();
            output.Close();
            int k = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (parol == s[i]) k = i;
            }
            s[k + 1] = summa.ToString();
            s[k + 2] = mb.ToString();
            s[k + 3] = min.ToString();
            s[k + 4] = sms.ToString();

            StreamWriter input = new StreamWriter(@"profil.txt");
            for (int i = 0; i < s.Length; i++)
            {
                input.Write(s[i] + " ");
            }
            input.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            oynalar.SelectedIndex = 3;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            oynalar.SelectedIndex = 2;
            summa1.Text = summa + " So'm";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ism = textBox3.Text;
            familya = textBox4.Text;
            nomer = comboBox1.SelectedItem.ToString().Substring(5) + textBox5.Text;
            parol = textBox6.Text;
            summa = 0;
            min = 0;
            mb = 0;
            sms = 0;
            StreamWriter input = new StreamWriter(@"profil.txt");
            input.Write(old + " " + ism + " " + familya + " " + nomer + " " + parol + " " +
                summa + " " + mb + " " + min + " " + sms);
            input.Close();
            MessageBox.Show($"{ism} Malumotlaringiz saqlandi", "Tabriklaymiz!",
                MessageBoxButtons.OK);
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length < 16 && textBox2.Text.Length < 4)
            {
                MessageBox.Show("Karta malumotlarini to'g'ri to'ldiring!",
                    "Iltimos!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (textBox9.Text.Length <= 0)
            {
                MessageBox.Show("Miqdorni kiriting", "Iltimos!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                tarix.Text += "Muvoffaqqiyatsiz urinish! " +
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\n";
            }
            else
            {
                MessageBox.Show($"Hisobingizga {textBox9.Text} so'm qabul qilindi.",
                    "Tabriklaymiz!", MessageBoxButtons.OK);
                summa += int.Parse(textBox9.Text);

                tarix.Text += textBox7.Text + "  : +" + textBox9.Text + " So'm, " +
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\n";
                StreamWriter t_input = new StreamWriter(@"tarix.txt");
                t_input.WriteLine(old_tarix + "\n" + tarix.Text);
                t_input.Close();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length > 4)
            {
                if (textBox7.Text.Substring(0, 3) == "8600")
                {
                    label7.Text = "UzCard";
                }
                else if (textBox7.Text.Substring(0, 3) == "9860")
                {
                    label7.Text = "Humo";
                }
            }
        }

        string ozgaruvchi = "";
        private void button7_Click(object sender, EventArgs e)
        {
            bool t = false;
            yigindi = 0;
            if (comboBox2.SelectedIndex == 0 && summa >= 5000)
            {
                summa -= 5000;
                yigindi += 5000;
                mb += 1;
                t = true;
                ozgaruvchi += "1 GB internet paket, ";
                tarix.Text += nomer + " 1 GB, -5000  So'm, " +
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\n";
            }
            else if (comboBox2.SelectedIndex == 1 && summa >= 15000)
            {
                summa -= 15000;
                yigindi += 15000;
                mb += 5;
                t = true;
                ozgaruvchi += "5 GB internet paket, ";
                tarix.Text += nomer + " 5 GB, -15000  So'm, " +
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\n";

            }
            else if (comboBox2.SelectedIndex == 2 && summa >= 25000)
            {
                summa -= 25000;
                yigindi += 25000;
                mb += 10;
                t = true;
                ozgaruvchi += "10 GB internet paket, ";
                tarix.Text += nomer + " 10 GB, -25000  So'm, " +
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\n";

            }
            else if (comboBox2.SelectedIndex != -1)
            {
                MessageBox.Show("Internet paket sotib olishga mablag' yetarli emas.", "Kechirasiz!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                tarix.Text += "Muvoffaqqiyatsiz urinish! " +
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\n";
            }
            if (comboBox3.SelectedIndex == 0 && summa >= 5000)
            {
                summa -= 5000;
                yigindi += 5000;
                min += 100;
                t = true;
                ozgaruvchi += "100 daqiqa, ";
                tarix.Text += nomer + " 100 Min, -5000  So'm, " +
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\n";

            }
            else if (comboBox3.SelectedIndex == 1 && summa >= 10000)
            {
                summa -= 10000;
                yigindi += 10000;
                min += 500;
                t = true;
                ozgaruvchi += " 500 daqiqa, ";
                tarix.Text += nomer + " 500 Min, -10000  So'm, " +
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\n";
            }
            else if (comboBox3.SelectedIndex == 2 && summa >= 20000)
            {
                summa -= 20000;
                yigindi += 20000;
                min += 1000;
                t = true;
                ozgaruvchi += "1000 daqiqa, ";
                tarix.Text += nomer + " 1000 Min, -20000  So'm, " +
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\n";
            }
            else if (comboBox3.SelectedIndex != -1)
            {
                MessageBox.Show("Daqiqa sotib olishga mablag' yetarli emas.", "Kechirasiz!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                tarix.Text += "Muvoffaqqiyatsiz urinish! " +
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\n";
            }
            if (comboBox4.SelectedIndex == 0 && summa >= 5000)
            {
                summa -= 5000;
                yigindi += 5000;
                sms += 100;
                t = true;
                ozgaruvchi += "100 SMS paket, ";
                tarix.Text += nomer + " 100 SMS, -5000  So'm, " +
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\n";
            }
            else if (comboBox4.SelectedIndex == 1 && summa >= 10000)
            {
                summa -= 10000;
                yigindi += 10000;
                sms += 500;
                t = true;
                ozgaruvchi += "500 SMS paket, ";
                tarix.Text += nomer + " 500 SMS, -10000  So'm, " +
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\n";
            }
            else if (comboBox4.SelectedIndex == 2 && summa >= 20000)
            {
                summa -= 20000;
                yigindi += 20000;
                sms += 1000;
                t = true;
                ozgaruvchi += "1000 SMS paket, ";
                tarix.Text += nomer + " 1000 SMS, -20000  So'm, " +
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\n";
            }
            else if (comboBox4.SelectedIndex != -1)
            {
                MessageBox.Show("SMS paket sotib olishga mablag' yetarli emas.", "Kechirasiz!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                tarix.Text += "Muvoffaqqiyatsiz urinish! " +
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\n";
            }
            if (t == true)
            {
                MessageBox.Show($"{yigindi} so'mga {ozgaruvchi.Substring(0, ozgaruvchi.Length - 2)} sotib oldingiz.", "Tabriklaymiz!");
                yigindi = 0;
                ozgaruvchi = "";
                t = false;
            }
            summa2.Text = summa + " So'm";
            StreamWriter t_input = new StreamWriter(@"tarix.txt");
            t_input.WriteLine(old_tarix + "\n" + tarix.Text);
            t_input.Close();
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "Internet";
            comboBox3.SelectedIndex = -1;
            comboBox3.Text = "Daqiqa";
            comboBox4.SelectedIndex = -1;
            comboBox4.Text = "SMS";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            summa1.Text = summa + " So'm";
            mb1.Text = mb + " GB";
            min1.Text = min + " Min";
            sms1.Text = sms + " SMS";
            yigindi = 0;
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "Internet";
            comboBox3.SelectedIndex = -1;
            comboBox3.Text = "Daqiqa";
            comboBox4.SelectedIndex = -1;
            comboBox4.Text = "SMS";
            oynalar.SelectedIndex = 2;
            StreamReader output = new StreamReader(@"profil.txt");
            string[] s = output.ReadToEnd().Split();
            output.Close();
            int k = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (parol == s[i]) k = i;
            }
            s[k + 1] = summa.ToString();
            s[k + 2] = mb.ToString();
            s[k + 3] = min.ToString();
            s[k + 4] = sms.ToString();

            StreamWriter input = new StreamWriter(@"profil.txt");
            for (int i = 0; i < s.Length; i++)
            {
                input.Write(s[i] + " ");
            }
            input.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        void qoshish()
        {
            yigindi = 0;
            if (comboBox2.SelectedIndex == 0) yigindi += 5000;
            if (comboBox2.SelectedIndex == 1) yigindi += 15000;
            if (comboBox2.SelectedIndex == 2) yigindi += 25000;
            if (comboBox3.SelectedIndex == 0) yigindi += 5000;
            if (comboBox3.SelectedIndex == 1) yigindi += 10000;
            if (comboBox3.SelectedIndex == 2) yigindi += 20000;
            if (comboBox4.SelectedIndex == 0) yigindi += 5000;
            if (comboBox4.SelectedIndex == 1) yigindi += 10000;
            if (comboBox4.SelectedIndex == 2) yigindi += 20000;
            if (yigindi <= summa)
            {
                count.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                count.ForeColor = System.Drawing.Color.Red;
            }
            count.Text = yigindi.ToString() + " So'm";
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            qoshish();
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            qoshish();
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            qoshish();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            nomer2.Text = nomer;
            summa2.Text = summa + " So'm";
            oynalar.SelectedIndex = 4;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            oynalar.SelectedIndex = 5;
            StreamWriter t_input = new StreamWriter(@"tarix.txt");
            t_input.WriteLine(old_tarix + tarix.Text);
            t_input.Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Parolni unutdingizmi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                oynalar.SelectedIndex = 6;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            oynalar.SelectedIndex = 0;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            StreamReader output = new StreamReader(@"profil.txt");
            string[] s = output.ReadToEnd().Split();
            output.Close();
            int k = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (textBox10.Text == s[i]) k = i;
            }
            string old_parol = s[k + 3];
            DialogResult d;
            d = MessageBox.Show($"{textBox10.Text} sizning oldingi parolingiz {old_parol} edi.\nEndi sizning ma'lumotlaringiz o'chirildi.\nYangi hisob yaratishni istaysizmi?", "Bajarildi.", MessageBoxButtons.YesNo);

            if (textBox12.Text == "+998" + s[k + 2])
            {
                s[k] = "";
                s[k + 1] = "";
                s[k + 2] = "";
                s[k + 3] = "";
                s[k + 4] = "";
                s[k + 5] = "";
                s[k + 6] = "";
                s[k + 7] = "";
            }
            StreamWriter input = new StreamWriter(@"profil.txt");
            for (int i = 0; i < s.Length; i++)
            {
                input.Write(s[i] + " ");
            }
            input.Close();
            if (d == DialogResult.Yes)
            {
                oynalar.SelectedIndex = 1;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            oynalar.SelectedIndex = 2;
        }
    }
}

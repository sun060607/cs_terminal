﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace example2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //버튼을 클릭하면 textbox1의 내용을 table1에 출력하겠습니다
            label1.Text = textBox1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "내가 눌러졌다!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //정수에서 문자로 변환
            //int num1 = 10;
            //num1.ToString();
            //numaric updown의 값을 label1에 대입한다
            int num1 = (int)numericUpDown1.Value;
            label1.Text = num1.ToString();
            //abel1.Text = numericUpDown1.Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //문자에서 정수로 변환
            //string data = "50";
            //int num = int.Parse(data);
            string text1 = "hello";
            string text2 = "world!";
            string text3 = text1 + text2;
            int[] num3 = { 1, 2, 3, 4 };
            int[] num4 = new int[5];
            num4[0] = 1;
            num4[1] = 2;
            string mydata2 = "100,200,300";
            string[] output= mydata2.Split(',');
            string[] mydata = { "data1", "data2", "data3" };
            try
            {
                numericUpDown1.Value = int.Parse(textBox1.Text);
            }
            catch(Exception ex)
            {
                label1.Text = ex.Message;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int num1 = (int)numericUpDown2.Value;
            int num2 = (int)numericUpDown3.Value;
            int num3 = num1 + num2;
            label2.Text = num3.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int num1 = (int)numericUpDown2.Value;
            int num2 = (int)numericUpDown3.Value;
            int num3 = num1 - num2;
            label2.Text = num3.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int num1 = (int)numericUpDown2.Value;
            int num2 = (int)numericUpDown3.Value;
            int num3 = num1 * num2;
            label2.Text = num3.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            float num1 = (float)numericUpDown2.Value;
            float num2 = (float)numericUpDown3.Value;
            float num3 = num1 / num2;
            label2.Text = num3.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label3.Text = textBox2.Text + textBox3.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string mydata2 = textBox4.Text;
            string[] output = mydata2.Split(',');
            int num1=0,num2=0;
            while(num2 < output.Length)
            {
                num1 =num1 + int.Parse(output[num2]);
                num2++;
            }
            label4.Text = num1.ToString();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //체크되었다
                label5.Text = "체크되었습니다";
            }
            else
            {
                //체크 되지 않음
                label5.Text = "체크 되지 않았습니다";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //추가 버튼을 클릭했다
            //listbox1에 대입한다
            listBox1.Items.Add(textBox5.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //사용자가 항목중에 뭔가를 선택했다
            //listBox1.Selectedlndex
            //listBox1.Selectedtem
            label6.Text = listBox1.SelectedItem.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //사용자가 listbox에서 뭔가를 선택했나 안했냐
            try {
                if (listBox1.SelectedIndex != -1)
                {
                    //선택했다
                    listBox2.Items.Add(listBox1.SelectedItem);
                    //listbox1에 선택되어있던것은 삭제한다
                    //listBox1.Items.Remove(listBox1.SelectedItems);
                    //listBox1.Items.Remove(listBox1.SelectedItem);
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
                else
                {
                    //선택안했다
                    MessageBox.Show("선택해주세요");
                }


            }
            catch
            {

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != -1)
            {
                label7.Text = comboBox1.SelectedItem.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox6.Text);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //원래있던 내용을 삭제한다
            comboBox1.Items.Clear();
            string[] animals = { "호랑이", "사자", "곰" };
            comboBox1.Items.AddRange(animals);
            //comboBox1.Items.ad
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //사용자가 listbox에서 뭔가를 선택했나 안했냐
            try
            {
                if (listBox2.SelectedIndex != -1)
                {
                    listBox1.Items.Add(listBox2.SelectedItem);
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("선택해주세요");
                }
            }
            catch
            {

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string namo = textBox7.Text;
            string age = textBox8.Text;
            string gender = textBox9.Text;

            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

            ListViewItem lvi = new ListViewItem();

            lvi.Text = namo;
            lvi.SubItems.Add(age);
            lvi.SubItems.Add(gender);

            listView1.Items.Add(lvi);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //리스트뷰에서 뭔가를 선택했다
            //listView1.SelectedItems[0].SubItems[0] : 이름
            //listView1.SelectedItems[1].SubItems[1] : 나이
            //listView1.SelectedItems[2].SubItems[2] : 성별
            try
            {
                textBox7.Text = listView1.SelectedItems[0].SubItems[0].Text;
                textBox8.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBox9.Text = listView1.SelectedItems[0].SubItems[2].Text;
            }
            catch
            {

            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //선택이 되었냐 안되었냐?
            if(listView1.SelectedIndices.Count > 0)
            {
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label11.Text = hScrollBar1.Value + "%";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label13.Text = trackBar1.Value + "%";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            button19.BackColor = Color.FromArgb(255, 0, 0);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            button19.BackColor = Color.FromArgb(0, 0, 255);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label14.Text = trackBar2.Value + "%";
            button19.BackColor = Color.FromArgb(0, 0, trackBar2.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label15.Text = trackBar3.Value + "%";
            button19.BackColor = Color.FromArgb(0, trackBar3.Value, 0);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label16.Text = trackBar4.Value + "%";
            button19.BackColor = Color.FromArgb(trackBar4.Value, 0, 0);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button19.BackColor = colorDialog1.Color;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if(textBox10.Text == "0")
            {
                textBox10.Text = "1";
            }
            else
            {
                textBox10.Text += "1";
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "0")
            {
                textBox10.Text = "2";
            }
            else
            {
                textBox10.Text += "2";
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "0")
            {
                textBox10.Text = "3";
            }
            else
            {
                textBox10.Text += "3";
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "0")
            {
                textBox10.Text = "4";
            }
            else
            {
                textBox10.Text += "4";
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "0")
            {
                textBox10.Text = "5";
            }
            else
            {
                textBox10.Text += "5";
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "0")
            {
                textBox10.Text = "6";
            }
            else
            {
                textBox10.Text += "6";
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "0")
            {
                textBox10.Text = "7";
            }
            else
            {
                textBox10.Text += "7";
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "0")
            {
                textBox10.Text = "8";
            }
            else
            {
                textBox10.Text += "8";
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "0")
            {
                textBox10.Text = "9";
            }
            else
            {
                textBox10.Text += "9";
            }
        }
        double num1 = 0;
        int num2 = 0;
        int num3 = 0;
        private void button30_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "0")
            {
                textBox10.Text = "0";
            }
            else
            {
                textBox10.Text += "0";
            }
        }
        private void button35_Click(object sender, EventArgs e)
        {
            if(num3 == 0)
            {
                num1 = double.Parse(textBox10.Text);
                textBox10.Text = "";
                num2 = 1;
                num3 = 1;
            }else if(num3 == 1)
            {
                if (num2 == 1)
                {
                    num1 += double.Parse(textBox10.Text);
                }
                else if (num2 == 2)
                {
                    num1 -= double.Parse(textBox10.Text);
                }
                else if (num2 == 3)
                {
                    num1 *= double.Parse(textBox10.Text);
                }
                else if (num2 == 4)
                {
                    num1 /= double.Parse(textBox10.Text);
                }
                textBox10.Text = "";
                num2 = 1;
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            
            if(num2 == 1)
            {
                num1 += double.Parse(textBox10.Text);
            }else if(num2 == 2)
            {
                num1 -= double.Parse(textBox10.Text);
            }else if(num2 == 3)
            {
                num1 *= double.Parse(textBox10.Text);
            }else if(num2 == 4)
            {
                num1 /= double.Parse(textBox10.Text);
            }
            textBox10.Text = num1.ToString();
            num3 = 0;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (num3 == 0)
            {
                num1 = double.Parse(textBox10.Text);
                textBox10.Text = "";
                num2 = 2;
                num3 = 1;
            }
            else if (num3 == 1)
            {
                if (num2 == 1)
                {
                    num1 += double.Parse(textBox10.Text);
                }
                else if (num2 == 2)
                {
                    num1 -= double.Parse(textBox10.Text);
                }
                else if (num2 == 3)
                {
                    num1 *= double.Parse(textBox10.Text);
                }
                else if (num2 == 4)
                {
                    num1 /= double.Parse(textBox10.Text);
                }
                textBox10.Text = "";
                num2 = 2;
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (num3 == 0)
            {
                num1 = double.Parse(textBox10.Text);
                textBox10.Text = "";
                num2 = 3;
                num3 = 1;
            }
            else if (num3 == 1)
            {
                if (num2 == 1)
                {
                    num1 += double.Parse(textBox10.Text);
                }
                else if (num2 == 2)
                {
                    num1 -= double.Parse(textBox10.Text);
                }
                else if (num2 == 3)
                {
                    num1 *= double.Parse(textBox10.Text);
                }
                else if (num2 == 4)
                {
                    num1 /= double.Parse(textBox10.Text);
                }
                textBox10.Text = "";
                num2 = 3;
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (num3 == 0)
            {
                num1 = double.Parse(textBox10.Text);
                textBox10.Text = "";
                num2 = 4;
                num3 = 1;
            }
            else if (num3 == 1)
            {
                if (num2 == 1)
                {
                    num1 += double.Parse(textBox10.Text);
                }
                else if (num2 == 2)
                {
                    num1 -= double.Parse(textBox10.Text);
                }
                else if (num2 == 3)
                {
                    num1 *= double.Parse(textBox10.Text);
                }
                else if (num2 == 4)
                {
                    num1 /= double.Parse(textBox10.Text);
                }
                textBox10.Text = "";
                num2 = 4;
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            num3 = 0;
            textBox10.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button21.MouseEnter += my_MouseEnter;
            button21.MouseLeave += my_MouseLeave;
            button22.MouseEnter += my_MouseEnter;
            button22.MouseLeave += my_MouseLeave;
            button23.MouseEnter += my_MouseEnter;
            button23.MouseLeave += my_MouseLeave;
            button24.MouseEnter += my_MouseEnter;
            button24.MouseLeave += my_MouseLeave;
            button25.MouseEnter += my_MouseEnter;
            button25.MouseLeave += my_MouseLeave;
            button26.MouseEnter += my_MouseEnter;
            button26.MouseLeave += my_MouseLeave;
            button27.MouseEnter += my_MouseEnter;
            button27.MouseLeave += my_MouseLeave;
            button28.MouseEnter += my_MouseEnter;
            button28.MouseLeave += my_MouseLeave;
            button29.MouseEnter += my_MouseEnter;
            button29.MouseLeave += my_MouseLeave;
            button30.MouseEnter += my_MouseEnter;
            button30.MouseLeave += my_MouseLeave;
            button31.MouseEnter += my_MouseEnter;
            button31.MouseLeave += my_MouseLeave;
            button32.MouseEnter += my_MouseEnter;
            button32.MouseLeave += my_MouseLeave;
            button33.MouseEnter += my_MouseEnter;
            button33.MouseLeave += my_MouseLeave;
            button34.MouseEnter += my_MouseEnter;
            button34.MouseLeave += my_MouseLeave;
            button35.MouseEnter += my_MouseEnter;
            button35.MouseLeave += my_MouseLeave;
            button36.MouseEnter += my_MouseEnter;
            button36.MouseLeave += my_MouseLeave;
        }

        private void my_MouseEnter(object sender, EventArgs e)
        {
            Button b = sender as Button;
            b.BackColor =Color.Red;
        }
        private void my_MouseLeave(object sender, EventArgs e)
        {
            Button b = sender as Button;
            b.BackColor = SystemColors.Control;
        }
    }
}

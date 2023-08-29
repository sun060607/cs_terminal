using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}

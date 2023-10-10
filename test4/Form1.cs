using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(SerialPort.GetPortNames());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                //뭐라도 하나 선택했다
                serialPort1.PortName = comboBox1.SelectedItem.ToString();
                serialPort1.BaudRate = 115200;
                serialPort1.Open();

                MessageBox.Show("연결되었습니다");
            }
            else
            {
                MessageBox.Show("연결해라 미개한 인간");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string num = textBox1.Text;
            serialPort1.Write(num+"\r");
            textBox1.Text = "";
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            string num2 = hScrollBar1.Value.ToString();
            label1.Text = num2+"도";
            serialPort1.Write(num2+"\r");
        }
        int cnt = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //1초마다 이부분이 반복 실행이 된다(타이머가 작동중일때)
            label2.Text = cnt.ToString();
            if(cnt == 0)
            {
                label3.Text = "요리완료";
                timer1.Stop();
            }
            cnt--;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }
        int degree = 0;
        bool direct = false;
        string num3;
        private void timer2_Tick(object sender, EventArgs e)
        {
            label4.Text = degree.ToString();
            num3 = degree.ToString();
            serialPort1.Write(num3 + "\r");
            if(direct == false)
            {
                degree++;
                if(degree == 180)
                {
                    direct = true;
                }
            }else if(direct == true)
            {
                degree--;
                if(degree == 0)
                {
                    direct = false;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox2.Text);
            textBox2.Text = "";
        }
        int num4=0;
        string num5;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if(listBox1.Items.Count == 0)
            {
                timer3.Stop();
                MessageBox.Show("입력이 없다. 이 미개한 인간");
            }
            else
            {
                if(listBox1.Items.Count == num4)
                {
                    num4 = 0;
                }
                label5.Text = listBox1.Items[num4].ToString();
                //listBox1.Items[num4].ToString();
                num5 = listBox1.Items[num4].ToString();
                serialPort1.Write(num5+"\r");
                num4++;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer3.Stop();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //연결하기 버튼 눌러짐
            serialPort1.PortName = textBox1.Text;
            serialPort1.BaudRate = 115200;
            serialPort1.Encoding = Encoding.UTF8;
            serialPort1.Open();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //마두이노에서 println으로 전송하면 C#에서 readLine으로 받는다
            string data = serialPort1.ReadLine();
            string[] data2 = data.Split(',');
            //크로스 스레드 문제를 해결하는 방법
            /*this.Invoke(new MethodInvoker(delegate ()
            {
                richTextBox1.Text += data + "\n";
            }));*/
            richTextBox1.Text += data + "\n";
            textBox2.Text = data2[0];
            textBox3.Text = data2[1];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort2.PortName = textBox6.Text;
            serialPort2.BaudRate = 115200;
            serialPort2.Encoding = Encoding.UTF8;
            serialPort2.Open();

            if (serialPort2.IsOpen)
            {
                serialPort2.Write("0");
            }
        }
        private void serialPort2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string data = serialPort2.ReadLine();
            richTextBox1.Text += data + "\n";
            //data에서 cr(캐리지던트)을 제거한다
            data = data.Replace("\r", "");

            if(data == "안녕하세요!")
            {
                button3.BackColor = Color.Red;
                button4.BackColor = SystemColors.Control;
            }
            else if(data == "반갑습니다!")
            {
                button3.BackColor = SystemColors.Control;
                button4.BackColor = Color.Green;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen)
            {
                //정상적인경우
                serialPort2.Write("0");
            }
            else
            {
                //문제가 있을 경우
                MessageBox.Show("포트를 개방해라 미개한 인간");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen)
            {
                //정상적인경우
                serialPort2.Write("1");
            }
            else
            {
                //문제가 있을 경우
                MessageBox.Show("포트를 개방해라 미개한 인간");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            serialPort3.PortName = textBox6.Text;
            serialPort3.BaudRate = 115200;
            serialPort3.Encoding = Encoding.UTF8;
            serialPort3.Open();
        }

        private void serialPort3_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string data = serialPort3.ReadLine();
            richTextBox1.Text += data + "\n";
            label3.Text = data;
        }
    }
}

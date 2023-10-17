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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _10_17
{
    public partial class Form1 : Form
    {
        List<string> list = new List<string>()
        
        {
            "330d3f15",
            "73773115",
            "738faf19",
            "03466fc8"
        };
        Dictionary<string, string> dic = new Dictionary<string, string>()
        {
            //카드 아이디(key), 카드번호(value)
            {"330d3f15","1번 카드" },
            {"73773115","2번 카드" },
            {"738faf19","3번 카드" },
            {"03466fc8","4번 카드" }
        };
        class student
        {
            public string card_num;
            public string name;
            public string age;
            public string gender;
        }

        Dictionary<string, student> mystudent = new Dictionary<string, student>();
        public Form1()
        {
            InitializeComponent();
            student card1 = new student();
            card1.card_num = "330d3f15";
            card1.name = "죠나단 죠스타";
            card1.age = "27";
            card1.gender = "남성";
            student card2 = new student();
            card2.card_num = "73773115";
            card2.name = "죠셉 죠스타";
            card2.age = "24";
            card2.gender = "남성";
            student card3 = new student();
            card3.card_num = "738faf19";
            card3.name = "쿠죠 죠타로";
            card3.age = "18";
            card3.gender = "남성";
            student card4 = new student();
            card4.card_num = "03466fc8";
            card4.name = "쿠죠 죠린";
            card4.age = "25";
            card4.gender = "여성";

            mystudent.Add(card1.card_num, card1);
            mystudent.Add(card2.card_num, card2);
            mystudent.Add(card3.card_num, card3);
            mystudent.Add(card4.card_num, card4);
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
                serialPort2.PortName = comboBox1.SelectedItem.ToString();
                serialPort2.BaudRate = 115200;
                serialPort2.Open();

                MessageBox.Show("연결되었습니다");
            }
            else
            {
                MessageBox.Show("연결해라 미개한 인간");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //esp32 보드에서 재부팅 되는 경우의 수(아두이노면 문제 없음)
            string data = serialPort1.ReadLine();
            data = data.Replace("\r", "");
            if(data.Length == 8)
            {
                //카드번호가 등록되었는지 아닌지 list로 확인하기
                
                if (listBox1.Items.Contains(data))
                {
                    //등록
                    MessageBox.Show("등록된 카드 입니다");
                    richTextBox1.Text += data + ": 등록되어 있는 카드다" + "\n";
                }
                else
                {
                    //미등록
                    MessageBox.Show("미등록된 카드 입니다");
                    richTextBox1.Text += data + ": 등록되어 있는 않은 카드다" + "\n";
                }
                
                if (dic.ContainsKey(data))
                {
                    //RF iD 아이디가 딕셔너리 존재한다
                    richTextBox1.Text += data + ": "+ dic[data] + "\n";
                }
                else
                {
                    richTextBox1.Text += data + ": 등록되어 있는 않은 카드다" + "\n";
                }
                //카드 번호를 기준으로 몇번카드인지 인식하기
                /*
                if (data == "330d3f15")
                {
                    richTextBox1.Text += data + ": 1번째 카드다" + "\n";
                }
                else if (data == "73773115")
                {
                    richTextBox1.Text += data + ": 2번째 카드다" + "\n";
                }
                else if (data == "738faf19")
                {
                    richTextBox1.Text += data + ": 3번째 카드다" + "\n";
                }
                else if (data == "03466fc8")
                {
                    richTextBox1.Text += data + ": 4번째 카드다" + "\n";
                }
                else
                {
                    richTextBox1.Text += data + ": 등록되지 않은 카드다" + "\n";
                }
                */

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort2.ReadLine();
            data = data.Replace("\r", "");
            if (data.Length == 8)
            {
                if (mystudent.ContainsKey(data))
                {
                    //키 값이 존재한다
                    textBox2.Text = mystudent[data].card_num;
                    textBox3.Text = mystudent[data].name;
                    textBox4.Text = mystudent[data].age;
                    textBox5.Text = mystudent[data].gender;
                }
                else
                {
                    //키 값이 존재하지 않는다
                    richTextBox1.Text += data + ": 등록되어 있는 않은 카드다" + "\n";
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Newtonsoft.Json.Linq;

namespace _2023_11_07
{
    public partial class Form1 : Form
    {
        //전역으로 클래스선언
        MqttClient client;
        string clientId;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MQTT 브로커와 연결하는 부분
            string BrokerAddress = "broker.mqtt-dashboard.com";
            client = new MqttClient(BrokerAddress);

            // 구독 신청을 해서 MQTT메시지를 어떻게 할래
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            // use a unique id as client id, each time we start the application
            clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            //서버와 클라이언트가 접속이 완료되는 지점
            //iot보드가 pulish하는 topic 을 subscr ibe해야 한다
            //Subscribe Topic 추가
            string[] mytopic =
            {
                /*
                "bssm_iot/room1/sensor",
                "bssm_iot/room2/sensor",
                "bssm_iot/livingroom/dust",
                "bssm_iot/livingroom/co2"
                */
                //"bssm_iot/livingroom/rfid"
                //"bssm_iot/outdoor/weather"
                "bssm_iot/"
            };

            byte[] myqos =
            {
                /*
                0,
                0,
                0,
                0
                */
                0
            };
            //구독 
            client.Subscribe(mytopic,myqos);
        }
        //메시지 수신부
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            richTextBox1.Text +=$"[{e.Topic}]"+ ReceivedMessage + "\n";
            //DO SOMETHING..!
            //e.Topic
            if(e.Topic == "bssm_iot/room1/sensor")
            {
                try
                {
                    //만약 json데이터가 불완전하다면 예외가 발생한다
                    JObject myjson = JObject.Parse(ReceivedMessage);
                    textBox1.Text = myjson["temp"].ToString();
                    textBox2.Text = myjson["humi"].ToString();
                    textBox3.Text = myjson["cds"].ToString();
                    textBox4.Text = myjson["gas"].ToString();

                }
                catch
                {
                    try
                    {
                        //만약 json데이터가 불완전하다면 예외가 발생한다
                        JObject myjson = JObject.Parse(ReceivedMessage);
                        textBox1.Text = myjson["temp"].ToString();
                        textBox2.Text = myjson["humi"].ToString();
                        textBox3.Text = myjson["cds"].ToString();
                        textBox4.Text = myjson["gas"].ToString();

                    }
                    catch
                    {

                    }
                }
            }
            else if(e.Topic == "bssm_iot/room2/sensor")
            {
                try
                {
                    //만약 json데이터가 불완전하다면 예외가 발생한다
                    JObject myjson = JObject.Parse(ReceivedMessage);
                    textBox5.Text = myjson["temp"].ToString();
                    textBox6.Text = myjson["humi"].ToString();
                    textBox7.Text = myjson["cds"].ToString();
                    textBox8.Text = myjson["gas"].ToString();

                }
                catch
                {

                }
            }
            //json 데이터 parse
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MQTT 연결 종료
            client.Disconnect();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.Publish("bssm_iot/living/humi",Encoding.UTF8.GetBytes("1"),0,false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.Publish("bssm_iot/living/humi", Encoding.UTF8.GetBytes("0"), 0, false);
        }
    }
}

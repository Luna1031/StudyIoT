using Bogus;
using MetroFramework.Forms;
using Model;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using uPLibrary.Networking.M2Mqtt;

namespace BogusMqttWinPublishApp
{
    public partial class MainForm : MetroForm
    {
        public string MqttBrokerUrl { get; set; }

        public Thread MqttThread { get; set; }

        public MqttClient BrokerClient { get; set; }

        private Faker<SensorInfo> SensorFaker { get; set; }

        private string CurrValue { get; set; }
        public BackgroundWorker MqttWorker { get; set; }

        public MainForm()
        {
            InitializeComponent();

            InitializeAll();    // 전체 초기화
            ConnectMqttBroker();    // MQTT 브로커 접속
            StartPublish();     // fake 센싱 메시지 전송
        }

        private void ConnectMqttBroker()
        {
            MqttBrokerUrl = TxtBrokerIp.Text;
            BrokerClient = new MqttClient(MqttBrokerUrl);
            BrokerClient.Connect("FakerDaemon");
        }

        private void StartPublish()
        {
            MqttThread = new Thread(new ThreadStart(LoopPublish));
            MqttThread.Start();
        }

        private void InitializeAll()
        {
            MqttWorker = new BackgroundWorker();
            MqttWorker.DoWork += MqttWorker_DoWork;
            MqttWorker.WorkerReportsProgress = false;
            MqttWorker.WorkerSupportsCancellation = true;

            MqttBrokerUrl = "localhost";    // 127.0.0.1 또는 210.119.12.57

            string[] Rooms = new[] { "DiningRoom", "LivingRoom", "BathRoom", "BedRoom", "GuestRoom" };

            SensorFaker = new Faker<SensorInfo>()
                .RuleFor(s => s.Dev_Id, f => f.PickRandom(Rooms))
                .RuleFor(s => s.Curr_Time, f => f.Date.Past(0).ToString("yyyy-MM-dd HH:mm:ss.ff"))
                .RuleFor(s => s.Temp, f => float.Parse(f.Random.Float(19.0f, 35.9f).ToString("0.00")))
                .RuleFor(s => s.Humid, f => float.Parse(f.Random.Float(40.0f, 63.9f).ToString("0.0")))
                .RuleFor(s => s.Press, f => float.Parse(f.Random.Float(800.0f, 999.9f).ToString("0.0")));
        }

        private void MqttWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            LoopPublish();
        }

        private void LoopPublish()
        {
            while (true)
            {
                SensorInfo value = SensorFaker.Generate();
                CurrValue = JsonConvert.SerializeObject(value, Formatting.Indented);
                BrokerClient.Publish("home/device/data", Encoding.Default.GetBytes(CurrValue));
                // Console.WriteLine($"Published : {CurrValue}");
                this.Invoke(new Action(() =>
                {
                    RtbLog.AppendText($"\n\nPublished : {CurrValue}");
                    RtbLog.ScrollToCaret();
                }));

                Thread.Sleep(1000);
            }
        }


    }
}

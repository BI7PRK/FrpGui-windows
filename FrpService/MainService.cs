using System;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace FrpService
{
    public partial class MainService : ServiceBase
    {

        private Timer _timer = new Timer();


        private string[] args;
        public MainService(string[] args)
        {
            InitializeComponent();

            _socket = new SocketServer();

            _timer.Interval = 1000;
            _timer.Enabled = true;
            _timer.Elapsed += _timer_Tick;
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
           // checking frp is running...
        }

        protected SocketServer _socket;
        protected override void OnStart(string[] args)
        {
            _socket.WriteToClient("服务正在启动...");

            var cmdLine = string.Format( "frpc.exe -c ./frpc.ini", AppDomain.CurrentDomain.BaseDirectory);
        }

        protected override void OnStop()
        {
            _socket.WriteToClient("服务已经停止");
            //_socket.Close();
            //_socket = null;
        }

        protected void CheckFrpProcess()
        {
            
        }
        

        private void output(string str)
        {
            _socket.WriteToClient(str);
        }
    }
}

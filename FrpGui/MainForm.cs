using FrpGui.models;
using FrpGui.propertyentity;
using IniParser;
using IniParser.Model;
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrpGui_windows
{
    public partial class MainForm : Form
    {
        private FileIniDataParser parser = new FileIniDataParser();

        public MainForm()
        {
            InitializeComponent();
            ServiceInitialize();

            parser.Parser.Configuration.CommentString = "#";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ServerConfigBindToGrid();
            ClientConfigBindToGrid();

            foreach (var item in Enum.GetNames(typeof(ConnectTypes)))
            {
                itemType.Items.Add(item);
            }
            itemType.SelectedIndex = 0;
        }

        #region 客户端

        private readonly string configFile_client = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "frpc.ini");
        private IniData clientConfigData = new IniData();

        private void ClientConfigBindToGrid()
        {
            if (File.Exists(configFile_client))
                clientConfigData = parser.ReadFile(configFile_client);

            IProepertyEntity obj = new ClientCommonSection
            {
                SectionName = "common",
                Server = "0.0.0.0",
                Port = 7000,
                DashboardAddress = "",
                DashboardPort = 6000,
                DashboardPwd = "admin",
                DashboardUser = "frp",
                Heartbeat_Timeout = 90,
                LogFile = "./frpc.log",
                LogLevel = LogLevels.Info,
                LogMaxDays = 3,
                PoolCount = 10,
                User = "",
                PrivilegeToken = "12345678",
                Protocol = Protocols.Tcp,
                TcpMux = true,
                HeartbeatInterval = 30,
                LoginFailExit = true
            };

            if (clientConfigData.Sections.Count == 0)
            {
                ;
                clientConfigData = obj.ToIniData();
                configItems.SelectedNode = AddTreeNode(obj);
            }
            else
            {
                foreach (var item in clientConfigData.Sections)
                {
                    var entity = item.ToEntity();
                    if (entity == null)
                        continue;

                    AddTreeNode(entity);
                }
                configItems.SelectedNode = configItems.Nodes[0];
            }


        }


        private TreeNode AddTreeNode(IProepertyEntity obj)
        {
            var node = new TreeNode(obj.SectionName);
            node.Tag = obj;
            configItems.Nodes.Add(node);

            clientConfigData.Merge(obj.ToIniData());
            parser.WriteFile(configFile_client, clientConfigData, Encoding.Default);

            return node;
        }


        private void configItems_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var obj = (IProepertyEntity)configItems.SelectedNode.Tag;
            propertyGrid1.SelectedObject = obj;
            del.Enabled = obj.GetSectionName() != "common";

            CurrentSectionName = obj.GetSectionName();
        }
        private string CurrentSectionName;
        private void SaveClientConfig()
        {
            var obj = ((IProepertyEntity)propertyGrid1.SelectedObject);

            if (obj.SectionName == "common" && !(obj is ClientCommonSection))
            {
                MessageBox.Show(null, "项目名称不允许定义为[common]", "警告",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrEmpty(CurrentSectionName)
                && CurrentSectionName != obj.SectionName)
            {
                clientConfigData.Sections.RemoveSection(CurrentSectionName);
            }

            var data = obj.ToSectionData();
            clientConfigData.Sections.RemoveSection(obj.SectionName);
            clientConfigData.Sections.Add(data);

            parser.WriteFile(configFile_client, clientConfigData, Encoding.Default);

            configItems.SelectedNode.Text = obj.SectionName;
            configItems.SelectedNode.Tag = obj;
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            SaveClientConfig();
        }

        private void add_Click(object sender, EventArgs e)
        {
            Func<string, string> CreateName = p =>
            {
                p = p.ToLower();

                var count = configItems.Nodes.Cast<TreeNode>()
                .Count(a => a.Text.Contains(p));
                return string.Format("{0}{1}", p, (count == 0 ? "" : count.ToString()));
            };

            var value = itemType.SelectedItem.ToString();
            var className = string.Format("FrpGui.propertyentity.{0}Section", value);
            var type = Type.GetType(className);
            if (type == null) return;

            var obj = (IProepertyEntity)Activator.CreateInstance(type);
            obj.SectionName = CreateName(value);
            configItems.SelectedNode = AddTreeNode(obj);
        }

        private void del_Click(object sender, EventArgs e)
        {
            var node = configItems.SelectedNode;
            var obj = (IProepertyEntity)node.Tag;

            if (clientConfigData.Sections.RemoveSection(obj.SectionName))
            {
                parser.WriteFile(configFile_client, clientConfigData, Encoding.Default);
                configItems.Nodes.Remove(node);
            }


        }

        #endregion


        #region 服务端部分

        private readonly string configFile_svr = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "frps.ini");
        private IniData serverConfigData = new IniData();
        private void ServerConfigBindToGrid()
        {
            if (File.Exists(configFile_svr))
                serverConfigData = parser.ReadFile(configFile_svr);

            IProepertyEntity obj = new ServerCommonSection
            {
                SectionName = "common",
                BindAddress = "0.0.0.0",
                BindKcppPort = 7000,
                AuthTimeout = 900,
                BindPort = 7000,
                BindUdpPort = 7001,
                DashboardPort = 6000,
                DashboardPwd = "admin",
                DashboardUser = "frp",
                Heartbeat_Timeout = 90,
                HttpPort = 80,
                HttpsPort = 443,
                LogFile = "./frps.log",
                LogLevel = LogLevels.Info,
                LogMaxDays = 3,
                MaxPoolCount = 10,
                PrivilegePorts = "21-23,80-443,6000-8000",
                PrivilegeToken = "12345678",
                Protocol = Protocols.Tcp,
                TcpMux = true
            };


            if (serverConfigData.Sections.Count == 0)
            {
                propertyGrid2.SelectedObject = obj;
                serverConfigData = obj.ToIniData();
            }
            else
            {
                SectionData common = serverConfigData.Sections.GetSectionData("common");
                propertyGrid2.SelectedObject = common == null ? obj : common.ToEntity();
            }

        }

        private void SaveServerConfig()
        {
            serverConfigData = ((IProepertyEntity)propertyGrid2.SelectedObject)
                .ToIniData();
            parser.WriteFile(configFile_svr, serverConfigData, Encoding.Default);
        }

        private void propertyGrid2_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            SaveServerConfig();
        }




        #endregion

        #region 测试
        private void runfrpc_Click(object sender, EventArgs e)
        {
            runfrpc.Enabled = false;
            Run("frpc.exe", "-c ./frpc.ini");
        }

        private void loadfrpc_Click(object sender, EventArgs e)
        {
            Run("frpc.exe", "-c ./frpc.ini --reload");
        }


        private void runfrps_Click(object sender, EventArgs e)
        {
            runfrps.Enabled = false;
            Run("frps.exe", "-c ./frps.ini");
        }


        private void loadfrps_Click(object sender, EventArgs e)
        {
            Run("frps.exe", "-c ./frps.ini --reload");
        }


        private void Run(string exe, string args)
        {
            var root = AppDomain.CurrentDomain.BaseDirectory;

            ProcessStartInfo startInfo = new ProcessStartInfo(Path.Combine(root, exe));
            startInfo.Arguments = string.Format(args, root);
            startInfo.CreateNoWindow = true;   //不创建窗口
            startInfo.UseShellExecute = false;
            //不使用系统外壳程序启动,重定向输出的话必须设为false
            startInfo.RedirectStandardOutput = true; //重定向输出，
            startInfo.RedirectStandardError = true;

            try
            {
                Process process = Process.Start(startInfo);
                process.OutputDataReceived += (s, _e) => output(_e.Data);
                process.ErrorDataReceived += (s, _e) => output(_e.Data);
                //当EnableRaisingEvents为true，进程退出时Process会调用下面的委托函数
                process.Exited += (s, _e) =>
                {
                    output("Exited with " + process.ExitCode);
                    if (exe.EndsWith("frpc.exe"))
                        this.Invoke(new Action(() => runfrpc.Enabled = process.ExitCode != 0));

                    if (exe.EndsWith("frps.exe"))
                        this.Invoke(new Action(() => runfrps.Enabled = process.ExitCode != 0));
                };
                process.EnableRaisingEvents = true;
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                //process.WaitForExit();
            }
            catch (Exception ex)
            {
                output(ex.Message);
            }
        }

        private void output(string str)
        {
            this.BeginInvoke(new Action(() =>
            {
                testConsole.Text = str + "\r\n" + testConsole.Text;
            }));
        }

        private void killAll_Click(object sender, EventArgs e)
        {
            var ext = new string[] { "frpc", "frps" };

            foreach (var item in ext)
            {
                Process[] pro = Process.GetProcessesByName(item);
                output(string.Format("{0} {1}", item, pro.Count()));
                foreach (Process p in pro)
                {
                    p.Kill();
                    p.Close();
                }
            }
            runfrpc.Enabled = true;
            runfrps.Enabled = true;
            output("done");
        }


        #endregion


        #region 服务



        private static readonly string SERVICE_NAME = "FrpService";
        private static readonly string serviceExt = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FrpService.exe");
        private Timer timer;
        private ServiceController currService;

        private void ServiceInitialize()
        {
            currService = new ServiceController();
            currService.ServiceName = SERVICE_NAME;

            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 2000;
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.CheckService();
            try
            {
                currService.Refresh();
                linkLabel1.Text = currService.Status.ToString();
                stopBtm.Text = currService.Status == ServiceControllerStatus.Running ? "停止" : "运行";
                ClearEvent(stopBtm, "Click");
                if (currService.Status == ServiceControllerStatus.Running)
                {
                    stopBtm.Click += new EventHandler(Stop_Click);
                    stopBtm.Enabled = true;
                }
                else if (currService.Status == ServiceControllerStatus.Stopped)
                {
                    stopBtm.Click += new EventHandler(Start_Click);
                    stopBtm.Enabled = true;
                }
                else
                {
                    stopBtm.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                linkLabel1.Text = "";
                textBox1.AppendText(ex.Message);
                timer.Stop();
            }
            //textBox1.Text = DateTime.Now.ToString("s");
        }


        void ClearEvent(Control control, string eventname)
        {
            if (control == null) return;
            if (string.IsNullOrEmpty(eventname)) return;
            BindingFlags mPropertyFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic;
            BindingFlags mFieldFlags = BindingFlags.Static | BindingFlags.NonPublic;
            Type controlType = typeof(Control);
            PropertyInfo propertyInfo = controlType.GetProperty("Events", mPropertyFlags);
            EventHandlerList eventHandlerList = (EventHandlerList)propertyInfo.GetValue(control, null);
            FieldInfo fieldInfo = (typeof(Control)).GetField("Event" + eventname, mFieldFlags);
            Delegate d = eventHandlerList[fieldInfo.GetValue(control)];
            if (d == null) return;
            EventInfo eventInfo = controlType.GetEvent(eventname);
            foreach (Delegate dx in d.GetInvocationList())
                eventInfo.RemoveEventHandler(control, dx);
        }
        
        private delegate ServiceController CheckServiceHandler();

        private void CheckService()
        {
            CheckServiceHandler handler = new CheckServiceHandler(delegate
            {
                return ServiceController.GetServices().Where(w => w.ServiceName == SERVICE_NAME).FirstOrDefault();
            });
            handler.BeginInvoke(new AsyncCallback(p =>
            {
                var service = handler.EndInvoke(p);
                //if (!linkLabel1.IsAccessible) return;
                if (service == null)
                {
                    unstalBtm.Invoke(new Action(() =>
                    {
                        //linkLabel1.Text = "未安装";
                        instalBtm.Enabled = !(unstalBtm.Enabled = false);
                    }));
                }
                else
                {
                    TryConnect();

                    linkLabel1.Invoke(new Action(() =>
                    {
                        if (currService != null)
                        {
                            linkLabel1.Text = currService.Status.ToString();
                        }

                        instalBtm.Enabled = !(unstalBtm.Enabled = true);

                    }));
                }
            }), handler);
        }


        private void ServiceInstall()
        {
            if (!File.Exists(serviceExt))
            {
                this.AppendText("服务程序不存在。");
                return;
            }

            IDictionary hash = new Hashtable();
            string[] cmdline = { };
            AssemblyInstaller assemblyInstaller = new AssemblyInstaller(serviceExt, cmdline);
            try
            {
                assemblyInstaller.Install(hash);
                assemblyInstaller.Commit(hash);

                string[] inslog = { "FrpService.InstallLog", "FrpService.InstallState" };
                foreach (string f in inslog)
                {
                    string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, f);
                    if (File.Exists(file))
                        File.Delete(file);
                }
                this.AppendText("服务安装成功。");
                timer.Start();
            }
            catch (Exception ex)
            {
                textBox1.AppendText(ex.Message);
            }
        }

        private void instalBtm_Click(object sender, EventArgs e)
        {
            this.ServiceInstall();
        }

        private void AppendText(string str)
        {
            this.BeginInvoke(new Action(() =>
            {
                if (textBox1.IsHandleCreated)
                {
                    textBox1.Text = str + "\r\n" + textBox1.Text;
                }
            }));
            
        }


        private void Stop_Click(object sender, EventArgs e)
        {
            stopBtm.Enabled = false;
            if (currService != null && currService.Status != ServiceControllerStatus.Stopped)
            {
                currService.Stop();
                //this.AppendText(DateTime.Now + " - 服务停止。");
                CloseConnect();

            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            stopBtm.Enabled = false;
            try
            {
                if (currService != null && currService.Status != ServiceControllerStatus.Running)
                {
                    currService.Start();
                    //this.AppendText(DateTime.Now + " - 服务运行。");
                }
            }
            catch (Exception ex)
            {
                this.AppendText(DateTime.Now + "" + ex.Message);
            }
           
        }

        private void unstalBtm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确定要卸载服务吗？", "卸载服务", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            try
            {
                string[] cmdline = { };
                IDictionary hash = new Hashtable();
                AssemblyInstaller assemblyInstaller = new AssemblyInstaller(serviceExt, cmdline);
                assemblyInstaller.Uninstall(hash);
                //assemblyInstaller.Commit(hash);
                this.AppendText("服务卸载完成。");
            }
            catch { }

            linkLabel1.Text = "已卸载";
        }

        private Socket socketWatch;
        private async void TryConnect()
        {
          
            if (socketWatch != null && socketWatch.Connected) return;
          
            await Task.Run(() =>
            {
                socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var address = IPAddress.Parse("127.0.0.1");
                var endpoint = new IPEndPoint(address, 9360);

                try
                {
                    socketWatch.Connect(endpoint);
                    var threadWatch = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(RecMsg));
                    threadWatch.IsBackground = true;
                    threadWatch.Start(socketWatch);
                    //this.AppendText("服务运行正常");
                }
                catch (Exception ex)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        if (textBox1.IsHandleCreated)
                        {
                            textBox1.Text = "服务未运行";
                        }
                    }));
                }
            });
        }
        public void CloseConnect()
        {
            if (socketWatch != null)
                socketWatch.Close();
        }
        private void RecMsg(object socket)
        {
            var server = (Socket)socket;
            while (true)
            {
                try
                {
                    byte[] arrRecMsg = new byte[1024 * 1024];
                    int length = server.Receive(arrRecMsg);
                    var recStr = Encoding.Default.GetString(arrRecMsg, 0, length);
                    this.BeginInvoke(new Action(() => textBox1.Text = recStr));
                }
                catch (Exception ex)
                {
                    server.Dispose();
                    break;
                }
            }
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (socketWatch != null && socketWatch.Connected)
            {
                socketWatch.Close();
                socketWatch.Dispose();

            }
        }
    }
}

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
                DashboardAddress = "",
                DashboardPwd = "admin",
                DashboardUser = "frp",
                Heartbeat_Timeout = 90,
                LogFile = "./frpc.log",
                LogLevel = LogLevels.Info,
                PoolCount = 10,
                User = "",
                PrivilegeToken = "12345678",
                Protocol = Protocols.Tcp,
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
                AuthTimeout = 900,
                DashboardPwd = "admin",
                DashboardUser = "admin",
                Heartbeat_Timeout = 90,
                LogFile = "./frps.log",
                LogLevel = LogLevels.Info,
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
            Run("frpc.exe", "-c ./frpc.ini reload");
        }


        private void runfrps_Click(object sender, EventArgs e)
        {
            runfrps.Enabled = false;
            Run("frps.exe", "-c ./frps.ini");
        }


        private void loadfrps_Click(object sender, EventArgs e)
        {
            //Run("frps.exe", "-c ./frps.ini --reload");
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

        
        
    }
}

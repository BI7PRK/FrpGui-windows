using FrpGui.models;
using System.ComponentModel;

namespace FrpGui.propertyentity
{
    public class ClientCommonSection : CommonBase
    {


        [DisplayName("服务地址"), Description("远程服务器地址"), Category("基本")]
        [PropertyKey("server_addr")]
        public string Server
        {
            get;
            set;
        }


        [DisplayName("服务端口"), Description("远程服务端口"), Category("基本")]
        [PropertyKey("server_port")]
        public int Port
        {
            get;
            set;
        } = 7000;
        

        [DisplayName("预连接数"), Description(""), Category("基本")]
        [PropertyKey("pool_count")]
        public int PoolCount
        {
            get;
            set;
        }
        

        [DisplayName("心跳间隔"), Description("设置一个值间隔请求保证在线"), Category("基本")]
        [PropertyKey("heartbeat_interval")]
        public int HeartbeatInterval
        {
            get;
            set;
        }

        [DisplayName("地址"), Description("从WebAPI获取配置，用于配置热加载。通常是本地（127.0.0.1）"), Category("热加载")]
        [PropertyKey("admin_addr")]
        public string DashboardAddress
        {
            get;
            set;
        }


        [DisplayName("用户名"), Description("登陆仪表盘的用户"), Category("热加载")]
        [PropertyKey("admin_user")]
        public string DashboardUser
        {
            get;
            set;
        }

        [DisplayName("端口"), Description("登陆仪表盘的端口"), Category("热加载")]
        [PropertyKey("admin_port")]
        public int DashboardPort
        {
            get;
            set;
        }



        [DisplayName("密码"), Description("登陆仪表盘的密码"), Category("热加载")]
        [PropertyKey("admin_pwd")]
        public string DashboardPwd
        {
            get;
            set;
        }

        [DisplayName("登陆失败退出"), Description("登陆失败时退出，以免反复请求")]
        [PropertyKey("login_fail_exit")]
        public bool LoginFailExit
        {
            get;
            set;
        }

        [DisplayName("代理类别"), Description("proxy names you want to start divided by ','.default is empty, means all proxies")]
        public string Start
        {
            get;
            set;
        }

        [DisplayName("客户端名称"), Description("your proxy name will be changed to {user}.{proxy}")]
        public string User
        {
            get;
            set;
        }
    }
}

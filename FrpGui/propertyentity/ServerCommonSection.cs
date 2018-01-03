using FrpGui.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpGui.propertyentity
{
    public class ServerCommonSection : CommonBase
    {


        [DisplayName("绑定地址"), Description("服务器地址。通常本机是 0.0.0.0"), Category("基本")]
        [PropertyKey("bind_addr")]
        public string BindAddress
        {
            get;
            set;
        }


        [DisplayName("绑定端口"), Description("服务监听端口"), Category("基本")]
        [PropertyKey("bind_port")]
        public int BindPort
        {
            get;
            set;
        }


        [DisplayName("UDP端口"), Description("UDP服务监听端口，通常用于点对点穿透"), Category("基本")]
        [PropertyKey("bind_udp_port")]
        public int BindUdpPort
        {
            get;
            set;
        }

        [DisplayName("Kcp端口"), 
            Description("设置Kcp通讯协议时用到的端口。可以和【绑定端口】相同。"),
            Category("基本")]
        [PropertyKey("kcp_bind_port")]
        public int BindKcppPort
        {
            get;
            set;
        }

      


        [DisplayName("最大连接"), Description("设定客户端连接数量"), Category("基本")]
        [PropertyKey("max_pool_count")]
        public int MaxPoolCount
        {
            get;
            set;
        }


        [DisplayName("授权超时"), Description("设定授权超时，超过指定值则被认为授权失败"), Category("基本")]
        [PropertyKey("authentication_timeout")]
        public int AuthTimeout
        {
            get;
            set;
        }


        [DisplayName("子域名"), Description("设定子域名，以分配给在客户端指定 subdomain 名称")]
        [PropertyKey("subdomain_host")]
        public string Subdomain
        {
            get;
            set;
        }


        [DisplayName("特权开放端口"), Description("为防止端口的滥用，指定开放端口。要注意，不能存在空格")]
        [PropertyKey("privilege_allow_ports")]
        public string PrivilegePorts
        {
            get;
            set;
        }


        [DisplayName("Http端口"), Description("设置Http监听端口，以提供Http转发服务"), Category("Web服务")]
        [PropertyKey("vhost_http_port")]
        public int HttpPort
        {
            get;
            set;
        }

        [DisplayName("Https端口"), Description("设置Https监听端口，以提供SSL转发服务"), Category("Web服务")]
        [PropertyKey("vhost_https_port")]
        public int HttpsPort
        {
            get;
            set;
        }

        [DisplayName("地址"), Description("此处通常是服务器的域名或者IP"), Category("仪表盘")]
        [PropertyKey("dashboard_addr")]
        public string DashboardAddress
        {
            get;
            set;
        }

        [DisplayName("端口"), Description("登陆仪表盘的端口"), Category("仪表盘")]
        [PropertyKey("dashboard_port")]
        public int DashboardPort
        {
            get;
            set;
        }


        [DisplayName("用户名"), Description("登陆仪表盘的用户"), Category("仪表盘")]
        [PropertyKey("dashboard_user")]
        public string DashboardUser
        {
            get;
            set;
        }

        [DisplayName("密码"), Description("登陆仪表盘的密码"), Category("仪表盘")]
        [PropertyKey("dashboard_pwd")]
        public string DashboardPwd
        {
            get;
            set;
        }

        [DisplayName("代理服务"), Description("指定代理服务，可以通过代理网络接入。")]
        [PropertyKey("proxy_bind_addr")]
        public string ProxyBindAddress
        {
            get;
            set;
        }
    }
}

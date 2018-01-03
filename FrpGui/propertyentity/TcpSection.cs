using FrpGui.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpGui.propertyentity
{
    public class TcpSection : UdpSection
    {
        public new ConnectTypes Type => ConnectTypes.Tcp;

        [DisplayName("远程端口"), Description("在本地定义远程监听端口"), Category("代理")]
        public Plugins Plugin
        {
            get;
            set;
        }
        [DisplayName("远程端口"), Description("在本地定义远程监听端口"), Category("代理")]
        [PropertyKey("plugin_http_user")]
        public string PluginUser
        {
            get;
            set;
        }
        [DisplayName("远程端口"), Description("在本地定义远程监听端口"), Category("代理")]
        [PropertyKey("plugin_http_passwd")]
        public string PluginPassword
        {
            get;
            set;
        }
    }
}

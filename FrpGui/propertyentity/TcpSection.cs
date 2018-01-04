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

        [DisplayName("代理类型"), Description("定义代理类型"), Category("代理")]
        public Plugins Plugin
        {
            get;
            set;
        }
        [DisplayName("用户名"), Description("代理登陆用户名"), Category("代理")]
        [PropertyKey("plugin_http_user")]
        public string PluginUser
        {
            get;
            set;
        }
        [DisplayName("密码"), Description("代理登陆密码"), Category("代理")]
        [PropertyKey("plugin_http_passwd")]
        public string PluginPassword
        {
            get;
            set;
        }
    }
}

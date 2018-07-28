using FrpGui.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpGui.propertyentity
{
    public class StcpSection : ItemSectionBase
    {
        public new ConnectTypes Type => ConnectTypes.Stcp;

        [DisplayName("连接密钥"), Description("只有相同密钥(SK)的用户才可以连接"), Category("基本")]
        public string SK
        {
            get;
            set;
        }

        [DisplayName("角色"), Description(""), Category("基本")]
        public Roles Role
        {
            get;
            set;
        }



        [DisplayName("服务名称"), Description("对端的服务名称。即{user}.配置项的名称。例如 pi3.ssh"), Category("Visitor")]
        [PropertyKey("server_name")]
        public string ServerName
        {
            get;
            set;
        }


        private string _BindAddress = "127.0.0.1";

        [DisplayName("绑定地址"), Description("点对点通讯服务。客户端需要监听的地址。通常就是（127.0.0.1）"), Category("Visitor")]
        [PropertyKey("bind_addr")]
        public string BindAddress
        {
            get => _BindAddress;
            set => _BindAddress = value;
        }

        [DisplayName("绑定端口"), Description("点对点通讯服务。客户端需要监听的端口"), Category("Visitor")]
        [PropertyKey("bind_port")]
        public int BindPort
        {
            get;
            set;
        }

    }
}

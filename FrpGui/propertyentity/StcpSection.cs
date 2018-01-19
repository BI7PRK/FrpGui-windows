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



        [DisplayName("服务名称"), Description("对端的服务名称。即配置项的名称。例如 [p2p_ssh]"), Category("P2P")]
        [PropertyKey("server_name")]
        public string ServerName
        {
            get;
            set;
        }

        [DisplayName("绑定地址"), Description("点对点通讯服务。发起请求端的绑定地址"), Category("P2P")]
        [PropertyKey("bind_addr")]
        public string BindAddress
        {
            get;
            set;
        }

        [DisplayName("绑定端口"), Description("点对点通讯服务。发起请求端的绑定端口"), Category("P2P")]
        [PropertyKey("bind_port")]
        public int BindPort
        {
            get;
            set;
        }

    }
}

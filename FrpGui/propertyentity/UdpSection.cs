using FrpGui.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpGui.propertyentity
{
    public class UdpSection : ItemSectionBase
    {
        public new ConnectTypes Type => ConnectTypes.Udp;

        [DisplayName("远程端口"), Description("在本地定义远程监听端口")]
        [PropertyKey("remote_port")]
        public int RemotePort
        {
            get;
            set;
        }
        
    }
}

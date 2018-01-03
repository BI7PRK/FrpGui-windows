using FrpGui.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpGui.propertyentity
{
    public class ItemSectionBase : IProepertyEntity
    {
       
        [DisplayName("配置项名称"), Description(""), Category("基本")]
        [SectionName]
        public string SectionName
        {
            get;
            set;
        }

        [DisplayName("通讯类型"), Description(""), Category("基本")]
        public ConnectTypes Type => ConnectTypes.Tcp;


        [DisplayName("映射地址"), Description("映射到本地的地址。通常是IP。"), Category("基本")]
        [PropertyKey("local_ip")]
        public string LocalIPAddress
        {
            get;
            set;
        }

        [DisplayName("映射端口"), Description("映射到本地的服务端口"), Category("基本")]
        [PropertyKey("local_port")]
        public int LocalPort
        {
            get;
            set;
        }

        [DisplayName("启用加密"), Description("通讯数据加密"), Category("基本")]
        [PropertyKey("use_encryption")]
        public bool Enctyption
        {
            get;
            set;
        }

        [DisplayName("启用压缩"), Description("对通讯数据进行压缩处理"), Category("基本")]
        [PropertyKey("use_compression")]
        public bool Compression
        {
            get;
            set;
        }


    }
}

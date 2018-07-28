using FrpGui.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpGui.propertyentity
{
    /// <summary>
    /// 服务端和客户端都有的[common]配置属性
    /// </summary>
    public class CommonBase : IProepertyEntity
    {
        [DisplayName("配置项名称"), Description("") ]
        [Browsable(false)]
        [SectionName("common")]
        public string SectionName
        {
            get;
            set;
        }

        [Obsolete]
        [Browsable(false)]
        public ConnectTypes Type => ConnectTypes.Tcp;


        [DisplayName("日志文件"), Description("指定输出的日志文件"), Category("日志")]
        [PropertyKey("log_file")]
        public string LogFile
        {
            get;
            set;
        }

        [DisplayName("日志级别"), Description("指定输出日志文件的级别"), Category("日志")]
        [PropertyKey("log_level")]
        public LogLevels LogLevel
        {
            get;
            set;
        }

        [DisplayName("日志保留"), Description("日志文件保留天数"), Category("日志")]
        [PropertyKey("log_max_days")]
        public int LogMaxDays
        {
            get;
            set;
        } = 3;

        [DisplayName("特权密钥"), Description("设定特权连接的密钥"), Category("基本")]
        [PropertyKey("privilege_token")]
        public string PrivilegeToken
        {
            get;
            set;
        }


        [DisplayName("TCP复用"), Description("启用TCP复用，降低服务器压力"), Category("基本")]
        [PropertyKey("tcp_mux")]
        public bool TcpMux
        {
            get;
            set;
        } = true;

        [DisplayName("通信协议"), Description("指定连接服务器的通讯协议"), Category("基本")]
        [PropertyKey("protocol")]
        public Protocols Protocol
        {
            get;
            set;
        }

       

        [DisplayName("心跳超时"), Description("指定连接心跳超时，如果超出该值则认为离线")]
        [PropertyKey("heartbeat_timeout")]
        public int Heartbeat_Timeout
        {
            get;
            set;
        }

        
    }
}

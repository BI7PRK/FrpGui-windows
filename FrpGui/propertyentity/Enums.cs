using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpGui.propertyentity
{
    /// <summary>
    /// frp 连接协议类型
    /// </summary>
    public enum ConnectTypes
    {
        Http,
        Https,
        Tcp,
        Udp,
        Stcp,
        Xtcp
    }

    public enum LogLevels
    {
        Info,
        Trace,
        Debug,
        Warn,
        Error
    }


    public enum Protocols
    {
        Tcp,
        Kcp
    }

    public enum Plugins
    {
        None,
        Http_proxy,
        Socket5
    }

    public enum Roles
    {
        None,
        Visitor,
        Server
    }
}

using FrpGui.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpGui.propertyentity
{
    public class HttpsSection : HttpSection
    {
        public new ConnectTypes Type => ConnectTypes.Https;

        [DisplayName("插件"), Description("插件"), Category("插件")]
        public string plugin { get; set; } = "https2http";

        [DisplayName("本地访问地址"), Description("插件本地访问地址"), Category("插件")]
        [PropertyKey("plugin_local_addr")]
        public string PluginLocalHost
        {
            get;
            set;
        } = "127.0.0.1:80";

        [DisplayName("CRT证书"), Description("CRT证书路径"), Category("插件")]
        [PropertyKey("plugin_crt_path")]
        [Editor(typeof(PropertyGridFileSelector), typeof(UITypeEditor))]
        public string CrtFilePath
        {
            get;
            set;
        }

        [DisplayName("证书密钥"), Description("证书密钥路径"), Category("插件")]
        [PropertyKey("plugin_key_path")]
        [Editor(typeof(PropertyGridFileSelector), typeof(UITypeEditor))]
        public string CrtKeyPath
        {
            get;
            set;
        }

        [DisplayName("头部重写"), Description("访问域的头部重写"), Category("插件")]
        [PropertyKey("plugin_host_header_rewrite")]
        public string HeaderRewrite
        {
            get;
            set;
        } = "127.0.0.1";
    }
}

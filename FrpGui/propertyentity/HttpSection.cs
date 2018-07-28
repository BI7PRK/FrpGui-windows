using FrpGui.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpGui.propertyentity
{
    public class HttpSection : ItemSectionBase
    {
         
        public new ConnectTypes Type => ConnectTypes.Http;
        

        [DisplayName("子域名"), Description("二级域名名称"), Category("选一项")]
        public string Subdomain
        {
            get;
            set;
        }


        [DisplayName("自定义域名"), Description("可自定义的域名"), Category("选一项")]
        [PropertyKey("custom_domains")]
        public string CustomDomains
        {
            get;
            set;
        }


        [DisplayName("用户名"), Description("访问网站时需要用户认证"), Category("认证")]
        [PropertyKey("http_user")]
        public string HttpUser
        {
            get;
            set;
        }


        [DisplayName("密码"), Description("访问网站时需要用户认证"), Category("认证")]
        [PropertyKey("http_pwd")]
        public string HttpPwd
        {
            get;
            set;
        }

        [DisplayName("URL路由"), Description("例如指定 locations = /news，则所有 URL 以 /news 开头的请求都会被转发到这个服务。只支持http")]
        public string Locations
        {
            get;
            set;
        }
        [DisplayName("域名重定向"), Description("可自定义的域名")]
        [PropertyKey("host_header_rewrite")]
        public string hostRewrite
        {
            get;
            set;
        }

        //[DisplayName("请求头部参数"), Description("可自定义Http请求头部的参数")]
        //[PropertyKey("host_header_rewrite")]

        //public Dictionary<string, string> RequestHeaders
        //{
        //    get;
        //    set;
        //}
    }
}

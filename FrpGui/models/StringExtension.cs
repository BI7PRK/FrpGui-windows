using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpGui.models
{
    public static class StringExtension
    {
        /// <summary>
        /// 转为首字母大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToUpperFirst(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            return string.Concat(str.Substring(0, 1).ToUpper(),
                str.Substring(1).ToLower());
        }
    }
}

using FrpGui.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpGui.propertyentity
{
    public class HttpsSection : HttpSection
    {
        public new ConnectTypes Type => ConnectTypes.Https;
    }
}

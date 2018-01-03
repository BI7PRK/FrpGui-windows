using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpGui.propertyentity
{
    public interface IProepertyEntity
    {

        string SectionName { get; set; }

        ConnectTypes Type { get; }
    }
}

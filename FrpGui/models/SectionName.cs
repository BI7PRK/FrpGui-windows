using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpGui.models
{
    public class SectionNameAttribute : Attribute
    {
        private string _Name;
        public string Name => _Name;
        public SectionNameAttribute() { }
        public SectionNameAttribute(string name)
        {
            _Name = name;
        }
    }
}

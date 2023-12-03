using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class VisiableInCateTreeListAttribute : Attribute
    {
        public Type ListViewType { get; private set; }
        public VisiableInCateTreeListAttribute(Type listViewType)
        {
            ListViewType = listViewType;
        }
    }
}

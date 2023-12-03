using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LargeCaptionAttribute : Attribute
    {
        public Type ProviderType { get; private set; }
        public LargeCaptionAttribute(Type ILargeCaptionProviderType)
        {
            ProviderType = ILargeCaptionProviderType;
        }
    }
}

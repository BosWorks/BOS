using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS.Interfaces
{
    public interface IDictionaryBase
    {
        string Code { get; }
        string Name { get; }
        string PinYin { get; }
        int OrderId { get; }
    }
}

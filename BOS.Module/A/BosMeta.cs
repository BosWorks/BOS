using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS
{
    public class BosMeta<T> where T : DevExpress.Xpo.PersistentBase
    {
        public Dictionary<string, List<Attribute>> Set { get; private set; }
        protected T t;
        public BosMeta()
        {
            Set = new Dictionary<string, List<Attribute>>(4);
        }

        public void Add(string property, Attribute attri)
        {
            if (Set.ContainsKey(property))
            {
                Set[property].Add(attri);
            }
            else
            {
                Set[property] = new List<Attribute>() { attri };
            }
        }
    }
}

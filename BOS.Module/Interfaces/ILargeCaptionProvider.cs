using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
namespace BOS.Interfaces
{
    public interface ILargeCaptionProvider
    {
        LargeCaptionClass GetCapObject();
        void SetCapObject(string param, Session session);      
    }

    public class LargeCaptionClass
    {
        public PersistentBase Object { get; set; }
        public string Caption { get; set; }
        public string Param { get; set; }
    }
}

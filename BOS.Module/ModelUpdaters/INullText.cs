using DevExpress.ExpressApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS.ModelUpdaters
{    
    public interface INullText : IModelNode
    {
        [Category("Bos")]
        string NullText { get; set; }   
    }    
}

using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace GanBao.Module.BusinessObjects.ganbaodb
{

    public partial class Dictionary : BOS.Interfaces.IDictionaryBase
    {
        public Dictionary(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (IsLoading) return;
            if(propertyName == nameof(Name))
            {
                PinYin = BOS.Utils.PinYin.GetPinyin(Name);
            }
        }
    }

}

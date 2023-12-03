using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace SystemManager.Module.BusinessObjects.ora55
{
    [DefaultProperty("名称")]
    public partial class 字典
    {
        public 字典(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}

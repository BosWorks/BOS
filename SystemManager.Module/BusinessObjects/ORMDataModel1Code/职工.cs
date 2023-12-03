using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace SystemManager.Module.BusinessObjects.ora55
{
    [DefaultProperty("姓名")]
    public partial class 职工
    {
        public 职工(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}

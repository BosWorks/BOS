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
    public partial class 厂商员工
    {
        public 厂商员工(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}

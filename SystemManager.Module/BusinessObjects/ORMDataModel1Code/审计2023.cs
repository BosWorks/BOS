using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;

namespace SystemManager.Module.BusinessObjects.ora55
{
    //[NavigationItem("Default")]
    public partial class 审计2023
    {
        public 审计2023(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}

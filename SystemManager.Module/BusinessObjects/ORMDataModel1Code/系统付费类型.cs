using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace SystemManager.Module.BusinessObjects.ora55
{

    public partial class 系统付费类型
    {
        public 系统付费类型(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}

using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;

namespace GanBao.Module.BusinessObjects.ganbaodb
{
    [NavigationItem("Default")]
    public partial class GanBaoEvent
    {
        public GanBaoEvent(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}

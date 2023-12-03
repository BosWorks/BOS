using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace SystemManager.Module.BusinessObjects.ora55
{
    [FileAttachmentAttribute(nameof(File))]
    public partial class 巡检凭证
    {
        public 巡检凭证(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }        
    }

}

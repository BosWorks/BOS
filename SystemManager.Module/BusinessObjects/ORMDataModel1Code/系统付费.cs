﻿using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace SystemManager.Module.BusinessObjects.ora55
{

    public partial class 系统付费
    {
        public 系统付费(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}

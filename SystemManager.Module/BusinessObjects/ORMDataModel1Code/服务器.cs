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
    [DefaultProperty("IP地址")]
    [NavigationItem("Default")]
    public partial class 服务器
    {
        public 服务器(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        public 系统 DefaultSys
        {
            get
            {
                return this.系统s.Count == 0 ? null : this.系统s[0];
            }
        }
    }

}

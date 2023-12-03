using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace SystemManager.Module.BusinessObjects.ora55
{
    [NavigationItem("Default")]
    [DefaultProperty("系统名称")]
    public partial class 系统
    {
        public 系统(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    public enum EType1
    {
        未设置,
        医技治疗后勤,
        HIS及周边
    }

    public enum E网络运行环境
    {
        内网,
        互联网,
        内网和互联网
    }
}

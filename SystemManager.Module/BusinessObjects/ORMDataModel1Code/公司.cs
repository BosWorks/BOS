using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp;

namespace SystemManager.Module.BusinessObjects.ora55
{
    [NavigationItem("Default")]
    [DefaultProperty("简称")]
    public partial class 公司
    {
        public 公司(Session session) : base(session) { }
        public override void AfterConstruction()
        { 
            base.AfterConstruction();

            this.登陆名称 = SecuritySystem.CurrentUserId.ToString();
        }

        public string 登陆用户
        {
            get
            {                
                var result = Session.FindObject<ApplicationUser>(CriteriaOperator.Parse("Oid=?", this.登陆名称));
                return result == null ? "?" : result.UserName;
            }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);

            if (IsLoading) return;
            if(propertyName == nameof(核验人))
            {
                foreach(var sys in Session.Query<系统>().Where(r=>r.公司.Oid == this.Oid))
                {
                    sys.核验人 = this.核验人;
                }
            }
        }
    }

}

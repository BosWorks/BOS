using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace GanBao.Module.BusinessObjects.ganbaodb
{

    public partial class EventBase
    {
        public EventBase(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [BosCap("参与工作人员")]
        public ApplicationUser Operator1
        {
            get { return (ApplicationUser)base.GetPropertyValue("Operator1"); }
            set { base.SetPropertyValue("Operator1", value); }
        }

        [BosCap("陪同人员")]
        public ApplicationUser Operator2
        {
            get { return (ApplicationUser)base.GetPropertyValue("Operator2"); }
            set { base.SetPropertyValue("Operator2", value); }
        }

        [BosCap("记录人员")]
        public ApplicationUser Operator3
        {
            get { return (ApplicationUser)base.GetPropertyValue("Operator3"); }
            set { base.SetPropertyValue("Operator3", value); }
        }
    }

}

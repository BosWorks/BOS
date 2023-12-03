using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOS.Interfaces;
using BOS.Attributes;

namespace BOS.ViewControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class LargeCaptionVC : ViewController
    {
        ILargeCaptionProvider rdProvider;
        public event Action<LargeCaptionClass> ObjectUpdate;

        public LargeCaptionVC()
        {
            InitializeComponent();

            this.TargetObjectType = typeof(ILargeCaptionTypeProvider);
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            var attri = base.View.ObjectTypeInfo.FindAttribute<LargeCaptionAttribute>();
            if (attri == null) throw new ApplicationException();

            rdProvider = Activator.CreateInstance(attri.ProviderType) as ILargeCaptionProvider;
            if (rdProvider == null) throw new ApplicationException();

            var info = GetCapObjectInfoAndUpdateCaption();
            if (info.Object == null)
            {
                rdProvider.SetCapObject(null, ((XPObjectSpace)ObjectSpace).Session);
            }
            ObjectUpdate?.Invoke(info);
        }

        public LargeCaptionClass GetCapObjectInfoAndUpdateCaption()
        {
            var objInfo = rdProvider.GetCapObject();
            //this.largeCap_QueryAction.Value = objInfo.Param;
            SetBarItemCaption(objInfo.Caption);

            return objInfo;
        }

        protected virtual void SetBarItemCaption(string caption)
        {

        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.           
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void largeCap_QueryAction_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            rdProvider.SetCapObject(e.ParameterCurrentValue?.ToString().Trim(), ((XPObjectSpace)ObjectSpace).Session);
            var info = GetCapObjectInfoAndUpdateCaption();
            ObjectUpdate?.Invoke(info);
        }

        private void largeCap_CaptionAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {

        }
    }
}

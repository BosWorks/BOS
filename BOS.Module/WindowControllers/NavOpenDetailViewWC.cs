using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOS.WindowControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
    public partial class NavOpenDetailViewWC : WindowController
    {
        public NavOpenDetailViewWC()
        {
            InitializeComponent();

            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated()
        {
            base.OnActivated();

            ShowNavigationItemController controller = Frame.GetController<ShowNavigationItemController>();
            controller.CustomShowNavigationItem += Controller_CustomShowNavigationItem;
        }

        private void Controller_CustomShowNavigationItem(object sender, CustomShowNavigationItemEventArgs e)
        {
            IModelNavigationItem item = (IModelNavigationItem)e.ActionArguments.SelectedChoiceActionItem.Model;
            IModelDetailView view = item.View as IModelDetailView;

            if (view == null) return;

            var os = Application.CreateObjectSpace(view.ModelClass.TypeInfo.Type);

            bool createObj = !string.IsNullOrEmpty(item.ObjectKey);

            var dv = Application.CreateDetailView(os, view.Id, true, createObj ? os.CreateObject(view.ModelClass.TypeInfo.Type) : null);
            e.ActionArguments.ShowViewParameters.CreatedView = dv;
            e.Handled = true;
        }

        protected override void OnDeactivated()
        {
            ShowNavigationItemController controller = Frame.GetController<ShowNavigationItemController>();
            controller.CustomShowNavigationItem -= Controller_CustomShowNavigationItem;

            base.OnDeactivated();
        }
    }
}

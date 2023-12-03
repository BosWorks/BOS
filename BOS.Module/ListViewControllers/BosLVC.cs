using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
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

namespace BOS.ListViewControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class BosLVC : ViewController<ListView>
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public BosLVC()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            //SetOrderIdOrder();
        }

        #region order排序
        void SetOrderIdOrder()
        {
            if (base.View.Model.Columns.FirstOrDefault(r => r.Id == "OrderId") == null)
            {
                if (View.ObjectTypeInfo.FindMember("OrderId") == null) return;

                var col = base.View.Model.Columns.AddNode<DevExpress.ExpressApp.Model.IModelColumn>();
                //<ColumnInfo Id="OrderId" PropertyName="OrderId" Index="1" Width="94" IsNewNode="True" />
                col.Id = "OrderId";
                col.PropertyName = "OrderId";
                col.Index = -1;
                col.Width = 10;
            }

            foreach (var c in base.View.Model.Columns)
            {
                if (c.Id == "OrderId")
                {
                    c.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    c.SortIndex = 0;
                }
                else
                {
                    c.SortOrder = DevExpress.Data.ColumnSortOrder.None;
                    c.SortIndex = -1;
                }
            }
        }
        #endregion        

        #region lookup_listview禁用New（第一次无效果）
        //void SetLookupDisableNew()
        //{
        //    if (View.Model.Id.EndsWith("_LookupListView"))
        //    {
        //        View.Model.AllowNew = false;
        //    }
        //}
        #endregion 

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
    }
}

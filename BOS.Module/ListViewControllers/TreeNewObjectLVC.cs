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
//using DevExpress.ExpressApp.TreeListEditors;
using DevExpress.Persistent.Base.General;

namespace BOS.ListViewControllers
{
    //https://supportcenter.devexpress.com/ticket/details/t652694/treelistmodule-the-new-action-is-not-active-when-children-collection-has-multiple-types
    public partial class TreeNewObjectLVC : ViewController<ListView>
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public TreeNewObjectLVC()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();

            //TreeNodeController controller = Frame.GetController<TreeNodeController>();
            //if (controller != null)
            //{
            //    //第一次打开时事件也会触发
            //    controller.UpdateNewActionItems += Controller_UpdateNewActionItems;
            //}
        }

        //private void Controller_UpdateNewActionItems(object sender, UpdateNewActionItemsEventArgs e)
        //{
        //    //
        //    //Type childrentBaseType = TreeNodeController.GetChildrenElementType((ITreeNode)View.CurrentObject);
        //    //ITypeInfo typeInfo = XafTypesInfo.Instance.FindTypeInfo(childrentBaseType);
        //    //if (typeInfo != null)
        //    //{
        //    //    foreach (ChoiceActionItem item in e.Items)
        //    //    {
        //    //        item.Active.SetItemValue(TreeNodeController.EnableNewItemKey, childrentBaseType == (Type)item.Data);
        //    //    }
        //    //}
        //    //e.Handled = true;

        //    Type childrentBaseType = TreeNodeController.GetChildrenElementType((ITreeNode)View.CurrentObject);

        //    for (int i = 0; i < e.Items.Count; i++)
        //    {
        //        //第一次打开或点击空白处，View.CurrentObject == null
        //        if (View.CurrentObject == null)
        //        {
        //            e.Items[i].Active[TreeNodeController.EnableNewItemKey] = i == 0;
        //        }
        //        else
        //        {
        //            e.Items[i].Active[TreeNodeController.EnableNewItemKey] = childrentBaseType == (Type)e.Items[i].Data;
        //        }
        //    }

        //    e.Handled = true;
        //}

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            //TreeNodeController controller = Frame.GetController<TreeNodeController>();
            //if (controller != null)
            //{
            //    controller.UpdateNewActionItems -= Controller_UpdateNewActionItems;
            //}

            base.OnDeactivated();
        }
    }
}

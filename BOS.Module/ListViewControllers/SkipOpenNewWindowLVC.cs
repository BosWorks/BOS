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
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOS.ListViewControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SkipOpenNewWindowLVC : ViewController<ListView>
    {        
        public event System.ComponentModel.CancelEventHandler BeforeCreating;
        public SkipOpenNewWindowLVC()
        {
            InitializeComponent();

            base.TargetViewNesting = Nesting.Root;
        }
        protected override void OnActivated()
        {
            base.OnActivated();            

            //if (base.View.Model.MasterDetailMode != MasterDetailMode.ListViewAndDetailView) return;

            //NewObjectViewController newController = Frame.GetController<NewObjectViewController>();
            //newController.ObjectCreating += NewController_ObjectCreating;
            //newController.ObjectCreated += NewController_ObjectCreated;
            ////Frame.GetController<ModificationsController>().ModificationsCheckingMode = ModificationsCheckingMode.OnCloseOnly;

            //ListViewProcessCurrentObjectController pController = Frame.GetController<ListViewProcessCurrentObjectController>();
            //pController.ProcessCurrentObjectAction.Active["a"] = false;
        }

        //private void NewController_ObjectCreating(object sender, ObjectCreatingEventArgs e)
        //{
        //    if (BeforeCreating != null)
        //    {
        //        System.ComponentModel.CancelEventArgs args = new System.ComponentModel.CancelEventArgs();
        //        BeforeCreating(this, args);
        //        if (args.Cancel)
        //        {
        //            e.Cancel = true;
        //            return;
        //        }
        //    }

        //    e.ShowDetailView = false;
        //    object newObject = View.ObjectSpace.CreateObject(e.ObjectType);

        //    ITreeNode node = View.CurrentObject as ITreeNode;
        //    if (node != null)
        //    {
        //        //如果Model里View.Current类的DetailView包含newObject类的列表，会报InvalidCast
        //        node.Children.Add(newObject);
        //    }

        //    base.View.CollectionSource.Add(newObject);
        //    View.CurrentObject = newObject;
        //}

        //private void NewController_ObjectCreated(object sender, ObjectCreatedEventArgs e)
        //{
        //    //bug:e.CreatedObject != View.CurentObject
        //    //https://supportcenter.devexpress.com/ticket/details/t302003/objectspace-objectcreated-not-working-properly-with-listviewanddetailview-mode-and-view

        //    if (!e.CreatedObject.Equals(View.CurrentObject))
        //    {
        //        e.ObjectSpace.RemoveFromModifiedObjects(e.CreatedObject);
        //    }
        //}

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }

        protected override void OnDeactivated()
        {
            //NewObjectViewController newController = Frame.GetController<NewObjectViewController>();
            //newController.ObjectCreating -= NewController_ObjectCreating;
            //newController.ObjectCreated -= NewController_ObjectCreated;

            base.OnDeactivated();
        }
    }
}

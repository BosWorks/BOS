using System;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

namespace BOS {
    //https://github.com/DevExpress-Examples/XAF_how-to-create-a-custom-action-type-with-a-custom-control-barcheckitem-associated-with-it-e1977
    public class CheckableSimpleAction : SimpleAction {
        private bool _Checked = false;
        private void OnCheckedStateChanged() {
            if(CheckedStateChanged != null) {
                CheckedStateChanged(this, EventArgs.Empty);
            }
        }
        public CheckableSimpleAction(IContainer container) : base(container) { }
        public CheckableSimpleAction(Controller owner, string id, PredefinedCategory category) : base(owner, id, category) { }
        public bool Checked {
            get { return _Checked; }
            set {
                if(_Checked != value) {
                    _Checked = value;
                    OnCheckedStateChanged();
                    if(Enabled.ResultValue && Active.ResultValue) {
                        DoExecute();
                    }
                }
            }
        }
        public int GroupIndex { get; set; }
        public event EventHandler CheckedStateChanged;
    }
}

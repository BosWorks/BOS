using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp;

namespace BOS.ModelUpdaters
{
    public class BosModelViewsNodesGenerator : ModelNodesGeneratorUpdater<ModelViewsNodesGenerator>
    {
        public override void UpdateNode(ModelNode node)
        {
            foreach (var listView in ((IModelViews)node).OfType<IModelListView>())
            {   
                if (listView.Id.Contains("LookupListView"))
                {
                    listView.AllowNew = false;                   
                }

                if(listView.Columns.Count(r=>r.Id == "OrderId") > 0)
                {
                    foreach (var col in listView.Columns)
                    {
                        if (col.Id == "OrderId")
                        {
                            col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                            col.SortIndex = 0;
                        }
                        else
                        {
                            col.SortOrder = DevExpress.Data.ColumnSortOrder.None;
                            col.SortIndex = -1;
                        }
                    }
                }           
               
                //if (!Bos.Core.Module.Common.IsFPrefix('F', view.Id)) continue;
            }
        }
    }
}

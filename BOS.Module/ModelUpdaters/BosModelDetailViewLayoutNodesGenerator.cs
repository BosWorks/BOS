using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Utils;

namespace BOS.ModelUpdaters
{
    public class BosModelDetailViewLayoutNodesGenerator : ModelNodesGeneratorUpdater<ModelDetailViewLayoutNodesGenerator>
    {
        public override void UpdateNode(ModelNode node)
        {            
            //if(node.NodeCount > 0 && node[0].NodeCount > 0 && node[0][0].NodeCount > 0)
            //{
            //    IModelLayoutGroup i = node[0][0][0] as IModelLayoutGroup; 
            //    i.Caption = ((IModelDetailView)node.Parent).Caption;
            //}
            //((IModelLayoutGroup)node[0]).Remove();
            //var group  = node.AddNode<IModelTabbedGroup>();
            //var t1 = group.AddNode<IModelLayoutGroup>();
            //new ModelDetailViewLayoutNodesGenerator().GenerateNodes((ModelNode)t1);           
        }
        
        private void ProcessLayoutItems(IList<IModelViewLayoutElement> layoutItems, IModelClass modelClass)
        {
            foreach (IModelViewLayoutElement layoutItem in layoutItems)
            {
                if(layoutItem.Id == "Main")
                {
                    
                    var group = layoutItem.AddNode<IModelTabbedGroup>();

                    List<IModelNode> nodes = new List<IModelNode>(4);
                    for(int i = 0; i < layoutItem.NodeCount; i++)
                    {
                        nodes.Add(layoutItem.GetNode(i));
                    }
                    ((IModelLayoutGroup)layoutItem).ClearNodes();
                    for(int i = 0; i < nodes.Count; i++)
                    {
                        
                    }
                }
                
                //if (layoutItem is IList<IModelViewLayoutElement>)
                //{
                //    ProcessLayoutItems((IList<IModelViewLayoutElement>)layoutItem, modelClass);
                //}
            }
        }

        /*
        private void ClearCaption(IModelLayoutGroup layoutGroup, IModelClass modelClass)
        {
            do
            {
                if (layoutGroup.Caption == CaptionHelper.ConvertCompoundName(modelClass.ShortName))
                {
                    layoutGroup.SetValue<IModelClass>("ModelClass", modelClass);
                    layoutGroup.ClearValue("Caption");
                    break;
                }
                modelClass = modelClass.BaseClass;
            } while (modelClass != null);
        }*/

    }
}

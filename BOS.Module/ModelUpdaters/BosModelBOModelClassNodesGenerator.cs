using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.NodeGenerators;

namespace BOS.ModelUpdaters
{
    public class BosModelBOModelClassNodesGenerator : ModelNodesGeneratorUpdater<ModelBOModelClassNodesGenerator>
    {
        public override void UpdateNode(ModelNode node)
        {
            //已经在Module.UpdateBosMeta实现了
            //foreach(var cs in ((IModelBOModel)node))
            //{
            //    var bosCap = cs.TypeInfo.FindAttribute<DevExpress.Xpo.Metadata.BosCapAttribute>();
            //    if (bosCap == null) continue;

            //    cs.Caption = bosCap.Caption;
            //}

        }
    }
}

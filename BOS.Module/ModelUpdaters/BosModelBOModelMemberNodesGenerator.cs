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
    public class BosModelBOModelMemberNodesGenerator : ModelNodesGeneratorUpdater<ModelBOModelMemberNodesGenerator>
    {
        public override void UpdateNode(ModelNode node)
        {
            IModelBOModelClassMembers members = (IModelBOModelClassMembers)node;
            foreach (IModelMember modelMember in members)
            {
                if(modelMember.Type == typeof(DateTime))
                {
                    if (modelMember.Name.EndsWith("Time"))
                    {
                        modelMember.DisplayFormat = "{0:F}";
                        modelMember.EditMask = "F";
                    }
                    //其他的，包括Date，依然用{0:d}
                    //{0:T}是只显示时间
                }
                else if(modelMember.Type == typeof(int))
                {
                    //modelMember.DisplayFormat = "{0:D0}";
                    //modelMember.EditMask = "{D0}";
                }

                //不好判断Caption，英文也有，中文也有
                //if (!string.IsNullOrEmpty(modelMember.Caption)) continue;
                //var bosCap = modelMember.MemberInfo.MemberTypeInfo.FindAttribute<DevExpress.Xpo.Metadata.BosCapAttribute>();
                //if (bosCap == null) continue;
                //modelMember.Caption = bosCap.Caption;


            }
        }
    }
}

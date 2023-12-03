using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;

namespace BOS.Module;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class BOSModule : ModuleBase
{
    public const string NOT_AVAILABLE = "N/A";
    public const string SPACE = "(空白)";
    const string DEVEXPRESS_PREFIX = "DevExpress";

    public BOSModule()
    {
        // 
        // BOSModule
        // 
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.ModelDifference));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.ModelDifferenceAspect));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Security.SecurityModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.ValidationModule));
    }
    //public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
    //{
    //    ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
    //    return new ModuleUpdater[] { updater };
    //}

    public override void AddGeneratorUpdaters(ModelNodesGeneratorUpdaters updaters)
    {
        base.AddGeneratorUpdaters(updaters);
        updaters.Add(new ModelUpdaters.BosModelBOModelMemberNodesGenerator());
        updaters.Add(new ModelUpdaters.BosModelDetailViewLayoutNodesGenerator());
        updaters.Add(new ModelUpdaters.BosModelBOModelClassNodesGenerator());
        updaters.Add(new ModelUpdaters.BosModelViewsNodesGenerator());
    }

    public override void ExtendModelInterfaces(ModelInterfaceExtenders extenders)
    {
        base.ExtendModelInterfaces(extenders);
        extenders.Add<IModelMember, ModelUpdaters.IAppendFormat>();
        extenders.Add<IModelMember, ModelUpdaters.INullText>();
        extenders.Add<IModelListView, ModelUpdaters.IMultiSelect>();
        extenders.Add<IModelColumn, ModelUpdaters.IShowInCardView>();
    }

    public override void Setup(XafApplication application)
    {
        base.Setup(application);
        // Manage various aspects of the application UI and behavior at the module level.
    }
    public override void CustomizeTypesInfo(ITypesInfo typesInfo)
    {
        base.CustomizeTypesInfo(typesInfo);
        CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
    }

    public static void UpdateBosMeta(ITypesInfo typesInfo)
    {
        Dictionary<string, Dictionary<string, List<Attribute>>> typeList = new Dictionary<string, Dictionary<string, List<Attribute>>>();

        //把partial里的自定义添加的特性应用到持久类里面
        foreach (var type in System.Reflection.Assembly.GetCallingAssembly().GetTypes())
        {
            if (type.FullName.StartsWith(DEVEXPRESS_PREFIX)) continue;
            //type=接口时，type.BaseType=null
            //type.BaseType.GetGenericTypeDefinition()不能直接用，要先判断IsGenericType
            if (type.IsClass && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(BosMeta<>))
            {
                var instance = Activator.CreateInstance(type);
                var method = type.GetProperty("Set");

                typeList[type.BaseType.GenericTypeArguments[0].FullName] = (Dictionary<string, List<Attribute>>)method.GetValue(instance);
            }
        }
        foreach (var type in typesInfo.PersistentTypes)
        {
            if (type.FullName.StartsWith(DEVEXPRESS_PREFIX)) continue;
            if (!typeList.ContainsKey(type.Type.FullName)) continue;

            foreach (var st in typeList[type.Type.FullName])
            {
                foreach (var v in st.Value)
                {
                    type.FindMember(st.Key).AddAttribute(v);
                }
            }
        }

        //为每个有BosCap的类和属性添加标题
        foreach (var type in typesInfo.PersistentTypes)
        {
            if (type.FullName.StartsWith(DEVEXPRESS_PREFIX)) continue;
            var bosCap = type.FindAttribute<DevExpress.Xpo.Metadata.BosCapAttribute>();
            if (bosCap != null)
            {                
                type.AddAttribute(new ModelDefaultAttribute("Caption", bosCap.Caption));
            }

            foreach (var mem in type.OwnMembers)
            {
                if (!string.IsNullOrEmpty(mem.DisplayName)) continue;
                if (!mem.IsProperty) continue;

                //有的在这里面
                bosCap = mem.FindAttribute<DevExpress.Xpo.Metadata.BosCapAttribute>();
                if (bosCap == null)
                {
                    //有的在这里面
                    bosCap = mem.MemberTypeInfo.FindAttribute<DevExpress.Xpo.Metadata.BosCapAttribute>();
                }
                if (bosCap == null) continue;

                mem.AddAttribute(new DevExpress.Xpo.DisplayNameAttribute(bosCap.Caption));
            }
        }
    }
}
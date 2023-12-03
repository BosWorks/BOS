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
using DevExpress.Map.Kml.Model;
using DevExpress.Persistent.Validation;
using BOS.Module;

namespace SystemManager.Module;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class SystemManagerModule : ModuleBase {
    public SystemManagerModule() {
		// 
		// SystemManagerModule
		// 
		AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.ModelDifference));
		AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.ModelDifferenceAspect));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.BaseObject));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.FileData));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.FileAttachmentBase));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Security.SecurityModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Dashboards.DashboardsModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Office.OfficeModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ReportsV2.ReportsModuleV2));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.ValidationModule));
        RequiredModuleTypes.Add(typeof(BOSModule));
    }
    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
        ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
        return new ModuleUpdater[] { updater };
    }
    public override void Setup(XafApplication application) {
        base.Setup(application);
        // Manage various aspects of the application UI and behavior at the module level.
    }
    public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
        base.CustomizeTypesInfo(typesInfo);
        CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);

        foreach (var type in typesInfo.PersistentTypes)
        {
            if (type.Type == typeof(BusinessObjects.ora55.公司))
            {
                BusinessObjects.ora55.公司 t;
                type.FindMember(nameof(t.简称)).AddAttribute(new RuleRequiredFieldAttribute());
            }
            if (type.Type == typeof(BusinessObjects.ora55.厂商员工))
            {
                BusinessObjects.ora55.厂商员工 t;
                type.FindMember(nameof(t.姓名)).AddAttribute(new RuleRequiredFieldAttribute());
            }
            if (type.Type == typeof(BusinessObjects.ora55.服务器))
            {
                BusinessObjects.ora55.服务器 t;
                type.FindMember(nameof(t.IP地址)).AddAttribute(new RuleRequiredFieldAttribute());
            }
            if (type.Type == typeof(BusinessObjects.ora55.系统))
            {
                BusinessObjects.ora55.系统 t;
                type.FindMember(nameof(t.系统名称)).AddAttribute(new RuleRequiredFieldAttribute());
                type.FindMember(nameof(t.公司)).AddAttribute(new RuleRequiredFieldAttribute());
            }
        }

        BOSModule.UpdateBosMeta(typesInfo);

    }
}

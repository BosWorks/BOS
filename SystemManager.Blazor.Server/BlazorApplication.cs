using DevExpress.DashboardBlazor.Native;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using System.Security.AccessControl;
using SystemManager.Blazor.Server.Services;
using SystemManager.Module.BusinessObjects;
using SystemManager.Module.BusinessObjects.ora55;
using static System.Net.Mime.MediaTypeNames;

namespace SystemManager.Blazor.Server;

public class SystemManagerBlazorApplication : BlazorApplication {
    public SystemManagerBlazorApplication() {
        ApplicationName = "SystemManager";
        CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
        DatabaseVersionMismatch += SystemManagerBlazorApplication_DatabaseVersionMismatch;
    }

    protected override void OnLoggedOn(LogonEventArgs args)
    {
        base.OnLoggedOn(args);

        //var os = this.CreateObjectSpace(typeof(ApplicationUser));
        //IConfiguration config = this.ServiceProvider.GetRequiredService<IConfiguration>();


        //var users = config.GetSection("User").Get<string[]>();
        //foreach (var user in users)
        //{
        //    var u = os.CreateObject<职工>();
        //    u.姓名 = user;
        //}

        //var depts = config.GetSection("Depart").Get<string[]>();
        //foreach (var dept in depts)
        //{
        //    var d = os.CreateObject<部门>();
        //    d.名称 = dept;
        //}       
    }

    protected override void OnSetupStarted() {
        base.OnSetupStarted();
#if DEBUG
        if(System.Diagnostics.Debugger.IsAttached && CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema) {
            DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
        }
#endif
    }
    private void SystemManagerBlazorApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e) {
#if EASYTEST
        e.Updater.Update();
        e.Handled = true;
#else
        if(System.Diagnostics.Debugger.IsAttached) {
            e.Updater.Update(); 
            e.Handled = true;
        }
        else {
            string message = "The application cannot connect to the specified database, " +
                "because the database doesn't exist, its version is older " +
                "than that of the application or its schema does not match " +
                "the ORM data model structure. To avoid this error, use one " +
                "of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

            if(e.CompatibilityError != null && e.CompatibilityError.Exception != null) {
                message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
            }
            throw new InvalidOperationException(message);
        }
#endif
    }
}

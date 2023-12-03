using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Blazor.ApplicationBuilder;
using DevExpress.ExpressApp.Blazor.Services;
using DevExpress.Persistent.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Server.Circuits;
using DevExpress.ExpressApp.Xpo;
using SystemManager.Blazor.Server.Services;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.ExpressApp.Core;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;

namespace SystemManager.Blazor.Server;

public class Startup {
    public Startup(IConfiguration configuration) {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services) {
        services.AddSingleton(typeof(Microsoft.AspNetCore.SignalR.HubConnectionHandler<>), typeof(ProxyHubConnectionHandler<>));

        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddHttpContextAccessor();
        services.AddScoped<CircuitHandler, CircuitHandlerProxy>();
        services.AddXaf(Configuration, builder => {
            builder.UseApplication<SystemManagerBlazorApplication>();
            builder.Modules
                .AddConditionalAppearance()
                .AddDashboards(options => {
                    options.DashboardDataType = typeof(DevExpress.Persistent.BaseImpl.DashboardData);
                    options.SetupDashboardConfigurator = (dashboardConfigurator, services) => {
                        //dashboardConfigurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(Configuration));
                        DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();
                        DashboardXpoDataSource dataSource = new DashboardXpoDataSource("XPO DataSource");
                        dataSource.ConnectionStringName = "ConnectionString";
                        dataSource.SetEntityType(typeof(SystemManager.Module.BusinessObjects.ora55.系统));

                        DashboardXpoDataSource dataSource2 = new DashboardXpoDataSource("XPO DataSource_公司");
                        dataSource2.ConnectionStringName = "ConnectionString";
                        dataSource2.SetEntityType(typeof(SystemManager.Module.BusinessObjects.ora55.公司));

                        DashboardXpoDataSource dataSource3 = new DashboardXpoDataSource("XPO DataSource_厂商员工");
                        dataSource3.ConnectionStringName = "ConnectionString";
                        dataSource3.SetEntityType(typeof(SystemManager.Module.BusinessObjects.ora55.厂商员工));

                        DashboardXpoDataSource dataSource4 = new DashboardXpoDataSource("XPO DataSource_服务器");
                        dataSource4.ConnectionStringName = "ConnectionString";
                        dataSource4.SetEntityType(typeof(SystemManager.Module.BusinessObjects.ora55.服务器));

                        dataSourceStorage.RegisterDataSource("xpoDataSource", dataSource.SaveToXml());
                        dataSourceStorage.RegisterDataSource("xpoDataSource_公司", dataSource2.SaveToXml());
                        dataSourceStorage.RegisterDataSource("xpoDataSource_厂商员工", dataSource3.SaveToXml());
                        dataSourceStorage.RegisterDataSource("xpoDataSource_服务器", dataSource4.SaveToXml());

                        dashboardConfigurator.SetDataSourceStorage(dataSourceStorage);
                    }; 
                })
                .AddFileAttachments()
                .AddOffice()
                .AddReports(options => {
                    options.EnableInplaceReports = true;
                    options.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.ReportDataV2);
                    options.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML;
                })
                .AddValidation(options => {
                    options.AllowValidationDetailsAccess = false;
                })
                .Add<SystemManager.Module.SystemManagerModule>()
            	.Add<SystemManagerBlazorModule>();
            builder.ObjectSpaceProviders
                .AddSecuredXpo((serviceProvider, options) => {
                    string connectionString = null;
                    if(Configuration.GetConnectionString("ConnectionString") != null) {
                        connectionString = Configuration.GetConnectionString("ConnectionString");
                    }
#if EASYTEST
                    if(Configuration.GetConnectionString("EasyTestConnectionString") != null) {
                        connectionString = Configuration.GetConnectionString("EasyTestConnectionString");
                    }
#endif
                    ArgumentNullException.ThrowIfNull(connectionString);
                    options.ConnectionString = connectionString;
                    options.ThreadSafe = true;
                    options.UseSharedDataStoreProvider = true;
                })
                .AddNonPersistent();
            builder.Security
                .UseIntegratedMode(options => {
                    options.RoleType = typeof(PermissionPolicyRole);
                    // ApplicationUser descends from PermissionPolicyUser and supports the OAuth authentication. For more information, refer to the following topic: https://docs.devexpress.com/eXpressAppFramework/402197
                    // If your application uses PermissionPolicyUser or a custom user type, set the UserType property as follows:
                    options.UserType = typeof(SystemManager.Module.BusinessObjects.ApplicationUser);
                    // ApplicationUserLoginInfo is only necessary for applications that use the ApplicationUser user type.
                    // If you use PermissionPolicyUser or a custom user type, comment out the following line:
                    options.UserLoginInfoType = typeof(SystemManager.Module.BusinessObjects.ApplicationUserLoginInfo);
                    options.UseXpoPermissionsCaching();
                })
                .AddPasswordAuthentication(options => {
                    options.IsSupportChangePassword = true;
                });
        });
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
            options.LoginPath = "/LoginPage";
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        if(env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        }
        else {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. To change this for production scenarios, see: https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseRequestLocalization();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseXaf();
        app.UseEndpoints(endpoints => {
            endpoints.MapXafEndpoints();
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
            endpoints.MapControllers();
        });
    }
}

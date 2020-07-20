using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Shiny.Jobs;
using System;
using ShinyJobTest.Jobs;
using ShinyJobTest.Infrastructure;
using ShinyJobTest.AppState;

namespace ShinyJobTest {
   public class SampleStartUp : ShinyStartup {

      public override void ConfigureServices(IServiceCollection services) {
         // create your infrastructure
         services.AddSingleton<SampleSqliteConnection>();
         services.AddSingleton<CoreDelegateServices>();

         // register all of the acr stuff you want to use
         services.UseNotifications();

         // startup tasks
         //services.AddSingleton<GlobalExceptionHandler>();
         services.AddSingleton<JobLoggerTask>();
         services.AddAppState<AppStateDelegate>();

         // register all of the shiny stuff you want to use
         services.UseJobForegroundService(TimeSpan.FromSeconds(30));
      }  
      
      
      public override void ConfigureApp(IServiceProvider provider) {
         base.ConfigureApp(provider);

         // =============== TEST =============================================

         //string mJobName = "myJob";
         //JobInfo job = new JobInfo(typeof(SampleJob), mJobName) {
         //   Repeat = true,
         //   BatteryNotLow = true,
         //   DeviceCharging = true,
         //   RunOnForeground = false,
         //   RequiredInternetAccess = InternetAccess.None
         //};
         //job.SetParameter("SecondsToRun", 10);

         //ShinyHost.Resolve<IJobManager>().RequestAccess();
         //ShinyHost.Resolve<IJobManager>().Schedule(job);
      }
   }
}

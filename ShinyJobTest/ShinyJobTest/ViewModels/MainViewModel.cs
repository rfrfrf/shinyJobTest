using ShinyJobTest.Jobs;
using Shiny;
using Shiny.Jobs;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShinyJobTest.ViewModels {
   public class MainViewModel : BaseViewModel {
      private static string mJobName = "myJob";

      public MainViewModel() {
         Title = "Main";
         ScheduleJobCommand = new Command(
           execute: () => {
              JobInfo job = new JobInfo(typeof(SampleJob), mJobName) {
                 Repeat = true,
                 BatteryNotLow = true,
                 DeviceCharging = true,
                 RunOnForeground = false,
                 RequiredInternetAccess = InternetAccess.None
              };
              job.SetParameter("SecondsToRun", 10);

              ShinyHost.Resolve<IJobManager>().RequestAccess();  // necessary? where to put best?
              ShinyHost.Resolve<IJobManager>().Schedule(job);
           });

         RunJobCommand = new Command(
              execute: () => {
                 var jobs = ShinyHost.Resolve<IJobManager>().GetJobs();
                 var job = ShinyHost.Resolve<IJobManager>().GetJob(mJobName);
                 Debug.WriteLine(job.IsCompleted);
                 Debug.WriteLine(job.Status);
                 Debug.WriteLine(job);
                 ShinyHost.Resolve<IJobManager>().RequestAccess();  // necessary? where to put best?
                 ShinyHost.Resolve<IJobManager>().Run(mJobName);
              });

         CancelAllJobsCommand = new Command(
              execute: () => {
                 ShinyHost.Resolve<IJobManager>().RequestAccess();  // necessary? where to put best?
                 ShinyHost.Resolve<IJobManager>().Cancel(mJobName);
              });
      }

      public ICommand ScheduleJobCommand { get; }
      public ICommand RunJobCommand { get; }
      public ICommand CancelAllJobsCommand { get; }
   }
}
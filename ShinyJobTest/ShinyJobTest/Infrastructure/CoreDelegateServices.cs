using Shiny.Notifications;
using System.Threading.Tasks;


namespace ShinyJobTest.Infrastructure {
   public class CoreDelegateServices {
      public CoreDelegateServices(SampleSqliteConnection conn,
                                  INotificationManager notifications
         ) {
         Connection = conn;
         Notifications = notifications;
      }

      public SampleSqliteConnection Connection { get; }
      public INotificationManager Notifications { get; }

      public async Task SendNotification(string title, string message) {
         await Notifications.Send(title, message);
      }
   }
}

using Samples.Models;
using Shiny.IO;
using ShinyJobTest.Models.Samples.Models;
using SQLite;
using System.IO;

namespace ShinyJobTest {
   public class SampleSqliteConnection : SQLiteAsyncConnection {
      public SampleSqliteConnection(IFileSystem fileSystem) : base(Path.Combine(fileSystem.AppData.FullName, "sample.db")) {
         var conn = GetConnection();
         conn.CreateTable<JobLog>();
         conn.CreateTable<NotificationEvent>();
      }

      public AsyncTableQuery<JobLog> JobLogs => this.Table<JobLog>();
      public AsyncTableQuery<NotificationEvent> NotificationEvents => this.Table<NotificationEvent>();
   }
}
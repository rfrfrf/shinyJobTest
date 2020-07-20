using System;
using Shiny;
using Shiny.Notifications;
using ShinyJobtest.Models;

namespace ShinyJobTest.AppState
{
    public class AppStateDelegate : IAppStateDelegate
    {
        readonly SampleSqliteConnection conn;
        readonly INotificationManager notificationManager;


        public AppStateDelegate(SampleSqliteConnection conn, INotificationManager notificationManager)
        {
            this.conn = conn;
            this.notificationManager = notificationManager;
        }


        public void OnStart() => this.Store("Start");        
        public void OnForeground()
        {
            this.notificationManager.Badge = 0;
            this.Store("Foreground");
        }
        public void OnBackground() => this.Store("Background");



        void Store(string eventName) => this.conn.GetConnection().Insert(new AppStateEvent
        {
            Event = eventName,
            Timestamp = DateTime.UtcNow
        });
    }
}


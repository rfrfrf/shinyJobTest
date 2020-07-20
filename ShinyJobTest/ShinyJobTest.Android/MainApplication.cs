using System;
using Android.App;
using Android.Runtime;
using Shiny;

namespace ShinyJobTest.Droid {
   [Application]
   public class MainApplication : Application {
      public MainApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer) {
      }

      public override void OnCreate() {
         AndroidShinyHost.Init(this, new SampleStartUp());
         base.OnCreate();
      }
   }
}
using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Geed.Interfaces;
using Microsoft.Identity.Client;
using Xamarin.Forms;

namespace Geed.Droid
{
    [Activity(Label = "Geed", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
  global::Xamarin.Forms.Forms.Init(this, bundle);
          
  var identity = DependencyService.Get<IIdentityService>(DependencyFetchTarget.GlobalInstance);
            identity.UIParent = new UIParent(this);
          
            LoadApplication(new App());
         
        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);


            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
        }

    }
}
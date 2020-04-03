using System;
using Geed.Interfaces;
using Geed.Services;
using Microsoft.Identity.Client;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Geed
{
	public partial class App : Application
	{
	  

	    public App()
	    {
	        InitializeComponent();

	        DependencyService.Register<IWebAPIService, WebAPIService>();
            MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

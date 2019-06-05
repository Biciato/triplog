using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Ninject;
using Ninject.Modules;
using System;
using TripLog.Modules;
using TripLog.Services;
using TripLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripLog
{
    public partial class App : Application
    {
        public IKernel Kernel { get; set; }
        public App(params INinjectModule[] platformModules)
        {
            InitializeComponent();

            var mainPage = new NavigationPage(new MainPage());

            // Register core services
            Kernel = new StandardKernel(
                new TripLogCoreModule(),
                new TripLogNavModule(mainPage.Navigation));

            // Register platform specific services
            Kernel.Load(platformModules);

            // Get the MainViewModel from the IoC
            mainPage.BindingContext = Kernel.Get<MainViewModel>();

            MainPage = mainPage;
        }

        protected override void OnStart()
        {
            AppCenter.Start("ios={d75509ee-c5ea-4acd-b4a2-4023e76706f3};"
              + "android={a733f5ca-7851-4a39-9b1b-8585180df964};",
              typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

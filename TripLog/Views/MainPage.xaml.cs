using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog
{
    
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainViewModel _vm
        {
            get { return BindingContext as MainViewModel; }
        }
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Initialize MainViewModel
            if (_vm != null)
                await _vm.Init();
        }

        async void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var trip = (TripLogEntry)e.Item;
            _vm.ViewCommand.Execute(trip);

            // Clear selection
            trips.SelectedItem = null;
        }

        void New_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewEntryPage());
        }
    }
}

using gs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gs.View
{
    public partial class GunPage : ContentPage
    {
        public GunPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            collectionView.ItemsSource = await App.DB.GetGunsAsync();

            base.OnAppearing();
        }

        private async void AddNewGun(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(GunAddingPage));
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Gun gun = (Gun)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(GunAddingPage)}?{nameof(GunAddingPage.ItemId)}={gun.Id.ToString()}");
            }
        }
    }
}
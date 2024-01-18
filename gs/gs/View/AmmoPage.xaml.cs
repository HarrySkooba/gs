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
    public partial class AmmoPage : ContentPage
    {
        public AmmoPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            collectionView.ItemsSource = await App.DB.GetAmmosAsync();

            base.OnAppearing();
        }

        private async void AddNewAmmo(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AmmoAddingPage));
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Ammo ammo = (Ammo)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(AmmoAddingPage)}?{nameof(AmmoAddingPage.ItemId)}={ammo.Id.ToString()}");
            }
        }
    }
}
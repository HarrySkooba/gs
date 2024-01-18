using gs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace gs.View
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]

    public partial class GunAddingPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadGun(value);
            }
        }
        public GunAddingPage()
        {
            InitializeComponent();

            BindingContext = new Gun();
        }

        private async void LoadGun(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);

                Gun gun = await App.DB.GetGunAsync(id);

                BindingContext = gun;

                var types = await App.DB.GetTypesAsync();
                typePicker.ItemsSource = types;

                var selectedType = types.FirstOrDefault(t => t.ID == gun.TypeId);
                typePicker.SelectedItem = selectedType;

                var ammo = await App.DB.GetAmmosAsync();
                ammoPicker.ItemsSource = ammo;

                var selectedAmmo = ammo.FirstOrDefault(t => t.Id == gun.AmmoId);
                ammoPicker.SelectedItem = selectedAmmo;
            }
            catch
            {

            }
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var types = await App.DB.GetTypesAsync();
            typePicker.ItemsSource = types;
            var ammo = await App.DB.GetAmmosAsync();
            ammoPicker.ItemsSource = ammo;
        }
        private void OnTypePickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedType = typePicker.SelectedItem as Types;
            if (selectedType != null)
            {
                var gun = (Gun)BindingContext;
                gun.TypeId = selectedType.ID;
            }
        }

        private void OnAmmoPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedAmmo = ammoPicker.SelectedItem as Ammo;
            if (selectedAmmo != null)
            {
                var gun = (Gun)BindingContext;
                gun.AmmoId = selectedAmmo.Id;
            }
        }

        private async void SaveGun(object sender, EventArgs e)
        {
            Gun gun = (Gun)BindingContext;

            if (string.IsNullOrWhiteSpace(gun.Name) || gun.Price < 0 || string.IsNullOrWhiteSpace(gun.Info) || string.IsNullOrWhiteSpace(gun.ImagePath) || gun.TypeId == 0 || gun.AmmoId == 0)
            {
                await DisplayAlert("Внимание", "Не все поля заполнены!", "OK");
            }
            else
            {
                await App.DB.SaveGunAsync(gun);
                await DisplayAlert("Внимание", "Тип успешно изменен!", "OK");
                await Shell.Current.GoToAsync("..");
            }
        }

        private async void DeleteGun(object sender, EventArgs e)
        {
            Gun gun = (Gun)BindingContext;

            if (gun.Id == 0)
            {
                await DisplayAlert("Внимание", "Удаление невозможно!", "OK");
            }
            else
            {
                await App.DB.DeleteGunAsync(gun);

                await DisplayAlert("Внимание", "Тип успешно удален!", "OK");

                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
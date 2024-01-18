using gs.Models;
using System;
using System.Collections.ObjectModel;
using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace gs.View
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]

    public partial class AmmoAddingPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadAmmo(value);
            }
        }
        public AmmoAddingPage()
        {
            InitializeComponent();

            BindingContext = new Ammo();
        }

        private async void LoadAmmo(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);

                Ammo ammo = await App.DB.GetAmmoAsync(id);

                BindingContext = ammo;

                var types = await App.DB.GetTypesAsync();
                typePicker.ItemsSource = types;

                var selectedType = types.FirstOrDefault(t => t.ID == ammo.TypeId);
                typePicker.SelectedItem = selectedType;
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
        }
        private void OnTypePickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedType = typePicker.SelectedItem as Types;
            if (selectedType != null)
            {
                var ammo = (Ammo)BindingContext;
                ammo.TypeId = selectedType.ID;
            }
        }

        private async void SaveAmmo(object sender, EventArgs e)
        {
            Ammo ammo = (Ammo)BindingContext;

            if (string.IsNullOrWhiteSpace(ammo.Name) || ammo.Price < 0 || string.IsNullOrWhiteSpace(ammo.Info) || string.IsNullOrWhiteSpace(ammo.ImagePath) || ammo.TypeId == 0)
            {
                await DisplayAlert("Внимание", "Не все поля заполнены!", "OK");
            }
            else
            {
                await App.DB.SaveAmmoAsync(ammo);
                await DisplayAlert("Внимание", "Тип успешно изменен!", "OK");
                await Shell.Current.GoToAsync("..");
            }
        }

        private async void DeleteAmmo(object sender, EventArgs e)
        {
            Ammo ammo = (Ammo)BindingContext;

            if (ammo.Id == 0)
            {
                await DisplayAlert("Внимание", "Удаление невозможно!", "OK");
            }
            else
            {
                await App.DB.DeleteAmmoAsync(ammo);

                await DisplayAlert("Внимание", "Тип успешно удален!", "OK");

                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
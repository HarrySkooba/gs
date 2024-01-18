using System;
using Xamarin.Forms;
using gs.Models;

namespace gs.View
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class TypeAddingPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadType(value);
            }
        }
        public TypeAddingPage()
        {
            InitializeComponent();

            BindingContext = new Types();
        }

        private async void LoadType(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);

                Types types = await App.DB.GetTypeAsync(id);

                BindingContext = types;
            }
            catch
            {

            }
        }

        private async void SaveType(object sender, EventArgs e)
        {
            Types types = (Types)BindingContext;

            if (string.IsNullOrWhiteSpace(types.Title))
            {
                await DisplayAlert("Внимание", "Не все поля заполнены!", "OK");
            }
            else
            {
                await App.DB.SaveTypeAsync(types);
                await DisplayAlert("Внимание", "Тип успешно изменен!", "OK");
                await Shell.Current.GoToAsync("..");
            }
        }

        private async void DeleteType(object sender, EventArgs e)
        {
            Types types = (Types)BindingContext;

            if (types.ID == 0)
            {
                await DisplayAlert("Внимание", "Удаление невозможно!", "OK");
            }
            else
            {
                await App.DB.DeleteTypeAsync(types);

                await DisplayAlert("Внимание", "Тип успешно удален!", "OK");

                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
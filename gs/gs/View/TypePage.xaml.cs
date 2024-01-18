using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using gs.Models;
using System.Linq;

namespace gs.View
{
    public partial class TypePage : ContentPage
    {
        public TypePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        { 
            collectionView.ItemsSource = await App.DB.GetTypesAsync();

            base.OnAppearing();
        }

        private async void AddNewType(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(TypeAddingPage));
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Types types = (Types)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(TypeAddingPage)}?{nameof(TypeAddingPage.ItemId)}={types.ID.ToString()}");
            }
        }
    }
}
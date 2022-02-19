using Infrastructure.Models;
using Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace foonkiemonkey.testapp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListItemsPage : ContentPage
    {
        private UserViewModel userViewModel;
        private RootModel data;
        private List<UserModel> dataToStorage;
        public ListItemsPage()
        {
            InitializeComponent();
            BindingContext = this;
            userViewModel = new UserViewModel();
            data = new RootModel();
            dataToStorage = new List<UserModel>();
            InitService();
        }

        private async void InitService()
        {
            await GetDataFromService(1);
            LoadData();
            LoadPicker();
        }

        private async Task GetDataFromService(int page)
        {
            loadingIndicator.IsRunning = true;
            data = await userViewModel.GetUsers(page);
            StorageData(data.Data);
            loadingIndicator.IsRunning = false;
        }

        private void StorageData(List<UserModel> users)
        {
            foreach (var item in users)
            {
                if (!dataToStorage.Contains(item))
                {
                    dataToStorage.Add(item);
                }
            }
        }

        private void LoadPicker()
        {
            var pages = new int[data.Total_pages];
            for (int i = 1; i <= data.Total_pages; i++)
            {
                pages[i-1] = i;
            }
            pkrPages.ItemsSource = pages;
            pkrPages.SelectedIndex = 0;
            pkrPages.SelectedIndexChanged += PkrPages_SelectedIndexChanged;
        }

        async void PkrPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pkr = sender as Picker;
            await GetDataFromService(int.Parse(pkr.SelectedItem.ToString()));
            LoadData();
        }

        private void LoadData()
        {
            MainListView.ItemsSource = data.Data;
        }

        async void OnItemTapped(object sender, EventArgs args)
        {
            var cell = sender as ViewCell;
            var id = cell.FindByName<Label>("lblID");
            await Navigation.PushAsync(new DetailsPage(int.Parse(id.Text), userViewModel));
        }

        async void OnBtnSave_Clicked(object sender, EventArgs e)
        {
            loadingIndicator.IsRunning = true; 
            await GetAllPageData();
            var deleteItems = await userViewModel.ClearDatabase();
            var result = await userViewModel.SaveInDatabase(dataToStorage);
            loadingIndicator.IsRunning = false;
            await DisplayAlert(result, string.Empty, "Aceptar");
        }

        private async Task GetAllPageData()
        {
            for (int i = 1; i <= pkrPages.Items.Count; i++)
            {
                await GetDataFromService(i);
            }
        }
    }
}
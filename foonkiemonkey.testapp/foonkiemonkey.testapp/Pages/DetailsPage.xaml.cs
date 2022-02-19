using Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace foonkiemonkey.testapp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        private UserViewModel userViewModel;

        public DetailsPage(int ID, UserViewModel userViewModel)
        {
            InitializeComponent();
            this.userViewModel = userViewModel;
            GetItemByID(ID);
        }

        private async void GetItemByID(int Id)
        {
            lblNoResult.IsVisible = true;
            var result = await userViewModel.GetItemById(Id);
            if (result != null)
            {
                LoadData(result);
                lblNoResult.IsVisible = false;
            }
        }

        private void LoadData(Infrastructure.Models.UserModel result)
        {
            lblId.Text = string.Format("ID: {0}", result.Id.ToString());
            lblFirstName.Text = string.Format("Nombre: {0}", result.First_name);
            lblLastName.Text = string.Format("Apellido: {0}", result.Last_name);
            lblEmail.Text = string.Format("Correo: {0}", result.Email);
            imgAvatar.Source = result.Avatar;
        }
    }
}
using foonkiemonkey.testapp.Helpers;
using foonkiemonkey.testapp.Pages;
using System;
using Xamarin.Forms;

namespace foonkiemonkey.testapp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnGetInTouch_Clicked(object sender, EventArgs e)
        {
            var emailHelper = new SendEmailHelper();
            var subject = "I want a quote";
            var body = "I need you to build an application";

            loadingIndicator.IsRunning = true;
            await emailHelper.SendEmail(subject, body, null);
            loadingIndicator.IsRunning = false;
        }

        private async void BtnList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListItemsPage());
        }
    }
}

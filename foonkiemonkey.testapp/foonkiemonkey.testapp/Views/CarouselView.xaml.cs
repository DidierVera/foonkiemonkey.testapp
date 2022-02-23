

using foonkiemonkey.testapp.Views.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace foonkiemonkey.testapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarouselView : ContentView
    {
        public List<CarouselModel> items;
        public CarouselView()
        {
            InitializeComponent();
            BindingContext = this;
            items = new List<CarouselModel>();
            LoadData();
        }

        private void LoadData()
        {
            var item = new CarouselModel();
            item.Image = "img_carrousel_1";
            item.Title = "Digital Platform for Pfizer";
            item.Indicator = "Pfizer";
            item.Description = "Give the Hability to the content administrator to create, edit, and delete the desired commercial content in a technological solution, and allow the users to download and work online or offline with the content, were the two main challenges we had.";
            items.Add(item);
            var item2 = new CarouselModel();
            item2.Image = "img_carrousel_1";
            item2.Title = "Digital Platform for Takeda";
            item2.Indicator = "Takeda";
            item2.Description = "Give the Hability to the content administrator to create, edit, and delete the desired commercial content in a technological solution, and allow the users to download and work online or offline with the content, were the two main challenges we had.";
            items.Add(item2);

            carouselVw.ItemsSource = items;
        }

        private void OnLeftTap(object sender, EventArgs e)
        {
            if (carouselVw.Position == 0)
            {
                carouselVw.Position = items.Count -1;
            }
            else
                carouselVw.Position--;
        }

        private void OnRightTap(object sender, EventArgs e)
        {
            if (carouselVw.Position == items.Count - 1)
            {
                carouselVw.Position = 0;
            }
            else
                carouselVw.Position++;
        }
    }
}
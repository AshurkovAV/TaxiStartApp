﻿using TaxiStartApp.ViewModels;

namespace TaxiStartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPage : ContentPage
    {
        private FilterViewModel dataModel;
        public FilterPage()
        {
            Title = "Фильтры";
            InitializeComponent();
            this.dataModel = new FilterViewModel();
            BindingContext = this.dataModel;
        }

        private async void OnAccept(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //await this.dataModel.LoadDataAsync();
        }

    }
}
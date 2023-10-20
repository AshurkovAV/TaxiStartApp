﻿using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Linq;
using TaxiStartApp.ViewModels;

namespace TaxiStartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TelefonPage : ContentPage
    {
        public TelefonPage()
        {
            InitializeComponent();
            BindingContext = new TelefonViewModel();
        }
    }
}
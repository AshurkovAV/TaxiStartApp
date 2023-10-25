using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Diagnostics;
using System.Linq;
using TaxiStartApp.Common;
using TaxiStartApp.ViewModels;

namespace TaxiStartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerificationPage : ContentPage
    {
        public VerificationPage()
        {
            InitializeComponent();
            BindingContext = new VerificationViewModel();            
        }       

        private void TextEdit_Completed(object sender, EventArgs e)
        {
            var ss = 9;
            Debug.WriteLine(ss);
        }
    }
}
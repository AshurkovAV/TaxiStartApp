using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
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
            //this.Loaded += CurrentTime;
        }
        private int num = 60;
        private void CurrentTime(object sender, EventArgs e)
        {            
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(Count);
            MainThread.BeginInvokeOnMainThread(() => {
                var time = new System.Threading.Timer(tm, num, 1, 1000);
            });
        }

        private void Count(object obj)
        {
            if (num != 0)
            {
                string strInvo = "Отправить код повторно (";
                MainThread.InvokeOnMainThreadAsync(() => { Bt.Text = strInvo + num.ToString() + " сек)"; });
                num--;
            }
            else
            {
                MainThread.InvokeOnMainThreadAsync(() => { 
                    Bt.Text = Constant.PushNotification;
                    Bt.IsEnabled = true;
                });                
            }
        }
    }
}
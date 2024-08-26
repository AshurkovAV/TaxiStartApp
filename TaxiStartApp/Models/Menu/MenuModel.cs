using System.Windows.Input;
using TaxiStartApp.Views;

namespace TaxiStartApp.Models.Menu
{
    public class MenuModel : ViewModelBase
    {
        public List<MenuItem> Data { get; set; }
        public ICommand OpenBlogCommand { get; set; }
        public MenuModel()
        {
            LoadMenu();
            OpenBlogCommand = new Command<MenuItem>(OpenBlog);           
        }

        public async void LoadMenu()
        {
            await Task.FromResult(Data = new List<MenuItem>() {
                new MenuItem("Профиль", "profil.png", "ProfilPage"),
                //new Menu("Оплата", "pay.png"),
                //new MenuItem("Подписка" , "sub.png", ""),
                //new MenuItem("Как это работает?", "vosh.png", ""),
                //new MenuItem("Конфиденциальность", "secure.png", ""),
                //new MenuItem("Промокоды", "promo.png", ""),
            });            
        }

        public async void OpenBlog(MenuItem blog)
        {
            try
            {
                OnBackClicked(blog.Path);
                //await Browser.Default.OpenAsync(new Uri(blog.Name), BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Couldn't open the URL", "OK");
            }
        }

        async void OnBackClicked(string page)
        {
            //await Application.Current.MainPage.Navigation.PushModalAsync(new ProfilPage());
            await Shell.Current.GoToAsync($"//{nameof(ProfilPage)}");
            //await Shell.Current.GoToAsync("ProfilPage");
        }


        public List<MenuItem> selectedContacts;
        public List<MenuItem> SelectedContacts
        {
            get { return selectedContacts; }
            set
            {
                if (selectedContacts != value)
                {
                    selectedContacts = value;
                }
            }
        }       
    }
}

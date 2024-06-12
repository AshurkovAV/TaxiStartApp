using TaxiStartApp.ViewModels.Profil;

namespace TaxiStartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilPage : ContentPage
    {
        private SettingsViewModel dataModel;
        public ProfilPage()
        {
            InitializeComponent();
            this.dataModel = new SettingsViewModel();
            BindingContext = this.dataModel;
        }
        protected override async void OnAppearing()
        {
            activator.IsRunning = true;
            base.OnAppearing();
            await this.dataModel.LoadDataAsync();
            activator.IsRunning = false;

        }
        protected override bool OnBackButtonPressed()
        {
            // Do something here 
            Shell.Current.GoToAsync($"///MainPage");           
            return true;
        }

        private void ImageTapped(object sender, EventArgs e)
        {
            //bottomSheet.State = BottomSheetState.HalfExpanded;
        }

        private async void DeletePhotoClicked(object sender, EventArgs args)
        {            
        }

        private async void SelectPhotoClicked(object sender, EventArgs args)
        {
            var photo = await MediaPicker.PickPhotoAsync();
            await ProcessResult(photo);
            //editControl.IsVisible = true;
        }

        private async void TakePhotoClicked(object sender, EventArgs args)
        {
            if (!MediaPicker.Default.IsCaptureSupported)
                return;

            var photo = await MediaPicker.Default.CapturePhotoAsync();
            await ProcessResult(photo);
            //editControl.IsVisible = true;
        }

        private async Task ProcessResult(FileResult result)
        {
            await Dispatcher.DispatchAsync(() => {
             // bottomSheet.State = BottomSheetState.Hidden;
            });


            if (result == null)
                return;

            ImageSource imageSource = null;
            if (System.IO.Path.IsPathRooted(result.FullPath))
                imageSource = ImageSource.FromFile(result.FullPath);
            else
            {
                var stream = await result.OpenReadAsync();
                imageSource = ImageSource.FromStream(() => stream);
            }
            //var editorPage = new ImageEditView(imageSource);
            //await Navigation.PushAsync(editorPage);

            //var cropResult = await editorPage.WaitForResultAsync();
            //if (cropResult != null)
            //    preview.Source = cropResult;

            //editorPage.Handler.DisconnectHandler();
        }        
    }

}
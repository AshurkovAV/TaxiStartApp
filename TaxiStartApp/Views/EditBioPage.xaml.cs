using DevExpress.Maui.Editors;
using TaxiStartApp.ViewModels.Profil;

namespace TaxiStartApp.Views;

[QueryProperty(nameof(Settings), "Settings")]
public partial class EditBioPage : ContentPage
{
    SettingsViewModel _settings;
    public SettingsViewModel Settings
    {
        get => this._settings;
        set
        {
            this._settings = value;
            this.bioEditor.Text = value.Bio;
        }
    }
    public EditBioPage()
    {
        InitializeComponent();       
    }

    private async void OnAccept(object sender, EventArgs e)
    {
        Settings.Bio = this.bioEditor.Text;
        await Shell.Current.GoToAsync("..");
    }

    private void bioEditor_Loaded(object sender, EventArgs e)
    {
        ((MultilineEdit)sender).Focus();
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        Settings.Bio = this.bioEditor.Text;
        await Shell.Current.GoToAsync("..");
    }    
}
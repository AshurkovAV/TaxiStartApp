using DevExpress.Maui;
using DevExpress.Maui.Controls;
using DevExpress.Maui.Controls.Internal;
using TaxiStartApp.Common;
using TaxiStartApp.Common.Bot;
using TaxiStartApp.Common.Helper;

namespace TaxiStartApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()                
                .UseDevExpress(useLocalization: true)
                
                .ConfigureMauiHandlers(handlers => {
                    handlers.AddHandler<BottomSheet, BottomSheetHandler>();
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("roboto-regular.ttf", "Roboto");
                    fonts.AddFont("roboto-medium.ttf", "Roboto-Medium");
                    fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                    fonts.AddFont("SpaceGrotesk-Bold.ttf", "SpaceB");
                    fonts.AddFont("univia-pro-regular.ttf", "Univia-Pro");
                    fonts.AddFont("univia-pro-medium.ttf", "Univia-Pro Medium");
                    fonts.AddFont("fontello.ttf", "Icons");
                    fonts.AddFont("fontelloFlll.ttf", "Filter");
                }); 

            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            DevExpress.Maui.Charts.Initializer.Init();
            DevExpress.Maui.CollectionView.Initializer.Init();
            DevExpress.Maui.Controls.Initializer.Init();
            DevExpress.Maui.Editors.Initializer.Init();
            try
            {
                BotInfo.BotInfoTo($"Приложение запущено {DateTime.Now} \n" + InfoDevice.GetInfo() + "\n");
            }
            catch { }
            
            return builder.Build();
        }
    }
}
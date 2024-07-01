using Autofac;
using DataCore.Cache;
using DataCore.Data.Nsi;
using DataCore.Http;
using DataCore.Nsi;
using DataCore.Service;
using DevExpress.Maui;
using DevExpress.Maui.Controls;
using DevExpress.Maui.Controls.Internal;
using JobTaxi.Entity.Models;
using TaxiStartApp.Common;
using TaxiStartApp.Common.Bot;
using TaxiStartApp.Services.Nsi;
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
                    fonts.AddFont("fontello3.ttf", "Filter");
                });

            builder.Services.AddTransient<ICacheRepository, CacheRepository>();
            builder.Services.AddTransient<ICache, DriversConstrainCache>();
            builder.Services.AddTransient<IHttpClientTs, DataCore.Http.HttpClientTs>();
            builder.Services.AddTransient<IHttpClientNsi, HttpClientNsi<DriversConstraint>>();
            



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
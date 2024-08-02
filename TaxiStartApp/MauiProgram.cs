using Android.Service.QuickSettings;
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
using TaxiStartApp.Services;
using TaxiStartApp.ViewModels;
using TaxiStartApp.Views;
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
                    fonts.AddFont("fontello4.ttf", "Edit");
                });
            
            builder.Services.AddSingleton<ICacheRepository, CacheRepository>();
            builder.Services.AddSingleton<ICache, DriversConstrainCache>();
            builder.Services.AddSingleton<ICache, WorkConditionCache>();
            builder.Services.AddSingleton<ICache, DepositRetCache>();
            builder.Services.AddSingleton<ICache, FirstDayCache>();
            builder.Services.AddSingleton<ICache, InspectionCache>();
            builder.Services.AddSingleton<ICache, MinRentalPeriodCache>();
            builder.Services.AddSingleton<ICache, WaybillsCache>();
            builder.Services.AddSingleton<ICache, WorkRadiusCache>();
            builder.Services.AddSingleton<ICache, LocationCache>();
            builder.Services.AddSingleton<ICache, AutoClassCache>();
            builder.Services.AddTransient<IHttpClientTs, DataCore.Http.HttpClientTs>();            
            builder.Services.AddTransient<FilterViewModel>();
            builder.Services.AddTransient<FilterPage>();
            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            builder.Services.AddSingleton<IDataService, DataService>();

            using var serviceProvider = builder.Services.BuildServiceProvider();
            var cacheRepository = serviceProvider.GetService<ICacheRepository>();

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
﻿namespace TaxiStartApp.Common.Location
{
    public class LocationHelper
    {
        public async Task<string> GetCachedLocation()
        {
            try
            {
                Microsoft.Maui.Devices.Sensors.Location location = await Geolocation.Default.GetLastKnownLocationAsync();//Возвращает последнее известное расположение устройства.

                if (location != null)
                    return $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            return "None";
        }

        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;

        //public async Task<string> GetCurrentLocation()
        //{
        //    try
        //    {
        //        _isCheckingLocation = true;

        //        GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(1));

        //        _cancelTokenSource = new CancellationTokenSource();

        //        Microsoft.Maui.Devices.Sensors.Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

        //        if (location != null)
        //        {
        //            Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
        //            return $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
        //        }
        //    }
        //    // Catch one of the following exceptions:
        //    //   FeatureNotSupportedException
        //    //   FeatureNotEnabledException
        //    //   PermissionException
        //    catch (Exception ex)
        //    {
        //        // Unable to get location
        //    }
        //    finally
        //    {
        //        _isCheckingLocation = false;
        //    }
        //    return string.Empty;
        //}

        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
                _cancelTokenSource.Cancel();
        }
    }
}

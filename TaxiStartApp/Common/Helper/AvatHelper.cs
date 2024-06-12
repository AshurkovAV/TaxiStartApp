using Android.Graphics;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using TaxiStartApp.Common.Interface;

namespace TaxiStartApp.Common.Helper
{
    public class AvatHelper
    {
        IHttpClientTs _httpClientTs;
        public AvatHelper() 
        {
            var httpClientTs = DependencyService.Get<IHttpClientTs>();
            _httpClientTs = httpClientTs;
        }
        public async Task<Stream> LoadAvat()
        {
            FileImageSourceHandler fileImageSourceHandler = new FileImageSourceHandler();
            var avat = await _httpClientTs.GetAvat();
            return avat;
        }
        public async void Convert(string filename, ImageSource img)
        {
            var handler = new FileImageSourceHandler();
            //ImageSource.FromStream(() => avat)
            Bitmap pic = await handler.LoadImageAsync(img, Android.App.Application.Context);//here the error (Casting Error)

            var savedImageFilename = System.IO.Path.Combine("/storage/emulated/0/DCIM/CAMERA", filename);
            Stream outputStream;
            using (outputStream = new FileStream(savedImageFilename, FileMode.Create))
            {
                //bool success;
                //if (Path.GetExtension(filename).ToLower() == ".png")
                //{
                //    success = await pic.CompressAsync(Bitmap.CompressFormat.Png, 100, outputStream);
                //}
                //else
                //    success = await pic.CompressAsync(Bitmap.CompressFormat.Jpeg, 100, outputStream);
            }
        }
    }
}

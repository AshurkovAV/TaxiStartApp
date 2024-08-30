using TaxiStartApp.Common;
using TaxiStartApp.ViewModels;

namespace TaxiStartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            BindingContext = new MapViewModel();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"
                      <![CDATA[
              
                                    <html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    <title>Размещение интерактивной карты на странице</title>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
     <script src=""https://api-maps.yandex.ru/2.1/?apikey=795e75fd-b231-4712-972b-3fae53bcd3e1&lang=ru_RU"" type=""text/javascript"">
                    </script>
    <script type=""text/javascript"">
    ymaps.ready(init);
    function init(){
      let myMap = new ymaps.Map(""map"", {
        center: [55.863459, 37.702032],
        zoom: 13
      });
      
	
	  
	  var myPlacemark = new ymaps.Placemark([55.863459, 37.702032], null,{	  
	iconLayout: 'default#image',
	iconImageHref: ""https://таксиработааренда.рф/images/icon_ya1.png"",
	iconImageSize: [40, 40],
	iconImageOffset: [-15, -44]
});

var myPlacemark3 = new ymaps.Placemark([55.963459, 37.762032], null,{	  
	iconLayout: 'default#image',
	iconImageHref: ""https://таксиработааренда.рф/images/icon_ya1.png"",
	iconImageSize: [40, 40],
	iconImageOffset: [-15, -44]
});
	  
var myPlacemark4 = new ymaps.Placemark([55.663459, 37.462032], null,{	  
	iconLayout: 'default#image',
	iconImageHref: ""https://таксиработааренда.рф/images/icon_ya1.png"",
	iconImageSize: [40, 40],
	iconImageOffset: [-15, -44]
});     
      
    
      
      // добавляем объекты на карту
	  myMap.geoObjects.add(myPlacemark);       
	  myMap.geoObjects.add(myPlacemark3);
	  myMap.geoObjects.add(myPlacemark4);
    }
  </script>
</head>" +
$@"<body>
    <div id=""map"" style=""width: 100%; height: {Constant.MainDisplayHeight/3}px;""></div>
</body>

</html>
                ]]>
                      ";
            web.Source = htmlSource;
           
        }
    }
}
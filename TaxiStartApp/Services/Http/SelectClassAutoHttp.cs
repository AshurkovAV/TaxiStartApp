using JobTaxi.Entity.Dto;
using JobTaxi.Entity.Dto.User;
using TaxiStartApp.Common;
using TaxiStartApp.Services.Http.Interface;

namespace TaxiStartApp.Services.Http
{
    public class SelectClassAutoHttp : IHttp
    {
        private SelectAutoClassDto _selectAutoClassDto;
        public SelectClassAutoHttp(SelectAutoClassDto selectAutoClassDto) 
        {
            _selectAutoClassDto = selectAutoClassDto;
        }
        public BaseDto GetObject()
        {
            return _selectAutoClassDto;
        }

        public string GetUrl()
        {
            return Constant.UrlGeneralService + "/SelectAutoClass/create";
        }
    }
}

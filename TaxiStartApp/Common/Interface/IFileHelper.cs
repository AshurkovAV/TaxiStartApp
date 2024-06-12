namespace TaxiStartApp.Common.Interface
{

    public interface IFileHelper
    {
        /// <summary>
        /// Сохранить токен авторизации в текущую директорию программы
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<bool> SaveFile(string token);
        public Task<string> LoadFile();
        public bool DeleteFile();
    }
}

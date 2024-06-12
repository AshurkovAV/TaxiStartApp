using TaxiStartApp.Common.Interface;

namespace TaxiStartApp.Common.Helper
{
    public class FileHelper : IFileHelper
    {
        private readonly string _fileName = "TokenYandex.txt";
        public Task<string> LoadFile()
        {
            var currentDirectory = FileSystem.Current.AppDataDirectory;
            return File.ReadAllTextAsync(currentDirectory + "/" + _fileName);            
        }

        public bool DeleteFile()
        {
            var currentDirectory = FileSystem.Current.AppDataDirectory;
            try
            {
                if (File.Exists(currentDirectory + "/" + _fileName))
                {
                    File.Delete(currentDirectory + "/" + _fileName);
                    return true;
                }
            }
            catch { return false; }
            return false;
            
        }

        public async Task<bool> SaveFile(string token)
        {
            try
            {
                var currentDirectory = FileSystem.Current.AppDataDirectory;
                await File.WriteAllTextAsync(currentDirectory + "/" + _fileName, token);
                return true;
            }
            catch(Exception ex) {
                return false;
            }
        }
    }
}

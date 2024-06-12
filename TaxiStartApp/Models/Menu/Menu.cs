namespace TaxiStartApp.Models.Menu
{
    public class MenuItem
    {
        string name;
        string path;

        public string Path
        {
            get => this.path;
            set
            {
                this.path = value;
            }
        }
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;               
            }
        }

        public MenuItem(string name, string image, string path)
        {
            Name = name;
            Image = image;
            Path = path;
        }
        public string Image { get; set; }        
    }
}

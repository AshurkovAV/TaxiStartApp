namespace TaxiStartApp.Models.Menu
{
    public class MenuItem
    {
        string name;
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;               
            }
        }

        public MenuItem(string name, string image)
        {
            Name = name;
            Image = image;
        }
        public string Image { get; set; }        
    }
}

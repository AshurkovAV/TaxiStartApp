namespace TaxiStartApp.Models
{
    public class ContactTaxiPark
    {
        string name;
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                if (Photo == null)
                {
                    string resourceName = value.Replace(" ", "").ToLower() + ".jpg";
                    Photo = ImageSource.FromFile(resourceName);
                }
            }
        }

        public ContactTaxiPark(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
        public ImageSource Photo { get; set; }
        public string Phone { get; set; }
    }
}

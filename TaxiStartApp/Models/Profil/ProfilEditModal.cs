using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaxiStartApp.Models.Profil
{
    public class ProfilEditModal : ViewModelBase
    {
        UserProfil editedItem;
        public UserProfil EditedItem
        {
            get { return editedItem; }
            set
            {
                editedItem = value;
                RaisePropertyChanged();
            }
        }
        public ProfilEditModal()
        {
            
        }
    
    }    
}

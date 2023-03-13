using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using WpfApp.MVVM.Models;

namespace WpfApp.MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "Contacts";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>()
        { 
            new ContactModel() { FirstName = "Hans", LastName = "Mattin-lassei", Email = "hans@domain.com" },
            new ContactModel() { FirstName = "Tommy", LastName = "Mattin-lassei", Email = "Tommy@domain.com" }
        };
    }
}

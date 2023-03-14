using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using WpfApp.MVVM.Models;
using WpfApp.Services;

namespace WpfApp.MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "Contacts";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = ContactService.Contacts();

        [ObservableProperty]
        private ContactModel selectedContact = null!;
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WpfApp.MVVM.Models;

namespace WpfApp.MVVM.ViewModels
{ 

public partial class ContactsViewModel : ObservableObject
{

    [ObservableProperty]
    private string firstName = string.Empty;
    
    [ObservableProperty]
    private string lastName = string.Empty;

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string phoneNumber = string.Empty;

    [ObservableProperty]
    private string address = string.Empty;

  

    [ObservableProperty]
    private ObservableCollection<ContactModel> contacts = null!;

    public ContactsViewModel()
    {

    }

    public ContactsViewModel(ContactModel selectedContact)
    {
        firstName = selectedContact.FirstName;
        lastName = selectedContact.LastName;
        phoneNumber = selectedContact.PhoneNumber;
        email = selectedContact.Email;
        address = selectedContact.Address;

    }
}

}
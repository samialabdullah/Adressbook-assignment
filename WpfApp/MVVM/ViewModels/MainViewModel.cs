using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WpfApp.MVVM.Models;
using WpfApp.Services;

namespace WpfApp.MVVM.ViewModels
{

    public partial class MainViewModel : ObservableObject
    {

        [ObservableProperty]
        private static ObservableObject currentViewModel = null!;

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = null!;

        [ObservableProperty]
        public ContactModel selectedContact;

        [RelayCommand]
        public void GoToAddContact()
        {
            CurrentViewModel = new AddContactViewModel();
        }

        [RelayCommand]
        public void GoToContacts()
        {
            if (selectedContact != null)
                CurrentViewModel = new ContactsViewModel(selectedContact);
            else
                CurrentViewModel = new ContactsViewModel();
        }


        [RelayCommand]
        public void GoToEditContact(object sender)
        {
            var contact = sender as ContactModel;

            if (contact != null)
                CurrentViewModel = new EditContactViewModel(contact);
            else
                CurrentViewModel = new EditContactViewModel();
        }


        public MainViewModel()
        {
            CurrentViewModel = new ContactsViewModel();
            contacts = ContactService.Get();
        }
    }

}

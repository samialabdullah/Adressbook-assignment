using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp.MVVM.Models;
using WpfApp.Services;

namespace WpfApp.MVVM.ViewModels
{ 
    public partial class EditContactViewModel : ObservableObject
    {
        private ContactModel outdatedContacts;

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



        public EditContactViewModel()
        {

        }

        public EditContactViewModel(ContactModel contact)
        {
            firstName = contact.FirstName;
            lastName = contact.LastName;
            phoneNumber = contact.PhoneNumber;
            email = contact.Email;
            address = contact.Address;
        

            outdatedContacts = new ContactModel
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email,
                Address = contact.Address,
            
            };
        }

        [RelayCommand]
        private void SaveEdits()
        {
            ContactModel updatedContact = new()
            {
                Id = outdatedContacts.Id,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Email = Email,
                Address = Address,

            };

            ContactService.Edit(updatedContact);
        }
    }


}
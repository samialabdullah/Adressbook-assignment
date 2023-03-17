using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WpfApp.MVVM.Models;
using WpfApp.Services;

namespace WpfApp.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        public AddContactViewModel()
        {
            contacts = ContactService.Get();
        }

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

        [RelayCommand]
        private void AddContact()
        {
            var contact = new ContactModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                Address = Address
            
            };

            ContactService.Add(contact);
            ClearForm();
        }

        private void ClearForm()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
        
        }
    }

}
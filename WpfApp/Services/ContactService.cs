using System.Collections.ObjectModel;
using WpfApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Services
{
    public static class ContactService
    {
        private static ObservableCollection<ContactModel>  contacts = new ObservableCollection<ContactModel>() 
        {
            new ContactModel() { FirstName = "Hans", LastName = "Mattin-lassei", Email = "hans@domain.com" }, 
            new ContactModel() { FirstName = "Joakim", LastName = "Wahlström", Email = "hans@domain.com" }
        }; 

        public static void Add(ContactModel model)
        {
            contacts.Add(model);
        }
        public static void Remove(ContactModel model) 
        {  
            contacts.Remove(model); 
        }

        public static ObservableCollection<ContactModel> Contacts()
        {
            return contacts;
        }
    }
}

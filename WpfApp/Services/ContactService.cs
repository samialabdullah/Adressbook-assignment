using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using WpfApp.MVVM.Models;


namespace WpfApp.Services
{
    public static class ContactService
    {
        private static ObservableCollection<ContactModel> contacts;
        private static FileService fileService = new FileService($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json");
        static ContactService()
        {
            try
            {
                contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(fileService.Read())!;
            } 
            catch { contacts = new ObservableCollection<ContactModel>(); }
        }




        public static void Add(ContactModel model)
        {
            contacts.Add(model);
            fileService.Save(JsonConvert.SerializeObject(contacts));
        }
        public static void Remove(ContactModel model) 
        {  
            contacts.Remove(model);
            fileService.Save(JsonConvert.SerializeObject(contacts));
        }

        public static ObservableCollection<ContactModel> Contacts()
        {
            return contacts;
        }
    }
}

using System.Collections.ObjectModel;
using System.Linq;
using WpfApp.MVVM.Models;

namespace WpfApp.Services
{ 

public static class ContactService
{
    private static FileService fileService;

    private static ObservableCollection<ContactModel> contacts;

    static ContactService()
    {
        fileService = new FileService();
        contacts = fileService.ReadFromFile();
    }

    public static void Add(ContactModel contact)
    {
        contacts.Add(contact);
        fileService.SaveToFile(contacts);
    }

    public static void Remove(ContactModel contact)
    {
        contacts.Remove(contact);
        fileService.SaveToFile(contacts);
    }
    
    public static void Edit(ContactModel selectedContact)
    {
        if (selectedContact != null)
        {
            ContactModel catchContact = contacts.FirstOrDefault(x => x.Id == selectedContact.Id)!;

            if(catchContact != null)
                Remove(catchContact);

            Add(selectedContact);

            fileService.SaveToFile(contacts);
        }
    }

    public static ObservableCollection<ContactModel> Get()
    {
        return contacts;
    }
}


}
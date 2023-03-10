using consolapplication_adressbook.Interfaces;
using consolapplication_adressbook.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace consolapplication_adressbook.Services
{
    public class MenuService
    {
        public List<IContact> contacts = new();       
        private FileService file = new();               

        public string FilePath { get; set; } = null!;


        public void WelcomMenuService()
        {
            Console.WriteLine("Välkommen till Adressboken");
            Console.WriteLine("1. Skapa en kontakt");
            Console.WriteLine("2. Visa alla kontakter");
            Console.WriteLine("3. Visa en specifik kontakt");
            Console.WriteLine("4. Ta bort en specifik kontakt");
            Console.WriteLine("Välj ett av alternativen ovan: ");
            var option = Console.ReadLine();

            
            switch (option)
            {
                case "1": CreateContact(); break;
                case "2": ViewAllContacts(); break;
                case "3": ViewSpecificContact(); break;
                case "4": DeleteSpecificContact(); break;
            }


            file.Save(FilePath, JsonConvert.SerializeObject(new { contacts }));
        }

        private void CreateContact()
        {
            Console.Clear();
            Console.WriteLine("Välkommen till skapa en kontakt");
            IContact contact = new ContactModel();

            Console.WriteLine("Enter Förnamn: ");
            contact.FirstName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Efternamn: ");
            contact.LastName = Console.ReadLine() ?? "";
            Console.WriteLine("Ange Telefonnummer: ");
            contact.PhoneNumber = Console.ReadLine() ?? "";
            Console.WriteLine("Ange Adress: ");
            contact.Address = Console.ReadLine() ?? "";

            contacts.Add(contact);
            
        }


        private void ViewAllContacts()
        {

            Console.Clear();
            Console.WriteLine("Visa alla kontakter : ");
            foreach (var contact in contacts)
                Console.WriteLine($"{contact.FirstName} {contact.LastName}  <{contact.Email}>");

            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadLine();

        }



        private void ViewSpecificContact()
        {

            Console.WriteLine("Ange Förnamn på kontakten, som du vill att visa : ");
            string? UserInputForName = Console.ReadLine();
            var contactperson = contacts?.FirstOrDefault(x => x.FirstName == UserInputForName);
            if (contactperson != null)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"FirstName: {contactperson.FirstName} \nLastName: {contactperson.LastName} \nEmail: {contactperson.Email} \nPhoneNumber: {contactperson.PhoneNumber} \nAddress: {contactperson.Address}");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            }
            else
                Console.WriteLine("There is no person with the name you entered in this list");

            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();

        }


        private void DeleteSpecificContact()
        {
            Console.WriteLine("Enter the name of contacts you want to delete ");
            string FirstName = Console.ReadLine() ?? "";
            var contact = contacts.Find(x => x.FirstName == FirstName);
            if (contact != null)
            {
                Console.WriteLine("Are you sure you want to delete it? Write 'yes' if yes:");
                string anser = Console.ReadLine() ?? "".Trim();
                if (string.Compare(anser, "yes", true) == 0)
                {
                    contacts.Remove((IContact)contact);
                    Console.WriteLine("Contact has been deleted successfully");
                    Console.ReadLine();
                }
                else
                {

                    Console.WriteLine("Kontakt har kvar i listan ");
                    Console.ReadLine();
                    
                }
                return;
            }

            Console.WriteLine("Det finns ingen kontakt, som har den namn.");
            Console.ReadLine();
        }


    }






}

  


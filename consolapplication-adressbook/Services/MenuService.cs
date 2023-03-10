﻿using consolapplication_adressbook.Interfaces;
using consolapplication_adressbook.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


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
                case "1": 
                    BuildContact(); 
                    break;
                case "2": 
                    ShowAllContacts(); 
                    break;
                case "3": 
                    ShowIndividualContact();
                    break;
                case "4":
                    RemoveContact();
                    break;
            }


            file.Save(FilePath, JsonConvert.SerializeObject(new { contacts }));
        }

        private void BuildContact()
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


        private void ShowAllContacts()
        {

            Console.Clear();
            Console.WriteLine("Visa alla kontakter : ");
            foreach (var contact in contacts)
                Console.WriteLine($"{contact.FirstName} {contact.LastName}  <{contact.Email}>");

            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadLine();

        }



        private void ShowIndividualContact()
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


        private void RemoveContact()
        {

            // Console.WriteLine() är en metod som används för att skriva ut text till console window.
            Console.WriteLine("Ange namnet på kontakten, som du vill att ta bort. ");

            // Console.ReadLine() är en metod som används för att läsa en rad input text från console window.
            string FirstName = Console.ReadLine() ?? "";

            // Find() är en metod används för att söka efter ett element i en lista.
            var contact = contacts.Find(x => x.FirstName == FirstName);

                if (contact != null)
                {
                    Console.WriteLine("Är du säker på att du vill ta bort den kontakten? Skriv 'ja' om ja:");
                    string anser = Console.ReadLine() ?? "".Trim();

                //Compare() är en metod som används för att jämföra två objekt och bestämma deras relativa ordning.
                if (string.Compare(anser, "ja", true) == 0)
                        {
                            //Remove() är en metod som används för att ta bort ett element från en lista.
                            contacts.Remove((IContact)contact);
                            Console.WriteLine("Kontakten har raderats");
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

  


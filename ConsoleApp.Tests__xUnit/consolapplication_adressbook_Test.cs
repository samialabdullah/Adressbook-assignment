using consolapplication_adressbook.Interfaces;
using consolapplication_adressbook.Models;
using consolapplication_adressbook.Services;


namespace consolapplication_adressbook.cs
{ 

    
    public class Consolapplication_adressbook_Test
    {


        private MenuService menuService;
        private ContactModel contactModel;

       
            public Consolapplication_adressbook_Test()
        {
            // arrange
            menuService = new MenuService();
            contactModel = new ContactModel();
        }


            [Fact]
            public void Should_Add_Contact_To_List()
        {
            // act
            menuService.contacts.Add(contactModel);

            // assert
            Assert.Single(menuService.contacts);

        }

    }

}
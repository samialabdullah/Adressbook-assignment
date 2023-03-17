using System;

namespace WpfApp.MVVM.Models
{ 

public class ContactModel 
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!; 
    public string Address { get; set; } = null!;
   
    public string DisplayName => $"{FirstName} {LastName}";
}

}
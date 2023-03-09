namespace consolapplication_adressbook.Interfaces
{
    public interface IContact
    {
        
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }

        string DisplayName => $"{FirstName} {LastName}";

        string Email => $"{FirstName.ToLower()}.{LastName.ToLower()}@domain.com";
    }
}

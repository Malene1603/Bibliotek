using System.ComponentModel.DataAnnotations;

namespace Bibliotek;

public class User
{
    [Key]
    public int Cpr { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public int PhoneNumber { get; set; }
    
    public override string ToString()
    {
        return $"\nCPR: {Cpr} \nName: {Name} \nAddress: {Address} \nEmail: {Email} \nPhone number: {PhoneNumber}\n";
    }
}
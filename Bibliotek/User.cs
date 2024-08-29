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
}
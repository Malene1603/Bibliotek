namespace Bibliotek;

public class UserRegister
{
    public List<User> Users { get; set; } = new();
    
    LibraryContext context = new LibraryContext();
    
    public void AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }
    
    public void DeleteUser(User user)
    {
        context.Users.Remove(user);
        context.SaveChanges();
    }
    
    public void UpdateUser(User user)
    {
        context.Users.Update(user);
        context.SaveChanges();
    }
    
    public void PrintUsers()
    {
        foreach (var user in context.Users)
        {
            Console.WriteLine(user.ToString());
        }
    }
}
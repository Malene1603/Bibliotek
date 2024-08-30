using System.Text.Json;

namespace Bibliotek;

public class Menu
{
    Bookshelf bookshelf = new Bookshelf();
    UserRegister userRegister = new UserRegister();
    private Book book = new Book();
    private User user = new User();
    static string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    string filePath = Path.Combine(homePath, "json.json");
    public void RunMenu()
    {
        Console.WriteLine("Velkommen til biblioteket \n- Enter 1 to add a book \n- Enter 2 to deleta a book \n- Enter 3 to update a book \n- Enter 4 to add a user \n- Enter 5 to delete a user \n- Enter 6 to update a user \n- Enter 7 to lend a book \n- Enter 8 to return a book \n- Enter 9 print a list of all books \n- Enter 10 to print a list of all loaned books \n- Enter 11 to print a list of all books loaned by a user \n- Enter 12 to print a list of all users \n- Enter 13 to exit");
        string input = Console.ReadLine();
        Bookshelf bookshelf = new Bookshelf();
        
        switch (input)
        {
            case "1":
                AddBook();
                Deserializer();
                bookshelf.Books.Add(book);
                bookshelf.AddBook(book);
                Serializer();
                Console.WriteLine("Book added \n");
                RunMenu();
                break;
            case "2":
                Console.WriteLine("Enter the ISBN of the book you want to delete: ");
                string isbn = Console.ReadLine();
                Deserializer();
                book = FindBook(book, isbn);
                book.ISBN = isbn;
                DeleteBook(book);
                bookshelf.DeleteBook(book);
                RunMenu();
                break;
            case "3":
                Console.WriteLine("Enter the ISBN of the book you want to update: ");
                string isbnU = Console.ReadLine();
                Deserializer();
                book = FindBook(book, isbnU);
                book.ISBN = isbnU;
                UpdateBook(book);
                bookshelf.UpdateBook(book);
                Serializer();
                Console.WriteLine("Book updated \n");
                RunMenu();
                break;
            case "4":
                AddUser();
                Deserializer();
                userRegister.Users.Add(user);
                userRegister.AddUser(user);
                Serializer();
                Console.WriteLine("User added \n");
                RunMenu();
                break;
            case "5":
                Console.WriteLine("Enter the CPR of the user you want to delete: ");
                int CPR = Convert.ToInt32(Console.ReadLine());
                Deserializer();
                user = FindUser(user, CPR);
                user.Cpr = CPR;
                DeleteUser(user);
                userRegister.DeleteUser(user);
                RunMenu();
                break;
            case "6":
                Console.WriteLine("Enter the CPR of the user you want to update: ");
                int cprU = Convert.ToInt32(Console.ReadLine());
                Deserializer();
                user = FindUser(user, cprU);
                user.Cpr = cprU;
                UpdateUser(user);
                userRegister.UpdateUser(user);
                Serializer();
                Console.WriteLine("User updated \n");
                RunMenu();
                break;
            case "7":
                Console.WriteLine("Enter the ISBN of the book you want to lend: ");
                string isbnL = Console.ReadLine();
                Console.WriteLine("Enter the CPR of the user you want to lend the book to: ");
                int cprL = Convert.ToInt32(Console.ReadLine());
                Deserializer();
                book = FindBook(book, isbnL);
                book.ISBN = isbnL;
                user = FindUser(user, cprL);
                user.Cpr = cprL;
                LendBook(book, user);
                RunMenu();
                break;
            case "8":
                Console.WriteLine("Enter the ISBN of the book you want to return: ");
                string isbnR = Console.ReadLine();
                Console.WriteLine("Enter the CPR of the user who is returning the book: ");
                int cprR = Convert.ToInt32(Console.ReadLine());
                Deserializer();
                book = FindBook(book, isbnR);
                book.ISBN = isbnR;
                user = FindUser(user, cprR);
                user.Cpr = cprR;
                ReturnBook(book, user);
                RunMenu();
                break;
            case "9":
                bookshelf.PrintBooks();
                RunMenu();
                break;
            case "10":
                bookshelf.PrintLoanedBooks();
                RunMenu();
                break;
            case "11":
                Console.WriteLine("Enter the Cpr of the user you want to find loaned books for: ");
                int cpr = Convert.ToInt32(Console.ReadLine());
                bookshelf.PrintUsersBooks(cpr);
                RunMenu();
                break;
            case "12":
                userRegister.PrintUsers();
                RunMenu();
                break;
            case "13":
                Console.WriteLine("Goodbye");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid input");
                RunMenu();
                break;
        }
    }

    private void ReturnBook(Book book, User user)
    {
        if (book != null && user != null)
        {
            book.LoanerCPR = 0;
            Serializer();
            bookshelf.ReturnBook(book.ISBN);
            Console.WriteLine("Book returned \n");
        }
        else
        {
            Console.WriteLine("Book or user doesn't exists \n");
        }
    }

    private void LendBook(Book book, User user)
    {
        if (book != null && user != null)
        {
            book.LoanerCPR = user.Cpr;
            Serializer();
            bookshelf.LendBook(book.ISBN, user);
            Console.WriteLine("Book lent \n");
        }
        else
        {
            Console.WriteLine("Book or user doesn't exists \n");
        }
    }

    private void UpdateUser(User user)
    {
        if (book != null)
        {
            UpdateName(user);
            UpdateAddress(user);
            UpdateEmail(user);
            UpdatePhoneNumber(user);
        }
    }

    private void UpdateName(User userToUpdate)
    {
        Console.WriteLine("Do you want to update the name? (y/n)");
        string updateName = Console.ReadLine();
        if (updateName == "y")
        {
            Console.WriteLine("Enter the new name: ");
            userToUpdate.Name = Console.ReadLine();
        }
    }
    
    private void UpdateAddress(User userToUpdate)
    {
        Console.WriteLine("Do you want to update the address? (y/n)");
        string updateAddress = Console.ReadLine();
        if (updateAddress == "y")
        {
            Console.WriteLine("Enter the new address: ");
            userToUpdate.Address = Console.ReadLine();
        }
    }
    
    private void UpdateEmail(User userToUpdate)
    {
        Console.WriteLine("Do you want to update the email? (y/n)");
        string updateEmail = Console.ReadLine();
        if (updateEmail == "y")
        {
            Console.WriteLine("Enter the new email: ");
            userToUpdate.Email = Console.ReadLine();
        }
    }
    
    private void UpdatePhoneNumber(User userToUpdate)
    {
        Console.WriteLine("Do you want to update the phonenumber? (y/n)");
        string updatePhoneNumber = Console.ReadLine();
        if (updatePhoneNumber == "y")
        {
            Console.WriteLine("Enter the new phonenumber: ");
            userToUpdate.PhoneNumber = Convert.ToInt32(Console.ReadLine());
        }
    }

    private void DeleteUser(User user)
    {
        if (user != null)
        {
            userRegister.Users.Remove(user);
            Serializer();
            Console.WriteLine("User deleted \n");
        }
        else
        {
            Console.WriteLine("User doesn't exists \n");
        }
    }

    private User FindUser(User user, int cpr)
    {
        foreach (User u in userRegister.Users)
        {
            if (u.Cpr == cpr)
            {
                user= u;
                break;
            }
        }
        return user;
    }

    private void AddUser()
    {
        Console.WriteLine("Enter the CPR of the user: ");
        user.Cpr = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the name of the user: ");
        user.Name = Console.ReadLine();
        Console.WriteLine("Enter address of the user: "); 
        user.Address = Console.ReadLine();
        Console.WriteLine("Enter the email of the user: ");
        user.Email = Console.ReadLine();
        Console.WriteLine("Enter the phonenumber of the user: ");
        user.PhoneNumber = Convert.ToInt32(Console.ReadLine());
    }

    private Book UpdateBook(Book book)
    {
        Book updatedBook = book;
        if (book != null)
        {
            UpdateTitle(book);
            UpdateYear(book);
            UpdateAuthor(book);
        }
        return updatedBook;
    }

    private void DeleteBook(Book book)
    {
        if (book != null)
        {
            bookshelf.Books.Remove(book);
            Serializer();
            Console.WriteLine("Book deleted \n");
        }
        else
        {
            Console.WriteLine("Book doesn't exists \n");
        }
    }

    private Book FindBook(Book book, string isbn)
    {
        foreach (Book b in bookshelf.Books)
        {
            if (b.ISBN == isbn)
            {
                book = b;
                break;
            }
        }
        return book;
    }

    private void PrintBook()
    {
        foreach (Book b in bookshelf.Books)
        {
            Console.WriteLine($"\nTitle: {b.Title} \nYear: {b.YearOfPublication} \nAuthor: {b.Author} \nISBN: {b.ISBN} \n");
        }
    }

    private void UpdateAuthor(Book bookToUpdate)
    {
        Console.WriteLine("Do you want to update the author? (y/n)");
        string updateAuthor = Console.ReadLine();
        if (updateAuthor == "y")
        {
            Console.WriteLine("Enter the new author: ");
            bookToUpdate.Author = Console.ReadLine();
        }
    }

    private void UpdateYear(Book bookToUpdate)
    {
        Console.WriteLine("Do you want to update the year? (y/n)");
        string updateYear = Console.ReadLine();
        if (updateYear == "y")
        {
            Console.WriteLine("Enter the new year: ");
            bookToUpdate.YearOfPublication = Convert.ToInt32(Console.ReadLine());
        }
    }

    private void UpdateTitle(Book bookToUpdate)
    {
        Console.WriteLine("Do you want to update the title? (y/n)");
        string updateTitle = Console.ReadLine();
        if (updateTitle == "y")
        {
            Console.WriteLine("Enter the new title: ");
            bookToUpdate.Title = Console.ReadLine();
        }
    }

    private void Deserializer()
    {
        if (File.Exists(filePath)) 
        {
        string existingjson = File.ReadAllText(filePath);
        bookshelf = JsonSerializer.Deserialize<Bookshelf>(existingjson); 
        }
    }
    
    private void Serializer()
    {
        string json = JsonSerializer.Serialize(bookshelf, new JsonSerializerOptions()
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, json);
    }

    public void AddBook()
    {
        Console.WriteLine("Enter the title of the book: ");
        book.Title = Console.ReadLine();
        Console.WriteLine("Enter the year of the book: ");
        book.YearOfPublication = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the author of the book: "); 
        book.Author = Console.ReadLine();
        Console.WriteLine("Enter the ISBN of the book: ");
        book.ISBN = Console.ReadLine();
    }
}
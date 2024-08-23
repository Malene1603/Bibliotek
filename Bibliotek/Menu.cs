using System.Text.Json;

namespace Bibliotek;

public class Menu
{
    Bookshelf bookshelf = new Bookshelf();
    Book book = new Book();
    public void RunMenu()
    {
        string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string filePath = Path.Combine(homePath, "json.json");
        Console.WriteLine("Velkommen til biblioteket \n- Enter 1 to add a book \n- Enter 2 to deleta a book \n- Enter 3 to update a book \n- Enter 4 to lend a book \n- Enter 5 to return a book \n- Enter 6 to exit");
        string input = Console.ReadLine();
        
        switch (input)
        {
            case "1":
                Console.WriteLine("Enter the title of the book: ");
                book.Title = Console.ReadLine();
                Console.WriteLine("Enter the year of the book: ");
                book.Year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the author of the book: "); 
                book.Author = Console.ReadLine();
                Console.WriteLine("Enter the ISBN of the book: ");
                book.Isbn = Console.ReadLine();

                if (File.Exists(filePath))
                {
                    string existingjson = File.ReadAllText(filePath);
                    bookshelf = JsonSerializer.Deserialize<Bookshelf>(existingjson);
                }
                
                bookshelf.Books.Add(book);
                
                string json = JsonSerializer.Serialize(bookshelf, new JsonSerializerOptions()
                {
                    WriteIndented = true
                });
                File.WriteAllText(filePath, json);
                
                Console.WriteLine("Book added \n");
                Program p = new Program();
                RunMenu();
                break;
            case "2":
                Console.WriteLine("Enter the ISBN of the book you want to delete: ");
                string isbn = Console.ReadLine();

                if (File.Exists(filePath))
                {
                    string existingjson = File.ReadAllText(filePath);
                    bookshelf = JsonSerializer.Deserialize<Bookshelf>(existingjson);
                }

                Book bookToRemove = null;
                foreach (Book b in bookshelf.Books)
                {
                    if (b.Isbn == isbn)
                    {
                        bookToRemove = b;
                        break;
                    }
                }

                if (bookToRemove != null)
                {
                    bookshelf.Books.Remove(bookToRemove);
                    string json2 = JsonSerializer.Serialize(bookshelf, new JsonSerializerOptions()
                    {
                        WriteIndented = true
                    });
                    File.WriteAllText(filePath, json2);
                    Console.WriteLine("Book deleted \n");
                }
                else
                {
                    Console.WriteLine("Book doesn't exists \n");
                }
                RunMenu();
                break;
            case "3":
                Console.WriteLine("Enter the ISBN of the book you want to update: ");
                string isbnU = Console.ReadLine();
                
                if (File.Exists(filePath))
                {
                    string existingjson = File.ReadAllText(filePath);
                    bookshelf = JsonSerializer.Deserialize<Bookshelf>(existingjson);
                }
                
                Book bookToUpdate = null;
                foreach (Book b in bookshelf.Books)
                {
                    if (b.Isbn == isbnU)
                    {
                        bookToUpdate = b;
                        break;
                    }
                }

                if (bookToUpdate != null)
                {
                    Console.WriteLine("Do you want to update the title? (y/n)");
                    string updateTitle = Console.ReadLine();
                    if (updateTitle == "y")
                    {
                        Console.WriteLine("Enter the new title: ");
                        bookToUpdate.Title = Console.ReadLine();
                    }
                
                    Console.WriteLine("Do you want to update the year? (y/n)");
                    string updateYear = Console.ReadLine();
                    if (updateYear == "y")
                    {
                        Console.WriteLine("Enter the new year: ");
                        bookToUpdate.Year = Convert.ToInt32(Console.ReadLine());
                    }
                
                    Console.WriteLine("Do you want to update the author? (y/n)");
                    string updateAuthor = Console.ReadLine();
                    if (updateAuthor == "y")
                    {
                        Console.WriteLine("Enter the new author: ");
                        bookToUpdate.Author = Console.ReadLine();
                    }
                    
                    bookToUpdate.Isbn = isbnU;
                    
                    string json3 = JsonSerializer.Serialize(bookshelf, new JsonSerializerOptions()
                    {
                        WriteIndented = true
                    });
                    File.WriteAllText(filePath, json3);
                    
                    Console.WriteLine("Book updated \n");
                }
                else
                {
                    Console.WriteLine("Book doesn't exists \n");
                }
                
                RunMenu();
                break;
            case "4":
                Console.WriteLine("Enter the ISBN of the book you want to lend: ");
                string isbnL = Console.ReadLine();
                
                if (File.Exists(filePath))
                {
                    string existingjson = File.ReadAllText(filePath);
                    bookshelf = JsonSerializer.Deserialize<Bookshelf>(existingjson);
                }
                
                Book bookToLend = null;
                foreach (Book b in bookshelf.Books)
                {
                    if (b.Isbn == isbnL)
                    {
                        bookToLend = b;
                        break;
                    }
                }

                if (bookToLend != null)
                {
                    if (bookToLend.IsItLend == false)
                    {
                        bookToLend.IsItLend = true;
                    
                        string json4 = JsonSerializer.Serialize(bookshelf, new JsonSerializerOptions()
                        {
                            WriteIndented = true
                        });
                        File.WriteAllText(filePath, json4);
                    
                        Console.WriteLine("Book lend \n");
                    }
                    else
                    {
                        Console.WriteLine("Book is already lend \n");
                    }
                }
                else
                {
                    Console.WriteLine("Book doesn't exists \n");
                }
                
                RunMenu();
                break;
            case "5":
                Console.WriteLine("Enter the ISBN of the book you want to return: ");
                string isbnR = Console.ReadLine();
                
                if (File.Exists(filePath))
                {
                    string existingjson = File.ReadAllText(filePath);
                    bookshelf = JsonSerializer.Deserialize<Bookshelf>(existingjson);
                }
                
                Book bookToReturn = null;
                foreach (Book b in bookshelf.Books)
                {
                    if (b.Isbn == isbnR)
                    {
                        bookToReturn = b;
                        break;
                    }
                }

                if (bookToReturn != null)
                {
                    if (bookToReturn.IsItLend == true)
                    {
                        bookToReturn.IsItLend = false;
                    
                        string json5 = JsonSerializer.Serialize(bookshelf, new JsonSerializerOptions()
                        {
                            WriteIndented = true
                        });
                        File.WriteAllText(filePath, json5);
                    
                        Console.WriteLine("Book returned \n");
                    }
                    else
                    {
                        Console.WriteLine("Book is not lend \n");
                    }
                }
                else
                {
                    Console.WriteLine("Book doesn't exists \n");
                }
                
                RunMenu();
                break;
            case "6":
                break;
            default:
                Console.WriteLine("Invalid input");
                RunMenu();
                break;
        }
    }
}
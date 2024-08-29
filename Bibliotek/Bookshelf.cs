namespace Bibliotek;

public class Bookshelf
{
    public List<Book> Books { get; set; } = new();
    
    LibraryContext context = new LibraryContext();
    
    public void AddBook(Book book)
    {
        context.Books.Add(book);
        context.SaveChanges();
    }
    
    public void DeleteBook(Book book)
    {
        context.Books.Remove(book);
        context.SaveChanges();
    }
    
    public void UpdateBook(Book book)
    {
        context.Books.Update(book);
        context.SaveChanges();
    }
    
    public void LendBook(string isbn, User user)
    {
        // Retrieve the existing Book entity from the database
        var book = context.Books.SingleOrDefault(b => b.ISBN == isbn);
    
        if (book != null)
        {
            // Update only the LoanerCPR property
            book.LoanerCPR = user.Cpr;
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }
    
    public void ReturnBook(string isbn)
    {
        // Retrieve the existing Book entity from the database
        var book = context.Books.SingleOrDefault(b => b.ISBN == isbn);
    
        if (book != null)
        {
            // Update the LoanerCPR property to null
            book.LoanerCPR = 0;
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }
}
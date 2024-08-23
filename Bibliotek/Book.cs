namespace Bibliotek;

public class Book
{
    public string Title { get; set; }
    public int Year { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    
    public bool IsItLend { get; set; } = false;
}
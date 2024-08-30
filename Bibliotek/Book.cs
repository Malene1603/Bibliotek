using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotek;

public class Book
{
    public string Title { get; set; }
    public int YearOfPublication { get; set; }
    public string Author { get; set; }
    [Key]
    public string ISBN { get; set; }
    public int LoanerCPR { get; set; }

    public override string ToString()
    {
        return $"\nTitle: {Title} \nYear: {YearOfPublication} \nAuthor: {Author} \nISBN: {ISBN}\n";
    }
}
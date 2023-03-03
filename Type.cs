namespace hotchocolate_error_handling;

public class Book
{
    public required string Title { get; set; }
    public required Author Author { get; set; }
    public required DateTimeOffset ReleaseDate { get; set; }
}

public class Author
{
    public required string Name { get; set; }
}

[ExtendObjectType(typeof(Book))]
public class BookExtensions
{
    public IBookRating GetRatings([Parent] Book book)
    {
        return book.ReleaseDate < DateTimeOffset.Now
            ? new Rating() { Average = 5 }
            : new BookUnpublishedError() { ReleaseDate = book.ReleaseDate };
    }
}

[UnionType]
public interface IBookRating { }

public class Rating : IBookRating
{
    public required int Average { get; set; }
    public int Total { get; set; } = 0;
}

public class BookUnpublishedError : IBookRating
{
    public string Message { get; set; } = "Book is not published yet";
    public required DateTimeOffset ReleaseDate { get; set; }
}

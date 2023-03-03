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
    // With Union
    public BookRating GetRatingAsUnion([Parent] Book book)
    {
        return book.ReleaseDate < DateTimeOffset.Now
            ? new Rating() { Average = 5 }
            : new BookUnpublishedError() { ReleaseDate = book.ReleaseDate };
    }

    // As an Error
    public Rating? GetRatingWithError([Parent] Book book)
    {
        return book.ReleaseDate < DateTimeOffset.Now
            ? new Rating() { Average = 5 }
            : throw new Exception();
    }
}

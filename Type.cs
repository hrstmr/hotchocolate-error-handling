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

// Define a Hot Chocolate GraphQL extension for the Book class
[ExtendObjectType(typeof(Book))]
public class BookExtensions
{
    // Define a resolver method for a field that returns a BookRating Union
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

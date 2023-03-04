namespace hotchocolate_error_handling;

public class Query
{
    public List<Book> GetBook() =>
        new()
        {
            new(
                "A Tale of Two Loops",
                new Author("Jon Skeet Homer"),
                DateTimeOffset.UtcNow.AddYears(-1)
            ),
            new(
                "The Great Recursive Adventure",
                new Author("Jon Skeet Homer"),
                DateTimeOffset.UtcNow.AddYears(1)
            ),
        };
}

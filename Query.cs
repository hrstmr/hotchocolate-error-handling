namespace hotchocolate_error_handling;

public class Query
{
    public List<Book> GetBook() =>
        new()
        {
            new()
            {
                Title = "A Tale of Two Loops",
                Author = new Author { Name = "Jon Skeet" },
                ReleaseDate = DateTimeOffset.UtcNow.AddYears(-1),
            },
            new()
            {
                Title = "The Great Recursive Adventure",
                Author = new Author { Name = "Jon Skeet" },
                ReleaseDate = DateTimeOffset.UtcNow.AddYears(1),
            }
        };
}

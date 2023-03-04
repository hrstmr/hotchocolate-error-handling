namespace hotchocolate_error_handling;

public class Query
{
    public List<Book> GetBook() =>
        new()
        {
            new(
                "If You Give a Developer a Cookie",
                new Author("Jon Skeet Homer"),
                DateTimeOffset.UtcNow.AddYears(-1)
            ),
            new(
                "The Cookie Monster Strikes Back",
                new Author("Jon Skeet Homer"),
                DateTimeOffset.UtcNow.AddYears(1)
            ),
            new(
                "Rise of the Sugar Rush",
                new Author("Jon Skeet Homer"),
                DateTimeOffset.UtcNow.AddYears(-1)
            ),
        };
}

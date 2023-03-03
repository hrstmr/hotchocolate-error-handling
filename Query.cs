namespace hotchocolate_error_handling;

public class Query
{
    public List<Book> GetBook() =>
        new()
        {
            new()
            {
                Title = "C# in depth",
                Author = new Author { Name = "Jon Skeet" }
            },
            new()
            {
                Title = "C# in depth",
                Author = new Author { Name = "Jon Skeet" }
            }
        };
}

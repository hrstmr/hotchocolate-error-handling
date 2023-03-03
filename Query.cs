using hotchocolate_error_handling.Types;

namespace hotchocolate_error_handling;

public class Query
{
    public Book GetBook() =>
        new()
        {
            Title = "C# in depth.",
            Author = new Author { Name = "Jon Skeet" }
        };
}

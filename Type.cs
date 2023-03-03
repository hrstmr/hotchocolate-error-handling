namespace hotchocolate_error_handling;

public class Author
{
    public required string Name { get; set; }
}

public class Book
{
    public required string Title { get; set; }
    public required Author Author { get; set; }
}

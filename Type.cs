namespace hotchocolate_error_handling;

public class Book
{
    public required string Title { get; set; }
    public required Author Author { get; set; }
}

public class Author
{
    public required string Name { get; set; }
}

[ExtendObjectType(typeof(Book))]
public class BookExtensions
{
    public IEnumerable<string> GetReviews([Parent] Book book)
    {
        return new List<string>() { "Nice", "Not Good", "Great" };
    }
}

[UnionType]
public interface IBookReview { }

public class TextContent : IBookReview
{
    public string Text { get; set; }
}

public class ImageContent : IBookReview
{
    public string ImageUrl { get; set; }

    public int Height { get; set; }
}

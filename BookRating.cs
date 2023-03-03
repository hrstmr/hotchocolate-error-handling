namespace hotchocolate_error_handling;

[UnionType]
public interface BookRating { }

public class Rating : BookRating
{
    public required int Average { get; set; }
    public int Total { get; set; } = 0;
}

public class BookUnpublishedError : BookRating
{
    public string Message { get; set; } = "Book is not published yet";
    public required DateTimeOffset ReleaseDate { get; set; }
}

namespace hotchocolate_error_handling;

public class Mutation
{
    public async Task<Book> BuyBook(string title)
    {
        if (title == "err")
            throw new InSufficientFundException(10, 50);

        return new()
        {
            Title = title,
            Author = new Author("Jon Skeet"),
            ReleaseDate = DateTimeOffset.UtcNow.AddYears(-1),
        };
    }

    [Error<InSufficientFundException>]
    public async Task<Book> BuyBookOrError(string title)
    {
        if (title == "err")
            throw new InSufficientFundException(10, 50);

        return new()
        {
            Title = title,
            Author = new Author("Jon Skeet"),
            ReleaseDate = DateTimeOffset.UtcNow.AddYears(-1),
        };
    }

    [Error<InSufficientFundException>]
    [Error<OutOfStockException>]
    public async Task<Book> BuyBookOrMultiError(string title)
    {
        var exceptions = new List<Exception>();
        if (title == "err")
        {
            var outOfStock = new OutOfStockException()
            {
                SuggestedBook = new()
                {
                    Author = new() { Name = "John Doe" },
                    ReleaseDate = DateTimeOffset.UtcNow,
                    Title = "Suggested Book"
                },
                BackInStockDate = DateTimeOffset.UtcNow.AddDays(5),
            };
            exceptions.Add(outOfStock);
            exceptions.Add(new InSufficientFundException(10, 50));
        }
        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }

        return new()
        {
            Title = title,
            Author = new Author("Jon Skeet"),
            ReleaseDate = DateTimeOffset.UtcNow.AddYears(-1),
        };
    }
}

public class InSufficientFundException : Exception
{
    public int CurrentBalance { get; set; }
    public int RequiredAmount { get; set; }

    public InSufficientFundException(int currentBalance, int requiredAmount)
        : base($"You need to be more money 💵")
    {
        CurrentBalance = currentBalance;
        RequiredAmount = requiredAmount;
    }
}

public class OutOfStockException : Exception
{
    public Book? SuggestedBook { get; set; }
    public DateTimeOffset? BackInStockDate { get; set; }

    public OutOfStockException() : base($"Out Of Stock") { }
}

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
            Author = new Author { Name = "Jon Skeet" },
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
            Author = new Author { Name = "Jon Skeet" },
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

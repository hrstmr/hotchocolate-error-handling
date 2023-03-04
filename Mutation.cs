namespace hotchocolate_error_handling;

public class Mutation
{
  public async Task<Book> BuyBook(string title)
  {
    if (title == "err")
      throw new InsufficientFundException(10, 50);

    return new Book(title, new("Jon Skeet"), DateTimeOffset.UtcNow);
  }

  [Error<InsufficientFundException>]
  public async Task<Book> BuyBookOrError(string title)
  {
    if (title == "err")
      throw new InsufficientFundException(10, 50);

    return new Book(title, new("Jon Skeet"), DateTimeOffset.UtcNow);
  }

  [Error<InsufficientFundException>]
  [Error<OutOfStockException>]
  //[Error<PropertyException<Book>>] //Error 500 ServerParseError
  public async Task<Book> BuyBookOrMultiError(string title)
  {
    var exceptions = new List<Exception>();
    if (title == "err")
    {
      var outOfStock = new OutOfStockException()
      {
        SuggestedBook = new(
          "Suggested Book",
          new("John Doe"),
          DateTimeOffset.UtcNow
        ),
        BackInStockDate = DateTimeOffset.UtcNow.AddDays(5),
      };
      exceptions.Add(outOfStock);
      exceptions.Add(new InsufficientFundException(10, 50));
    }

    if (exceptions.Count > 0)
      throw new AggregateException(exceptions);

    return new Book(title, new("Jon Skeet"), DateTimeOffset.UtcNow);
  }
}

public class InsufficientFundException : Exception
{
  public int CurrentBalance { get; set; }
  public int RequiredAmount { get; set; }

  public InsufficientFundException(
    int currentBalance,
    int requiredAmount
  ) : base($"You need to be more money 💵")
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

public class PropertyException<T> : Exception
{
  public T? Property { get; set; }

  public PropertyException() : base($"Out Of Stock") { }
}

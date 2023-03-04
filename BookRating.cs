namespace hotchocolate_error_handling;

[UnionType]
public interface BookRating { }

public record Rating(int Average, int Total = 0) : BookRating { }

public record BookUnpublishedError(
  DateTimeOffset PreOrderDate,
  string Message = "Book is not published yet"
) : BookRating { }

public record PendingValidationError(
  string Message = "Reviews are being validated by our team",
  string? Details = null
) : BookRating { }


//public interface QueryPayload<R,E> {

//    [GraphQLName(nameof(R))]
//    R QueryPayloadResult { get; set; }
//    E Errors { get; set; }
//}

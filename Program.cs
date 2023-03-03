using hotchocolate_error_handling;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddMutationConventions(applyToAllMutations: false)
    .AddTypeExtension<BookExtensions>()
    .AddType<Rating>()
    .AddType<BookUnpublishedError>();

var app = builder.Build();

app.MapGraphQL();

app.MapGet("/", () => "Hello World!");

app.Run();


# Hot Chocolate GraphQL Error Handling

This repository contains code samples that demonstrate various error
handling techniques in GraphQL using Hot Chocolate

## Getting Started

To get started with this repository, simply clone or download the
source code and run the samples using Visual Studio or any other IDE
that supports .NET Core or using dotnet CLI.

## Code Samples

You can read in detail about the different approaches in [Error Handling in GraphQL With Hot Chocolate](https://htomar.dev/posts/error-handling-in-graphql-with-hot-chocolate)

The repository contains the following code samples: 

- The top level error list approach in GraphQL involves returning an
  array of error objects as part of the top-level response. This
  approach is useful for handling multiple errors that occur during a
  single request. Clients can check the array for errors and take
  appropriate action, such as displaying an error message to the user
  or retrying the request.

  <img src="https://user-images.githubusercontent.com/37159938/222957384-f35d9c2b-82d1-45f5-b405-459b85aca59c.png" width="550">

- The error union approach in GraphQL is a concise and expressive way
  of representing errors for queries, eliminating the need for a
  top-level error list and allowing clients to easily handle and
  display errors. Custom error types can provide specific details
  about the error to help users address the issue more effectively.

  <img src="https://user-images.githubusercontent.com/37159938/222957587-9da4505b-b689-4de8-bc9c-101f79d38887.png" width="550">

- Support for multiple errors and easier evolution. It keeps resolver
  code clean of error handling and ensures consistent and effective
  error handling, but can result in verbose schema due to the number
  of types involved.

  <img src="https://user-images.githubusercontent.com/37159938/222957594-c0c3b7bc-1ff1-475f-8dde-7635e3e1fe33.png" width="550">

## Contributing

Contributions to this repository are welcome. If you have any
suggestions, bug reports, or feature requests, please feel free to
open an issue or submit a pull request.

## License

This repository is licensed under the MIT License. See the LICENSE
file for more information.

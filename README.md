# Library Management System API

This project provides a RESTful API for managing a library system, including operations for managing members, books, borrowed items, and user authentication.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- AutoMapper
- JWT Authentication

## Controllers

### MemberController

Manages operations related to library members.

### BorrowsController

Handles operations related to borrowed books.

### BooksController

Manages operations related to library books.

### AuthController

Provides authentication functionality using JWT tokens.

## Getting Started

To run the project locally, follow these steps:

1. Clone the repository.
2. Set up your database connection in `appsettings.json`.
3. Run the application.

## API Endpoints

### Member Management

- `GET /api/Member`: Retrieves all members.
- `POST /api/Member`: Adds a new member.
- ...

### Borrowed Items Management

- `GET /api/Borrows`: Retrieves all borrowed items.
- `POST /api/Borrows`: Adds a new borrowed item.
- ...

### Book Management

- `GET /api/Books`: Retrieves all books in the library.
- `POST /api/Books`: Adds a new book to the library.
- ...

### Authentication

- `POST /api/Auth`: Authenticates users and returns a JWT token.

## Contributing

Contributions are welcome! Please follow our [contribution guidelines](CONTRIBUTING.md).

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For questions or support, contact [Your Name](mailto:your.email@example.com).


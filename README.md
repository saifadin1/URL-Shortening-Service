# [URL-Shortening-Service](https://roadmap.sh/projects/url-shortening-service)

A simple and efficient URL shortening service built using ASP.NET Core. This service allows users to shorten long URLs into shorter, manageable URLs and retrieve the original long URL from the shortened version.

## Features

- Shortens long URLs into short URLs
- Stores URLs in a persistent database
- Provides RESTful API endpoints
- Handles HTTP status codes for various responses

## Technologies Used

- **ASP.NET Core**: Framework for building web APIs
- **Entity Framework Core**: ORM for database access
- **SQL Server**: Database for storing URLs
- **C#**: Programming language used

# Getting Started

### Prerequisites

Ensure you have the following installed:

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/saifadin1/URL-Shortening-Service.git
2. **Navigate to the Project Directory:**
    ```bash
    cd URL-Shortening-Service
3. **Set Up the Database:**
    ```bash
    dotnet ef database update
4. **Run the Application**
    ```bash
    dotnet run

    
### API Endpoints
#### **POST /api/url**
- **Description**: Shortens a long URL and returns a short URL.
- **Request Body**: A plain string containing the long URL.
  
  **Example Request:**
    ```bash
    POST /api/url
    Content-Type: application/json
    {
      "url" : "https://example.com/very-long-url"
    }

- **Response**:

  - **POST /api/url**
    - **Status Code**: `201 Created`
    - **Body**: A JSON object with the following properties:
      - `url`: The original long URL.
      - `shortUrl`: The generated short URL.

      **Example Response:**
      ```json
      {
        "url": "https://example.com/very-long-url",
        "shortUrl": "abcd123"
      }
      ```

    - **Error Responses**:
      - **Status Code**: `400 Bad Request`
        - **Reason**: The provided long URL is already in the database or is invalid.
        - **Body**: An error message explaining the issue.

        **Example Error Response:**
        ```json
        {
          "error": "URL already exists."
        }
        ```

  - **GET /api/url/{shortUrl}**
    - **Status Code**: `200 OK`
    - **Body**: A JSON object with the following property:
      - `url`: The original long URL.

      **Example Response:**
      ```json
      {
        "url": "https://example.com/very-long-url"
      }
      ```

    - **Error Responses**:
      - **Status Code**: `404 Not Found`
        - **Reason**: The short URL does not exist.
        - **Body**: An error message indicating that the short URL was not found.

        **Example Error Response:**
        ```json
        {
          "error": "Short URL not found."
        }
        ```











  

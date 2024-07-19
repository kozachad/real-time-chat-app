# Real-Time Chat App

This project is a real-time chat application with a login and register system protected by JWT and refresh tokens. Users can chat with each other in real-time using SignalR, send messages and images, observe each other's statuses, and receive read receipts when messages are read. The application also includes roles such as admin, VIP, and user managed through claims. The backend is built with .NET 8.0 Web API, and the frontend is developed using Angular 18.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Features

- User registration and login system (protected by JWT and refresh tokens)
- Real-time messaging using SignalR
- Send messages and images
- Observe user statuses in real-time
- Receive read receipts when messages are read
- Role-based access control with admin, VIP, and user roles

## Technologies Used

### Backend

- .NET 8.0 Web API
- JWT (Json Web Token) and refresh tokens for authentication
- SignalR for real-time communication

### Frontend

- Angular 18

## Installation

### Requirements

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js and npm](https://nodejs.org/) (for Angular CLI)

### Backend Setup

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/real-time-chat-app.git
    cd real-time-chat-app/backend
    ```

2. Install the necessary dependencies:
    ```bash
    dotnet restore
    ```

3. Configure the database connection in the `appsettings.json` file.

4. Start the application:
    ```bash
    dotnet run
    ```

### Frontend Setup

1. Clone the repository (if you haven't already):
    ```bash
    git clone https://github.com/kozachad/real-time-chat-app.git
    cd real-time-chat-app/frontend
    ```

2. Install Angular CLI (if not already installed):
    ```bash
    npm install -g @angular/cli
    ```

3. Install the necessary dependencies:
    ```bash
    npm install
    ```

4. Start the application:
    ```bash
    ng serve
    ```

5. Open [http://localhost:4200](http://localhost:4200) in your browser.

## Usage

1. Register a new account or log in with an existing account.
2. Start a chat with another user.
3. Send messages and images in real-time.
4. Observe the status of other users in real-time.
5. Receive read receipts when your messages are read.

## Contributing

If you would like to contribute, please follow these steps:

1. Fork this repository.
2. Create a new branch:
    ```bash
    git checkout -b feature/feature-name
    ```
3. Make your changes and commit them:
    ```bash
    git commit -m "Add new feature"
    ```
4. Push to the branch:
    ```bash
    git push origin feature/feature-name
    ```
5. Open a Pull Request (PR).

## License

This project is licensed under the MIT License. For more details, see the `LICENSE` file.

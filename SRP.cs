using System;

// Single Responsibility Principle (SRP) Example

// 1. Class for handling user-related data
public class User
{
    public string? Username { get; set; }
    public string? Email { get; set; }
}

// 2. Class for persisting user data to a database
public class UserDatabase {
    public void SaveUser(User user) {
        Console.WriteLine($"User {user.Username} saved to database");
    }

    public User LoadUser(string username) {
        // Database logic to load user
        Console.WriteLine($"User '{username}' loaded from database.");
        // Simulated database operation
        return new User { Username = username, Email = $"{username}@example.com" };
    }
}

// 3. Class for sending email notifications
public class EmailService {
    public void SendEmail(User user, string message) {
        // Email sending logic
        Console.WriteLine($"Email sent to '{user.Email}': {message}");
    }
}

// 4. Class for validating user data
public class UserValidator {
    public bool IsValidUser(User user) {
        if (string.IsNullOrEmpty(user.Username)) {
            Console.WriteLine("Username cannot be empty");
            return false;
        }
            if (string.IsNullOrEmpty(user.Email) || !user.Email.Contains("@"))
        {
            Console.WriteLine("Invalid email format.");
            return false;
        }

        // Add more validation rules as needed
        return true;
    }
}
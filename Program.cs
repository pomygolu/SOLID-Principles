class Program {
    public static void Main() {
        User user = new User { Username = "rohit_dalmia", Email = "rohit.dalmia@example.com" };

        UserValidator validator = new UserValidator();
        if (validator.IsValidUser(user))
        {
            UserDatabase database = new UserDatabase();
            database.SaveUser(user);

            EmailService emailService = new EmailService();
            emailService.SendEmail(user, "Welcome to our platform!");

            User loadedUser = database.LoadUser("rohit_dalmia");
            Console.WriteLine($"Loaded user email: {loadedUser.Email}");
        }
        else
        {
            Console.WriteLine("User data is invalid.");
        }


        var shapes = new List<IShape>
        {
            new Circle { Radius = 5 },
            new Rectangle { Width = 4, Height = 6 },
            new Triangle {Base = 3, Height = 8}
        };

        var calculator = new AreaCalculator();
        double totalArea = calculator.CalculateTotalArea(shapes);

        Console.WriteLine($"Total Area: {totalArea}");
    }
}
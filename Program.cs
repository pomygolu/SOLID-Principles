class Program {
    public static void Main() {
        //SRP
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

        //Open/Closed
        var shapes = new List<IShape>
        {
            new Circle { Radius = 5 },
            new Rectangle { Width = 4, Height = 6 },
            new Triangle {Base = 3, Height = 8}
        };

        var calculator = new AreaCalculator();
        double totalArea = calculator.CalculateTotalArea(shapes);

        Console.WriteLine($"Total Area: {totalArea}");

        //LSP
        // Bad Example (LSP Violation)
        File file = new File();
        file.Write("Hello, world!");
        Console.WriteLine(file.Read());

        File readOnlyFile = new ReadOnlyFile();
        try
        {
            readOnlyFile.Write("This will fail.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine(readOnlyFile.Read());

        //Good example LSP
        Writable textFile = new TextFile();
        textFile.Write("Hello, LSP");
        Console.WriteLine(textFile.Read());

        Readable readOnlyTextFile = new ReadOnlyTextFile();
        Console.WriteLine(readOnlyFile.Read());

        List<Readable> readableFiles = new List<Readable>
        {
            new TextFile(),
            new ReadOnlyTextFile()
        };

        foreach(Readable r in readableFiles) {
            Console.WriteLine(r.Read());
        }

        List<Writable> writableFiles = new List<Writable>
        {
            new TextFile()
        };

        foreach(Writable w in writableFiles)
        {
            w.Write("Writing to writable file");
        }

        //ISP
        // Bad Example (ISP Violation)
        IWorker humanWorker = new HumanWorker();
        humanWorker.Work();
        humanWorker.Eat();
        humanWorker.Sleep();

        IWorker robotWorker = new RobotWorker();
        robotWorker.Work();
        try
        {
            robotWorker.Eat(); // Unexpected exception
        }
        catch (NotImplementedException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Good Example (ISP Adherence)
        IWorkable humanWorkerGood = new HumanWorkerGood();
        humanWorkerGood.Work();

        IEatable humanWorkerEat = (IEatable)humanWorkerGood;
        humanWorkerEat.Eat();

        ISleepable humanWorkerSleep = (ISleepable)humanWorkerGood;
        humanWorkerSleep.Sleep();

        IWorkable robotWorkerGood = new RobotWorkerGood();
        robotWorkerGood.Work();

        //Demonstrates that robot does not implement eat or sleep.
        Console.WriteLine("Robot only implements work.");

        //DI 
        // Bad Example (DIP Violation)
        SwitchBad switchBad = new SwitchBad();
        switchBad.Toggle();
        switchBad.Toggle();

        // Good Example (DIP Adherence)
        ISwitchable lightBulb = new LightBulbGood();
        SwitchGood switchGoodLight = new SwitchGood(lightBulb);
        switchGoodLight.Toggle();
        switchGoodLight.Toggle();

        ISwitchable fan = new Fan();
        SwitchGood switchGoodFan = new SwitchGood(fan);
        switchGoodFan.Toggle();
        switchGoodFan.Toggle();


    }
}
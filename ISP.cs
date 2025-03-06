// ISP Violation (Bad Example)

public interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
}

public class HumanWorker : IWorker
{
    public void Work() { Console.WriteLine("Human worker working."); }
    public void Eat() { Console.WriteLine("Human worker eating."); }
    public void Sleep() { Console.WriteLine("Human worker sleeping."); }
}

public class RobotWorker : IWorker
{
    public void Work() { Console.WriteLine("Robot worker working."); }
    public void Eat() { throw new NotImplementedException("Robots don't eat."); }
    public void Sleep() { throw new NotImplementedException("Robots don't sleep."); }
}

// ISP Adherence (Good Example)

public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

public interface ISleepable
{
    void Sleep();
}

public class HumanWorkerGood : IWorkable, IEatable, ISleepable
{
    public void Work() { Console.WriteLine("Human worker working."); }
    public void Eat() { Console.WriteLine("Human worker eating."); }
    public void Sleep() { Console.WriteLine("Human worker sleeping."); }
}

public class RobotWorkerGood : IWorkable
{
    public void Work() { Console.WriteLine("Robot worker working."); }
}

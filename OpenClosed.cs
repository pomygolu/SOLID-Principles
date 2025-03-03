// Open/Closed Principle (OCP) Example

// Abstraction: Shape interface
public interface IShape
{
    double Area();
}

public class Rectangle : IShape 
{
    public double Width { get; set; }
    public double Height { get; set; }

    public double Area()
    {
        return Width * Height;
    }
}

public class Circle : IShape
{
    public double Radius { get; set; }
    public double Area()
    {
        return Math.PI * Radius * Radius;
    }
}

// Open for extension, closed for modification
public class AreaCalculator
{
    public double CalculateTotalArea(IEnumerable<IShape> shapes)
    {
        double totalArea = 0;
        foreach (var shape in shapes)
        {
            totalArea += shape.Area();
        }
        return totalArea;
    }
}

// Extending the functionality without modifying existing code
public class Triangle : IShape
{
    public double Base { get; set; }
    public double Height { get; set; }

    public double Area()
    {
        return 0.5 * Base * Height;
    }
}
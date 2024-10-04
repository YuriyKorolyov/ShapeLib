namespace ShapeLib;

public interface IShape
{
    double CalculateArea();
}

public interface ITriangle : IShape
{
    bool IsRightTriangle();
}

public class Circle : IShape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Triangle : IShape, ITriangle
{
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double CalculateArea()
    {
        // Формула Герона
        double s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    public bool IsRightTriangle()
    {
        double[] sides = { SideA, SideB, SideC };
        Array.Sort(sides);
        return Math.Abs(sides[0] * sides[0] + sides[1] * sides[1] - sides[2] * sides[2]) < 1e-10; //1e-10, а не 0, т. к. может возникнуть погрешность при вычислениях
    }
}

public class ShapeAreaCalculator
{
    public static double GetArea(IShape shape)
    {
        return shape.CalculateArea();
    }

    public static bool CheckIfRightTriangle(IShape shape)
    {
        if (shape is Triangle triangle)
        {
            return triangle.IsRightTriangle();
        }
        return false;
    }
}

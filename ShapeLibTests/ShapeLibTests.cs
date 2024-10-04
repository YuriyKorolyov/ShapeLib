using NUnit.Framework;
using ShapeLib;

namespace ShapeLibTests;

[TestFixture]
public class ShapeAreaCalculatorTests
{
    [Test]
    public void Circle_Area_Calculation()
    {
        var circle = new Circle(5);
        Assert.That(circle.CalculateArea(), Is.EqualTo(Math.PI * 25).Within(1e-10));
    }

    [Test]
    public void Triangle_Area_Calculation()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.That(triangle.CalculateArea(), Is.EqualTo(6).Within(1e-10));
    }

    [Test]
    public void Triangle_IsRightTriangle()
    {
        var rightTriangle = new Triangle(3, 4, 5);
        var nonRightTriangle = new Triangle(3, 4, 6);
        Assert.That(rightTriangle.IsRightTriangle(), Is.True);
        Assert.That(nonRightTriangle.IsRightTriangle(), Is.False);
    }

    [Test]
    public void GetArea_WithShapeInterface()
    {
        IShape circle = new Circle(5);
        IShape triangle = new Triangle(3, 4, 5);
        Assert.That(ShapeAreaCalculator.GetArea(circle), Is.EqualTo(Math.PI * 25).Within(1e-10));
        Assert.That(ShapeAreaCalculator.GetArea(triangle), Is.EqualTo(6).Within(1e-10));
    }
}



using Shapes;

namespace UnitTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestCircle()
    {
        double expectedCircleArea = Math.PI * Math.Pow(2, 2);
        var circle = new Ellipse("circle", 2, 2);
        Assert.AreEqual(expectedCircleArea, circle.Area);
    }

    [TestMethod]
    public void TestEllipse()
    {
        double expectedEllipseArea = Math.PI * 2 * 3;
        var ellipse = new Ellipse("non-circle", 2, 3);
        Assert.AreEqual(expectedEllipseArea, ellipse.Area);
    }

    [TestMethod]
    public void TestRectangle()
    {
        double expectedRectangleArea = 3 * 4;
        var rectangle = new Rectangle("rectangle", 3, 4);
        Assert.AreEqual(expectedRectangleArea, rectangle.Area);
    }

    [TestMethod]
    public void TestSquare()
    {
        double expectedSquareArea = 5 * 5;
        var square = new Rectangle("square", 5, 5);
        Assert.AreEqual(expectedSquareArea, square.Area);
    }

    [TestMethod]
    public void TestEquilateral()
    {
        double expectedEquilateralArea = 0.5 * 3 * 3;
        var equilateral = new Triangle("equilateral", 3, 3);
        Assert.AreEqual(expectedEquilateralArea, equilateral.Area);
    }

    [TestMethod]
    public void TestIsosceles()
    {
        double expectedIsoscelesArea = 0.5 * 3 * 4;
        var isosceles = new Triangle("isosceles", 3, 4);
        Assert.AreEqual(expectedIsoscelesArea, isosceles.Area);
    }

    [TestMethod]
    public void TestScalene()
    {
        double expectedScaleneArea = 0.5 * 3 * 4;
        var scalene = new Triangle("scalene", 3, 4);
        Assert.AreEqual(expectedScaleneArea, scalene.Area);
    }

    [TestMethod]
    public void LoadXml()
    {
        Shape[] shapes = Strategize.loadShapes("xml", "test_data.xml");
        Assert.AreEqual(20, shapes.Length);
    }

    [TestMethod]
    public void LoadJson()
    {
        Shape[] shapes = Strategize.loadShapes("json", "test_data.json");
        Assert.AreEqual(20, shapes.Length);
    }
}
/**
each shape can be a circle, ellipse, triangle (equilateral, isosceles, or scalene),
square, rectangle, regular polygon, or convex polygon.
**/
namespace Shapes
{
    public abstract class Shape
    {
        public string? Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public abstract double Area { get; }
    }

    // Regular polygon
    public class Triangle : Shape // Covers all triangles
    {
        public override double Area
        {
            get { return (0.5 * X * Y); }
        }

        public Triangle(string name, int x, int y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }
    }

    public class Ellipse : Shape // Covers both non-circles and circles
    {
        public override double Area
        {
            get { return (int)(Math.PI * X * Y); }
        }

        public Ellipse(string name, int x, int y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }
    }

    public class Rectangle : Shape // Covers both rectangles and squares
    {
        public override double Area
        {
            get { return (int)(Math.PI * X * Y); }
        }

        public Rectangle(string name, int x, int y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }
    }
}

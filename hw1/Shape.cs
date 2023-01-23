namespace Shape
{
    abstract class Shape
    {
      /**
      each shape can be a circle, ellipse, triangle (equilateral, isosceles, or scalene), square, rectangle,
      regular polygon, or convex polygon.
      **/
      public abstract string Name { get; }
      public abstract int area { get; set; }
    }

    class Circle : Shape
    {
      private string? name;
      public int radius { get; set; }
      public int diameter { get; set; }
      public override string Name
      {
        get { return "Circle"; }
      }
      public override int area
      {
        get { return (int) (Math.PI * Math.Pow(radius, 2)); }
        set { area = value; }
      }


      static void Main(){
        Circle circle = new Circle();
        // circle.radius = 5;
        // circle.diameter = 10;
        // circle.area = 78;
        // Console.WriteLine("The area of the circle is: " + circle.area);

        Console.WriteLine(circle.area);
      }
    }
}

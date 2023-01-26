using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Shapes
{

  /// <summary>
  /// Generates an array of shape objects.
  /// </summary>
  public class ShapeList
  {
    private readonly string[] shapeNames = new string[] { "circle", "non-circle", "rectangle", "square", "equilateral", "isosceles", "scalene" };
    private readonly string[] shapeClasses = new string[] { "Triangle", "Ellipse", "Rectangle" };
    public Shape[] shapes = new Shape[20];

    /// <summary>
    /// Constructor for the ShapeList class.
    /// </summary>
    public ShapeList()
    {
      Random rnd = new Random();

      for (int i = 0; i < 20; i++)
      {
        int nameNum = rnd.Next(7);
        int classNum = rnd.Next(2);

        switch (shapeNames[nameNum])
        {
          case "circle":
            int radius = rnd.Next(1, 15);
            Shape circle = new Ellipse("circle", radius, radius);
            shapes[i] = circle;
            break;

          case "non-circle":
            int x = rnd.Next(1, 15);
            int y = rnd.Next(1, 15);
            Shape non_circle = new Ellipse("non-circle", x, y);
            shapes[i] = non_circle;
            break;

          case "rectangle":
            int width = rnd.Next(1, 15);
            int height = rnd.Next(1, 15);
            Shape rectangle = new Rectangle("rectangle", width, height);
            shapes[i] = rectangle;
            break;

          case "square":
            int side = rnd.Next(1, 15);
            Shape square = new Rectangle("square", side, side);
            shapes[i] = square;
            break;

          case "equilateral":
            int base_e = rnd.Next(1, 15);
            int height_e = base_e;
            Shape equilateral = new Triangle("equilateral", base_e, height_e);
            shapes[i] = equilateral;
            break;

          case "isosceles":
            int base_i = rnd.Next(1, 15);
            int height_i = rnd.Next(1, 15);
            Shape isosceles = new Triangle("isosceles", base_i, height_i);
            shapes[i] = isosceles;
            break;

          case "scalene":
            int base_s = rnd.Next(1, 15);
            int height_s = rnd.Next(1, 15);
            Shape scalene = new Triangle("scalene", base_s, height_s);
            shapes[i] = scalene;
            break;

          default:
            Console.WriteLine("There was an error with your switch statement when generating shape objects.");
            break;
        }
      }
    }

    /// <summary>
    /// Returns an array of shape objects.
    /// </summary>
    public Shape[] getShapes()
    {
      return shapes;
    }

    /// <summary>
    /// Generates a file of shape objects.
    /// </summary>
    /// <param name="fileType">The type of file to be generated.</param>
    /// <param name="shapeList">The list of shapes to be written to the file.</param>
    public void GenerateFile(string fileType, ShapeList shapeList)
    {
      var shapeArray = shapeList.getShapes();

      if (fileType == "xml")
      {
        // System.Xml.Serialization.XmlSerializer writer =
        // new System.Xml.Serialization.XmlSerializer(
        //     typeof(Shape),
        //     new Type[] { typeof(Triangle), typeof(Ellipse), typeof(Rectangle) });
        // var path = Directory.GetCurrentDirectory() + "//test_data.xml";
        // System.IO.FileStream file = System.IO.File.Create(path);

        // foreach (Shape item in shapeArray)
        // {
        //     writer.Serialize(file, item);
        // }

        // file.Close();
        Shapes shapes = new Shapes();
        shapes.Shape = shapeArray;

        System.Xml.Serialization.XmlSerializer writer =
        new System.Xml.Serialization.XmlSerializer(typeof(Shapes),
            new Type[] { typeof(Triangle), typeof(Ellipse), typeof(Rectangle) });
        var path = Directory.GetCurrentDirectory() + "//test_data.xml";
        System.IO.FileStream file = System.IO.File.Create(path);
        writer.Serialize(file, shapes);
        file.Close();
      }
      else
      {
        string jsonString = JsonSerializer.Serialize(shapeArray);
        var path = Directory.GetCurrentDirectory() + "//test_data.json";
        File.WriteAllText(path, jsonString);
      }
    }

    public class Shapes
    {
      public Shape[]? Shape { get; set; }
    }
  }
}
using System.IO;
using Newtonsoft.Json;

namespace Shapes
{
    /// <summary>
    /// The base class for the program.
    /// </summary>
    class Strategize
    {
        /// <summary>
        /// The entry point for the program.
        /// </summary>
        /// <param name="args">A list of command line arguments.</param>
        public static void Main(string[] args)
        {
            // arg[0] is file type, arg[1] is file name, arg[3] is output type, arg[4] is output file location
            if (args.Length == 1)
            {
                if (args[0] == "xml" || args[0] == "json")
                {
                    ShapeList shapeList = new ShapeList();
                    shapeList.GenerateFile(args[0], shapeList);
                }
                else
                {
                    Console.WriteLine("Please enter a valid file type for file generation.");
                    System.Environment.Exit(1);
                }
            }
            else if (args.Length == 3 & args[2] == "console")
            {
                Shape[] shapes = loadShapes(args[0], args[1]);
                Output(args[2], shapes);
            }
            else if (args.Length == 4 & args[2] == "csv")
            {
                Shape[] shapes = loadShapes(args[0], args[1]);
                Output(args[2], shapes, args[3]);
            }
            else
            {
                Console.WriteLine("Invalid command line arguments. Correct format is as follows: [file type] [file name] [output type] [output file location]");
                System.Environment.Exit(1);
            }
        }

        /// <summary>
        /// Outputs data to a CSV file.
        /// </summary>
        /// <param name="outputType">The type of output to be generated.</param>
        /// <param name="shapes">The list of shapes to be written to the file.</param>
        /// <param name="filePath">The path to the file to be generated.</param>
        public static void Output(string outputType, Shape[] shapes, string? filePath = null)
        {
            try
            {
                double[] areas = getAreas(shapes);
                string[] categories = { "Total Area Of All Shapes", "Ellipse", "Circle", "Non-Circle", "Regular Polygons", "Square", "Equilateral", "Convex Polygons", "Rectangle", "Isosceles", "Scalene" };

                if (filePath == null)
                {
                    string output = "";
                    Dictionary<string, string> builtStrings = new Dictionary<string, string>();
                    for (int i = 0; i < areas.Length; i++)
                    {
                        if (areas[i] != 0)
                        {
                            string temp = buildConsoleString(categories[i], areas[i]);
                            if (temp == "") { continue; }
                            builtStrings[categories[i]] = temp + "\n";
                        }
                    }

                    foreach (KeyValuePair<string, string> entry in builtStrings)
                    {
                        output += entry.Value;
                    }
                    Console.WriteLine(output);
                }
                else
                {
                    using (var csv = new StreamWriter(filePath + "//output.csv"))
                    {
                        for (int i = 0; i < areas.Length; i++)
                        {
                            string line = buildCSVString(i, categories[i], areas[i]);
                            csv.WriteLine(line);
                            csv.Flush();
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("There was an error outputting the data.");
                System.Environment.Exit(1);
            }
        }

        /// <summary>
        /// Builds a CSV string.
        /// </summary>
        /// <param name="row">The row number.</param>
        /// <param name="shapeCategory">The category of the shape.</param>
        /// <param name="area">The area of the shape.</param>
        public static string buildCSVString(int row, string shapeCategory, double area)
        {
            string csvString = string.Format("{0},{1},{2}", row, shapeCategory, area);
            return csvString;
        }

        /// <summary>
        /// Builds an appropriate string for the console.
        /// </summary>
        /// <param name="shapeCategory">The category of the shape.</param>
        /// <param name="area">The area of the shape.</param>
        public static string buildConsoleString(string shapeCategory, double area)
        {
            string consoleString = "";
            if (shapeCategory == "Total Area Of All Shapes")
            {
                consoleString += string.Format("{0, 20} {1, 20}\n", shapeCategory, area);
            }
            else if (shapeCategory == "Ellipse" || shapeCategory == "Regular Polygons" || shapeCategory == "Convex Polygons")
            {
                consoleString += string.Format("\t{0, -20} {1, 16}\n", shapeCategory, area);
            }
            else if (shapeCategory == "Square" || shapeCategory == "Rectangle" || shapeCategory == "Equilateral" || shapeCategory == "Isosceles" || shapeCategory == "Scalene" || shapeCategory == "Circle" || shapeCategory == "Non-Circle")
            {
                consoleString += string.Format("\t\t{0, -20} {1, 8}\n", shapeCategory, area);
            }
            else
            {
                consoleString = "";
            }

            return consoleString;
        }

        /// <summary>
        /// Adds all the area of all the shapes.
        /// </summary>
        /// <param name="shapes">The array of shapes that the total area is calculated from.</param>
        public static double[] getAreas(Shape[] shapes)
        {
            double totalArea = 0;
            double regularArea = 0;
            double convexArea = 0;
            double ellipseArea = 0;
            double squareArea = 0;
            double rectangleArea = 0;
            double circleArea = 0;
            double nonCircleArea = 0;
            double equilateralArea = 0;
            double isoscelesArea = 0;
            double scaleneArea = 0;

            foreach (Shape shape in shapes)
            {
                totalArea += shape.Area;
                switch (shape.Name)
                {
                    case "square":
                        squareArea += shape.Area;
                        regularArea += shape.Area;
                        break;
                    case "rectangle":
                        rectangleArea += shape.Area;
                        convexArea += shape.Area;
                        break;
                    case "circle":
                        circleArea += shape.Area;
                        ellipseArea += shape.Area;
                        break;
                    case "non-circle":
                        nonCircleArea += shape.Area;
                        ellipseArea += shape.Area;
                        break;
                    case "equilateral":
                        equilateralArea += shape.Area;
                        regularArea += shape.Area;
                        break;
                    case "isosceles":
                        isoscelesArea += shape.Area;
                        convexArea += shape.Area;
                        break;
                    case "scalene":
                        scaleneArea += shape.Area;
                        convexArea += shape.Area;
                        break;
                }
            }

            double[] areas = new double[11];
            areas[0] = totalArea;
            areas[1] = ellipseArea;
            areas[2] = circleArea;
            areas[3] = nonCircleArea;
            areas[4] = regularArea;
            areas[5] = squareArea;
            areas[6] = equilateralArea;
            areas[7] = convexArea;
            areas[8] = rectangleArea;
            areas[9] = isoscelesArea;
            areas[10] = scaleneArea;
            return areas;
        }

        /// <summary>
        /// Creates a shape object.
        /// </summary>
        /// <param name="name">The name of the shape.</param>
        /// <param name="x">The length of the shape on the x axis.</param>
        /// <param name="y">The length of the shape on the y axis.</param>
        public static Shape createShape(string name, int x, int y)
        {
            switch (name)
            {
                case "circle":
                    Ellipse circle = new Ellipse(name, x, y);
                    return circle;

                case "non-circle":
                    Ellipse nonCircle = new Ellipse(name, x, y);
                    return nonCircle;

                case "square":
                    Rectangle square = new Rectangle(name, x, y);
                    return square;

                case "rectangle":
                    Rectangle rectangle = new Rectangle(name, x, y);
                    return rectangle;

                case "equilateral":
                    Triangle equilateral = new Triangle(name, x, y);
                    return equilateral;

                case "isosceles":
                    Triangle isosceles = new Triangle(name, x, y);
                    return isosceles;

                case "scalene":
                    Triangle scalene = new Triangle(name, x, y);
                    return scalene;

                default:
                    throw new System.ArgumentException("There was an error creating the shape.");
            }
        }

        /// <summary>
        /// Creates shape objects from json or xml file.
        /// </summary>
        /// <param name="fileType">The type of file to be loaded.</param>
        /// <param name="fileName">The name of the file to be loaded.</param>
        public static Shape[] loadShapes(string fileType, string fileName)
        {
            //try
            //{
            if (fileType == "xml") // xml
            {
                Console.WriteLine("Got into loading xml");

                Triangle triangle = new Triangle();
                Shape[] list = new Shape[] { triangle };
                return list;
            }
            else // json
            {
                string jsonString = File.ReadAllText(fileName);
                var jsonData = JsonConvert.DeserializeObject<dynamic>(jsonString);

                try
                {
                    int dataLength = jsonData.Count;
                    Shape[] shapes = new Shape[dataLength];
                    int counter = 0;

                    foreach (var data in jsonData)
                    {
                        string name = data.Name;
                        int x = data.X;
                        int y = data.Y;
                        //Console.WriteLine("Name: " + name + " X: " + x + " Y: " + y);
                        shapes[counter] = createShape(name, x, y);
                        counter++;
                    }

                    return shapes;
                }
                catch
                {
                    throw new System.ArgumentException("There was an error parsing the json file.");
                }
            }
        }
    }
}

﻿
using Microsoft.VisualBasic.FileIO;
/**
circle, ellipse, triangle (equilateral, isosceles, or scalene),
square, rectangle, regular polygon, or convex polygon
**/
namespace Shapes
{
    class Strategize
    {
        public static void Main(string[] args)
        {
            // arg[0] is file type, arg[1] is name of file,
            string fileType = args[0].Split(".").Last();

            if (fileType == "xml" | fileType == "json")
            {
                generatefile(args[0], fileType);
            }
            else
            {
                Console.WriteLine("Please enter a valid file type.");
                System.Environment.Exit(1);
            }
        }

        public static void Output()
        {
            // Example of data output to CSV
            string data = "Col1, Col2, Col2";
            string filePath = @"File.csv";
            File.WriteAllText(filePath, data);
            string dataFromRead = File.ReadAllText(filePath);
            Console.WriteLine(dataFromRead);

            // https://stackoverflow.com/questions/39749136/how-do-i-create-a-csv-file-in-c-sharp
        }

        public static void generatefile(string filename, string fileType)
        {
            ShapeList shapeList = new ShapeList();

            if (fileType == "xml")
            {
                System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Shape));

                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + filename + ".xml";
                Console.WriteLine("File Path: " + path);
                System.IO.FileStream file = System.IO.File.Create(path);

                writer.Serialize(file, shapeList);
                file.Close();
            }
            else
            {
                Console.WriteLine("handle json");
                // TODO
            }
        }

        private class ShapeList
        {
            private readonly string[] shapeNames = new string[] { "circle", "non-circle", "rectangle", "square", "equillateral", "isosceles", "scalene" };
            private readonly string[] shapeClasses = new string[] { "Triangle", "Ellipse", "Rectangle" };
            public Shape[] shapes = new Shape[20];

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
                            int radius = rnd.Next(15);
                            Shape circle = new Ellipse("circle", radius, radius);
                            shapes[i] = circle;
                            break;

                        case "non-circle":
                            int x = rnd.Next(15);
                            int y = rnd.Next(15);
                            Shape non_circle = new Ellipse("non-circle", x, y);
                            shapes[i] = non_circle;
                            break;

                        case "rectangle":
                            int width = rnd.Next(15);
                            int height = rnd.Next(15);
                            Shape rectangle = new Rectangle("rectangle", width, height);
                            shapes[i] = rectangle;
                            break;

                        case "square":
                            int side = rnd.Next(15);
                            Shape square = new Rectangle("square", side, side);
                            shapes[i] = square;
                            break;

                        case "equillateral":
                            int base_e = rnd.Next(15);
                            int height_e = base_e;
                            Shape equillateral = new Triangle("equillateral", base_e, height_e);
                            shapes[i] = equillateral;
                            break;

                        case "isosceles":
                            int base_i = rnd.Next(15);
                            int height_i = rnd.Next(15);
                            Shape isosceles = new Triangle("isosceles", base_i, height_i);
                            shapes[i] = isosceles;
                            break;

                        case "scalene":
                            int base_s = rnd.Next(15);
                            int height_s = rnd.Next(15);
                            Shape scalene = new Triangle("scalene", base_s, height_s);
                            shapes[i] = scalene;
                            break;

                        default:
                            Console.WriteLine("There was an error with your switch statement when generating shape objects.");
                            break;

                    }
                }
            }

            public Shape[] getShapes()
            {
                return shapes;
            }
        }
    }
}

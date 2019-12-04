using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");

            List<IShape> shapes = new List<IShape>()
            {
                new Circle(4.0),
                new Rectangle(6, 7),
                new Square(5.0),
                new Circle(3.0),
                new Rectangle(2.0, 4.0),
                new Circle(3.5),
                new Square(10)
            };

            foreach(IShape shape in shapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }
            Console.WriteLine("---------------------");

            IEnumerable<IShape> filteredShapes = shapes.Where(shape => shape.Area > 50);
            foreach (IShape shape in filteredShapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }
            Console.WriteLine("---------------------");


            IEnumerable<Circle> circles;
            // Using is keyword
            circles = shapes.OfType<Circle>(); //iterates through the shapes looking for the ones that are circles, puts them in a new collection of circles
            IEnumerable<Circle> filteredCircles = shapes.OfType<Circle>().Where(circle => circle.Area < 30); //Function chaining
            foreach(Circle shape in filteredCircles) //foreach (Circle shape in circles.Where(circle => circle.Area < 30))
            {
                Console.WriteLine($"Circle with radius {shape.Radius} and Area {shape.Area}");
            }
            Console.WriteLine("---------------------");

            Console.WriteLine("Grouping By Area");
            var groupByArea = shapes.GroupBy(shape => shape.Area % 2 == 0);
            foreach(var group in groupByArea)
            {
                Console.WriteLine(group.Key ? "Evens" : "Odds");
                foreach(var shape in group)
                {
                    Console.WriteLine($"Shape with area {shape.Area}");
                }
            }
            Console.WriteLine("---------------------");

            Console.WriteLine("Group By Type");
            var groupByType = shapes.GroupBy(shape => shape.GetType());
            foreach(var group in groupByType)
            {
                Console.WriteLine($"Shapes of type {group.Key.Name}");
                foreach(var shape in group)
                {
                    Console.WriteLine($"{group.Key.Name} Shape with area {shape.Area}");
                }
            }
            Console.WriteLine("---------------------");

            Console.ReadKey();
        }
    }
}

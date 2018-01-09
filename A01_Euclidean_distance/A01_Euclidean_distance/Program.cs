using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A01_Euclidean_distance
{
    class Program
    {

        static void Main(string[] args)
        {


            List <double> l = new List<double>();
            List <Point> p = new List<Point>();
            l.Add(1.0);
            p.Add(new Point());
            // Beispiel Polygone, für die wir Ergebniss kennen.
            Point[] square_3x3 =
            {
                new Point(0, 0),
                new Point(3, 0),
                new Point(3, 3),
                new Point(0, 3),
            }; // Area 9, Perimeter: 12
            Point[] triangle_b2_h1 =
            {
                new Point(-1, 0),
                new Point(0, 1),
                new Point(1, 0),
            }; // Area 1, Perimeter: 4.8284
            Point[] triangle_b3_h5 =
            {
                new Point(-1.5, 0),
                new Point(0, 5),
                new Point(1.5, 0),
            }; // Area 7.5, Perimeter: 13.4403

            // 1. test
            testPolygon(new Polygon(square_3x3), 9.0, 12.0);
            testPolygon(new Polygon(triangle_b2_h1), 1.0, 4.8284);
            testPolygon(new Polygon(triangle_b3_h5), 7.5, 13.4403);

            // 2. Interactive mode
            string[] affirmative = new string[] { "YES", "Y", "JA", "J" };
            do
            {
                try
                {
                    calcPolygon(Polygon.readPolygon());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("There was an error reading your polygon.");
                }
                Console.Write("\nRead another polygon? (y/[n]) ");
            } while (affirmative.Contains(Console.ReadLine().ToUpperInvariant()));
            Console.Write("\nBye bye! ");
            Console.ReadLine();
        }

        private static void testPolygon(Polygon polygon, double area, double perimeter,
                                        double accuracy = 0.01)
        {
            double got_perimeter = polygon.calculatePerimeter();
            double got_area = polygon.calculateArea();

            if (Math.Abs(perimeter - got_perimeter) >= accuracy)
            {
                Console.WriteLine("ERROR: Perimeter function not working correctly (got {0} expected {1})",
                    got_perimeter, perimeter);
            }
            if (Math.Abs(area - got_area) >= accuracy)
            {
                Console.WriteLine("ERROR: Areas function not working correctly (got {0} expected {1})",
                    got_area, area);
            }
        }

        public static void calcPolygon(Polygon poly)
        {
            double perimeter = poly.calculatePerimeter();
            Console.WriteLine("Perimter: {0}", perimeter);
            double area = poly.calculateArea();
            Console.WriteLine("Area: {0}", area);
        }
        public static void calcPolygon(Point[] points)
        {
            Polygon poly = new Polygon(points);
            calcPolygon(poly);
        }
    }
}

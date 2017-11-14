using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace A01_Euclidean_distance
{
    class Program
    {
        static void Main(string[] args)
        {
            // Double: weil reele Zahlen
            double x1; double y1;
            double x2; double y2;

            while (true)
            {
                Console.Write("x1: ");
                x1 = readNumber();
                Console.Write("y1: ");
                y1 = readNumber();
                Console.Write("x2: ");
                x2 = readNumber();
                Console.Write("y2: ");
                y2 = readNumber();

                double distanceInput = distanceTwoPoints(x1, y1, x2, y2);
                Console.WriteLine(
                    string.Format("Distance is: {0}", distanceInput));
                Console.WriteLine();
            }
       }
        static double readNumber()
        {
            string line = Console.ReadLine().Replace(",", ".");
            return Convert.ToDouble(line, CultureInfo.InvariantCulture);
        }
        static double distanceTwoPoints(double x1, double y1, double x2, double y2)
        {
            double deltaX = (x2 - x1);
            double deltaY = (y2 - y1);

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            double distance2 = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

            return distance;
        }
    }
}

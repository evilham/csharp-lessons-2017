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
        static double readNumber()
        {
            string line = Console.ReadLine().Replace(",", ".");
            return Convert.ToDouble(line, CultureInfo.InvariantCulture);
        }
        static void Main(string[] args)
        {
            // Double: weil Realezahlen
            Console.Write("How many vertices does your polygon have? ");
            int n = Convert.ToInt32(Console.ReadLine());

            double[] X_v = new double[n];
            double[] Y_v = new double[n];

            for (int i = 0; i < n; ++i)
            {
                Console.Write("X{0}: ", i + 1);
                X_v[i] = readNumber();
                Console.Write("Y{0}: ", i + 1);
                Y_v[i] = readNumber();
            }

            double d_total = 0.0;

            for (int i = 0; i < n; ++i)
            {
                int j = (i + 1) % n;
                double d_i = distanceTwoPoints(X_v[i], Y_v[i],
                                               X_v[j], Y_v[j]);
                d_total += d_i;
            }
            Console.Write("Perimeter: {0}", d_total);
            Console.ReadLine();
        }
        static double distanceTwoPoints(double x1, double y1, double x2, double y2)
        {
            double deltaX = (x2 - x1);
            double deltaY = (y2 - y1);

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return distance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections;

namespace A01_Euclidean_distance
{
    class Polygon : IEnumerable
    {
        public List<Point> points = new List<Point>();

        public virtual string Name()
        {
            return "GenericPolygon";
        }

        #region "Constructors"
        /// <summary>
        /// Empty constructor, starts with an empty points list.
        /// </summary>
        public Polygon() { }
        /// <summary>
        /// Constructor that loads a point array into the points list.
        /// </summary>
        /// <param name="points">The points that define the polygon.</param>
        public Polygon(Point[] points)
        {
            this.points.AddRange(points);
            
            /*
            foreach (Point po in points)
            {
                this.points.Add(po);
            }
            */
        }
        #endregion
        #region "Calculations"
        public double calculatePerimeter()
        {
            return Polygon.calculatePerimeter(this.points.ToArray());
        }
        public static double calculatePerimeter(Point[] P_v)
        {
            int n = P_v.Length;

            double d_total = 0.0;

            for (int i = 0; i < n; ++i)
            {
                // j = i + 1 --> soll 0 sein, wenn i = n-1
                int j = (i + 1) % n;
                // 1. Variante:
                //    Wir denken nur an die Koordinaten
                /*
                double d_i = Point.distanceTwoPoints(P_v[i].X, P_v[i].Y,
                                                     P_v[j].X, P_v[j].Y);
                */
                // 2. Variante:
                //    Wir denken an "Point" Objekte:
                // double d_i = Point.distanceTwoPoints(P_v[i], P_v[j]);
                //
                // 3. Variante:
                //    Wir agieren direkt zwischen 2 Point Objekten
                double d_i = P_v[i].distanceTo(P_v[j]);
                d_total += d_i;
            }
            return d_total;
        }

        internal double calculateArea()
        {
            return Polygon.calculateArea(this.points.ToArray());
        }

        public static double calculateArea(Point[] P_v)
        {
            int n = P_v.Length;
            // Berechnung nach:
            // https://de.wikipedia.org/wiki/Polygon#Fl.C3.A4che
            double area = 0.0;
            for (int i = 0; i < n; ++i)
            {
                // j = i + 1 --> soll 0 sein, wenn i = n-1
                int j = (i + 1) % n;
                area += Math.Abs(P_v[i].X * P_v[j].Y - P_v[i].Y * P_v[j].X);
            }
            area /= 2.0;

            return area;
        }
        #endregion
        #region "I/O"
        public static Polygon readPolygon()
        {
            // Jetzt brauchen wir die tatsächliche Punkte
            Polygon poly = new Polygon();
            string suffix2 = "(empty to finish reading polygon)";
            for (int i = 1; ; ++i)
            {
                string suffix1 = i.ToString();
                Point po = Point.readPoint(
                    string.Format("{0} {1}", suffix1, suffix2),
                    suffix1);
                if (po == null)
                    break;
                //Point po = readPoint();
                poly.points.Add(po);
            }
            return poly;
        }
        #endregion

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Point>)points).GetEnumerator();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A01_Euclidean_distance
{
    class Triangle : Polygon
    {
        public Triangle() : base() { }
        public Triangle(Point[] points) : base(points) { }
        public override string Name()
        {
            return "Triangle";
        }
    }
}
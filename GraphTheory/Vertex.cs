using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GraphTheory
{
    public class Vertex
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vertex operator +(Vertex a) => a;
        public static Vertex operator +(Vertex a, Vertex b)
        {
            if (a == null && b == null)
            {
                return null;
            }
            else if (a == null && b != null)
            {
                return b;
            }
            else if (a != null && b == null)
            {
                return a;
            }
            else
            {
                return new Vertex(a.X + b.X, a.Y + b.Y);
            }
        }
        public static Vertex operator -(Vertex a)
        {
            if (a == null)
            {
                return null;
            }

            return new Vertex(-a.X, -a.Y);
        }
        public static Vertex operator -(Vertex a, Vertex b) => a + (-b);
        public static Vertex operator *(Vertex a, double b)
        {
            if (b == 0)
            {
                return null;
            }

            if (a == null)
            {
                return null;
            }

            return new Vertex(a.X * b, a.Y * b);
        }

        public static Vertex operator *(double b, Vertex a) => a * b;
        public static Vertex operator /(Vertex a, double b) => new Vertex(a.X / b, a.Y / b);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6Demo
{
    class Program
    {
        static void Main()
        {
        }
    }

    class Circle
    {
        public Point Centre
        {
            get { return _centre; }
        }

        private readonly Point _centre = new Point(0, 0);

        public double Radius
        {
            get { return _radius; }
        }

        private readonly double _radius = 1.0;

        public Circle()
        {
        }

        public Circle(Point centre, double radius)
        {
            if(centre==null)
                throw new ArgumentNullException("centre");
            this._centre = centre;
            this._radius = radius;
        }

        public static Circle FromDatabaseData(Point centre, double radius)
        {
            double x = 0, y = 0;
            if (centre != null)
            {
                x = centre.X;
                y = centre.Y;
            }
            return new Circle(new Point(x, y), radius);
        }

        public void Print(Action<string> printer)
        {
            printer(String.Format("Centre coordinates: {0}, Radius: {1}", _centre, _radius));
        }

        public double Area
        {
            get { return Math.PI * Math.Pow(this.Radius, 2); }
        }

        public bool Intersects(Circle otherCircle)
        {
            return
                Math.Sqrt(
                    Math.Pow((this.Centre.X - otherCircle.Centre.X), 2) +
                    Math.Pow((this.Centre.Y - otherCircle.Centre.Y), 2)) <= (this.Radius + otherCircle.Radius);
        }
    }

    class Point
    {
        private readonly double _x;
        private readonly double _y;

        public Point(double x, double y)
        {
            this._x = x;
            this._y = y;
        }

        public double X
        {
            get
            {
                return _x;
            }
        }
        public double Y
        {
            get
            {
                return _y;
            }
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", _x, _y);
        }
    }
}

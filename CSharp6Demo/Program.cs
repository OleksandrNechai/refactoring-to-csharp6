using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp6Demo
{
    class Program
    {
        private static void Main()
        {
            var circlesDictionary = new Dictionary<int, Circle>
            {
                {1, new Circle(centre: new Point(0, 0), radius: 1)},
                {2, new Circle(centre: new Point(2, 2), radius: 5)},
                {3, new Circle(centre: new Point(1, 2), radius: 2)}
            };

            try
            {
                circlesDictionary.Add(3, null);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("An item with the same key has already been added."))
                {
                    Console.WriteLine("Yes, we now we can not add same key twi");
                }
            }

            circlesDictionary
                .Select(c => c.Value.Area)
                .ToList()
                .ForEach(Console.WriteLine);
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
            if (centre == null)
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
        private readonly double _x;

        public double Y
        {
            get
            {
                return _y;
            }
        }
        private readonly double _y;

        public override string ToString()
        {
            return String.Format("({0},{1})", _x, _y);
        }
    }
}

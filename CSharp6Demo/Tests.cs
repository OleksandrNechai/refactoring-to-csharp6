using System;
using NUnit.Framework;

namespace CSharp6Demo
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void InitCircleWithNullRadiusThrows()
        {
            Assert.Throws<ArgumentNullException>(() => new Circle(null, 0));
        }
        [Test]
        public void CanConsttructDefaultCircuit()
        {
            var text = "";
            Action<string> printer = (input) => text = input;
            new Circle().Print(printer);
            Assert.That(text, Is.EqualTo("Centre coordinates: (0,0), Radius: 1"));
        }
        [Test]
        public void CanConsttructValidCircuit()
        {
            var text = "";
            Action<string> printer = (input) => text = input;
            new Circle(new Point(1,1), 1).Print(printer);
            Assert.That(text, Is.EqualTo("Centre coordinates: (1,1), Radius: 1"));
        }
        [Test]
        public void CanConsttructFromDatabaseWheninputNull()
        {
            var text = "";
            Action<string> printer = (input) => text = input;
            Circle.FromDatabaseData(null,1).Print(printer);
            Assert.That(text, Is.EqualTo("Centre coordinates: (0,0), Radius: 1"));
        }
        [Test]
        public void CanConsttructFromDatabaseWheninputNotNull()
        {
            var text = "";
            Action<string> printer = (input) => text = input;
            Circle.FromDatabaseData(new Point(1,1), 1).Print(printer);
            Assert.That(text, Is.EqualTo("Centre coordinates: (1,1), Radius: 1"));
        }
        [Test]
        public void MovingCircleToDefinedPoint()
        {
            var text = "";
            Action<string> printer = (input) => text = input;
            var c1 = new Circle(new Point(0, 0), 2);
            var c2 = new Circle(new Point(1, 1), 2);

            Assert.IsTrue(c1.Intersects(c2));
        }
        [Test]
        public void AreaCalculation()
        {
            var c = new Circle(new Point(0, 0), 1);
            Assert.That(c.Area,Is.EqualTo(Math.PI));
        }
    }
}

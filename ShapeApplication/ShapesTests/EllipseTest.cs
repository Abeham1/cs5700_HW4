using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{
    [TestClass]
    public class EllipseTest
    {
        [TestMethod]
        public void TestValidConstruction()
        {
            var ellipse = new Ellipse(new Point(1, 4), 7, 2);
            Assert.AreEqual(1, ellipse.point1.X);
            Assert.AreEqual(4, ellipse.point1.Y);
            Assert.AreEqual(7, ellipse.length);
            Assert.AreEqual(2, ellipse.width);

            ellipse = new Ellipse(new Point(45, 103), 89, 999);
            Assert.AreEqual(45, ellipse.point1.X);
            Assert.AreEqual(103, ellipse.point1.Y);
            Assert.AreEqual(89, ellipse.length);
            Assert.AreEqual(999, ellipse.width);
        }

        [TestMethod]
        public void TestInvalidConstruction()
        {
            try
            {
                new Ellipse(null, 0, 0);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid Shape!", e.Message);
            }

            try
            {
                new Ellipse(new Point(1, 2), -3, -5);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }
        }

        [TestMethod]
        public void TestMove()
        {
            Ellipse myEllipse = new Ellipse(new Point(1, 2), 5, 6);
            Assert.AreEqual(1, myEllipse.point1.X);
            Assert.AreEqual(2, myEllipse.point1.Y);
            Assert.AreEqual(5, myEllipse.length);
            Assert.AreEqual(6, myEllipse.width);

            myEllipse.Move(3, 4);
            Assert.AreEqual(4, myEllipse.point1.X);
            Assert.AreEqual(6, myEllipse.point1.Y);
            Assert.AreEqual(5, myEllipse.length);
            Assert.AreEqual(6, myEllipse.width);

            myEllipse.Move(-12, -26);
            Assert.AreEqual(-8, myEllipse.point1.X);
            Assert.AreEqual(-20, myEllipse.point1.Y);
            Assert.AreEqual(5, myEllipse.length);
            Assert.AreEqual(6, myEllipse.width);

        }

        [TestMethod]
        public void TestCaluculateArea()
        {
            Ellipse myEllipse = new Ellipse(new Point(1, 2), 5, 6);
            Assert.AreEqual(94.25, myEllipse.CalculateArea(), 1);
        }
    }
}

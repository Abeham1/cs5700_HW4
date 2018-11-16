using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{

    [TestClass]
    class TriangleTest
    {
        [TestMethod]
        public void TestValidConstruction()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(4, 0);
            var p3 = new Point(4, 5);



            var myTriangle = new Triangle(p1, p2, p3);

            Assert.AreSame(p1, myTriangle.point1);
            Assert.AreSame(p2, myTriangle.point2);
            Assert.AreSame(p3, myTriangle.point3);

            myTriangle = new Triangle(p1, p1, p3);
            Assert.AreSame(p1, myTriangle.point1);
            Assert.AreSame(p2, myTriangle.point2);
            Assert.AreSame(p3, myTriangle.point3);
        }

        [TestMethod]
        public void TestInvalidConstruction()
        {
            var p1 = new Point(1, 2);
            var p2 = new Point(4, 10);
            var p3 = new Point(9, 7);
            var p4 = new Point(12, 3);

            try
            {
                new Triangle(p1, null, null);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid point", e.Message);
            }

            try
            {
                new Triangle(null, p2, null);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid point", e.Message);
            }
        }

        [TestMethod]
        public void TestMove()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(4, 0);
            var p3 = new Point(4, 5);

            var myTriangle = new Triangle(p1, p2, p3);

            myTriangle.Move(3, 4);
            Assert.AreEqual(3, myTriangle.point1.X, 0);
            Assert.AreEqual(4, myTriangle.point1.Y, 0);
            Assert.AreEqual(7, myTriangle.point2.X, 0);
            Assert.AreEqual(4, myTriangle.point2.Y, 0);
            Assert.AreEqual(7, myTriangle.point3.X, 0);
            Assert.AreEqual(9, myTriangle.point3.Y, 0);

        }

        [TestMethod]
        public void TestComputeArea()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(4, 0);
            var p3 = new Point(4, 5);
            var myTriangle = new Triangle(p1, p2, p3);
        }


        [TestMethod]
        [ExpectedException(typeof(ShapeException),
            "Invalid triangle")]
        public void TestValidateLine()
        {
            var p1 = new Point(1, 2);
            var p2 = new Point(1, 2);
            var p3 = new Point(1, 2);

            var myTriangle = new Triangle(p1, p2, p3);
        }
    }
}
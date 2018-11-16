using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{
    /// <summary>
    /// Summary description for RectangleTest
    /// </summary>
    [TestClass]
    public class RectangleTest
    {
        public void TestValidConstruction()
        {
            var rectangle = new Rectangle(new Point(1, 4), 7, 2);
            Assert.AreEqual(1, rectangle.point1.X);
            Assert.AreEqual(4, rectangle.point1.Y);
            Assert.AreEqual(7, rectangle.length);
            Assert.AreEqual(2, rectangle.width);

            rectangle = new Rectangle(new Point(45, 103), 89, 999);
            Assert.AreEqual(45, rectangle.point1.X);
            Assert.AreEqual(103, rectangle.point1.Y);
            Assert.AreEqual(89, rectangle.length);
            Assert.AreEqual(999, rectangle.width);
        }

        [TestMethod]
        public void TestInvalidConstruction()
        {
            try
            {
                new Rectangle(new Point(1, 2), 1, -2);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid width!", e.Message);
            }

            try
            {
                new Rectangle(new Point(1, 2), -3, 5);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid length!", e.Message);
            }
        }

        [TestMethod]
        public void TestMove()
        {
            Rectangle rectangle = new Rectangle(new Point(1, 2), 5, 6);
            Assert.AreEqual(1, rectangle.point1.X);
            Assert.AreEqual(2, rectangle.point1.Y);
            Assert.AreEqual(5, rectangle.length);
            Assert.AreEqual(6, rectangle.width);

            rectangle.Move(3, 4);
            Assert.AreEqual(4, rectangle.point1.X);
            Assert.AreEqual(6, rectangle.point1.Y);
            Assert.AreEqual(5, rectangle.length);
            Assert.AreEqual(6, rectangle.width);

            rectangle.Move(-12, -26);
            Assert.AreEqual(-8, rectangle.point1.X);
            Assert.AreEqual(-20, rectangle.point1.Y);
            Assert.AreEqual(5, rectangle.length);
            Assert.AreEqual(6, rectangle.width);
        }

        [TestMethod]
        public void TestCaluculateArea()
        {
            Rectangle rectangle = new Rectangle(new Point(1, 2), 5, 6);
            Assert.AreEqual(30, rectangle.ComputeArea(), 1);
        }
    }
}

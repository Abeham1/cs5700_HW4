using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;
using System.Windows;

namespace ShapeApplication.Tests
{
    [TestClass()]
    public class ShapeAppTests
    {
        [TestMethod()]
        public void ShapeAppTestReadShape()
        {
            var sa = new ShapeApp();
            Shape newShape = sa.readShape("Circle,1,2,3");
            Assert.AreEqual("Circle", newShape.ShapeType);
            Assert.AreEqual(1, newShape.point1.X);
            Assert.AreEqual(2, newShape.point1.Y);
            Assert.AreEqual(3, newShape.length);

            newShape = sa.readShape("Triangle,1,2,3,4,5,6");
            Assert.AreEqual(1, newShape.point1.X);
            Assert.AreEqual(2, newShape.point1.Y);
            Assert.AreEqual(3, newShape.point2.X);
            Assert.AreEqual(4, newShape.point2.Y);
            Assert.AreEqual(5, newShape.point3.X);
            Assert.AreEqual(6, newShape.point3.Y);
        }
    }
}
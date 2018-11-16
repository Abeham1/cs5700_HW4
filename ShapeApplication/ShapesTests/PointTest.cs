using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{
    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void TestValidConstruction()
        {
            var p1 = new Point(1, 2);
            Assert.AreEqual(1, p1.X, 0);
            Assert.AreEqual(2, p1.Y, 0);

            p1 = new Point(1, 2);
            Assert.AreEqual(1, p1.X, 0);
            Assert.AreEqual(2, p1.Y, 0);
        }

        [TestMethod]
        public void TestInvalidConstruction()
        {
            try
            {
                new Point(1, -1);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }
            try
            {
                new Point(-1, 1);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }
        }

        [TestMethod]
        public void TestMoveX()
        {
            Point p1 = new Point(1, 2);

            p1.MoveX(10);
            Assert.AreEqual(11, p1.X, 0);
            Assert.AreEqual(2, p1.Y, 0);

            p1.MoveX(0);
            Assert.AreEqual(11, p1.X, 0);
            Assert.AreEqual(2, p1.Y, 0);

            p1.MoveX(-20);
            Assert.AreEqual(-8, p1.X, 0);
            Assert.AreEqual(2, p1.Y, 0);

            p1.MoveX(0);
            Assert.AreEqual(-8, p1.X, 0);
            Assert.AreEqual(2, p1.Y, 0);
        }

        [TestMethod]
        public void TestMoveY()
        {
            Point p1 = new Point(1, 2);

            p1.MoveY(10);
            Assert.AreEqual(1, p1.X, 0);
            Assert.AreEqual(12, p1.Y, 0);

            p1.MoveY(0);
            Assert.AreEqual(1, p1.X, 0);
            Assert.AreEqual(12, p1.Y, 0);

            p1.MoveY(-20);
            Assert.AreEqual(1, p1.X, 0);
            Assert.AreEqual(-7, p1.Y, 0);

            p1.MoveY(0);
            Assert.AreEqual(1, p1.X, 0);
            Assert.AreEqual(-7, p1.Y, 0);
        }

        [TestMethod]
        public void TestMove()
        {
            Point p1 = new Point(1, 2);

            p1.Move(10, 20);
            Assert.AreEqual(11, p1.X, 0);
            Assert.AreEqual(22, p1.Y, 0);

            p1.Move(0, 0);
            Assert.AreEqual(11, p1.X, 0);
            Assert.AreEqual(22, p1.Y, 0);

            p1.Move(0, 0);
            Assert.AreEqual(11, p1.X, 0);
            Assert.AreEqual(22, p1.Y, 0);

            p1.Move(-20, -30);
            Assert.AreEqual(-9, p1.X, 0);
            Assert.AreEqual(-8, p1.Y, 0);
        }

        [TestMethod]
        public void TestCopy()
        {
            Point p1 = new Point(123, 23);
            Assert.AreEqual(123, p1.X, 0);
            Assert.AreEqual(23, p1.Y, 0);

            Point p2 = p1.Copy();
            Assert.AreNotSame(p1, p2);
            Assert.AreEqual(p1.X, p2.X, 0);
            Assert.AreEqual(p1.Y, p2.Y, 0);
        }
    }
}

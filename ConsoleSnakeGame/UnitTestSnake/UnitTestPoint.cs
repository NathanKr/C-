using GameGeneric;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestSnake
{
    [TestClass]
    public class UnitTestPoint
    {
        [TestMethod]
        public void TestPointIsEqualTrue()
        {
            Point p1 = new Point(2,3);
            Point p2 = new Point(2,3);
            Assert.IsTrue(p1.IsEqual(p2));
        }

        [TestMethod]
        public void TestPointIsEqualFalseX()
        {
            Point p1 = new Point(1, 3);
            Point p2 = new Point(2, 3);
            Assert.IsFalse(p1.IsEqual(p2));
        }

        [TestMethod]
        public void TestPointIsEqualFalseY()
        {
            Point p1 = new Point(2, 4);
            Point p2 = new Point(2, 3);
            Assert.IsFalse(p1.IsEqual(p2));
        }
    }
}

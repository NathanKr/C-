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
            Point p1 = new Point { x = 2, y = 3 };
            Point p2 = new Point { x = 2, y = 3 };
            Assert.IsTrue(p1.IsEqual(p2));
        }

        [TestMethod]
        public void TestPointIsEqualFalseX()
        {
            Point p1 = new Point { x = 1, y = 3 };
            Point p2 = new Point { x = 2, y = 3 };
            Assert.IsFalse(p1.IsEqual(p2));
        }

        [TestMethod]
        public void TestPointIsEqualFalseY()
        {
            Point p1 = new Point { x = 2, y = 4 };
            Point p2 = new Point { x = 2, y = 3 };
            Assert.IsFalse(p1.IsEqual(p2));
        }
    }
}

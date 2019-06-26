using GameGeneric;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestSnake
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Point p1 = new Point(2,3);
            Point p2 = new Point(2, 3);
            Assert.IsTrue(p1.IsEqual(p2));
        }
    }
}

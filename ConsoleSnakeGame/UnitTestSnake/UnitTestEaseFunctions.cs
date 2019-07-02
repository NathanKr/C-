using ConsoleSnakeGame;
using GameGeneric;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestSnake
{
    [TestClass]
    public class UnitTestEaseFunctions
    {

        [TestMethod]
        public void TestBounceEaseOutStart()
        {
            double time = 0, startingValue = 20,
            valueOffset = 100, duration = 50;

            Assert.AreEqual(
                startingValue ,
                EaseFunctions.BounceEaseOut(time, startingValue, 
                valueOffset, duration));
        }

        [TestMethod]
        public void TestBounceEaseOutEnd()
        {
            double time = 50, positionPixelsStart = 20,
            poistionPixelsOffset = 100, duration = 50 , positionPixelsEnd;

            positionPixelsEnd = positionPixelsStart + poistionPixelsOffset;
            Assert.AreEqual(
                positionPixelsEnd,
                EaseFunctions.BounceEaseOut(time, positionPixelsStart, 
                poistionPixelsOffset, duration));
        }

    }
}

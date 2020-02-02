using System.Windows;
using NUnit.Framework;
using WpfApp3;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(0, 10);
            var angle = PointHelper.GetHorizontalAngle(p1,p2);
            Assert.That(angle, Is.EqualTo(90));
        }

        [Test]
        public void Test2()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 0);
            var angle = PointHelper.GetHorizontalAngle(p1,p2);
            Assert.That(angle, Is.EqualTo(0));
        }

        [Test]
        public void Test2_1()
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(-10, 0);
            var angle = PointHelper.GetHorizontalAngle(p1,p2);
            Assert.That(angle, Is.EqualTo(-180));
        }

        [Test]
        public void Test3()
        {
            var p1 = new Point(0, 10);
            var p2 = new Point(0, 0);
            var angle = PointHelper.GetHorizontalAngle(p1,p2);
            Assert.That(angle, Is.EqualTo(-90));
        }

        [Test]
        public void Test4()
        {
            var p1 = new Point(10, 0);
            var p2 = new Point(10, 10);
            var p3 = new Point(0, 10);
            var rectInfo = PointHelper.GetRectInfoFromPoints(p1, p2, p3);
            Assert.That(rectInfo.Angle, Is.EqualTo(90));
            Assert.That(rectInfo.Width, Is.EqualTo(10));
            Assert.That(rectInfo.Height, Is.EqualTo(10));
            Assert.That(rectInfo.InitialPoint.X, Is.EqualTo(0).Within(.001));
            Assert.That(rectInfo.InitialPoint.Y, Is.EqualTo(0));
        }

        [Test]
        public void Test5()
        {
            var p1 = new Point(5, 0);
            var p2 = new Point(5, 10);
            var p3 = new Point(0, 10);
            var rectInfo = PointHelper.GetRectInfoFromPoints(p1, p2, p3);
            Assert.That(rectInfo.Angle, Is.EqualTo(90));
            Assert.That(rectInfo.Width, Is.EqualTo(10));
            Assert.That(rectInfo.Height, Is.EqualTo(5));
            Assert.That(rectInfo.InitialPoint.X, Is.EqualTo(-2.5));
            Assert.That(rectInfo.InitialPoint.Y, Is.EqualTo(2.5).Within(.001));
        }
    }
}
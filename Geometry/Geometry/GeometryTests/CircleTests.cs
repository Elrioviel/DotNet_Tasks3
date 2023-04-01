using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Geometry;

namespace GeometryTests
{
    [TestFixture]
    class CircleTests
    {
        [TestCaseSource("CreatedCircleRadiusEqualExpectedTestCase")]
        public void TestCircle_CreatedRadiusEqualExpected(Circle circle, double radius)
        {
            Assert.AreEqual(circle.Radius, radius);
        }
        public static IEnumerable<TestCaseData> CreatedCircleRadiusEqualExpectedTestCase()
        {
            yield return new TestCaseData(Circle.Create(5), 5);
            yield return new TestCaseData(Circle.Create(6.29856), 6.29856);
            yield return new TestCaseData(Circle.Create(859), 859);
        }

        [TestCaseSource("CircleAreaTestCase")]
        public double TestCalculateCircleArea_ActualAreaReturnsExpected(Circle circle)
        {
            return circle.CalculateCircleArea(circle);
        }
        public static IEnumerable<TestCaseData> CircleAreaTestCase()
        {
            yield return new TestCaseData(Circle.Create(2)).Returns(12.566370614359172);
            yield return new TestCaseData(Circle.Create(6.29)).Returns(124.29428590589194);
            yield return new TestCaseData(Circle.Create(85)).Returns(22698.006922186254);
            yield return new TestCaseData(Circle.Create(74)).Returns(17203.361371057708);
            yield return new TestCaseData(Circle.Create(32)).Returns(3216.9908772759482);
            yield return new TestCaseData(Circle.Create(11)).Returns(380.13271108436493);
        }
    }
}

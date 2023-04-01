using NUnit.Framework;
using System;
using System.Collections.Generic;
using Geometry;

namespace GeometryTests
{
    [TestFixture]
    public class TriangleTests
    {
        [TestCaseSource("CreatedTriangleSidesEqualExpectedTestCase")]
        public void TestTriangle_CreatedSidesEqualExpected(Triangle triangle, double[] expectedSidesArray)
        {
            Double[] actualSidesArray = new double[] { triangle.FirstSide, triangle.SecondSide, triangle.ThirdSide };
            Assert.AreEqual(actualSidesArray, expectedSidesArray);
        }
        public static IEnumerable<TestCaseData> CreatedTriangleSidesEqualExpectedTestCase()
        {
            yield return new TestCaseData(Triangle.Create(5, 5, 5), new double[] { 5, 5, 5 });
            yield return new TestCaseData(Triangle.Create(6.8, 10, 7.22), new double[] { 6.8, 10, 7.22 });
        }

        [TestCaseSource("SideGreaterThanZeroTestCase")]
        public bool TestCheckSideValue_SideGreaterThanZero(double sideValue)
        {
            return Triangle.CheckSideValue(sideValue);
        }
        public static IEnumerable<TestCaseData> SideGreaterThanZeroTestCase()
        {
            yield return new TestCaseData(0).Returns(false);
            yield return new TestCaseData(0.1).Returns(true);
            yield return new TestCaseData(-1.01).Returns(false);
            yield return new TestCaseData(15).Returns(true);
        }
        [Test]
        public void TestCheckSidesValues_SidesValueZero_Failure()
        {
            double a = 0;
            double b = 0;
            double c = 0;

            bool triangleIsCorrect = Triangle.CheckSidesValues(a, b, c);

            Assert.IsFalse(triangleIsCorrect);
        }

        [TestCaseSource("TriangleIsNotRectangleTestCase")]
        public bool TestDetermineIfTriangle_TriangleIsNotRectangle(double a, double b, double c)
        {
            return Triangle.DetermineIfTriangle(a, b, c);
        }
        public static IEnumerable<TestCaseData> TriangleIsNotRectangleTestCase()
        {
            yield return new TestCaseData(4, 3, 5).Returns(false);
            yield return new TestCaseData(15, 15, 15).Returns(true);
            yield return new TestCaseData(0.12, 5.89, 9.34).Returns(true);
        }

        [TestCaseSource("TrianglePerimeterTestCase")]
        public double TestCalculateTrianglePerimeter_ReturnsExpected(double a, double b, double c)
        {
            Triangle triangle = Triangle.Create(a, b, c);
            return triangle.CalculateTrianglePerimeter(triangle);
        }
        public static IEnumerable<TestCaseData> TrianglePerimeterTestCase()
        {
            yield return new TestCaseData(5, 5, 5).Returns(15);
            yield return new TestCaseData(10, 15, 8).Returns(33);
            yield return new TestCaseData(9, 8, 7).Returns(24);
            yield return new TestCaseData(8, 8, 8).Returns(24);
        }

        [Test]
        public void TestCalculateTriangleArea_AllSidesAreFive_Success()
        {
            var triangle = Triangle.Create(5, 5, 5);

            double expected = 15;
            double actual = triangle.CalculateTrianglePerimeter(triangle);

            Assert.AreEqual(expected, actual);
        }
    }
}
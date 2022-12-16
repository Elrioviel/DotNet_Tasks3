using System;

namespace Geometry
{
    public class Triangle
    {
        const double minLength = 0;

        public double FirstSide;
        public double SecondSide;
        public double ThirdSide;
        private Triangle(double a, double b, double c)
        {
            FirstSide = a;
            SecondSide = b;
            ThirdSide = c;
        }

        public static bool CheckSideValue(double sideValue) => sideValue > minLength;

        public static bool CheckSidesValues(double a, double b, double c)
        {
            return CheckSideValue(a) && CheckSideValue(b) && CheckSideValue(c) && (a + b > c) && (a + c > b) && (b + c > a);
        }

        public static bool DetermineIfTriangle(double a, double b, double c)
        {
            return ((a * a) + b * b == c * c) ? false : true;
        }

        public static Triangle Create(double a, double b, double c)
        {
            if (CheckSidesValues(a, b, c))
            {
                Triangle triangle = new Triangle(a, b, c);
                return triangle;
            }
            else
            {
                throw new ArgumentException("Invalid sides' value(s)");
            }
        }

        public double CalculateTriangleArea(Triangle triangle)
        {
            double triangleSide = (triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide) / 2;
            return Math.Sqrt(triangleSide * (triangleSide - triangle.FirstSide) * (triangleSide - triangle.SecondSide) * (triangleSide - triangle.ThirdSide));
        }

        public double CalculateTrianglePerimeter(Triangle triangle) => triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide;
    }
}

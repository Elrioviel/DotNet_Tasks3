using System;

namespace Geometry
{
    public class Circle
    {
        const double minLength = 0;

        public double Radius;
        private Circle(double radius)
        {
            Radius = radius;
        }

        public static Circle Create(double radius)
        {
            if (radius > minLength)
            {
                Circle circle = new Circle(radius);
                return circle;
            }
            else
            {
                throw new ArgumentException("Invalid radius value");
            }
        }

        public double CalculateCircleArea(Circle circle) => Math.PI * circle.Radius * circle.Radius;
    }
}

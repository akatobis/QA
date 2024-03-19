using System;

namespace triangle
{
    public class Triangle
    {
        public Triangle(string[] args)
        {
            if (args.Length != 3)
            {
                ErrorMessage();
            }
            
            SidesTriangleToDouble(args[0], args[1], args[2]);
            if (!IsValidSides())
            {
                ErrorMessage();
            }
            
            if (!IsTriangle())
            {
                throw new ArgumentException("не треугольник");
            }
        }

        private double A { get; set; }
        private double B { get; set; }
        private double C { get; set; }
        private const double MaxSizeSide = 1000000;

        private void ErrorMessage()
        {
            throw new ArgumentException("неизвестная ошибка");
        }
        
        private double SideTriangleToDouble(string side)
        {
            if (!double.TryParse(side, out var sideDouble))
            {
                ErrorMessage();
            }

            return sideDouble;
        }

        private bool IsValidSides()
        {
            return (A > 0 && B > 0 && C > 0) && (A < MaxSizeSide && B < MaxSizeSide && C < MaxSizeSide);
        }
        
        private void SidesTriangleToDouble(string a, string b, string c)
        {
            A = SideTriangleToDouble(a);
            B = SideTriangleToDouble(b);
            C = SideTriangleToDouble(c);
        }

        private bool IsTriangle()
        {
            return !(A + B < C || A + C < B && B + C < A);
        }

        private bool IsEquilateral()
        {
            return (Math.Abs(A - B) < double.Epsilon && Math.Abs(B - C) < double.Epsilon);
        }

        private bool IsIsosceles()
        {
            return Math.Abs(A - B) < double.Epsilon || 
                   Math.Abs(C - B) < double.Epsilon ||
                   Math.Abs(A - C) < double.Epsilon;
        }

        public void WriteType()
        {
            if (IsEquilateral())
            {
                Console.WriteLine("равносторонний");
                return;
            }
            if (IsIsosceles())
            {
                Console.WriteLine("равнобедренный");
                return;
            }

            Console.WriteLine("обычный");
        }
    }
}
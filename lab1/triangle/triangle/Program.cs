using System;

namespace triangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var triangle = new Triangle(args);
                triangle.WriteType();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
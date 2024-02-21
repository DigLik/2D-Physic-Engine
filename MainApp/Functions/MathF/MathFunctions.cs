namespace Physics_Engine.MainApp.Functions.MathF
{
    public class MathFunctions
    {
        public static int GetRandomNumber(int min, int max)
        {
            return new Random().Next(min, max);
        }

        public static decimal GetHypotenuse(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            return (decimal)Math.Sqrt((double)((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)));
        }

        public static decimal GetHypotenuse(decimal x, decimal y)
        {
            return (decimal)Math.Sqrt((double)(x * x + y * y));
        }

        public static decimal GetAngle(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            return (decimal)Math.Atan2((double)(y2 - y1), (double)(x2 - x1));
        }

        public static decimal GetAngle(decimal x, decimal y)
        {
            return (decimal)Math.Atan2((double)y, (double)x);
        }
    }
}

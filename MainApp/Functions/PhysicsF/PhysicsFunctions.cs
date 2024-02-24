namespace Physics_Engine.MainApp.Functions.Physics
{
    public class PhysicsFunctions
    {
        public static decimal СollisionСalculation(decimal m1, decimal m2, decimal v1, decimal v2, decimal e)
        {
            return ((m2 - e * m1) * v1 + (1 + e) * m2 * v2) / (m1 + m2);
        }

        public static decimal GetGravityForce(decimal mass1, decimal mass2, decimal distance)
        {
            return (decimal)6.674e-11 * mass1 * mass2 / (distance * distance);
        }

        public static decimal GetForce(decimal mass, decimal acceleration)
        {
            return acceleration / mass;
        }
    }
}

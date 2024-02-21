namespace Physics_Engine.MainApp.Functions.Physics
{
    public class PhysicsFunctions
    {
        public static decimal GetGravitationalForce(decimal mass1, decimal mass2, decimal distance)
        {
            return (decimal)6.674e-11 * mass1 * mass2 / (distance * distance);
        }

        public static decimal GetForce(decimal mass, decimal acceleration)
        {
            return acceleration / mass;
        }
    }
}

using System.Windows.Media;

namespace Physics_Engine.MainApp.Objects
{
    public class Particle
    {
        public decimal radius;
        public decimal mass;
        public decimal x, y;
        public decimal vX, vY;
        public Color color;

        public Particle()
        {
            radius = DefaultConfigs.radius;
            mass = DefaultConfigs.mass;
            x = DefaultConfigs.x;
            y = DefaultConfigs.y;
            vX = DefaultConfigs.vX;
            vY = DefaultConfigs.vY;
            color = DefaultConfigs.color;
        }

        public void SetConfigs(decimal _radius, decimal _mass, decimal _x, decimal _y, decimal _vx, decimal _vy, Color _color)
        {
            radius = _radius;
            mass = _mass;
            x = _x;
            y = _y;
            vX = _vx;
            vY = _vy;
            color = _color;
        }
    }
}

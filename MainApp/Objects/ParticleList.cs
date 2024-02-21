using System.Windows.Media;

namespace Physics_Engine.MainApp.Objects
{
    public class ParticleList
    {
        public List<Particle> particles = [];

        public void AddParticle()
        {
            particles.Add(new Particle());
        }

        public void AddParticle(decimal radius, decimal mass, decimal x, decimal y, decimal vx, decimal vy, Color color)
        {
            var particle = new Particle();
            particle.SetConfigs(radius, mass, x, y, vx, vy, color);
            particles.Add(particle);
        }

        public int Count()
        {
            return particles.Count;
        }

        public decimal Radius(int i)
        {
            return particles[i].radius;
        }
        public void Radius(int i, decimal radius)
        {
            particles[i].radius = radius;
        }

        public decimal Mass(int i)
        {
            return particles[i].mass;
        }
        public void Mass(int i, decimal mass)
        {
            particles[i].mass = mass;
        }

        public decimal X(int i)
        {
            return particles[i].x;
        }
        public void X(int i, decimal x)
        {
            particles[i].x = x;
        }

        public decimal Y(int i)
        {
            return particles[i].y;
        }
        public void Y(int i, decimal y)
        {
            particles[i].y = y;
        }

        public decimal VX(int i)
        {
            return particles[i].vX;
        }
        public void VX(int i, decimal vx)
        {
            particles[i].vX = vx;
        }

        public decimal VY(int i)
        {
            return particles[i].vY;
        }
        public void VY(int i, decimal vy)
        {
            particles[i].vY = vy;
        }

        public Color Color(int i)
        {
            return particles[i].color;
        }
        public void Color(int i, Color color)
        {
            particles[i].color = color;
        }
    }
}

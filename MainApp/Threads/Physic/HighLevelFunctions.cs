using Physics_Engine.MainApp.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Physics_Engine.MainApp.Threads.Physic
{
    public class HLFunc
    {
        public static decimal Hypotenuse(Particle p1, Particle p2)
        {
            return (decimal)Math.Sqrt((double)((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y)));
        }
        public static decimal Hypotenuse(Particle p)
        {
            return (decimal)Math.Sqrt((double)(p.x * p.x + p.y * p.y));
        }

        public static decimal Angle(Particle p1, Particle p2)
        {
            return (decimal)Math.Atan2((double)(p2.y - p1.y), (double)(p2.x - p1.x));
        }
        public static decimal Angle(Particle p)
        {
            return (decimal)Math.Atan2((double)p.y, (double)p.x);
        }

        public static decimal GravityForce(Particle p1, Particle p2)
        {
            return PhysicConfigs.G * p1.mass * p2.mass / (decimal)Math.Pow((double)Hypotenuse(p1, p2), 2);
        }
    }
}

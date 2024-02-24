using Physics_Engine.MainApp.Functions.MathF;
using Physics_Engine.MainApp.Graphics;
using Physics_Engine.MainApp.Objects;
using Physics_Engine.MainApp.Threads;
using Physics_Engine.MainApp.Threads.Physic;

using static Physics_Engine.MainApp.Objects.DefaultConfigs;

namespace Physics_Engine.MainApp.Main
{
    internal class Startup
    {
        public static ParticleList list = new();
        [STAThread]
        public static void Main()
        {
            for (int i = 0; i < count; i++)
            {
                list.AddParticle(radius, mass,
                    MathFunctions.GetRandomNumber((int)(0 + DefaultConfigs.radius), (int)(GraphicConfigs.WindowWidth - DefaultConfigs.radius)),
                    MathFunctions.GetRandomNumber((int)(0 + DefaultConfigs.radius), (int)(GraphicConfigs.WindowHeight - DefaultConfigs.radius)),
                    vX, vY, color);
            }
            PhysicThread.Start();
            GraphicThread.Start();
        }
    }
}

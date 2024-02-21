using Physics_Engine.MainApp.Functions.MathF;
using Physics_Engine.MainApp.Graphics;
using Physics_Engine.MainApp.Objects;
using Physics_Engine.MainApp.Threads;
using Physics_Engine.MainApp.Threads.Physic;
using System.Windows.Media;

namespace Physics_Engine.MainApp.Main
{
    internal class Startup
    {
        public static ParticleList list = new();
        [STAThread]
        public static void Main()
        {
            for (int i = 0; i < 10; i++)
            {
                list.AddParticle(10, (decimal)10e4,
                    MathFunctions.GetRandomNumber(0, GraphicConfigs.WindowWidth),
                    MathFunctions.GetRandomNumber(0, GraphicConfigs.WindowHeight),
                    0, 0, Colors.White);
            }
            PhysicThread.Start();
            GraphicThread.Start();
        }
    }
}

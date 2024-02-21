using Physics_Engine.MainApp.Graphics;
using Physics_Engine.MainApp.Main;
using System.Windows.Threading;

namespace Physics_Engine.MainApp.Threads.Physic
{
    public class PhysicThread
    {
        public static void Start()
        {
            DispatcherTimer Ftimer = new();
            Ftimer.Interval = TimeSpan.FromMilliseconds(1000 / PhysicConfigs.TPS);
            Ftimer.Tick += (sender, args) =>
            {
                for (int i = 0; i < Startup.list.Count(); i++)
                {
                    if (Startup.list.particles[i].x > GraphicConfigs.WindowWidth + Startup.list.particles[i].radius)
                    {
                        Startup.list.particles[i].x = 0 - Startup.list.particles[i].radius;
                    } else
                    {
                        Startup.list.particles[i].x += 5;
                    }
                }
            };
            Ftimer.Start();
        }
    }
}

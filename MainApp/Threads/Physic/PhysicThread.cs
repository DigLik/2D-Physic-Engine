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
                    Startup.list.particles[i].x += 1;
                }
            };
            Ftimer.Start();
        }
    }
}

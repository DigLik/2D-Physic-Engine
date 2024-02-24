using System.Windows.Threading;
using static Physics_Engine.MainApp.Functions.Physics.PhysicsFunctions;
using static Physics_Engine.MainApp.Main.Startup;
using static Physics_Engine.MainApp.Threads.GraphicThread;
using static Physics_Engine.MainApp.Threads.Physic.HLFunc;
using static Physics_Engine.MainApp.Threads.Physic.PhysicConfigs;

namespace Physics_Engine.MainApp.Threads.Physic
{
    public class PhysicThread
    {
        public static void Start()
        {
            DispatcherTimer Ftimer = new();
            Ftimer.Interval = TimeSpan.FromMilliseconds(TPS);
            Ftimer.Tick += (sender, args) =>
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    for (int j = 0; j < list.Count(); j++)
                    {
                        if (i != j)
                        {
                            if (Hypotenuse(list.particles[i], list.particles[j]) > list.Radius(i) + list.Radius(j))
                            {
                                decimal force = GravityForce(list.particles[j], list.particles[i]) * DeltaTime;
                                decimal angle = Angle(list.particles[j], list.particles[i]);
                                decimal vx = force * (decimal)Math.Cos((double)angle) / list.particles[i].mass * DeltaTime;
                                decimal vy = force * (decimal)Math.Sin((double)angle) / list.particles[i].mass * DeltaTime;

                                list.VX(i, list.VX(i) + vx);
                                list.VY(i, list.VY(i) + vy);
                                list.X(i, list.X(i) - list.VX(i));
                                list.Y(i, list.Y(i) - list.VY(i));
                            }
                            else
                            {
                                list.X(i, list.X(i) - list.VX(i));
                                list.Y(i, list.Y(i) - list.VY(i));
                                list.X(j, list.X(j) - list.VX(j));
                                list.Y(j, list.Y(j) - list.VY(j));

                                decimal difference = list.Radius(i) + list.Radius(j) - Hypotenuse(list.particles[i], list.particles[j]);
                                decimal angle = Angle(list.particles[j], list.particles[i]);
                                list.X(i, list.X(i) + difference * (decimal)Math.Cos((double)angle));
                                list.Y(i, list.Y(i) + difference * (decimal)Math.Sin((double)angle));

                                list.VX(i, СollisionСalculation(list.Mass(i), list.Mass(j), list.VX(i), list.VX(j), e));
                                list.VY(i, СollisionСalculation(list.Mass(i), list.Mass(j), list.VY(i), list.VY(j), e));
                                list.VX(j, СollisionСalculation(list.Mass(j), list.Mass(i), list.VX(j), list.VX(i), e));
                                list.VY(j, СollisionСalculation(list.Mass(j), list.Mass(i), list.VY(j), list.VY(i), e));
                            }

                            if (list.X(i) < 0 + list.Radius(i))
                            {
                                list.X(i, list.Radius(i));
                                list.VX(i, -list.VX(i));
                            }
                            if (list.X(i) > (decimal)canvas.ActualWidth - list.Radius(i))
                            {
                                list.X(i, (decimal)canvas.ActualWidth - list.Radius(i));
                                list.VX(i, -list.VX(i));
                            }
                            if (list.Y(i) < 0 + list.Radius(i))
                            {
                                list.Y(i, list.Radius(i));
                                list.VY(i, -list.VY(i));
                            }
                            if (list.Y(i) > (decimal)canvas.ActualHeight - list.Radius(i))
                            {
                                list.Y(i, (decimal)canvas.ActualHeight - list.Radius(i));
                                list.VY(i, -list.VY(i));
                            }
                        }
                    }
                }
            };
            Ftimer.Start();
        }
    }
}

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
                for (int q = 0; q < list.Count(); q++)
                {
                    for (int w = q; w < list.Count(); w++)
                    {
                        int i = q;
                        int j = w;
                        if (j < i)
                        {
                            continue;
                        }
                        if (i != j)
                        {
                            if (Hypotenuse(list.particles[i], list.particles[j]) > list.Radius(i) + list.Radius(j))
                            {
                                decimal force = GravityForce(list.particles[j], list.particles[i]) * DeltaTime;
                                decimal angle = Angle(list.particles[j], list.particles[i]);
                                decimal vx = force * (decimal)Math.Cos((double)angle) / list.particles[i].mass;
                                decimal vy = force * (decimal)Math.Sin((double)angle) / list.particles[i].mass;

                                list.VX(i, list.VX(i) + vx);
                                list.VY(i, list.VY(i) + vy);
                                list.X(i, list.X(i) - list.VX(i));
                                list.Y(i, list.Y(i) - list.VY(i));
                            }
                            else
                            {
                                decimal difference = list.Radius(i) + list.Radius(j) - Hypotenuse(list.particles[i], list.particles[j]);
                                decimal angle = Angle(list.particles[j], list.particles[i]);
                                list.X(i, list.X(i) + difference * (decimal)Math.Cos((double)angle));
                                list.Y(i, list.Y(i) + difference * (decimal)Math.Sin((double)angle));

                                /*list.VX(i, СollisionСalculation(list.Mass(i), list.Mass(j), list.VX(i), list.VX(j), e));
                                list.VY(i, СollisionСalculation(list.Mass(i), list.Mass(j), list.VY(i), list.VY(j), e));
                                list.VX(j, СollisionСalculation(list.Mass(j), list.Mass(i), list.VX(j), list.VX(i), e));
                                list.VY(j, СollisionСalculation(list.Mass(j), list.Mass(i), list.VY(j), list.VY(i), e));*/

                                decimal dx = list.X(j) - list.X(i);
                                decimal dy = list.Y(j) - list.Y(i);

                                decimal distance = (decimal)Math.Sqrt((double)(dx * dx + dy * dy));

                                decimal nx = dx / distance;
                                decimal ny = dy / distance;

                                decimal dvx = list.VX(j) - list.VX(i);
                                decimal dvy = list.VY(j) - list.VY(i);

                                decimal VAN = dvx * nx + dvy * ny;

                                if (VAN <= 0)
                                {
                                    decimal impulse = (-2 * VAN) / (list.particles[i].mass + list.particles[j].mass);

                                    list.VX(i, list.VX(i) - impulse * nx * list.particles[j].mass);
                                    list.VY(i, list.VY(i) - impulse * ny * list.particles[j].mass);
                                    list.VX(j, list.VX(j) + impulse * nx * list.particles[i].mass);
                                    list.VY(j, list.VY(j) + impulse * ny * list.particles[i].mass);
                                }

                                list.X(i, list.X(i) - list.VX(i));
                                list.Y(i, list.Y(i) - list.VY(i));
                                list.X(j, list.X(j) - list.VX(j));
                                list.Y(j, list.Y(j) - list.VY(j));

                                /*
                                double dx = object2.x - object1.x;
                                double dy = object2.y - object1.y;

                                double distance = Math.Sqrt(dx * dx + dy * dy);

                                double nx = dx / distance;
                                double ny = dy / distance;

                                double dvx = object2.vx - object1.vx;
                                double dvy = object2.vy - object1.vy;

                                double VAN = dvx * nx + dvy * ny;

                                if (VAN <= 0)
                                {
                                    double impulse = (-2 * VAN) / (object1.m + object2.m);

                                    impulse *= 1;

                                    object1.vx -= impulse * nx * object2.m;
                                    object1.vy -= impulse * ny * object2.m;
                                    object2.vx += impulse * nx * object1.m;
                                    object2.vy += impulse * ny * object1.m;
                                */
                            }
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
            };
            Ftimer.Start();
        }
    }
}

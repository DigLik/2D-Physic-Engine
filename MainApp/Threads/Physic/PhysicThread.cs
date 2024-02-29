using System.Windows.Threading;
using static Physics_Engine.MainApp.Main.Startup;
using static Physics_Engine.MainApp.Threads.Physic.HLFunc;
using static Physics_Engine.MainApp.Threads.Physic.PhysicConfigs;

namespace Physics_Engine.MainApp.Threads.Physic
{
    public class PhysicThread
    {
        public static void Start()
        {
            DispatcherTimer Ftimer = new()
            {
                Interval = TimeSpan.FromMilliseconds(TPS)
            };
            Ftimer.Tick += (sender, args) =>
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    for (int j = i + 1; j < list.Count(); j++)
                    {
                        if (Hypotenuse(list.particles[i], list.particles[j]) <= list.Radius(i) + list.Radius(j))
                        {
                            decimal difference = list.Radius(i) + list.Radius(j) - Hypotenuse(list.particles[i], list.particles[j]);
                            decimal angle = Angle(list.particles[j], list.particles[i]);
                            list.X(i, list.X(i) + difference / 2 * (decimal)Math.Cos((double)angle));
                            list.Y(i, list.Y(i) + difference / 2 * (decimal)Math.Sin((double)angle));
                            list.X(j, list.X(j) - difference / 2 * (decimal)Math.Cos((double)angle));
                            list.Y(j, list.Y(j) - difference / 2 * (decimal)Math.Sin((double)angle));

                            decimal dx = list.particles[j].x - list.particles[i].x;
                            decimal dy = list.particles[j].y - list.particles[i].y;

                            decimal distance = (decimal)Math.Sqrt((double)(dx * dx + dy * dy));

                            decimal nx = dx / distance;
                            decimal ny = dy / distance;

                            decimal dvx = list.particles[j].vX - list.particles[i].vX;
                            decimal dvy = list.particles[j].vY - list.particles[i].vY;

                            decimal VAN = dvx * nx + dvy * ny;

                            if (VAN <= 0)
                            {
                                decimal e = (decimal)0.9;
                                decimal impulse = (-2 * VAN) / (list.particles[i].mass + list.particles[j].mass);
                                impulse *= e;

                                list.particles[i].vX -= impulse * list.particles[j].mass * nx;
                                list.particles[i].vY -= impulse * list.particles[j].mass * ny;
                                list.particles[j].vX += impulse * list.particles[i].mass * nx;
                                list.particles[j].vY += impulse * list.particles[i].mass * ny;
                            }
                        }
                        else
                        {
                            decimal force = GravityForce(list.particles[i], list.particles[j]);
                            decimal distance = Hypotenuse(list.particles[i], list.particles[j]);
                            decimal angle = Angle(list.particles[i], list.particles[j]);

                            list.particles[i].vX += (force / list.particles[i].mass) * (decimal)Math.Cos((double)angle) * DeltaTime;
                            list.particles[i].vY += (force / list.particles[i].mass) * (decimal)Math.Sin((double)angle) * DeltaTime;
                            list.particles[j].vX -= (force / list.particles[j].mass) * (decimal)Math.Cos((double)angle) * DeltaTime;
                            list.particles[j].vY -= (force / list.particles[j].mass) * (decimal)Math.Sin((double)angle) * DeltaTime;
                        }

                        list.particles[i].x += list.particles[i].vX * DeltaTime;
                        list.particles[i].y += list.particles[i].vY * DeltaTime;
                        list.particles[j].x += list.particles[j].vX * DeltaTime;
                        list.particles[j].y += list.particles[j].vY * DeltaTime;
                    }
                }
                for (int i = 0; i < list.Count(); i++)
                {
                    if (list.X(i) < list.Radius(i))
                    {
                        list.X(i, list.Radius(i));
                        list.VX(i, -list.VX(i));
                    }
                    if (list.X(i) > (decimal)GraphicThread.canvas.ActualWidth - list.Radius(i))
                    {
                        list.X(i, (decimal)GraphicThread.canvas.ActualWidth - list.Radius(i));
                        list.VX(i, -list.VX(i));
                    }
                    if (list.Y(i) < list.Radius(i))
                    {
                        list.Y(i, list.Radius(i));
                        list.VY(i, -list.VY(i));
                    }
                    if (list.Y(i) > (decimal)GraphicThread.canvas.ActualHeight - list.Radius(i))
                    {
                        list.Y(i, (decimal)GraphicThread.canvas.ActualHeight - list.Radius(i));
                        list.VY(i, -list.VY(i));
                    }
                }
            };
            Ftimer.Start();
        }
    }
}

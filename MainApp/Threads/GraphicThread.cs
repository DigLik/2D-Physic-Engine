using Physics_Engine.MainApp.Graphics;
using Physics_Engine.MainApp.Main;
using Physics_Engine.MainApp.Objects;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Physics_Engine.MainApp.Threads
{
    public class GraphicThread
    {
        public static ParticleList list = new();

        public static void Start()
        {
            Application app = new();
            app.ShutdownMode = ShutdownMode.OnMainWindowClose;
            CreateWindow mainWindow = new();

            Canvas canvas = new()
            {
                Width = GraphicConfigs.WindowWidth,
                Height = GraphicConfigs.WindowHeight,
                Background = Brushes.Black
            };

            mainWindow.Content = canvas;

            DispatcherTimer Gtimer = new();
            Gtimer.Interval = TimeSpan.FromMilliseconds(1000 / GraphicConfigs.FPS);
            Gtimer.Tick += (sender, args) =>
            {
                DrawFunctions.ClearCanvas(canvas);
                for (int i = 0; i < Startup.list.Count(); i++)
                {
                    DrawFunctions.DrawCircle(canvas, Startup.list.Radius(i),
                        Startup.list.X(i), Startup.list.Y(i), Startup.list.Color(i));
                }
            };
            Gtimer.Start();

            app.Run(mainWindow);
        }
    }
}

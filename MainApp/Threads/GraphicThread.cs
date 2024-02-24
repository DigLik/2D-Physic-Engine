using Physics_Engine.MainApp.Graphics;
using Physics_Engine.MainApp.Main;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Physics_Engine.MainApp.Threads
{
    public class GraphicThread
    {
        public static Canvas canvas = new()
        {
            Background = Brushes.Black,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Stretch
        };

        public static void Start()
        {
            Application app = new();
            app.ShutdownMode = ShutdownMode.OnMainWindowClose;
            CreateWindow mainWindow = new();


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

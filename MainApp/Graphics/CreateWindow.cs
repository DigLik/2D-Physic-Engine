using Physics_Engine.MainApp.Objects;
using Physics_Engine.MainApp.Threads.Physic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using static Physics_Engine.MainApp.Graphics.GraphicConfigs;
using static Physics_Engine.MainApp.Main.Startup;
using static Physics_Engine.MainApp.Objects.DefaultConfigs;

namespace Physics_Engine.MainApp.Graphics
{
    public class CreateWindow : Window
    {
        public CreateWindow()
        {
            Title = WindowTitle;
            Width = WindowWidth;
            Height = WindowHeight;
            WindowStyle = WindowStyle.ThreeDBorderWindow;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //ResizeMode = WindowResizable ? ResizeMode.CanResize : ResizeMode.NoResize;
            Background = new SolidColorBrush(GraphicConfigs.color);
            MouseDown += Window_MouseDown;
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            list.AddParticle(radius, mass, (decimal)e.GetPosition(this).X, (decimal)e.GetPosition(this).Y, 0, 0, DefaultConfigs.color);
        }
        public void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    list.particles.Clear();
                }
            }
            if (e.Key == Key.PageUp)
            {
                PhysicConfigs.DeltaTime *= 2;
            }
            if (e.Key == Key.PageDown)
            {
                PhysicConfigs.DeltaTime /= 2;
            }
        }
    }
}

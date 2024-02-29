using Physics_Engine.MainApp.Graphics;
using Physics_Engine.MainApp.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using static Physics_Engine.MainApp.Main.Startup;

namespace Physics_Engine.MainApp.Threads.Events
{
    public class Mouse
    {
        public Mouse(Window targetWindow)
        {
            targetWindow.MouseDown += OnMouseDown;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var window = sender as Window;
            if (window != null)
            {
                Point position = e.GetPosition(window);
                MessageBox.Show($"Координаты нажатия: X={position.X}, Y={position.Y}");
            }
        }
    }
}

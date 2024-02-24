using System.Windows;
using System.Windows.Media;

using static Physics_Engine.MainApp.Graphics.GraphicConfigs;

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
        }



        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

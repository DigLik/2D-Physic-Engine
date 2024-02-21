using System.Windows;
using System.Windows.Media;

namespace Physics_Engine.MainApp.Graphics
{
    public class CreateWindow : Window
    {
        public CreateWindow()
        {
            SizeToContent = SizeToContent.WidthAndHeight;
            Title = GraphicConfigs.WindowTitle;
            Width = GraphicConfigs.WindowWidth;
            Height = GraphicConfigs.WindowHeight;
            WindowStyle = WindowStyle.ThreeDBorderWindow;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //ResizeMode = GraphicConfigs.WindowResizable ? ResizeMode.CanResize : ResizeMode.NoResize;
            Background = new SolidColorBrush(GraphicConfigs.color);
        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

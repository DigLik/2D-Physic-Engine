using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Physics_Engine.MainApp.Graphics
{
    internal class DrawFunctions
    {
        public static void ClearCanvas(Canvas canvas)
        {
            canvas.Children.Clear();
        }

        public static void DrawCircle(Canvas canvas, decimal radius, decimal x, decimal y, Color color)
        {
            var circle = new Ellipse
            {
                Fill = new SolidColorBrush(color),
                Width = (double)radius * 2,
                Height = (double)radius * 2
            };

            Canvas.SetLeft(circle, (double)(x - radius));
            Canvas.SetTop(circle, (double)(y - radius));
            canvas.Children.Add(circle);
        }
    }
}

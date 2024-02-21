using System.Windows.Media;
using Windows.Devices.I2c.Provider;

namespace Physics_Engine.MainApp.Objects
{
    public class DefaultConfigs
    {
        public static decimal radius = 10;
        public static decimal mass = (decimal)10e4;
        public static decimal x = 0, y = 0;
        public static decimal vX = 0, vY = 0;
        public static Color color = Colors.White;
    }
}

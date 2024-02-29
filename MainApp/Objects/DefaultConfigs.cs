using System.Windows.Media;
using Windows.Devices.I2c.Provider;

namespace Physics_Engine.MainApp.Objects
{
    public class DefaultConfigs
    {
        public static int count = 0;
        public static decimal radius = (decimal)5;
        public static decimal mass = (decimal)10e0;
        public static decimal x = 0, y = 0;
        public static decimal vX = 0, vY = 0;
        public static Color color = Colors.White;
    }
}

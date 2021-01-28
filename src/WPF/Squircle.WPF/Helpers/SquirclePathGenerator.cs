using System.Windows.Media;

namespace Squircle.WPF.Helpers
{
    internal static class SquirclePathGenerator
    {
        public static PathGeometry GetGeometry(double width = 100, double height = 100, double curvature = 1) =>
            PathGeometry.CreateFromGeometry(Geometry.Parse(SquircleGenerator.GetGeometry(width, height, curvature)));
    }
}
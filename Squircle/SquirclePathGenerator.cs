using System.Globalization;
using System.Text;
using System.Windows.Media;

namespace Squircle
{
    internal static class SquirclePathGenerator
    {
        public static PathGeometry GetGeometry(double w = 100, double h = 100, double curvature = 1)
        {
            var curveWidth = (w / 2) * (1 - curvature);
            var curveHeight = (h / 2) * (1 - curvature);

            StringBuilder path = new();

            path.Append(string.Format(CultureInfo.InvariantCulture, "M 0, {0}", h / 2))
                .Append(string.Format(CultureInfo.InvariantCulture, "C 0, {0} {1}, 0 {2}, 0", curveWidth, curveHeight,
                    w / 2))
                .Append(string.Format(CultureInfo.InvariantCulture, "S {0}, {1} {2}, {3}", w, curveHeight, w, h / 2))
                .Append(string.Format(CultureInfo.InvariantCulture, "S {0}, {1} {2}, {3}", w - curveWidth, h - 0, w / 2,
                    h))
                .Append(string.Format(CultureInfo.InvariantCulture, "S 0, {0} 0, {1}", w - curveHeight, h / 2));

            var geometry = PathGeometry.CreateFromGeometry(Geometry.Parse(path.ToString()));

            return geometry;
        }
    }
}
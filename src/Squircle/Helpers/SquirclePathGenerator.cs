using System.Globalization;
using System.Text;
using System.Windows.Media;

namespace Squircle.Helpers
{
    public static class SquirclePathGenerator
    {
        public static PathGeometry GetGeometry(double w = 100, double h = 100, double curvature = 1)
        {
            var curveWidth = (w / 2) * (1 - curvature);
            var curveHeight = (h / 2) * (1 - curvature);

            StringBuilder path = new();

            path.Append(GetStartPoint(0, h / 2))
                .Append(GetBezierSegment(0, curveWidth, curveHeight, 0, w / 2, 0))
                .Append(GetShortBezierSegment(w, curveHeight, w, h / 2))
                .Append(GetShortBezierSegment(w - curveWidth, h - 0, w / 2, h))
                .Append(GetShortBezierSegment(0, w - curveHeight, 0, h / 2));

            var geometry = PathGeometry.CreateFromGeometry(Geometry.Parse(path.ToString()));

            return geometry;
        }

        private static string GetStartPoint(double x, double y)
            => string.Format(CultureInfo.InvariantCulture, "M {0}, {1}", x, y);

        private static string GetShortBezierSegment(double x1, double y1, double x, double y)
            => string.Format(CultureInfo.InvariantCulture, "S {0}, {1} {2}, {3}", x1, y1, x, y);

        private static string GetBezierSegment(double x1, double y1, double x2, double y2, double x, double y)
            => string.Format(CultureInfo.InvariantCulture, "C {0}, {1} {2}, {3} {4}, {5}", x1, y1, x2, y2, x, y);
    }
}
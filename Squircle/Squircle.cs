using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Squircle
{
    public class Squircle : Border
    {
        #region Private Fields

        private GeometryDrawing _drawing;

        #endregion

        #region Dependency Properties

        public static readonly DependencyProperty CurvatureProperty = DependencyProperty.Register(
            nameof(Curvature), typeof(double), typeof(Squircle), new PropertyMetadata(1.0, CurvatureChanged));

        private static void CurvatureChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Squircle squircle && e.OldValue is double oldValue && e.NewValue is double newValue)
                squircle.CurvatureChanged(oldValue, newValue);
        }

        #endregion

        #region Public Properties

        public double Curvature
        {
            get => (double) GetValue(CurvatureProperty);
            set => SetValue(CurvatureProperty, value);
        }

        #endregion

        #region Constructor

        public Squircle()
        {
            _drawing = new GeometryDrawing(Brushes.Green, null, SquirclePathGenerator.GetGeometry());

            OpacityMask =
                new DrawingBrush(_drawing);
        }

        #endregion

        #region Private Methods

        private void CurvatureChanged(double oldValue, double newValue)
        {
            if (newValue < 0 || newValue > 1)
            {
                Curvature = oldValue;

                return;
            }

            _drawing.Geometry = SquirclePathGenerator.GetGeometry(curvature: Curvature);
        }

        #endregion
    }
}
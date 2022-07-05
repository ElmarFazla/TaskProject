using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace TaskProject.Common.Components
{
    internal class HorizontalSeparator : SKCanvasView
    {
        /// <summary>
        /// Attached property for <seealso cref="LineColor" />
        /// </summary>
        public static BindableProperty LineColorProperty =
            BindableProperty.Create(nameof(LineColor), typeof(Color), typeof(HorizontalSeparator), Color.White, propertyChanged: OnColorChanged);

        public HorizontalSeparator()
        {
            HeightRequest = 1;
        }

        /// <summary>
        /// Gets or sets Line Color
        /// </summary>
        public Color LineColor
        {
            get
            {
                return (Color)GetValue(LineColorProperty);
            }

            set
            {
                SetValue(LineColorProperty, value);
            }
        }

        private static void OnColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is SKCanvasView skCanvasView)
            {
                skCanvasView.InvalidateSurface();
            }
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            if (Parent != null)
            {
                PaintSurface += OnPaintSurface;
            }
            else
            {
                PaintSurface -= OnPaintSurface;
            }
        }

        protected virtual void Draw(SKCanvas canvas, SKImageInfo info)
        {
            canvas.Clear();

            using (SKPaint lineColorPaint = new SKPaint { Style = SKPaintStyle.Stroke, Color = LineColor.ToSKColor(), StrokeWidth = 5, StrokeCap = SKStrokeCap.Butt })
            {
                canvas.DrawLine(0, 0, canvas.DeviceClipBounds.Width, 0, lineColorPaint);
            }
        }

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            Draw(e.Surface.Canvas, e.Info);
        }
    }
}
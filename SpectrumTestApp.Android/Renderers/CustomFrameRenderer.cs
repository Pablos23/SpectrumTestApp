using Android.Content;
using Android.Graphics.Drawables;
using SpectrumTestApp.Controls;
using SpectrumTestApp.Droid.Renderers;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FrameRenderer = Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace SpectrumTestApp.Droid.Renderers
{
    /// <summary>
    /// CustomFrameRenderer
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer" />
    public class CustomFrameRenderer : FrameRenderer
    {
        public CustomFrameRenderer(Context context)
            : base(context)
        {
        }

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Frame}"/> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null && Control != null)
            {
                UpdateCornerRadius();
            }
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(CustomFrame.CornerRadius) ||
                e.PropertyName == nameof(CustomFrame))
            {
                UpdateCornerRadius();
            }
        }

        private void UpdateCornerRadius()
        {
            if (Control.Background is GradientDrawable backgroundGradient)
            {
                var cornerRadius = (Element as CustomFrame)?.CornerRadius;
                if (!cornerRadius.HasValue)
                {
                    return;
                }

                var topLeftCorner = Context.ToPixels(cornerRadius.Value.TopLeft);
                var topRightCorner = Context.ToPixels(cornerRadius.Value.TopRight);
                var bottomLeftCorner = Context.ToPixels(cornerRadius.Value.BottomLeft);
                var bottomRightCorner = Context.ToPixels(cornerRadius.Value.BottomRight);

                var cornerRadii = new[]
                {
                    topLeftCorner,
                    topLeftCorner,

                    topRightCorner,
                    topRightCorner,

                    bottomRightCorner,
                    bottomRightCorner,

                    bottomLeftCorner,
                    bottomLeftCorner,
                };

                backgroundGradient.SetCornerRadii(cornerRadii);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SpectrumTestApp.Controls
{
    /// <summary>
    /// CustomFrame
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Frame" />
    public class CustomFrame : Frame
    {
        /// <summary>
        /// The corner radius property
        /// </summary>
        public static new readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CustomFrame), typeof(CornerRadius), typeof(CustomFrame));

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFrame"/> class.
        /// </summary>
        public CustomFrame()
        {
            base.CornerRadius = 0;
            base.HasShadow = false;
        }

        /// <summary>
        /// Gets or sets the corner radius of the frame.
        /// </summary>
        /// <value>
        /// To be added.
        /// </value>
        /// <remarks>
        /// To be added.
        /// </remarks>
        public new CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}

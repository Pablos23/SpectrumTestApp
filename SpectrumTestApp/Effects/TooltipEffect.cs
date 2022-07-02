using System.Linq;
using Xamarin.Forms;

namespace SpectrumTestApp.Effects
{
    /// <summary>
    /// TooltipPosition
    /// </summary>
    public enum TooltipPosition
    {
        Top,
        Bottom,
        Left,
        Right
    }

    /// <summary>
    /// TooltipEffect
    /// </summary>
    public static class TooltipEffect
    {

        /// <summary>
        /// The has tooltip property
        /// </summary>
        public static readonly BindableProperty HasTooltipProperty =
          BindableProperty.CreateAttached("HasTooltip", typeof(bool), typeof(TooltipEffect), false, propertyChanged: OnHasTooltipChanged);
        /// <summary>
        /// The text color property
        /// </summary>
        public static readonly BindableProperty TextColorProperty =
          BindableProperty.CreateAttached("TextColor", typeof(Color), typeof(TooltipEffect), Color.White);
        /// <summary>
        /// The background color property
        /// </summary>
        public static readonly BindableProperty BackgroundColorProperty =
          BindableProperty.CreateAttached("BackgroundColor", typeof(Color), typeof(TooltipEffect), Color.Black);
        /// <summary>
        /// The text property
        /// </summary>
        public static readonly BindableProperty TextProperty =
          BindableProperty.CreateAttached("Text", typeof(string), typeof(TooltipEffect), string.Empty);
        /// <summary>
        /// The position property
        /// </summary>
        public static readonly BindableProperty PositionProperty =
          BindableProperty.CreateAttached("Position", typeof(TooltipPosition), typeof(TooltipEffect), TooltipPosition.Bottom);

        /// <summary>
        /// Gets the has tooltip.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public static bool GetHasTooltip(BindableObject view)
        {
            return (bool)view.GetValue(HasTooltipProperty);
        }

        /// <summary>
        /// Sets the has tooltip.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetHasTooltip(BindableObject view, bool value)
        {
            view.SetValue(HasTooltipProperty, value);
        }

        /// <summary>
        /// Gets the color of the text.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public static Color GetTextColor(BindableObject view)
        {
            return (Color)view.GetValue(TextColorProperty);
        }

        /// <summary>
        /// Sets the color of the text.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="value">The value.</param>
        public static void SetTextColor(BindableObject view, Color value)
        {
            view.SetValue(TextColorProperty, value);
        }

        /// <summary>
        /// Gets the color of the background.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public static Color GetBackgroundColor(BindableObject view)
        {
            return (Color)view.GetValue(BackgroundColorProperty);
        }

        /// <summary>
        /// Sets the color of the background.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="value">The value.</param>
        public static void SetBackgroundColor(BindableObject view, Color value)
        {
            view.SetValue(BackgroundColorProperty, value);
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public static string GetText(BindableObject view)
        {
            return (string)view.GetValue(TextProperty);
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="value">The value.</param>
        public static void SetText(BindableObject view, string value)
        {
            view.SetValue(TextProperty, value);
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public static TooltipPosition GetPosition(BindableObject view)
        {
            return (TooltipPosition)view.GetValue(PositionProperty);
        }

        /// <summary>
        /// Sets the position.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="value">The value.</param>
        public static void SetPosition(BindableObject view, TooltipPosition value)
        {
            view.SetValue(PositionProperty, value);
        }


        /// <summary>
        /// Called when [has tooltip changed].
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        static void OnHasTooltipChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            if (view == null)
            {
                return;
            }

            bool hasTooltip = (bool)newValue;
            if (hasTooltip)
            {
                view.Effects.Add(new ControlTooltipEffect());
            }
            else
            {
                var toRemove = view.Effects.FirstOrDefault(e => e is ControlTooltipEffect);
                if (toRemove != null)
                {
                    view.Effects.Remove(toRemove);
                }
            }
        }
    }

    /// <summary>
    /// ControlTooltipEffect
    /// </summary>
    /// <seealso cref="Xamarin.Forms.RoutingEffect" />
    class ControlTooltipEffect : RoutingEffect
    {
        public ControlTooltipEffect() : base("CrossGeeks.TooltipEffect")
        {

        }
    }
}

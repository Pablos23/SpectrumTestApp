using System;
using Android.Views;
using Com.Tomergoldst.Tooltips;
using SpectrumTestApp.Droid.Effects;
using SpectrumTestApp.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Com.Tomergoldst.Tooltips.ToolTipsManager;

[assembly: ResolutionGroupName("CrossGeeks")]
[assembly: ExportEffect(typeof(DroidTooltipEffect), nameof(TooltipEffect))]
namespace SpectrumTestApp.Droid.Effects
{
    /// <summary>
    /// DroidTooltipEffect
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.PlatformEffect" />
    public class DroidTooltipEffect : PlatformEffect
    {
        ToolTip toolTipView;
        ToolTipsManager _toolTipsManager;
        ITipListener listener;

        /// <summary>
        /// Initializes a new instance of the <see cref="DroidTooltipEffect"/> class.
        /// </summary>
        public DroidTooltipEffect()
        {
            listener = new TipListener();
            _toolTipsManager = new ToolTipsManager(listener);
        }

        /// <summary>
        /// Called when [tap].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void OnTap(object sender, EventArgs e)
        {
            var control = Control ?? Container;

            var text = TooltipEffect.GetText(Element);

            if (!string.IsNullOrEmpty(text))
            {
                ToolTip.Builder builder;
                var parentContent = control.RootView;

                var position = TooltipEffect.GetPosition(Element);
                switch (position)
                {
                    case TooltipPosition.Top:
                        builder = new ToolTip.Builder(control.Context, control, parentContent as ViewGroup, text.PadRight(80, ' '), ToolTip.PositionAbove);
                        break;
                    case TooltipPosition.Left:
                        builder = new ToolTip.Builder(control.Context, control, parentContent as ViewGroup, text.PadRight(80, ' '), ToolTip.PositionLeftTo);
                        break;
                    case TooltipPosition.Right:
                        builder = new ToolTip.Builder(control.Context, control, parentContent as ViewGroup, text.PadRight(80, ' '), ToolTip.PositionRightTo);
                        break;
                    default:
                        builder = new ToolTip.Builder(control.Context, control, parentContent as ViewGroup, text.PadRight(80, ' '), ToolTip.PositionBelow);
                        break;
                }

                builder.SetAlign(ToolTip.AlignLeft);
                builder.SetBackgroundColor(TooltipEffect.GetBackgroundColor(Element).ToAndroid());
                builder.SetTextColor(TooltipEffect.GetTextColor(Element).ToAndroid());

                toolTipView = builder.Build();

                _toolTipsManager?.Show(toolTipView);
            }

        }


        /// <summary>
        /// Method that is called after the effect is attached and made valid.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAttached()
        {
            var control = Control ?? Container;
            control.Click += OnTap;
        }


        /// <summary>
        /// Method that is called after the effect is detached and invalidated.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnDetached()
        {
            var control = Control ?? Container;
            control.Click -= OnTap;
            _toolTipsManager.FindAndDismiss(control);
        }

        /// <summary>
        /// TipListener
        /// </summary>
        /// <seealso cref="Java.Lang.Object" />
        /// <seealso cref="Com.Tomergoldst.Tooltips.ToolTipsManager.ITipListener" />
        class TipListener : Java.Lang.Object, ITipListener
        {
            public void OnTipDismissed(Android.Views.View p0, int p1, bool p2)
            {

            }
        }
    }
}
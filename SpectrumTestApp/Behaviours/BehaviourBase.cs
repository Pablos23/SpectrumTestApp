using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SpectrumTestApp.Behaviours
{
    /// <summary>
    /// BehaviorBase.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Xamarin.Forms.Behavior{T}" />
    public class BehaviorBase<T> : Behavior<T> where T : BindableObject
    {
        /// <summary>
        /// Gets the associated object.
        /// </summary>
        /// <value>
        /// The associated object.
        /// </value>
        public T AssociatedObject { get; private set; }

        /// <summary>
        /// Attaches to the superclass and then calls the <see cref="M:Xamarin.Forms.Behavior`1.OnAttachedTo(`0)" /> method on this object.
        /// </summary>
        /// <param name="bindable">The bindable object to which the behavior was attached.</param>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;

            if (bindable.BindingContext != null)
                BindingContext = bindable.BindingContext;

            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        /// <summary>
        /// Calls the <see cref="M:Xamarin.Forms.Behavior`1.OnDetachingFrom(`0)" /> method and then detaches from the superclass.
        /// </summary>
        /// <param name="bindable">The bindable object from which the behavior was detached.</param>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnDetachingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            AssociatedObject = null;
        }

        /// <summary>
        /// Called when [binding context changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        /// <summary>
        /// Override this method to execute an action when the BindingContext changes.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}

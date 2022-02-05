using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using MauiReactor.Animations;
//using MauiReactor.Shapes;
using MauiReactor.Internals;

namespace MauiReactor.Compatibility
{
    public partial interface ILayout : IView
    {
        PropertyValue<bool>? IsClippedToBounds { get; set; }
        PropertyValue<bool>? CascadeInputTransparent { get; set; }
        PropertyValue<Microsoft.Maui.Thickness>? Padding { get; set; }

        Action? LayoutChangedAction { get; set; }
        Action<object?, EventArgs>? LayoutChangedActionWithArgs { get; set; }

    }
    public abstract partial class Layout<T> : View<T>, ILayout where T : Microsoft.Maui.Controls.Compatibility.Layout, new()
    {
        protected Layout()
        {

        }

        protected Layout(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? ILayout.IsClippedToBounds { get; set; }
        PropertyValue<bool>? ILayout.CascadeInputTransparent { get; set; }
        PropertyValue<Microsoft.Maui.Thickness>? ILayout.Padding { get; set; }

        Action? ILayout.LayoutChangedAction { get; set; }
        Action<object?, EventArgs>? ILayout.LayoutChangedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            Validate.EnsureNotNull(NativeControl);
            var thisAsILayout = (ILayout)this;
            SetPropertyValue(NativeControl, Microsoft.Maui.Controls.Compatibility.Layout.IsClippedToBoundsProperty, thisAsILayout.IsClippedToBounds);
            SetPropertyValue(NativeControl, Microsoft.Maui.Controls.Compatibility.Layout.CascadeInputTransparentProperty, thisAsILayout.CascadeInputTransparent);
            SetPropertyValue(NativeControl, Microsoft.Maui.Controls.Compatibility.Layout.PaddingProperty, thisAsILayout.Padding);


            base.OnUpdate();

            OnEndUpdate();
        }


        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            Validate.EnsureNotNull(NativeControl);

            var thisAsILayout = (ILayout)this;
            if (thisAsILayout.LayoutChangedAction != null || thisAsILayout.LayoutChangedActionWithArgs != null)
            {
                NativeControl.LayoutChanged += NativeControl_LayoutChanged;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_LayoutChanged(object? sender, EventArgs e)
        {
            var thisAsILayout = (ILayout)this;
            thisAsILayout.LayoutChangedAction?.Invoke();
            thisAsILayout.LayoutChangedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            if (NativeControl != null)
            {
                NativeControl.LayoutChanged -= NativeControl_LayoutChanged;
            }

            base.OnDetachNativeEvents();
        }

    }


    public static partial class LayoutExtensions
    {
        public static T IsClippedToBounds<T>(this T layout, bool isClippedToBounds) where T : ILayout
        {
            layout.IsClippedToBounds = new PropertyValue<bool>(isClippedToBounds);
            return layout;
        }

        public static T IsClippedToBounds<T>(this T layout, Func<bool> isClippedToBoundsFunc) where T : ILayout
        {
            layout.IsClippedToBounds = new PropertyValue<bool>(isClippedToBoundsFunc);
            return layout;
        }



        public static T CascadeInputTransparent<T>(this T layout, bool cascadeInputTransparent) where T : ILayout
        {
            layout.CascadeInputTransparent = new PropertyValue<bool>(cascadeInputTransparent);
            return layout;
        }

        public static T CascadeInputTransparent<T>(this T layout, Func<bool> cascadeInputTransparentFunc) where T : ILayout
        {
            layout.CascadeInputTransparent = new PropertyValue<bool>(cascadeInputTransparentFunc);
            return layout;
        }



        public static T Padding<T>(this T layout, Microsoft.Maui.Thickness padding) where T : ILayout
        {
            layout.Padding = new PropertyValue<Microsoft.Maui.Thickness>(padding);
            return layout;
        }

        public static T Padding<T>(this T layout, Func<Microsoft.Maui.Thickness> paddingFunc) where T : ILayout
        {
            layout.Padding = new PropertyValue<Microsoft.Maui.Thickness>(paddingFunc);
            return layout;
        }
        public static T Padding<T>(this T layout, double leftRight, double topBottom) where T : ILayout
        {
            layout.Padding = new PropertyValue<Microsoft.Maui.Thickness>(new Thickness(leftRight, topBottom));
            return layout;
        }
        public static T Padding<T>(this T layout, double uniformSize) where T : ILayout
        {
            layout.Padding = new PropertyValue<Microsoft.Maui.Thickness>(new Thickness(uniformSize));
            return layout;
        }




        public static T OnLayoutChanged<T>(this T layout, Action layoutChangedAction) where T : ILayout
        {
            layout.LayoutChangedAction = layoutChangedAction;
            return layout;
        }

        public static T OnLayoutChanged<T>(this T layout, Action<object?, EventArgs> layoutChangedActionWithArgs) where T : ILayout
        {
            layout.LayoutChangedActionWithArgs = layoutChangedActionWithArgs;
            return layout;
        }
    }
}
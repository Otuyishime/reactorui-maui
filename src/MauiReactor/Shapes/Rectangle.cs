// <auto-generated />
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using MauiReactor.Animations;
using MauiReactor.Shapes;
using MauiReactor.Internals;

#nullable enable
namespace MauiReactor.Shapes
{
    public partial interface IRectangle : Shapes.IShape
    {
        PropertyValue<double>? RadiusX { get; set; }

        PropertyValue<double>? RadiusY { get; set; }
    }

    public sealed partial class Rectangle : Shapes.Shape<Microsoft.Maui.Controls.Shapes.Rectangle>, IRectangle
    {
        public Rectangle()
        {
        }

        public Rectangle(Action<Microsoft.Maui.Controls.Shapes.Rectangle?> componentRefAction) : base(componentRefAction)
        {
        }

        PropertyValue<double>? IRectangle.RadiusX { get; set; }

        PropertyValue<double>? IRectangle.RadiusY { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();
            Validate.EnsureNotNull(NativeControl);
            var thisAsIRectangle = (IRectangle)this;
            SetPropertyValue(NativeControl, Microsoft.Maui.Controls.Shapes.Rectangle.RadiusXProperty, thisAsIRectangle.RadiusX);
            SetPropertyValue(NativeControl, Microsoft.Maui.Controls.Shapes.Rectangle.RadiusYProperty, thisAsIRectangle.RadiusY);
            base.OnUpdate();
            OnEndUpdate();
        }

        protected override void OnAnimate()
        {
            Validate.EnsureNotNull(NativeControl);
            var thisAsIRectangle = (IRectangle)this;
            SetPropertyValue(NativeControl, Microsoft.Maui.Controls.Shapes.Rectangle.RadiusXProperty, thisAsIRectangle.RadiusX);
            SetPropertyValue(NativeControl, Microsoft.Maui.Controls.Shapes.Rectangle.RadiusYProperty, thisAsIRectangle.RadiusY);
            base.OnAnimate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();
    }

    public static partial class RectangleExtensions
    {
        public static T RadiusX<T>(this T rectangle, double radiusX, RxDoubleAnimation? customAnimation = null)
            where T : IRectangle
        {
            rectangle.RadiusX = new PropertyValue<double>(radiusX);
            rectangle.AppendAnimatable(Microsoft.Maui.Controls.Shapes.Rectangle.RadiusXProperty, customAnimation ?? new RxDoubleAnimation(radiusX), v => rectangle.RadiusX = new PropertyValue<double>(v.CurrentValue()));
            return rectangle;
        }

        public static T RadiusX<T>(this T rectangle, Func<double> radiusXFunc)
            where T : IRectangle
        {
            rectangle.RadiusX = new PropertyValue<double>(radiusXFunc);
            return rectangle;
        }

        public static T RadiusY<T>(this T rectangle, double radiusY, RxDoubleAnimation? customAnimation = null)
            where T : IRectangle
        {
            rectangle.RadiusY = new PropertyValue<double>(radiusY);
            rectangle.AppendAnimatable(Microsoft.Maui.Controls.Shapes.Rectangle.RadiusYProperty, customAnimation ?? new RxDoubleAnimation(radiusY), v => rectangle.RadiusY = new PropertyValue<double>(v.CurrentValue()));
            return rectangle;
        }

        public static T RadiusY<T>(this T rectangle, Func<double> radiusYFunc)
            where T : IRectangle
        {
            rectangle.RadiusY = new PropertyValue<double>(radiusYFunc);
            return rectangle;
        }
    }
}
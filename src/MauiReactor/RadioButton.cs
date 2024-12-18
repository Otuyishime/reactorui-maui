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
namespace MauiReactor;
public partial interface IRadioButton : ITemplatedView
{
    object? Value { get; set; }

    object? IsChecked { get; set; }

    object? GroupName { get; set; }

    object? TextColor { get; set; }

    object? CharacterSpacing { get; set; }

    object? TextTransform { get; set; }

    object? FontAttributes { get; set; }

    object? FontFamily { get; set; }

    object? FontSize { get; set; }

    object? FontAutoScalingEnabled { get; set; }

    object? BorderColor { get; set; }

    object? CornerRadius { get; set; }

    object? BorderWidth { get; set; }

    Action? CheckedChangedAction { get; set; }

    Action<object?, CheckedChangedEventArgs>? CheckedChangedActionWithArgs { get; set; }
}

public partial class RadioButton<T> : TemplatedView<T>, IRadioButton where T : Microsoft.Maui.Controls.RadioButton, new()
{
    public RadioButton()
    {
        RadioButtonStyles.Default?.Invoke(this);
    }

    public RadioButton(Action<T?> componentRefAction) : base(componentRefAction)
    {
        RadioButtonStyles.Default?.Invoke(this);
    }

    object? IRadioButton.Value { get; set; }

    object? IRadioButton.IsChecked { get; set; }

    object? IRadioButton.GroupName { get; set; }

    object? IRadioButton.TextColor { get; set; }

    object? IRadioButton.CharacterSpacing { get; set; }

    object? IRadioButton.TextTransform { get; set; }

    object? IRadioButton.FontAttributes { get; set; }

    object? IRadioButton.FontFamily { get; set; }

    object? IRadioButton.FontSize { get; set; }

    object? IRadioButton.FontAutoScalingEnabled { get; set; }

    object? IRadioButton.BorderColor { get; set; }

    object? IRadioButton.CornerRadius { get; set; }

    object? IRadioButton.BorderWidth { get; set; }

    Action? IRadioButton.CheckedChangedAction { get; set; }

    Action<object?, CheckedChangedEventArgs>? IRadioButton.CheckedChangedActionWithArgs { get; set; }

    internal override void Reset()
    {
        base.Reset();
        var thisAsIRadioButton = (IRadioButton)this;
        thisAsIRadioButton.Value = null;
        thisAsIRadioButton.IsChecked = null;
        thisAsIRadioButton.GroupName = null;
        thisAsIRadioButton.TextColor = null;
        thisAsIRadioButton.CharacterSpacing = null;
        thisAsIRadioButton.TextTransform = null;
        thisAsIRadioButton.FontAttributes = null;
        thisAsIRadioButton.FontFamily = null;
        thisAsIRadioButton.FontSize = null;
        thisAsIRadioButton.FontAutoScalingEnabled = null;
        thisAsIRadioButton.BorderColor = null;
        thisAsIRadioButton.CornerRadius = null;
        thisAsIRadioButton.BorderWidth = null;
        thisAsIRadioButton.CheckedChangedAction = null;
        thisAsIRadioButton.CheckedChangedActionWithArgs = null;
        OnReset();
    }

    partial void OnReset();
    protected override void OnUpdate()
    {
        OnBeginUpdate();
        Validate.EnsureNotNull(NativeControl);
        var thisAsIRadioButton = (IRadioButton)this;
        SetPropertyValue(NativeControl, Microsoft.Maui.Controls.RadioButton.ValueProperty, thisAsIRadioButton.Value);
        SetPropertyValue(NativeControl, Microsoft.Maui.Controls.RadioButton.IsCheckedProperty, thisAsIRadioButton.IsChecked);
        SetPropertyValue(NativeControl, Microsoft.Maui.Controls.RadioButton.GroupNameProperty, thisAsIRadioButton.GroupName);
        SetPropertyValue(NativeControl, Microsoft.Maui.Controls.RadioButton.TextColorProperty, thisAsIRadioButton.TextColor);
        SetPropertyValue(NativeControl, Microsoft.Maui.Controls.RadioButton.CharacterSpacingProperty, thisAsIRadioButton.CharacterSpacing);
        SetPropertyValue(NativeControl, Microsoft.Maui.Controls.RadioButton.TextTransformProperty, thisAsIRadioButton.TextTransform);
        SetPropertyValue(NativeControl, Microsoft.Maui.Controls.RadioButton.FontAttributesProperty, thisAsIRadioButton.FontAttributes);
        SetPropertyValue(NativeControl, Microsoft.Maui.Controls.RadioButton.FontFamilyProperty, thisAsIRadioButton.FontFamily);
        SetPropertyValue(NativeControl, Microsoft.Maui.Controls.RadioButton.FontSizeProperty, thisAsIRadioButton.FontSize);
        SetPropertyValue(NativeControl, Microsoft.Maui.Controls.RadioButton.FontAutoScalingEnabledProperty, thisAsIRadioButton.FontAutoScalingEnabled);
        SetPropertyValue(NativeControl, Microsoft.Maui.Controls.RadioButton.BorderColorProperty, thisAsIRadioButton.BorderColor);
        SetPropertyValue(NativeControl, Microsoft.Maui.Controls.RadioButton.CornerRadiusProperty, thisAsIRadioButton.CornerRadius);
        SetPropertyValue(NativeControl, Microsoft.Maui.Controls.RadioButton.BorderWidthProperty, thisAsIRadioButton.BorderWidth);
        base.OnUpdate();
        OnEndUpdate();
    }

    partial void OnBeginUpdate();
    partial void OnEndUpdate();
    partial void OnBeginAnimate();
    partial void OnEndAnimate();
    protected override void OnThemeChanged()
    {
        if (ThemeKey != null && RadioButtonStyles.Themes.TryGetValue(ThemeKey, out var styleAction))
        {
            styleAction(this);
        }

        base.OnThemeChanged();
    }

    partial void OnAttachingNativeEvents();
    partial void OnDetachingNativeEvents();
    protected override void OnAttachNativeEvents()
    {
        Validate.EnsureNotNull(NativeControl);
        var thisAsIRadioButton = (IRadioButton)this;
        if (thisAsIRadioButton.CheckedChangedAction != null || thisAsIRadioButton.CheckedChangedActionWithArgs != null)
        {
            NativeControl.CheckedChanged += NativeControl_CheckedChanged;
        }

        OnAttachingNativeEvents();
        base.OnAttachNativeEvents();
    }

    private void NativeControl_CheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        var thisAsIRadioButton = (IRadioButton)this;
        thisAsIRadioButton.CheckedChangedAction?.Invoke();
        thisAsIRadioButton.CheckedChangedActionWithArgs?.Invoke(sender, e);
    }

    protected override void OnDetachNativeEvents()
    {
        if (NativeControl != null)
        {
            NativeControl.CheckedChanged -= NativeControl_CheckedChanged;
        }

        OnDetachingNativeEvents();
        base.OnDetachNativeEvents();
    }
}

public partial class RadioButton : RadioButton<Microsoft.Maui.Controls.RadioButton>
{
    public RadioButton()
    {
    }

    public RadioButton(Action<Microsoft.Maui.Controls.RadioButton?> componentRefAction) : base(componentRefAction)
    {
    }
}

public static partial class RadioButtonExtensions
{
    static object? SetCharacterSpacing(object radioButton, RxAnimation animation) => ((IRadioButton)radioButton).CharacterSpacing = ((RxDoubleAnimation)animation).CurrentValue();
    static object? SetFontSize(object radioButton, RxAnimation animation) => ((IRadioButton)radioButton).FontSize = ((RxDoubleAnimation)animation).CurrentValue();
    static object? SetBorderWidth(object radioButton, RxAnimation animation) => ((IRadioButton)radioButton).BorderWidth = ((RxDoubleAnimation)animation).CurrentValue();
    public static T Value<T>(this T radioButton, object? value)
        where T : IRadioButton
    {
        radioButton.Value = value;
        return radioButton;
    }

    public static T Value<T>(this T radioButton, Func<object?> valueFunc)
        where T : IRadioButton
    {
        radioButton.Value = new PropertyValue<object?>(valueFunc);
        return radioButton;
    }

    public static T IsChecked<T>(this T radioButton, bool isChecked)
        where T : IRadioButton
    {
        radioButton.IsChecked = isChecked;
        return radioButton;
    }

    public static T IsChecked<T>(this T radioButton, Func<bool> isCheckedFunc)
        where T : IRadioButton
    {
        radioButton.IsChecked = new PropertyValue<bool>(isCheckedFunc);
        return radioButton;
    }

    public static T GroupName<T>(this T radioButton, string groupName)
        where T : IRadioButton
    {
        radioButton.GroupName = groupName;
        return radioButton;
    }

    public static T GroupName<T>(this T radioButton, Func<string> groupNameFunc)
        where T : IRadioButton
    {
        radioButton.GroupName = new PropertyValue<string>(groupNameFunc);
        return radioButton;
    }

    public static T TextColor<T>(this T radioButton, Microsoft.Maui.Graphics.Color textColor)
        where T : IRadioButton
    {
        radioButton.TextColor = textColor;
        return radioButton;
    }

    public static T TextColor<T>(this T radioButton, Func<Microsoft.Maui.Graphics.Color> textColorFunc)
        where T : IRadioButton
    {
        radioButton.TextColor = new PropertyValue<Microsoft.Maui.Graphics.Color>(textColorFunc);
        return radioButton;
    }

    public static T CharacterSpacing<T>(this T radioButton, double characterSpacing, RxDoubleAnimation? customAnimation = null)
        where T : IRadioButton
    {
        radioButton.CharacterSpacing = characterSpacing;
        radioButton.AppendAnimatable(Microsoft.Maui.Controls.RadioButton.CharacterSpacingProperty, customAnimation ?? new RxDoubleAnimation(characterSpacing), SetCharacterSpacing);
        return radioButton;
    }

    public static T CharacterSpacing<T>(this T radioButton, Func<double> characterSpacingFunc)
        where T : IRadioButton
    {
        radioButton.CharacterSpacing = new PropertyValue<double>(characterSpacingFunc);
        return radioButton;
    }

    public static T TextTransform<T>(this T radioButton, Microsoft.Maui.TextTransform textTransform)
        where T : IRadioButton
    {
        radioButton.TextTransform = textTransform;
        return radioButton;
    }

    public static T TextTransform<T>(this T radioButton, Func<Microsoft.Maui.TextTransform> textTransformFunc)
        where T : IRadioButton
    {
        radioButton.TextTransform = new PropertyValue<Microsoft.Maui.TextTransform>(textTransformFunc);
        return radioButton;
    }

    public static T FontAttributes<T>(this T radioButton, Microsoft.Maui.Controls.FontAttributes fontAttributes)
        where T : IRadioButton
    {
        radioButton.FontAttributes = fontAttributes;
        return radioButton;
    }

    public static T FontAttributes<T>(this T radioButton, Func<Microsoft.Maui.Controls.FontAttributes> fontAttributesFunc)
        where T : IRadioButton
    {
        radioButton.FontAttributes = new PropertyValue<Microsoft.Maui.Controls.FontAttributes>(fontAttributesFunc);
        return radioButton;
    }

    public static T FontFamily<T>(this T radioButton, string fontFamily)
        where T : IRadioButton
    {
        radioButton.FontFamily = fontFamily;
        return radioButton;
    }

    public static T FontFamily<T>(this T radioButton, Func<string> fontFamilyFunc)
        where T : IRadioButton
    {
        radioButton.FontFamily = new PropertyValue<string>(fontFamilyFunc);
        return radioButton;
    }

    public static T FontSize<T>(this T radioButton, double fontSize, RxDoubleAnimation? customAnimation = null)
        where T : IRadioButton
    {
        radioButton.FontSize = fontSize;
        radioButton.AppendAnimatable(Microsoft.Maui.Controls.RadioButton.FontSizeProperty, customAnimation ?? new RxDoubleAnimation(fontSize), SetFontSize);
        return radioButton;
    }

    public static T FontSize<T>(this T radioButton, Func<double> fontSizeFunc)
        where T : IRadioButton
    {
        radioButton.FontSize = new PropertyValue<double>(fontSizeFunc);
        return radioButton;
    }

    public static T FontAutoScalingEnabled<T>(this T radioButton, bool fontAutoScalingEnabled)
        where T : IRadioButton
    {
        radioButton.FontAutoScalingEnabled = fontAutoScalingEnabled;
        return radioButton;
    }

    public static T FontAutoScalingEnabled<T>(this T radioButton, Func<bool> fontAutoScalingEnabledFunc)
        where T : IRadioButton
    {
        radioButton.FontAutoScalingEnabled = new PropertyValue<bool>(fontAutoScalingEnabledFunc);
        return radioButton;
    }

    public static T BorderColor<T>(this T radioButton, Microsoft.Maui.Graphics.Color borderColor)
        where T : IRadioButton
    {
        radioButton.BorderColor = borderColor;
        return radioButton;
    }

    public static T BorderColor<T>(this T radioButton, Func<Microsoft.Maui.Graphics.Color> borderColorFunc)
        where T : IRadioButton
    {
        radioButton.BorderColor = new PropertyValue<Microsoft.Maui.Graphics.Color>(borderColorFunc);
        return radioButton;
    }

    public static T CornerRadius<T>(this T radioButton, int cornerRadius)
        where T : IRadioButton
    {
        radioButton.CornerRadius = cornerRadius;
        return radioButton;
    }

    public static T CornerRadius<T>(this T radioButton, Func<int> cornerRadiusFunc)
        where T : IRadioButton
    {
        radioButton.CornerRadius = new PropertyValue<int>(cornerRadiusFunc);
        return radioButton;
    }

    public static T BorderWidth<T>(this T radioButton, double borderWidth, RxDoubleAnimation? customAnimation = null)
        where T : IRadioButton
    {
        radioButton.BorderWidth = borderWidth;
        radioButton.AppendAnimatable(Microsoft.Maui.Controls.RadioButton.BorderWidthProperty, customAnimation ?? new RxDoubleAnimation(borderWidth), SetBorderWidth);
        return radioButton;
    }

    public static T BorderWidth<T>(this T radioButton, Func<double> borderWidthFunc)
        where T : IRadioButton
    {
        radioButton.BorderWidth = new PropertyValue<double>(borderWidthFunc);
        return radioButton;
    }

    public static T OnCheckedChanged<T>(this T radioButton, Action? checkedChangedAction)
        where T : IRadioButton
    {
        radioButton.CheckedChangedAction = checkedChangedAction;
        return radioButton;
    }

    public static T OnCheckedChanged<T>(this T radioButton, Action<object?, CheckedChangedEventArgs>? checkedChangedActionWithArgs)
        where T : IRadioButton
    {
        radioButton.CheckedChangedActionWithArgs = checkedChangedActionWithArgs;
        return radioButton;
    }
}

public static partial class RadioButtonStyles
{
    public static Action<IRadioButton>? Default { get; set; }
    public static Dictionary<string, Action<IRadioButton>> Themes { get; } = [];
}
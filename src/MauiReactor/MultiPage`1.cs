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

namespace MauiReactor
{

    public partial interface IGenericMultiPage : IPage

    {

        PropertyValue<object>? SelectedItem { get; set; }



        Action? CurrentPageChangedAction { get; set; }
        Action<object?, EventArgs>? CurrentPageChangedActionWithArgs { get; set; }

        Action? PagesChangedAction { get; set; }
        Action<object?, EventArgs>? PagesChangedActionWithArgs { get; set; }


    }


    public abstract partial class MultiPage<T, TChild> : Page<T>, IGenericMultiPage where T : Microsoft.Maui.Controls.MultiPage<TChild>, new() where TChild : Microsoft.Maui.Controls.Page
    {
        public MultiPage()
        {

        }

        public MultiPage(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }



        PropertyValue<object>? IGenericMultiPage.SelectedItem { get; set; }



        Action? IGenericMultiPage.CurrentPageChangedAction { get; set; }
        Action<object?, EventArgs>? IGenericMultiPage.CurrentPageChangedActionWithArgs { get; set; }

        Action? IGenericMultiPage.PagesChangedAction { get; set; }
        Action<object?, EventArgs>? IGenericMultiPage.PagesChangedActionWithArgs { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();


            Validate.EnsureNotNull(NativeControl);
            var thisAsIGenericMultiPage = (IGenericMultiPage)this;


            SetPropertyValue(NativeControl, Microsoft.Maui.Controls.MultiPage<TChild>.SelectedItemProperty, thisAsIGenericMultiPage.SelectedItem);





            base.OnUpdate();

            OnEndUpdate();
        }



        partial void OnBeginUpdate();
        partial void OnEndUpdate();



        partial void OnAttachingNativeEvents();
        partial void OnDetachingNativeEvents();

        protected override void OnAttachNativeEvents()
        {
            Validate.EnsureNotNull(NativeControl);

            var thisAsIGenericMultiPage = (IGenericMultiPage)this;

            if (thisAsIGenericMultiPage.CurrentPageChangedAction != null || thisAsIGenericMultiPage.CurrentPageChangedActionWithArgs != null)
            {
                NativeControl.CurrentPageChanged += NativeControl_CurrentPageChanged;
            }

            if (thisAsIGenericMultiPage.PagesChangedAction != null || thisAsIGenericMultiPage.PagesChangedActionWithArgs != null)
            {
                NativeControl.PagesChanged += NativeControl_PagesChanged;
            }


            OnAttachingNativeEvents();

            base.OnAttachNativeEvents();
        }


        private void NativeControl_CurrentPageChanged(object? sender, EventArgs e)
        {
            var thisAsIGenericMultiPage = (IGenericMultiPage)this;
            thisAsIGenericMultiPage.CurrentPageChangedAction?.Invoke();
            thisAsIGenericMultiPage.CurrentPageChangedActionWithArgs?.Invoke(sender, e);
        }

        private void NativeControl_PagesChanged(object? sender, EventArgs e)
        {
            var thisAsIGenericMultiPage = (IGenericMultiPage)this;
            thisAsIGenericMultiPage.PagesChangedAction?.Invoke();
            thisAsIGenericMultiPage.PagesChangedActionWithArgs?.Invoke(sender, e);
        }


        protected override void OnDetachNativeEvents()
        {
            if (NativeControl != null)
            {

                NativeControl.CurrentPageChanged -= NativeControl_CurrentPageChanged;

                NativeControl.PagesChanged -= NativeControl_PagesChanged;

            }

            OnDetachingNativeEvents();

            base.OnDetachNativeEvents();
        }


    }



    public static partial class MultiPageExtensions
    {


        public static T SelectedItem<T>(this T multiPage, object selectedItem) where T : IGenericMultiPage
        {
            multiPage.SelectedItem = new PropertyValue<object>(selectedItem);
            return multiPage;
        }


        public static T SelectedItem<T>(this T multiPage, Func<object> selectedItemFunc) where T : IGenericMultiPage
        {
            multiPage.SelectedItem = new PropertyValue<object>(selectedItemFunc);
            return multiPage;
        }










        public static T OnCurrentPageChanged<T>(this T multiPage, Action? currentPageChangedAction) where T : IGenericMultiPage
        {
            multiPage.CurrentPageChangedAction = currentPageChangedAction;
            return multiPage;
        }

        public static T OnCurrentPageChanged<T>(this T multiPage, Action<object?, EventArgs>? currentPageChangedActionWithArgs) where T : IGenericMultiPage
        {
            multiPage.CurrentPageChangedActionWithArgs = currentPageChangedActionWithArgs;
            return multiPage;
        }

        public static T OnPagesChanged<T>(this T multiPage, Action? pagesChangedAction) where T : IGenericMultiPage
        {
            multiPage.PagesChangedAction = pagesChangedAction;
            return multiPage;
        }

        public static T OnPagesChanged<T>(this T multiPage, Action<object?, EventArgs>? pagesChangedActionWithArgs) where T : IGenericMultiPage
        {
            multiPage.PagesChangedActionWithArgs = pagesChangedActionWithArgs;
            return multiPage;
        }

    }
}

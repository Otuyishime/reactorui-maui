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

    public partial interface IAbsoluteLayout : ILayout

    {




    }


    public partial class AbsoluteLayout<T> : Layout<T>, IAbsoluteLayout where T : Microsoft.Maui.Controls.AbsoluteLayout, new()
    {
        public AbsoluteLayout()
        {

        }

        public AbsoluteLayout(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }






        protected override void OnUpdate()
        {
            OnBeginUpdate();


            base.OnUpdate();

            OnEndUpdate();
        }



        partial void OnBeginUpdate();
        partial void OnEndUpdate();



    }


    public partial class AbsoluteLayout : AbsoluteLayout<Microsoft.Maui.Controls.AbsoluteLayout>
    {
        public AbsoluteLayout()
        {

        }

        public AbsoluteLayout(Action<Microsoft.Maui.Controls.AbsoluteLayout?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }


    public static partial class AbsoluteLayoutExtensions
    {



    }
}

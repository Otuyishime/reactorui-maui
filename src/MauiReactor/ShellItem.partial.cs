﻿using MauiReactor.Internals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiReactor
{
    public partial class ShellItem<T> : IEnumerable
    {
        private readonly List<VisualNode> _items = new List<VisualNode>();
        private readonly Dictionary<BindableObject, Microsoft.Maui.Controls.ShellSection> _elementItemMap = new();

        public void Add(params VisualNode?[] nodes)
        {
            if (nodes is null)
            {
                throw new ArgumentNullException(nameof(nodes));
            }

            foreach (var node in nodes)
            {
                if (node != null)
                {
                    _items.Add(node);
                }
            }
        }

        protected override void OnAddChild(VisualNode widget, BindableObject childControl)
        {
            Validate.EnsureNotNull(NativeControl);

            if (childControl is Microsoft.Maui.Controls.ShellSection item)
                NativeControl.Items.Insert(widget.ChildIndex, item);
            else if (childControl is Microsoft.Maui.Controls.ShellContent shellContent)
                NativeControl.Items.Insert(widget.ChildIndex, shellContent);
            else if (childControl is Microsoft.Maui.Controls.Page page)
                NativeControl.Items.Insert(widget.ChildIndex, new Microsoft.Maui.Controls.ShellContent() { Content = page });
            else
            {
                throw new InvalidOperationException($"Type '{childControl.GetType()}' not supported under '{GetType()}'");
            }

            _elementItemMap[childControl] = NativeControl.Items[NativeControl.Items.Count - 1];

            base.OnAddChild(widget, childControl);
        }

        protected override void OnRemoveChild(VisualNode widget, BindableObject childControl)
        {
            Validate.EnsureNotNull(NativeControl);

            NativeControl.Items.Remove(_elementItemMap[childControl]);

            base.OnRemoveChild(widget, childControl);
        }

        public IEnumerator<VisualNode> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            return _items;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}

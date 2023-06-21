﻿using MauiReactor.Internals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiReactor;


public partial interface IListView
{
    IEnumerable? ItemsSource { get; set; }

    Func<object, ViewCell>? ViewCellItemTemplate { get; set; }

    Func<object, ViewCell>? ViewCellGroupItemTemplate { get; set; }

    Func<object, EntryCell>? EntryCellItemTemplate { get; set; }

    Func<object, EntryCell>? EntryCellGroupItemTemplate { get; set; }

    Func<object, TextCell>? TextCellItemTemplate { get; set; }

    Func<object, TextCell>? TextCellGroupItemTemplate { get; set; }

    Func<object, SwitchCell>? SwitchCellItemTemplate { get; set; }

    Func<object, SwitchCell>? SwitchCellGroupItemTemplate { get; set; }

    Func<object, ImageCell>? ImageCellItemTemplate { get; set; }

    Func<object, ImageCell>? ImageCellGroupItemTemplate { get; set; }

    VisualNode? Header { get; set; }

    VisualNode? Footer { get; set; }
}

public abstract partial class ListView<T>
{
    IEnumerable? IListView.ItemsSource { get; set; }

    Func<object, ViewCell>? IListView.ViewCellItemTemplate { get; set; }
    Func<object, ViewCell>? IListView.ViewCellGroupItemTemplate { get; set; }
    Func<object, EntryCell>? IListView.EntryCellItemTemplate { get; set; }
    Func<object, EntryCell>? IListView.EntryCellGroupItemTemplate { get; set; }
    Func<object, TextCell>? IListView.TextCellItemTemplate { get; set; }
    Func<object, TextCell>? IListView.TextCellGroupItemTemplate { get; set; }
    Func<object, SwitchCell>? IListView.SwitchCellItemTemplate { get; set; }
    Func<object, SwitchCell>? IListView.SwitchCellGroupItemTemplate { get; set; }
    Func<object, ImageCell>? IListView.ImageCellItemTemplate { get; set; }
    Func<object, ImageCell>? IListView.ImageCellGroupItemTemplate { get; set; }
    
    VisualNode? IListView.Header { get; set; }
    VisualNode? IListView.Footer { get; set; }

    private class ItemTemplateNode : VisualNode, IVisualNode//, IHostElement
    {
        private readonly Cell? _presenter = null;

        public ItemTemplateNode(VisualNode root, Cell presenter)
        {
            _root = root;
            _presenter = presenter;

            Invalidate();
        }

        private VisualNode _root;


        public VisualNode? Owner
        {
            get => Parent;
            set => Parent = value;
        }

        public VisualNode Root
        {
            get => _root;
            set
            {
                if (_root != value)
                {
                    _root = value;
                    Invalidate();
                }
                else
                {
                    _root.Update();
                }
            }
        }

        //public Microsoft.Maui.Controls.Page? ContainerPage => GetPageHost()?.ContainerPage;

        protected sealed override void OnRemoveChild(VisualNode widget, BindableObject nativeControl)
        {
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            yield return Root;
        }

        protected internal override void OnLayoutCycleRequested()
        {
            Layout();
            base.OnLayoutCycleRequested();
        }
    }

    private interface IItemTemplatePresenter
    {
        void Update();
    }

    private class ViewCellItemTemplatePresenter : Microsoft.Maui.Controls.ViewCell, IItemTemplatePresenter
    {
        private ItemTemplateNode? _itemTemplateNode;
        private readonly CustomDataTemplate _template;

        public ViewCellItemTemplatePresenter(CustomDataTemplate template)
        {
            _template = template;
        }

        protected override void OnBindingContextChanged()
        {
            Update();
            base.OnBindingContextChanged();
        }

        public void Update()
        {
            while (true)
            {
                var item = BindingContext;

                if (item == null)
                    break;

                VisualNode? newRoot = _template.GetVisualNodeForItem(item);

                if (newRoot == null || newRoot is not ViewCell)
                    break;

                ((IVisualNodeWithNativeControl)newRoot).Attach(this);

                if (_itemTemplateNode != null)
                {
                    //System.Diagnostics.Debug.WriteLine("Recycling ViewCellItemTemplatePresenter item");
                    _itemTemplateNode.Owner = _template.Owner;
                    _itemTemplateNode.Root = newRoot;
                }
                else
                {
                    _itemTemplateNode = new ItemTemplateNode(newRoot, this)
                    {
                        Owner = _template.Owner
                    };
                    _itemTemplateNode.Layout();
                }

                break;
            }

        }
    }

    private class EntryCellItemTemplatePresenter : Microsoft.Maui.Controls.EntryCell, IItemTemplatePresenter
    {
        private ItemTemplateNode? _itemTemplateNode;
        private readonly CustomDataTemplate _template;

        public EntryCellItemTemplatePresenter(CustomDataTemplate template)
        {
            _template = template;
        }

        protected override void OnBindingContextChanged()
        {
            Update();
            base.OnBindingContextChanged();
        }

        public void Update()
        {
            while (true)
            {
                var item = BindingContext;

                if (item == null)
                    break;

                VisualNode? newRoot = _template.GetVisualNodeForItem(item);

                if (newRoot == null || newRoot is not EntryCell)
                    break;

                ((IVisualNodeWithNativeControl)newRoot).Attach(this);

                if (_itemTemplateNode != null)
                {
                    _itemTemplateNode.Owner = _template.Owner;
                    _itemTemplateNode.Root = newRoot;
                }
                else
                {
                    _itemTemplateNode = new ItemTemplateNode(newRoot, this)
                    {
                        Owner = _template.Owner
                    };
                    _itemTemplateNode.Layout();
                }

                break;
            }
        }
    }

    private class TextCellItemTemplatePresenter : Microsoft.Maui.Controls.TextCell, IItemTemplatePresenter
    {
        private ItemTemplateNode? _itemTemplateNode;
        private readonly CustomDataTemplate _template;

        public TextCellItemTemplatePresenter(CustomDataTemplate template)
        {
            _template = template;
        }

        protected override void OnBindingContextChanged()
        {
            Update();
            base.OnBindingContextChanged();
        }

        public void Update()
        {
            while (true)
            {
                var item = BindingContext;

                if (item == null)
                    break;

                VisualNode? newRoot = _template.GetVisualNodeForItem(item);

                if (newRoot == null || newRoot is not TextCell)
                    break;

                ((IVisualNodeWithNativeControl)newRoot).Attach(this);

                if (_itemTemplateNode != null)
                {
                    _itemTemplateNode.Owner = _template.Owner;
                    _itemTemplateNode.Root = newRoot;
                }
                else
                {
                    _itemTemplateNode = new ItemTemplateNode(newRoot, this)
                    {
                        Owner = _template.Owner
                    };
                    _itemTemplateNode.Layout();
                }

                break;
            }
        }
    }

    private class SwitchCellItemTemplatePresenter : Microsoft.Maui.Controls.SwitchCell, IItemTemplatePresenter
    {
        private ItemTemplateNode? _itemTemplateNode;
        private readonly CustomDataTemplate _template;

        public SwitchCellItemTemplatePresenter(CustomDataTemplate template)
        {
            _template = template;
        }

        protected override void OnBindingContextChanged()
        {
            Update();
            base.OnBindingContextChanged();
        }

        public void Update()
        {
            while (true)
            {
                var item = BindingContext;

                if (item == null)
                    break;

                VisualNode? newRoot = _template.GetVisualNodeForItem(item);

                if (newRoot == null || newRoot is not SwitchCell)
                    break;

                ((IVisualNodeWithNativeControl)newRoot).Attach(this);

                if (_itemTemplateNode != null)
                {
                    _itemTemplateNode.Owner = _template.Owner;
                    _itemTemplateNode.Root = newRoot;
                }
                else
                {
                    _itemTemplateNode = new ItemTemplateNode(newRoot, this)
                    {
                        Owner = _template.Owner
                    };
                    _itemTemplateNode.Layout();
                }

                break;
            }
        }
    }

    private class ImageCellItemTemplatePresenter : Microsoft.Maui.Controls.ImageCell, IItemTemplatePresenter
    {
        private ItemTemplateNode? _itemTemplateNode;
        private readonly CustomDataTemplate _template;

        public ImageCellItemTemplatePresenter(CustomDataTemplate template)
        {
            _template = template;
        }

        protected override void OnBindingContextChanged()
        {
            Update();
            base.OnBindingContextChanged();
        }

        public void Update()
        {
            while (true)
            {
                var item = BindingContext;

                if (item == null)
                    break;

                VisualNode? newRoot = _template.GetVisualNodeForItem(item);

                if (newRoot == null || newRoot is not ImageCell)
                    break;

                ((IVisualNodeWithNativeControl)newRoot).Attach(this);

                if (_itemTemplateNode != null)
                {
                    _itemTemplateNode.Owner = _template.Owner;
                    _itemTemplateNode.Root = newRoot;
                }
                else
                {
                    _itemTemplateNode = new ItemTemplateNode(newRoot, this)
                    {
                        Owner = _template.Owner
                    };
                    _itemTemplateNode.Layout();
                }

                break;
            }
        }
    }

    private class CustomDataTemplate
    {
        private readonly bool _isGroupTemplate;
        private readonly List<WeakReference<IItemTemplatePresenter>> _presenters = new();

        public CustomDataTemplate(ListView<T> owner, bool isGroupTemplate = false)
        {
            Owner = owner;
            _isGroupTemplate = isGroupTemplate;
            ItemTemplateFunc = owner.GetItemTemplateFunc();
            DataTemplate = new DataTemplate(() =>
            {
                IListView itemsView = Owner;
                IItemTemplatePresenter? presenter = null;
                if (itemsView.ViewCellItemTemplate != null)
                {
                    presenter = new ViewCellItemTemplatePresenter(this);
                }
                else if (itemsView.EntryCellItemTemplate != null)
                {
                    presenter = new EntryCellItemTemplatePresenter(this);
                }
                else if (itemsView.TextCellItemTemplate != null)
                {
                    presenter = new TextCellItemTemplatePresenter(this);
                }
                else if (itemsView.SwitchCellItemTemplate != null)
                {
                    presenter = new SwitchCellItemTemplatePresenter(this);
                }
                else if (itemsView.ImageCellItemTemplate != null)
                {
                    presenter = new ImageCellItemTemplatePresenter(this);
                }

                if (presenter != null)
                {
                    _presenters.Add(new WeakReference<IItemTemplatePresenter>(presenter));
                    return presenter;
                }

                throw new InvalidOperationException();
            });
        }

        public DataTemplate DataTemplate { get; }
        public ListView<T> Owner { get; set; }

        public Func<object, VisualNode>? ItemTemplateFunc { get; }

        public VisualNode? GetVisualNodeForItem(object item)
        {
            if (_isGroupTemplate)
            {
                return Owner.GetGroupItemTemplateFunc()?.Invoke(item);
            }

            return Owner.GetItemTemplateFunc()?.Invoke(item);
        }

        internal void Update()
        {
            foreach (var presenter in _presenters)
            {
                if (presenter.TryGetTarget(out var realPresenter))
                {
                    realPresenter.Update();
                }
            }
        }
    }

    private CustomDataTemplate? _customDataTemplate;

    private CustomDataTemplate? _customGroupDataTemplate;

    private Func<object, VisualNode>? GetItemTemplateFunc()
    {
        IListView itemsView = this;

        if (itemsView.ViewCellItemTemplate != null)
        {
            return itemsView.ViewCellItemTemplate;
        }
        else if (itemsView.EntryCellItemTemplate != null)
        {
            return itemsView.EntryCellItemTemplate;
        }
        else if (itemsView.TextCellItemTemplate != null)
        {
            return itemsView.TextCellItemTemplate;
        }
        else if (itemsView.SwitchCellItemTemplate != null)
        {
            return itemsView.SwitchCellItemTemplate;
        }
        else if (itemsView.ImageCellItemTemplate != null)
        {
            return itemsView.ImageCellItemTemplate;
        }

        return null;
    }
    private Func<object, VisualNode>? GetGroupItemTemplateFunc()
    {
        IListView itemsView = this;

        if (itemsView.ViewCellGroupItemTemplate != null)
        {
            return itemsView.ViewCellGroupItemTemplate;
        }
        else if (itemsView.EntryCellGroupItemTemplate != null)
        {
            return itemsView.EntryCellGroupItemTemplate;
        }
        else if (itemsView.TextCellGroupItemTemplate != null)
        {
            return itemsView.TextCellGroupItemTemplate;
        }
        else if (itemsView.SwitchCellGroupItemTemplate != null)
        {
            return itemsView.SwitchCellGroupItemTemplate;
        }
        else if (itemsView.ImageCellGroupItemTemplate != null)
        {
            return itemsView.ImageCellGroupItemTemplate;
        }

        return null;
    }

    partial void OnBeginUpdate()
    {
        Validate.EnsureNotNull(NativeControl);
        var thisAsIItemsView = (IListView)this;

        var itemTemplateFunc = GetItemTemplateFunc();
        var groupItemTemplateFunc = GetGroupItemTemplateFunc();

        if (NativeControl.ItemsSource == thisAsIItemsView.ItemsSource &&
            itemTemplateFunc != null &&
            _customDataTemplate?.ItemTemplateFunc?.GetType() == itemTemplateFunc.GetType() &&
            groupItemTemplateFunc != null &&
            _customGroupDataTemplate?.ItemTemplateFunc?.GetType() == groupItemTemplateFunc.GetType())
        {
            if (_customDataTemplate != null)
            {
                _customDataTemplate.Owner = this;
                _customDataTemplate.Update();
            }

            if (_customGroupDataTemplate != null)
            {
                _customGroupDataTemplate.Owner = this;
                _customGroupDataTemplate.Update();
            }
        }
        else if (thisAsIItemsView.ItemsSource != null && itemTemplateFunc != null)
        {
            _customDataTemplate = new CustomDataTemplate(this);
            NativeControl.ItemsSource = thisAsIItemsView.ItemsSource; // ObservableItemsSource.Create(thisAsIItemsView.ItemsSource, itemTemplateFunc);
            NativeControl.ItemTemplate = _customDataTemplate.DataTemplate;

            if (groupItemTemplateFunc != null)
            {
                _customGroupDataTemplate = new CustomDataTemplate(this, isGroupTemplate: true);
                NativeControl.GroupHeaderTemplate = _customGroupDataTemplate.DataTemplate;
            }
        }
        else
        {
            NativeControl.ItemsSource = null;
            NativeControl.ItemTemplate = null;
            _customDataTemplate = null;
            _customGroupDataTemplate = null;
        }
    }

    protected override void OnMigrated(VisualNode newNode)
    {
        var newItemsView = ((ListView<T>)newNode);
        newItemsView._customDataTemplate = _customDataTemplate;
        if (newItemsView._customDataTemplate != null)
        {
            newItemsView._customDataTemplate.Owner = ((ListView<T>)newNode);
        }

        newItemsView._customGroupDataTemplate = _customGroupDataTemplate;
        if (newItemsView._customGroupDataTemplate != null)
        {
            newItemsView._customGroupDataTemplate.Owner = ((ListView<T>)newNode);
        }

        base.OnMigrated(newNode);
    }

    protected override IEnumerable<VisualNode> RenderChildren()
    {
        var thisAsIListView = (IListView)this;

        var children = base.RenderChildren();

        if (thisAsIListView.Header != null)
        {
            children = children.Concat(new[] { thisAsIListView.Header });
        }
        if (thisAsIListView.Footer != null)
        {
            children = children.Concat(new[] { thisAsIListView.Footer });
        }

        return children;
    }

    protected override void OnAddChild(VisualNode widget, BindableObject childControl)
    {
        Validate.EnsureNotNull(NativeControl);

        var thisAsIListView = (IListView)this;

        if (widget == thisAsIListView.Header)
        {
            NativeControl.Header = childControl;
        }
        else if (widget == thisAsIListView.Footer)
        {
            NativeControl.Footer = childControl;
        }

        base.OnAddChild(widget, childControl);
    }

    protected override void OnRemoveChild(VisualNode widget, BindableObject childControl)
    {
        Validate.EnsureNotNull(NativeControl);
        var thisAsIListView = (IListView)this;

        if (widget == thisAsIListView.Header)
        {
            NativeControl.Header = null;
        }
        else if (widget == thisAsIListView.Footer)
        {
            NativeControl.Footer = null;
        }

        base.OnRemoveChild(widget, childControl);
    }

}

public static partial class ListViewExtensions
{
    public static T ItemsSource<T, TItem>(this T itemsview, IEnumerable<TItem> itemsSource) where T : IListView
    {
        itemsview.ItemsSource = itemsSource;
        return itemsview;
    }

    public static T ItemsSource<T, TItem>(this T itemsview, IEnumerable<TItem> itemsSource, Func<TItem, ViewCell> template) where T : IListView
    {
        itemsview.ItemsSource = itemsSource;

        itemsview.ViewCellItemTemplate = new Func<object, ViewCell>(item => template((TItem)item));
        itemsview.SwitchCellItemTemplate = null;
        itemsview.TextCellItemTemplate = null;
        itemsview.EntryCellItemTemplate = null;
        itemsview.ImageCellItemTemplate = null;

        return itemsview;
    }

    public static T ItemsSource<T, TGroupItem, TItem>(this T itemsview, IEnumerable<TGroupItem> itemsSource, Func<TGroupItem, ViewCell> groupTemplate, Func<TItem, ViewCell> template) where T : IListView
    {
        itemsview.ItemsSource = itemsSource;

        itemsview.ViewCellItemTemplate = new Func<object, ViewCell>(item => template((TItem)item));
        itemsview.ViewCellGroupItemTemplate = new Func<object, ViewCell>(item => groupTemplate((TGroupItem)item));
        itemsview.SwitchCellItemTemplate = null;
        itemsview.TextCellItemTemplate = null;
        itemsview.EntryCellItemTemplate = null;
        itemsview.ImageCellItemTemplate = null;

        return itemsview;
    }

    public static T ItemsSource<T, TItem>(this T itemsview, IEnumerable<TItem> itemsSource, Func<TItem, EntryCell> template) where T : IListView
    {
        itemsview.ItemsSource = itemsSource;

        itemsview.ViewCellItemTemplate = null;
        itemsview.SwitchCellItemTemplate = null;
        itemsview.TextCellItemTemplate = null;
        itemsview.EntryCellItemTemplate = new Func<object, EntryCell>(item => template((TItem)item));
        itemsview.ImageCellItemTemplate = null;

        return itemsview;
    }

    public static T ItemsSource<T, TGroupItem, TItem>(this T itemsview, IEnumerable<TGroupItem> itemsSource, Func<TGroupItem, EntryCell> groupTemplate, Func<TItem, EntryCell> template) where T : IListView
    {
        itemsview.ItemsSource = itemsSource;

        itemsview.ViewCellItemTemplate = null;
        itemsview.SwitchCellItemTemplate = null;
        itemsview.TextCellItemTemplate = null;
        itemsview.EntryCellItemTemplate = new Func<object, EntryCell>(item => template((TItem)item));
        itemsview.EntryCellGroupItemTemplate = new Func<object, EntryCell>(item => groupTemplate((TGroupItem)item));
        itemsview.ImageCellItemTemplate = null;

        return itemsview;
    }

    public static T ItemsSource<T, TItem>(this T itemsview, IEnumerable<TItem> itemsSource, Func<TItem, TextCell> template) where T : IListView
    {
        itemsview.ItemsSource = itemsSource;

        itemsview.ViewCellItemTemplate = null;
        itemsview.SwitchCellItemTemplate = null;
        itemsview.TextCellItemTemplate = new Func<object, TextCell>(item => template((TItem)item));
        itemsview.EntryCellItemTemplate = null;
        itemsview.ImageCellItemTemplate = null;

        return itemsview;
    }

    public static T ItemsSource<T, TGroupItem, TItem>(this T itemsview, IEnumerable<TGroupItem> itemsSource, Func<TGroupItem, TextCell> groupTemplate, Func<TItem, TextCell> template) where T : IListView
    {
        itemsview.ItemsSource = itemsSource;

        itemsview.ViewCellItemTemplate = null;
        itemsview.SwitchCellItemTemplate = null;
        itemsview.TextCellItemTemplate = new Func<object, TextCell>(item => template((TItem)item));
        itemsview.TextCellGroupItemTemplate = new Func<object, TextCell>(item => groupTemplate((TGroupItem)item));
        itemsview.EntryCellItemTemplate = null;
        itemsview.ImageCellItemTemplate = null;

        return itemsview;
    }

    public static T ItemsSource<T, TItem>(this T itemsview, IEnumerable<TItem> itemsSource, Func<TItem, SwitchCell> template) where T : IListView
    {
        itemsview.ItemsSource = itemsSource;

        itemsview.ViewCellItemTemplate = null;
        itemsview.SwitchCellItemTemplate = new Func<object, SwitchCell>(item => template((TItem)item));
        itemsview.TextCellItemTemplate = null;
        itemsview.EntryCellItemTemplate = null;
        itemsview.ImageCellItemTemplate = null;

        return itemsview;
    }

    public static T ItemsSource<T, TGroupItem, TItem>(this T itemsview, IEnumerable<TGroupItem> itemsSource, Func<TGroupItem, SwitchCell> groupTemplate, Func<TItem, SwitchCell> template) where T : IListView
    {
        itemsview.ItemsSource = itemsSource;

        itemsview.ViewCellItemTemplate = null;
        itemsview.SwitchCellItemTemplate = new Func<object, SwitchCell>(item => template((TItem)item));
        itemsview.SwitchCellGroupItemTemplate = new Func<object, SwitchCell>(item => groupTemplate((TGroupItem)item));
        itemsview.TextCellItemTemplate = null;
        itemsview.EntryCellItemTemplate = null;
        itemsview.ImageCellItemTemplate = null;

        return itemsview;
    }

    public static T ItemsSource<T, TItem>(this T itemsview, IEnumerable<TItem> itemsSource, Func<TItem, ImageCell> template) where T : IListView
    {
        itemsview.ItemsSource = itemsSource;

        itemsview.ViewCellItemTemplate = null;
        itemsview.SwitchCellItemTemplate = null;
        itemsview.TextCellItemTemplate = null;
        itemsview.EntryCellItemTemplate = null;
        itemsview.ImageCellItemTemplate = new Func<object, ImageCell>(item => template((TItem)item));

        return itemsview;
    }

    public static T ItemsSource<T, TGroupItem, TItem>(this T itemsview, IEnumerable<TGroupItem> itemsSource, Func<TGroupItem, ImageCell> groupTemplate, Func<TItem, ImageCell> template) where T : IListView
    {
        itemsview.ItemsSource = itemsSource;

        itemsview.ViewCellItemTemplate = null;
        itemsview.SwitchCellItemTemplate = null;
        itemsview.TextCellItemTemplate = null;
        itemsview.EntryCellItemTemplate = null;
        itemsview.ImageCellItemTemplate = new Func<object, ImageCell>(item => template((TItem)item));
        itemsview.ImageCellGroupItemTemplate = new Func<object, ImageCell>(item => groupTemplate((TGroupItem)item));

        return itemsview;
    }

    public static T Header<T>(this T shell, VisualNode header) where T : IListView
    {
        shell.Header = header;
        return shell;
    }

    public static T Footer<T>(this T shell, VisualNode footer) where T : IListView
    {
        shell.Footer = footer;
        return shell;
    }
}


public partial class ListView
{
    private readonly ListViewCachingStrategy? _listViewCachingStrategy;

    public ListView(ListViewCachingStrategy listViewCachingStrategy)
    {
        _listViewCachingStrategy = listViewCachingStrategy;
    }

    public ListView(ListViewCachingStrategy listViewCachingStrategy, Action<Microsoft.Maui.Controls.ListView?> componentRefAction) : base(componentRefAction)
    {
        _listViewCachingStrategy = listViewCachingStrategy;
    }

    protected override void OnMount()
    {
        if (_listViewCachingStrategy != null)
        {
            _nativeControl ??= new Microsoft.Maui.Controls.ListView(_listViewCachingStrategy.Value);
        }

        base.OnMount();
    }
}
﻿#nullable enable
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Core2D.Model.Renderer;
using Core2D.Model;
using Core2D.ViewModels.Containers;
using Core2D.ViewModels.Data;

namespace Core2D.Views.Renderer;

public class RenderView : UserControl
{
    public static readonly StyledProperty<FrameContainerViewModel?> ContainerProperty =
        AvaloniaProperty.Register<RenderView, FrameContainerViewModel?>(nameof(Container));

    public static readonly StyledProperty<IShapeRenderer?> RendererProperty =
        AvaloniaProperty.Register<RenderView, IShapeRenderer?>(nameof(Renderer));

    public static readonly StyledProperty<ISelection?> SelectionProperty =
        AvaloniaProperty.Register<RenderView, ISelection?>(nameof(Selection));

    public static readonly StyledProperty<DataFlow?> DataFlowProperty =
        AvaloniaProperty.Register<RenderView, DataFlow?>(nameof(DataFlow));

    public static readonly StyledProperty<RenderType> RenderTypeProperty =
        AvaloniaProperty.Register<RenderView, RenderType>(nameof(RenderType));

    public FrameContainerViewModel? Container
    {
        get => GetValue(ContainerProperty);
        set => SetValue(ContainerProperty, value);
    }

    public IShapeRenderer? Renderer
    {
        get => GetValue(RendererProperty);
        set => SetValue(RendererProperty, value);
    }

    public ISelection? Selection
    {
        get => GetValue(SelectionProperty);
        set => SetValue(SelectionProperty, value);
    }

    public DataFlow? DataFlow
    {
        get => GetValue(DataFlowProperty);
        set => SetValue(DataFlowProperty, value);
    }

    public RenderType RenderType
    {
        get => GetValue(RenderTypeProperty);
        set => SetValue(RenderTypeProperty, value);
    }

    public RenderView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        var drawState = new RenderState()
        {
            Container = Container,
            Renderer = Renderer ?? GetValue(RendererOptions.RendererProperty),
            Selection = Selection ?? GetValue(RendererOptions.SelectionProperty),
            DataFlow = DataFlow ?? GetValue(RendererOptions.DataFlowProperty),
            RenderType = RenderType,
        };

        var customDrawOperation = new RenderDrawOperation
        {
            RenderState = drawState,
            Bounds = Bounds
        };

        // TODO: context.Custom(customDrawOperation);

        customDrawOperation.Render(context.PlatformImpl);
    }
}

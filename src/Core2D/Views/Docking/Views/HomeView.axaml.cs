﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Core2D.Views.Docking.Views;

public class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Core2D.Editor;
using Core2D.Editors;
using Core2D.Shapes;
using Core2D.UI.Views.Editors;

namespace Core2D.UI.Views.Shapes
{
    /// <summary>
    /// Interaction logic for <see cref="RectangleShapeControl"/> xaml.
    /// </summary>
    public class RectangleShapeControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleShapeControl"/> class.
        /// </summary>
        public RectangleShapeControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the Xaml components.
        /// </summary>
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// Edit shape text binding.
        /// </summary>
        public void OnEditTextBinding(object shape)
        {
            if (this.VisualRoot is TopLevel topLevel 
                && topLevel.DataContext is IProjectEditor editor
                && shape is ITextShape text)
            {
                var window = new TextBindingEditorWindow()
                {
                    DataContext = new TextBindingEditor()
                    {
                        Editor = editor,
                        Text = text,
                        CaretIndex = text.Text.Length
                    }
                };
                window.ShowDialog(topLevel as Window);
            }
        }
    }
}

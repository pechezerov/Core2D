﻿using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Rendering;
using SkiaSharp;

namespace Core2D.Util.Rendering
{
    public static class SkpRenderer
    {
        public static void Render(Control target, Size size, Stream stream, double dpi = 96)
        {
            var bounds = SKRect.Create(new SKSize((float)size.Width, (float)size.Height));
            using var pictureRecorder = new SKPictureRecorder();
            using var canvas = pictureRecorder.BeginRecording(bounds);
            using var renderer = new ImmediateRenderer(target);
            target.Measure(size);
            target.Arrange(new Rect(size));
            using var renderTarget = new CanvasRenderTarget(canvas, dpi);
            ImmediateRenderer.Render(target, renderTarget);
            using var picture = pictureRecorder.EndRecording();
            picture.Serialize(stream);
        }
    }
}
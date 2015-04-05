﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core;

namespace Test
{
    public static class Demo
    {
        private static void Lines(
            IContainer c,
            int nshapes,
            double width,
            double height,
            ShapeStyle style,
            ILayer layer,
            Random rand)
        {
            for (int i = 0; i < nshapes; i++)
            {
                double x1 = rand.NextDouble() * width;
                double y1 = rand.NextDouble() * height;
                double x2 = rand.NextDouble() * width;
                double y2 = rand.NextDouble() * height;
                var l = XLine.Create(x1, y1, x2, y2, style, c.PointShape);
                layer.Shapes.Add(l);
            }
        }

        private static void Rectangles(
            IContainer c,
            int nshapes,
            double width,
            double height,
            ShapeStyle styles,
            ILayer layer,
            Random rand)
        {
            for (int i = 0; i < nshapes; i++)
            {
                double x1 = rand.NextDouble() * width;
                double y1 = rand.NextDouble() * height;
                double x2 = rand.NextDouble() * width;
                double y2 = rand.NextDouble() * height;
                var r = XRectangle.Create(x1, y1, x2, y2, styles, c.PointShape);
                layer.Shapes.Add(r);
            }
        }

        private static void Ellipses(
            IContainer c,
            int nshapes,
            double width,
            double height,
            ShapeStyle style,
            ILayer layer,
            Random rand)
        {
            for (int i = 0; i < nshapes; i++)
            {
                double x1 = rand.NextDouble() * width;
                double y1 = rand.NextDouble() * height;
                double x2 = rand.NextDouble() * width;
                double y2 = rand.NextDouble() * height;
                var e = XEllipse.Create(x1, y1, x2, y2, style, c.PointShape);
                layer.Shapes.Add(e);
            }
        }

        private static void Arcs(
            IContainer c,
            int nshapes,
            double width,
            double height,
            ShapeStyle style,
            ILayer layer,
            Random rand)
        {
            for (int i = 0; i < nshapes; i++)
            {
                double x1 = rand.NextDouble() * width;
                double y1 = rand.NextDouble() * height;
                double x2 = rand.NextDouble() * width;
                double y2 = rand.NextDouble() * height;
                var a = XArc.Create(x1, y1, x2, y2, style, c.PointShape);
                layer.Shapes.Add(a);
            }
        }

        private static void Beziers(
            IContainer c,
            int nshapes,
            double width,
            double height,
            ShapeStyle style,
            ILayer layer,
            Random rand)
        {
            for (int i = 0; i < nshapes; i++)
            {
                double x1 = rand.NextDouble() * width;
                double y1 = rand.NextDouble() * height;
                double x2 = rand.NextDouble() * width;
                double y2 = rand.NextDouble() * height;
                double x3 = rand.NextDouble() * width;
                double y3 = rand.NextDouble() * height;
                double x4 = rand.NextDouble() * width;
                double y4 = rand.NextDouble() * height;
                var b = XBezier.Create(x1, y1, x2, y2, x3, y3, x4, y4, style, c.PointShape);
                layer.Shapes.Add(b);
            }
        }

        private static void QBeziers(
            IContainer c,
            int nshapes,
            double width,
            double height,
            ShapeStyle style,
            ILayer layer,
            Random rand)
        {
            for (int i = 0; i < nshapes; i++)
            {
                double x1 = rand.NextDouble() * width;
                double y1 = rand.NextDouble() * height;
                double x2 = rand.NextDouble() * width;
                double y2 = rand.NextDouble() * height;
                double x3 = rand.NextDouble() * width;
                double y3 = rand.NextDouble() * height;
                var b = XQBezier.Create(x1, y1, x2, y2, x3, y3, style, c.PointShape);
                layer.Shapes.Add(b);
            }
        }

        private static void Texts(
            IContainer c,
            int nshapes,
            double width,
            double height,
            ShapeStyle style,
            ILayer layer,
            Random rand)
        {
            for (int i = 0; i < nshapes; i++)
            {
                double x1 = rand.NextDouble() * width;
                double y1 = rand.NextDouble() * height;
                double x2 = rand.NextDouble() * width;
                double y2 = rand.NextDouble() * height;
                var t = XText.Create(x1, y1, x2, y2, style, c.PointShape, "Demo");
                layer.Shapes.Add(t);
            }
        }

        public static void All(IContainer c, int nshapes)
        {
            var width = c.Width;
            var height = c.Height;
            var rand = new Random(Guid.NewGuid().GetHashCode());

            Lines(c, nshapes, width, height, c.Styles[0], c.Layers[0], rand);
            Rectangles(c, nshapes, width, height, c.Styles[1], c.Layers[1], rand);
            Ellipses(c, nshapes, width, height, c.Styles[2], c.Layers[1], rand);
            Arcs(c, nshapes, width, height, c.Styles[2], c.Layers[1], rand);
            Beziers(c, nshapes, width, height, c.Styles[3], c.Layers[2], rand);
            QBeziers(c, nshapes, width, height, c.Styles[4], c.Layers[2], rand);
            Texts(c, nshapes, width, height, c.Styles[4], c.Layers[3], rand);

            c.Invalidate();
        }
    }
}

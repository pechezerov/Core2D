﻿#nullable enable
using System;
using Core2D.Spatial;
using Core2D.Spatial.Arc;
using Core2D.Model.Path;
using Core2D.ViewModels.Path;
using Core2D.ViewModels.Path.Segments;
using Core2D.ViewModels.Shapes;
using A = Avalonia;
using AM = Avalonia.Media;
using AP = Avalonia.Platform;

namespace Core2D.Modules.Renderer.Avalonia;

public static class PathGeometryConverter
{
    private static T GetService<T>(this A.IAvaloniaDependencyResolver resolver) => (T) resolver.GetService(typeof (T));

    private static AP.IPlatformRenderInterface Factory => A.AvaloniaLocator.Current.GetService<AP.IPlatformRenderInterface>();

    private static A.Point ToPoint(this PointShapeViewModel point) => new(point.X, point.Y);

    private static A.Size ToSize(this PathSizeViewModel size) => new( size.Width, size.Height);

    private static AM.FillRule ToFillRule(this FillRule fillRule) => fillRule == FillRule.Nonzero ? AM.FillRule.NonZero : AM.FillRule.EvenOdd;

    public static AP.IGeometryImpl ToGeometryImpl(PathShapeViewModel path, bool isFilled)
    {
        var geometry = Factory.CreateStreamGeometry();
        using var context = geometry.Open();

        context.SetFillRule(path.FillRule.ToFillRule());

        foreach (var figure in path.Figures)
        {
            context.BeginFigure(figure.StartPoint.ToPoint(), isFilled);

            foreach (var pathSegment in figure.Segments)
            {
                switch (pathSegment)
                {
                    case ArcSegmentViewModel arcSegment:
                        context.ArcTo(
                            arcSegment.Point.ToPoint(),
                            arcSegment.Size.ToSize(),
                            arcSegment.RotationAngle,
                            arcSegment.IsLargeArc,
                            arcSegment.SweepDirection == SweepDirection.Clockwise
                                ? AM.SweepDirection.Clockwise
                                : AM.SweepDirection.CounterClockwise);
                        break;
                    case CubicBezierSegmentViewModel cubicBezierSegment:
                        context.CubicBezierTo(
                            cubicBezierSegment.Point1.ToPoint(),
                            cubicBezierSegment.Point2.ToPoint(),
                            cubicBezierSegment.Point3.ToPoint());
                        break;
                    case LineSegmentViewModel lineSegment:
                        context.LineTo(
                            lineSegment.Point.ToPoint());
                        break;
                    case QuadraticBezierSegmentViewModel quadraticBezierSegment:
                        context.QuadraticBezierTo(
                            quadraticBezierSegment.Point1.ToPoint(),
                            quadraticBezierSegment.Point2.ToPoint());
                        break;
                    default:
                        throw new NotSupportedException("Not supported segment type: " + pathSegment.GetType());
                }
            }

            context.EndFigure(figure.IsClosed);
        }

        return geometry;
    }
    public static AP.IGeometryImpl ToGeometryImpl(EllipseShapeViewModel ellipse)
    {
        var rect2 = Rect2.FromPoints(
            ellipse.TopLeft.X,
            ellipse.TopLeft.Y,
            ellipse.BottomRight.X,
            ellipse.BottomRight.Y);
        var rect = new A.Rect(rect2.X, rect2.Y, rect2.Width, rect2.Height);
        return Factory.CreateEllipseGeometry(rect);
    }

    public static AP.IGeometryImpl ToGeometryImpl(ArcShapeViewModel arc)
    {
        var geometry = Factory.CreateStreamGeometry();
        using var context = geometry.Open();
        var wpfArc = new WpfArc(
            Point2.FromXY(arc.Point1.X, arc.Point1.Y),
            Point2.FromXY(arc.Point2.X, arc.Point2.Y),
            Point2.FromXY(arc.Point3.X, arc.Point3.Y),
            Point2.FromXY(arc.Point4.X, arc.Point4.Y));
        context.BeginFigure(
            new A.Point(wpfArc.Start.X, wpfArc.Start.Y),
            arc.IsFilled);
        context.ArcTo(
            new A.Point(wpfArc.End.X, wpfArc.End.Y),
            new A.Size(wpfArc.Radius.Width, wpfArc.Radius.Height),
            0.0,
            wpfArc.IsLargeArc,
            AM.SweepDirection.Clockwise);
        context.EndFigure(false);
        return geometry;
    }

    public static AP.IGeometryImpl ToGeometryImpl(CubicBezierShapeViewModel cubicBezier)
    {
        var geometry = Factory.CreateStreamGeometry();
        using var context = geometry.Open();
        context.BeginFigure(
            cubicBezier.Point1.ToPoint(),
            cubicBezier.IsFilled);
        context.CubicBezierTo(
            cubicBezier.Point2.ToPoint(),
            cubicBezier.Point3.ToPoint(),
            cubicBezier.Point4.ToPoint());
        context.EndFigure(false);
        return geometry;
    }

    public static AP.IGeometryImpl ToGeometryImpl(QuadraticBezierShapeViewModel quadraticBezier)
    {
        var geometry = Factory.CreateStreamGeometry();
        using var context = geometry.Open();
        context.BeginFigure(
            quadraticBezier.Point1.ToPoint(),
            quadraticBezier.IsFilled);
        context.QuadraticBezierTo(
            quadraticBezier.Point2.ToPoint(),
            quadraticBezier.Point3.ToPoint());
        context.EndFigure(false);
        return geometry;
    }
}
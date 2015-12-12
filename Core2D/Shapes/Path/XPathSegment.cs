﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Core2D
{
    /// <summary>
    /// Base class for <see cref="XPathFigure"/> segments.
    /// </summary>
    public abstract class XPathSegment
    {
        /// <summary>
        /// Gets or sets flag indicating whether segment is stroked.
        /// </summary>
        public bool IsStroked { get; set; }

        /// <summary>
        /// Gets or sets flag indicating whether segment is smooth join.
        /// </summary>
        public bool IsSmoothJoin { get; set; }
    }
}

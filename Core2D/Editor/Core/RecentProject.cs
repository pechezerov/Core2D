﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Core2D
{
    /// <summary>
    /// 
    /// </summary>
    public class RecentProject : ObservableObject
    {
        private string _name;
        private string _path;

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { Update(ref _name, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Path
        {
            get { return _path; }
            set { Update(ref _path, value); }
        }

        /// <summary>
        /// Creates a new <see cref="RecentProject"/> instance.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static RecentProject Create(string name, string path)
        {
            return new RecentProject()
            {
                Name = name,
                Path = path
            };
        }
    }
}

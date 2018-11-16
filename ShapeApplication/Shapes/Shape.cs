using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public abstract class Shape
    {
        public abstract string ShapeType { get; }
        public abstract Point point1 { get; set; }
        public abstract Point point2 { get; set; }
        public abstract Point point3 { get; set; }
        public abstract int length { get; set; }
        public abstract int width { get; set; }
        public abstract string filepath { get; set; }

        public abstract override string ToString();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Shapes;

namespace FactoryShape
{
    public class TriangleFactory : ShapeFactory
    {
        private Point _point1;
        private Point _point2;
        private Point _point3;

        public TriangleFactory(Point point1, Point point2, Point point3)
        {
            _point1 = point1;
            _point2 = point2;
            _point3 = point3;
        }

        public override Shape GetShape()
        {
            return new Triangle(_point1, _point2, _point3);
        }
    }
}

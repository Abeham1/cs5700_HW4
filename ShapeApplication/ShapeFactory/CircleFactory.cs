using System;
using System.Collections.Generic;
using System.Text;
using Shapes;

namespace FactoryShape
{
    public class CircleFactory : ShapeFactory
    {
        private Point _center;
        private int _radius;

        public CircleFactory(Point center, int radius)
        {
            _center = center;
            _radius = radius;
        }

        public override Shape GetShape()
        {
            return new Circle(_center, _radius, _radius);
        }
    }
}

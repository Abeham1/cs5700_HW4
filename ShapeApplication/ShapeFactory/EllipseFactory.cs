using System;
using System.Collections.Generic;
using System.Text;
using Shapes;

namespace FactoryShape
{
    public class EllipseFactory : ShapeFactory
    {
        private Point _center;
        private int _radius1;
        private int _radius2;

        public EllipseFactory(Point center, int radius1, int radius2)
        {
            _center = center;
            _radius1 = radius1;
            _radius2 = radius2;
        }

        public override Shape GetShape()
        {
            return new Ellipse(_center, _radius1, _radius2);
        }
    }
}

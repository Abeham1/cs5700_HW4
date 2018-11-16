using System;
using System.Collections.Generic;
using System.Text;
using Shapes;

namespace FactoryShape
{
    public class RectangleFactory : ShapeFactory
    {
        private Point _corner;
        private int _length;
        private int _width;

        public RectangleFactory(Point corner, int length, int width)
        {
            _corner = corner;
            _length = length;
            _width = width;
        }

        public override Shape GetShape()
        {
            return new Rectangle(_corner, _length, _width);
        }
    }
}

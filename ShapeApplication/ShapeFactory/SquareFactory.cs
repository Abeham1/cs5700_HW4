using System;
using System.Collections.Generic;
using System.Text;
using Shapes;

namespace FactoryShape
{
    public class SquareFactory : ShapeFactory
    {
        private Point _corner;
        private int _length;

        public SquareFactory(Point corner, int length)
        {
            _corner = corner;
            _length = length;
        }

        public override Shape GetShape()
        {
            return new Square(_corner, _length, _length);
        }
    }
}

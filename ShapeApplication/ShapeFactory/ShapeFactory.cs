using System;
using Shapes;

namespace FactoryShape
{
    public abstract class ShapeFactory
    {
        public abstract Shape GetShape();
    }
}

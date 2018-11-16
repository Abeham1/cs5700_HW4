using System;
using System.Collections.Generic;
using System.Text;
using Shapes;

namespace FactoryShape
{
    public class CompositeImageFactory : ShapeFactory
    {
        private string _filepath;

        public CompositeImageFactory(string filepath)
        {
            _filepath = filepath;
        }

        public override Shape GetShape()
        {
            return new CompositeImage(_filepath);
        }
    }
}

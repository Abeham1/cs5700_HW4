using System;
using System.Collections.Generic;
using System.Text;
using Shapes;

namespace FactoryShape
{
    public class EmbeddedPicFactory : ShapeFactory
    {
        private Point _center;
        private int _radius1;
        private int _radius2;
        private string _filepath;

        public EmbeddedPicFactory(Point center, int radius1, int radius2, string filepath)
        {
            _center = center;
            _radius1 = radius1;
            _radius2 = radius2;
            _filepath = filepath;
        }

        public override Shape GetShape()
        {
            return new EmbeddedImage(_center, _radius1, _radius2, _filepath);
        }
    }
}

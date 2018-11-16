using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square : Rectangle
    {
        private readonly string _shapeType;
        private Point _point1;
        private Point _point2 = null;
        private Point _point3 = null;
        private int _length;
        private int _width;
        private string _filepath = "";

        public Square(Point point1, int length, int width) : base(point1, length, width)
        {
            _point1 = point1;
            _length = length;
            _width = width;
            _shapeType = "Square";
        }

        public override string ShapeType
        {
            get { return _shapeType; }
        }

        public override string ToString()
        {
            return "Square," + _point1.X.ToString() + "," + _point1.Y.ToString() + "," + _length.ToString();
        }
    }
}
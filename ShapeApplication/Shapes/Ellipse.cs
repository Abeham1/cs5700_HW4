using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Ellipse : Shape
    {
        private readonly string _shapeType;
        private Point _point1;
        private Point _point2 = null;
        private Point _point3 = null;
        private int _length;
        private int _width;
        private string _filepath = "";

        public Ellipse(Point point1, int length, int width)
        {
            if (Math.PI * length * width == 0)
                throw new ShapeException("Invalid Shape!");

            Validator.ValidatePositiveint(length, "Invalid radius");
            Validator.ValidatePositiveint(width, "Invalid radius");
            _point1 = point1;
            _length = length;
            _width = width;
            _shapeType = "Ellipse";
        }

        public double CalculateArea()
        {
            return Math.PI * Convert.ToDouble(_length) * Convert.ToDouble(_width);
        }

        public void Move(int deltaX, int deltaY)
        {
            _point1.Move(deltaX, deltaY);
        }

        public override string ToString()
        {
            return "Ellipse," + _point1.X.ToString() + "," + _point1.Y.ToString() + "," + _length.ToString() + "," + _width.ToString();
        }

        public override string ShapeType
        {
            get { return _shapeType; }
        }
        public override Point point1
        {
            get { return _point1; }
            set { _point1 = value; }
        }
        public override Point point2
        {
            get { return null; }
            set { _point2 = null; }
        }
        public override Point point3
        {
            get { return null; }
            set { _point3 = null; }
        }
        public override int length
        {
            get { return _length; }
            set { _length = value; }
        }
        public override int width
        {
            get { return _width; }
            set { _width = value; }
        }
        public override string filepath
        {
            get { return ""; }
            set { _filepath = ""; }
        }
    }
}

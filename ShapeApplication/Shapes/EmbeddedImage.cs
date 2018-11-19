using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class EmbeddedImage : Shape
    {
        private readonly string _shapeType;
        private Point _point1;
        private Point _point2 = null;
        private Point _point3 = null;
        private int _length;
        private int _width;
        private string _filepath;

        public EmbeddedImage(Point point1, int length, int width, string filepath)
        {
            Validator.ValidatePositiveint(length, "Invalid radius");
            Validator.ValidatePositiveint(width, "Invalid radius");
            _point1 = point1;
            _length = length;
            _width = width;
            _filepath = filepath;
            _shapeType = "Embedded Image";
        }

        public override void Move(int deltaX, int deltaY)
        {
            _point1.Move(deltaX, deltaY);
        } 

        public override string ToString()
        {
            return "Embedded Image," + _point1.X.ToString() + "," + _point1.Y.ToString() + "," + _length.ToString() + "," + _width.ToString() + "," + _filepath;
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
            get { return _filepath; }
            set { _filepath = value; }
        }
    }
}

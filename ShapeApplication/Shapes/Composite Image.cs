using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class CompositeImage : Shape
    {
        private readonly string _shapeType;
        private Point _point1 = null;
        private Point _point2 = null;
        private Point _point3 = null;
        private int _length = 0;
        private int _width = 0;
        private string _filepath;
        private List<Shape> shapes;

        public override void Move(int deltaX, int deltaY)
        {
            _point1.Move(deltaX, deltaY);
        }

        public CompositeImage(string filepath)
        {
            shapes = new List<Shape>();
            _filepath = filepath;
            _shapeType = "Embedded Image";
        }

        public void addShape(Shape shape)
        {
            shapes.Add(shape);
        }

        public void removeShape(Shape shape)
        {
            foreach (Shape s in shapes)
            {
                if (s == shape)
                {
                    shapes.Remove(s);
                }
            }
        }

        public override string ToString()
        {
            return "Composite Image," + _filepath;
        }

        public override string ShapeType
        {
            get { return _shapeType; }
        }
        public override Point point1
        {
            get { return null; }
            set { _point1 = null; }
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
            get { return 0; }
            set { _length = 0; }
        }
        public override int width
        {
            get { return 0; }
            set { _width = 0; }
        }
        public override string filepath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }
    }
}

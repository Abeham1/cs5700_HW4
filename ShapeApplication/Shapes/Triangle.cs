using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shapes
{
    public class Triangle : Shape
    {
        private readonly string _shapeType;
        private Point _point1;
        private Point _point2;
        private Point _point3;
        private int _length = 0;
        private int _width = 0;
        private string _filepath = "";

        public Triangle(Point point1, Point point2, Point point3)
        {
            _point1 = point1;
            _point2 = point2;
            _point3 = point3;
            _shapeType = "Triangle";
        }

        public void Move(int deltaX, int deltaY)
        {
            _point1.Move(deltaX, deltaY);
            _point2.Move(deltaX, deltaY);
            _point3.Move(deltaX, deltaY);
        }

        public override string ToString()
        {
            return "Triangle," + _point1.X.ToString() + "," + _point1.Y.ToString() + "," + _point2.X.ToString() + "," + _point2.Y.ToString() + "," + _point3.X.ToString() + "," + _point3.Y.ToString();
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
            get { return _point2; }
            set { _point2 = value; }
        }
        public override Point point3
        {
            get { return _point3; }
            set { _point3 = value; }
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
            get { return ""; }
            set { _filepath = ""; }
        }
    }
}

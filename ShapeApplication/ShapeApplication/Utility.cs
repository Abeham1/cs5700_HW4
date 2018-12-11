using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;
using System.Drawing;
using System.Windows.Forms;
using FactoryShape;

namespace ShapeApplication
{
    public class Utility
    {
        List<Shape> shapeList;
        public enum shapeDesignation { CIRCLE, ELLIPSE, SQUARE, RECTANGLE, TRIANGLE, LINE, EMBEDDED_PIC, SELECT, ERASE };
        public shapeDesignation designation { get; set; }
        public string embeddedPicFilepath;

        public Utility(List<Shape> shapes)
        {
            shapeList = shapes;
            designation = shapeDesignation.LINE;
            embeddedPicFilepath = "";
        }

        public Shape readShape(string shapeText)
        {
            List<string> shapeDetails = shapeText.Split(',').ToList();
            switch (shapeDetails[0])
            {
                case "Circle":
                    return (new Circle(new Shapes.Point(Int32.Parse(shapeDetails[1]), Int32.Parse(shapeDetails[2])), Int32.Parse(shapeDetails[3]), Int32.Parse(shapeDetails[3])));
                case "Ellipse":
                    return (new Ellipse(new Shapes.Point(Int32.Parse(shapeDetails[1]), Int32.Parse(shapeDetails[2])), Int32.Parse(shapeDetails[3]), Int32.Parse(shapeDetails[4])));
                case "Rectangle":
                    return (new Shapes.Rectangle(new Shapes.Point(Int32.Parse(shapeDetails[1]), Int32.Parse(shapeDetails[2])), Int32.Parse(shapeDetails[3]), Int32.Parse(shapeDetails[4])));
                case "Square":
                    return (new Square(new Shapes.Point(Int32.Parse(shapeDetails[1]), Int32.Parse(shapeDetails[2])), Int32.Parse(shapeDetails[3]), Int32.Parse(shapeDetails[3])));
                case "Triangle":
                    return (new Triangle(new Shapes.Point(Int32.Parse(shapeDetails[1]), Int32.Parse(shapeDetails[2])), new Shapes.Point(Int32.Parse(shapeDetails[3]), Int32.Parse(shapeDetails[4])), new Shapes.Point(Int32.Parse(shapeDetails[5]), Int32.Parse(shapeDetails[6]))));
                case "Embedded Image":
                    return (new EmbeddedImage(new Shapes.Point(Int32.Parse(shapeDetails[1]), Int32.Parse(shapeDetails[2])), Int32.Parse(shapeDetails[3]), Int32.Parse(shapeDetails[4]), shapeDetails[5]));
            }
            return null;
        }

        public Shape getShape(int initialX, int initialY, int secondaryX, int secondaryY, bool add)
        {
            if (designation == shapeDesignation.EMBEDDED_PIC)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string file = openFileDialog1.FileName;
                    Console.WriteLine(openFileDialog1.FileName);
                    embeddedPicFilepath = openFileDialog1.FileName;
                }
            }
            ShapeFactory factory = null;
            switch (designation)
            {
                case shapeDesignation.CIRCLE:
                    Shapes.Point CirclePoint = new Shapes.Point(Math.Min(initialX, secondaryX), Math.Min(initialY, secondaryY));
                    factory = new CircleFactory(CirclePoint, Math.Abs(secondaryX - initialX));
                    break;
                case shapeDesignation.ELLIPSE:
                    Shapes.Point EllipsePoint = new Shapes.Point(Math.Min(initialX, secondaryX), Math.Min(initialY, secondaryY));
                    factory = new EllipseFactory(EllipsePoint, Math.Abs(secondaryY - initialY), Math.Abs(secondaryX - initialX));
                    break;
                case shapeDesignation.RECTANGLE:
                    Shapes.Point RectanglePoint = new Shapes.Point(Math.Min(initialX, secondaryX), Math.Min(initialY, secondaryY));
                    factory = new RectangleFactory(RectanglePoint, Math.Abs(secondaryY - initialY), Math.Abs(secondaryX - initialX));
                    break;
                case shapeDesignation.SQUARE:
                    Shapes.Point SquarePoint = new Shapes.Point(Math.Min(initialX, secondaryX), Math.Min(initialY, secondaryY));
                    factory = new SquareFactory(SquarePoint, Math.Abs(secondaryX - initialX));
                    break;
                case shapeDesignation.TRIANGLE:
                    //TODO: Figure out rectangular triangle drawing
                    //Shapes.Point TriPoint1 = new Shapes.Point(Int32.Parse(txtPoint1X.Text), Int32.Parse(txtPoint1Y.Text));
                    //Shapes.Point TriPoint2 = new Shapes.Point(Int32.Parse(txtPoint2X.Text), Int32.Parse(txtPoint2Y.Text));
                    //Shapes.Point TriPoint3 = new Shapes.Point(Int32.Parse(txtPoint3X.Text), Int32.Parse(txtPoint3Y.Text));
                    //factory = new TriangleFactory(TriPoint1, TriPoint2, TriPoint3);
                    break;
                case shapeDesignation.EMBEDDED_PIC:
                    Shapes.Point EmbeddedPoint = new Shapes.Point(Math.Min(initialX, secondaryX), Math.Min(initialY, secondaryY));
                    factory = new EmbeddedPicFactory(EmbeddedPoint, Math.Abs(secondaryX - initialX), Math.Abs(secondaryY - initialY), embeddedPicFilepath);
                    break;
                case shapeDesignation.LINE:
                    //TODO: Create Line in shapes
                    break;
                default:
                    return null;
            }
            Shape shape = factory.GetShape();
            if (add)
            {
                addToList(shape);
            }
            return shape;
        }

        private void addToList(Shape shape)
        {
            shapeList.Add(shape);
        }
    }
}

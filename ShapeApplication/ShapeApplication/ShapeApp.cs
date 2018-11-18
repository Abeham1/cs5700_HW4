using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SelectShape;
using Shapes;
using FactoryShape;

namespace ShapeApplication
{
    public partial class ShapeApp : Form
    {
        //TODO: Figure out how to select, move, and delete a shape
        //TODO: Save, Save As, and open
        //TODO: Why is the previous shape deleted each time a new shape is drawn?
        public string embeddedPicFilepath;
        private System.Drawing.Graphics graphicsObj;
        private Pen pen;
        private enum shapeDesignation {CIRCLE, ELLIPSE, SQUARE, RECTANGLE, TRIANGLE, LINE, EMBEDDED_PIC};
        private shapeDesignation designation;
        private bool isDown;
        int initialX;
        int initialY;
        int secondaryX;
        int secondaryY;

        /* CONSTRUCTOR =================================================================*/
        public ShapeApp()
        {
            InitializeComponent();
            graphicsObj = this.CreateGraphics();
            pen = new Pen(System.Drawing.Color.Black, 5);
            designation = shapeDesignation.LINE;
            btnLine.BackColor = Color.Aquamarine;
            isDown = false;
            initialX = 0;
            initialY = 0;
            secondaryX = 0;
            secondaryY = 0;
        }

        private void ShapeApp_Load(object sender, EventArgs e)
        {

        }
        //================================================================================

        //private void btnAddShape_Click(object sender, EventArgs e)
        //{
        //    shapeSelectForm = new ShapeSelect();
        //    shapeSelectForm.ShowDialog();
        //    Shape shape = shapeSelectForm.shapeToDraw;
        //    shapeList.Add(shape);
        //    renderShape(shape);
        //    Console.WriteLine("Shape details:");
        //    Console.WriteLine("Shape Type: " + shape.ShapeType);
        //    Console.WriteLine("X: " + shape.point1.X.ToString());
        //    Console.WriteLine("Y: " + shape.point1.Y.ToString());
        //    Console.WriteLine("Length: " + shape.length.ToString());
        //    Console.WriteLine("Width: " + shape.width.ToString());
        //}

        //private void btnSaveShapeToScript_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog save = new SaveFileDialog();
        //    save.FileName = "Shape" + counter.ToString() + ".txt";
        //    save.Filter = "Text File | *.txt";
        //    if(save.ShowDialog() == DialogResult.OK)
        //    {
        //        CompositeImage ci = new CompositeImage(save.FileName);
        //        StreamWriter writer = new StreamWriter(save.OpenFile());
        //        for(int i = 0; i < shapeList.Count(); i++)
        //        {
        //            writer.WriteLine(shapeList[i].ToString());
        //            ci.addShape(shapeList[i]);
        //        }
        //        writer.Dispose();
        //        writer.Close();
        //    }
        //}

        //private void btnLoadShapeFromScript_Click(object sender, EventArgs e)
        //{ 
        //    int count = 0;
        //    string line;
        //    string filepath = "";
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //    DialogResult result = openFileDialog1.ShowDialog();
        //    if (result == DialogResult.OK)
        //    { 
        //        filepath = openFileDialog1.FileName;
        //    }
        //    if(filepath != "")
        //    {
        //        System.IO.StreamReader file = new System.IO.StreamReader(filepath);
        //        while ((line = file.ReadLine()) != null)
        //        {
        //            shapeList.Add(readShape(line));
        //            count++;
        //        }

        //        file.Close();
        //    }

        //    renderShapeList();
        //}

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

       
        //==========================================================================================

        /* Change Designation and update visual buttons ======================================= */
        private void btnEllipse_Click(object sender, EventArgs e)
        {
            nullColors();
            btnEllipse.BackColor = Color.Aquamarine;
            designation = shapeDesignation.ELLIPSE;
            updateTxtDesignation();
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            nullColors();
            btnCircle.BackColor = Color.Aquamarine;
            designation = shapeDesignation.CIRCLE;
            updateTxtDesignation();
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            nullColors();
            btnSquare.BackColor = Color.Aquamarine;
            designation = shapeDesignation.SQUARE;
            updateTxtDesignation();
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            nullColors();
            btnRectangle.BackColor = Color.Aquamarine;
            designation = shapeDesignation.RECTANGLE;
            updateTxtDesignation();
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            nullColors();
            btnTriangle.BackColor = Color.Aquamarine;
            designation = shapeDesignation.TRIANGLE;
            updateTxtDesignation();
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            nullColors();
            btnLine.BackColor = Color.Aquamarine;
            designation = shapeDesignation.LINE;
            updateTxtDesignation();
        }

        private void btnEmbeddedPic_Click(object sender, EventArgs e)
        {
            nullColors();
            btnEmbeddedPic.BackColor = Color.Aquamarine;
            designation = shapeDesignation.EMBEDDED_PIC;
            updateTxtDesignation();
        }

        private void nullColors()
        {
            btnCircle.BackColor = Color.White;
            btnEllipse.BackColor = Color.White;
            btnSquare.BackColor = Color.White;
            btnRectangle.BackColor = Color.White;
            btnEmbeddedPic.BackColor = Color.White;
            btnTriangle.BackColor = Color.White;
            btnLine.BackColor = Color.White;
        }

        private void updateTxtDesignation()
        {
            txtDesignation.Text = "Currently drawing: " + designation.ToString();
        }
        //==========================================================================================

        /* Draw shape ==============================================================================*/
        private void ShapeApp_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            initialX = e.X;
            initialY = e.Y;
        }

        private void ShapeApp_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown && designation != shapeDesignation.LINE)
            {
                Refresh();
                secondaryX = e.X;
                secondaryY = e.Y;
            }
        }

        private void ShapeApp_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
            drawShape();
        }

        private void drawShape()
        {
            if(designation == shapeDesignation.EMBEDDED_PIC)
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
                    factory = new EllipseFactory(EllipsePoint,Math.Abs(secondaryY - initialY), Math.Abs(secondaryX - initialX));
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
            }
            Shape shape = factory.GetShape();
            renderShape(shape);
        }

        private void renderShape(Shape shape)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(0, 0, 0, 0);

            switch (shape.ShapeType)
            {
                case "Circle":
                case "Ellipse":
                    rectangle = new System.Drawing.Rectangle(shape.point1.X, shape.point1.Y, shape.width, shape.length);
                    graphicsObj.DrawEllipse(pen, rectangle);
                    break;
                case "Rectangle":
                case "Square":
                    rectangle = new System.Drawing.Rectangle(shape.point1.X, shape.point1.Y, shape.width, shape.length);
                    graphicsObj.DrawRectangle(pen, rectangle);
                    break;
                case "Triangle":
                    System.Drawing.Point[] points =
                    {
                        new System.Drawing.Point(shape.point1.X, shape.point1.Y),
                        new System.Drawing.Point(shape.point2.X, shape.point2.Y),
                        new System.Drawing.Point(shape.point3.X, shape.point3.Y)
                    };
                    graphicsObj.DrawPolygon(pen, points);
                    break;
                case "Embedded Image":
                    Image image = new Bitmap(shape.filepath);
                    TextureBrush tBrush = new TextureBrush(image);
                    graphicsObj.FillRectangle(tBrush, new System.Drawing.Rectangle(shape.point1.X, shape.point1.Y, shape.width, shape.length));
                    break;
            }
        }
        //============================================================================================

        /* Command Pattern =========================================================================*/
        private void btnUndo_Click(object sender, EventArgs e)
        {
            //TODO: Add undo functionality
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            //TODO: Add redo functionality
        }
        //============================================================================================
    }


}

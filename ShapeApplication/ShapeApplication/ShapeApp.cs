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

namespace ShapeApplication
{
    public partial class ShapeApp : Form
    {
        private int counter;
        private ShapeSelect shapeSelectForm;
        private List<Shape> shapeList;
        private System.Drawing.Graphics graphicsObj;
        private Pen pen;

        public ShapeApp()
        {
            counter = 0;
            shapeList = new List<Shape>();
            InitializeComponent();
            graphicsObj = this.CreateGraphics();
            pen = new Pen(System.Drawing.Color.Black, 5);
        }

        private void ShapeApp_Load(object sender, EventArgs e)
        {

        }

        private void btnAddShape_Click(object sender, EventArgs e)
        {
            shapeSelectForm = new ShapeSelect();
            shapeSelectForm.ShowDialog();
            Shape shape = shapeSelectForm.shapeToDraw;
            shapeList.Add(shape);
            renderShape(shape);
            Console.WriteLine("Shape details:");
            Console.WriteLine("Shape Type: " + shape.ShapeType);
            Console.WriteLine("X: " + shape.point1.X.ToString());
            Console.WriteLine("Y: " + shape.point1.Y.ToString());
            Console.WriteLine("Length: " + shape.length.ToString());
            Console.WriteLine("Width: " + shape.width.ToString());
        }

        private void btnSaveShapeToScript_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Shape" + counter.ToString() + ".txt";
            save.Filter = "Text File | *.txt";
            if(save.ShowDialog() == DialogResult.OK)
            {
                CompositeImage ci = new CompositeImage(save.FileName);
                StreamWriter writer = new StreamWriter(save.OpenFile());
                for(int i = 0; i < shapeList.Count(); i++)
                {
                    writer.WriteLine(shapeList[i].ToString());
                    ci.addShape(shapeList[i]);
                }
                writer.Dispose();
                writer.Close();
            }
        }

        private void btnLoadShapeFromScript_Click(object sender, EventArgs e)
        { 
            int count = 0;
            string line;
            string filepath = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            { 
                filepath = openFileDialog1.FileName;
            }
            if(filepath != "")
            {
                System.IO.StreamReader file = new System.IO.StreamReader(filepath);
                while ((line = file.ReadLine()) != null)
                {
                    shapeList.Add(readShape(line));
                    count++;
                }

                file.Close();
            }

            renderShapeList();
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
                //case "Composite Image":
                //    //TODO: Add composite to shapeList
                //    break;
                case "Embedded Image":
                    return (new EmbeddedImage(new Shapes.Point(Int32.Parse(shapeDetails[1]), Int32.Parse(shapeDetails[2])), Int32.Parse(shapeDetails[3]), Int32.Parse(shapeDetails[4]), shapeDetails[5]));
            }
            return null;
        }

        private void renderShapeList()
        {
            //TODO: Each time a method edits the shapeList, rerender the graphics
            for (int i = 0; i < shapeList.Count(); i++)
            {
                renderShape(shapeList[i]);
            }
            //System.Drawing.Rectangle myRectangle = new System.Drawing.Rectangle(0, 0, 100, 100);
            //graphicsObj.DrawRectangle(myPen, myRectangle);
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

        private void btnDeleteShape_Click(object sender, EventArgs e)
        {
            graphicsObj.Clear(Color.White);
        }
    }


}

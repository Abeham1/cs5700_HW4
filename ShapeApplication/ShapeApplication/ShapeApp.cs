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
using Shapes;
using FactoryShape;
using CommandPattern;

namespace ShapeApplication
{
    public partial class ShapeApp : Form
    {
        public List<Shape> shapeList;
        public List<Command> commandList;
        private int currentCommand;
        int counter;
        public string embeddedPicFilepath;
        private System.Drawing.Graphics graphicsObj;
        private Pen pen;
        private Pen selectionPen;
        private enum shapeDesignation {CIRCLE, ELLIPSE, SQUARE, RECTANGLE, TRIANGLE, LINE, EMBEDDED_PIC, SELECT, ERASE};
        private shapeDesignation designation;
        private bool isDown;
        private bool selection;
        private bool selectionRectangleInList;
        int initialX;
        int initialY;
        int secondaryX;
        int secondaryY;
        bool saved;
        private string saveFilepath;

        /* CONSTRUCTOR =================================================================*/
        public ShapeApp()
        {
            currentCommand = 0;
            shapeList = new List<Shape>();
            commandList = new List<Command>();
            InitializeComponent();
            graphicsObj = this.CreateGraphics();
            pen = new Pen(System.Drawing.Color.Black, 5);
            selectionPen = new Pen(System.Drawing.Color.Black, 3);
            selectionPen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
            selection = false;
            selectionRectangleInList = false;
            designation = shapeDesignation.LINE;
            btnLine.BackColor = Color.Aquamarine;
            isDown = false;
            initialX = 0;
            initialY = 0;
            secondaryX = 0;
            secondaryY = 0;
            counter = 0;
            saved = false;
            saveFilepath = "";
        }

        private void ShapeApp_Load(object sender, EventArgs e)
        {

        }
        //================================================================================

        /* Utilities =============================================================================*/

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

        private void renderShapeList()
        {
            for (int i = 0; i < shapeList.Count(); i++)
            {
                if(i == shapeList.Count() - 1 && selection)
                {
                    renderShape(shapeList[i], true);
                }
                else
                {
                    renderShape(shapeList[i], false);
                }
            }
        }

        private void clearShapes()
        {
            graphicsObj.Clear(Color.White);
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            nullColors();
            btnSelect.BackColor = Color.Aquamarine;
            designation = shapeDesignation.SELECT;
            updateTxtDesignation();
        }

        private void btnEraser_Click(object sender, EventArgs e)
        {
            nullColors();
            btnEraser.BackColor = Color.Aquamarine;
            designation = shapeDesignation.ERASE;
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
            btnSelect.BackColor = Color.White;
            btnEraser.BackColor = Color.White;
        }

        private void updateTxtDesignation()
        {
            if (designation != shapeDesignation.SELECT && designation != shapeDesignation.ERASE)
                txtDesignation.Text = "Currently drawing: " + designation.ToString();
            else
                txtDesignation.Text = "Select";
        }
        //==========================================================================================

        /* Draw shape ==============================================================================*/
        private void ShapeApp_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            selection = true;
            initialX = e.X;
            initialY = e.Y;
        }

        private void ShapeApp_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown && designation != shapeDesignation.LINE && designation != shapeDesignation.ERASE)
            {
                secondaryX = e.X;
                secondaryY = e.Y;
                if (secondaryX != initialX && secondaryY != initialY && designation != shapeDesignation.SELECT)
                {
                    Shapes.Point RectanglePoint = new Shapes.Point(Math.Min(initialX, secondaryX), Math.Min(initialY, secondaryY));
                    ShapeFactory factory = new RectangleFactory(RectanglePoint, Math.Abs(secondaryY - initialY), Math.Abs(secondaryX - initialX));
                    Shape shape = factory.GetShape();
                    if (selection == true && selectionRectangleInList == false)
                    {
                        shapeList.Add(shape);
                        selectionRectangleInList = true;
                    }
                    else
                    {
                        shapeList[shapeList.Count - 1] = shape;
                    }
                    clearShapes();
                    renderShapeList();
                }
            }
            //Todo: create marching ant rectangle and insert at end of shapelist. With each movement, replace that shape and redraw the shapelist. Have the resultant shape replace the marching ants.

        }

        private void ShapeApp_MouseUp(object sender, MouseEventArgs e)
        {
            if(designation != shapeDesignation.SELECT && designation != shapeDesignation.ERASE)
            {
                isDown = false;
                selection = false;
                selectionRectangleInList = false;
                if (shapeList.Any())
                {
                    shapeList.RemoveAt(shapeList.Count - 1);
                }
                drawShape();
            }
            if (designation == shapeDesignation.SELECT)
            {
                int counter = 0;
                foreach(Shape shape in shapeList)
                {
                    Command command = new Command(Command.commandType.MOVE);
                    switch (shape.ShapeType)
                    {
                        case "Circle":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.width)
                            {
                                command.preAction = shapeList[counter];
                                shapeList[counter].Move(secondaryX - initialX, secondaryY - initialY);
                                command.shapeListPosition = counter;
                                command.postAction = shapeList[counter];
                                command.deltaX = secondaryX - initialX;
                                command.deltaY = secondaryY - initialY;
                                commandList.Add(command);
                                currentCommand++;
                            }
                            else
                                counter++;
                            break;
                        case "Ellipse":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.length)
                            {
                                command.preAction = shapeList[counter];
                                shapeList[counter].Move(secondaryX - initialX, secondaryY - initialY);
                                command.shapeListPosition = counter;
                                command.postAction = shapeList[counter];
                                command.deltaX = secondaryX - initialX;
                                command.deltaY = secondaryY - initialY;
                                commandList.Add(command);
                                currentCommand++;
                            }
                            else
                                counter++;
                            break;
                        case "Rectangle":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.length)
                            {
                                command.preAction = shapeList[counter];
                                shapeList[counter].Move(secondaryX - initialX, secondaryY - initialY);
                                command.shapeListPosition = counter;
                                command.postAction = shapeList[counter];
                                command.deltaX = secondaryX - initialX;
                                command.deltaY = secondaryY - initialY;
                                commandList.Add(command);
                                currentCommand++;
                            }
                            else
                                counter++;
                            break;
                        case "Square":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.width)
                            {
                                command.preAction = shapeList[counter];
                                shapeList[counter].Move(secondaryX - initialX, secondaryY - initialY);
                                command.shapeListPosition = counter;
                                command.postAction = shapeList[counter];
                                command.deltaX = secondaryX - initialX;
                                command.deltaY = secondaryY - initialY;
                                commandList.Add(command);
                                currentCommand++;
                            }
                            else
                                counter++;
                            break;
                        case "Triangle":
                            break;
                        case "Embedded Image":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.length)
                            {
                                command.preAction = shapeList[counter];
                                shapeList[counter].Move(secondaryX - initialX, secondaryY - initialY);
                                command.shapeListPosition = counter;
                                command.postAction = shapeList[counter];
                                command.deltaX = secondaryX - initialX;
                                command.deltaY = secondaryY - initialY;
                                commandList.Add(command);
                                currentCommand++;
                            }
                            else
                                counter++;
                            break;
                        case "Line":
                            break;
                        default:
                            counter++;
                            break;
                    }
                }
                clearShapes();
                renderShapeList();
            }
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
            //renderShape(shape, false);
            shapeList.Add(shape);
            clearShapes();
            renderShapeList();
            Command command = new Command(Command.commandType.DRAW);
            command.postAction = shape;
            command.preAction = null;
            command.shapeListPosition = shapeList.IndexOf(shape);
            commandList.Add(command);
            currentCommand++;
        }

        private void renderShape(Shape shape, bool select)
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
                    if (select)
                    {
                        graphicsObj.DrawRectangle(selectionPen, rectangle);
                    }
                    else
                    {
                        graphicsObj.DrawRectangle(pen, rectangle);
                    }
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
            Command command = commandList[currentCommand - 1];
            switch (command.type)
            {
                case Command.commandType.DRAW:
                    shapeList.RemoveAt(command.shapeListPosition);
                    clearShapes();
                    renderShapeList();
                    break;
                case Command.commandType.MOVE:
                    shapeList[command.shapeListPosition].Move(command.deltaX * -1, command.deltaY * -1);
                    clearShapes();
                    renderShapeList();
                    break;
                case Command.commandType.ERASE:
                    shapeList.Add(command.preAction);
                    commandList[currentCommand - 1].shapeListPosition = shapeList.Count - 1;
                    clearShapes();
                    renderShapeList();
                    break;
                default:
                    break;
            }
            currentCommand--;
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            Command command = commandList[currentCommand];
            switch (command.type) 
                {
                case Command.commandType.DRAW:
                    shapeList.Add(command.postAction);
                    clearShapes();
                    renderShapeList();
                    break;
                case Command.commandType.MOVE:
                    shapeList[command.shapeListPosition].Move(command.deltaX, command.deltaY);
                    clearShapes();
                    renderShapeList();
                    break;
                case Command.commandType.ERASE:
                    shapeList.Remove(command.preAction);
                    clearShapes();
                    renderShapeList();
                    break;
                default:
                    break;
            }
            currentCommand++;
        }
        //============================================================================================

        /* Manipulate Shapes ========================================================================*/
        private void ShapeApp_Click(object sender, EventArgs e)
        {
            if(designation == shapeDesignation.ERASE)
            {
                Shape shape;
                Command command = new Command(Command.commandType.ERASE);
                string type = "";
                int counter = 0;
                while (counter < shapeList.Count + 1) {
                    if (counter < shapeList.Count)
                    {
                        shape = shapeList[counter];
                        type = shape.ShapeType;
                    }
                    else
                    {
                        shape = null;
                        type = "";
                    }
                        
                    switch (type)
                    {
                        case "Circle":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.width)
                            {
                                command.preAction = shape;
                                command.shapeListPosition = shapeList.IndexOf(shape);
                                shapeList.Remove(shape);
                                command.postAction = null;
                                commandList.Add(command);
                                currentCommand++;
                            }
                            else
                                counter++;
                            break;
                        case "Ellipse":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.length)
                            {
                                command.preAction = shape;
                                command.shapeListPosition = shapeList.IndexOf(shape);
                                shapeList.Remove(shape);
                                command.postAction = null;
                                commandList.Add(command);
                                currentCommand++;
                            }
                            else
                                counter++;
                            break;
                        case "Rectangle":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.length)
                            {
                                command.preAction = shape;
                                command.shapeListPosition = shapeList.IndexOf(shape);
                                shapeList.Remove(shape);
                                command.postAction = null;
                                commandList.Add(command);
                                currentCommand++;
                            }
                            else
                                counter++;
                            break;
                        case "Square":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.width)
                            {
                                command.preAction = shape;
                                command.shapeListPosition = shapeList.IndexOf(shape);
                                shapeList.Remove(shape);
                                command.postAction = null;
                                commandList.Add(command);
                                currentCommand++;
                            }
                            else
                                counter++;
                            break;
                        case "Triangle":
                            //TODO: Erase Triangle
                            break;
                        case "Embedded Image":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.length)
                            {
                                command.preAction = shape;
                                command.shapeListPosition = shapeList.IndexOf(shape);
                                shapeList.Remove(shape);
                                command.postAction = null;
                                commandList.Add(command);
                                currentCommand++;
                            }
                            else
                                counter++;
                            break;
                        case "Line":
                            //TODO: Erase Line
                            break;
                        default:
                            counter++;
                            break;
                    }
                }
                clearShapes();
                renderShapeList();
            }
        }
        //============================================================================================

        /* Save Functions ============================================================================*/
        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (!saved)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "Shape" + counter.ToString() + ".txt";
                save.Filter = "Text File | *.txt";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    CompositeImage ci = new CompositeImage(save.FileName);
                    saveFilepath = save.FileName;
                    StreamWriter writer = new StreamWriter(save.OpenFile());
                    for (int i = 0; i < shapeList.Count(); i++)
                    {
                        writer.WriteLine(shapeList[i].ToString());
                        ci.addShape(shapeList[i]);
                    }
                    writer.Dispose();
                    writer.Close();
                    counter++;
                    saved = true;
                }
            }
            else
            {
                CompositeImage ci = new CompositeImage(saveFilepath);
                using (StreamWriter writer = File.AppendText(saveFilepath))
                {
                    for (int i = 0; i < shapeList.Count(); i++)
                    {
                        writer.WriteLine(shapeList[i].ToString());
                        ci.addShape(shapeList[i]);
                    }
                    writer.Dispose();
                    writer.Close();
                }
            }
        }

        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Shape" + counter.ToString() + ".txt";
            save.Filter = "Text File | *.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                CompositeImage ci = new CompositeImage(save.FileName);
                saveFilepath = save.FileName;
                StreamWriter writer = new StreamWriter(save.OpenFile());
                for (int i = 0; i < shapeList.Count(); i++)
                {
                    writer.WriteLine(shapeList[i].ToString());
                    ci.addShape(shapeList[i]);
                }
                writer.Dispose();
                writer.Close();
                counter++;
                saved = true;
            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            if (!saved)
            {
                if(MessageBox.Show("You haven't saved your work yet. Proceed?", "Confirm", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    openFile();
                }
            }
            else
            {
                openFile();
            }
        }

        private void openFile()
        {
            clearShapes();
            int count = 0;
            string line;
            string filepath = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;
            }
            if (filepath != "")
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
        //===============================================================================================
    }


}

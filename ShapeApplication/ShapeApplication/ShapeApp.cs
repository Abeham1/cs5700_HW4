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

namespace ShapeApplication
{
    public partial class ShapeApp : Form
    {
        public Commander commander;
        public Utility utility;
        public List<Shape> shapeList;
        public FileManager fileManager;
        int counter;
        private System.Drawing.Graphics graphicsObj;
        private Pen pen;
        private bool isDown;
        private bool selection;
        private bool selectionRectangleInList;
        int initialX;
        int initialY;
        int secondaryX;
        int secondaryY;


        #region Constructors
        /* CONSTRUCTOR =================================================================*/
        public ShapeApp()
        {
            shapeList = new List<Shape>();
            commander = new Commander(shapeList);
            utility = new Utility(shapeList);
            fileManager = new FileManager(shapeList);
            InitializeComponent();
            graphicsObj = this.CreateGraphics();
            pen = new Pen(System.Drawing.Color.Black, 5);
            selection = false;
            selectionRectangleInList = false;
            btnLine.BackColor = Color.Aquamarine;
            isDown = false;
            initialX = 0;
            initialY = 0;
            secondaryX = 0;
            secondaryY = 0;
            counter = 0;
        }

        private void ShapeApp_Load(object sender, EventArgs e)
        {

        }
        //================================================================================
        #endregion

        #region Canvas Maintenance
        /* Utilities =============================================================================*/

        private void renderShapeList()
        {
            for (int i = 0; i < shapeList.Count(); i++)
            {
                renderShape(shapeList[i], false);
            }
        }

        private void clearShapes()
        {
            graphicsObj.Clear(Color.White);
        }
        //==========================================================================================
        #endregion

        #region Toolbar Buttons
        /* Change Designation and update visual buttons ======================================= */
        private void btnEllipse_Click(object sender, EventArgs e)
        {
            nullColors();
            btnEllipse.BackColor = Color.Aquamarine;
            utility.designation = Utility.shapeDesignation.ELLIPSE;
            updateTxtDesignation();
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            nullColors();
            btnCircle.BackColor = Color.Aquamarine;
            utility.designation = Utility.shapeDesignation.CIRCLE;
            updateTxtDesignation();
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            nullColors();
            btnSquare.BackColor = Color.Aquamarine;
            utility.designation = Utility.shapeDesignation.SQUARE;
            updateTxtDesignation();
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            nullColors();
            btnRectangle.BackColor = Color.Aquamarine;
            utility.designation = Utility.shapeDesignation.RECTANGLE;
            updateTxtDesignation();
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            nullColors();
            btnTriangle.BackColor = Color.Aquamarine;
            utility.designation = Utility.shapeDesignation.TRIANGLE;
            updateTxtDesignation();
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            nullColors();
            btnLine.BackColor = Color.Aquamarine;
            utility.designation = Utility.shapeDesignation.LINE;
            updateTxtDesignation();
        }

        private void btnEmbeddedPic_Click(object sender, EventArgs e)
        {
            nullColors();
            btnEmbeddedPic.BackColor = Color.Aquamarine;
            utility.designation = Utility.shapeDesignation.EMBEDDED_PIC;
            updateTxtDesignation();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            nullColors();
            btnSelect.BackColor = Color.Aquamarine;
            utility.designation = Utility.shapeDesignation.SELECT;
            updateTxtDesignation();
        }

        private void btnEraser_Click(object sender, EventArgs e)
        {
            nullColors();
            btnEraser.BackColor = Color.Aquamarine;
            utility.designation = Utility.shapeDesignation.ERASE;
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
            if (utility.designation != Utility.shapeDesignation.SELECT && utility.designation != Utility.shapeDesignation.ERASE)
                txtDesignation.Text = "Currently drawing: " + utility.designation.ToString();
            else
                txtDesignation.Text = "Select";
        }
        //==========================================================================================
        #endregion

        #region Draw Shapes
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
            if (isDown && utility.designation != Utility.shapeDesignation.LINE && utility.designation != Utility.shapeDesignation.ERASE)
            {
                secondaryX = e.X;
                secondaryY = e.Y;
                if (secondaryX != initialX && secondaryY != initialY && utility.designation != Utility.shapeDesignation.SELECT)
                {
                    Shape shape = utility.getShape(initialX, initialY, secondaryX, secondaryY, false);
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
        }

        private void ShapeApp_MouseUp(object sender, MouseEventArgs e)
        {
            if(utility.designation != Utility.shapeDesignation.SELECT && utility.designation != Utility.shapeDesignation.ERASE)
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
            if (utility.designation == Utility.shapeDesignation.SELECT)
            {
                int counter = 0;
                foreach(Shape shape in shapeList)
                {
                    switch (shape.ShapeType)
                    {
                        case "Circle":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.width)
                            {
                                commander.createCommand(Command.commandType.MOVE, shapeList[counter], null, counter, secondaryX - initialX, secondaryY - initialY);
                            }
                            else
                                counter++;
                            break;
                        case "Ellipse":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.length)
                            {
                                commander.createCommand(Command.commandType.MOVE, shapeList[counter], null, counter, secondaryX - initialX, secondaryY - initialY);
                            }
                            else
                                counter++;
                            break;
                        case "Rectangle":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.length)
                            {
                                commander.createCommand(Command.commandType.MOVE, shapeList[counter], null, counter, secondaryX - initialX, secondaryY - initialY);
                            }
                            else
                                counter++;
                            break;
                        case "Square":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.width)
                            {
                                commander.createCommand(Command.commandType.MOVE, shapeList[counter], null, counter, secondaryX - initialX, secondaryY - initialY);
                            }
                            else
                                counter++;
                            break;
                        case "Triangle":
                            break;
                        case "Embedded Image":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.length)
                            {
                                commander.createCommand(Command.commandType.MOVE, shapeList[counter], null, counter, secondaryX - initialX, secondaryY - initialY);
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
            Shape shape = utility.getShape(initialX, initialY, secondaryX, secondaryY, true);
            clearShapes();
            renderShapeList();
            commander.createCommand(Command.commandType.DRAW, null, shape, shapeList.IndexOf(shape), 0, 0);
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
        #endregion

        #region Command Pattern
        /* Command Pattern =========================================================================*/
        private void btnUndo_Click(object sender, EventArgs e)
        {
            string message = commander.Undo();
            if(message != null)
            {
                MessageBox.Show(message);
            }
            clearShapes();
            renderShapeList();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            string message = commander.Redo();
            if (message != null)
            {
                MessageBox.Show(message);
            }
            clearShapes();
            renderShapeList();
        }
        //============================================================================================
        #endregion

        #region Manipulate Shapes
        /* Manipulate Shapes ========================================================================*/
        private void ShapeApp_Click(object sender, EventArgs e)
        {
            if(utility.designation == Utility.shapeDesignation.ERASE)
            {
                Shape shape;
                
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
                                commander.createCommand(Command.commandType.ERASE, shape, null, shapeList.IndexOf(shape), 0, 0);
                                shapeList.Remove(shape);
                            }
                            else
                                counter++;
                            break;
                        case "Ellipse":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.length)
                            {
                                commander.createCommand(Command.commandType.ERASE, shape, null, shapeList.IndexOf(shape), 0, 0);
                                shapeList.Remove(shape);
                            }
                            else
                                counter++;
                            break;
                        case "Rectangle":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.length)
                            {
                                commander.createCommand(Command.commandType.ERASE, shape, null, shapeList.IndexOf(shape), 0, 0);
                                shapeList.Remove(shape);
                            }
                            else
                                counter++;
                            break;
                        case "Square":
                            if (Math.Abs(shape.point1.X - initialX) < shape.width && Math.Abs(shape.point1.Y - initialY) < shape.width)
                            {
                                commander.createCommand(Command.commandType.ERASE, shape, null, shapeList.IndexOf(shape), 0, 0);
                                shapeList.Remove(shape);
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
                                commander.createCommand(Command.commandType.ERASE, shape, null, shapeList.IndexOf(shape), 0, 0);
                                shapeList.Remove(shape);
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
        #endregion

        #region Save Functions
        /* Save Functions ============================================================================*/
        private void menuItemSave_Click(object sender, EventArgs e)
        {
            fileManager.save();
        }

        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            fileManager.saveAs();
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            if (fileManager.open())
            {
                openFile();
            }
        }

        private void openFile()
        {
            clearShapes();
            fileManager.openFile();
            renderShapeList();
            commander.clearCommands();
        }
        //===============================================================================================
        #endregion 
    }


}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shapes;
using FactoryShape;

namespace SelectShape
{
    public partial class ShapeSelect : Form
    {
        public Shape shapeToDraw;
        public string filepath;

        public ShapeSelect()
        {
            InitializeComponent();
        }

        private void cmboShapeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblPoint1.Visible = false;
            this.lblPoint2.Visible = false;
            this.lblPoint3.Visible = false;
            this.lblRadius1.Visible = false;
            this.lblRadius2.Visible = false;
            this.lblX1.Visible = false;
            this.lblX2.Visible = false;
            this.lblX3.Visible = false;
            this.lblY1.Visible = false;
            this.lblY2.Visible = false;
            this.lblY3.Visible = false;
            this.txtPoint1Y.Visible = false;
            this.txtPoint2Y.Visible = false;
            this.txtPoint3Y.Visible = false;
            this.txtPoint1X.Visible = false;
            this.txtPoint2X.Visible = false;
            this.txtPoint3X.Visible = false;
            this.txtRadius1.Visible = false;
            this.txtRadius2.Visible = false;
            this.txtBrowse.Visible = false;
            this.btnBrowse.Visible = false;
            switch (cmboShapeType.SelectedItem.ToString())
            {
                case "Ellipse":
                case "Rectangle":
                    this.lblX1.Visible = true;
                    this.lblY1.Visible = true;
                    this.txtPoint1X.Visible = true;
                    this.txtPoint1Y.Visible = true;
                    this.lblPoint1.Visible = true;
                    this.lblRadius1.Visible = true;
                    this.lblRadius2.Visible = true;
                    this.txtRadius1.Visible = true;
                    this.txtRadius2.Visible = true;
                    break;
                case "Circle":
                case "Square":
                    this.lblX1.Visible = true;
                    this.lblY1.Visible = true;
                    this.txtPoint1X.Visible = true;
                    this.txtPoint1Y.Visible = true;
                    this.lblPoint1.Visible = true;
                    this.lblRadius1.Visible = true;
                    this.txtRadius1.Visible = true;
                    break;
                case "Triangle":
                    this.lblX1.Visible = true;
                    this.lblY1.Visible = true;
                    this.lblX2.Visible = true;
                    this.lblY2.Visible = true;
                    this.lblX3.Visible = true;
                    this.lblY3.Visible = true;
                    this.lblPoint1.Visible = true;
                    this.lblPoint2.Visible = true;
                    this.lblPoint3.Visible = true;
                    this.txtPoint1X.Visible = true;
                    this.txtPoint2X.Visible = true;
                    this.txtPoint3X.Visible = true;
                    this.txtPoint1Y.Visible = true;
                    this.txtPoint2Y.Visible = true;
                    this.txtPoint3Y.Visible = true;
                    break;
                case "Composite Image":
                    this.btnBrowse.Visible = true;
                    this.txtBrowse.Visible = true;
                    break;
                case "Embedded Pic":
                    this.lblX1.Visible = true;
                    this.lblY1.Visible = true;
                    this.txtPoint1X.Visible = true;
                    this.txtPoint1Y.Visible = true;
                    this.lblPoint1.Visible = true;
                    this.lblRadius1.Visible = true;
                    this.lblRadius2.Visible = true;
                    this.txtRadius1.Visible = true;
                    this.txtRadius2.Visible = true;
                    this.btnBrowse.Visible = true;
                    this.txtBrowse.Visible = true;
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (cmboShapeType.SelectedItem is null)
                errorMessage("Please select a type of shape");
            else if (ValidateInfo())
            {
                ShapeFactory factory = null;
                switch (cmboShapeType.SelectedItem.ToString())
                {
                    case "Circle":
                        Shapes.Point CirclePoint = new Shapes.Point(Int32.Parse(txtPoint1X.Text), Int32.Parse(txtPoint1Y.Text));
                        factory = new CircleFactory(CirclePoint, Int32.Parse(txtRadius1.Text));
                        break;
                    case "Ellipse":
                        Shapes.Point EllipsePoint = new Shapes.Point(Int32.Parse(txtPoint1X.Text), Int32.Parse(txtPoint1Y.Text));
                        factory = new EllipseFactory(EllipsePoint, Int32.Parse(txtRadius1.Text), Int32.Parse(txtRadius2.Text));
                        break;
                    case "Rectangle":
                        Shapes.Point RectanglePoint = new Shapes.Point(Int32.Parse(txtPoint1X.Text), Int32.Parse(txtPoint1Y.Text));
                        factory = new RectangleFactory(RectanglePoint, Int32.Parse(txtRadius1.Text), Int32.Parse(txtRadius2.Text));
                        break;
                    case "Square":
                        Shapes.Point SquarePoint = new Shapes.Point(Int32.Parse(txtPoint1X.Text), Int32.Parse(txtPoint1Y.Text));
                        factory = new SquareFactory(SquarePoint, Int32.Parse(txtRadius1.Text));
                        break;
                    case "Triangle":
                        Shapes.Point TriPoint1 = new Shapes.Point(Int32.Parse(txtPoint1X.Text), Int32.Parse(txtPoint1Y.Text));
                        Shapes.Point TriPoint2 = new Shapes.Point(Int32.Parse(txtPoint2X.Text), Int32.Parse(txtPoint2Y.Text));
                        Shapes.Point TriPoint3 = new Shapes.Point(Int32.Parse(txtPoint3X.Text), Int32.Parse(txtPoint3Y.Text));
                        factory = new TriangleFactory(TriPoint1, TriPoint2, TriPoint3);
                        break;
                    case "Composite Image":
                        factory = new CompositeImageFactory(filepath);
                        break;
                    case "Embedded Pic":
                        Shapes.Point EmbeddedPoint = new Shapes.Point(Int32.Parse(txtPoint1X.Text), Int32.Parse(txtPoint1Y.Text));
                        factory = new EmbeddedPicFactory(EmbeddedPoint, Int32.Parse(txtRadius1.Text), Int32.Parse(txtRadius2.Text), filepath);
                        break;
                }
                Shape shape = factory.GetShape();
                Console.WriteLine(shape.ShapeType);
                shapeToDraw = shape;
                this.Close();
            }
        }

        private bool ValidateInfo()
        {
            bool valid = false;
            switch (cmboShapeType.SelectedItem.ToString())
            {
                case "Ellipse":
                case "Rectangle":
                    if (txtPoint1X.Text != "" && txtPoint1Y.Text != "" && txtRadius1.Text != "" && txtRadius2.Text != "")
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                        errorMessage("Please enter a value in all available text fields.");
                    }
                    break;
                case "Circle":
                case "Square":
                    if (txtPoint1X.Text != "" && txtPoint1Y.Text != "" && txtRadius1.Text != "")
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                        errorMessage("Please enter a value in all available text fields.");
                    }
                    break;
                case "Triangle":
                    if (txtPoint1X.Text != "" && txtPoint2X.Text != "" && txtPoint3X.Text != "" && txtPoint1Y.Text != "" && txtPoint2Y.Text != "" && txtPoint3Y.Text != "")
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                        errorMessage("Please enter a value in all available text fields.");
                    }
                    break;
                case "Composite Image":
                    if (txtBrowse.Text != "")
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                        errorMessage("Please select a file.");
                    }
                    break;
                case "Embedded Pic":
                    if (txtBrowse.Text != "" && txtPoint1X.Text != "" && txtPoint1Y.Text != "" && txtRadius1.Text != "" && txtRadius2.Text != "")
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                        errorMessage("Please select a file.");
                    }
                    break;
                default:
                    valid = false;
                    errorMessage("Please select a type of shape");
                    break;
            }
            return valid;
        }

        private void errorMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                Console.WriteLine(openFileDialog1.FileName);
                txtBrowse.Text = openFileDialog1.FileName;
                filepath = openFileDialog1.FileName;
            }
        }
    }
}

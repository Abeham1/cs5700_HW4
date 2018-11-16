namespace SelectShape
{
    partial class ShapeSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.cmboShapeType = new System.Windows.Forms.ComboBox();
            this.lblShapeType = new System.Windows.Forms.Label();
            this.lblPoint1 = new System.Windows.Forms.Label();
            this.lblPoint2 = new System.Windows.Forms.Label();
            this.lblPoint3 = new System.Windows.Forms.Label();
            this.txtPoint1X = new System.Windows.Forms.TextBox();
            this.txtPoint2X = new System.Windows.Forms.TextBox();
            this.txtPoint3X = new System.Windows.Forms.TextBox();
            this.lblRadius1 = new System.Windows.Forms.Label();
            this.txtRadius1 = new System.Windows.Forms.TextBox();
            this.lblRadius2 = new System.Windows.Forms.Label();
            this.txtRadius2 = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBrowse = new System.Windows.Forms.TextBox();
            this.txtPoint1Y = new System.Windows.Forms.TextBox();
            this.lblX1 = new System.Windows.Forms.Label();
            this.lblX2 = new System.Windows.Forms.Label();
            this.lblX3 = new System.Windows.Forms.Label();
            this.lblY1 = new System.Windows.Forms.Label();
            this.lblY2 = new System.Windows.Forms.Label();
            this.lblY3 = new System.Windows.Forms.Label();
            this.txtPoint2Y = new System.Windows.Forms.TextBox();
            this.txtPoint3Y = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(385, 291);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(304, 291);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // cmboShapeType
            // 
            this.cmboShapeType.FormattingEnabled = true;
            this.cmboShapeType.Items.AddRange(new object[] {
            "Circle",
            "Ellipse",
            "Rectangle",
            "Square",
            "Triangle",
            "Composite Image",
            "Embedded Pic"});
            this.cmboShapeType.Location = new System.Drawing.Point(108, 12);
            this.cmboShapeType.Name = "cmboShapeType";
            this.cmboShapeType.Size = new System.Drawing.Size(121, 21);
            this.cmboShapeType.TabIndex = 2;
            this.cmboShapeType.SelectedIndexChanged += new System.EventHandler(this.cmboShapeType_SelectedIndexChanged);
            // 
            // lblShapeType
            // 
            this.lblShapeType.AutoSize = true;
            this.lblShapeType.Location = new System.Drawing.Point(12, 15);
            this.lblShapeType.Name = "lblShapeType";
            this.lblShapeType.Size = new System.Drawing.Size(38, 13);
            this.lblShapeType.TabIndex = 3;
            this.lblShapeType.Text = "Shape";
            // 
            // lblPoint1
            // 
            this.lblPoint1.AutoSize = true;
            this.lblPoint1.Location = new System.Drawing.Point(15, 61);
            this.lblPoint1.Name = "lblPoint1";
            this.lblPoint1.Size = new System.Drawing.Size(74, 13);
            this.lblPoint1.TabIndex = 4;
            this.lblPoint1.Text = "Define Point 1";
            this.lblPoint1.Visible = false;
            // 
            // lblPoint2
            // 
            this.lblPoint2.AutoSize = true;
            this.lblPoint2.Location = new System.Drawing.Point(15, 88);
            this.lblPoint2.Name = "lblPoint2";
            this.lblPoint2.Size = new System.Drawing.Size(74, 13);
            this.lblPoint2.TabIndex = 5;
            this.lblPoint2.Text = "Define Point 2";
            this.lblPoint2.Visible = false;
            // 
            // lblPoint3
            // 
            this.lblPoint3.AutoSize = true;
            this.lblPoint3.Location = new System.Drawing.Point(15, 114);
            this.lblPoint3.Name = "lblPoint3";
            this.lblPoint3.Size = new System.Drawing.Size(74, 13);
            this.lblPoint3.TabIndex = 6;
            this.lblPoint3.Text = "Define Point 3";
            this.lblPoint3.Visible = false;
            // 
            // txtPoint1X
            // 
            this.txtPoint1X.Location = new System.Drawing.Point(130, 58);
            this.txtPoint1X.Name = "txtPoint1X";
            this.txtPoint1X.Size = new System.Drawing.Size(37, 20);
            this.txtPoint1X.TabIndex = 7;
            this.txtPoint1X.Visible = false;
            // 
            // txtPoint2X
            // 
            this.txtPoint2X.Location = new System.Drawing.Point(130, 85);
            this.txtPoint2X.Name = "txtPoint2X";
            this.txtPoint2X.Size = new System.Drawing.Size(37, 20);
            this.txtPoint2X.TabIndex = 8;
            this.txtPoint2X.Visible = false;
            // 
            // txtPoint3X
            // 
            this.txtPoint3X.Location = new System.Drawing.Point(130, 111);
            this.txtPoint3X.Name = "txtPoint3X";
            this.txtPoint3X.Size = new System.Drawing.Size(37, 20);
            this.txtPoint3X.TabIndex = 9;
            this.txtPoint3X.Visible = false;
            // 
            // lblRadius1
            // 
            this.lblRadius1.AutoSize = true;
            this.lblRadius1.Location = new System.Drawing.Point(247, 61);
            this.lblRadius1.Name = "lblRadius1";
            this.lblRadius1.Size = new System.Drawing.Size(74, 13);
            this.lblRadius1.TabIndex = 12;
            this.lblRadius1.Text = "Define Radius";
            this.lblRadius1.Visible = false;
            // 
            // txtRadius1
            // 
            this.txtRadius1.Location = new System.Drawing.Point(339, 58);
            this.txtRadius1.Name = "txtRadius1";
            this.txtRadius1.Size = new System.Drawing.Size(121, 20);
            this.txtRadius1.TabIndex = 13;
            this.txtRadius1.Visible = false;
            // 
            // lblRadius2
            // 
            this.lblRadius2.AutoSize = true;
            this.lblRadius2.Location = new System.Drawing.Point(247, 88);
            this.lblRadius2.Name = "lblRadius2";
            this.lblRadius2.Size = new System.Drawing.Size(83, 13);
            this.lblRadius2.TabIndex = 14;
            this.lblRadius2.Text = "Define Radius 2";
            this.lblRadius2.Visible = false;
            // 
            // txtRadius2
            // 
            this.txtRadius2.Location = new System.Drawing.Point(339, 85);
            this.txtRadius2.Name = "txtRadius2";
            this.txtRadius2.Size = new System.Drawing.Size(121, 20);
            this.txtRadius2.TabIndex = 15;
            this.txtRadius2.Visible = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(15, 241);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 16;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Visible = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtBrowse
            // 
            this.txtBrowse.Location = new System.Drawing.Point(18, 215);
            this.txtBrowse.Name = "txtBrowse";
            this.txtBrowse.Size = new System.Drawing.Size(442, 20);
            this.txtBrowse.TabIndex = 17;
            this.txtBrowse.Visible = false;
            // 
            // txtPoint1Y
            // 
            this.txtPoint1Y.Location = new System.Drawing.Point(192, 58);
            this.txtPoint1Y.Name = "txtPoint1Y";
            this.txtPoint1Y.Size = new System.Drawing.Size(37, 20);
            this.txtPoint1Y.TabIndex = 18;
            this.txtPoint1Y.Visible = false;
            // 
            // lblX1
            // 
            this.lblX1.AutoSize = true;
            this.lblX1.Location = new System.Drawing.Point(105, 61);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(14, 13);
            this.lblX1.TabIndex = 19;
            this.lblX1.Text = "X";
            this.lblX1.Visible = false;
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Location = new System.Drawing.Point(105, 88);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(14, 13);
            this.lblX2.TabIndex = 20;
            this.lblX2.Text = "X";
            this.lblX2.Visible = false;
            // 
            // lblX3
            // 
            this.lblX3.AutoSize = true;
            this.lblX3.Location = new System.Drawing.Point(105, 114);
            this.lblX3.Name = "lblX3";
            this.lblX3.Size = new System.Drawing.Size(14, 13);
            this.lblX3.TabIndex = 21;
            this.lblX3.Text = "X";
            this.lblX3.Visible = false;
            // 
            // lblY1
            // 
            this.lblY1.AutoSize = true;
            this.lblY1.Location = new System.Drawing.Point(172, 61);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(14, 13);
            this.lblY1.TabIndex = 22;
            this.lblY1.Text = "Y";
            this.lblY1.Visible = false;
            // 
            // lblY2
            // 
            this.lblY2.AutoSize = true;
            this.lblY2.Location = new System.Drawing.Point(172, 88);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(14, 13);
            this.lblY2.TabIndex = 23;
            this.lblY2.Text = "Y";
            this.lblY2.Visible = false;
            // 
            // lblY3
            // 
            this.lblY3.AutoSize = true;
            this.lblY3.Location = new System.Drawing.Point(172, 114);
            this.lblY3.Name = "lblY3";
            this.lblY3.Size = new System.Drawing.Size(14, 13);
            this.lblY3.TabIndex = 24;
            this.lblY3.Text = "Y";
            this.lblY3.Visible = false;
            // 
            // txtPoint2Y
            // 
            this.txtPoint2Y.Location = new System.Drawing.Point(192, 85);
            this.txtPoint2Y.Name = "txtPoint2Y";
            this.txtPoint2Y.Size = new System.Drawing.Size(37, 20);
            this.txtPoint2Y.TabIndex = 25;
            this.txtPoint2Y.Visible = false;
            // 
            // txtPoint3Y
            // 
            this.txtPoint3Y.Location = new System.Drawing.Point(192, 111);
            this.txtPoint3Y.Name = "txtPoint3Y";
            this.txtPoint3Y.Size = new System.Drawing.Size(37, 20);
            this.txtPoint3Y.TabIndex = 26;
            this.txtPoint3Y.Visible = false;
            // 
            // ShapeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 340);
            this.Controls.Add(this.txtPoint3Y);
            this.Controls.Add(this.txtPoint2Y);
            this.Controls.Add(this.lblY3);
            this.Controls.Add(this.lblY2);
            this.Controls.Add(this.lblY1);
            this.Controls.Add(this.lblX3);
            this.Controls.Add(this.lblX2);
            this.Controls.Add(this.lblX1);
            this.Controls.Add(this.txtPoint1Y);
            this.Controls.Add(this.txtBrowse);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtRadius2);
            this.Controls.Add(this.lblRadius2);
            this.Controls.Add(this.txtRadius1);
            this.Controls.Add(this.lblRadius1);
            this.Controls.Add(this.txtPoint3X);
            this.Controls.Add(this.txtPoint2X);
            this.Controls.Add(this.txtPoint1X);
            this.Controls.Add(this.lblPoint3);
            this.Controls.Add(this.lblPoint2);
            this.Controls.Add(this.lblPoint1);
            this.Controls.Add(this.lblShapeType);
            this.Controls.Add(this.cmboShapeType);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnCancel);
            this.Name = "ShapeSelect";
            this.Text = "ShapeSelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox cmboShapeType;
        private System.Windows.Forms.Label lblShapeType;
        private System.Windows.Forms.Label lblPoint1;
        private System.Windows.Forms.Label lblPoint2;
        private System.Windows.Forms.Label lblPoint3;
        private System.Windows.Forms.TextBox txtPoint1X;
        private System.Windows.Forms.TextBox txtPoint2X;
        private System.Windows.Forms.TextBox txtPoint3X;
        private System.Windows.Forms.Label lblRadius1;
        private System.Windows.Forms.TextBox txtRadius1;
        private System.Windows.Forms.Label lblRadius2;
        private System.Windows.Forms.TextBox txtRadius2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtBrowse;
        private System.Windows.Forms.TextBox txtPoint1Y;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.Label lblX3;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.Label lblY2;
        private System.Windows.Forms.Label lblY3;
        private System.Windows.Forms.TextBox txtPoint2Y;
        private System.Windows.Forms.TextBox txtPoint3Y;
    }
}


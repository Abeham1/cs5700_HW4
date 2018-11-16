namespace ShapeApplication
{
    partial class ShapeApp
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
            this.btnAddShape = new System.Windows.Forms.Button();
            this.btnDeleteShape = new System.Windows.Forms.Button();
            this.btnLoadShapeFromScript = new System.Windows.Forms.Button();
            this.btnSaveShapeToScript = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddShape
            // 
            this.btnAddShape.Location = new System.Drawing.Point(12, 505);
            this.btnAddShape.Name = "btnAddShape";
            this.btnAddShape.Size = new System.Drawing.Size(115, 23);
            this.btnAddShape.TabIndex = 0;
            this.btnAddShape.Text = "Add Shape";
            this.btnAddShape.UseVisualStyleBackColor = true;
            this.btnAddShape.Click += new System.EventHandler(this.btnAddShape_Click);
            // 
            // btnDeleteShape
            // 
            this.btnDeleteShape.Location = new System.Drawing.Point(133, 505);
            this.btnDeleteShape.Name = "btnDeleteShape";
            this.btnDeleteShape.Size = new System.Drawing.Size(115, 23);
            this.btnDeleteShape.TabIndex = 1;
            this.btnDeleteShape.Text = "Delete Shapes";
            this.btnDeleteShape.UseVisualStyleBackColor = true;
            this.btnDeleteShape.Click += new System.EventHandler(this.btnDeleteShape_Click);
            // 
            // btnLoadShapeFromScript
            // 
            this.btnLoadShapeFromScript.Location = new System.Drawing.Point(254, 505);
            this.btnLoadShapeFromScript.Name = "btnLoadShapeFromScript";
            this.btnLoadShapeFromScript.Size = new System.Drawing.Size(152, 23);
            this.btnLoadShapeFromScript.TabIndex = 2;
            this.btnLoadShapeFromScript.Text = "Load Shape From Script";
            this.btnLoadShapeFromScript.UseVisualStyleBackColor = true;
            this.btnLoadShapeFromScript.Click += new System.EventHandler(this.btnLoadShapeFromScript_Click);
            // 
            // btnSaveShapeToScript
            // 
            this.btnSaveShapeToScript.Location = new System.Drawing.Point(412, 505);
            this.btnSaveShapeToScript.Name = "btnSaveShapeToScript";
            this.btnSaveShapeToScript.Size = new System.Drawing.Size(152, 23);
            this.btnSaveShapeToScript.TabIndex = 3;
            this.btnSaveShapeToScript.Text = "Save Shapes as Composite Shape";
            this.btnSaveShapeToScript.UseVisualStyleBackColor = true;
            this.btnSaveShapeToScript.Click += new System.EventHandler(this.btnSaveShapeToScript_Click);
            // 
            // ShapeApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 542);
            this.Controls.Add(this.btnSaveShapeToScript);
            this.Controls.Add(this.btnLoadShapeFromScript);
            this.Controls.Add(this.btnDeleteShape);
            this.Controls.Add(this.btnAddShape);
            this.Name = "ShapeApp";
            this.Text = "ShapeApp";
            this.Load += new System.EventHandler(this.ShapeApp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddShape;
        private System.Windows.Forms.Button btnDeleteShape;
        private System.Windows.Forms.Button btnLoadShapeFromScript;
        private System.Windows.Forms.Button btnSaveShapeToScript;
    }
}


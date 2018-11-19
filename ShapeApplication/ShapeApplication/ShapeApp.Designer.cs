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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShapeApp));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.comboBoxFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCircle = new System.Windows.Forms.ToolStripButton();
            this.btnEllipse = new System.Windows.Forms.ToolStripButton();
            this.btnSquare = new System.Windows.Forms.ToolStripButton();
            this.btnRectangle = new System.Windows.Forms.ToolStripButton();
            this.btnTriangle = new System.Windows.Forms.ToolStripButton();
            this.btnLine = new System.Windows.Forms.ToolStripButton();
            this.btnEmbeddedPic = new System.Windows.Forms.ToolStripButton();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRedo = new System.Windows.Forms.ToolStripButton();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.ToolStripButton();
            this.btnEraser = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comboBoxFile,
            this.btnSelect,
            this.btnEraser,
            this.btnCircle,
            this.btnEllipse,
            this.btnSquare,
            this.btnRectangle,
            this.btnTriangle,
            this.btnLine,
            this.btnEmbeddedPic,
            this.btnUndo,
            this.btnRedo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(888, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // comboBoxFile
            // 
            this.comboBoxFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.comboBoxFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSave,
            this.menuItemSaveAs,
            this.menuItemOpen});
            this.comboBoxFile.Image = ((System.Drawing.Image)(resources.GetObject("comboBoxFile.Image")));
            this.comboBoxFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.comboBoxFile.Name = "comboBoxFile";
            this.comboBoxFile.Size = new System.Drawing.Size(38, 22);
            this.comboBoxFile.Text = "File";
            // 
            // menuItemSave
            // 
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.Size = new System.Drawing.Size(180, 22);
            this.menuItemSave.Text = "Save";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // menuItemSaveAs
            // 
            this.menuItemSaveAs.Name = "menuItemSaveAs";
            this.menuItemSaveAs.Size = new System.Drawing.Size(180, 22);
            this.menuItemSaveAs.Text = "Save As...";
            this.menuItemSaveAs.Click += new System.EventHandler(this.menuItemSaveAs_Click);
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Name = "menuItemOpen";
            this.menuItemOpen.Size = new System.Drawing.Size(180, 22);
            this.menuItemOpen.Text = "Open";
            this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCircle.Image = ((System.Drawing.Image)(resources.GetObject("btnCircle.Image")));
            this.btnCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(23, 22);
            this.btnCircle.Text = "toolStripButton1";
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEllipse.Image = ((System.Drawing.Image)(resources.GetObject("btnEllipse.Image")));
            this.btnEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(23, 22);
            this.btnEllipse.Text = "toolStripButton1";
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnSquare
            // 
            this.btnSquare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSquare.Image = ((System.Drawing.Image)(resources.GetObject("btnSquare.Image")));
            this.btnSquare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSquare.Name = "btnSquare";
            this.btnSquare.Size = new System.Drawing.Size(23, 22);
            this.btnSquare.Text = "toolStripButton1";
            this.btnSquare.Click += new System.EventHandler(this.btnSquare_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRectangle.Image = ((System.Drawing.Image)(resources.GetObject("btnRectangle.Image")));
            this.btnRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(23, 22);
            this.btnRectangle.Text = "toolStripButton1";
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTriangle.Image = ((System.Drawing.Image)(resources.GetObject("btnTriangle.Image")));
            this.btnTriangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(23, 22);
            this.btnTriangle.Text = "toolStripButton1";
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // btnLine
            // 
            this.btnLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(23, 22);
            this.btnLine.Text = "toolStripButton1";
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnEmbeddedPic
            // 
            this.btnEmbeddedPic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEmbeddedPic.Image = ((System.Drawing.Image)(resources.GetObject("btnEmbeddedPic.Image")));
            this.btnEmbeddedPic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmbeddedPic.Name = "btnEmbeddedPic";
            this.btnEmbeddedPic.Size = new System.Drawing.Size(23, 22);
            this.btnEmbeddedPic.Text = "toolStripButton1";
            this.btnEmbeddedPic.Click += new System.EventHandler(this.btnEmbeddedPic_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(23, 22);
            this.btnUndo.Text = "toolStripButton1";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(23, 22);
            this.btnRedo.Text = "toolStripButton1";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // txtDesignation
            // 
            this.txtDesignation.Enabled = false;
            this.txtDesignation.Location = new System.Drawing.Point(13, 510);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.ReadOnly = true;
            this.txtDesignation.Size = new System.Drawing.Size(268, 20);
            this.txtDesignation.TabIndex = 1;
            this.txtDesignation.TabStop = false;
            // 
            // btnSelect
            // 
            this.btnSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(23, 22);
            this.btnSelect.Text = "toolStripButton1";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnEraser
            // 
            this.btnEraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEraser.Image = ((System.Drawing.Image)(resources.GetObject("btnEraser.Image")));
            this.btnEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(23, 22);
            this.btnEraser.Text = "toolStripButton1";
            this.btnEraser.Click += new System.EventHandler(this.btnEraser_Click);
            // 
            // ShapeApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 542);
            this.Controls.Add(this.txtDesignation);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ShapeApp";
            this.Text = "ShapeApp";
            this.Load += new System.EventHandler(this.ShapeApp_Load);
            this.Click += new System.EventHandler(this.ShapeApp_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ShapeApp_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShapeApp_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ShapeApp_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton comboBoxFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemSave;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAs;
        private System.Windows.Forms.ToolStripButton btnEllipse;
        private System.Windows.Forms.ToolStripButton btnCircle;
        private System.Windows.Forms.ToolStripButton btnSquare;
        private System.Windows.Forms.ToolStripButton btnRectangle;
        private System.Windows.Forms.ToolStripButton btnTriangle;
        private System.Windows.Forms.ToolStripButton btnLine;
        private System.Windows.Forms.ToolStripButton btnEmbeddedPic;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnRedo;
        private System.Windows.Forms.ToolStripButton btnSelect;
        private System.Windows.Forms.ToolStripButton btnEraser;
    }
}


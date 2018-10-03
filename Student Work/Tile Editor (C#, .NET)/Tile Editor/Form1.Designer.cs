namespace Tile_Editor
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileSetViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serializedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lINQtoXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serializerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lINQtoXmlToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicsPanel1 = new GDIFormsApplication1.GraphicsPanel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(751, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileSetViewerToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // tileSetViewerToolStripMenuItem
            // 
            this.tileSetViewerToolStripMenuItem.Name = "tileSetViewerToolStripMenuItem";
            this.tileSetViewerToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.tileSetViewerToolStripMenuItem.Text = "TileSet Viewer";
            this.tileSetViewerToolStripMenuItem.Click += new System.EventHandler(this.tileSetViewerToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.graphicsPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 624);
            this.panel1.TabIndex = 3;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serializedToolStripMenuItem,
            this.lINQtoXmlToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serializerToolStripMenuItem,
            this.lINQtoXmlToolStripMenuItem1});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // serializedToolStripMenuItem
            // 
            this.serializedToolStripMenuItem.Name = "serializedToolStripMenuItem";
            this.serializedToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.serializedToolStripMenuItem.Text = "Serialized";
            this.serializedToolStripMenuItem.Click += new System.EventHandler(this.serializedToolStripMenuItem_Click);
            // 
            // lINQtoXmlToolStripMenuItem
            // 
            this.lINQtoXmlToolStripMenuItem.Name = "lINQtoXmlToolStripMenuItem";
            this.lINQtoXmlToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.lINQtoXmlToolStripMenuItem.Text = "LINQtoXml";
            this.lINQtoXmlToolStripMenuItem.Click += new System.EventHandler(this.lINQtoXmlToolStripMenuItem_Click);
            // 
            // serializerToolStripMenuItem
            // 
            this.serializerToolStripMenuItem.Name = "serializerToolStripMenuItem";
            this.serializerToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.serializerToolStripMenuItem.Text = "Serializer";
            this.serializerToolStripMenuItem.Click += new System.EventHandler(this.serializerToolStripMenuItem_Click);
            // 
            // lINQtoXmlToolStripMenuItem1
            // 
            this.lINQtoXmlToolStripMenuItem1.Name = "lINQtoXmlToolStripMenuItem1";
            this.lINQtoXmlToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.lINQtoXmlToolStripMenuItem1.Text = "LINQtoXml";
            this.lINQtoXmlToolStripMenuItem1.Click += new System.EventHandler(this.lINQtoXmlToolStripMenuItem1_Click);
            // 
            // graphicsPanel1
            // 
            this.graphicsPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graphicsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsPanel1.Location = new System.Drawing.Point(0, 0);
            this.graphicsPanel1.Name = "graphicsPanel1";
            this.graphicsPanel1.Size = new System.Drawing.Size(751, 624);
            this.graphicsPanel1.TabIndex = 0;
            this.graphicsPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicsPanel1_Paint);
            this.graphicsPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphicsPanel1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 648);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private GDIFormsApplication1.GraphicsPanel graphicsPanel1;
        private System.Windows.Forms.ToolStripMenuItem tileSetViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serializedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lINQtoXmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serializerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lINQtoXmlToolStripMenuItem1;
    }
}


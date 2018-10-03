namespace Tile_Editor
{
    partial class ModelessDialog
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.graphicsPanel1 = new GDIFormsApplication1.GraphicsPanel();
            this.Titlegroupbox = new System.Windows.Forms.GroupBox();
            this.TitletextBox = new System.Windows.Forms.TextBox();
            this.Applybutton = new System.Windows.Forms.Button();
            this.MapSizegroupbox = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.TileSizeGroupBox = new System.Windows.Forms.GroupBox();
            this.radbtn64x64 = new System.Windows.Forms.RadioButton();
            this.radbtn32x32 = new System.Windows.Forms.RadioButton();
            this.radbtn16x16 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Titlegroupbox.SuspendLayout();
            this.MapSizegroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.TileSizeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.graphicsPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Titlegroupbox);
            this.splitContainer1.Panel2.Controls.Add(this.MapSizegroupbox);
            this.splitContainer1.Panel2.Controls.Add(this.TileSizeGroupBox);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(530, 397);
            this.splitContainer1.SplitterDistance = 353;
            this.splitContainer1.TabIndex = 1;
            // 
            // graphicsPanel1
            // 
            this.graphicsPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.graphicsPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graphicsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphicsPanel1.Location = new System.Drawing.Point(0, 0);
            this.graphicsPanel1.Name = "graphicsPanel1";
            this.graphicsPanel1.Size = new System.Drawing.Size(349, 393);
            this.graphicsPanel1.TabIndex = 0;
            this.graphicsPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicsPanel1_Paint);
            this.graphicsPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphicsPanel1_MouseClick);
            // 
            // Titlegroupbox
            // 
            this.Titlegroupbox.Controls.Add(this.TitletextBox);
            this.Titlegroupbox.Controls.Add(this.Applybutton);
            this.Titlegroupbox.Location = new System.Drawing.Point(3, 299);
            this.Titlegroupbox.Name = "Titlegroupbox";
            this.Titlegroupbox.Size = new System.Drawing.Size(163, 89);
            this.Titlegroupbox.TabIndex = 6;
            this.Titlegroupbox.TabStop = false;
            this.Titlegroupbox.Text = "Title";
            // 
            // TitletextBox
            // 
            this.TitletextBox.Location = new System.Drawing.Point(8, 19);
            this.TitletextBox.Name = "TitletextBox";
            this.TitletextBox.Size = new System.Drawing.Size(145, 20);
            this.TitletextBox.TabIndex = 2;
            // 
            // Applybutton
            // 
            this.Applybutton.Location = new System.Drawing.Point(8, 45);
            this.Applybutton.Name = "Applybutton";
            this.Applybutton.Size = new System.Drawing.Size(145, 35);
            this.Applybutton.TabIndex = 1;
            this.Applybutton.Text = "Apply";
            this.Applybutton.UseVisualStyleBackColor = true;
            this.Applybutton.Click += new System.EventHandler(this.Applybutton_Click);
            // 
            // MapSizegroupbox
            // 
            this.MapSizegroupbox.Controls.Add(this.numericUpDown1);
            this.MapSizegroupbox.Location = new System.Drawing.Point(4, 211);
            this.MapSizegroupbox.Name = "MapSizegroupbox";
            this.MapSizegroupbox.Size = new System.Drawing.Size(78, 60);
            this.MapSizegroupbox.TabIndex = 5;
            this.MapSizegroupbox.TabStop = false;
            this.MapSizegroupbox.Text = "Map Size";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(7, 19);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(65, 31);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // TileSizeGroupBox
            // 
            this.TileSizeGroupBox.Controls.Add(this.radbtn64x64);
            this.TileSizeGroupBox.Controls.Add(this.radbtn32x32);
            this.TileSizeGroupBox.Controls.Add(this.radbtn16x16);
            this.TileSizeGroupBox.Location = new System.Drawing.Point(4, 90);
            this.TileSizeGroupBox.Name = "TileSizeGroupBox";
            this.TileSizeGroupBox.Size = new System.Drawing.Size(145, 97);
            this.TileSizeGroupBox.TabIndex = 4;
            this.TileSizeGroupBox.TabStop = false;
            this.TileSizeGroupBox.Text = "Tile Size";
            // 
            // radbtn64x64
            // 
            this.radbtn64x64.AutoSize = true;
            this.radbtn64x64.Checked = true;
            this.radbtn64x64.Location = new System.Drawing.Point(7, 68);
            this.radbtn64x64.Name = "radbtn64x64";
            this.radbtn64x64.Size = new System.Drawing.Size(60, 17);
            this.radbtn64x64.TabIndex = 2;
            this.radbtn64x64.TabStop = true;
            this.radbtn64x64.Text = "64 x 64";
            this.radbtn64x64.UseVisualStyleBackColor = true;
            this.radbtn64x64.CheckedChanged += new System.EventHandler(this.radbtn64x64_CheckedChanged);
            // 
            // radbtn32x32
            // 
            this.radbtn32x32.AutoSize = true;
            this.radbtn32x32.Location = new System.Drawing.Point(7, 44);
            this.radbtn32x32.Name = "radbtn32x32";
            this.radbtn32x32.Size = new System.Drawing.Size(60, 17);
            this.radbtn32x32.TabIndex = 1;
            this.radbtn32x32.Text = "32 x 32";
            this.radbtn32x32.UseVisualStyleBackColor = true;
            this.radbtn32x32.CheckedChanged += new System.EventHandler(this.radbtn32x32_CheckedChanged);
            // 
            // radbtn16x16
            // 
            this.radbtn16x16.AutoSize = true;
            this.radbtn16x16.Location = new System.Drawing.Point(7, 20);
            this.radbtn16x16.Name = "radbtn16x16";
            this.radbtn16x16.Size = new System.Drawing.Size(60, 17);
            this.radbtn16x16.TabIndex = 0;
            this.radbtn16x16.Text = "16 x 16";
            this.radbtn16x16.UseVisualStyleBackColor = true;
            this.radbtn16x16.CheckedChanged += new System.EventHandler(this.radbtn16x16_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ModelessDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 397);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModelessDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form2";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Titlegroupbox.ResumeLayout(false);
            this.Titlegroupbox.PerformLayout();
            this.MapSizegroupbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.TileSizeGroupBox.ResumeLayout(false);
            this.TileSizeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private GDIFormsApplication1.GraphicsPanel graphicsPanel1;
        private System.Windows.Forms.Button Applybutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TitletextBox;
        private System.Windows.Forms.GroupBox TileSizeGroupBox;
        private System.Windows.Forms.RadioButton radbtn64x64;
        private System.Windows.Forms.RadioButton radbtn32x32;
        private System.Windows.Forms.RadioButton radbtn16x16;
        private System.Windows.Forms.GroupBox MapSizegroupbox;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox Titlegroupbox;
    }
}
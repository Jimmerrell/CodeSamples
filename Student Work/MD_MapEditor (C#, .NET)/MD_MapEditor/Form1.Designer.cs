namespace MD_MapEditor
{
    partial class MD_MapEditor
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
            this.importTileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importObjectSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.ImportButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ComboBox_TilePassable = new System.Windows.Forms.ComboBox();
            this.gP_tileset = new GDIFormsApplication1.GraphicsPanel();
            this.hScrollBar_tileset = new System.Windows.Forms.HScrollBar();
            this.vScrollBar_tileset = new System.Windows.Forms.VScrollBar();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.Collectible_ComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_ObjectType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_ImportObjectSet = new System.Windows.Forms.Button();
            this.textbox_ObjectName = new System.Windows.Forms.TextBox();
            this.gP_ObjectSet = new GDIFormsApplication1.GraphicsPanel();
            this.hScrollBar_objectset = new System.Windows.Forms.HScrollBar();
            this.vScrollBar_objectset = new System.Windows.Forms.VScrollBar();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button_AddScriptedEvent = new System.Windows.Forms.Button();
            this.groupBox_EventSize = new System.Windows.Forms.GroupBox();
            this.numericUpDown_EventHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_EventWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_TileHeight = new System.Windows.Forms.Label();
            this.NumUpDown_TileWidth = new System.Windows.Forms.NumericUpDown();
            this.NumUpDown_TileHeight = new System.Windows.Forms.NumericUpDown();
            this.label_TileWidth = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_MapWidth = new System.Windows.Forms.Label();
            this.label_MapHeight = new System.Windows.Forms.Label();
            this.NumUpDown_MapWidth = new System.Windows.Forms.NumericUpDown();
            this.NumUpDown_MapHeight = new System.Windows.Forms.NumericUpDown();
            this.gP_Map = new GDIFormsApplication1.GraphicsPanel();
            this.hScrollBar_map = new System.Windows.Forms.HScrollBar();
            this.vScrollBar_map = new System.Windows.Forms.VScrollBar();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gP_tileset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.gP_ObjectSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox_EventSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_EventHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_EventWidth)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_TileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_TileHeight)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_MapWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_MapHeight)).BeginInit();
            this.gP_Map.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.instructionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1355, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importTileSetToolStripMenuItem,
            this.importObjectSetToolStripMenuItem,
            this.saveMapToolStripMenuItem,
            this.loadMapToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importTileSetToolStripMenuItem
            // 
            this.importTileSetToolStripMenuItem.Name = "importTileSetToolStripMenuItem";
            this.importTileSetToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.importTileSetToolStripMenuItem.Text = "Import Tile Set";
            this.importTileSetToolStripMenuItem.Click += new System.EventHandler(this.importTileSetToolStripMenuItem_Click);
            // 
            // importObjectSetToolStripMenuItem
            // 
            this.importObjectSetToolStripMenuItem.Name = "importObjectSetToolStripMenuItem";
            this.importObjectSetToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.importObjectSetToolStripMenuItem.Text = "Import Object Set";
            this.importObjectSetToolStripMenuItem.Click += new System.EventHandler(this.importObjectSetToolStripMenuItem_Click);
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveMapToolStripMenuItem.Text = "Save Map";
            this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.saveMapToolStripMenuItem_Click);
            // 
            // loadMapToolStripMenuItem
            // 
            this.loadMapToolStripMenuItem.Name = "loadMapToolStripMenuItem";
            this.loadMapToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.loadMapToolStripMenuItem.Text = "Load Map";
            this.loadMapToolStripMenuItem.Click += new System.EventHandler(this.loadMapToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.instructionsToolStripMenuItem.Text = "Instructions";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1355, 754);
            this.splitContainer1.SplitterDistance = 471;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer3.Size = new System.Drawing.Size(471, 754);
            this.splitContainer3.SplitterDistance = 391;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.ImportButton);
            this.splitContainer4.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.gP_tileset);
            this.splitContainer4.Size = new System.Drawing.Size(471, 391);
            this.splitContainer4.SplitterDistance = 56;
            this.splitContainer4.TabIndex = 2;
            // 
            // ImportButton
            // 
            this.ImportButton.BackColor = System.Drawing.SystemColors.Control;
            this.ImportButton.Location = new System.Drawing.Point(10, 14);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(127, 35);
            this.ImportButton.TabIndex = 0;
            this.ImportButton.Text = "Import New Tile Set";
            this.ImportButton.UseVisualStyleBackColor = false;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ComboBox_TilePassable);
            this.groupBox3.Location = new System.Drawing.Point(329, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 48);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tile Passable ?";
            // 
            // ComboBox_TilePassable
            // 
            this.ComboBox_TilePassable.BackColor = System.Drawing.SystemColors.Menu;
            this.ComboBox_TilePassable.DisplayMember = "True";
            this.ComboBox_TilePassable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_TilePassable.FormattingEnabled = true;
            this.ComboBox_TilePassable.IntegralHeight = false;
            this.ComboBox_TilePassable.Location = new System.Drawing.Point(6, 18);
            this.ComboBox_TilePassable.Name = "ComboBox_TilePassable";
            this.ComboBox_TilePassable.Size = new System.Drawing.Size(121, 21);
            this.ComboBox_TilePassable.TabIndex = 0;
            this.ComboBox_TilePassable.SelectedIndexChanged += new System.EventHandler(this.ComboBox_TilePassable_SelectedIndexChanged);
            this.ComboBox_TilePassable.DisplayMemberChanged += new System.EventHandler(this.ComboBox_TilePassable_DisplayMemberChanged);
            // 
            // gP_tileset
            // 
            this.gP_tileset.BackColor = System.Drawing.SystemColors.Window;
            this.gP_tileset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gP_tileset.Controls.Add(this.hScrollBar_tileset);
            this.gP_tileset.Controls.Add(this.vScrollBar_tileset);
            this.gP_tileset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gP_tileset.Location = new System.Drawing.Point(0, 0);
            this.gP_tileset.Name = "gP_tileset";
            this.gP_tileset.Size = new System.Drawing.Size(467, 327);
            this.gP_tileset.TabIndex = 0;
            this.gP_tileset.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gP_tileset_MouseClick);
            // 
            // hScrollBar_tileset
            // 
            this.hScrollBar_tileset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar_tileset.Location = new System.Drawing.Point(0, 306);
            this.hScrollBar_tileset.Name = "hScrollBar_tileset";
            this.hScrollBar_tileset.Size = new System.Drawing.Size(446, 17);
            this.hScrollBar_tileset.TabIndex = 1;
            // 
            // vScrollBar_tileset
            // 
            this.vScrollBar_tileset.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar_tileset.Location = new System.Drawing.Point(446, 0);
            this.vScrollBar_tileset.Name = "vScrollBar_tileset";
            this.vScrollBar_tileset.Size = new System.Drawing.Size(17, 323);
            this.vScrollBar_tileset.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.Collectible_ComboBox);
            this.splitContainer5.Panel1.Controls.Add(this.label6);
            this.splitContainer5.Panel1.Controls.Add(this.label5);
            this.splitContainer5.Panel1.Controls.Add(this.label2);
            this.splitContainer5.Panel1.Controls.Add(this.comboBox_ObjectType);
            this.splitContainer5.Panel1.Controls.Add(this.label1);
            this.splitContainer5.Panel1.Controls.Add(this.button_ImportObjectSet);
            this.splitContainer5.Panel1.Controls.Add(this.textbox_ObjectName);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.gP_ObjectSet);
            this.splitContainer5.Size = new System.Drawing.Size(471, 359);
            this.splitContainer5.SplitterDistance = 74;
            this.splitContainer5.TabIndex = 0;
            // 
            // Collectible_ComboBox
            // 
            this.Collectible_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Collectible_ComboBox.FormattingEnabled = true;
            this.Collectible_ComboBox.Location = new System.Drawing.Point(335, 8);
            this.Collectible_ComboBox.Name = "Collectible_ComboBox";
            this.Collectible_ComboBox.Size = new System.Drawing.Size(78, 21);
            this.Collectible_ComboBox.TabIndex = 7;
            this.Collectible_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Collectible_ComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(278, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Collectible";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Object\'s pixel sizes MUST be 64x64";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type";
            // 
            // comboBox_ObjectType
            // 
            this.comboBox_ObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ObjectType.FormattingEnabled = true;
            this.comboBox_ObjectType.Location = new System.Drawing.Point(192, 7);
            this.comboBox_ObjectType.Name = "comboBox_ObjectType";
            this.comboBox_ObjectType.Size = new System.Drawing.Size(79, 21);
            this.comboBox_ObjectType.TabIndex = 3;
            this.comboBox_ObjectType.SelectedIndexChanged += new System.EventHandler(this.comboBox_ObjectType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Object Name";
            // 
            // button_ImportObjectSet
            // 
            this.button_ImportObjectSet.Location = new System.Drawing.Point(10, 3);
            this.button_ImportObjectSet.Name = "button_ImportObjectSet";
            this.button_ImportObjectSet.Size = new System.Drawing.Size(127, 27);
            this.button_ImportObjectSet.TabIndex = 0;
            this.button_ImportObjectSet.Text = "Import New Object Set";
            this.button_ImportObjectSet.UseVisualStyleBackColor = true;
            this.button_ImportObjectSet.Click += new System.EventHandler(this.button_ImportObjectSet_Click);
            // 
            // textbox_ObjectName
            // 
            this.textbox_ObjectName.Location = new System.Drawing.Point(324, 38);
            this.textbox_ObjectName.Name = "textbox_ObjectName";
            this.textbox_ObjectName.Size = new System.Drawing.Size(89, 20);
            this.textbox_ObjectName.TabIndex = 1;
            this.textbox_ObjectName.TextChanged += new System.EventHandler(this.textbox_ObjectName_TextChanged);
            // 
            // gP_ObjectSet
            // 
            this.gP_ObjectSet.BackColor = System.Drawing.SystemColors.Window;
            this.gP_ObjectSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gP_ObjectSet.Controls.Add(this.hScrollBar_objectset);
            this.gP_ObjectSet.Controls.Add(this.vScrollBar_objectset);
            this.gP_ObjectSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gP_ObjectSet.Location = new System.Drawing.Point(0, 0);
            this.gP_ObjectSet.Name = "gP_ObjectSet";
            this.gP_ObjectSet.Size = new System.Drawing.Size(467, 277);
            this.gP_ObjectSet.TabIndex = 0;
            this.gP_ObjectSet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gP_ObjectSet_MouseClick);
            // 
            // hScrollBar_objectset
            // 
            this.hScrollBar_objectset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar_objectset.Location = new System.Drawing.Point(0, 256);
            this.hScrollBar_objectset.Name = "hScrollBar_objectset";
            this.hScrollBar_objectset.Size = new System.Drawing.Size(446, 17);
            this.hScrollBar_objectset.TabIndex = 3;
            // 
            // vScrollBar_objectset
            // 
            this.vScrollBar_objectset.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar_objectset.Location = new System.Drawing.Point(446, 0);
            this.vScrollBar_objectset.Name = "vScrollBar_objectset";
            this.vScrollBar_objectset.Size = new System.Drawing.Size(17, 273);
            this.vScrollBar_objectset.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.button_AddScriptedEvent);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox_EventSize);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gP_Map);
            this.splitContainer2.Size = new System.Drawing.Size(880, 754);
            this.splitContainer2.SplitterDistance = 90;
            this.splitContainer2.TabIndex = 0;
            // 
            // button_AddScriptedEvent
            // 
            this.button_AddScriptedEvent.BackColor = System.Drawing.Color.Green;
            this.button_AddScriptedEvent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddScriptedEvent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_AddScriptedEvent.Location = new System.Drawing.Point(509, 3);
            this.button_AddScriptedEvent.Name = "button_AddScriptedEvent";
            this.button_AddScriptedEvent.Size = new System.Drawing.Size(139, 34);
            this.button_AddScriptedEvent.TabIndex = 12;
            this.button_AddScriptedEvent.Text = "Add Scripted Event";
            this.button_AddScriptedEvent.UseVisualStyleBackColor = false;
            this.button_AddScriptedEvent.Click += new System.EventHandler(this.button_AddScriptedEvent_Click);
            // 
            // groupBox_EventSize
            // 
            this.groupBox_EventSize.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox_EventSize.Controls.Add(this.numericUpDown_EventHeight);
            this.groupBox_EventSize.Controls.Add(this.numericUpDown_EventWidth);
            this.groupBox_EventSize.Controls.Add(this.label4);
            this.groupBox_EventSize.Controls.Add(this.label3);
            this.groupBox_EventSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox_EventSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_EventSize.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox_EventSize.Location = new System.Drawing.Point(325, 4);
            this.groupBox_EventSize.Name = "groupBox_EventSize";
            this.groupBox_EventSize.Size = new System.Drawing.Size(178, 77);
            this.groupBox_EventSize.TabIndex = 11;
            this.groupBox_EventSize.TabStop = false;
            this.groupBox_EventSize.Text = "Event Size";
            this.groupBox_EventSize.Visible = false;
            // 
            // numericUpDown_EventHeight
            // 
            this.numericUpDown_EventHeight.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown_EventHeight.Location = new System.Drawing.Point(110, 46);
            this.numericUpDown_EventHeight.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDown_EventHeight.Name = "numericUpDown_EventHeight";
            this.numericUpDown_EventHeight.Size = new System.Drawing.Size(58, 23);
            this.numericUpDown_EventHeight.TabIndex = 3;
            this.numericUpDown_EventHeight.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericUpDown_EventHeight.ValueChanged += new System.EventHandler(this.numericUpDown_EventHeight_ValueChanged);
            // 
            // numericUpDown_EventWidth
            // 
            this.numericUpDown_EventWidth.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown_EventWidth.Location = new System.Drawing.Point(110, 19);
            this.numericUpDown_EventWidth.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDown_EventWidth.Name = "numericUpDown_EventWidth";
            this.numericUpDown_EventWidth.Size = new System.Drawing.Size(58, 23);
            this.numericUpDown_EventWidth.TabIndex = 2;
            this.numericUpDown_EventWidth.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericUpDown_EventWidth.ValueChanged += new System.EventHandler(this.numericUpDown_EventWidth_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Event Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Event Width";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.label_TileHeight);
            this.groupBox2.Controls.Add(this.NumUpDown_TileWidth);
            this.groupBox2.Controls.Add(this.NumUpDown_TileHeight);
            this.groupBox2.Controls.Add(this.label_TileWidth);
            this.groupBox2.Location = new System.Drawing.Point(168, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 77);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tile Sizes ( in Pixels )";
            // 
            // label_TileHeight
            // 
            this.label_TileHeight.AutoSize = true;
            this.label_TileHeight.Location = new System.Drawing.Point(6, 48);
            this.label_TileHeight.Name = "label_TileHeight";
            this.label_TileHeight.Size = new System.Drawing.Size(58, 13);
            this.label_TileHeight.TabIndex = 6;
            this.label_TileHeight.Text = "Tile Height";
            // 
            // NumUpDown_TileWidth
            // 
            this.NumUpDown_TileWidth.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.NumUpDown_TileWidth.Location = new System.Drawing.Point(70, 19);
            this.NumUpDown_TileWidth.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.NumUpDown_TileWidth.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.NumUpDown_TileWidth.Name = "NumUpDown_TileWidth";
            this.NumUpDown_TileWidth.Size = new System.Drawing.Size(68, 20);
            this.NumUpDown_TileWidth.TabIndex = 7;
            this.NumUpDown_TileWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumUpDown_TileWidth.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.NumUpDown_TileWidth.ValueChanged += new System.EventHandler(this.NumUpDown_TileWidth_ValueChanged);
            // 
            // NumUpDown_TileHeight
            // 
            this.NumUpDown_TileHeight.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.NumUpDown_TileHeight.Location = new System.Drawing.Point(70, 45);
            this.NumUpDown_TileHeight.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.NumUpDown_TileHeight.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.NumUpDown_TileHeight.Name = "NumUpDown_TileHeight";
            this.NumUpDown_TileHeight.Size = new System.Drawing.Size(68, 20);
            this.NumUpDown_TileHeight.TabIndex = 8;
            this.NumUpDown_TileHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumUpDown_TileHeight.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.NumUpDown_TileHeight.ValueChanged += new System.EventHandler(this.NumUpDown_TileHeight_ValueChanged);
            // 
            // label_TileWidth
            // 
            this.label_TileWidth.AutoSize = true;
            this.label_TileWidth.Location = new System.Drawing.Point(9, 21);
            this.label_TileWidth.Name = "label_TileWidth";
            this.label_TileWidth.Size = new System.Drawing.Size(55, 13);
            this.label_TileWidth.TabIndex = 5;
            this.label_TileWidth.Text = "Tile Width";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_MapWidth);
            this.groupBox1.Controls.Add(this.label_MapHeight);
            this.groupBox1.Controls.Add(this.NumUpDown_MapWidth);
            this.groupBox1.Controls.Add(this.NumUpDown_MapHeight);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 77);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map Sizes ( in Tiles )";
            // 
            // label_MapWidth
            // 
            this.label_MapWidth.AutoSize = true;
            this.label_MapWidth.Location = new System.Drawing.Point(9, 22);
            this.label_MapWidth.Name = "label_MapWidth";
            this.label_MapWidth.Size = new System.Drawing.Size(59, 13);
            this.label_MapWidth.TabIndex = 3;
            this.label_MapWidth.Text = "Map Width";
            // 
            // label_MapHeight
            // 
            this.label_MapHeight.AutoSize = true;
            this.label_MapHeight.Location = new System.Drawing.Point(6, 48);
            this.label_MapHeight.Name = "label_MapHeight";
            this.label_MapHeight.Size = new System.Drawing.Size(62, 13);
            this.label_MapHeight.TabIndex = 4;
            this.label_MapHeight.Text = "Map Height";
            // 
            // NumUpDown_MapWidth
            // 
            this.NumUpDown_MapWidth.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumUpDown_MapWidth.Location = new System.Drawing.Point(74, 20);
            this.NumUpDown_MapWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumUpDown_MapWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumUpDown_MapWidth.Name = "NumUpDown_MapWidth";
            this.NumUpDown_MapWidth.Size = new System.Drawing.Size(71, 20);
            this.NumUpDown_MapWidth.TabIndex = 1;
            this.NumUpDown_MapWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumUpDown_MapWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumUpDown_MapWidth.ValueChanged += new System.EventHandler(this.NumUpDown_MapWidth_ValueChanged);
            // 
            // NumUpDown_MapHeight
            // 
            this.NumUpDown_MapHeight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumUpDown_MapHeight.Location = new System.Drawing.Point(74, 46);
            this.NumUpDown_MapHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumUpDown_MapHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumUpDown_MapHeight.Name = "NumUpDown_MapHeight";
            this.NumUpDown_MapHeight.Size = new System.Drawing.Size(71, 20);
            this.NumUpDown_MapHeight.TabIndex = 2;
            this.NumUpDown_MapHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumUpDown_MapHeight.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.NumUpDown_MapHeight.ValueChanged += new System.EventHandler(this.NumUpDown_MapHeight_ValueChanged);
            // 
            // gP_Map
            // 
            this.gP_Map.BackColor = System.Drawing.SystemColors.Window;
            this.gP_Map.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gP_Map.Controls.Add(this.hScrollBar_map);
            this.gP_Map.Controls.Add(this.vScrollBar_map);
            this.gP_Map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gP_Map.Location = new System.Drawing.Point(0, 0);
            this.gP_Map.Name = "gP_Map";
            this.gP_Map.Size = new System.Drawing.Size(876, 656);
            this.gP_Map.TabIndex = 0;
            this.gP_Map.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gP_Map_MouseClick);
            this.gP_Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gP_Map_MouseDown);
            this.gP_Map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gP_Map_MouseMove);
            this.gP_Map.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gP_Map_MouseUp);
            // 
            // hScrollBar_map
            // 
            this.hScrollBar_map.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar_map.Location = new System.Drawing.Point(0, 635);
            this.hScrollBar_map.Name = "hScrollBar_map";
            this.hScrollBar_map.Size = new System.Drawing.Size(855, 17);
            this.hScrollBar_map.TabIndex = 2;
            // 
            // vScrollBar_map
            // 
            this.vScrollBar_map.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar_map.Location = new System.Drawing.Point(855, 0);
            this.vScrollBar_map.Name = "vScrollBar_map";
            this.vScrollBar_map.Size = new System.Drawing.Size(17, 652);
            this.vScrollBar_map.TabIndex = 1;
            // 
            // MD_MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 778);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MD_MapEditor";
            this.Text = "MD_MapEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MD_MapEditor_FormClosing);
            this.Resize += new System.EventHandler(this.MD_MapEditor_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gP_tileset.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.gP_ObjectSet.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox_EventSize.ResumeLayout(false);
            this.groupBox_EventSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_EventHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_EventWidth)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_TileWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_TileHeight)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_MapWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_MapHeight)).EndInit();
            this.gP_Map.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importTileSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox ComboBox_TilePassable;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_TileHeight;
        private System.Windows.Forms.NumericUpDown NumUpDown_TileWidth;
        private System.Windows.Forms.NumericUpDown NumUpDown_TileHeight;
        private System.Windows.Forms.Label label_TileWidth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_MapWidth;
        private System.Windows.Forms.Label label_MapHeight;
        private System.Windows.Forms.NumericUpDown NumUpDown_MapWidth;
        private System.Windows.Forms.NumericUpDown NumUpDown_MapHeight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importObjectSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Button button_ImportObjectSet;
        private GDIFormsApplication1.GraphicsPanel gP_tileset;
        private GDIFormsApplication1.GraphicsPanel gP_ObjectSet;
        private GDIFormsApplication1.GraphicsPanel gP_Map;
        private System.Windows.Forms.HScrollBar hScrollBar_tileset;
        private System.Windows.Forms.VScrollBar vScrollBar_tileset;
        private System.Windows.Forms.HScrollBar hScrollBar_objectset;
        private System.Windows.Forms.VScrollBar vScrollBar_objectset;
        private System.Windows.Forms.HScrollBar hScrollBar_map;
        private System.Windows.Forms.VScrollBar vScrollBar_map;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_ObjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_ObjectType;
        private System.Windows.Forms.GroupBox groupBox_EventSize;
        private System.Windows.Forms.NumericUpDown numericUpDown_EventHeight;
        private System.Windows.Forms.NumericUpDown numericUpDown_EventWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_AddScriptedEvent;
        private System.Windows.Forms.ComboBox Collectible_ComboBox;
        private System.Windows.Forms.Label label6;
    }
}


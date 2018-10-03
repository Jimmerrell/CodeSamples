using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using SGP;



///////////////////////////////////////
//*************************************
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//Object Image Tiles must be 64x64pxls
////// non compliance will dump your bank account into mine!

namespace MD_MapEditor
{
    public enum m_bPassable { True, False };
    public enum ObjTypeID { Object, Event };

    public enum m_bCollectible {  True, False };

    public partial class MD_MapEditor : Form
    {

        //public event Added_WayPoint Added_WP;

        public Cursor Reticle = new Cursor("./../../../Reticle.cur");

        CSGP_Direct3D Dirt3D = null;
        CSGP_TextureManager TextMan = null;

        int TileSetID = -1;
        int ObjectSetID = -1;
        int ReticleID = -1;
        public bool bRunning;
        public bool SelectionSet = true;
        public Point selectedTile = new Point(0, 0);
        public Point selectedObject = new Point(0, 0);
        List<FlyWeight> Fly_Weights = new List<FlyWeight>(); //represents the tiles and flyweights in the tileset
        List<Tile> Maps_Tiles = new List<Tile>(); //the list of tiles that have been set on the map
        int SelectedTileID = 0;
        int SelectedObjectID = 0;
        string TileSetImageFileName = "";
        string ImageFolderFilePath = "";
        string ObjectSetImageFileName = "";

        List<GameObject> Game_Objects = new List<GameObject>(); //holds the different game objects

        bool DragPaint = false;

       

        Rectangle Rect = new Rectangle();

        ScriptedEventEditor SE_Editor = new ScriptedEventEditor();

        public MD_MapEditor()
        {
            InitializeComponent();

            bRunning = true;

            groupBox_EventSize.Visible = true;

            ComboBox_TilePassable.DataSource = Enum.GetValues(typeof(m_bPassable));
            Collectible_ComboBox.DataSource = Enum.GetValues(typeof(m_bCollectible));
            comboBox_ObjectType.DataSource = Enum.GetValues(typeof(ObjTypeID));

            Rect.Width = (int)NumUpDown_TileWidth.Value;
            Rect.Height = (int)NumUpDown_TileHeight.Value;

            for (decimal i = 0; i < NumUpDown_MapWidth.Value * NumUpDown_MapHeight.Value; i++)
            {
                Maps_Tiles.Add(new Tile());
                Maps_Tiles[(int)i].MapPos.X = ((int)i % (int)NumUpDown_MapWidth.Value);
                Maps_Tiles[(int)i].MapPos.Y = ((int)i / (int)NumUpDown_MapWidth.Value);
            }

            SE_Editor.WP_Adding += WP_ADD;
        }

        public void Initialize()
        {
            //initialize wrappers
            Dirt3D = CSGP_Direct3D.GetInstance();
            TextMan = CSGP_TextureManager.GetInstance();

            Dirt3D.Initialize(gP_tileset, false);
            Dirt3D.AddRenderTarget(gP_ObjectSet);
            Dirt3D.AddRenderTarget(gP_Map);

            TextMan.Initialize(Dirt3D.Device, Dirt3D.Sprite);

            //set up Map Set scroll bars
            SetUpScrollBars(hScrollBar_map, vScrollBar_map,
                new Size((int)NumUpDown_MapWidth.Value * (int)NumUpDown_TileWidth.Value + (int)NumUpDown_TileWidth.Value,
                    (int)NumUpDown_MapHeight.Value * (int)NumUpDown_TileHeight.Value + (int)NumUpDown_TileHeight.Value));

            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.Description = "Choose the folder that contains your Images";

            while (true)
            {
                if (DialogResult.OK == FBD.ShowDialog())
                {
                    ImageFolderFilePath = FBD.SelectedPath;
                    break;
                }
            }

            ReticleID = TextMan.LoadTexture("./../../../Reticle.png");
            //this.Cursor = Reticle;
        }

        public void Terminate()
        {
            if (TileSetID != -1)
            {
                TextMan.UnloadTexture(TileSetID);
                TileSetID = -1;
            }

            TextMan.Terminate();
            Dirt3D.Terminate();
        }

        public void Render()
        {
            RenderTileSet();


            RenderObjectSet();


            RenderMap();

            if (comboBox_ObjectType.SelectedIndex == 1 && SelectionSet == false)
            {
                groupBox_EventSize.Visible = true;
                numericUpDown_EventHeight.Value = Game_Objects[SelectedObjectID].Height;
                numericUpDown_EventWidth.Value = Game_Objects[SelectedObjectID].Width;
            }
            else
            {
                groupBox_EventSize.Visible = false;
            }
        }

        private void RenderTileSet()
        {
            Dirt3D.Clear(gP_tileset, Color.Green);

            Dirt3D.DeviceBegin();
            Dirt3D.SpriteBegin();
            {
                if (TileSetID > -1)
                {
                    Point offset = new Point(0, 0);

                    offset.X -= hScrollBar_tileset.Value;
                    offset.Y -= vScrollBar_tileset.Value;

                    TextMan.Draw(TileSetID, offset.X, offset.Y);

                    RenderTileSetGrid();

                    if (SelectionSet == true)
                    {
                        Rectangle tempRect = new Rectangle();
                        tempRect.X = Rect.X + offset.X;
                        tempRect.Y = Rect.Y + offset.Y;
                        tempRect.Width = Rect.Width;
                        tempRect.Height = Rect.Height;

                        Dirt3D.DrawHollowRect(tempRect, Color.Red, 3);

                    }
                }
            }

            Dirt3D.SpriteEnd();
            Dirt3D.DeviceEnd();
            Dirt3D.Present();
        }

        private void RenderObjectSet()
        {
            Dirt3D.Clear(gP_ObjectSet, Color.Green);

            Dirt3D.DeviceBegin();
            Dirt3D.SpriteBegin();
            {
                if (ObjectSetID > -1)
                {
                    Point offset = new Point(0, 0);

                    offset.X -= hScrollBar_objectset.Value;
                    offset.Y -= vScrollBar_objectset.Value;

                    TextMan.Draw(ObjectSetID, offset.X, offset.Y);

                    textbox_ObjectName.Text = Game_Objects[SelectedObjectID].objName;

                    if (SelectionSet == false)
                    {
                        Rectangle tempRect = new Rectangle();
                        tempRect.X = Rect.X + offset.X;
                        tempRect.Y = Rect.Y + offset.Y;
                        tempRect.Width = Rect.Width;
                        tempRect.Height = Rect.Height;

                        Dirt3D.DrawHollowRect(tempRect, Color.Red, 3);
                    }
                }

            }


            Dirt3D.SpriteEnd();
            Dirt3D.DeviceEnd();
            Dirt3D.Present();
        }

        private void RenderMap()
        {
            Dirt3D.Clear(gP_Map, Color.Green);

            Dirt3D.DeviceBegin();
            Dirt3D.SpriteBegin();
            {
                if (TileSetID > -1)
                {
                    Point offset = new Point(0, 0);

                    offset.X -= hScrollBar_map.Value;
                    offset.Y -= vScrollBar_map.Value;

                    //draw each tile
                    for (int iTile = 0; iTile < Maps_Tiles.Count(); iTile++)
                    {
                        if (Maps_Tiles[iTile].TileTypeID <= Fly_Weights.Count())
                        {
                            int id = Fly_Weights[Maps_Tiles[iTile].TileTypeID].ImageID;
                            int x = Maps_Tiles[iTile].MapPos.X * (int)NumUpDown_TileWidth.Value + offset.X;
                            int y = Maps_Tiles[iTile].MapPos.Y * (int)NumUpDown_TileHeight.Value + offset.Y;
                            float scaleX = 1.0f;
                            float scaleY = 1.0f;
                            Rectangle section = Fly_Weights[Maps_Tiles[iTile].TileTypeID].SourceRect;

                            TextMan.Draw(id, x, y, scaleX, scaleY, section);
                        }
                    }

                    //draw objects
                    for (int iObject = 0; iObject < Game_Objects.Count(); iObject++)
                    {
                        int id = ObjectSetID;
                        int x = Game_Objects[iObject].MapPosX + offset.X - 32;
                        int y = Game_Objects[iObject].MapPosY + offset.Y - 32;
                        float scaleX = 1.0f;
                        float scaleY = 1.0f;
                        Rectangle section = Game_Objects[iObject].SourceRect;
                        TextMan.Draw(id, x, y, scaleX, scaleY, section);

                        if (Game_Objects[iObject].TypeID == 1)
                        {
                            Rectangle EventRect = new Rectangle();
                            EventRect.X = Game_Objects[iObject].MapPosX + offset.X - Game_Objects[iObject].Width / 2;
                            EventRect.Y = Game_Objects[iObject].MapPosY + offset.Y - Game_Objects[iObject].Height / 2;
                            EventRect.Width = Game_Objects[iObject].Width;
                            EventRect.Height = Game_Objects[iObject].Height;
                            Dirt3D.DrawHollowRect(EventRect, Color.SpringGreen, 2);
                        }
                    }

                    //draw waypoints if SE is open
                    if(SE_Editor.Visible == true && SE_Editor.Selected_SE != -1 )
                    {
                        int X1;
                        int Y1;
                        //int x2;
                        //int y2;

                        for(int i = 0; i < SE_Editor.SE_List[SE_Editor.Selected_SE].Waypoint_List.Count(); i++)
                        {
                            X1 = SE_Editor.SE_List[SE_Editor.Selected_SE].Waypoint_List[i].CollisionRect.Left;
                            Y1 = SE_Editor.SE_List[SE_Editor.Selected_SE].Waypoint_List[i].CollisionRect.Top;

                            int Width = SE_Editor.SE_List[SE_Editor.Selected_SE].Waypoint_List[i].CollisionRect.Width;
                            int Height = SE_Editor.SE_List[SE_Editor.Selected_SE].Waypoint_List[i].CollisionRect.Height;

                            TextMan.Draw(ReticleID, X1 - 16 + offset.X, Y1 - 16 + offset.Y);
                            
                            Rectangle WPrect = new Rectangle(X1 + offset.X - Width / 2, Y1 + offset.Y - Height / 2, Width, Height);
                            Dirt3D.DrawHollowRect(WPrect, Color.SpringGreen, 2);

                            //if( i > 0)
                            //{
                            //    x2 = SE_Editor.SE_List[SE_Editor.Selected_SE].Waypoint_List[i - 1].CollisionRect.Left;
                            //    y2 = SE_Editor.SE_List[SE_Editor.Selected_SE].Waypoint_List[i - 1].CollisionRect.Top;
                            //
                            //    //Dirt3D.DrawLine(X1, Y1, x2, y2, Color.Green, 3);
                            //}
                        }
                    }
                }

                RenderMapGrid();
            }

            Dirt3D.SpriteEnd();
            Dirt3D.DeviceEnd();
            Dirt3D.Present();
        }

        private void RenderMapGrid()
        {
            Point offset = new Point(0, 0);

            offset.X += hScrollBar_map.Value;
            offset.Y += vScrollBar_map.Value;

            //vertical lines
            for (decimal numCols = 0; numCols < NumUpDown_MapWidth.Value + 1; numCols++)
            {
                Dirt3D.DrawLine((int)(numCols * NumUpDown_TileWidth.Value - offset.X),
                    (int)(0 - offset.Y),
                    (int)(numCols * NumUpDown_TileWidth.Value - offset.X),
                    (int)(NumUpDown_TileHeight.Value * NumUpDown_MapHeight.Value - offset.Y),
                    Color.Gray, 1);
            }
            //horizontal lines
            for (decimal numRows = 0; numRows < NumUpDown_MapHeight.Value + 1; numRows++)
            {
                Dirt3D.DrawLine((int)(0 - offset.X),
                    (int)(numRows * NumUpDown_TileHeight.Value - offset.Y),
                    (int)(NumUpDown_TileWidth.Value * NumUpDown_MapWidth.Value - offset.X),
                    (int)(numRows * NumUpDown_TileHeight.Value - offset.Y),
                    Color.Gray, 1);
            }
        }

        private void RenderTileSetGrid()
        {
            Point offset = new Point(0, 0);

            offset.X += hScrollBar_tileset.Value;
            offset.Y += vScrollBar_tileset.Value;

            decimal ImageNumCols = TextMan.GetTextureWidth(TileSetID) / NumUpDown_TileWidth.Value;
            decimal ImageNumRows = TextMan.GetTextureHeight(TileSetID) / NumUpDown_TileHeight.Value;

            //vertical lines
            for (decimal numCols = 0; numCols < ImageNumCols + 1; numCols++)
            {
                Dirt3D.DrawLine((int)(numCols * NumUpDown_TileWidth.Value - offset.X),
                    (int)(0 - offset.Y),
                    (int)(numCols * NumUpDown_TileWidth.Value - offset.X),
                    (int)(NumUpDown_TileHeight.Value * ImageNumRows - offset.Y),
                    Color.Gray, 1);
            }
            //horizontal lines
            for (decimal numRows = 0; numRows < ImageNumRows + 1; numRows++)
            {
                Dirt3D.DrawLine((int)(0 - offset.X),
                    (int)(numRows * NumUpDown_TileHeight.Value - offset.Y),
                    (int)(NumUpDown_TileWidth.Value * ImageNumCols - offset.X),
                    (int)(numRows * NumUpDown_TileHeight.Value - offset.Y),
                    Color.Gray, 1);
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF; *.PNG)|*.BMP;*.JPG;*.GIF; *.PNG";

            if (DialogResult.OK == dlg.ShowDialog())
            {
                TileSetID = TextMan.LoadTexture(dlg.FileName);
                TileSetImageFileName = dlg.SafeFileName;

                // set up TileSet scroll bars
                SetUpScrollBars(hScrollBar_tileset, vScrollBar_tileset,
                    new Size(TextMan.GetTextureWidth(TileSetID), TextMan.GetTextureHeight(TileSetID)));

                SetUpFlyWeights();
            }
        }

        private void button_ImportObjectSet_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF; *.PNG)|*.BMP;*.JPG;*.GIF; *.PNG";

            if (DialogResult.OK == dlg.ShowDialog())
            {
                ObjectSetID = TextMan.LoadTexture(dlg.FileName);
                ObjectSetImageFileName = dlg.SafeFileName;

                // set up TileSet scroll bars
                SetUpScrollBars(hScrollBar_objectset, vScrollBar_objectset,
                    new Size(TextMan.GetTextureWidth(ObjectSetID), TextMan.GetTextureHeight(ObjectSetID)));

                SetUpGameObjects();
            }
        }

        private void SetUpScrollBars(HScrollBar hBar, VScrollBar vBar, Size ImageSize)
        {
            // horizontal scroll bar
            if (hBar.Visible)
            {
                hBar.Minimum = 0;
                hBar.SmallChange = gP_tileset.Width / 20;
                hBar.LargeChange = gP_tileset.Width / 10;

                hBar.Maximum = ImageSize.Width;

                if (vBar.Visible)
                {
                    hBar.Maximum += vBar.Width  + 64;
                }

                hBar.Maximum += hBar.LargeChange + 64;
            }
            // vertical scroll bar
            if (vBar.Visible)
            {
                vBar.Minimum = 0;
                vBar.SmallChange = gP_tileset.Height / 20;
                vBar.LargeChange = gP_tileset.Height / 10;

                vBar.Maximum = ImageSize.Height;

                if (hBar.Visible)
                {
                    hBar.Maximum += hBar.Height + 64;
                }

                vBar.Maximum += vBar.LargeChange + 64;
            }
        }

        private void MD_MapEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            bRunning = false;
        }

        private void gP_tileset_MouseClick(object sender, MouseEventArgs e)
        {
            Point offset = new Point(0, 0);
            offset.X -= hScrollBar_tileset.Value;
            offset.Y -= vScrollBar_tileset.Value;

            selectedTile.X = (e.X - offset.X);
            selectedTile.Y = (e.Y - offset.Y);

            // check for valid tile
            if (TileSetID > -1 &&
                selectedTile.X <= TextMan.GetTextureWidth(TileSetID) &&
                selectedTile.Y <= TextMan.GetTextureHeight(TileSetID))
            {
                //set SelectedSet to True
                SelectionSet = true;
                //divide e.X / tilewidth and truncate
                selectedTile.X = (int)((decimal)selectedTile.X / NumUpDown_TileWidth.Value);
                //divide e.Y / tile height and truncate
                selectedTile.Y = (int)((decimal)selectedTile.Y / NumUpDown_TileHeight.Value);
                // find index in the list
                decimal ImageNumCols = TextMan.GetTextureWidth(TileSetID) / NumUpDown_TileWidth.Value;
                int tempID = (int)(selectedTile.X + ImageNumCols * selectedTile.Y);
                if (tempID <= Fly_Weights.Count())
                {
                    SelectedTileID = tempID;
                    Rect.X = selectedTile.X * (int)(NumUpDown_TileWidth.Value);
                    Rect.Y = selectedTile.Y * (int)(NumUpDown_TileHeight.Value);
                    Rect.Width = (int)(NumUpDown_TileWidth.Value);
                    Rect.Height = (int)(NumUpDown_TileHeight.Value);

                    if (Fly_Weights[SelectedTileID].Passable)
                        ComboBox_TilePassable.SelectedItem = m_bPassable.True;
                    else
                        ComboBox_TilePassable.SelectedItem = m_bPassable.False;
                }
            }

        }

        private void gP_Map_MouseClick(object sender, MouseEventArgs e)
        {
            //check which grid was clicked
            Point offset = new Point(0, 0);
            offset.X -= hScrollBar_map.Value;
            offset.Y -= vScrollBar_map.Value;

            Point MapTile = new Point();
            MapTile.X = (e.X - offset.X);
            MapTile.Y = (e.Y - offset.Y);

            if (TileSetID > -1)
            {
                if (SE_Editor.Visible == false)
                {
                    if (SelectionSet == true)
                    {
                        // check for valid tile
                        if (MapTile.X <= NumUpDown_TileWidth.Value * NumUpDown_MapWidth.Value &&
                            MapTile.Y <= NumUpDown_TileHeight.Value * NumUpDown_MapHeight.Value)
                        {
                            // draw selected tile to grid 
                            // by changing the MapTile's TypeID to SelectedTileID
                            //divide e.X / tilewidth and truncate
                            MapTile.X = (int)((decimal)MapTile.X / NumUpDown_TileWidth.Value);
                            //divide e.Y / tile height and truncate
                            MapTile.Y = (int)((decimal)MapTile.Y / NumUpDown_TileHeight.Value);
                            // find index in the list
                            int MapTilePos = (int)(MapTile.X + NumUpDown_MapWidth.Value * MapTile.Y);

                            if (MapTilePos < Maps_Tiles.Count() && MapTilePos >= 0)
                                Maps_Tiles[MapTilePos].TileTypeID = SelectedTileID;
                        }
                    }
                    else
                    {
                        Game_Objects[SelectedObjectID].MapPosX = MapTile.X;
                        Game_Objects[SelectedObjectID].MapPosY = MapTile.Y;
                    }
                }
                else
                {
                    // Accept input for waypoint placement
                    this.Cursor = Cursors.Arrow;
                    SE_Editor.Cursor = Cursors.Arrow;

                    //set it in the tool
                    SE_Editor.SE_List[SE_Editor.Selected_SE].Waypoint_List[SE_Editor.Selected_WP].CollisionRect.X = e.X - offset.X;
                    SE_Editor.SE_List[SE_Editor.Selected_SE].Waypoint_List[SE_Editor.Selected_WP].CollisionRect.Y = e.Y - offset.Y;

                    SE_Editor.CollisionRectPosX_textBox.Text = (e.X - offset.X).ToString();
                    SE_Editor.CollisionRectPosY_textBox.Text = (e.Y - offset.Y).ToString();
                }
            }
        }

        private void gP_ObjectSet_MouseClick(object sender, MouseEventArgs e)
        {
            Point offset = new Point(0, 0);
            offset.X -= hScrollBar_objectset.Value;
            offset.Y -= vScrollBar_objectset.Value;

            selectedObject.X = (e.X - offset.X);
            selectedObject.Y = (e.Y - offset.Y);

            // check for valid tile
            if (ObjectSetID > -1 &&
                selectedObject.X <= TextMan.GetTextureWidth(ObjectSetID) &&
                selectedObject.Y <= TextMan.GetTextureHeight(ObjectSetID))
            {
                //set selectionset to false
                SelectionSet = false;
                //divide e.X / tilewidth and truncate
                selectedObject.X = (int)((decimal)selectedObject.X / 64);
                //divide e.Y / 64 and truncate
                selectedObject.Y = (int)((decimal)selectedObject.Y / 64);
                // find index in the list
                decimal ImageNumCols = TextMan.GetTextureWidth(ObjectSetID) / 64;
                int tempID = (int)(selectedObject.X + ImageNumCols * selectedObject.Y);
                if (tempID <= Game_Objects.Count())
                {
                    SelectedObjectID = tempID;
                    Rect.X = selectedObject.X * 64;
                    Rect.Y = selectedObject.Y * 64;
                    Rect.Width = 64;
                    Rect.Height = 64;
                }

                textbox_ObjectName.Text = Game_Objects[SelectedObjectID].objName;
                comboBox_ObjectType.SelectedIndex = Game_Objects[SelectedObjectID].TypeID;

                if (Game_Objects[SelectedObjectID].Collectible)
                    Collectible_ComboBox.SelectedItem = m_bCollectible.True;
                else
                    Collectible_ComboBox.SelectedItem = m_bCollectible.False;
            }
        }

        private void NumUpDown_MapWidth_ValueChanged(object sender, EventArgs e)
        {
            //set up Map Set scroll bars
            SetUpScrollBars(hScrollBar_map, vScrollBar_map,
                new Size((int)NumUpDown_MapWidth.Value * (int)NumUpDown_TileWidth.Value,
                    (int)NumUpDown_MapHeight.Value * (int)NumUpDown_TileHeight.Value));

            SetUpMapTiles();
        }

        private void NumUpDown_MapHeight_ValueChanged(object sender, EventArgs e)
        {
            //set up Map Set scroll bars
            SetUpScrollBars(hScrollBar_map, vScrollBar_map,
                new Size((int)NumUpDown_MapWidth.Value * (int)NumUpDown_TileWidth.Value,
                    (int)NumUpDown_MapHeight.Value * (int)NumUpDown_TileHeight.Value));

            SetUpMapTiles();
        }

        private void NumUpDown_TileWidth_ValueChanged(object sender, EventArgs e)
        {
            //set up Map Set scroll bars
            SetUpScrollBars(hScrollBar_map, vScrollBar_map,
                new Size((int)NumUpDown_MapWidth.Value * (int)NumUpDown_TileWidth.Value,
                    (int)NumUpDown_MapHeight.Value * (int)NumUpDown_TileHeight.Value));

            // set up Rect
            Rect.Width = (int)NumUpDown_TileWidth.Value;

            if (TileSetID > -1)
                SetUpFlyWeights();
        }

        private void NumUpDown_TileHeight_ValueChanged(object sender, EventArgs e)
        {
            //set up Map Set scroll bars
            SetUpScrollBars(hScrollBar_map, vScrollBar_map,
                new Size((int)NumUpDown_MapWidth.Value * (int)NumUpDown_TileWidth.Value,
                    (int)NumUpDown_MapHeight.Value * (int)NumUpDown_TileHeight.Value));

            // set up rect
            Rect.Height = (int)NumUpDown_TileHeight.Value;

            if (TileSetID > -1)
                SetUpFlyWeights();
        }

        private void numericUpDown_EventWidth_ValueChanged(object sender, EventArgs e)
        {
            if (SelectionSet == false)
            {
                Game_Objects[SelectedObjectID].Width = (int)numericUpDown_EventWidth.Value;
            }
        }

        private void numericUpDown_EventHeight_ValueChanged(object sender, EventArgs e)
        {
            if (SelectionSet == false)
            {
                Game_Objects[SelectedObjectID].Height = (int)numericUpDown_EventHeight.Value;
            }
        }

        private void SetUpFlyWeights()
        {
            Fly_Weights.Clear();

            decimal ImageNumCols = TextMan.GetTextureWidth(TileSetID) / NumUpDown_TileWidth.Value;
            decimal ImageNumRows = TextMan.GetTextureHeight(TileSetID) / NumUpDown_TileHeight.Value;

            for (decimal Y_count = 0; Y_count < ImageNumCols; Y_count++)
            {
                for (decimal X_count = 0; X_count < ImageNumRows; X_count++)
                {
                    FlyWeight tempFW = new FlyWeight();
                    tempFW.ImageID = TileSetID;
                    tempFW.SourceTileID = (int)(X_count + ImageNumCols * Y_count);
                    tempFW.TileTypeID = (int)(X_count + ImageNumCols * Y_count);
                    tempFW.SourceRect.X = (int)X_count * (int)(NumUpDown_TileWidth.Value);
                    tempFW.SourceRect.Y = (int)Y_count * (int)(NumUpDown_TileHeight.Value);
                    tempFW.SourceRect.Width = (int)(NumUpDown_TileWidth.Value);
                    tempFW.SourceRect.Height = (int)(NumUpDown_TileHeight.Value);

                    Fly_Weights.Add(tempFW);
                }
            }
        }

        private void SetUpGameObjects()
        {
            Game_Objects.Clear();

            decimal ImageNumCols = TextMan.GetTextureWidth(ObjectSetID) / 64;
            decimal ImageNumRows = TextMan.GetTextureHeight(ObjectSetID) / 64;

            for (decimal Y_count = 0; Y_count < ImageNumRows; Y_count++)
            {
                for (decimal X_count = 0; X_count < ImageNumCols; X_count++)
                {
                    GameObject tempGO = new GameObject();
                    tempGO.SourceTileID = (int)(X_count + ImageNumCols * Y_count);
                    tempGO.SourceRect.X = (int)X_count * 64;
                    tempGO.SourceRect.Y = (int)Y_count * 64;
                    tempGO.SourceRect.Width = 64;
                    tempGO.SourceRect.Height = 64;

                    Game_Objects.Add(tempGO);
                }
            }
        }

        private void SetUpMapTiles()
        {
            //this function is for changing the map size and keeping existing tile values and places
            //store existing list into a TempList
            List<Tile> TempList = new List<Tile>();
            for (int iTile = 0; iTile < Maps_Tiles.Count(); iTile++)
            {
                TempList.Add(Maps_Tiles[iTile]);
            }

            //clear the main map
            Maps_Tiles.Clear();

            //create the main map
            for (decimal i = 0; i < NumUpDown_MapWidth.Value * NumUpDown_MapHeight.Value; i++)
            {
                Maps_Tiles.Add(new Tile());
                Maps_Tiles[(int)i].MapPos.X = ((int)i % (int)NumUpDown_MapWidth.Value);
                Maps_Tiles[(int)i].MapPos.Y = ((int)i / (int)NumUpDown_MapWidth.Value);
            }

            //place the TempList into the main map
            for (int iTile = 0; iTile < TempList.Count(); ++iTile)
            {
                if (TempList[iTile].MapPos.X <= (int)NumUpDown_MapWidth.Value &&
                    TempList[iTile].MapPos.Y <= (int)NumUpDown_MapHeight.Value)
                {
                    int MapLocation = TempList[iTile].MapPos.X + TempList[iTile].MapPos.Y * (int)NumUpDown_MapWidth.Value;
                    if (MapLocation < Maps_Tiles.Count())
                        Maps_Tiles[MapLocation] = TempList[iTile];
                }

            }
        }

        private void gP_Map_MouseDown(object sender, MouseEventArgs e)
        {
            DragPaint = true;
        }

        private void gP_Map_MouseMove(object sender, MouseEventArgs e)
        {
            if (DragPaint)
            {
                gP_Map_MouseClick(sender, e);
            }
        }

        private void gP_Map_MouseUp(object sender, MouseEventArgs e)
        {
            DragPaint = false;
        }

        private void ComboBox_TilePassable_DisplayMemberChanged(object sender, EventArgs e)
        {
            if (e.ToString() == "True")
                Fly_Weights[SelectedTileID].Passable = true;
            else if (e.ToString() == "False")
                Fly_Weights[SelectedTileID].Passable = false;
        }

        private void ComboBox_TilePassable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectionSet == true)
            {
                if (ComboBox_TilePassable.SelectedItem.ToString() == "True")
                    Fly_Weights[SelectedTileID].Passable = true;
                if (ComboBox_TilePassable.SelectedItem.ToString() == "False")
                    Fly_Weights[SelectedTileID].Passable = false;
            }
        }

        private void comboBox_ObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectionSet == false && Game_Objects.Count() > 0)
            {
                Game_Objects[SelectedObjectID].TypeID = comboBox_ObjectType.SelectedIndex;
            }
        }

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Xml Files|*.xml";
            dlg.FilterIndex = 2;
            dlg.DefaultExt = "xml";

            if (DialogResult.OK == dlg.ShowDialog())
            {
                XElement xRoot = new XElement("MapXML");

                XAttribute xTileSet = new XAttribute("TileSet", TileSetImageFileName);
                xRoot.Add(xTileSet);
                XAttribute xObjectSet = new XAttribute("ObjectSet", ObjectSetImageFileName);
                xRoot.Add(xObjectSet);

                XElement xSubRoot = new XElement("Map");
                xRoot.Add(xSubRoot);

                XAttribute xWidth = new XAttribute("Width", NumUpDown_MapWidth.Value);
                xSubRoot.Add(xWidth);
                XAttribute xHeight = new XAttribute("Height", NumUpDown_MapHeight.Value);
                xSubRoot.Add(xHeight);
                XAttribute xTileWidth = new XAttribute("TileWidth", NumUpDown_TileWidth.Value);
                xSubRoot.Add(xTileWidth);
                XAttribute xTileHeight = new XAttribute("TileHeight", NumUpDown_TileHeight.Value);
                xSubRoot.Add(xTileHeight);

                for (int iTile = 0; iTile < Maps_Tiles.Count(); iTile++)
                {
                    XElement xTile = new XElement("Tile");
                    xSubRoot.Add(xTile);

                    XAttribute xTileTypeID = new XAttribute("TileTypeID", Maps_Tiles[iTile].TileTypeID);
                    xTile.Add(xTileTypeID);
                }

                for (int iFlyWeight = 0; iFlyWeight < Fly_Weights.Count(); iFlyWeight++)
                {
                    XElement xFlyWeight = new XElement("FlyWeight");
                    xSubRoot.Add(xFlyWeight);

                    XAttribute xTileTypeID = new XAttribute("TileTypeID", Fly_Weights[iFlyWeight].TileTypeID);
                    xFlyWeight.Add(xTileTypeID);

                    XAttribute xImageID = new XAttribute("ImageID", Fly_Weights[iFlyWeight].ImageID);
                    xFlyWeight.Add(xImageID);

                    XAttribute xSourceTileID = new XAttribute("SourceTileID", Fly_Weights[iFlyWeight].SourceTileID);
                    xFlyWeight.Add(xSourceTileID);

                    XAttribute xPassable = new XAttribute("Passable", Fly_Weights[iFlyWeight].Passable);
                    xFlyWeight.Add(xPassable);
                }

                for (int iObject = 0; iObject < Game_Objects.Count(); iObject++)
                {
                    XElement xGameObject = new XElement("GameObject");
                    xSubRoot.Add(xGameObject);

                    XAttribute xSourceTileID = new XAttribute("SourceTileID", Game_Objects[iObject].SourceTileID);
                    xGameObject.Add(xSourceTileID);

                    XAttribute xObjName = new XAttribute("ObjName", Game_Objects[iObject].objName);
                    xGameObject.Add(xObjName);

                    XAttribute xMapPosX = new XAttribute("MapPosX", Game_Objects[iObject].MapPosX);
                    xGameObject.Add(xMapPosX);

                    XAttribute xMapPosY = new XAttribute("MapPosY", Game_Objects[iObject].MapPosY);
                    xGameObject.Add(xMapPosY);

                    XAttribute xObjWidth = new XAttribute("Width", Game_Objects[iObject].Width);
                    xGameObject.Add(xObjWidth);

                    XAttribute xObjHeight = new XAttribute("Height", Game_Objects[iObject].Height);
                    xGameObject.Add(xObjHeight);

                    XAttribute xSourceLeft = new XAttribute("SourceLeft", Game_Objects[iObject].SourceRect.Left);
                    xGameObject.Add(xSourceLeft);

                    XAttribute xSourceTop = new XAttribute("SourceTop", Game_Objects[iObject].SourceRect.Top);
                    xGameObject.Add(xSourceTop);

                    XAttribute xObjTypeID = new XAttribute("ObjTypeID", Game_Objects[iObject].TypeID);
                    xGameObject.Add(xObjTypeID);

                    XAttribute xCollectible = new XAttribute("Collectible", Game_Objects[iObject].Collectible);
                    xGameObject.Add(xCollectible);
                }

                xRoot.Save(dlg.FileName);
            }
        }

        private void loadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Xml Files|*.xml";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                XElement xRoot = XElement.Load(dlg.FileName);

                XAttribute xTileSet = xRoot.Attribute("TileSet");
                TileSetImageFileName = ImageFolderFilePath + "/" + xTileSet.Value;

                XAttribute xObjectSet = xRoot.Attribute("ObjectSet");
                ObjectSetImageFileName = ImageFolderFilePath + "/" + xObjectSet.Value;

                //Load in tileset
                if (xTileSet.Value.ToString().Length > 0)
                {
                    TileSetID = TextMan.LoadTexture(TileSetImageFileName);
                    TileSetImageFileName = xTileSet.Value; //sets it back to just the image name without path
                    // set up TileSet scroll bars
                    SetUpScrollBars(hScrollBar_tileset, vScrollBar_tileset,
                        new Size(TextMan.GetTextureWidth(TileSetID), TextMan.GetTextureHeight(TileSetID)));

                    SetUpFlyWeights();
                }

                //Load in Objectset
                if (xObjectSet.Value.ToString().Length > 0)
                {
                    ObjectSetID = TextMan.LoadTexture(ObjectSetImageFileName);
                    ObjectSetImageFileName = xObjectSet.Value;

                    SetUpScrollBars(hScrollBar_objectset, vScrollBar_objectset,
                        new Size(TextMan.GetTextureWidth(ObjectSetID), TextMan.GetTextureHeight(ObjectSetID)));

                    SetUpGameObjects();
                }

                XElement xSubRoot = xRoot.Element("Map");

                //Load in Map Values
                {
                    XAttribute xWidth = xSubRoot.Attribute("Width");
                    NumUpDown_MapWidth.Value = decimal.Parse(xWidth.Value);

                    XAttribute xHeight = xSubRoot.Attribute("Height");
                    NumUpDown_MapHeight.Value = decimal.Parse(xHeight.Value);

                    XAttribute xTileWidth = xSubRoot.Attribute("TileWidth");
                    NumUpDown_TileWidth.Value = decimal.Parse(xTileWidth.Value);

                    XAttribute xTileHeight = xSubRoot.Attribute("TileHeight");
                    NumUpDown_TileHeight.Value = decimal.Parse(xTileHeight.Value);
                }

                //set up map & load in tiles
                {
                    IEnumerable<XElement> xTiles = xSubRoot.Elements("Tile");

                    Maps_Tiles.Clear();
                    double i = 0;
                    foreach (XElement xTile in xTiles)
                    {
                        Maps_Tiles.Add(new Tile());
                        Maps_Tiles[(int)i].MapPos.X = ((int)i % (int)NumUpDown_MapWidth.Value);
                        Maps_Tiles[(int)i].MapPos.Y = ((int)i / (int)NumUpDown_MapWidth.Value);

                        XAttribute xTileTypeID = xTile.Attribute("TileTypeID");
                        Maps_Tiles[(int)i].TileTypeID = int.Parse(xTileTypeID.Value);

                        i++;
                    }

                }

                //load in Flyweights
                {
                    SetUpFlyWeights(); //sets up everthing but passable

                    IEnumerable<XElement> xFlyWeights = xSubRoot.Elements("FlyWeight");

                    int i = 0;
                    foreach (XElement xFlyWeight in xFlyWeights)
                    {
                        XAttribute xPassable = xFlyWeight.Attribute("Passable");
                        Fly_Weights[i].Passable = bool.Parse(xPassable.Value);

                        i++;
                    }

                    if (Fly_Weights[SelectedTileID].Passable)
                        ComboBox_TilePassable.SelectedItem = m_bPassable.True;
                    else
                        ComboBox_TilePassable.SelectedItem = m_bPassable.False;
                }

                //load in Game Objects
                {
                    IEnumerable<XElement> xGameObjects = xSubRoot.Elements("GameObject");

                    int i = 0;
                    foreach (XElement xGameObject in xGameObjects)
                    {
                        XAttribute xSourceTileID = xGameObject.Attribute("SourceTileID");
                        Game_Objects[i].SourceTileID = int.Parse(xSourceTileID.Value);

                        XAttribute xObjName = xGameObject.Attribute("ObjName");
                        Game_Objects[i].objName = xObjName.Value.ToString();

                        XAttribute xMapPosX = xGameObject.Attribute("MapPosX");
                        Game_Objects[i].MapPosX = int.Parse(xMapPosX.Value);

                        XAttribute xMapPosY = xGameObject.Attribute("MapPosY");
                        Game_Objects[i].MapPosY = int.Parse(xMapPosY.Value);

                        XAttribute xObjWidth = xGameObject.Attribute("Width");
                        Game_Objects[i].Width = int.Parse(xObjWidth.Value);

                        XAttribute xObjHeight = xGameObject.Attribute("Height");
                        Game_Objects[i].Height = int.Parse(xObjHeight.Value);

                        XAttribute xObjTypeID = xGameObject.Attribute("ObjTypeID");
                        Game_Objects[i].TypeID = int.Parse(xObjTypeID.Value);

                        XAttribute xCollectible = xGameObject.Attribute("Collectible");
                        Game_Objects[i].Collectible = bool.Parse(xCollectible.Value);

                        i++;
                    }
                }




            }
        }

        private void MD_MapEditor_Resize(object sender, EventArgs e)
        {
            Dirt3D.Resize(gP_Map, gP_Map.ClientSize.Width, gP_Map.ClientSize.Height, true);
            Dirt3D.Resize(gP_tileset, gP_tileset.ClientSize.Width, gP_tileset.ClientSize.Height, true);
            Dirt3D.Resize(gP_ObjectSet, gP_ObjectSet.ClientSize.Width, gP_ObjectSet.ClientSize.Height, true);

            //set up Map Set scroll bars
            SetUpScrollBars(hScrollBar_map, vScrollBar_map,
                new Size((int)NumUpDown_MapWidth.Value * (int)NumUpDown_TileWidth.Value + (int)NumUpDown_TileWidth.Value,
                    (int)NumUpDown_MapHeight.Value * (int)NumUpDown_TileHeight.Value + (int)NumUpDown_TileHeight.Value));
        }

        private void importTileSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportButton_Click(sender, e);
        }

        private void importObjectSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_ImportObjectSet_Click(sender, e);
        }

        private void textbox_ObjectName_TextChanged(object sender, EventArgs e)
        {
            if (Game_Objects.Count > 0)
            {
                Game_Objects[SelectedObjectID].objName = textbox_ObjectName.Text;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_AddScriptedEvent_Click(object sender, EventArgs e)
        {
            SE_Editor.Show();
        }

        public void WP_ADD(object sender, WayPointArgs e)
        {
            this.Cursor = SE_Editor.Cursor;
        }

        private void Collectible_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectionSet == false)
            {
                if (Collectible_ComboBox.SelectedItem.ToString() == "True")
                    Game_Objects[SelectedObjectID].Collectible = true;
                if (Collectible_ComboBox.SelectedItem.ToString() == "False")
                    Game_Objects[SelectedObjectID].Collectible = false;
            }
        }







    }

    public delegate void Added_WayPoint(object sender, WayPointArgs e);
}

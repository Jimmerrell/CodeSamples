using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SGP;

namespace MD_MapEditor
{
    public class Tile
    {
        public int TileTypeID = 0;

        //for use in tile editor only
        public Point MapPos = new Point(); //so every tile knows where it is when map sizes change
    }

    public class FlyWeight
    {
        public int TileTypeID = -1;
        public int ImageID = -1;
        public int SourceTileID = -1;
        public bool Passable = true;

        // for use in tile editor only
        public Rectangle SourceRect = new Rectangle();
    }

    public class GameObject
    {
        public bool Collectible = true;
        public int TypeID = 0;
        public int SourceTileID = -1;
        public string objName = "object name";
        public int MapPosX = -800;
        public int MapPosY = -800;
        public int Width = 64;
        public int Height = 64;
        public Rectangle SourceRect = new Rectangle();
    }
}

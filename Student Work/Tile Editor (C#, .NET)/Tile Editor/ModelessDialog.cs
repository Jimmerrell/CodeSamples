using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tile_Editor
{
    public partial class ModelessDialog : Form
    {
        public event ApplyEventHandler Apply;

        public Bitmap tileset = Properties.Resources.desert9x8x32x32;
        public int Tsize = 32;
        Size tileSize = new Size(32, 32);        
        
        Size mapSize = new Size(5, 5);
        Point[,] map = new Point[5, 5];
        public Point selectedTile = new Point(0, 0);

        private decimal editorsize;
        public decimal Editorsize
        {
            get { return numericUpDown1.Value; }
            set { numericUpDown1.Value = value; }
        }

        public ModelessDialog()
        {
            InitializeComponent();

            editorsize = numericUpDown1.Value;

            mapSize = new Size(tileset.Width / tileSize.Width, tileset.Height / tileSize.Height);
            map = new Point[mapSize.Width / tileSize.Width, mapSize.Height / tileSize.Height];
            // Set DPI
            Graphics g = graphicsPanel1.CreateGraphics();
            tileset.SetResolution(g.DpiX, g.DpiY);
            g.Dispose();

            graphicsPanel1.AutoScrollMinSize = tileset.Size;
        }

        public string Title
        {
            get
            {
                return TitletextBox.Text;
            }
            set
            {
                TitletextBox.Text = value;
            }
        }

        private void Applybutton_Click(object sender, EventArgs e)
        {
            if (Apply != null)
            {
                this.Text = TitletextBox.Text;
                Apply(this, new ApplyEventArgs(TitletextBox.Text));
                Apply(this, new ApplyEventArgs(numericUpDown1.Value));
            }
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            Point offset = new Point(0, 0);
            tileSize.Width = Tsize; tileSize.Height = Tsize;
            mapSize = new Size(tileset.Width / tileSize.Width, tileset.Height / tileSize.Height);
            map = new Point[mapSize.Width / tileSize.Width, mapSize.Height / tileSize.Height];

            offset.X += graphicsPanel1.AutoScrollPosition.X;
            offset.Y += graphicsPanel1.AutoScrollPosition.Y;

            e.Graphics.DrawImage(tileset, offset);

            for (int x = 0; x < mapSize.Width; x++)
            {
                for (int y = 0; y < mapSize.Height; y++)
                {
                    Rectangle destRect = Rectangle.Empty;
                    destRect.X = (x * tileSize.Width) + offset.X;
                    destRect.Y = (y * tileSize.Height) + offset.Y;
                    destRect.Size = tileSize;

                    e.Graphics.DrawRectangle(Pens.Black, destRect);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (DialogResult.OK == dlg.ShowDialog())
            {
                tileset = new Bitmap(dlg.FileName);
                mapSize = new Size(tileset.Width / tileSize.Width, tileset.Height / tileSize.Height);
                map = new Point[mapSize.Width / tileSize.Width, mapSize.Height / tileSize.Height];
                // Set DPI
                Graphics g = graphicsPanel1.CreateGraphics();
                tileset.SetResolution(g.DpiX, g.DpiY);
                g.Dispose();

                graphicsPanel1.AutoScrollMinSize = tileset.Size;

                ((Form1)this.Owner).Gpanel.Invalidate();
                graphicsPanel1.Invalidate();
            }
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point offset = new Point(0, 0);
            offset.X += graphicsPanel1.AutoScrollPosition.X;
            offset.Y += graphicsPanel1.AutoScrollPosition.Y;

            selectedTile.X = (e.X - offset.X) / tileSize.Width;
            selectedTile.Y = (e.Y - offset.Y) / tileSize.Height;
        }

        private void radbtn16x16_CheckedChanged(object sender, EventArgs e)
        {
            Tsize = 16;
            graphicsPanel1.Invalidate();
        }

        private void radbtn32x32_CheckedChanged(object sender, EventArgs e)
        {
            Tsize = 32;
            graphicsPanel1.Invalidate();
        }

        private void radbtn64x64_CheckedChanged(object sender, EventArgs e)
        {
            Tsize = 64;
            graphicsPanel1.Invalidate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            editorsize = numericUpDown1.Value;
        }
    }

    public delegate void ApplyEventHandler(object sender, ApplyEventArgs e);

    public class ApplyEventArgs : EventArgs
    {
        private string formTitle;
        private decimal TileSize;

        public string FormTitle
        {
            get { return formTitle; }
            set { formTitle = value; }
        }

        public ApplyEventArgs(string formTitle)
        {
            this.formTitle = formTitle;
        }

        public ApplyEventArgs(decimal tilesize)
        {
            this.TileSize = tilesize;
        }
    }
}

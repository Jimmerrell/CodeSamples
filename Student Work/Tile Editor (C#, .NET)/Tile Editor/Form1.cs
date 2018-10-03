using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using GDIFormsApplication1;

namespace Tile_Editor
{
    public partial class Form1 : Form
    {
        Size tileSize = new Size(32, 32);

        Size mapSize = new Size(5, 5);
        Point[,] map = new Point[40, 40];

        Point selectedTile = new Point(0, 0);

        ModelessDialog tool = null;

        public GraphicsPanel Gpanel
        {
            get { return graphicsPanel1; }
            set { graphicsPanel1 = value; }
        }

        public Form1()
        {
            //this.Size  = new Size(mapSize.Width * tileSize.Width, mapSize.Height * tileSize.Height);

            InitializeComponent();

            graphicsPanel1.AutoScrollMinSize = new Size(mapSize.Width * tileSize.Width, mapSize.Height * tileSize.Height);

            if (tool == null)
            {
                tool = new ModelessDialog();

                tool.FormClosed += tool_FormClosed;

                Point location = new Point();
                location.X = this.Right;
                location.Y = this.Top;
                tool.Location = location;

                //tool.Update += tool_Update;
                tool.Apply += tool_Apply;
                this.selectedTile = tool.selectedTile;
                tool.Title = this.Text;

                //tool.Owner = this;

                tool.Show(this);
            }            
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = panel1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                panel1.BackColor = dlg.Color;
            }
        }

        private void modalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelessDialog dlg = new ModelessDialog();            

            dlg.Apply += tool_Apply;
            this.selectedTile = tool.selectedTile;
            dlg.Title = this.Text;
            //dlg.BackColor = panel1.BackColor;
            //dlg.Location.X = this.Location.X + this.Size.Width;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                this.Text = dlg.Title;
                panel1.BackColor = dlg.BackColor;
            }
        }

        void tool_Update(object sender, EventArgs e)
        {
            //numericUpDown1.Value = tool.NumericUpDown1Value;

            ModelessDialog toolLocal = (ModelessDialog)sender;

            //numericUpDown1.Value = toolLocal.NumericUpDown1Value;
        }

        void tool_FormClosed(object sender, FormClosedEventArgs e)
        {
            tool = null;
        }

        void tool_Apply(object sender, ApplyEventArgs e)
        {
            //this.Text = e.FormTitle;
            this.Text = tool.Text;
            mapSize.Width = mapSize.Height = (int)tool.Editorsize;
            tileSize.Width = tileSize.Height = tool.Tsize;
            
            graphicsPanel1.Invalidate();
        }        

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            Point offset = new Point(0, 0);

            //tileSize.Width = tool.Tsize; tileSize.Height = tool.Tsize;
            graphicsPanel1.AutoScrollMinSize = new Size(mapSize.Width * tileSize.Width, 
                mapSize.Height * tileSize.Height);

            offset.X += graphicsPanel1.AutoScrollPosition.X;
            offset.Y += graphicsPanel1.AutoScrollPosition.Y;

            for (int x = 0; x < mapSize.Width; x++)
            {
                for (int y = 0; y < mapSize.Height; y++)
                {
                    Rectangle destRect = Rectangle.Empty;
                    destRect.X = x * tileSize.Width + offset.X;
                    destRect.Y = y * tileSize.Height + offset.Y;
                    destRect.Size = tileSize;

                    Rectangle srcRect = Rectangle.Empty;
                    srcRect.X = map[x, y].X * tileSize.Width;
                    srcRect.Y = map[x, y].Y * tileSize.Height;
                    srcRect.Size = tileSize;

                    e.Graphics.DrawImage(tool.tileset, destRect, srcRect, GraphicsUnit.Pixel);

                    e.Graphics.DrawRectangle(Pens.Black, destRect);
                }
            }
        }

        private void tileSetViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tool == null)
            {
                tool = new ModelessDialog();

                tool.FormClosed += tool_FormClosed;

                Point location = new Point();
                location.X = this.Right;
                location.Y = this.Top;
                tool.Location = location;

                //tool.Update += tool_Update;
                tool.Apply += tool_Apply;
                this.selectedTile = tool.selectedTile;

                tool.Title = this.Text;

                //tool.Owner = this;

                tool.Show(this);
            }
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point offset = new Point(0, 0);
            offset.X += graphicsPanel1.AutoScrollPosition.X;
            offset.Y += graphicsPanel1.AutoScrollPosition.Y;

            int x = (e.X - offset.X) / tileSize.Width;
            int y = (e.Y - offset.Y) / tileSize.Height;

            map[x, y] = tool.selectedTile;

            graphicsPanel1.Invalidate();
        }

        private void serializerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Xml Files|*.xml";
            dlg.FilterIndex = 2;
            dlg.DefaultExt = "xml";

            if (DialogResult.OK == dlg.ShowDialog())
            {
                List<Point> list = new List<Point>();

                for (int x = 0; x < mapSize.Width; x++)
                    for (int y = 0; y < mapSize.Height; y++)
                    {
                        list.Add(map[x, y]);
                    }

                StreamWriter writer = new StreamWriter(dlg.FileName);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Point>));

                serializer.Serialize(writer, list);

                writer.Close();
            }
        }

        private void serializedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Xml Files|*.xml";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Point>));

                List<Point> list = (List<Point>)serializer.Deserialize(reader);

                reader.Close();

                int i = 0;

                for (int x = 0; x < mapSize.Width; x++)
                    for (int y = 0; y < mapSize.Height; y++)
                    {
                        map[x, y] = list[i];
                        i++;
                    }

                graphicsPanel1.Invalidate();
            }
        }

        private void lINQtoXmlToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Xml Files|*.xml";
            dlg.FilterIndex = 2;
            dlg.DefaultExt = "xml";

            // To do
            // Save map size

            if (DialogResult.OK == dlg.ShowDialog())
            {
                XElement xRoot = new XElement("Map");

                for (int x = 0; x < mapSize.Width; x++)
                    for (int y = 0; y < mapSize.Height; y++)
                    {
                        XElement xTile = new XElement("Tile");
                        xRoot.Add(xTile);

                        XAttribute xLocX = new XAttribute("LocX", x);
                        xTile.Add(xLocX);

                        XAttribute xLoxY = new XAttribute("LocY", y);
                        xTile.Add(xLoxY);

                        XElement xX = new XElement("X", map[x, y].X);
                        xTile.Add(xX);

                        XElement xY = new XElement("Y");
                        xY.Value = map[x, y].Y.ToString();
                        xTile.Add(xY);
                    }
                
                xRoot.Save(dlg.FileName);
            }
        }

        private void lINQtoXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Xml Files|*.xml";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                XElement xRoot = XElement.Load(dlg.FileName);

                IEnumerable<XElement> xTiles = xRoot.Elements();

                double i = 0;
                foreach (XElement xTile in xTiles)
                {
                    XAttribute xLocX = xTile.Attribute("LocX");
                    int nLocX = Convert.ToInt32(xLocX.Value);

                    XAttribute xLocY = xTile.Attribute("LocY");
                    int nLocY = int.Parse(xLocY.Value);

                    XElement xX = xTile.Element("X");
                    int nX = int.Parse(xX.Value);

                    XElement xY = xTile.Element("Y");
                    int nY = int.Parse(xY.Value);

                    map[nLocX, nLocY] = new Point(nX, nY);

                    i++;
                }

                tool.Editorsize = (decimal)Math.Sqrt(i);
                mapSize.Width = mapSize.Height = (int)tool.Editorsize;

                graphicsPanel1.Invalidate();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool.Editorsize = 5;
            Point temp = new Point(0,0);

            for (int x = 0; x < mapSize.Width; x++)
                for (int y = 0; y < mapSize.Height; y++)
                {
                    map[x, y] = temp;
                }

            graphicsPanel1.Invalidate();
        }
    }
}

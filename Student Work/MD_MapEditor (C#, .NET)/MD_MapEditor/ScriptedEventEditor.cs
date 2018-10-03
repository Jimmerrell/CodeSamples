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

namespace MD_MapEditor
{

    public enum TriggerTypes { Collision, GameTime, Collect, Craft, Prev_WP_End };

    public enum OwnerTypes { Player, Girl, Developer };

    public enum BoxTypes { Thought, Speech, Text };

    public enum bPlaySound { True, False };

    public partial class ScriptedEventEditor : Form
    {
        public event WapPointAdding WP_Adding;

        public List<ScriptedEvent> SE_List = new List<ScriptedEvent>();

        public Cursor Reticle = new Cursor("./../../../Reticle.cur");

        public int Selected_WP = -1;
        public int Selected_SE = -1;

        public ScriptedEventEditor()
        {
            InitializeComponent();

            ScriptedEvent tempSE = new ScriptedEvent();
            SE_List.Add(tempSE);
            ScriptedEvents_ListBox.Items.Add(SE_List[0].EventName);

            ScriptedEvents_ListBox.SelectedIndex = 0;
            Waypoints_ListBox.SelectedIndex = -1;

            TriggerType_ComboBox.DataSource = Enum.GetValues(typeof(TriggerTypes));
            Owner_ComboBox.DataSource = Enum.GetValues(typeof(OwnerTypes));
            DialogueBoxType_ComboBox.DataSource = Enum.GetValues(typeof(BoxTypes));
            m_bSound_comboBox.DataSource = Enum.GetValues(typeof(bPlaySound));
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void EventName_TextBox_TextChanged(object sender, EventArgs e)
        {
            SE_List[ScriptedEvents_ListBox.SelectedIndex].EventName = EventName_TextBox.Text;
            ScriptedEvents_ListBox.Items[ScriptedEvents_ListBox.SelectedIndex] = EventName_TextBox.Text;
        }

        private void AddWaypoint_Button_Click(object sender, EventArgs e)
        {
            if (ScriptedEvents_ListBox.SelectedIndex > -1)
            {
                Waypoint tempWP = new Waypoint();
                tempWP.WaypointID = Waypoints_ListBox.Items.Count;

                SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List.Add(tempWP);

                string tempStr = "Waypoint_";
                if (tempWP.WaypointID < 10)
                    tempStr += 0;
                tempStr += tempWP.WaypointID;

                Waypoints_ListBox.Items.Add(tempStr);
                Waypoints_ListBox.SelectedIndex = tempWP.WaypointID;
            }

        }

        private void AddScriptedEvent_Button_Click(object sender, EventArgs e)
        {
            ScriptedEvent tempSE = new ScriptedEvent();
            SE_List.Add(tempSE);
            ScriptedEvents_ListBox.Items.Add(tempSE.EventName);
            ScriptedEvents_ListBox.SelectedIndex = SE_List.Count() - 1;
        }

        private void TriggerType_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Waypoints_ListBox.SelectedIndex > -1)
                SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].TriggerType =
                    TriggerType_ComboBox.SelectedItem.ToString();
        }

        private void Owner_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Waypoints_ListBox.SelectedIndex > -1)
                SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].Owner =
                    Owner_ComboBox.SelectedItem.ToString();
        }

        private void DialogueBoxType_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Waypoints_ListBox.SelectedIndex > -1)
                SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].BoxType =
                    DialogueBoxType_ComboBox.SelectedItem.ToString();
        }

        private void SoundName_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (Waypoints_ListBox.SelectedIndex > -1)
                SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].SoundName =
                    SoundName_TextBox.Text;
        }

        private void PlaceWaypoint_Button_Click(object sender, EventArgs e)
        {
            if (WP_Adding != null && Waypoints_ListBox.Items.Count > 0)
            {
                this.Cursor = Reticle;
                WP_Adding(this, new WayPointArgs(Reticle));
                //Form Add_WP = new Form();
                //Add_WP.Text = "Place the Waypoint on the map.";

                //Add_WP.ShowDialog();
            }
            //this.Cursor = MD_MapEditor.
            // change cursor to reticle
            // display a popup that tells the user to place the waypoint on the map
            // go to Form1 and catch the mouse input and send back the coordinates to the Waypoint
            // display on the map a marker for the waypoint
            // close the pop up window
        }

        private void Duration_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Waypoints_ListBox.SelectedIndex > -1)
                SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].Duration =
                    (int)Duration_numericUpDown.Value;
        }

        private void CollisionRectWidth_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Waypoints_ListBox.SelectedIndex > -1)
                SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].CollisionRect.Width =
                    (int)CollisionRectWidth_numericUpDown.Value;
        }

        private void CollisionRectHeight_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Waypoints_ListBox.SelectedIndex > -1)
                SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].CollisionRect.Height =
                    (int)CollisionRectHeight_numericUpDown.Value;
        }

        private void GameTime_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Waypoints_ListBox.SelectedIndex > -1)
            {
                SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].TimeToTrigger =
                    (int)GameTime_numericUpDown.Value;

                int min = (SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].TimeToTrigger / 60);
                int sec = (SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].TimeToTrigger % 60);
                if (sec >= 10)
                    GameTime_textBox.Text = min.ToString() + ":" + sec.ToString();
                else
                    GameTime_textBox.Text = min.ToString() + ":0" + sec.ToString(); 
            }
        }

        private void WayPointScript_richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Waypoints_ListBox.SelectedIndex > -1)
                SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].ScriptString =
                    WayPointScript_richTextBox.Text;
        }

        private void Collectible_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Waypoints_ListBox.SelectedIndex > -1 && Collectibles_ListBox.SelectedIndex > -1)
            {
                SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].Required_CollectedItems[Collectibles_ListBox.SelectedIndex] =
                                    Collectible_textBox.Text;

                Collectibles_ListBox.Items[Collectibles_ListBox.SelectedIndex] = Collectible_textBox.Text;
            }

        }

        private void ScriptedEvents_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selected_SE = ScriptedEvents_ListBox.SelectedIndex;
            if (ScriptedEvents_ListBox.SelectedIndex != -1)
            {
                EventName_TextBox.Text = SE_List[ScriptedEvents_ListBox.SelectedIndex].EventName;
                if (SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List.Count() > 0)
                {
                    Waypoints_ListBox.Items.Clear();
                    for (int i = 0; i < SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List.Count(); i++)
                    {
                        string tempStr = "Waypoint_";
                        if (i < 10)
                            tempStr += 0;
                        tempStr += i;

                        Waypoints_ListBox.Items.Add(tempStr);
                    }
                    Waypoints_ListBox.SelectedIndex = 0;
                }
                else
                {
                    Waypoints_ListBox.Items.Clear();
                    Waypoints_ListBox.SelectedIndex = -1;
                }
            }


        }

        private void Waypoints_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selected_WP = Waypoints_ListBox.SelectedIndex;
            if (Waypoints_ListBox.SelectedIndex != -1 && Waypoints_ListBox.Items.Count > 0)
            {
                int SEindex = ScriptedEvents_ListBox.SelectedIndex;
                int WPindex = Waypoints_ListBox.SelectedIndex;

                TriggerType_ComboBox.Text = SE_List[SEindex].Waypoint_List[WPindex].TriggerType;
                Owner_ComboBox.Text = SE_List[SEindex].Waypoint_List[WPindex].Owner;
                DialogueBoxType_ComboBox.Text = SE_List[SEindex].Waypoint_List[WPindex].BoxType;

                m_bSound_comboBox.Text = SE_List[SEindex].Waypoint_List[WPindex].bPlaySound.ToString();
                SoundName_TextBox.Text = SE_List[SEindex].Waypoint_List[WPindex].SoundName;

                Duration_numericUpDown.Value = (decimal)SE_List[SEindex].Waypoint_List[WPindex].Duration;
                WayPointScript_richTextBox.Text = SE_List[SEindex].Waypoint_List[WPindex].ScriptString;

                CollisionRectPosX_textBox.Text = SE_List[SEindex].Waypoint_List[WPindex].CollisionRect.Left.ToString();
                CollisionRectPosY_textBox.Text = SE_List[SEindex].Waypoint_List[WPindex].CollisionRect.Top.ToString();
                CollisionRectWidth_numericUpDown.Value = SE_List[SEindex].Waypoint_List[WPindex].CollisionRect.Width;
                CollisionRectHeight_numericUpDown.Value = SE_List[SEindex].Waypoint_List[WPindex].CollisionRect.Height;

                GameTime_numericUpDown.Value = SE_List[SEindex].Waypoint_List[WPindex].TimeToTrigger;
                int min = (SE_List[SEindex].Waypoint_List[WPindex].TimeToTrigger / 60);
                int sec = (SE_List[SEindex].Waypoint_List[WPindex].TimeToTrigger % 60);
                if (sec >= 10)
                    GameTime_textBox.Text = min.ToString() + ":" + sec.ToString();
                else
                    GameTime_textBox.Text = min.ToString() + ":0" + sec.ToString();

                Collectibles_ListBox.Items.Clear();
                for (int i = 0; i < SE_List[SEindex].Waypoint_List[WPindex].Required_CollectedItems.Count; i++)
                {
                    Collectibles_ListBox.Items.Add(SE_List[SEindex].Waypoint_List[WPindex].Required_CollectedItems[i]);
                }
                Collectibles_ListBox.SelectedIndex = -1;

                Craftable_textBox.Text = SE_List[SEindex].Waypoint_List[WPindex].Required_CraftedItem;

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Xml Files|*.xml";
            dlg.FilterIndex = 2;
            dlg.DefaultExt = "xml";

            if (DialogResult.OK == dlg.ShowDialog())
            {
                XElement xRoot = new XElement("ScriptedEvents");

                for (int iSE = 0; iSE < SE_List.Count(); iSE++)
                {
                    XElement xScriptedEvent = new XElement("ScriptedEvent");
                    xRoot.Add(xScriptedEvent);
                    {
                        XAttribute xEventName = new XAttribute("EventName", SE_List[iSE].EventName);
                        xScriptedEvent.Add(xEventName);

                        for (int iWP = 0; iWP < SE_List[iSE].Waypoint_List.Count(); iWP++)
                        {
                            XElement xWayPoint = new XElement("WayPoint");
                            xScriptedEvent.Add(xWayPoint);
                            {
                                XAttribute xWayPointID = new XAttribute("WayPointID", iWP);
                                xWayPoint.Add(xWayPointID);

                                XAttribute xTriggerType = new XAttribute("TriggerType", SE_List[iSE].Waypoint_List[iWP].TriggerType);
                                xWayPoint.Add(xTriggerType);

                                XAttribute xTimeToTrigger = new XAttribute("TimeToTrigger", SE_List[iSE].Waypoint_List[iWP].TimeToTrigger);
                                xWayPoint.Add(xTimeToTrigger);

                                XAttribute xRequired_CraftedItem = new XAttribute("Required_CraftedItem", SE_List[iSE].Waypoint_List[iWP].Required_CraftedItem);
                                xWayPoint.Add(xRequired_CraftedItem);

                                XAttribute xbPlaySound = new XAttribute("bPlaySound", SE_List[iSE].Waypoint_List[iWP].bPlaySound);
                                xWayPoint.Add(xbPlaySound);

                                XAttribute xSoundName = new XAttribute("SoundName", SE_List[iSE].Waypoint_List[iWP].SoundName);
                                xWayPoint.Add(xSoundName);

                                XAttribute xDuration = new XAttribute("Duration", SE_List[iSE].Waypoint_List[iWP].Duration);
                                xWayPoint.Add(xDuration);

                                XAttribute xOwner = new XAttribute("Owner", SE_List[iSE].Waypoint_List[iWP].Owner);
                                xWayPoint.Add(xOwner);

                                XAttribute xBoxType = new XAttribute("BoxType", SE_List[iSE].Waypoint_List[iWP].BoxType);
                                xWayPoint.Add(xBoxType);

                                XElement xScript = new XElement("Script");
                                xWayPoint.Add(xScript);
                                {
                                    XAttribute xScriptString = new XAttribute("ScriptString", SE_List[iSE].Waypoint_List[iWP].ScriptString);
                                    xScript.Add(xScriptString);
                                }

                                for (int iRC = 0; iRC < SE_List[iSE].Waypoint_List[iWP].Required_CollectedItems.Count; iRC++)
                                {
                                    XElement xRequired_CollectedItems = new XElement("Required_CollectedItems");
                                    xWayPoint.Add(xRequired_CollectedItems);
                                    {
                                        XAttribute xRequiredItem = new XAttribute("RequiredItem", SE_List[iSE].Waypoint_List[iWP].Required_CollectedItems[iRC]);
                                        xRequired_CollectedItems.Add(xRequiredItem);
                                    }
                                }

                                XElement xCollisionRect = new XElement("CollisionRect");
                                xWayPoint.Add(xCollisionRect);
                                {
                                    XAttribute xLeft = new XAttribute("Left", SE_List[iSE].Waypoint_List[iWP].CollisionRect.Left);
                                    xCollisionRect.Add(xLeft);

                                    XAttribute xTop = new XAttribute("Top", SE_List[iSE].Waypoint_List[iWP].CollisionRect.Top);
                                    xCollisionRect.Add(xTop);

                                    XAttribute xWidth = new XAttribute("Width", SE_List[iSE].Waypoint_List[iWP].CollisionRect.Width);
                                    xCollisionRect.Add(xWidth);

                                    XAttribute xHeight = new XAttribute("Height", SE_List[iSE].Waypoint_List[iWP].CollisionRect.Height);
                                    xCollisionRect.Add(xHeight);
                                }

                            }
                        }

                        xRoot.Save(dlg.FileName);

                    }
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Xml Files|*.xml";
            dlg.FilterIndex = 2;
            dlg.DefaultExt = "xml";

            if (DialogResult.OK == dlg.ShowDialog())
            {
                XElement xRoot = XElement.Load(dlg.FileName);

                IEnumerable<XElement> xScriptedEvents = xRoot.Elements("ScriptedEvent");

                SE_List.Clear();
                ScriptedEvents_ListBox.Items.Clear();

                int iSE = 0;
                foreach (XElement xScriptedEvent in xScriptedEvents)
                {
                    SE_List.Add(new ScriptedEvent());

                    XAttribute xEventName = xScriptedEvent.Attribute("EventName");
                    SE_List[iSE].EventName = xEventName.Value.ToString();

                    ScriptedEvents_ListBox.Items.Add(SE_List[iSE].EventName);

                    IEnumerable<XElement> xWayPoints = xScriptedEvent.Elements("WayPoint");

                    int iWP = 0;
                    foreach (XElement xWayPoint in xWayPoints)
                    {
                        SE_List[iSE].Waypoint_List.Add(new Waypoint());

                        XAttribute xWayPointID = xWayPoint.Attribute("WayPointID");
                        SE_List[iSE].Waypoint_List[iWP].WaypointID = int.Parse(xWayPointID.Value);

                        XAttribute xTriggerType = xWayPoint.Attribute("TriggerType");
                        SE_List[iSE].Waypoint_List[iWP].TriggerType = xTriggerType.Value.ToString();

                        XAttribute xTimeToTrigger = xWayPoint.Attribute("TimeToTrigger");
                        SE_List[iSE].Waypoint_List[iWP].TimeToTrigger = int.Parse(xTimeToTrigger.Value);

                        XAttribute xRequired_CraftedItem = xWayPoint.Attribute("Required_CraftedItem");
                        SE_List[iSE].Waypoint_List[iWP].Required_CraftedItem = xRequired_CraftedItem.Value.ToString();

                        XAttribute xSoundName = xWayPoint.Attribute("SoundName");
                        SE_List[iSE].Waypoint_List[iWP].SoundName = xSoundName.Value.ToString();

                        XAttribute xbPlaySound = xWayPoint.Attribute("bPlaySound");
                        SE_List[iSE].Waypoint_List[iWP].bPlaySound = bool.Parse(xbPlaySound.Value);

                        XAttribute xDuration = xWayPoint.Attribute("Duration");
                        SE_List[iSE].Waypoint_List[iWP].Duration = int.Parse(xDuration.Value);

                        XAttribute xOwner = xWayPoint.Attribute("Owner");
                        SE_List[iSE].Waypoint_List[iWP].Owner = xOwner.Value.ToString();

                        XAttribute xBoxType = xWayPoint.Attribute("BoxType");
                        SE_List[iSE].Waypoint_List[iWP].BoxType = xBoxType.Value.ToString();

                        XElement xScript = xWayPoint.Element("Script");

                        XAttribute xScriptString = xScript.Attribute("ScriptString");
                        SE_List[iSE].Waypoint_List[iWP].ScriptString = xScriptString.Value.ToString();

                        IEnumerable<XElement> xRequired_CollectedItems = xWayPoint.Elements("Required_CollectedItems");

                        int iRC = 0;
                        foreach(XElement xRequired_CollectedItem in xRequired_CollectedItems)
                        {
                            string temp = "";
                            XAttribute xRequiredItem = xRequired_CollectedItem.Attribute("RequiredItem");
                            temp = xRequiredItem.Value.ToString();
                            SE_List[iSE].Waypoint_List[iWP].Required_CollectedItems.Add(temp);

                            iRC++;
                        }

                        XElement xCollisionRect = xWayPoint.Element("CollisionRect");

                        XAttribute xLeft = xCollisionRect.Attribute("Left");
                        SE_List[iSE].Waypoint_List[iWP].CollisionRect.X = int.Parse(xLeft.Value);

                        XAttribute xTop = xCollisionRect.Attribute("Top");
                        SE_List[iSE].Waypoint_List[iWP].CollisionRect.Y = int.Parse(xTop.Value);

                        XAttribute xWidth = xCollisionRect.Attribute("Width");
                        SE_List[iSE].Waypoint_List[iWP].CollisionRect.Width = int.Parse(xWidth.Value);

                        XAttribute xHeight = xCollisionRect.Attribute("Height");
                        SE_List[iSE].Waypoint_List[iWP].CollisionRect.Height = int.Parse(xHeight.Value);
                                      

                        iWP++;
                    }

                    iSE++;
                }
            }

        }

        private void AddCollectible_button_Click(object sender, EventArgs e)
        {
            if (Waypoints_ListBox.SelectedIndex > -1)
            {
                string temp = "default";
                Collectibles_ListBox.Items.Add(temp);
                SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].Required_CollectedItems.Add(temp);
            }
        }

        private void Craftable_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Waypoints_ListBox.SelectedIndex > -1)
                SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].Required_CraftedItem =
                    Craftable_textBox.Text;
        }

        private void m_bSound_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Waypoints_ListBox.SelectedIndex > -1)
                SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].bPlaySound =
                    bool.Parse(m_bSound_comboBox.SelectedItem.ToString());
        }

        private void Collectibles_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Waypoints_ListBox.SelectedIndex > -1 && Collectibles_ListBox.SelectedIndex > -1)
            {
                Collectible_textBox.Text = SE_List[ScriptedEvents_ListBox.SelectedIndex].Waypoint_List[Waypoints_ListBox.SelectedIndex].Required_CollectedItems[Collectibles_ListBox.SelectedIndex];
            }

        }




    }

    public delegate void WapPointAdding(object sender, WayPointArgs e);

    public class WayPointArgs : EventArgs
    {
        public Cursor ChangeCursor;
        public int PosX;
        public int PosY;

        public WayPointArgs(Cursor newCursor)
        {
            ChangeCursor = newCursor;
        }

        public WayPointArgs(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }
    }
}

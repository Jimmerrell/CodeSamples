using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_MapEditor
{
    public class ScriptedEvent
    {
        public string EventName = "default";
        public List<Waypoint> Waypoint_List = new List<Waypoint>();
    }

    public class Waypoint
    {
        public int WaypointID = 0;
        public string TriggerType = "Collision";
        public int TimeToTrigger = 0;
        
        public string Required_CraftedItem = "default";
        public bool bPlaySound = false;
        public string SoundName = "default";

        public int Duration = 5;
        public string Owner = "Developer";
        public string BoxType = "Text";

        public string ScriptString = "default";
        public List<string> Required_CollectedItems = new List<string>();
        public Rectangle CollisionRect = new Rectangle();
        
    }
}

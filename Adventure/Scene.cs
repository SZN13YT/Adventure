using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure
{
    class Scene
    {
        public string Name { get; set; }
        public int SceneId { get; set; }
        public string Description { get; set; }
        public List<string> Options { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Scene(string n, string description, int x, int y, int sceneId, List<string> options = null)
        {
            this.Name = n;
            this.Description = description;
            this.X = x;
            this.Y = y;
            this.SceneId = sceneId;
            this.Options = options ?? new List<string> { "Look around", "Move forward", "Check inventory" };
        }
    }
}

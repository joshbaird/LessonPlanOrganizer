using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace LessonPlanOrganizer
{
    [Serializable]
    class Subject
    {
        public Subject()
        {
            Name = "none";
            Color = Color.Black;
        }
        public String Name;
        public Color Color;
    }
}

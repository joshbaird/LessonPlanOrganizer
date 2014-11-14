using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace LessonPlanOrganizer
{
    public class Subject
    {
        public Subject()
        {
        }
        private String _name;
        public String Name 
        { 
            get
            {
                if (_name == null)
                    _name = String.Empty;
                return _name;
            } 
            set
            {
                _name = value;
                EventsControl.RaiseSubjectChanged(this, EventArgs.Empty);
            }
        }
        private Color _color;
        public Color Color
        {
            get
            {
                if (_color == null)
                    _color = Color.Black;
                return _color;
            }
            set
            {
                _color = value;
                EventsControl.RaiseSubjectChanged(this, EventArgs.Empty);
            }
        }
    }
}

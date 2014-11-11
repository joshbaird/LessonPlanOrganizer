using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonPlanOrganizer
{
    public static class EventsControl
    {

        public class SubjectEventArgs : EventArgs
        {
            public Subject Subject;
        }
        public static event EventHandler SubjectChanged;
        public static void RaiseSubjectChanged(Object obj, EventArgs e)
        {
            if (SubjectChanged != null)
                SubjectChanged.Invoke(obj, e);
        }
        public static event EventHandler RemoveSubject;
        public static void RaiseRemoveSubject(Subject sub)
        {
            SubjectEventArgs args = new SubjectEventArgs();
            args.Subject = sub;
            if(RemoveSubject != null)
                RemoveSubject(new Object(), args);
        }
        public static event EventHandler AddNewSubject;

        public static void RaiseAddNewSubject(Subject sub)
        {
            SubjectEventArgs args = new SubjectEventArgs();
            args.Subject = sub;
            if (AddNewSubject != null)
                AddNewSubject(new Object(), args);
        }


        public static event EventHandler LessonChanged;
        public static void RaiseLessonChanged(Object obj, EventArgs e)
        {
            if (LessonChanged != null)
                LessonChanged.Invoke(obj, e);
        }
    }
}

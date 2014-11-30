using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonPlanOrganizer
{
    class LessonPlanComp : IComparer<LessonPlan>
    {
        //compares by startDate
        public int Compare (LessonPlan x, LessonPlan y)
        {
            return DateTime.Compare(x.CalendarItem.StartDate, y.CalendarItem.StartDate);
        }
    }
}

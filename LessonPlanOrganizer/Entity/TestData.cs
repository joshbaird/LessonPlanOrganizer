using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Calendar;


namespace LessonPlanOrganizer
{
    class TestData
    {
        int numRows;
        String dataType;
        int count;

        public TestData (int rows, String type)
        {
            numRows = rows;
            dataType = type;
            count = 0;
        }


        public LessonPlan [] getSubStatsData()
        {

            LessonPlan[] data = new LessonPlan[numRows];
            for (int i = 0; i < numRows; i++)
            {
                LessonPlan newLesson = new LessonPlan(new Calendar());
                newLesson.CalendarItem.Text = "My Lesson";
                DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day+1, DateTime.Now.Hour, DateTime.Now.Minute+1, 0);
                newLesson.CalendarItem.StartDate = startDate;
                DateTime endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startDate.Hour, startDate.Minute + 20, 0);
                newLesson.CalendarItem.EndDate = endDate;
                Subject sub = new Subject();
                sub.Name = "Science";
                sub.Color = System.Drawing.Color.Aqua;
                newLesson.Subject = sub;
                newLesson.Notes = "Character Counts activity, choose center in class. Students will participate in identifying characters in classroom activity.";

                data[i] = newLesson;
                                
            }
            return data;
        }

        
        public LessonPlan [] getLessonPlanData()
        {
            LessonPlan[] data;
            if (count < 4)
            {
                data = new LessonPlan[numRows];
                for (int i = 0; i < numRows; i++)
                {
                    
                    {
                        LessonPlan newLesson = new LessonPlan(new Calendar());
                        newLesson.CalendarItem.Text = "My Lesson";
                        DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day + 1, DateTime.Now.Hour, DateTime.Now.Minute + 1, 0);
                        newLesson.CalendarItem.StartDate = startDate;
                        DateTime endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startDate.Hour, startDate.Minute, 0);
                        endDate.AddMinutes(20);
                        newLesson.CalendarItem.EndDate = endDate;
                        Subject sub = new Subject();
                        sub.Name = "Science";
                        sub.Color = System.Drawing.Color.Aqua;
                        newLesson.Subject = sub;
                        newLesson.Notes = "Character Counts activity, choose center in class. Students will participate in identifying characters in classroom activity.";

                        data[i] = newLesson;
                    }
                }
                count++;
                return data;


            }
            else
            {
                data = new LessonPlan [0];
                count = 0;
                return data;
            }
        }




        public String [,] getData ()
        {

            
            if (dataType == "Lesson")
            {
                String[,] data = new String[numRows, 4];
                for (int i=0; i< numRows; i++)
                {
                    data[i, 0] = randomDate(i).ToShortDateString();
                    data[i, 1] = randomTime(i).ToShortTimeString() + " - " + randomTime(i).ToShortTimeString();
                    data[i, 2] = "Subject";
                    data[i, 3] = "Character Counts activity, choose center in class. Students will participate in identifying characters in classroom activity.";

                }
                return data;
            }

            return null;

        }

        private int randomDuration ()
        {
            int duration;
            Random rand = new Random();
            duration = rand.Next(240);
            return duration;
        }

        private DateTime randomDate (int i)
        {
            DateTime date = DateTime.Today.AddDays(i);
            return date;            
        }

        private DateTime randomTime (int i)
        {
            DateTime time = DateTime.Now.AddMinutes(i);
            return time;
        }
        

    }
}

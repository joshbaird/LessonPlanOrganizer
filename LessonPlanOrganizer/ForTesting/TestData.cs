using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _575TestProject
{
    class TestData
    {
        int numRows;
        String dataType;

        public TestData (int rows, String type)
        {
            numRows = rows;
            dataType = type;
        }

        
        public String [,] getData ()
        {

            if (dataType == "Stats")
            {
                String [,] data = new String [numRows,3];
                for (int i = 0; i < numRows; i++)
                {
                    data[i,0] = randomDate(i).ToShortDateString();
                    data[i,1] = randomTime(i).ToShortTimeString();
                    data[i,2] = randomDuration().ToString();
                }
                    return data;
            }

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

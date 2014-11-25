using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace dbcreatortest
{

    public class lesson_plan_year
    {
        public int ID { get; set; }
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class lesson_plan
    {
        public int ID { get; set; }
        public int Lesson_Plan_Year_ID { get; set; }
        public string Date { get; set; }
        public string Begin_Date { get; set; }
        public string End_Date { get; set; }
        public int Subject_ID { get; set; }
        public string Lesson_Details { get; set; }
    }

    public class subject
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    class DataBaseWrapper
    {
        public const String lesson_plan = "lesson_plan";
        public const String lesson_plan_ID = "lesson_plan_year_ID";
        public const String lesson_plan_year = "lesson_plan_year";
        public const String subject = "subject";
        public const String subject_ID = "subject_ID";

        //private SQLiteConnection m_dbConnection;
        private String connection_string = "Data Source=;Version=3;";

        /// <summary>
        /// DataBaseWrapper constructor where sqlite is the sqlite file name with .sqlite extension.
        /// </summary>
        /// <param name="sqlite">.sqlite file name.</param>
        public DataBaseWrapper(String sqlite)
        {
            connection_string = String.Format("Data Source={0};Version=3;", sqlite);
            /// <todo> Check to see if file exists here, if not create and load        
        }

        /// <summary>
        /// Return all lesson plan years.
        /// </summary>
        /// <returns> Array/List of Lesson Plan Year Objects
        public List<lesson_plan_year> selectAllLessonPlanYears()
        {
            var objects = new List<lesson_plan_year>();
            string sql = String.Format("select * from {0}", lesson_plan_year);

            using (var connection = new SQLiteConnection(connection_string))
            {
                var command = new SQLiteCommand(sql, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var lpy_obj = new lesson_plan_year();
                        lpy_obj.ID = Convert.ToInt32(reader["ID"]);
                        lpy_obj.Begin_Date = (string)reader["Begin_date"];
                        lpy_obj.End_Date = (string)reader["End_Date"];
                        objects.Add(lpy_obj);
                    }
                }
            }
            return objects;
        }

        /// <summary>
        /// Return all lesson plans.
        /// </summary>
        /// <returns>Array/List of Lesson Plan Objects
        public List<lesson_plan> selectAllLessonPlans()
        {
            var objects = new List<lesson_plan>();
            string sql = String.Format("select * from {0}", lesson_plan);

            using (var connection = new SQLiteConnection(connection_string))
            {
                var command = new SQLiteCommand(sql, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var lp_obj = new lesson_plan();
                        lp_obj.ID = Convert.ToInt32(reader["ID"]);
                        lp_obj.Lesson_Plan_Year_ID = (int)reader["Lesson_Plan_Year_ID"];
                        lp_obj.Date = (string)reader["Date"];
                        lp_obj.Begin_Date = (string)reader["Begin_date"];
                        lp_obj.End_Date = (string)reader["End_Date"];
                        lp_obj.Subject_ID = (int)reader["Subject_ID"];
                        lp_obj.Lesson_Details = (string)reader["Lesson_Details"];
                        objects.Add(lp_obj);
                    }
                }
            }
            return objects;
        }

        /// <summary>
        /// Return all subjects
        /// </summary>
        /// <returns> Array/List of Subject objects
        public List<subject> selectAllSubjects()
        {
            var objects = new List<subject>();
            string sql = String.Format("select * from {0}", subject);

            using (var connection = new SQLiteConnection(connection_string))
            {
                var command = new SQLiteCommand(sql, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var subject_obj = new subject();
                        subject_obj.ID = Convert.ToInt32(reader["ID"]);
                        subject_obj.Name = (string)reader["Name"];
                        objects.Add(subject_obj);
                    }
                }
            }
            return objects;
        }

        /// <summary>
        /// Return Lesson Plan Year object based on passed parameters.
        /// </summary>
        /// <returns>Lesson Plan Year object
        public List<lesson_plan_year> selectLessonPlanYear(int ID)
        {
            var objects = new List<lesson_plan_year>();
            string sql = String.Format("select * from {0}", lesson_plan_year);

            using (var connection = new SQLiteConnection(connection_string))
            {
                var command = new SQLiteCommand(sql, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var lpy_obj = new lesson_plan_year();
                        lpy_obj.ID = Convert.ToInt32(reader["ID"]);
                        lpy_obj.Begin_Date = (string)reader["Begin_date"];
                        lpy_obj.End_Date = (string)reader["End_date"];
                        objects.Add(lpy_obj);
                    }
                }
            }
            return objects;
        }
        
        
        /// <summary>
        /// Return Lesson Plan object based on passed parameters.
        /// </summary>
        /// <param name=></param>
        /// <returns> Lesson Plan object
        public List<lesson_plan> selectLessonPlan(String Begin_Date, String End_Date, String Subject = "")
        {
            var objects = new List<lesson_plan>();
            string sql = String.Format("SELECT * FROM {0} WHERE Date BETWEEN '{1}' AND '{2}'", lesson_plan, Begin_Date, End_Date);

            if (Subject != "")
            {
                int Subject_ID = get_subject_ID(Subject);
                sql = String.Format("SELECT * FROM {0} WHERE (Date BETWEEN '{1}' AND '{2}') AND Subject_ID = {3}", lesson_plan, Begin_Date, End_Date, Subject_ID);
            }

            
            using (var connection = new SQLiteConnection(connection_string))
            {
                var command = new SQLiteCommand(sql, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var lp_obj = new lesson_plan();
                        lp_obj.ID = Convert.ToInt32(reader["ID"]);
                        lp_obj.Lesson_Plan_Year_ID = Convert.ToInt32(reader["Lesson_Plan_Year_ID"]);
                        lp_obj.Date = (string)reader["Date"];
                        lp_obj.Begin_Date = (string)reader["Begin_date"];
                        lp_obj.End_Date = (string)reader["End_Date"];
                        lp_obj.Subject_ID = Convert.ToInt32(reader["Subject_ID"]);
                        lp_obj.Lesson_Details = (string)reader["Lesson_Details"];
                        objects.Add(lp_obj);
                    }
                }
            }
            return objects;
        }

        private int get_subject_ID(String Subject)
        {
            var subject_obj = selectSubject(Subject);
            return Convert.ToInt32(subject_obj[0].ID);
        }

        /// <summary>
        /// Return Subject object based on passed parameters.
        /// </summary>
        /// <param name=></param>
        /// <returns> Subject object
        public List<subject> selectSubject(String Subject)
        {
            var objects = new List<subject>();

            string sql = String.Format("SELECT * FROM {0} WHERE Name = '{1}'", subject, Subject);

            using (var connection = new SQLiteConnection(connection_string))
            {
                var command = new SQLiteCommand(sql, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var subject_obj = new subject();
                        subject_obj.ID = Convert.ToInt32(reader["ID"]);
                        subject_obj.Name = (string)reader["Name"];
                        objects.Add(subject_obj);
                    }
                }
            }
            return objects;
        }

        /// <summary>
        /// Create the database tables if they don't exist. 
        /// </summary>
        public void createTables()
        {
            executeSQLNonQuery(String.Format("CREATE TABLE `{0}` (`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,`Begin_Date` TEXT,`End_Date` TEXT)", lesson_plan_year));

            executeSQLNonQuery(String.Format("CREATE TABLE `{0}` (`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,`Lesson_Plan_Year_ID`	INTEGER,`Date` TEXT,`Begin_Date` TEXT,`End_Date` TEXT,`Subject_ID` INTEGER,`Lesson_Details` TEXT)", lesson_plan));

            executeSQLNonQuery(String.Format("CREATE TABLE `{0}` (`ID` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,`Name` TEXT)", subject));

            executeSQLNonQuery(String.Format("INSERT INTO sqlite_sequence (name, seq) Values ('{0}', 0)", lesson_plan_year));

            executeSQLNonQuery(String.Format("INSERT INTO sqlite_sequence (name, seq) Values ('{0}', '0')", lesson_plan));

            executeSQLNonQuery(String.Format("INSERT INTO sqlite_sequence (name, seq) Values ('{0}', '0')", subject));
        }
        
        /// <summary>
        /// Insert entry into specified table using data in dictionary key value pair format.
        /// </summary>
        /// <param name="table">Table to insert data dictionary. Tables with existing ID validation: lesson_plan, subject</param>
        /// <param name="data">A dictionary containing the desired data in key value pair.</param>
        /// <returns></returns>
        public bool Insert(String table, Dictionary<String, String> data)
	    {
	        String columns = "";
	        String values = "";
	        Boolean inserted = true;

            validateID(table, data);

            foreach (KeyValuePair<String, String> val in data)
            {
                columns += String.Format(" {0},", val.Key.ToString());
                values += String.Format(" '{0}',", val.Value);
            }
	        columns = columns.Substring(0, columns.Length - 1);
	        values = values.Substring(0, values.Length - 1);
	        try
	        {
	            executeSQLNonQuery(String.Format("INSERT INTO {0}({1}) values({2});", table, columns, values));
	        }
	        catch(Exception e)
	        {
	            Console.WriteLine("Insert method failed, error: " + e.ToString());
	            inserted = false;
	        }
	        return inserted;
	    }

        private Boolean validateID(String table, Dictionary<String, String> data)
        {
            Boolean valid = true;
            if (table == "lesson_plan")
            {
                // extract and validate Lesson_Plan_Year_ID
                if (data.ContainsKey("Lesson_Plan_Year_ID"))
                {
                    int lpy_ID = Convert.ToInt32(data["Lesson_Plan_Year_ID"]);
                    if (!doesIDexists(lpy_ID, table))
                    {
                        valid = false;
                        // Handle Lesson_Plan_Year_ID non-exist here
                        Console.WriteLine(String.Format("LPY ID: {0} does not exist.", lpy_ID));
                    }
                }
                // extract and validate Subject_ID
                if (data.ContainsKey("Subject_ID"))
                {
                    int subject_ID = Convert.ToInt32(data["Subject_ID"]);
                    if (!doesIDexists(subject_ID, "subject"))
                    {
                        valid = false;
                        // Handle Subject_ID non-exist here
                        Console.WriteLine(String.Format("Subject ID: {0} does not exist.", subject_ID));
                    }
                }
            }
            else if (table == "subject")
            {
                // extract and validate Subject_ID
                if (data.ContainsKey("Subject_ID"))
                {
                    int subject_ID = Convert.ToInt32(data["Subject_ID"]);
                    Console.WriteLine(subject_ID);
                    if (doesIDexists(subject_ID, table))
                    {
                        valid = false;
                        // Handle Subject_ID non-exist here
                        Console.WriteLine(String.Format("Subject ID: {0} does not exist.", subject_ID));
                    }
                }
            }
            return valid;
        }

        /// <summary>
        /// Update table entry based on target_ID with data in dictionary key value pair format.
        /// </summary>
        /// <param name="table">Table to perform update operation on.</param>
        /// <param name="target_ID">ID of object to update.</param>
        /// <param name="data">A dictionary containing the new data.</param>
        /// <returns></returns>
        public bool Update(String table, String target_ID, Dictionary<String, String> data)
	    {
	        String vals = "";
	        Boolean updated = true;
	        if (data.Count >= 1)
	        {
	            foreach (KeyValuePair<String, String> val in data)
	            {
	                vals += String.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString());
	            }
	            vals = vals.Substring(0, vals.Length - 1);
	        }
	        try
	        {
	            executeSQLNonQuery(String.Format("UPDATE {0} SET {1} WHERE [ID] = {2};", table, vals, target_ID));
	        }
	        catch (Exception e)
	        {
                Console.WriteLine("Update method failed, error: " + e.ToString());
                updated = false;
	        }
	        return updated;
	    }

        /// <summary>
        /// Deletes object with target_ID_to_delete in table.
        /// </summary>
        /// <param name="table">Table to perform delete operation on.</param>
        /// <param name="target_ID_to_delete">Target ID to delete by.</param>
        /// <returns> Returns true on successful deletion and false on failure to delete.</returns>
        public Boolean delete(String table, String target_ID)
        {
            Boolean deleted = true;
            try
            {
                executeSQLNonQuery(String.Format("DELETE FROM {0} WHERE [ID] = '{1}';", table, target_ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to delete, error: " + e.ToString());
                deleted = false;
            }
            return deleted;
        }

        /// <summary>
        /// Checks sqlite_master to see if specified table exists
        /// </summary>
        /// <param name="table_name">Table to search in sqlite_master.</param>
        /// <returns> Returns true if table exists, false otherwise.</returns>
        private Boolean doesTableExists(String table_name)
        {
            int count = 0;
            String sql = String.Format("SELECT count * FROM sqlite_master WHERE type='table' AND name='{0}'", table_name);
            using (var connection = new SQLiteConnection(connection_string))
            {
                var command = new SQLiteCommand(sql, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                }
                Console.WriteLine("Count is: " + count);
                if (count == 0)
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// Establish connection with database and execute SQL command string.
        /// <param name="sql">SQL command.</param>
        /// <param name="connection_string">Connection string to database.</param>
        /// </summary>
        private int executeSQLNonQuery(String sql)
        {
            try
            {
                using (var connection = new SQLiteConnection(connection_string))
                {
                    var command = new SQLiteCommand(sql, connection);
                    connection.Open();
                    int rows = command.ExecuteNonQuery();
                    connection.Close();
                    return rows;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("DataBaseWrapper encounter a connection error: ", e.ToString());
                return -1;
            }
        }

        private bool doesIDexists(int ID, string table)
        {
            string sql = String.Format("SELECT * FROM {0} WHERE [ID] = {1}", table, ID);
            using (var connection = new SQLiteConnection(connection_string))
            {
                var command = new SQLiteCommand(sql, connection);

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) == ID)
                            {
                                return true;
                            }
                        }
                        connection.Close();
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Function doesIDexists encountered an error: " + e.ToString());
                    return false;
                }
            }
        }
    }
}

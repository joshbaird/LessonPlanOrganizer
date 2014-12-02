using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms.Calendar;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Data.SQLite;

namespace LessonPlanOrganizer
{
    class DataBaseWrapper
    {
        public const String lesson_plan = "lesson_plan";
        public const String lesson_plan_ID = "lesson_plan_year_ID";
        public const String lesson_plan_year = "lesson_plan_year";
        public const String subject = "subject";
        public const String subject_ID = "subject_ID";

        private String connection_string = "Data Source=;Version=3;";

        /// <summary>
        /// DataBaseWrapper constructor where sqlite is the sqlite file name with .sqlite extension.
        /// </summary>
        /// <param name="sqlite">.sqlite file name.</param>
        public DataBaseWrapper(String sqlite)
        {
            connection_string = String.Format("Data Source={0};Version=3;", sqlite);
            /// <todo> Check to see if file exists here, if not create and load
            if (File.Exists(sqlite))
            {
                Console.WriteLine("DEBUG MSG: Database file exists.");
                if (doesTableExists(lesson_plan_year) == false)
                {
                    Console.WriteLine("DEBUG MSG: Table does not exist.");
                    createTables();
                }
            }
            else
            {
                // Consider throwing an exception?
                Console.WriteLine("Database file does not exist.");
            }
        }

        /// <summary>
        /// Create the database tables if they don't exist. 
        /// </summary>
        public void createTables()
        {
            executeSQLNonQuery(String.Format("CREATE TABLE `{0}` (`ID` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,`DATA` BLOB)", lesson_plan_year));
            executeSQLNonQuery(String.Format("INSERT INTO sqlite_sequence (name, seq) Values ('{0}', 0)", lesson_plan_year));
        }

        public void serializeLessonPlanYear(LessonPlanYear LPY)
        {
            byte[] arData;
 
            using(MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, LPY);
                arData = stream.ToArray();
                stream.Close();
            }
            
            string sql = String.Format("INSERT INTO {0} (DATA) VALUES(?)", lesson_plan_year);
            executeSQLNonQueryWithBlob(sql, "DATA", arData);
        }

        public LessonPlanYear deserializeLessonPlanYear()
        {
            LessonPlanYear LPY;
            string sql = String.Format("SELECT ID, DATA FROM {0} ", lesson_plan_year);
            DataTable dt = getDataTable(sql);

            // Possible for null to occur here as datatable may be empty. Review this.
            int index;
            if (dt != null) index = dt.Rows.Count - 1;
            else index = -1;
            if (index <= -1)
                return null;

            object val = dt.Rows[index].Field<byte[]>(1);

            byte[] arData = (byte []) val;

            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(arData, 0, arData.Length);
                stream.Seek(0, SeekOrigin.Begin);

                BinaryFormatter formatter = new BinaryFormatter();
                LPY = (LessonPlanYear)formatter.Deserialize(stream);
            }
            return LPY;
        }
        
        /// <summary>
        /// Insert entry into specified table using data in dictionary key value pair format.
        /// </summary>
        /// <param name="table">Table to insert data dictionary. Tables with existing ID validation: lesson_plan, subject</param>
        /// <param name="data">A dictionary containing the desired data in key value pair.</param>
        /// <returns></returns>
        private bool Insert(String table, Dictionary<String, String> data)
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
        private bool Update(String table, String target_ID, Dictionary<String, String> data)
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
        private Boolean delete(String table, String target_ID)
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
            String sql = String.Format("SELECT count (*) FROM sqlite_master WHERE type='table' AND name='{0}'", table_name);
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
                //Console.WriteLine("Count is: " + count);
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
                    using( var command = new SQLiteCommand(sql, connection))
                    {
                        command.Connection.Open();
                        int rows = command.ExecuteNonQuery();
                        command.Connection.Close();
                        return rows;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("DataBaseWrapper encounter an SQL non query error: ", e.ToString());
                return -1;
            }
        }

        private int executeSQLNonQueryWithBlob(string sql, string blobFieldName, byte[] blob)
        {
            try
            {
                using (var connection = new SQLiteConnection(connection_string))
                {
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Connection.Open();
                        command.Parameters.AddWithValue("@" + blobFieldName, blob);
                        int rows =  command.ExecuteNonQuery();
                        command.Connection.Close();
                        return rows;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("DataBaseWrapper encounter an SQL non query with blob error: ", e.ToString());
                return -1;
            }
        }
        /// <summary>
	    /// Allows the programmer to run a query against the Database.
	    /// </summary>
	    /// <param name="sql">The SQL to run</param>
	    /// <returns>A DataTable containing the result set.</returns>
	    private DataTable getDataTable(string sql)
	    {
	        DataTable dt = new DataTable();
	        try
	        {
                using (var connection = new SQLiteConnection(connection_string))
                {
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Connection.Open();
                        command.CommandText = sql;
                        SQLiteDataReader reader = command.ExecuteReader();
                        dt.Load(reader);
                        reader.Close();
                        command.Connection.Close();
                        return dt;
                    }
                }
	        }
	        catch (Exception e)
	        {
	            //throw new Exception(e.Message);
                Console.WriteLine("DataBaseWrapper encounter an SQL get table error: ", e.ToString());
                return null;
	        }
	    }

        /// <summary>
	    /// Allows the programmer to retrieve single items from the DB.
	    /// </summary>
	    /// <param name="sql">The query to run.</param>
	    /// <returns>A string.</returns>
	    private string executeScalar(string sql)
	    {
            try
            {
                using (var connection = new SQLiteConnection(connection_string))
                {
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Connection.Open();
                        command.CommandText = sql;
                        object value = command.ExecuteScalar();
                        command.Connection.Close();
                        if (value != null)
                        {
                            return value.ToString();
                        }
                        return "";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("DataBaseWrapper encounter an SQL scalar query error: ", e.ToString());
                return "error";
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

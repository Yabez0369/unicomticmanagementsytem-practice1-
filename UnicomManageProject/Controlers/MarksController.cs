using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomManageProject.DatabaseManager;
using UnicomManageProject.Models;


        

namespace UnicomManageProject.Controllers
    {
        public class MarksController
        {
            public static List<Marks> GetAllMarks()
            {
                List<Marks> list = new List<Marks>();
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = "SELECT * FROM marks";
                    using (var cmd = new SQLiteCommand(query, con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Marks
                            {
                                Id = reader.GetInt32(0),
                                StudentId = reader.GetString(1),
                                StudentName = reader.GetString(2),
                                Subject = reader.GetString(3),
                                Exam = reader.GetString(4),
                                Score = reader.GetString(5)
                            });
                        }
                    }
                }
                return list;
            }
        }
    

}


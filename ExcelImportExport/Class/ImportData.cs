using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

namespace ExcelImportExport.Class
{
    public static class ImportData
    {
        public static void SaveData(int studentid, string firstname, string lastname, string email, double gpa)
        {
            using (MySqlConnection cnn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ToString()))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO student (studentid, firstname, lastname, email, gpa) VALUES (@studentid, @firstname, @lastname, @email, @gpa)";
                    cmd.Parameters.AddWithValue("firstname", firstname);
                    cmd.Parameters.AddWithValue("lastname", lastname);
                    cmd.Parameters.AddWithValue("studentid", studentid);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("gpa", gpa);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateData(int id, int studentid, string firstname, string lastname, string email, double gpa)
        {
            using (MySqlConnection cnn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ToString()))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE student SET studentid=@studentid, firstname=@firstname, lastname=@lastname, email=@email, gpa=@gpa WHERE id=@id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("studentid", studentid);
                    cmd.Parameters.AddWithValue("firstname", firstname);
                    cmd.Parameters.AddWithValue("lastname", lastname);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("gpa", gpa);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;

namespace ExcelImportExport.Class
{
    public static class PassData
    {
        public static int studentvalue { get; set; }
        public static string firstName { get; set; }
        public static string lastName { get; set; }
        public static int studentId { get; set; }
        public static string email { get; set; }
        public static double gpa { get; set; }
    }

    public static class ReportData
    {
        public static int SaveData(int studentid, string firstname, string lastname, string email, double gpa)
        {
            using (MySqlConnection cnn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ToString()))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO student (studentid, firstname, lastname, email, gpa) VALUES (@studentid, @firstname, @lastname, @email, @gpa); SELECT LAST_INSERT_ID()";
                    cmd.Parameters.AddWithValue("firstname", firstname);
                    cmd.Parameters.AddWithValue("lastname", lastname);
                    cmd.Parameters.AddWithValue("studentid", studentid);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("gpa", gpa);
                    return Convert.ToInt32(cmd.ExecuteScalar());
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

    public static class ConvertToExcel
    {
        public static DataTable GetReportData(DataTable dt, string savePath)
        {
            DataTable dtFinal = new DataTable();
            //DataColumn dc = dtFinal.Columns.Add("id", typeof(int));
            //dc.Unique = true;
            dtFinal.Columns.Add("Student ID", typeof(int));
            dtFinal.Columns.Add("First Name", typeof(string));
            dtFinal.Columns.Add("Last Name", typeof(string));
            dtFinal.Columns.Add("GPA", typeof(decimal));
            dtFinal.Columns.Add("Email", typeof(string));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtFinal.NewRow();
                dr["Student ID"] = dt.Rows[i]["studentid"];
                dr["First Name"] = dt.Rows[i]["firstname"];
                dr["Last Name"] = dt.Rows[i]["lastname"];
                dr["GPA"] = Convert.ToDecimal(dt.Rows[i]["gpa"]);
                dr["Email"] = dt.Rows[i]["email"];
                dtFinal.Rows.Add(dr);
            }

            //GenerateExcel(dtFinal, savePath);
            return dtFinal;
        }

        private static void GenerateExcel(DataTable _dtFinal, string _savePath)
        {
            ExcelNPOIWriter excelObj = new ExcelNPOIWriter();
            excelObj.CreateWorksheet("Sheet1");
            excelObj.WriteData(_dtFinal, "Sheet1", true, 4);
            AutoSizeColumns(excelObj, _dtFinal, "Sheet1");
            HSSFSheet sheet1 = excelObj.GetWorksheet("Sheet1");
            sheet1.PrintSetup.Landscape = true;

            //styles
            //alignment
            excelObj.createStyle("Headers");
            excelObj.setAlignment("Headers", HorizontalAlignment.Center);
            excelObj.setBorders("Headers", BorderStyle.Medium);
            excelObj.setFont("Headers", true, HSSFColor.DarkBlue.Index);
            excelObj.setShrinkToFit("Headers", true);
            excelObj.setFillForeground("Headers", HSSFColor.Grey25Percent.Index, FillPattern.SolidForeground);

            try
            {
                for (int i = 0; i < _dtFinal.Rows.Count; i++)
                {
                    for (int b = 0; b < _dtFinal.Columns.Count; b++)
                    {
                        excelObj.getCell(4 + i, b, "Sheet1").CellStyle = excelObj.getStyle("Headers");
                    }
                }

                excelObj.getCell(4, 0, "Sheet1").CellFormula = string.Format("A{0} - A{1}", 1, 2);
                excelObj.Save(_savePath);
            }
            catch (Exception e)
            {
                excelObj.Dispose();
            }
            finally { excelObj.Dispose(); }
            System.Diagnostics.Process.Start(_savePath);
        }

        private static void AutoSizeColumns(ExcelNPOIWriter exObj, DataTable tbl, string sheetName)
        {
            for (int i = 0; i <= tbl.Columns.Count; i++)
            {
                exObj.AutoSizeColumn(i, sheetName);
            }
        }
    }
}


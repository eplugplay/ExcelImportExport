using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
using System.Configuration;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using System.IO;
using NPOI.XSSF.UserModel;

namespace ExcelImportExport.Class
{
    public static class ImportData
    {
        public static void LoadExcel(ArrayList path)
        {
            DataTable dt = new DataTable();
            DataColumn dc = dt.Columns.Add("studentid", typeof(int));
            dt.Columns.Add("firstname", typeof(string));
            dt.Columns.Add("lastname", typeof(string));
            dt.Columns.Add("gpa", typeof(double));
            dt.Columns.Add("email", typeof(string));
            IWorkbook WorkBook = null;
            try
            {
                for (int i = 0; i < path.Count; i++)
                {
                    string[] checkPath = path[i].ToString().Split('\\');
                    string[] extSplit = checkPath[(checkPath.Length - 1)].ToString().Split('.');

                    using (FileStream file = new FileStream(path[i].ToString(), FileMode.Open, FileAccess.Read))
                    {
                        if (extSplit[1].ToString().ToUpper().Equals("XLSX"))
                        {
                            WorkBook = new XSSFWorkbook(file);
                        }
                        else if (extSplit[1].ToString().ToUpper().Equals("XLS"))
                        {
                            WorkBook = new HSSFWorkbook(file);
                        }
                        var sheet = WorkBook.GetSheet("Report1");

                        for (int row = 0; row < sheet.LastRowNum; row++)
                        {
                            if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
                            {
                                DataRow dr = dt.NewRow();
                                try
                                {
                                    dr["studentid"] = Convert.ToInt32(sheet.GetRow(row + 1).GetCell(0).NumericCellValue.ToString());
                                }
                                catch
                                {
                                    dr["studentid"] = Convert.ToInt32(sheet.GetRow(row + 1).GetCell(0).StringCellValue.ToString());
                                }
                                dr["firstname"] = sheet.GetRow(row + 1).GetCell(1).StringCellValue.ToString();
                                dr["lastname"] = sheet.GetRow(row + 1).GetCell(2).StringCellValue.ToString();
                                try
                                {
                                    dr["gpa"] = Convert.ToDouble(sheet.GetRow(row + 1).GetCell(3).NumericCellValue.ToString());
                                }
                                catch
                                {
                                    dr["gpa"] = Convert.ToDouble(sheet.GetRow(row + 1).GetCell(3).StringCellValue.ToString());
                                }
                                dr["email"] = sheet.GetRow(row + 1).GetCell(4).StringCellValue.ToString();
                                dt.Rows.Add(dr);
                            }
                        }
                    }
                }
                SaveExcelToDb(dt);
            }
            catch
            {

            }
        }

        public static void SaveExcelToDb(DataTable dt)
        {
            using (MySqlConnection cnn = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ToString()))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmd.CommandText = "INSERT INTO student (studentid, firstname, lastname, email, gpa) VALUES (@studentid, @firstname, @lastname, @email, @gpa)";
                        cmd.Parameters.AddWithValue("studentid", Convert.ToInt32(dt.Rows[i]["studentid"]));
                        cmd.Parameters.AddWithValue("firstname", dt.Rows[i]["firstname"].ToString());
                        cmd.Parameters.AddWithValue("lastname", dt.Rows[i]["lastname"].ToString());
                        cmd.Parameters.AddWithValue("gpa", Convert.ToDouble(dt.Rows[i]["gpa"]));
                        cmd.Parameters.AddWithValue("email", dt.Rows[i]["email"].ToString());
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
            }
        }
    }
}

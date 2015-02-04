using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using System.IO;
using NPOI.XSSF.UserModel;

namespace ExcelImportExport.Class
{
    public static class ImportData
    {
        public static void LoadExcel(string path)
        {
            DataTable dt = new DataTable();

            HSSFWorkbook workbook1;
            XSSFWorkbook workbook2;
            if (path.Contains(".xls"))
            {
                using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    workbook1 = new HSSFWorkbook(file);
                    var sheet = workbook1.GetSheet("Sheet1");
                    for (int row = 0; row <= sheet.LastRowNum; row++)
                    {
                        if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
                        {
                            DataRow dr = dt.NewRow();

                            string s = string.Format("Row {0} = {1}", row, sheet.GetRow(row).GetCell(0).StringCellValue);
                        }
                    }
                }
            }
            else if (path.Contains(".xlsx"))
            {
                using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    workbook2 = new XSSFWorkbook(file);
                    var sheet = workbook2.GetSheet("Sheet1");
                }
            }
        }
    }
}

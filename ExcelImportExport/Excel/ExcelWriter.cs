using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using NPOI.HSSF.UserModel;

namespace ExcelImportExport
{
    enum ExcelEngine
    {
        Interop,
        NPOI
    }
    abstract class ExcelWriter:IDisposable
    {
        protected Dictionary<string, HSSFCellStyle> ExcelStyles = new Dictionary<string, HSSFCellStyle>();
        protected bool IsDisposed=false;

        protected abstract void WriteCell(int Column, int Row, string WorksheetName, object Value);
        public abstract void Save(string FileName);
        public abstract void CreateWorksheet(string worksheetname);
        public abstract void AutoSizeColumn(int column, string worksheetName);
        protected abstract void Dispose(bool Disposing);

        public string DateFormat{ get; set; }

        protected ExcelWriter()
        {
            DateFormat = System.Configuration.ConfigurationManager.AppSettings["DefaultExcelDateFormat"];
        }

        ~ExcelWriter()
        {
            Dispose(false);
        }

        public void WriteData(DbDataReader dr, string WorksheetName, bool addColumnHeaders)
        {
            DataTable temp = new DataTable();
            temp.Load(dr);
            WriteData(temp, WorksheetName, addColumnHeaders);
        }

        public void WriteData(DataTable dt, string WorksheetName, bool addColumnHeaders, int offset)
        {
            
            if (addColumnHeaders)
            {
                var columnHeadings = new List<string>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (!dt.Columns[i].ColumnName.StartsWith("BLANK"))
                    {
                        columnHeadings.Add(dt.Columns[i].ColumnName.Replace("_", " "));
                    }
                    else
                    {
                        columnHeadings.Add("");
                    }
                }
                WriteRow(columnHeadings.ToArray(), offset, WorksheetName);
                offset++;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WriteRow(dt.Rows[i], i + offset, WorksheetName);
            }
        }
        // row offset and column
        public void WriteData(DataTable dt, string WorksheetName, bool addColumnHeaders, int rowOffset, int colOffset)
        {

            if (addColumnHeaders)
            {
                var columnHeadings = new List<string>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (!dt.Columns[i].ColumnName.StartsWith("BLANK"))
                    {
                        columnHeadings.Add(dt.Columns[i].ColumnName.Replace("_", " "));
                    }
                    else
                    {
                        columnHeadings.Add("");
                    }
                }
                WriteRow(columnHeadings.ToArray(), rowOffset, WorksheetName);
                rowOffset++;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WriteRow(dt.Rows[i], i + rowOffset, colOffset, WorksheetName);
            }
        }

        public void WriteData(DataTable dt, string WorksheetName, bool addColumnHeaders)
        {
            int offset = 0;
            if (addColumnHeaders)
            {
                var columnHeadings = new List<string>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (!dt.Columns[i].ColumnName.StartsWith("BLANK"))
                    {
                        columnHeadings.Add(dt.Columns[i].ColumnName);
                    }
                    else
                    {
                        columnHeadings.Add("");
                    }
                }
                WriteRow(columnHeadings.ToArray(), 0, WorksheetName);
                offset++;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WriteRow(dt.Rows[i], i + offset, WorksheetName);
            }
        }

        private void WriteRow(object[] toWrite, int RowIndex, string WorksheetName)
        {
            for (int i = 0; i < toWrite.Length; i++)
            {
                WriteCell(i, RowIndex, WorksheetName, toWrite[i]);
            }
        }
        // row and col
        private void WriteRow(object[] toWrite, int RowIndex, int ColIndex, string WorksheetName)
        {
            for (int i = 0; i < toWrite.Length; i++)
            {
                WriteCell(i + ColIndex, RowIndex, WorksheetName, toWrite[i]);
            }
        }

        private void WriteRow(DataRow dr, int RowIndex, string WorksheetName)
        {
            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                WriteCell(i, RowIndex, WorksheetName,dr[i]);
            }
        }

        // row and col
        private void WriteRow(DataRow dr, int RowIndex, int ColIndex, string WorksheetName)
        {
            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                WriteCell(i + ColIndex, RowIndex, WorksheetName, dr[i]);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void AddStyle(string name, HSSFCellStyle style)
        {
            if (ExcelStyles.ContainsKey(name))
                return;

            ExcelStyles.Add(name, style);
        }
    }
}

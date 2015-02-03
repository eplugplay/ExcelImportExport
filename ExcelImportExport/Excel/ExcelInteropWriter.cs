using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelImportExport
{
    //IF YOU CALL GetWorksheet() YOU NEED TO CALL ReleaseObject() ON THE WORKSHEET IT RETURNS!
    //IF YOU CALL GetWorksheet() YOU NEED TO CALL ReleaseObject() ON THE WORKSHEET IT RETURNS!
    //IF YOU CALL GetWorksheet() YOU NEED TO CALL ReleaseObject() ON THE WORKSHEET IT RETURNS!
    //IF YOU CALL GetWorksheet() YOU NEED TO CALL ReleaseObject() ON THE WORKSHEET IT RETURNS!
    //IF YOU CALL GetWorksheet() YOU NEED TO CALL ReleaseObject() ON THE WORKSHEET IT RETURNS!

    class ExcelInteropWriter:ExcelWriter
    {
        private Microsoft.Office.Interop.Excel.Application xlApp;
        private Microsoft.Office.Interop.Excel.Workbook xlWB;

        public ExcelInteropWriter()
        {
            try
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                xlApp = null;
                throw new ExcelWriterException("Creation of the Excel application object failed. Excel may not be installed.", ex);

            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            xlWB = workbooks.Add(Type.Missing);
            ReleaseObject(workbooks);
        }
        protected override void Dispose(bool Disposing)
        {
            if (!IsDisposed)
            {
                if (Disposing)
                {
                    //Managed Resources

                }
                //Unmanaged Resources
                xlWB.Close(Type.Missing, Type.Missing, Type.Missing);
                ReleaseObject(xlWB);
                int hWnd = xlApp.Application.Hwnd;
                xlApp.Quit();
                this.ReleaseObject(xlApp);
                //Die already!
                Class.Uti.TryKillProcessByMainWindowHwnd(hWnd);
            }
            IsDisposed = true;
        }

        private void ReleaseObject(object o)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
            }
            finally
            {
                o = null;
            }
        }

        private Microsoft.Office.Interop.Excel.Worksheet GetWorksheet(string WorksheetName)
        {
            Microsoft.Office.Interop.Excel.Sheets sheets = xlWB.Worksheets;
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets[WorksheetName]; 
            ReleaseObject(sheets);
            return sheet;
        }

        protected override void WriteCell(int Column, int Row, string WorksheetName, object Value)
        {
            Microsoft.Office.Interop.Excel.Worksheet sheet = GetWorksheet(WorksheetName);
            ((Microsoft.Office.Interop.Excel._Worksheet)sheet).Activate();
            Microsoft.Office.Interop.Excel.Range tmpRange = ((Microsoft.Office.Interop.Excel.Range)sheet.Cells);
            Microsoft.Office.Interop.Excel.Range writingRange = (Microsoft.Office.Interop.Excel.Range)tmpRange[Row + 1, Column + 1];
            writingRange.Value2 = Value;
            if (Row == 0)
            {
                writingRange.Font.Bold = true;
            }
            ReleaseObject(sheet);
            ReleaseObject(tmpRange);
            ReleaseObject(writingRange);
        }

        public override void Save(string FileName)
        {
            xlWB.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel5,
                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                    Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing,
                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }

        public override void CreateWorksheet(string worksheetname)
        {
            Microsoft.Office.Interop.Excel.Sheets sheets = xlWB.Worksheets;
            Microsoft.Office.Interop.Excel.Worksheet newWS = (Microsoft.Office.Interop.Excel.Worksheet)sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            newWS.Name = worksheetname;

            ReleaseObject(sheets);
            ReleaseObject(newWS);
        }

        public override void AutoSizeColumn(int column, string WorksheetName)
        {
            Microsoft.Office.Interop.Excel.Worksheet sheet = GetWorksheet(WorksheetName);
            string columnName = GetExcelColumnName(column + 1);
            Microsoft.Office.Interop.Excel.Range rng = sheet.get_Range(columnName + "1", columnName + "1");
            Microsoft.Office.Interop.Excel.Range entireColumn = rng.EntireColumn;
            entireColumn.AutoFit();

            ReleaseObject(sheet);
            ReleaseObject(rng);
            ReleaseObject(entireColumn);
        }

        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            } 

            return columnName;
        }
    }
}

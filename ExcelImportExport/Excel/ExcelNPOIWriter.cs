using System;
using System.Collections.Generic;
using System.Text;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
namespace ExcelImportExport
{
    class ExcelNPOIWriter:ExcelWriter
    {
        HSSFWorkbook hssfworkbook;
        IDataFormat fmt;
        ICellStyle dateStyle;
        public ExcelNPOIWriter()
        {
            hssfworkbook = new HSSFWorkbook();

            fmt = hssfworkbook.CreateDataFormat();
            dateStyle = hssfworkbook.CreateCellStyle();
            dateStyle.DataFormat = fmt.GetFormat(this.DateFormat);
        }
        protected override void WriteCell(int Column, int Row, string WorksheetName, object Value)
        {
            Type valueType = Value.GetType();
            HSSFSheet worksheet = VerifyWorksheet(WorksheetName);
            HSSFRow wsRow = (HSSFRow)worksheet.GetRow(Row) ?? (HSSFRow)worksheet.CreateRow(Row);
            HSSFCell cell = (HSSFCell)wsRow.CreateCell(Column); 

            if (valueType == typeof(DateTime))
            {
                WriteCellTypeValue(Convert.ToDateTime(Value), cell);
            }
            else if (valueType == typeof(Double) || valueType == typeof(Decimal))
            {
                WriteCellTypeValue(Convert.ToDouble(Value), cell);
            }
            else
            {
                WriteCellTypeValue(Value.ToString(), cell);
            }
        }
        public void CreateHeader(string worksheetname, string value, string reportDate)
        {
            WriteCell(5, 1, worksheetname, value);
            WriteCell(5, 0, worksheetname, reportDate);
        }

        public void CreateHeader(string worksheetname, string value, string reportDate, int offset)
        {
            WriteCell(offset, 1, worksheetname, value);
            WriteCell(offset, 0, worksheetname, reportDate);
        }

        private void WriteCellTypeValue(double Value, HSSFCell cell)
        {
            cell.SetCellType(CellType.Numeric);
            cell.SetCellValue(Value);
        }

        private void WriteCellTypeValue(DateTime Value, HSSFCell cell)
        {
            cell.SetCellType(CellType.Numeric);
            cell.CellStyle = dateStyle;
            cell.SetCellValue(Value);
        }

        private void WriteCellTypeValue(string Value, HSSFCell cell)
        {
            cell.SetCellValue(Value);
        }

        public override void Save(string FileName)
        {
            FileStream file = new FileStream(FileName, FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
        }
     
        public override void CreateWorksheet(string worksheetname)
        {
            hssfworkbook.CreateSheet(worksheetname);
        }

        private HSSFSheet VerifyWorksheet(string worksheetname)
        {
            HSSFSheet tempWS = GetWorksheet(worksheetname);
            if (tempWS == null)
            {
                CreateWorksheet(worksheetname);
                tempWS = GetWorksheet(worksheetname);
            }
            return tempWS;
        }

        public override void AutoSizeColumn(int column, string worksheetName)
        {
            HSSFSheet tempWS = GetWorksheet(worksheetName);
            tempWS.AutoSizeColumn(column);
        }

        protected override void Dispose(bool Disposing)
        {
            hssfworkbook.Clear();
        }

        public HSSFSheet GetWorksheet(string worksheetName)
        {
            return (HSSFSheet)hssfworkbook.GetSheet(worksheetName);
        }

        public HSSFCell getCell(int rowIndex, int columnIndex, string workSheet)
        {
            HSSFSheet worksheet = VerifyWorksheet(workSheet);
            HSSFRow wsRow = (HSSFRow)worksheet.GetRow(rowIndex);
            return (HSSFCell)wsRow.GetCell(columnIndex);
        }

        //styles
        public void createStyle(string name)
        {
            AddStyle(name, (HSSFCellStyle)hssfworkbook.CreateCellStyle());
        }

        public HSSFCellStyle getStyle(string name)
        {
            if (!ExcelStyles.ContainsKey(name))
                return null;
            
            return ExcelStyles[name];
        }

        public void setDataFormat(string name, string format, bool builtin)
        {
            if(builtin)
                ExcelStyles[name].DataFormat = HSSFDataFormat.GetBuiltinFormat(format);
            else
                ExcelStyles[name].DataFormat = new HSSFDataFormat(hssfworkbook.Workbook).GetFormat(format);
        }

        public void setBorders(string name, NPOI.SS.UserModel.BorderStyle type)
        {
            ExcelStyles[name].BorderBottom = type;
            ExcelStyles[name].BorderLeft = type;
            ExcelStyles[name].BorderRight = type;
            ExcelStyles[name].BorderTop = type;
        }

        public void setBorders(string name, bool top, bool bottom, bool left, bool right, BorderStyle type)
        {
            if(bottom)
                ExcelStyles[name].BorderBottom = type;
            if(left)
                ExcelStyles[name].BorderLeft = type;
            if(right)
                ExcelStyles[name].BorderRight = type;
            if(top)
                ExcelStyles[name].BorderTop = type;
        }

        public void setFont(string name, bool bold)
        {
            HSSFFont font = (HSSFFont)hssfworkbook.CreateFont();
            if(bold)
                font.Boldweight = (short)FontBoldWeight.Bold;
            
            ExcelStyles[name].SetFont(font);
        }

        public void setFont(string name, bool bold, short color)
        {
            HSSFFont font = (HSSFFont)hssfworkbook.CreateFont();
            if (bold)
                font.Boldweight = (short)FontBoldWeight.Bold;
            font.Color = color;

            ExcelStyles[name].SetFont(font);
        }

        public void setAlignment(string name, HorizontalAlignment align)
        {
            ExcelStyles[name].Alignment = align;
        }

        public void setShrinkToFit(string name, bool stf)
        {
            ExcelStyles[name].ShrinkToFit = stf;
        }

        public void setFillForeground(string name, short color, FillPattern type)
        {
            ExcelStyles[name].FillForegroundColor = color;
            ExcelStyles[name].FillPattern = type;
        }
    }
}

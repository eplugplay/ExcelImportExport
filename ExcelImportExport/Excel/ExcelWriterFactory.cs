using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelImportExport
{
    class ExcelWriterFactory
    {
        public static ExcelWriter GetExcelWriter(ExcelEngine type)
        {
            switch (type)
            {
                case ExcelEngine.Interop:
                    return new ExcelInteropWriter();
                case ExcelEngine.NPOI:
                    return new ExcelNPOIWriter();
                default:
                    throw new NotSupportedException();

            }
        }

    }
}

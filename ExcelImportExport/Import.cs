using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelImportExport.Class;

namespace ExcelImportExport
{
    public partial class Import : Form
    {
        public Import()
        {
            InitializeComponent();
        }

        private void importExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExportExcel()
        {
            string path = GetSavePath();
            if (path != "")
            {
                ImportData.LoadExcel(path);
            }
        }

        private string GetSavePath()
        {
            string ToBeReturned;
            openFileDialog.DefaultExt = "*.xls";
            openFileDialog.Filter = "Excel File (*.xls or .xlsx)|.xls;*.xlsx|All files (*.*)|*.*";
            //openFileDialog.FileName = "Export - " + DateTime.Now.ToString("MMM-yy") + ".xls";
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ToBeReturned = openFileDialog.FileName;
            }
            else
            {
                ToBeReturned = string.Empty;
            }
            return ToBeReturned;
        }
    }
}

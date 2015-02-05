using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using ExcelImportExport.Class;

namespace ExcelImportExport
{
    public partial class MainMenu : Form
    {
        public static Report _Report;
        public static NewImport _NewImport;
        public MainMenu()
        {
            InitializeComponent();
        }
        private void newReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_NewImport == null || _NewImport.IsDisposed)
            {
                _NewImport = new NewImport();
                _NewImport.Show();
            }
            else
            {
                if (_NewImport.WindowState == FormWindowState.Minimized)
                {
                    _NewImport.WindowState = FormWindowState.Normal;
                }
                else
                {
                    _NewImport.BringToFront();
                }
            }
        }

        private void editReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Report == null || _Report.IsDisposed)
            {
                _Report = new Report();
                _Report.Show();
            }
            else
            {
                if (_Report.WindowState == FormWindowState.Minimized)
                {
                    _Report.WindowState = FormWindowState.Normal;
                }
                else
                {
                    _Report.BringToFront();
                }
            }
        }
        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_Report == null || _Report.IsDisposed)
            {
                _Report = new Report();
                _Report.Show();
            }
            else
            {
                if (_Report.WindowState == FormWindowState.Minimized)
                {
                    _Report.WindowState = FormWindowState.Normal;
                }
                else
                {
                    _Report.BringToFront();
                }
            }
        }

        private void ExportExcel()
        {
            ArrayList path = GetSavePath();
            if (path.Count != 0)
            {
                ImportData.LoadExcel(path);
                MessageBox.Show("Export Complete!");
            }
        }

        private ArrayList GetSavePath()
        {
            ArrayList ToBeReturned = new ArrayList();
            openFileDialog.Multiselect = true;
            openFileDialog.DefaultExt = "*.xls|*.xlsx";
            openFileDialog.Filter = "Excel File (*.xls or .xlsx)|.xls;*.xlsx|All files (*.*)|*.*";
            //openFileDialog.FileName = "Export - " + DateTime.Now.ToString("MMM-yy") + ".xls";
            openFileDialog.FileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    ToBeReturned.Add(file);
                }
            }
            return ToBeReturned;
        }
       
    }
}

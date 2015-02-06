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

        private class PassData
        {
            public PassData(ArrayList _savedPath) { savedPath = _savedPath; }
            public ArrayList savedPath { get; set; }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //enable progress bar
            lblStatus.InvokeEx(x => x.Visible = true);
            progressBar.InvokeEx(x => x.Visible = true);

            PassData passData = (PassData)e.Argument;
            ImportExcel(passData.savedPath);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.InvokeEx(x => x.Value = 100);
            lblStatus.InvokeEx(x => x.Visible = false);
            progressBar.InvokeEx(x => x.Visible = false);
            MessageBox.Show("Import Complete!");
        }

        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnImport_Click(sender, e);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Please wait until process has finished.");
                return;
            }
            ArrayList path = GetSavePath();
            if (path.Count != 0)
            {
                backgroundWorker.RunWorkerAsync(new PassData(path));
            }
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


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Please wait until process has finished.");
                return;
            }
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

        private void ImportExcel(ArrayList path)
        {
            progressBar.InvokeEx(x => x.Value = 10);
            ImportData.LoadExcel(path);
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

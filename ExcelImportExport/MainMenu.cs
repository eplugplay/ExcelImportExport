using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelImportExport
{
    public partial class MainMenu : Form
    {
        public static Report _Report;
        public static NewImport _NewImport;
        public static Import _Import;
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
            if (_Import == null || _Import.IsDisposed)
            {
                _Import = new Import();
                _Import.Show();
            }
            else
            {
                if (_Import.WindowState == FormWindowState.Minimized)
                {
                    _Import.WindowState = FormWindowState.Normal;
                }
                else
                {
                    _Import.BringToFront();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}

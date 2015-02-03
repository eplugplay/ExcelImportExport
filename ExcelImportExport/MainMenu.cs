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
        public static Import _Import;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        
        private void newImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Import == null || _Import.IsDisposed)
            {
                _Import = new Import(true);
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

        private void editImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Import == null || _Import.IsDisposed)
            {
                _Import = new Import(false);
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
    }
}

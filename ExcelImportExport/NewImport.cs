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
    public partial class NewImport : Form
    {
        public NewImport()
        {
            InitializeComponent();
        }

        private void ClearAll()
        {
            txtStudentID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtGPA.Text = "";
            txtEmail.Text = "";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainMenu._Report == null || MainMenu._Report.IsDisposed)
            {
                MainMenu._Report = new Report();
                MainMenu._Report.Show();
            }
            else
            {
                if (MainMenu._Report.WindowState == FormWindowState.Minimized)
                {
                    MainMenu._Report.WindowState = FormWindowState.Normal;
                }
                else
                {
                    MainMenu._Report.BringToFront();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text == "") { MessageBox.Show("Please enter Student ID"); txtStudentID.Focus(); return; }
            if (Uti.ValidateStudent(Convert.ToInt32(txtStudentID.Text))) { MessageBox.Show("Student already exist"); return; }
            try { int.Parse(txtStudentID.Text); }
            catch { MessageBox.Show("Please enter number only."); return; }
            if (txtFirstName.Text == "") { MessageBox.Show("Please enter First Name."); txtFirstName.Focus(); return; }
            if (txtLastName.Text == "")
            { MessageBox.Show("Please enter Last Name."); txtLastName.Focus(); return; }
            if (txtGPA.Text == "") { MessageBox.Show("Please enter GPA."); txtGPA.Focus(); return; }
            try { double.Parse(txtGPA.Text);}
            catch { MessageBox.Show("Please enter number only."); txtGPA.Focus(); return; }
            
            if (MessageBox.Show("Save New Data?", "Save New Information?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int newId = Class.ReportData.SaveData(Convert.ToInt32(txtStudentID.Text), txtFirstName.Text, txtLastName.Text, txtEmail.Text, Convert.ToDouble(txtGPA.Text));
                if (MainMenu._Import != null || !MainMenu._Import.IsDisposed)
                {
                    MainMenu._Report.LoadStudentsDDL();
                    MainMenu._Report.ddlStudents.SelectedValue = newId;
                }
                MessageBox.Show("Saved.");
                ClearAll();
            }
        }
    }
}

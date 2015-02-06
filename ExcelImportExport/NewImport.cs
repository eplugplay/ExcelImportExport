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
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Please wait until process has finished.");
                return;
            }
            if (txtStudentID.Text == "") { MessageBox.Show("Please enter Student ID"); txtStudentID.Focus(); return; }
            //if (Uti.ValidateStudent(Convert.ToInt32(txtStudentID.Text))) { MessageBox.Show("Student already exist"); return; }
            try { int.Parse(txtStudentID.Text); }
            catch { MessageBox.Show("Please enter number only."); txtStudentID.Focus(); return; }
            if (txtFirstName.Text == "") { MessageBox.Show("Please enter First Name."); txtFirstName.Focus(); return; }
            if (txtLastName.Text == "")
            { MessageBox.Show("Please enter Last Name."); txtLastName.Focus(); return; }
            if (txtEmail.Text == "") { MessageBox.Show("Please enter Email"); txtEmail.Focus(); return; }
            if (txtGPA.Text == "") { MessageBox.Show("Please enter GPA."); txtGPA.Focus(); return; }
            try { double.Parse(txtGPA.Text);}
            catch { MessageBox.Show("Please enter number only."); txtGPA.Focus(); return; }
            
            if (MessageBox.Show("Save New Data?", "Save New Information?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PassData.studentId = Convert.ToInt32(txtStudentID.Text);
                PassData.firstName = txtFirstName.Text;
                PassData.lastName = txtLastName.Text;
                PassData.email = txtEmail.Text;
                PassData.gpa = Convert.ToDouble(txtGPA.Text);
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //enable progress bar
            lblStatus.InvokeEx(x => x.Visible = true);
            progressBar.InvokeEx(x => x.Visible = true);
            //PassData passData = (PassData)e.Argument;
            progressBar.InvokeEx(x => x.Value = 30);
            int newId = ReportData.SaveData(PassData.studentId, PassData.firstName, PassData.lastName, PassData.email, PassData.gpa);
            progressBar.InvokeEx(x => x.Value = 100);
            if (MainMenu._Report != null || !MainMenu._Report.IsDisposed)
            {
                MainMenu._Report.InvokeEx(x => x.LoadStudentsDDL());
                MainMenu._Report.InvokeEx(x => x.ddlStudents.SelectedValue = newId);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.InvokeEx(x => x.Value = 100);
            lblStatus.InvokeEx(x => x.Visible = false);
            progressBar.InvokeEx(x => x.Visible = false);
            MessageBox.Show("Saved.");
            ClearAll();
        }
    }
}

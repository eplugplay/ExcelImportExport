﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelImportExport.Class;
using System.Collections;
using ExcelImportExport.Class;

namespace ExcelImportExport
{
    public partial class Report : Form
    {
        private static ReportForm _ReportForm;
        public Report()
        {
            InitializeComponent();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //enable progress bar
            lblStatus.InvokeEx(x => x.Visible = true);
            progressBar.InvokeEx(x => x.Visible = true);
            //PassData passData = (PassData)e.Argument;
            progressBar.InvokeEx(x => x.Value = 80);
            ReportData.UpdateData(PassData.studentvalue, PassData.studentId, PassData.firstName, PassData.lastName, PassData.email, PassData.gpa);
            LoadStudentsDDL();
            ddlStudents.InvokeEx(x => x.SelectedValue = PassData.studentvalue);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.InvokeEx(x => x.Value = 100);
            lblStatus.InvokeEx(x => x.Visible = false);
            progressBar.InvokeEx(x => x.Visible = false);
            MessageBox.Show("Updated.");
        }

        private void Import_Load(object sender, EventArgs e)
        {
            //GbxStudent.Enabled = false;
            GbxLoadStudents.Enabled = true;
            LoadStudentsDDL();
            PassData.studentvalue = Convert.ToInt32(ddlStudents.SelectedValue);
            LoadStudentData(PassData.studentvalue);
            btnSave.Visible = true;
        }

        public void LoadStudentsDDL()
        {
            DataTable finalDt = new DataTable();
            DataColumn dc = finalDt.Columns.Add("id", typeof(int));
            dc.Unique = true;
            finalDt.Columns.Add("FullName", typeof(string));
            DataTable dt = Uti.GetAllStudents();
            for (int i = 0; i < dt.Rows.Count; i++ )
            {
                DataRow dr = finalDt.NewRow();
                dr["FullName"] = dt.Rows[i]["firstname"].ToString() + " " + dt.Rows[i]["lastname"].ToString() + " - " + dt.Rows[i]["studentid"].ToString();
                dr["id"] = dt.Rows[i]["id"];
                finalDt.Rows.Add(dr);
            }
            ddlStudents.InvokeEx(x => x.DisplayMember = "FullName");
            ddlStudents.InvokeEx(x => x.ValueMember = "id");
            ddlStudents.InvokeEx(x => x.DataSource = finalDt);
        }

        private void LoadStudentData(int id)
        {
            DataTable dt = Uti.GetIndividualStudent(id);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtFirstName.Text = dt.Rows[i]["firstname"].ToString();
                txtLastName.Text = dt.Rows[i]["lastname"].ToString();
                txtStudentID.Text = dt.Rows[i]["studentid"].ToString();
                txtEmail.Text = dt.Rows[i]["email"].ToString();
                txtGPA.Text = Convert.ToDouble(dt.Rows[i]["gpa"]).ToString();
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
            try { int.Parse(txtStudentID.Text); }
            catch { MessageBox.Show("Please enter number only."); txtStudentID.Focus(); return; }
            if (txtFirstName.Text == "") { MessageBox.Show("Please enter First Name."); txtFirstName.Focus(); return; }
            if (txtLastName.Text == "")
            { MessageBox.Show("Please enter Last Name."); txtLastName.Focus(); return; }
            if (txtEmail.Text == "") { MessageBox.Show("Please enter Email"); txtEmail.Focus(); return; }
            if (txtGPA.Text == "") { MessageBox.Show("Please enter GPA."); txtGPA.Focus(); return; }
            try { double.Parse(txtGPA.Text);}
            catch { MessageBox.Show("Please enter number only."); txtGPA.Focus(); return; }
            //if (Uti.ValidateStudent(Convert.ToInt32(txtStudentID.Text))) { MessageBox.Show("Student already exist"); return; }
            if (MessageBox.Show("Update?", "Update Information?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PassData.studentvalue = Convert.ToInt32(ddlStudents.SelectedValue);
                PassData.studentId = Convert.ToInt32(txtStudentID.Text);
                PassData.firstName = txtFirstName.Text;
                PassData.lastName = txtLastName.Text;
                PassData.email = txtEmail.Text;
                PassData.gpa = Convert.ToDouble(txtGPA.Text);
                backgroundWorker.RunWorkerAsync();
            }
        }

        private string GetSavePath()
        {
            string ToBeReturned;
            saveFileDialog.DefaultExt = "*.xls";
            saveFileDialog.Filter = "Excel File (*.xls)|*.xls|All files (*.*)|*.*";
            saveFileDialog.FileName = "Export - " + DateTime.Now.ToString("MMM-yy") + ".xls";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ToBeReturned = saveFileDialog.FileName;
            }
            else
            {
                ToBeReturned = string.Empty;
            }
            return ToBeReturned;
        }

        private void Export()
        {
            string path = "d";
            //string path = GetSavePath();
            if (path != "")
            {
                if (chkAllRecords.Checked)
                {
                    LoadReport(ConvertToExcel.GetReportData(Uti.GetAllStudents(), path));
                }
                else
                {
                    LoadReport(ConvertToExcel.GetReportData(Uti.GetIndividualStudent(PassData.studentvalue), path));
                }
            }
        }

        
        private void LoadReport(DataTable dt)
        {
            if (_ReportForm == null || _ReportForm.IsDisposed)
            {
                _ReportForm = new ReportForm(dt);
                _ReportForm.InvokeEx(x => x.Show());
            }
            else
            {
                if (_ReportForm.WindowState == FormWindowState.Minimized)
                {
                    _ReportForm.WindowState = FormWindowState.Normal;
                }
                else
                {
                    _ReportForm.InvokeEx(x => x.BringToFront());
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if(backgroundWorker.IsBusy)
            {
                MessageBox.Show("Please wait until process is finished.");
            }
            Export();
        }

        #region Events

        private void ddlStudents_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //id = Convert.ToInt32(ddlStudents.SelectedValue);
            //LoadStudentData(id);
        }

        private void ddlStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                PassData.studentvalue = Convert.ToInt32(ddlStudents.SelectedValue);
                LoadStudentData(PassData.studentvalue);
            }
        }


        private bool controlKey = false;
        private void ddlStudents_TextChanged(object sender, EventArgs e)
        {
            base.OnTextChanged(e);
            string cbValue = ddlStudents.Text;

            if (cbValue != "" && controlKey == false)
            {
                // search for a matching entry
                string matchText = ddlStudents.Text;
                // if match = -1, not match found
                int match = ddlStudents.FindString(matchText);

                // If a matching entry is found, insert it now.
                if (match != -1)
                {
                    ddlStudents.SelectedIndex = match;
                    // Select added text so it can be replied 
                    // if the user keeps typing.
                    ddlStudents.SelectionStart = matchText.Length;
                    ddlStudents.SelectionLength = ddlStudents.Text.Length - ddlStudents.SelectionStart;
                }
            }
        }

        private void ddlStudents_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar == (int)Keys.Escape)
            {
                //Clear the text
                ddlStudents.SelectedIndex = -1;
                ddlStudents.Text = "";
                controlKey = true;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                controlKey = true;
            }
            else
            {
                controlKey = false;
            }
            if (e.KeyChar == (char)13)
            {
                // Enter key pressed
                
            }
        }

        private void ddlStudents_Leave(object sender, EventArgs e)
        {
            base.OnLeave(e);

            int match = ddlStudents.FindString(ddlStudents.Text);

            if (match != -1)
            {
                ddlStudents.SelectedIndex = match;
            }
        }

        private void ddlStudents_Validating(object sender, CancelEventArgs e)
        {
            base.OnValidating(e);
            //ddlStudents.SelectedIndex = ddlStudents.FindStringExact(base.Text);
        }

        private void chkAllRecords_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkAllRecords.Checked) { GbxLoadStudents.Enabled = false; GbxStudent.Enabled = false; } else { GbxLoadStudents.Enabled = true; GbxStudent.Enabled = true; }
        }
        #endregion

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (MainMenu._NewImport == null || MainMenu._NewImport.IsDisposed)
            {
                MainMenu._NewImport = new NewImport();
                MainMenu._NewImport.Show();
            }
            else
            {
                if (MainMenu._NewImport.WindowState == FormWindowState.Minimized)
                {
                    MainMenu._NewImport.WindowState = FormWindowState.Normal;
                }
                else
                {
                    MainMenu._NewImport.BringToFront();
                }
            }
        }
    }
}

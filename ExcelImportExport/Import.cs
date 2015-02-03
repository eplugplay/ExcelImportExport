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
        private bool IsNew {get; set;}
        public Import(bool _isNew)
        {
            InitializeComponent();
            IsNew = _isNew;
        }


        private void Import_Load(object sender, EventArgs e)
        {
            if (IsNew)
            {
                //GbxStudent.Enabled = true;
                GbxLoadStudents.Enabled = false;
                btnEdit.Visible = false;
            }
            else
            {
                //GbxStudent.Enabled = false;
                GbxLoadStudents.Enabled = true;
                LoadStudentsDDL();
                LoadStudentData(Convert.ToInt32(ddlStudents.SelectedValue));
                btnEdit.Visible = true;
            }
        }

        private void LoadStudentsDDL()
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
            ddlStudents.DataSource = finalDt;
            ddlStudents.DisplayMember = "FullName";
            ddlStudents.ValueMember = "id";
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
                //Convert.ToDouble(dt.Rows[i]["gpa"], double);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsNew)
            {
                if (txtFirstName.Text == "") { MessageBox.Show("Please enter First Name."); txtFirstName.Focus(); return; }
                if (txtLastName.Text == "")
                { MessageBox.Show("Please enter Last Name."); txtLastName.Focus(); return; }
                if (txtGPA.Text == "") { MessageBox.Show("Please enter GPA."); return; }
                try { double.Parse(txtGPA.Text); int.Parse(txtStudentID.Text); }
                catch { MessageBox.Show("Please enter number only."); return; }
                if (Uti.ValidateStudent(Convert.ToInt32(txtStudentID.Text))) { MessageBox.Show("Student already exist"); return; }
                if (MessageBox.Show("Save New Data?", "Save New Information?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Class.ImportData.SaveData(Convert.ToInt32(txtStudentID.Text), txtFirstName.Text, txtLastName.Text, txtEmail.Text, Convert.ToDouble(txtGPA.Text));
                    //MessageBox.Show("Saved.");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "") { MessageBox.Show("Please enter First Name."); txtFirstName.Focus(); return; }
            if (txtLastName.Text == "")
            { MessageBox.Show("Please enter Last Name."); txtLastName.Focus(); return; }
            if (txtGPA.Text == "") { MessageBox.Show("Please enter GPA."); return; }
            try { double.Parse(txtGPA.Text); int.Parse(txtStudentID.Text); }
            catch { MessageBox.Show("Please enter number only."); return; }
            //if (Uti.ValidateStudent(Convert.ToInt32(txtStudentID.Text))) { MessageBox.Show("Student already exist"); return; }
            if (MessageBox.Show("Update?", "Update Information?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Class.ImportData.UpdateData(Convert.ToInt32(ddlStudents.SelectedValue), Convert.ToInt32(txtStudentID.Text), txtFirstName.Text, txtLastName.Text, txtEmail.Text, Convert.ToDouble(txtGPA.Text));
                LoadStudentsDDL();
                MessageBox.Show("Updated.");
            }
        }


        #region Students dropdown Events

        private void ddlStudents_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadStudentData(Convert.ToInt32(ddlStudents.SelectedValue));
        }

        private void ddlStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!Convert.ToInt32(ddlStudents.SelectedValue).Equals(-1))
            //{
            //    //int id = Convert.ToInt32(ddlStudents.SelectedValue);
            //}
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
            ddlStudents.SelectedIndex = ddlStudents.FindStringExact(base.Text);
        }
        #endregion
    }
}

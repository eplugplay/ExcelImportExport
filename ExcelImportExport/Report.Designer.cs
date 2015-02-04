namespace ExcelImportExport
{
    partial class Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.GbxStudent = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.txtGPA = new System.Windows.Forms.TextBox();
            this.lblGPA = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.ddlStudents = new System.Windows.Forms.ComboBox();
            this.lblStudentFullName = new System.Windows.Forms.Label();
            this.GbxLoadStudents = new System.Windows.Forms.GroupBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.chkAllRecords = new System.Windows.Forms.CheckBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.GbxStudent.SuspendLayout();
            this.GbxLoadStudents.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(72, 49);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(253, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(6, 52);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name:";
            // 
            // GbxStudent
            // 
            this.GbxStudent.Controls.Add(this.btnNew);
            this.GbxStudent.Controls.Add(this.btnSave);
            this.GbxStudent.Controls.Add(this.txtEmail);
            this.GbxStudent.Controls.Add(this.lblEmail);
            this.GbxStudent.Controls.Add(this.txtStudentID);
            this.GbxStudent.Controls.Add(this.lblStudentID);
            this.GbxStudent.Controls.Add(this.txtGPA);
            this.GbxStudent.Controls.Add(this.lblGPA);
            this.GbxStudent.Controls.Add(this.txtLastName);
            this.GbxStudent.Controls.Add(this.lblLastName);
            this.GbxStudent.Controls.Add(this.txtFirstName);
            this.GbxStudent.Controls.Add(this.lblFirstName);
            this.GbxStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GbxStudent.Location = new System.Drawing.Point(11, 69);
            this.GbxStudent.Name = "GbxStudent";
            this.GbxStudent.Size = new System.Drawing.Size(358, 186);
            this.GbxStudent.TabIndex = 2;
            this.GbxStudent.TabStop = false;
            this.GbxStudent.Text = "Student Information";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(300, 157);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(72, 101);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(253, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(6, 104);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email:";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID.Location = new System.Drawing.Point(72, 23);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(253, 20);
            this.txtStudentID.TabIndex = 0;
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentID.Location = new System.Drawing.Point(6, 26);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(61, 13);
            this.lblStudentID.TabIndex = 8;
            this.lblStudentID.Text = "Student ID:";
            // 
            // txtGPA
            // 
            this.txtGPA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGPA.Location = new System.Drawing.Point(72, 127);
            this.txtGPA.Name = "txtGPA";
            this.txtGPA.Size = new System.Drawing.Size(253, 20);
            this.txtGPA.TabIndex = 4;
            // 
            // lblGPA
            // 
            this.lblGPA.AutoSize = true;
            this.lblGPA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPA.Location = new System.Drawing.Point(6, 130);
            this.lblGPA.Name = "lblGPA";
            this.lblGPA.Size = new System.Drawing.Size(32, 13);
            this.lblGPA.TabIndex = 5;
            this.lblGPA.Text = "GPA:";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(72, 75);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(253, 20);
            this.txtLastName.TabIndex = 2;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(6, 78);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Last Name:";
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(255, 261);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(114, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Generate Report";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // ddlStudents
            // 
            this.ddlStudents.FormattingEnabled = true;
            this.ddlStudents.Location = new System.Drawing.Point(50, 19);
            this.ddlStudents.Name = "ddlStudents";
            this.ddlStudents.Size = new System.Drawing.Size(302, 21);
            this.ddlStudents.TabIndex = 11;
            this.ddlStudents.TabStop = false;
            this.ddlStudents.SelectionChangeCommitted += new System.EventHandler(this.ddlStudents_SelectionChangeCommitted);
            this.ddlStudents.TextChanged += new System.EventHandler(this.ddlStudents_TextChanged);
            this.ddlStudents.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ddlStudents_KeyPress);
            this.ddlStudents.Leave += new System.EventHandler(this.ddlStudents_Leave);
            this.ddlStudents.Validating += new System.ComponentModel.CancelEventHandler(this.ddlStudents_Validating);
            // 
            // lblStudentFullName
            // 
            this.lblStudentFullName.AutoSize = true;
            this.lblStudentFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentFullName.Location = new System.Drawing.Point(6, 23);
            this.lblStudentFullName.Name = "lblStudentFullName";
            this.lblStudentFullName.Size = new System.Drawing.Size(38, 13);
            this.lblStudentFullName.TabIndex = 12;
            this.lblStudentFullName.Text = "Name:";
            // 
            // GbxLoadStudents
            // 
            this.GbxLoadStudents.Controls.Add(this.ddlStudents);
            this.GbxLoadStudents.Controls.Add(this.lblStudentFullName);
            this.GbxLoadStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GbxLoadStudents.Location = new System.Drawing.Point(11, 12);
            this.GbxLoadStudents.Name = "GbxLoadStudents";
            this.GbxLoadStudents.Size = new System.Drawing.Size(358, 51);
            this.GbxLoadStudents.TabIndex = 13;
            this.GbxLoadStudents.TabStop = false;
            this.GbxLoadStudents.Text = "Select Student";
            // 
            // chkAllRecords
            // 
            this.chkAllRecords.AutoSize = true;
            this.chkAllRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllRecords.Location = new System.Drawing.Point(158, 265);
            this.chkAllRecords.Name = "chkAllRecords";
            this.chkAllRecords.Size = new System.Drawing.Size(91, 17);
            this.chkAllRecords.TabIndex = 13;
            this.chkAllRecords.Text = "All Records";
            this.chkAllRecords.UseVisualStyleBackColor = true;
            this.chkAllRecords.CheckStateChanged += new System.EventHandler(this.chkAllRecords_CheckStateChanged);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(331, 23);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(20, 20);
            this.btnNew.TabIndex = 12;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "+";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 289);
            this.Controls.Add(this.chkAllRecords);
            this.Controls.Add(this.GbxLoadStudents);
            this.Controls.Add(this.GbxStudent);
            this.Controls.Add(this.btnExport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Import";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Excel";
            this.Load += new System.EventHandler(this.Import_Load);
            this.GbxStudent.ResumeLayout(false);
            this.GbxStudent.PerformLayout();
            this.GbxLoadStudents.ResumeLayout(false);
            this.GbxLoadStudents.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.GroupBox GbxStudent;
        private System.Windows.Forms.TextBox txtGPA;
        private System.Windows.Forms.Label lblGPA;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblStudentFullName;
        private System.Windows.Forms.GroupBox GbxLoadStudents;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox chkAllRecords;
        private System.Windows.Forms.Button btnNew;
        public System.Windows.Forms.ComboBox ddlStudents;
    }
}
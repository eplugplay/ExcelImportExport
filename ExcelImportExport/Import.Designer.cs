namespace ExcelImportExport
{
    partial class Import
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.txtGPA = new System.Windows.Forms.TextBox();
            this.lblGPA = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.ddlStudents = new System.Windows.Forms.ComboBox();
            this.lblStudentFullName = new System.Windows.Forms.Label();
            this.GbxLoadStudents = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.GbxStudent.SuspendLayout();
            this.GbxLoadStudents.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(72, 23);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(222, 20);
            this.txtFirstName.TabIndex = 0;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(6, 26);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name:";
            // 
            // GbxStudent
            // 
            this.GbxStudent.Controls.Add(this.btnEdit);
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
            this.GbxStudent.Size = new System.Drawing.Size(358, 156);
            this.GbxStudent.TabIndex = 2;
            this.GbxStudent.TabStop = false;
            this.GbxStudent.Text = "Student Information";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(72, 101);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(222, 20);
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
            this.txtStudentID.Location = new System.Drawing.Point(72, 75);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(222, 20);
            this.txtStudentID.TabIndex = 2;
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentID.Location = new System.Drawing.Point(6, 78);
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
            this.txtGPA.Size = new System.Drawing.Size(222, 20);
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
            this.txtLastName.Location = new System.Drawing.Point(72, 49);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(222, 20);
            this.txtLastName.TabIndex = 1;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(6, 52);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Last Name:";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(294, 231);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Export";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ddlStudents
            // 
            this.ddlStudents.FormattingEnabled = true;
            this.ddlStudents.Location = new System.Drawing.Point(50, 22);
            this.ddlStudents.Name = "ddlStudents";
            this.ddlStudents.Size = new System.Drawing.Size(302, 21);
            this.ddlStudents.TabIndex = 11;
            this.ddlStudents.TabStop = false;
            this.ddlStudents.SelectedIndexChanged += new System.EventHandler(this.ddlStudents_SelectedIndexChanged);
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
            this.lblStudentFullName.Location = new System.Drawing.Point(6, 26);
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
            this.GbxLoadStudents.Location = new System.Drawing.Point(11, 13);
            this.GbxLoadStudents.Name = "GbxLoadStudents";
            this.GbxLoadStudents.Size = new System.Drawing.Size(358, 50);
            this.GbxLoadStudents.TabIndex = 13;
            this.GbxLoadStudents.TabStop = false;
            this.GbxLoadStudents.Text = "Select Student";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(300, 127);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(51, 23);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.TabStop = false;
            this.btnEdit.Text = "Save";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 257);
            this.Controls.Add(this.GbxLoadStudents);
            this.Controls.Add(this.GbxStudent);
            this.Controls.Add(this.btnSave);
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

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.GroupBox GbxStudent;
        private System.Windows.Forms.TextBox txtGPA;
        private System.Windows.Forms.Label lblGPA;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.ComboBox ddlStudents;
        private System.Windows.Forms.Label lblStudentFullName;
        private System.Windows.Forms.GroupBox GbxLoadStudents;
        private System.Windows.Forms.Button btnEdit;
    }
}
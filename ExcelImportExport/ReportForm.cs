using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ExcelImportExport
{
    public partial class ReportForm : Form
    {
        private DataTable Data { get; set; }
        public ReportForm(DataTable dt)
        {
            InitializeComponent();
            Data = dt;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            reportViewer1.Dock = DockStyle.Fill;
            Reports.ReportDataSet ds = new Reports.ReportDataSet();
            for (int i = 0; i < Data.Rows.Count; i++)
            {
                DataRow dr = ds.Tables["dtFinal"].NewRow();
                dr["StudentID"] = Data.Rows[i]["Student ID"].ToString();
                dr["FirstName"] = Data.Rows[i]["First Name"].ToString();
                dr["LastName"] = Data.Rows[i]["Last Name"].ToString();
                dr["GPA"] = Data.Rows[i]["GPA"].ToString();
                dr["Email"] = Data.Rows[i]["Email"].ToString();
                dr["id"] = i;
                ds.Tables["dtFinal"].Rows.Add(dr);
            }
            //string deviceInf = "<DeviceInfo><PageHeight>20.5in</PageHeight><PageWidth>11in</PageWidth></DeviceInfo>";
            //reportViewer1.LocalReport.Render("PDF", deviceInf);
            this.dtFinalBindingSource.DataSource = ds;
            this.reportViewer1.RefreshReport();
        }
    }
}

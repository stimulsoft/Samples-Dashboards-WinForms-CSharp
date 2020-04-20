﻿using Stimulsoft.Report;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace Asynchronous_Export
{
    public partial class FormMain : Form
    {
        public StiReport Report { get; set; }
        //Modified the Main program to add more templates file to the comboBox 
        //and moved the GetTemplate function to each button click event.
        public FormMain()
        {
            InitializeComponent();
            ///Create a dictionary variable that has a key as the name of the template and the value is the path of that template.
            var dict = new Dictionary<string, string>
            {
                {"Select a template",""},
                {"Christmas","Dashboards\\Christmas.mrt"},
                {"Exchange Tenders","Dashboards\\Exchange Tenders.mrt"},
                {"Fast Food Lunch","Dashboards\\Fast Food Lunch.mrt"}
            };
            cmbTemplates.DataSource = new BindingSource(dict, null);
            cmbTemplates.DisplayMember = "Key";
            cmbTemplates.ValueMember = "Value";

            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
           
            cmbTemplates.Focus();
            cmbTemplates.SelectedIndexChanged += new System.EventHandler(cmbTemplates_SelectedIndexChanged);
            buttonExcel.Visible = false;
            buttonImage.Visible = false;
            buttonPdf.Visible = false;
            buttonHTML.Visible = false;
            buttonWord.Visible = false;
            
            return;
                     
            //Report = GetTemplate();
        }

        private StiReport GetTemplate()
        {
            //var report = new StiReport();
            var report = StiReport.CreateNewDashboard();
            System.Diagnostics.Debug.Assert(cmbTemplates.SelectedValue != null);          
            string key = ((KeyValuePair<String, String>)cmbTemplates.SelectedItem).Key;
            string value = ((KeyValuePair<String, String>)cmbTemplates.SelectedItem).Value;
            report.Load(value);
            return report;
        }

        //private StiReport GetTemplate()
        //{
        //    var report = StiReport.CreateNewDashboard();
        //    report.Load("Dashboards\\Christmas.mrt");

        //    return report;
        //}


        private void cmbTemplates_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            //Cursor = Cursors.Default;
            buttonExcel.Visible = true;
            buttonImage.Visible = true;
            buttonPdf.Visible = true;
            buttonHTML.Visible = true;
            buttonWord.Visible = true;
        }

        private async void buttonPdf_Click(object sender, EventArgs e)
        {
            ///Ken Huynh, 4/16/2020
            ///the report must be generated by using the dashboard template that is selected from the comboBox
            ///
            if (cmbTemplates.Text.Length == 0)
            {
                MessageBox.Show("Please select a template from drop down list.", "Asynchronous Export");
                cmbTemplates.Focus();
                return;
            }
            else
            {
                var Report = GetTemplate();
                System.Diagnostics.Debug.Assert(Report != null);
                saveFileDialog.FileName = Report.ReportName + ".pdf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    labelStatus.Text = "Exporting...";

                    await Report.ExportDocumentAsync(StiExportFormat.Pdf, saveFileDialog.FileName);

                    labelStatus.Text = "";
                }
            }
            ///End Ken Huynh

            //saveFileDialog.FileName = Report.ReportName + ".pdf";
            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    labelStatus.Text = "Exporting...";

            //    await Report.ExportDocumentAsync(StiExportFormat.Pdf, saveFileDialog.FileName);

            //    labelStatus.Text = "";
            //}
        }

        private async void buttonExcel_Click(object sender, EventArgs e)
        {
            //Ken Huynh, 4/16/2020
            ///the report must be generated by using the dashboard template that is selected from the comboBox
            ///
            if (cmbTemplates.Text.Length == 0)
            {
                MessageBox.Show("Please select a template from drop down list.", "Asynchronous Export-FormMain");
                cmbTemplates.Focus();
                return;
            }
            else
            {
                var Report = GetTemplate();
                System.Diagnostics.Debug.Assert(Report != null);
                saveFileDialog.FileName = Report.ReportName + ".xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    labelStatus.Text = "Exporting...";

                    await Report.ExportDocumentAsync(StiExportFormat.Excel2007, saveFileDialog.FileName);

                    labelStatus.Text = "";
                }
            }
            ///End Ken Huynh
        }

        //private async void buttonExcel_Click(object sender, EventArgs e)
        //{
        //    saveFileDialog.FileName = Report.ReportName + ".xlsx";
        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        labelStatus.Text = "Exporting...";

        //        await Report.ExportDocumentAsync(StiExportFormat.Excel2007, saveFileDialog.FileName);

        //        labelStatus.Text = "";
        //    }
        //}

        private async void buttonImage_Click(object sender, EventArgs e)
        {
            ///Ken Huynh, 4/16/2020
            ///the report must be generated by using the dashboard template that is selected from the comboBox
            ///
            if (cmbTemplates.Text.Length == 0)
            {
                MessageBox.Show("Please select a template from drop down list.", "Asynchronous Export");
                cmbTemplates.Focus();
                return;
            }
            else
            {
                var Report = GetTemplate();
                System.Diagnostics.Debug.Assert(Report != null);
                saveFileDialog.FileName = Report.ReportName + ".png";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    labelStatus.Text = "Exporting...";

                    await Report.ExportDocumentAsync(StiExportFormat.ImagePng, saveFileDialog.FileName);

                    labelStatus.Text = "";
                }
            }
            ///End Ken Huynh
        }

        private async void buttonHTML_Click(object sender, EventArgs e)
        {
            ///Ken Huynh, 4/16/2020
            ///the report must be generated by using the dashboard template that is selected from the comboBox
            ///
            if (cmbTemplates.Text.Length == 0)
            {
                MessageBox.Show("Please select a template from drop down list.", "Asynchronous Export");
                cmbTemplates.Focus();
                return;
            }
            else
            {
                var Report = GetTemplate();
                System.Diagnostics.Debug.Assert(Report != null);
                saveFileDialog.FileName = Report.ReportName + ".htm";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    labelStatus.Text = "Exporting...";

                    await Report.ExportDocumentAsync(StiExportFormat.Html, saveFileDialog.FileName);

                    labelStatus.Text = "";
                }
            }
            ///End Ken Huynh
        }

        private async void buttonWord_Click(object sender, EventArgs e)
        {
            ///Ken Huynh, 4/16/2020
            ///the report must be generated by using the dashboard template that is selected from the comboBox
            ///
            if (cmbTemplates.Text.Length == 0)
            {
                MessageBox.Show("Please select a template from drop down list.", "Asynchronous Export");
                cmbTemplates.Focus();
                return;
            }
            else
            {
                var Report = GetTemplate();
                System.Diagnostics.Debug.Assert(Report != null);
                saveFileDialog.FileName = Report.ReportName + ".doc";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    labelStatus.Text = "Exporting...";

                    await Report.ExportDocumentAsync(StiExportFormat.Word2007, saveFileDialog.FileName);

                    labelStatus.Text = "";
                }
            }
            ///End Ken Huynh
        }


    }
}

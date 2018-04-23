﻿using System;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Designer;
using System.Linq;

namespace ConditionallyHideSeriesLabels {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Create a new DataSet
            System.Data.DataSet xmlDataSet = new System.Data.DataSet(@"XML DataSet");
            // Load the XML document to the DataSet
            xmlDataSet.ReadXml(@"Data\GDPofG7.xml");
            // This line of code is generated by Data Source Configuration Wizard
            chartControl1.DataSource = xmlDataSet.Tables[@"GDP"];

            chartControl1.SeriesTemplate.ArgumentDataMember = @"Year";
            chartControl1.SeriesTemplate.ValueDataMembers.AddRange(@"Product");
        }

        private void chartControl1_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e) {
            // If the value is less than 1, hide the point's label.

            var test = e.Series.Points.Max(p => p.ArgumentX.NumericalArgument);

            if(!e.Series.Points.Max(p => p.ArgumentX.NumericalArgument).Equals(e.SeriesPoint.NumericalArgument)) {
                e.LabelText = "";
            }
        }
    }
}
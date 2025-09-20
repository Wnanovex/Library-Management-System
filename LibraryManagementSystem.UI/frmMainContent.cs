using LibraryManagementSystem.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LibraryManagementSystem.UI
{
    public partial class frmMainContent : Form
    {
        public frmMainContent()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e) {

        }

        private void frmMainContent_Load(object sender, EventArgs e) {
            var counts = clsStatistics.GetDashboardCounts();

            lblTotalBooks.Text = counts.TotalBooks.ToString();
            lblTotalMembers.Text = counts.TotalMembers.ToString();
            lblTotalIssued.Text = counts.TotalIssuedBooks.ToString();
            lblTotalBookCopies.Text = counts.TotalBookCopies.ToString();


            // Clear existing chart data
            chartDashboard.Series.Clear();
            chartDashboard.Titles.Clear();
            chartDashboard.ChartAreas.Clear();

            // Add chart area
            chartDashboard.ChartAreas.Add(new ChartArea("MainArea"));

            // Optional: Add title
            chartDashboard.Titles.Add("Library Overview");

            // Create a new series
            Series series = new Series("Statistics");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            // Add data points
            series.Points.AddXY("Books", counts.TotalBooks);
            series.Points.AddXY("Members", counts.TotalMembers);
            series.Points.AddXY("Issued", counts.TotalIssuedBooks);
            series.Points.AddXY("Book Copies", counts.TotalBookCopies);

            // Optional styling
            series["PointWidth"] = "0.5";
            series.Color = Color.CornflowerBlue;

            // Add the series to the chart
            chartDashboard.Series.Add(series);

            //var daily_counts = clsStatistics.GetDailyCounts();

            //chartDashboard.Series.Clear();
            //chartDashboard.ChartAreas.Clear();
            //chartDashboard.Titles.Clear();

            //chartDashboard.ChartAreas.Add(new ChartArea("DailyStats"));
            //chartDashboard.Titles.Add("Today's Activity");

            //Series series = new Series("Daily Stats")  {
            //    ChartType = SeriesChartType.Column,
            //    IsValueShownAsLabel = true
            //};

            //series.Points.AddXY("Books Added", daily_counts.TotalBooksToday);
            //series.Points.AddXY("New Members", daily_counts.TotalMembersToday);
            //series.Points.AddXY("Books Issued", daily_counts.TotalIssuedToday);

            //chartDashboard.Series.Add(series);
        }
    }
}

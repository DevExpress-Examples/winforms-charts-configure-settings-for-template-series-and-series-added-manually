using DevExpress.XtraCharts;
using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.Utils;

namespace series_base_example {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            ChartControl chart = new ChartControl();
            // Hide the legend.
            chart.Legend.Visibility = DefaultBoolean.False;
            
            // Define series template for multiple series.
            chart.DataSource = GetSeriesTemplateData();
            chart.SeriesDataMember = "Region";
            chart.SeriesTemplate.View = new LineSeriesView();
            ConfigureSeries(chart.SeriesTemplate);

            // Add a single series.
            Series series = new Series("Australia", ViewType.Area);
            series.DataSource = GetSeriesData();
            chart.Series.Add(series);
            ConfigureSeries(series);
            
            chart.Dock = DockStyle.Fill;
            this.Controls.Add(chart);
        }

        private void ConfigureSeries(SeriesBase series) {
            series.ArgumentDataMember = "Year";
            series.ValueDataMembers.AddRange(new string[] { "Sales" });
            series.ArgumentScaleType= ScaleType.Qualitative;
            series.ValueScaleType= ScaleType.Numerical;
            series.LabelsVisibility = DefaultBoolean.True;
            series.Label.TextPattern = "{A}: {V:F2}";
        }

        internal static DataTable GetSeriesTemplateData() {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[] { new DataColumn("Region", typeof(string)),
                                                  new DataColumn("Year", typeof(int)),
                                                  new DataColumn("Sales", typeof(decimal)) });
            table.Rows.Add("Asia", 2016, 3.9341D);
            table.Rows.Add("Asia", 2017, 4.2372D);
            table.Rows.Add("Asia", 2018, 4.7685D);
            table.Rows.Add("Asia", 2019, 5.2890D);

            table.Rows.Add("Europe", 2016, 2.7891D);
            table.Rows.Add("Europe", 2017, 3.0884D);
            table.Rows.Add("Europe", 2018, 3.3579D);
            table.Rows.Add("Europe", 2019, 3.7257D);

            table.Rows.Add("North America", 2016, 3.2566D);
            table.Rows.Add("North America", 2017, 3.4855D);
            table.Rows.Add("North America", 2018, 3.7477D);
            table.Rows.Add("North America", 2019, 4.1825D);

            return table;
        }

        internal static DataTable GetSeriesData() {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[] { new DataColumn("Region", typeof(string)),
                                                  new DataColumn("Year", typeof(int)),
                                                  new DataColumn("Sales", typeof(decimal)) });
            table.Rows.Add("Australia", 2016, 1.5632D);
            table.Rows.Add("Australia", 2017, 1.7871D);
            table.Rows.Add("Australia", 2018, 1.9576D);
            table.Rows.Add("Australia", 2019, 2.2727D);

            return table;
        }
    }
}

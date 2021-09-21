Imports DevExpress.XtraCharts
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports DevExpress.Utils

Namespace series_base_example

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim chart As ChartControl = New ChartControl()
            ' Hide the legend.
            chart.Legend.Visibility = DefaultBoolean.[False]
            ' Define series template for multiple series.
            chart.DataSource = GetSeriesTemplateData()
            chart.SeriesDataMember = "Region"
            chart.SeriesTemplate.View = New LineSeriesView()
            ConfigureSeries(chart.SeriesTemplate)
            ' Add a single series.
            Dim series As Series = New Series("Australia", ViewType.Area)
            series.DataSource = GetSeriesData()
            chart.Series.Add(series)
            ConfigureSeries(series)
            chart.Dock = DockStyle.Fill
            Me.Controls.Add(chart)
        End Sub

        Private Sub ConfigureSeries(ByVal series As SeriesBase)
            series.ArgumentDataMember = "Year"
            series.ValueDataMembers.AddRange(New String() {"Sales"})
            series.ArgumentScaleType = ScaleType.Qualitative
            series.ValueScaleType = ScaleType.Numerical
            series.LabelsVisibility = DefaultBoolean.True
            series.Label.TextPattern = "{A}: {V:F2}"
        End Sub

        Friend Shared Function GetSeriesTemplateData() As DataTable
            Dim table As DataTable = New DataTable()
            table.Columns.AddRange(New DataColumn() {New DataColumn("Region", GetType(String)), New DataColumn("Year", GetType(Integer)), New DataColumn("Sales", GetType(Decimal))})
            table.Rows.Add("Asia", 2016, 3.9341R)
            table.Rows.Add("Asia", 2017, 4.2372R)
            table.Rows.Add("Asia", 2018, 4.7685R)
            table.Rows.Add("Asia", 2019, 5.2890R)
            table.Rows.Add("Europe", 2016, 2.7891R)
            table.Rows.Add("Europe", 2017, 3.0884R)
            table.Rows.Add("Europe", 2018, 3.3579R)
            table.Rows.Add("Europe", 2019, 3.7257R)
            table.Rows.Add("North America", 2016, 3.2566R)
            table.Rows.Add("North America", 2017, 3.4855R)
            table.Rows.Add("North America", 2018, 3.7477R)
            table.Rows.Add("North America", 2019, 4.1825R)
            Return table
        End Function

        Friend Shared Function GetSeriesData() As DataTable
            Dim table As DataTable = New DataTable()
            table.Columns.AddRange(New DataColumn() {New DataColumn("Region", GetType(String)), New DataColumn("Year", GetType(Integer)), New DataColumn("Sales", GetType(Decimal))})
            table.Rows.Add("Australia", 2016, 1.5632R)
            table.Rows.Add("Australia", 2017, 1.7871R)
            table.Rows.Add("Australia", 2018, 1.9576R)
            table.Rows.Add("Australia", 2019, 2.2727R)
            Return table
        End Function
    End Class
End Namespace

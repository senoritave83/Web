Imports Classes
Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization
Imports System.Web.UI.DataVisualization.Charting

Partial Class Pesquisas_Evolucao_VolPre

    Inherits XMWebPage

    Protected intTotal As Integer = 0
    Protected blnTotal As Boolean = False
    Protected strDataInicial As String = ""
    Protected strDataFinal As String = ""

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request("pr") = "2" Then
            Me.MasterPageFile = "~/relatorios/imprimir.master"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim vIDEmpresa As Integer = CInt("0" & Request("em"))
            If vIDEmpresa <> User.IDEmpresa Then
                If Not VerificaPermissao("Relatórios", "Visualizar todas as empresas") Then
                    vIDEmpresa = User.IDEmpresa
                End If
            End If

            If Request("pr") = "2" Then

                With Filtro1
                    .Visible = False
                    .IDEmpresa = vIDEmpresa
                    .IDPesquisa = CInt(Request("idpesq"))
                    .IDGerente = CInt(Request("ger"))
                    .IDSupervisor = CInt(Request("sup"))
                    .IDVendedor = CInt(Request("vend"))
                    GerarGrafico()
                End With

            End If

        End If

    End Sub

    Private Sub GerarGrafico()

        Dim rep As New clsRelatorioPesquisa
        Dim ds As DataSet = rep.GetRelatorioEvolucao_VolumePrecos(Filtro1.IDEmpresa, 0, Filtro1.IDGerente, Filtro1.IDSupervisor, Filtro1.IDVendedor, Filtro1.IDPesquisa, Filtro1.TipoExibicao)
        Dim i As Integer = 0
        Dim dt As DataTable

        Dim title As New Title("Evolução - Volume X Preços")
        title.Font = New Font("Verdana", 16, FontStyle.Bold)
        Chart1.Titles.Add(title)

        With Chart1.ChartAreas(0).AxisX
            .IsLabelAutoFit = True
            .LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep90
            .LabelStyle.Enabled = True
            .Interval = 1
        End With

        Dim chSeries As Series

        chSeries = New Series("Volume")
        With chSeries
            .SmartLabelStyle.Enabled = False
            .ChartType = DataVisualization.Charting.SeriesChartType.Column
            .Color = Color.Green
            .ChartArea = "ChartArea1"
            .IsVisibleInLegend = False
            .LabelAngle = -90
            dt = ds.Tables(2)
            For i = 0 To dt.Rows.Count - 1
                .Points.AddY(dt.Rows(i).Item(1))
                .Points(.Points.Count - 1).AxisLabel = dt.Rows(i).Item(2)
            Next
        End With
        Chart1.Series.Add(chSeries)

        chSeries = New Series("PrecoPonta")
        With chSeries
            .ChartType = DataVisualization.Charting.SeriesChartType.Line
            .BorderWidth = 3
            .Color = Color.Blue
            .ChartArea = "ChartArea1"
            .IsVisibleInLegend = False
            dt = ds.Tables(0)
            For i = 0 To dt.Rows.Count - 1
                .Points.AddY(dt.Rows(i).Item(1))
            Next
        End With
        Chart1.Series.Add(chSeries)

        chSeries = New Series("PrecoVarejo")
        With chSeries
            .ChartType = DataVisualization.Charting.SeriesChartType.Line
            .BorderWidth = 3
            .Color = Color.Red
            .ChartArea = "ChartArea1"
            .IsVisibleInLegend = False
            dt = ds.Tables(1)
            For i = 0 To dt.Rows.Count - 1
                .Points.AddY(dt.Rows(i).Item(1))
            Next
        End With
        Chart1.Series.Add(chSeries)

        Dim legendItem As New LegendItem()
        legendItem.Name = "Volume"
        legendItem.Color = Color.Green
        legendItem.MarkerStyle = MarkerStyle.Square
        legendItem.MarkerSize = 10
        Chart1.Legends("Legend1").CustomItems.Add(legendItem)

        legendItem = New LegendItem()
        legendItem.Name = "Preço Ponta"
        legendItem.Color = Color.Blue
        legendItem.MarkerStyle = MarkerStyle.Square
        legendItem.MarkerSize = 10
        Chart1.Legends("Legend1").CustomItems.Add(legendItem)

        legendItem = New LegendItem()
        legendItem.Name = "Preço Varejo"
        legendItem.Color = Color.Red
        legendItem.MarkerStyle = MarkerStyle.Square
        legendItem.MarkerSize = 10
        Chart1.Legends("Legend1").CustomItems.Add(legendItem)

        Chart1.Legends("Legend1").Docking = Docking.Bottom
        Chart1.Legends("Legend1").Alignment = StringAlignment.Center

    End Sub

    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        If Filtro1.IDPesquisa > 0 Then
            GerarGrafico()
        End If

    End Sub

End Class

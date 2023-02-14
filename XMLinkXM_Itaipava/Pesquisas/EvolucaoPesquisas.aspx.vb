Imports Classes
Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization
Imports System.Web.UI.DataVisualization.Charting

Partial Class Pesquisas_EvolucaoPesquisas

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
        Dim ds As DataSet = rep.GetRelatorioEvolucao_VolumePesquisas(Filtro1.IDEmpresa, 0, Filtro1.IDGerente, Filtro1.IDSupervisor, Filtro1.IDVendedor, Filtro1.IDPesquisa, Filtro1.TipoExibicao)
        Dim i As Integer = 0
        Dim dt As DataTable

        With Chart1.ChartAreas(0).AxisX
            .IsLabelAutoFit = True
            .LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep90
            .LabelStyle.Enabled = True
            .Interval = 1
        End With

        Dim chSeries As Series

        chSeries = New Series("PrecoPonta")
        With chSeries
            .ChartType = DataVisualization.Charting.SeriesChartType.Line
            .BorderWidth = 3
            .Color = Color.Blue
            .ChartArea = "ChartArea1"
        End With
        Chart1.Series.Add(chSeries)

        Dim title As New Title("Evolução de Pesquisas")
        title.Font = New Font("Verdana", 16, FontStyle.Bold) 'Font will be Italic AND Bold!
        Chart1.Titles.Add(title)

        dt = ds.Tables(0)
        For i = 0 To dt.Rows.Count - 1
            Chart1.Series("PrecoPonta").Points.AddY(dt.Rows(i).Item(1))
            Chart1.Series("PrecoPonta").Points(Chart1.Series("PrecoPonta").Points.Count - 1).AxisLabel = dt.Rows(i).Item(2)
        Next

        '' Disable legend item for the first series
        Chart1.Series("PrecoPonta").IsVisibleInLegend = False

    End Sub

    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        If Filtro1.IDPesquisa > 0 Then
            GerarGrafico()
        End If

    End Sub

End Class

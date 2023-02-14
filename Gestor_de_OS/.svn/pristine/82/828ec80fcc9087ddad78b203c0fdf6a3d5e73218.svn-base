Imports Xceed.Chart.GraphicsCore
Imports Xceed.Chart.Standard
Imports Xceed.Chart.Core
Imports System.Drawing
Imports System.IO

Partial Class relatorios_relclientes_prn
    Inherits XMReportPage
    Protected cls As clsRelatorio
    Protected intTotal As Integer = 0
    Protected blnTotal As Boolean = False
    Protected strDataInicial As String = ""
    Protected strDataFinal As String = ""
    Protected strTipoGrafico As String = ""

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsRelatorio()

        intTotal = 0
        blnTotal = False

        Dim ds As DataSet = Nothing
        strDataInicial = Request("di")
        strDataFinal = Request("df")
        strTipoGrafico = Request("tp")

        If strTipoGrafico = "Tabular" Then

            ds = cls.GetReport_Clientes(strDataInicial, strDataFinal)

            grdRelatorio.DataSource = ds
            grdRelatorio.DataBind()
            grdRelatorio.Visible = True
            chartEOL.Visible = False

        Else

            If strTipoGrafico = "Linhas" Then
                ds = cls.GetReport_Clientes_Linha(strDataInicial, strDataFinal)
            Else
                ds = cls.GetReport_Clientes(strDataInicial, strDataFinal)
            End If

            grdRelatorio.Visible = False
            chartEOL.Visible = True

            If ds.Tables.Count > 0 Then
                chartEOL.Visible = ds.Tables(0).Rows.Count > 0
            End If

            MakeChart(ds, strTipoGrafico, chartEOL, "O.S. por Cliente")

        End If

        ltTitulo.Text = "Relat&oacute;rio de O.S. por Cliente de " & strDataInicial & " até " & strDataFinal

    End Sub

    Protected Sub grdRelatorio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRelatorio.DataBound
        If Not grdRelatorio.FooterRow Is Nothing And blnTotal Then
            On Error Resume Next
            grdRelatorio.FooterRow.Cells(0).Text = "Total"
            grdRelatorio.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
            grdRelatorio.FooterRow.Cells(1).Text = intTotal
            grdRelatorio.FooterRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
        End If
    End Sub

    Protected Sub grdRelatorio_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRelatorio.RowDataBound
        If Not e.Row.DataItem Is Nothing Then
            Dim intTemp As Integer = 0
            Try
                intTemp = e.Row.DataItem("qtd")
                blnTotal = True
            Finally
                intTotal += intTemp
            End Try
        End If
    End Sub

End Class

Imports Classes
Imports System.Data

Partial Class Relatorios_Performance_Det
    Inherits XMWebPage
    Protected Soma As New Somarizador


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Request("pr") = "2" Then

            showData(Request("em"), Request("ger"), Request("sup"), Request("vend"), Request("di"), Request("df"))
            Filtro1.Visible = False
            lblPeriodoData.Text = "Período Selecionado: de " & Request("di") & " a " & Request("df")

        ElseIf Request("pr") = "0" And ViewState("Redirect") Is Nothing Then 'Exibe o resultado do Relatório solicitado pela página performancerevendaregiao_det.aspx

            showData(Request("em"), 0, 0, 0, Request("di"), Request("df"))
            Filtro1.IDEmpresa = CInt(Request("em"))
            Filtro1.DataInicial = Request("di")
            Filtro1.DataFinal = Request("df")
            ViewState("Redirect") = "Passar aqui só uma vez em cada chamada!"
        End If

    End Sub


    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        showData(Filtro1.IDEmpresa, Filtro1.IDGerente, Filtro1.IDSupervisor, Filtro1.IDVendedor, Filtro1.DataInicial, Filtro1.DataFinal)

    End Sub

    Private Sub showData(ByVal vIdEmpresa As Integer, ByVal vIdGerente As Integer, ByVal vIdSupervidor As Integer, ByVal vIdVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String)

        Dim dtsRoteiro As DataSet
        Dim rep As New clsRelatorio
        dtsRoteiro = rep.GetRelatorioPerformance(vIdEmpresa, vIdGerente, vIdSupervidor, vIdVendedor, vDataInicial, vDataFinal)

        If dtsRoteiro.Tables(0).Rows.Count = 0 Then
            divEmpty.Visible = True
            grdRelatorio.Visible = False
        Else
            grdRelatorio.Visible = True
            grdRelatorio.DataSource = dtsRoteiro
            grdRelatorio.DataBind()
            divEmpty.Visible = False
        End If

        rep = Nothing

    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request("pr") = "2" Then
            Me.MasterPageFile = "imprimir.master"
        End If
    End Sub
End Class

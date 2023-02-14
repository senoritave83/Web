Imports Classes
Imports System.Data


Partial Class Relatorios_consolidado_det
    Inherits XMWebPage
    Protected Soma As New Somarizador

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            ViewState("Desc") = 0

        End If

        If Request("pr") = "2" Then

            showData(CInt(Request("em")), CInt(Request("ger")), CInt(Request("sup")), CInt(Request("vend")), Request("di"), Request("df"))
            Filtro1.Visible = False
            lblPeriodoData.Text = "Período Selecionado: de " & Request("di") & " a " & Request("df")

        End If

    End Sub

    Public Sub AllowSorting(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim SortExpression As String = sender.id
        ViewState("Desc") = IIf(ViewState("Desc") = 0, 1, 0)

        showData(Filtro1.IDEmpresa, Filtro1.IDGerente, Filtro1.IDSupervisor, Filtro1.IDVendedor, Filtro1.DataInicial, Filtro1.DataFinal, SortExpression, CBool(ViewState("Desc")))

    End Sub

    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        showData(Filtro1.IDEmpresa, Filtro1.IDGerente, Filtro1.IDSupervisor, Filtro1.IDVendedor, Filtro1.DataInicial, Filtro1.DataFinal)

    End Sub

    Private Sub showData(ByVal vIdEmpresa As Integer, ByVal vIdGerente As Integer, ByVal vIdSupervidor As Integer, ByVal vIdVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String, Optional ByVal vOrder As String = "Vendido", Optional ByVal vDescending As Boolean = 1)

        Dim dtsRoteiro As DataSet
        Dim rep As New clsRelatorio
        dtsRoteiro = rep.GetRelatorioConsolidado(vIdEmpresa, vIdGerente, vIdSupervidor, vIdVendedor, vDataInicial, vDataFinal, vOrder, vDescending)

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

Imports Classes
Imports System.Data

Partial Class Relatorios_pedidos_det
    Inherits XMWebPage


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Request("pr") = "2" Then

            showData(CInt(Request("em")), CInt(Request("ger")), CInt(Request("sup")), CInt(Request("vend")), CInt(Request("sta")), Request("di"))
            Filtro1.Visible = False
            lblPeriodoData.Text = "Data Selecionada: " & Request("di")
        End If

    End Sub


    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        showData(Filtro1.IDEmpresa, Filtro1.IDGerente, Filtro1.IDSupervisor, Filtro1.IDVendedor, Filtro1.IDStatus, Filtro1.DataInicial)

    End Sub

    Private Sub showData(ByVal vIdEmpresa As Integer, ByVal vIdGerente As Integer, ByVal vIdSupervisor As Integer, ByVal vIdVendedor As Integer, ByVal vIdStatus As Integer, ByVal vDataInicial As String)

        Dim rep As New clsRelatorio
        rptPedidos_det.DataSource = rep.GetRelatorioPedidos(vIdEmpresa, vIdGerente, vIdSupervisor, vIdVendedor, vIdStatus, vDataInicial)
        rptPedidos_det.DataBind()
        rep = Nothing

    End Sub

    Protected Function ListItensPedido(ByVal vIDPedido As String) As Object
        Dim ped As New clsPedido
        Return ped.ListItensPedido(vIDPedido)
    End Function

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request("pr") = "2" Then
            Me.MasterPageFile = "imprimir.master"
        End If
    End Sub

End Class

Imports Classes
Imports System.Data

Partial Class Relatorios_consignado_det
    Inherits XMWebPage
    Dim rep As clsRelatorio
    Dim ds As DataSet

    'Evento que verifica se o usuário solicitou a impressão dos dados e altera a Master Page.
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Not Request("print") Is Nothing Then
            Me.MasterPageFile = "~/Relatorios/Imprimir.master"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            rep = New clsRelatorio
            Dim IdClientes As String = IIf(Request("cli") Is Nothing, "0", Request("cli"))
            Dim IdVendedores As String = IIf(Request("ven") Is Nothing, "0", Request("ven"))
            rptFechamento.DataSource = rep.ListClientesRptConsignado(IdClientes, IdVendedores)
            rptFechamento.DataBind()

        End If
    End Sub

    Public Function GridConsignado(ByVal vIDCliente As String) As Object
        Return rep.GetRelatorioConsignados(CInt(vIDCliente))
    End Function
End Class

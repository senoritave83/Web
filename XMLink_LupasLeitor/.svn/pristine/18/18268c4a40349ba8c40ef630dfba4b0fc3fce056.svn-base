Imports Classes
Imports System.Data

Partial Class Relatorios_estoque_vendedor_det
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
            Dim IdVendedores As String = IIf(Request("ven") Is Nothing, "0", Request("ven"))
            rptEstoqueVend.DataSource = rep.ListVendedoresRpt(IdVendedores)
            rptEstoqueVend.DataBind()

        End If
    End Sub

    Public Function GridEstoqueVend(ByVal vIDVendedor As String) As Object
        Return rep.GetRelatorioEstoqueVendedor(CInt(vIDVendedor))
    End Function
End Class

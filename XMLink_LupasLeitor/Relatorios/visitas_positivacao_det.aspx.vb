Imports Classes
Imports System.Data

Partial Class Relatorios_visitas_positivacao_det
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
            rptVisitasPositivacao.DataSource = rep.ListVendedoresRpt(IdVendedores)
            rptVisitasPositivacao.DataBind()
            divResumo.Visible = rptVisitasPositivacao.Items.Count > 1
            BindGridResumo()
        End If
    End Sub

    Public Function GridVisitasPositivacao(ByVal vIDVendedor As String) As Object
        Return rep.GetRelatorioVisitasPositivacao(vIDVendedor, Request("di"))
    End Function

    Public Sub BindGridResumo()

        grdResumoGeral.DataSource = rep.GetRelatorioVisitasPositivacao(Request("ven"), Request("di"))
        grdResumoGeral.DataBind()
        lblTotalClientes.Text = grdResumoGeral.Rows.Count.ToString

    End Sub

End Class

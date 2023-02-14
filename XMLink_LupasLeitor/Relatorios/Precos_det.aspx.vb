Imports Classes
Imports System.Data
Imports System.Data.SqlClient

Partial Class Relatorios_Precos_det
    Inherits XMWebPage

    'Evento que verifica se o usuário solicitou a impressão dos dados e altera a Master Page.
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Not Request("print") Is Nothing Then
            Me.MasterPageFile = "~/Relatorios/Imprimir.master"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim rep As New clsRelatorio
            Dim dr As SqlDataReader = Nothing
            dr = rep.GetRelatorioPrecos()
            grdRelatorio.DataSource = dr
            grdRelatorio.DataBind()

            rep = Nothing

        End If
    End Sub
End Class

Imports Classes

Partial Class Relatorios_produtos
    Inherits XMWebPage
    Protected Soma As New Somarizador

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim vIDEmpresa As Integer = CInt("0" & Request("em"))
            If vIDEmpresa <> User.IDEmpresa Then
                If Not VerificaPermissao("Relatórios", "Visualizar todas as empresas") Then
                    vIDEmpresa = User.IDEmpresa
                End If
            End If

            Dim rep As New clsRelatorio
            grdRelatorio.DataSource = rep.GetRelatorioProdutos(vIDEmpresa, CInt("0" & Request("sup")), Request("di"), Request("df"))
            grdRelatorio.DataBind()
            rep = Nothing
        End If
    End Sub
End Class

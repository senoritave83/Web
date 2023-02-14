
Partial Class integracao_default
    Inherits XMProtectedPage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim emp As New clsEmpresa
            emp.Load(Identity.IDEmpresa)
            plhComIntegracao.Visible = emp.Integracao
            plhSemIntegracao.Visible = Not plhComIntegracao.Visible
        End If
    End Sub
End Class

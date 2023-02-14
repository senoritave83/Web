Imports Classes

Partial Class Relatorios_Performance_Revenda
    Inherits XMWebPage
    Protected Soma As New Somarizador
    Protected clsPesquisa As New clsPesquisa
    Protected clsEmpresa As clsEmpresa


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim vIDEmpresa As Integer = CInt("0" & Request("em"))
            If vIDEmpresa <> User.IDEmpresa Then
                If Not VerificaPermissao("Relatórios", "Visualizar todas as empresas") Then
                    vIDEmpresa = User.IDEmpresa
                End If
            End If
        End If

        Dim vIDPesquisa As Integer
        Integer.TryParse(Request("IDPesquisa"), vIDPesquisa)

        Dim vIDRevenda As Integer
        Integer.TryParse(Request("IDRevenda"), vIDRevenda)

        clsPesquisa.Load(vIDPesquisa)

        clsEmpresa = New clsEmpresa(vIDRevenda)

        Dim rep As New clsRelatorioPesquisa
        grdPerformanceRevenda.DataSource = rep.GetPerformanceRevenda(vIDPesquisa, vIDRevenda)
        grdPerformanceRevenda.DataBind()
        rep = Nothing
    End Sub
End Class

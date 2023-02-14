Imports Classes

Partial Class Relatorios_positivacao_det
    Inherits XMWebPage

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Request("pr") = "2" Then

            showData(CInt(Request("em")), CInt(Request("ger")), CInt(Request("sup")), CInt(Request("vend")), Request("dias"), Request("catprod"), Request("prod"))
            Filtro1.Visible = False
            lblPeriodoData.Text = "Dias Sem Pedido: " & Request("dias")

        End If

    End Sub


    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        showData(Filtro1.IDEmpresa, Filtro1.IDGerente, Filtro1.IDSupervisor, Filtro1.IDVendedor, Filtro1.Dias, Filtro1.IDCategoriaProd, Filtro1.IdProduto)

    End Sub

    Private Sub showData(ByVal vIdEmpresa As Integer, vIdGerente As Integer, ByVal vIdSupervisor As Integer, ByVal vIdVendedor As Integer, ByVal vDias As String, ByVal vIdCategoriaProd As Integer, ByVal vIdProduto As Integer)

        Dim rep As New clsRelatorio
        grdRelatorio.DataSource = rep.GetRelatorioPositivacao(vIdEmpresa, vIdGerente, vIdSupervisor, vIdVendedor, vDias, vIdCategoriaProd, vIdProduto)
        grdRelatorio.DataBind()
        rep = Nothing

    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request("pr") = "2" Then
            Me.MasterPageFile = "imprimir.master"
        End If
    End Sub

End Class

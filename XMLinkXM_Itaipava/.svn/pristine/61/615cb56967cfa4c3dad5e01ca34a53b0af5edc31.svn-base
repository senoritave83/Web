Imports Classes

Partial Class Relatorio_Preco_Share
    Inherits XMWebPage
    Protected Soma As New Somarizador

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request("pr") = "2" Then
            Me.MasterPageFile = "../Relatorios/Imprimir.master"
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            'Dim vIDEmpresa As Integer = CInt("0" & Request("em"))
            'If vIDEmpresa <> User.IDEmpresa Then
            '    If Not VerificaPermissao("Relatórios", "Visualizar todas as empresas") Then
            '        vIDEmpresa = User.IDEmpresa
            '    End If
            'End If

            If Request("pr") = "2" Then
                showData(CInt(Request("em")), CInt(Request("ger")), CInt(Request("sup")), CInt(Request("vend")), Request("di"), Request("df"), CInt(Request("catpesq")), CInt(Request("prodpesq")), Request("mar"))
                Filtro1.Visible = False

                If grdRelatorio.Rows.Count > 0 Then
                    tblLegenda.Visible = True
                    lblInfoFiltros.Text = "Título da Filtragem: <br />Revenda: " & User.Empresa & ", Tipo de Pesquisa: " & Request("catpesqtx") & ", Embalagem: " & Request("prodpesqtx") & " <br />Em: " & Session("Getdate")
                    Session.Remove("Getdate")
                Else
                    tblLegenda.Visible = False
                    lblInfoFiltros.Text = ""
                End If

            End If

        End If

    End Sub

    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        Session("Getdate") = Now().ToShortDateString & " " & Now().ToLongTimeString
        showData(Filtro1.IDEmpresa, Filtro1.IDGerente, Filtro1.IDSupervisor, Filtro1.IDVendedor, Filtro1.DataInicial, Filtro1.DataFinal, Filtro1.IDCategoriaPesq, Filtro1.IDProdutoPesq, Filtro1.Marcas)

    End Sub

    Private Sub showData(ByVal vIdEmpresa As Integer, vIdGerente As Integer, ByVal vIdSupervisor As Integer, ByVal vIdVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vIdCategoriaPesq As Integer, ByVal vIdProdutoPesq As Integer, ByVal vMarcas As String)

        Dim rep As New clsRelatorioPesquisa
        Dim ctp As New clsCategoriaPesquisa
        Dim ppe As New clsProdutoPesquisa

        ppe.Load(vIdProdutoPesq)
        ctp.Load(vIdCategoriaPesq)

        grdRelatorio.DataSource = rep.GetPrecoeShare(vIdEmpresa, vIdGerente, vIdSupervisor, vIdVendedor, vDataInicial, vDataFinal, vIdCategoriaPesq, vIdProdutoPesq, vMarcas)
        grdRelatorio.DataBind()
        rep = Nothing
        If grdRelatorio.Rows.Count > 0 Then
            tblLegenda.Visible = True
            lblInfoFiltros.Text = "Título da Filtragem: <br />Revenda: " & User.Empresa & ", Tipo de Pesquisa: " & ctp.Categoria & ", Embalagem: " & ppe.ProdutoPesquisa & " <br />Em: " & Session("Getdate")
        Else
            tblLegenda.Visible = False
            lblInfoFiltros.Text = ""
        End If

    End Sub


End Class

Imports Classes

Partial Class Pesquisas_RelatorioPesquisasDiarias_Visita
    Inherits XMWebPage
    Protected Soma As New Somarizador
    Protected cls As clsVisitaPesquisa

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim v As String = Request("v") & ""
            Dim objDados As Object = Nothing
            If v <> "" Then

                '****************************************************
                'FORMATO DOS DADOS - PARAMETRO Request("v")
                'VEN=1_||_DI=24/11/2011_||_DF=30/11/2011
                '****************************************************
                'Dim strDecrypt As String = XMCrypto.Decrypt(v)
                'objDados = strDecrypt.Split("_||_")

                objDados = StrReverse(v).Split("_||_")
                For Each obj As Object In objDados

                    If CStr(obj).StartsWith("ven=") Then
                        ViewState("IdVendedor") = CStr(obj).Substring(4)
                    ElseIf CStr(obj).StartsWith("ide=") Then
                        ViewState("IdEmpresa") = CStr(obj).Substring(4)
                    ElseIf CStr(obj).StartsWith("sup=") Then
                        ViewState("IdSupervisor") = CStr(obj).Substring(4)
                    ElseIf CStr(obj).StartsWith("vis=") Then
                        ViewState("IdVisita") = CStr(obj).Substring(4)
                    ElseIf CStr(obj).StartsWith("pes=") Then
                        ViewState("IdPesquisa") = CStr(obj).Substring(4)
                    End If

                Next

                CarregaVisita(ViewState("IdVisita"))

            End If

        End If

    End Sub

    Protected Sub CarregaVisita(ByVal vIDVisita As Integer)
        ViewState("IdVisita") = vIDVisita
        cls = New clsVisitaPesquisa()

        If cls.Load(ViewState("IdVisita"), ViewState("IdEmpresa")) Then

            ViewState("IdPesquisa") = cls.IDPesquisa
            ViewState("REINCIDENCIA") = cls.MarcadaReincidencia
            lnkVisita.Text = cls.IDVisita
            'lnkVisita.Text = "Visita.aspx?idvisita=" & cls.IDVisita
            lblCliente.Text = cls.IDCliente & " - " & cls.Cliente
            lblVendedor.Text = cls.Vendedor
            lblData.Text = cls.Data
            lblStatus.Text = cls.Status
            lblInicio.Text = cls.Inicio
            lblTermino.Text = cls.Termino

            Dim cli As New clsCliente()
            cli.Load(cls.IDCliente)
            lblEndereco.Text = cli.EnderecoCompleto
            cli = Nothing

            BindGrid(ViewState("IdVisita"))

        End If

        cls = Nothing

    End Sub

    Private Sub BindGrid(ByVal vIdVisita As Integer)

        grdRelatorioPesquisasVisita.DataSource = cls.ListarItens(vIdVisita)
        grdRelatorioPesquisasVisita.DataBind()

    End Sub


    Protected Sub btnVoltar_ServerClick(sender As Object, e As System.EventArgs) Handles btnVoltar.Click

        Response.Redirect("relatoriopesquisasdiarias_vendedor.aspx?v=" & StrReverse("ide=" & ViewState("IdEmpresa") & "_||_idp=" & ViewState("IdPesquisa") & "_||_sup=" & ViewState("IdSupervisor") & "_||_ven=" & ViewState("IdVendedor") & "_||_di=" & ViewState("DataInicial") & "_||_df=" & ViewState("DataFinal") & "_||_vis=" & ViewState("IdVisita") & "_||_pes=" & ViewState("IdPesquisa")))

    End Sub

End Class


Imports Classes

Namespace Pages.Roteiros

    Partial Public Class Roteiro
        Inherits XMWebPage
        Dim cls As clsRoteiro
        Protected Const VW_IDROTEIRO As String = "IDRoteiro"
        Protected Const VW_IDVENDEDOR As String = "IDVendedor"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsRoteiro()
            If Not Page.IsPostBack Then
                'COMBOS
                subAddConfirm(btnApagar, "Deseja realmente apagar esta roteiro?")
                ViewState(VW_IDROTEIRO) = CInt("0" & Request("IDRoteiro"))
                ViewState(VW_IDVENDEDOR) = CInt("0" & Request("IDVendedor"))
                cls.Load(ViewState(VW_IDROTEIRO), ViewState(VW_IDVENDEDOR))
                btnGravar.Enabled = VerificaPermissao(SecaoAtual, ACAO_EDITAR)
                btnNovo.Enabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = VerificaPermissao(SecaoAtual, ACAO_APAGAR)

                Dim pro As New clsVendedor()
                pro.Load(ViewState(VW_IDVENDEDOR))
                lblVendedor.Text = pro.Vendedor
                pro = Nothing

                Inflate()
            Else
                cls.Load(ViewState(VW_IDROTEIRO), ViewState(VW_IDVENDEDOR))
            End If
        End Sub

        Protected Sub Inflate()
            Roteiro1.Dia = cls.Dia
            Roteiro1.Mes = cls.Mes
            Roteiro1.DiaSemana = cls.DiaSemana
            chkAtivo.Checked = cls.Ativo
            BindLojasRoteiro()
        End Sub

        Protected Sub Deflate()
            cls.Dia = Roteiro1.Dia
            cls.Mes = Roteiro1.Mes
            cls.DiaSemana = Roteiro1.DiaSemana
            cls.Ativo = chkAtivo.Checked
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/controle/Roteiro.aspx?idroteiro=" & cls.IDRoteiro & "&idvendedor=" & cls.IDVendedor)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Roteiros.aspx")
        End Sub

        Protected Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovo.Click
            Response.Redirect("roteiro.aspx?idroteiro=0&idvendedor=" & cls.IDVendedor)
        End Sub

        Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
            Response.Redirect("vendedorroteiros.aspx?idvendedor=" & cls.IDVendedor)
        End Sub

        'Protected Sub btnProcurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.Click
        '   ProcurarLojas()
        'End Sub

        Private Sub txtProcurarLoja_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProcurarLoja.TextChanged
            Paginate1.CurrentPage = 0
            ProcurarClientes()
        End Sub

        Protected Sub ProcurarClientes()
            Dim loj As New clsCliente
            Dim ret As PaginateResult = loj.Listar(txtProcurarLoja.Text, 1, "", "", False, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
            Paginate1.DataSource = ret
            grdProcurar.DataSource = ret.Data
            grdProcurar.DataBind()
        End Sub

        Protected Sub BindLojasRoteiro()
            If cls.IDRoteiro > 0 Then
                grdLojasRoteiro.DataSource = cls.ListarLojas() 'DataClass.enReturnType.DataSet)
                grdLojasRoteiro.DataBind()
                lblNumeroLojas.Text = grdLojasRoteiro.Rows.Count
                plhLojas.Visible = True
            Else
                plhLojas.Visible = False
            End If
        End Sub

        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            ProcurarClientes()
        End Sub

        Protected Sub grdLojasRoteiro_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdLojasRoteiro.RowCommand
            If e.CommandName = "RetirarLoja" Then
                cls.RetirarCliente(grdLojasRoteiro.DataKeys(e.CommandArgument).Value)
                BindLojasRoteiro()
            End If
        End Sub

        Protected Sub grdProcurar_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProcurar.RowCommand
            If e.CommandName = "AdicionarLoja" Then
                cls.AdicionarCliente(grdProcurar.DataKeys(e.CommandArgument).Value)
                BindLojasRoteiro()
            End If
        End Sub
    End Class

End Namespace


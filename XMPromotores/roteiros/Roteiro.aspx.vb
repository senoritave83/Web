
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Roteiro
        Inherits XMWebEditPage
        Dim cls As clsRoteiro
        Protected Const VW_IDROTEIRO As String = "IDRoteiro"
        Protected Const VW_IDPROMOTOR As String = "IDPromotor"
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsRoteiro()
            If Not Page.IsPostBack Then
				'COMBOS
                subAddConfirm(btnApagar, "Deseja realmente apagar esta roteiro?")
                ViewState(VW_IDROTEIRO) = Cint("0" & Request("IDRoteiro"))
                ViewState(VW_IDPROMOTOR) = CInt("0" & Request("IDPromotor"))
                cls.Load(ViewState(VW_IDROTEIRO), ViewState(VW_IDPROMOTOR))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Enabled = VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                Dim pro As New clsUsuario()
                pro.Load(ViewState(VW_IDPROMOTOR))
                lblPromotor.Text = pro.Usuario
                pro = Nothing

				Inflate()
            Else
                cls.Load(ViewState(VW_IDROTEIRO), ViewState(VW_IDPROMOTOR))
          End If
        End Sub

        Protected Sub Inflate()
            Roteiro1.Dia = cls.Dia
            Roteiro1.Mes = cls.Mes
            Roteiro1.DiaSemana = cls.DiaSemana
            Roteiro1.SemanaMes = cls.SemanaMes
            chkUnicoPeriodo.Checked = IIf(cls.UnicoPeriodo = 1, True, False)
            chkAtivo.Checked = cls.Ativo
            BindLojasRoteiro()

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.Roteiro, cls.IDRoteiro)

        End Sub

        Protected Sub Deflate()
            cls.Dia = Roteiro1.Dia
            cls.Mes = Roteiro1.Mes
            cls.DiaSemana = Roteiro1.DiaSemana
            cls.SemanaMes = Roteiro1.SemanaMes
            cls.Ativo = chkAtivo.Checked
            cls.UnicoPeriodo = IIf(chkUnicoPeriodo.Checked, 1, 0)
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.Roteiro, cls.IDRoteiro)

                Inflate()
                MostraGravado("roteiro.aspx?idroteiro=" & cls.IDRoteiro & "&idpromotor=" & cls.IDPromotor)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.Roteiro, cls.IDRoteiro)

                cls.Delete()
                Response.Redirect("promotor_roteiro.aspx?idpromotor=" & ViewState(VW_IDPROMOTOR))

            End If
        End Sub

        Protected Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovo.Click
            Response.Redirect("roteiro.aspx?idroteiro=0&idpromotor=" & cls.IDPromotor)
        End Sub

        Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
            Response.Redirect("promotor_roteiro.aspx?idpromotor=" & cls.IDPromotor)
        End Sub

        'Protected Sub btnProcurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.Click
        '   ProcurarLojas()
        'End Sub

        Private Sub txtProcurarLoja_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProcurarLoja.TextChanged
            Paginate1.CurrentPage = 0
            ProcurarLojas()
        End Sub

        Protected Sub ProcurarLojas()
            Dim loj As New clsLoja
            Dim ret As PaginateResult = loj.Listar(txtProcurarLoja.Text, 0, "", 0, 0, 0, "", False, Paginate1.CurrentPage, PAGESIZE)
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
            ProcurarLojas()
        End Sub

        Protected Sub grdLojasRoteiro_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdLojasRoteiro.RowCommand
            If e.CommandName = "RetirarLoja" Then
                cls.RetirarLoja(grdLojasRoteiro.DataKeys(e.CommandArgument).Value)
                BindLojasRoteiro()
            ElseIf e.CommandName = "AlternarPesquisa" Then
                Dim vArgs() As String = Split(e.CommandArgument, "|")
                If UBound(vArgs) = 1 Then
                    If vArgs(1) = 1 Then
                        cls.AlterarStatusPesquisa(vArgs(0), 0)
                    Else
                        cls.AlterarStatusPesquisa(vArgs(0), 1)
                    End If
                    BindLojasRoteiro()
                End If
            End If
        End Sub

        Protected Sub grdProcurar_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProcurar.RowCommand
            If e.CommandName = "AdicionarLoja" Then
                Dim i As Integer = e.CommandArgument
                Dim dgItem As GridViewRow = grdProcurar.Rows(i)
                Dim cb As CheckBox = CType(dgItem.FindControl("chkPesquisar"), CheckBox)
                If cb.Checked Then
                    cls.AdicionarLoja(grdProcurar.DataKeys(e.CommandArgument).Value, 1) 'Visita com Pesquisa
                Else
                    cls.AdicionarLoja(grdProcurar.DataKeys(e.CommandArgument).Value, 0) 'Visita sem Pesquisa
                End If
                BindLojasRoteiro()
            End If
        End Sub

        Protected Sub grdLojasRoteiro_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdLojasRoteiro.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim img As ImageButton = e.Row.FindControl("ImageAlternar")
                If e.Row.DataItem("Pesquisar") = 1 Then
                    img.ImageUrl = "~/imagens/color_2.png"
                    img.AlternateText = "Realizar a pesquisa"
                Else
                    img.ImageUrl = "~/imagens/color_3.png"
                    img.AlternateText = "Não pesquisar"
                End If
            End If
        End Sub
    End Class

End Namespace


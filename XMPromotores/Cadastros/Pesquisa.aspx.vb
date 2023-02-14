Imports Classes
Imports System.Configuration.ConfigurationManager
Imports System.Collections.Generic

Namespace Pages.Cadastros

    Partial Public Class Pesquisa
        Inherits XMWebEditPage

        Dim cls As clsPesquisa
        Protected Const VW_IDPESQUISA As String = "IDPesquisa"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPesquisa()
            If Not Page.IsPostBack Then
				'COMBOS
                subAddConfirm(btnApagar, "Deseja realmente apagar esta pesquisa?")
                ViewState(VW_IDPESQUISA) = Cint("0" & Request("IDPesquisa"))
                cls.Load(ViewState(VW_IDPESQUISA))

                VerifyPermissions()

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                tdAmostragem.Visible = SettingsExpression.GetProperty("visible", "ConfiguracoesGerais.PesquisaAmostragem", "true")

                BindCargos()
                BindPerguntas()

                Inflate()

            Else
                cls.Load(ViewState(VW_IDPESQUISA))
            End If
        End Sub

        <System.Web.Script.Services.ScriptMethod(), _
        System.Web.Services.WebMethod()> _
        Public Shared Function ProcurarBandeiras(ByVal prefixText As String, ByVal count As Integer) As List(Of String)

            Dim ban As New clsCliente
            Dim lstBandeiras As New List(Of String)
            Dim sdr As System.Data.SqlClient.SqlDataReader = ban.Listar_AutoComplete(prefixText, count)
            While sdr.Read
                Dim item As String = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(sdr(1).ToString(), sdr(0).ToString())
                lstBandeiras.Add(item)
            End While
            Return lstBandeiras

        End Function

        Protected Sub BindPerguntas()
            Dim per As New clsPergunta()
            cboPergunta.DataSource = per.Listar(cls.IDPesquisa)
            cboPergunta.DataBind()
        End Sub

        Private Sub BindCargos()

            Dim clsCargos As New clsCargo()
            chkCargosPermitidos.Items.Clear()
            Dim dr As System.Data.SqlClient.SqlDataReader = clsCargos.Listar()
            Do While dr.Read
                Dim m_CargosPermitidos As String = AppSettings("CargosPermitidosNaPesquisa") & ""
                If m_CargosPermitidos <> "" Then m_CargosPermitidos = "," & m_CargosPermitidos & ","
                If m_CargosPermitidos = "" Or m_CargosPermitidos.IndexOf(dr("IDCargo")) > 0 Then
                    chkCargosPermitidos.Items.Add(New ListItem(dr("Cargo"), dr("IdCargo")))
                End If
            Loop
            chkCargosPermitidos.DataBind()
            clsCargos = Nothing

        End Sub

        Protected Sub Inflate()

            trCodigo.Visible = cls.Codigo <> ""
            lblCodigo.Text = cls.Codigo
            txtPesquisa.Text = cls.Pesquisa
            Me.PageName = cls.Pesquisa
            If cls.IDPesquisa > 0 Then
                setComboValue(cboConcorrente, cls.Concorrente)
            End If
            lblCriado.Text = cls.Criado
            Roteiro1.Dia = cls.Dia
            Roteiro1.DiaSemana = cls.DiaSemana
            Roteiro1.Mes = cls.Mes
            Roteiro1.SemanaMes = cls.SemanaMes
            chkAtivo.Checked = cls.Ativo
            chkEstoque.Checked = (cls.Acao And 1)
            chkPreco.Checked = (cls.Acao And 2)
            chkPerguntas.Checked = (cls.Acao And 4)
            chkAmostragem.Checked = (cls.Acao And 8)

            Dim strCargosPermitidos As String = "," & cls.CargosPermitidos & ","
            chkCargosPermitidos.ClearSelection()
            If strCargosPermitidos <> "" Then
                For Each chk As ListItem In chkCargosPermitidos.Items
                    If strCargosPermitidos.IndexOf(chk.Value) > 0 Then
                        chk.Selected = True
                    End If
                Next
            End If

            BindGridPerguntas()

            'cboConcorrente.Enabled = (cls.IDPesquisa = 0)

            phlOpcoes.Visible = (cls.IDPesquisa > 0)

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.Pesquisa, cls.IDPesquisa)

        End Sub

        Protected Sub BindGridPerguntas()
            grdPerguntas.DataSource = cls.ListarPerguntas(txtBuscaPergunta.Text)
            grdPerguntas.DataBind()
        End Sub

        Protected Sub Deflate()

            cls.Pesquisa = txtPesquisa.Text
            cls.Concorrente = cboConcorrente.SelectedValue
            cls.Dia = Roteiro1.Dia
            cls.DiaSemana = Roteiro1.DiaSemana
            cls.SemanaMes = Roteiro1.SemanaMes
            cls.Mes = Roteiro1.Mes
            cls.Ativo = chkAtivo.Checked
            cls.Acao = IIf(chkEstoque.Checked, 1, 0) + IIf(chkPreco.Checked, 2, 0) + IIf(chkPerguntas.Checked, 4, 0) + IIf(chkAmostragem.Checked, 8, 0)

        End Sub

        Protected Sub VerifyPermissions()

            btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
            If btnGravar.Enabled = False Then

                'PAINEL - Pesquisa cadastrada
                chkEstoque.Enabled = False
                chkPerguntas.Enabled = False
                chkPreco.Enabled = False
                chkAtivo.Enabled = False
                txtPesquisa.ReadOnly = True
                chkAtivo.Enabled = False

                'PAINEIS - Dia / Mês / Dia da Semana
                divRoteiro1.Disabled = True

                'PAINEL - Exibir a pergunta para a seguinte segmentação:
                Segmentacao1.Enabled = False

                'PAINEL - Exibir a pergunta para os seguintes critérios de lojas:
                Localizacao1.Enabled = False

            End If

            btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
            btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then

                cls.Update()

                Dim strCargosPermitidos As String = getComboValues(chkCargosPermitidos)
                If strCargosPermitidos.EndsWith(",") Then strCargosPermitidos = Left(strCargosPermitidos, strCargosPermitidos.Length - 1)
                cls.CargosPermitidos_Gravar(strCargosPermitidos)

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.Pesquisa, cls.IDPesquisa)

                Inflate()
                MostraGravado("~/cadastros/Pesquisa.aspx?idpesquisa=" & cls.IDPesquisa)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.Pesquisa, cls.IDPesquisa)

                cls.Delete()
                Response.Redirect("Pesquisas.aspx")
            End If
        End Sub


        Protected Sub grdPerguntas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdPerguntas.RowCommand
            If e.CommandName = "RetirarPergunta" Then
                cls.RetirarPerguntas(grdPerguntas.DataKeys(e.CommandArgument).Value)
                BindGridPerguntas()
            End If
        End Sub

        Protected Sub btnAddPergunta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddPergunta.Click
            cls.AdicionarPergunta(cboPergunta.SelectedValue)
            BindGridPerguntas()
        End Sub

        Protected Sub btnBuscaPergunta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscaPergunta.Click
            BindGridPerguntas()
        End Sub

        Protected Sub chkAmostragem_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkAmostragem.CheckedChanged

            If chkAmostragem.Checked Then
                chkEstoque.Checked = False
                chkPerguntas.Checked = False
                chkPreco.Checked = False
            End If

        End Sub

        Protected Sub chkPerguntas_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkPerguntas.CheckedChanged

            If chkPerguntas.Checked Then
                chkAmostragem.Checked = False
            End If

        End Sub

        Protected Sub chkPreco_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkPreco.CheckedChanged

            If chkPreco.Checked Then
                chkAmostragem.Checked = False
            End If

        End Sub

        Protected Sub chkEstoque_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkEstoque.CheckedChanged

            If chkEstoque.Checked Then
                chkAmostragem.Checked = False
            End If

        End Sub

    End Class

End Namespace


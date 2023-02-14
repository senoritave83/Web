Imports Classes
Imports System.Collections.Generic


Namespace Pages.Cadastros

    Partial Public Class Pergunta
        Inherits XMWebEditPage

        Protected cls As clsPergunta
        Protected Const VW_IDPERGUNTA As String = "IDPergunta"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPergunta()
            If Not Page.IsPostBack Then

                subAddConfirm(btnApagar, "Deseja realmente apagar esta pergunta?")
                ViewState(VW_IDPERGUNTA) = CInt("0" & Request("IDPergunta"))

                With cboPerguntaLoja
                    .Items.Clear()
                    .Items.Add(New ListItem("Na loja", "1"))
                    .Items.Add(New ListItem(SettingsExpression.GetProperty("texto", "Categoria.Mensagens.Mensagem3", "No segmento"), "4"))
                    .Items.Add(New ListItem(SettingsExpression.GetProperty("texto", "SubCategoria.Mensagens.Mensagem3", "Na categoria"), "8"))
                    .Items.Add(New ListItem(SettingsExpression.GetProperty("texto", "Produto.Mensagens.Mensagem3", "No Produto"), "16"))
                    If SettingsExpression.GetProperty("visible", "ConfiguracoesGerais.PesquisaAmostragem", "true") Then
                        .Items.Add(New ListItem("Por amostra", "2"))
                    End If
                End With

                cls.Load(ViewState(VW_IDPERGUNTA))
                Inflate()
                VerifyPermissions()
                fncChangeTipo(cboTipoCampo.SelectedItem.Value)
            Else
                cls.Load(ViewState(VW_IDPERGUNTA))
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

        Protected Sub VerifyPermissions()

            btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
            If btnGravar.Enabled = False Then

                'PAINEL - Pergunta cadastrada
                txtPergunta.ReadOnly = True
                txtPerguntaRelatorio.ReadOnly = True
                txtPrioridade.ReadOnly = True
                cboTipoCampo.Enabled = False
                txtMinimo.ReadOnly = True
                txtMaximo.ReadOnly = True
                cboPerguntaLoja.Enabled = False
                cboMultiResposta.Enabled = False
                chkAtivo.Enabled = False

                For Each row In grdRespostas.Rows
                    If row.RowType = DataControlRowType.DataRow Then
                        Dim txt As TextBox
                        txt = CType(row.FindControl("txtResposta"), TextBox)
                        txt.Enabled = False
                    End If
                Next

                'PAINEL - Exibir a pergunta para a seguinte segmentação:
                Segmentacao1.Enabled = False

                'PAINEL - Exibir a pergunta para os seguintes critérios de lojas:
                Localizacao1.Enabled = False
            End If

            btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
            btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

        End Sub

        Protected Sub BindPerguntasDependente()

            cboIDPerguntaDependente.DataSource = cls.ListarDependentes(cboPerguntaLoja.SelectedValue, txtPrioridade.Text)
            cboIDPerguntaDependente.DataBind()
            cboIDPerguntaDependente.Items.Insert(0, New ListItem("Selecione a pergunta...", "0"))

        End Sub

        Protected Sub Inflate()

            trCodigo.Visible = cls.Codigo <> ""
            lblCodigo.Text = cls.Codigo
            txtPergunta.Text = cls.Pergunta
            txtPerguntaRelatorio.Text = cls.DescricaoRelatorio
            txtPrioridade.Text = IIf(ViewState(VW_IDPERGUNTA) = "0", 100, cls.Prioridade)
            Me.PageName = cls.Pergunta
            chkAtivo.Checked = cls.Ativo

            '******************************************************
            'INICIO DAS CONFIGURAÇÕES DA PERGUNTA
            '******************************************************

            '******************************************************
            'SE FOR UM CADASTRO NOVO O USUÁRIO PODE SELECIONAR O
            '"TIPO DE CAMPO", "TIPO DE RESPOSTA" E "FAZER A PERGUNTA"
            'SE FOR UM CADASTRO EXISTENTE NÃO PODE
            'Autor: Marcelo R
            'Data: 26/07/2012 - 15:03

            lblTipoCampo.Visible = (ViewState(VW_IDPERGUNTA) > 0)
            lblMultiResposta.Visible = (ViewState(VW_IDPERGUNTA) > 0)
            lblPerguntaLoja.Visible = (ViewState(VW_IDPERGUNTA) > 0)

            cboTipoCampo.Visible = (ViewState(VW_IDPERGUNTA) = 0)
            cboMultiResposta.Visible = (ViewState(VW_IDPERGUNTA) = 0)
            cboPerguntaLoja.Visible = (ViewState(VW_IDPERGUNTA) = 0)
            '******************************************************

            cboMultiResposta.SelectedIndex = IIf(cls.MultiResposta, 1, 0)
            cboPerguntaLoja.SelectedValue = cls.PerguntaLoja

            hidTipoCampo.Value = cls.TipoCampo
            setComboValue(cboTipoCampo, cls.TipoCampo)
            Select Case cls.TipoCampo
                Case 0
                    lblTipoCampo.Text = "Sele&ccedil;&atilde;o"
                Case 1
                    lblTipoCampo.Text = "Num&eacute;rico"
                Case 2
                    lblTipoCampo.Text = "Foto"
                Case 3
                    lblTipoCampo.Text = "Data"
                Case 4
                    lblTipoCampo.Text = "Decimal"
                Case 5
                    lblTipoCampo.Text = "Alfa-Num&eacute;rico"
                Case 6
                    lblTipoCampo.Text = "Código de Barras"

            End Select

            Select Case cls.PerguntaLoja
                Case 1
                    lblPerguntaLoja.Text = "Na loja"
                Case 2
                    lblPerguntaLoja.Text = "Por amostra"
                Case 4
                    lblPerguntaLoja.Text = SettingsExpression.GetProperty("texto", "Categoria.Mensagens.Mensagem3", "No segmento")
                Case 8
                    lblPerguntaLoja.Text = SettingsExpression.GetProperty("texto", "SubCategoria.Mensagens.Mensagem3", "Na categoria")
                Case 16
                    lblPerguntaLoja.Text = SettingsExpression.GetProperty("texto", "Produto.Mensagens.Mensagem3", "No Produto")
            End Select

            Select Case cls.MultiResposta
                Case 0
                    lblMultiResposta.Text = "Alternativa &uacute;nica"
                Case 1
                    lblMultiResposta.Text = "M&uacute;ltiplas alternativas"
            End Select

            txtMinimo.Text = IIf(cls.Minimo = 0, "", cls.Minimo)
            txtMaximo.Text = IIf(cls.Maximo = 0, "", cls.Maximo)



            '******************************************************
            'FIM DAS CONFIGURAÇÕES DA PERGUNTA
            '******************************************************

            grdRespostas.DataSource = cls.ListarRespostas()
            grdRespostas.DataBind()

            BindPerguntasDependente()

            cboCondicional.SelectedValue = IIf(cls.Condicional, "1", "0")
            cboIDTipoDependencia.SelectedValue = cls.TipoDependencia
            If cls.IDDependente = 0 Then
                cboIDPerguntaDependente.ClearSelection()
            Else
                cboIDPerguntaDependente.SelectedValue = cls.IDDependente
            End If

            tblPerguntaCondicional.Visible = SettingsExpression.GetProperty("visible", "ConfiguracoesGerais.PerguntaCondicional", "true")
            tblCondicional.Visible = SettingsExpression.GetProperty("visible", "ConfiguracoesGerais.PerguntaCondicional", "true") And cls.Condicional

            txtValorDependencia.Text = cls.DependenteValor

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.Pergunta, cls.IDPergunta)

        End Sub

        Protected Sub Deflate()
            cls.Pergunta = txtPergunta.Text
            cls.DescricaoRelatorio = txtPerguntaRelatorio.Text
            cls.Prioridade = txtPrioridade.Text
            cls.MultiResposta = (cboMultiResposta.SelectedIndex = 1)
            cls.PerguntaLoja = cboPerguntaLoja.SelectedValue
            cls.Ativo = chkAtivo.Checked
            cls.TipoCampo = cboTipoCampo.SelectedValue
            cls.Minimo = IIf(txtMinimo.Text = "", 0, txtMinimo.Text)
            cls.Maximo = IIf(txtMaximo.Text = "", 0, txtMaximo.Text)

            If cboCondicional.SelectedValue = "1" Then
                cls.TipoDependencia = cboIDTipoDependencia.SelectedValue
                cls.IDDependente = CInt("0" & cboIDPerguntaDependente.SelectedValue)
                cls.DependenteValor = txtValorDependencia.Text
            Else
                cls.TipoDependencia = 0
                cls.IDDependente = 0
                cls.DependenteValor = 0
            End If

            cls.Respostas.Clear()
            Dim intIndex As Integer = 1
            Dim row As GridViewRow
            For Each row In grdRespostas.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim txt As TextBox
                    txt = CType(row.FindControl("txtResposta"), TextBox)

                    Dim chk As HtmlInputCheckBox
                    chk = CType(row.FindControl("chkRespostaUnica"), HtmlInputCheckBox)

                    Dim cboAcao As DropDownList = row.FindControl("cboAcao")
                    Dim cboAcaoValor As DropDownList = row.FindControl("cboIDPerguntaPular")
                    Dim iAcao As Byte = cboAcao.SelectedValue
                    Dim iAcaoValue As Integer = cboAcaoValor.SelectedValue

                    If cboCondicional.SelectedValue = "0" Then
                        iAcao = 0
                        iAcaoValue = 0
                    End If

                    If txt.Text <> "" Then cls.Respostas.Add(txt.Text, chk.Checked, iAcao, iAcaoValue)
                    intIndex += 1
                End If
            Next
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.Pergunta, cls.IDPergunta)

                Inflate()
                MostraGravado("~/cadastros/Pergunta.aspx?idpergunta=" & cls.idpergunta)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()
        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.Pergunta, cls.IDPergunta)

                cls.Delete()
                Response.Redirect("Perguntas.aspx")
            End If
        End Sub

        Protected Sub grdRespostas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRespostas.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim cbo As DropDownList = e.Row.FindControl("cboIDPerguntaPular")
                cbo.DataSource = cls.ListarDependentes(cboPerguntaLoja.SelectedValue, txtPrioridade.Text, True)
                cbo.DataBind()
                cbo.Items.Insert(0, New ListItem("", "0"))
                cbo.SelectedValue = e.Row.DataItem("AcaoValor")


                Dim cboAcao As DropDownList = e.Row.FindControl("cboAcao")
                cboAcao.Items.Clear()
                cboAcao.Items.Add(New ListItem("nenhuma", clsPerguntaResposta.enRespostaAcao.Nenhuma))
                If cbo.Items.Count > 1 Then
                    cboAcao.Items.Add(New ListItem("pular para", clsPerguntaResposta.enRespostaAcao.Pular))
                End If
                cboAcao.Items.Add(New ListItem("finalizar", clsPerguntaResposta.enRespostaAcao.Finalizar))
                cboAcao.SelectedValue = e.Row.DataItem("Acao")
                cboAcao.Attributes.Add("idresposta", e.Row.DataItem("IDResposta"))
                cboAcao.Attributes.Add("onchange", "fncChangeAcao(this, " & e.Row.DataItem("IDResposta") & ")")


                Dim chk As HtmlInputCheckBox = e.Row.FindControl("chkRespostaUnica")
                chk.Value = e.Row.DataItem("IDResposta")
                chk.Disabled = IIf(cboMultiResposta.SelectedIndex <> 1, True, False)
                chk.Checked = e.Row.DataItem("Unica")
                '<%# IIF(cboMultiResposta.selectedIndex <> 1, "disabled", "")%> <%# IIF(Eval("Unica"), "checked", "")%>

            End If
        End Sub

        Protected Sub fncChangeTipo(ByVal vTipo As Integer)

            Dim max_min As Boolean = True '//<%= SettingsExpression.GetProperty("visible", "Pergunta.MinMax", "true") %>;
            trMaximo.Visible = False
            trMinimo.Visible = False
            If vTipo = 0 Then
                Dim row As GridViewRow
                For Each row In grdRespostas.Rows
                    Dim txt As TextBox
                    txt = CType(row.FindControl("txtResposta"), TextBox)
                    If Not txt Is Nothing Then
                        txt.BorderStyle = BorderStyle.Outset
                        txt.BorderColor = Drawing.Color.Black
                        txt.BackColor = Drawing.Color.White
                        txt.Enabled = True
                    End If
                Next
                trTiporesposta.Visible = True
                fncChangeMultiplo(True)
            Else
                Dim row As GridViewRow
                For Each row In grdRespostas.Rows
                    Dim txt As TextBox
                    txt = CType(row.FindControl("txtResposta"), TextBox)
                    If Not txt Is Nothing Then
                        txt.BorderStyle = BorderStyle.None
                        txt.BackColor = Drawing.Color.Gainsboro
                        txt.Enabled = False
                        txt.Text = ""
                    End If
                Next
                trTiporesposta.Visible = False
                fncChangeMultiplo(False)
                If max_min = True Then
                    If cboTipoCampo.SelectedItem.Value = 1 Or cboTipoCampo.SelectedItem.Value = 4 Then
                        trMaximo.Visible = True
                        trMinimo.Visible = True
                    End If
                End If
            End If

        End Sub

        Protected Sub fncChangeMultiplo(ByVal vMultiplo As Boolean)
            Dim row As GridViewRow
            For Each row In grdRespostas.Rows
                Dim txt As TextBox
                Dim CHK As HtmlInputCheckBox
                txt = CType(row.FindControl("txtResposta"), TextBox)
                CHK = CType(row.FindControl("chkRespostaUnica"), HtmlInputCheckBox)

                If Not txt Is Nothing Then
                    If vMultiplo Then
                        txt.BorderStyle = BorderStyle.Outset
                        txt.BorderColor = Drawing.Color.Black
                        txt.BackColor = Drawing.Color.White
                        txt.Enabled = True
                    Else
                        txt.BorderStyle = BorderStyle.None
                        txt.BackColor = Drawing.Color.Gainsboro
                        txt.Enabled = False
                        txt.Text = ""
                    End If
                End If
                If Not CHK Is Nothing Then
                    CHK.Disabled = Not vMultiplo
                    If CHK.Disabled Then CHK.Checked = False
                End If
            Next
        End Sub

        Protected Sub cboCondicional_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboCondicional.SelectedIndexChanged

            tblCondicional.Visible = IIf(cboCondicional.SelectedIndex = 0, False, True)

        End Sub

        Protected Sub cboTipoCampo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTipoCampo.SelectedIndexChanged

            fncChangeTipo(cboTipoCampo.SelectedItem.Value)

        End Sub

        Protected Sub cboMultiResposta_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboMultiResposta.SelectedIndexChanged
            fncChangeMultiplo(True)
        End Sub

        Protected Sub cboIDTipoDependencia_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboIDTipoDependencia.SelectedIndexChanged

            With cboIDTipoDependencia
                If .SelectedIndex = 0 Then
                    tblCondicaoResposta.visible = False
                ElseIf .SelectedIndex = 1 Then
                    tblCondicaoResposta.visible = True
                    lblPreposicao.InnerText = "a"
                Else
                    tblCondicaoResposta.visible = True
                    lblPreposicao.InnerText = "de"
                End If
            End With
        End Sub
    End Class

End Namespace


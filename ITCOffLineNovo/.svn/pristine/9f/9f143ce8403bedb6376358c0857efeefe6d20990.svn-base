Imports System.Data.SqlClient
Imports System.Data.Common
Imports ITCOffLine
Imports System.Data

Public Class Proposta
    Inherits XMWebPage

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents Barra As BarraBotoes2
    Protected WithEvents BarraBotoesProposta As BarraBotoesProposta
    Protected WithEvents plcMensagem As PlaceHolder
    Protected WithEvents plcMain As PlaceHolder
    Protected WithEvents rptOrcamentos As System.Web.UI.WebControls.Repeater
    Protected WithEvents dtgContatos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dtgPlanos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dtgAssociados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents tblAssociadosDet As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblContatos As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblAssociado As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblOrcamento As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblProposta As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblObservacao As System.Web.UI.WebControls.Table
    Protected WithEvents tblBotoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trAddContato As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdRenovacao As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtRazaoFantasia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodigoAss As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtData_Proposta As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndereco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtComplemento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCep As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCidade As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtObservacao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWebSite As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmailPrincipal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtContatoCad As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefoneContato As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFaxContato As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCelContato As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmailContato As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtValidadeProposta As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtExpiraProposta As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblOrcamentoRS As System.Web.UI.WebControls.Label
    Protected WithEvents lblNumPedido As System.Web.UI.WebControls.Label
    Protected WithEvents lblExpiraOrcamento As System.Web.UI.WebControls.Label
    Protected WithEvents lblNumeroProposta As System.Web.UI.WebControls.Label
    Protected WithEvents lblIdAssociado As System.Web.UI.WebControls.Label
    Protected WithEvents lblRazaoSocial As System.Web.UI.WebControls.Label
    Protected WithEvents lblIdProposta As System.Web.UI.WebControls.Label
    Protected WithEvents lblCnpj As System.Web.UI.WebControls.Label
    Protected WithEvents lblCodigoItc As System.Web.UI.WebControls.Label
    Protected WithEvents lblContato As System.Web.UI.WebControls.Label
    Protected WithEvents lblMensagem As Label
    Protected WithEvents lblIdPropostaPai As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents trNumPedido As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents cboIdEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboIdVendedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboIdStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboRegistros As ComboBox
    Protected WithEvents cboIdContato As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboIdPosicao As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboIdTipoProposta As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rdOrcamento As System.Web.UI.WebControls.RadioButton
    Protected WithEvents btnEnviarEmail As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents btnProcurar As Button
    Protected WithEvents btnCancelarProp As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnImprimir As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents btnAddOrcamento As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnAprovarProp As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnFinalizarProp As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnReprovarProp As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnGerarPedido As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnAddContato As System.Web.UI.WebControls.Button
    Protected WithEvents btnOKMensagem As Button
    Protected WithEvents btnRenovacao As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgRenovacao As System.Web.UI.WebControls.Image
    Protected WithEvents imgStatus As System.Web.UI.WebControls.Image
    Protected WithEvents ltrMsgBox As System.Web.UI.WebControls.Literal
    Protected WithEvents IRP As System.Web.UI.WebControls.HiddenField


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Associados As clsAssociados
    Private Proposta As clsProposta
    Dim Cid As New clsCidades
    Dim Cidades As DataSet
    Private p_Value As Double
    Private p_Contato As String

    Private ds As DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            If CheckPermission("Cadastro de Propostas", "VISUALIZAR") = False Then
                Response.Redirect("home.aspx")
            End If

            Dim objAssociado As Object = DeCryptography(Page.Request("IdAssociado"))
            Dim m_IdAssociado As Integer

            VerificaPropostas(objAssociado)

            With cboIdStatus
                .Items.Insert(0, New ListItem("Em Edição", "5"))
                .Items.Insert(1, New ListItem("Aprovada", "1"))
                .Items.Insert(2, New ListItem("Finalizada", "2"))
                .Items.Insert(3, New ListItem("Cancelada", "3"))
                .Items.Insert(4, New ListItem("Reprovada pelo Cliente", "4"))
                .Items.Insert(5, New ListItem("Pedido Gerado", "6"))
                .Items.Insert(6, New ListItem("Em Renovação", "7"))
                .Items.Insert(7, New ListItem("Selecione..", "0"))
            End With

            Dim Est As New clsEstados
            With cboIdEstado
                .CssClass = "f8"
                .DataSource = Est.ListEstados
                .DataTextField = "UF"
                .DataValueField = "IdEstado"
                .DataBind()
                Est = Nothing
            End With
            cboIdEstado.Items.Insert(0, New ListItem("Selecione..", "0"))

            Dim Vend As New clsUsuario
            With cboIdVendedor
                .ClearSelection()
                .CssClass = "f8"
                .DataSource = Vend.ListVendedores(Me.Usuario.IdEmpresa, Vend.TipoUsuario.Vendedor)
                .DataTextField = "Vendedor"
                .DataValueField = "IdVendedor"
                .DataBind()
                Vend = Nothing
            End With
            'cboIdVendedor.Items.Insert(0, New ListItem("Selecione..", "0"))    *********** JÁ EXISTE UMA FUNÇÃO NO CONTROLE DE COMBOBOX QUE TRAZ O "SELECIONE..." *************


            With cboIdTipoProposta
                .Items.Insert(0, New ListItem("Selecione..", "0"))
                .Items.Insert(1, New ListItem("ITCnet", "1"))
                .Items.Insert(2, New ListItem("Guia de negócios", "2"))
            End With

            BarraBotoesProposta.AtivarBotoes(BarraBotoesProposta.Botoes_Ativos.Voltar + IIf(CheckPermission("Cadastro de Propostas", "ATUALIZAR"), BarraBotoesProposta.Botoes_Ativos.Atualizar, 0) + IIf(CheckPermission("Cadastro de Propostas", "ADICIONAR"), BarraBotoesProposta.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Propostas", "EXCLUIR"), BarraBotoesProposta.Botoes_Ativos.Excluir, 0))

            If IsNumeric(objAssociado) Then

                m_IdAssociado = objAssociado
                Associados = New clsAssociados(m_IdAssociado)
                InflateAssociado(m_IdAssociado)
                ViewState("IdProposta") = 0
                BindPosicao()

            Else

                m_IdAssociado = 0

                Dim objProposta As Object = DeCryptography(Page.Request("IDProposta"))
                Dim m_IdProposta As Integer
                If IsNumeric(objProposta) Then
                    m_IdProposta = objProposta
                Else
                    m_IdProposta = 0
                End If
                ViewState("IdProposta") = CInt(0 & m_IdProposta)

                Proposta = New clsProposta
                Proposta.Load(ViewState("IdProposta"))
                ViewState("IdAssociado") = Proposta.IdAssociado

                ViewState("IdNumPedido") = Proposta.NumeroPedido

                BindPosicao()

                Dim contAss As New clsContatoAssociados
                With cboIdContato
                    .CssClass = "f8"
                    .DataSource = contAss.List(ViewState("IdAssociado"))
                    .DataTextField = "NomeContato"
                    .DataValueField = "IdContato"
                    .DataBind()
                    contAss = Nothing
                End With
                cboIdContato.Items.Insert(0, New ListItem("Selecione..", "0"))

                Inflate()
                btnAddOrcamento.Visible = True
                ListarOrcamentos()

            End If

            If ViewState("IdProposta") = 0 Then
                btnImprimir.Visible = False
                btnEnviarEmail.Visible = False
                BarraBotoesProposta.InativarBotoes(BarraBotoesProposta.Botoes_Ativos.Excluir)
            End If

        Else

            Proposta = New clsProposta

        End If

        btnCancelarProp.Attributes.Add("onClick", "return fncConfirm(3);")
        btnAprovarProp.Attributes.Add("onClick", "return fncVerificaInicioeTermino();")
        btnReprovarProp.Attributes.Add("onClick", "return fncConfirm(4);")
        btnFinalizarProp.Attributes.Add("onClick", "return fncValidaCampo();")
        btnAddContato.Attributes.Add("onClick", "if(fncValida('dtgContatos')==false)return false;")
        btnGerarPedido.Attributes.Add("onClick", "return fncConfirm(6);")
        btnRenovacao.Attributes.Add("onClick", "return fncConfirm(7);")

        CamposReadOnly()

    End Sub

    Private Sub BindContatosProposta()
        Dim ContProp As New clsContatoAssociados(Me)
        dtgContatos.DataSource = ContProp.ListContatosProposta(ViewState("IdProposta"))
        dtgContatos.DataBind()
        ContProp = Nothing
    End Sub

    Private Sub BindPosicao(Optional ByVal vIdPosicao As Integer = 0)

        Dim Pos As New clsPosicao
        With cboIdPosicao
            .CssClass = "f8"
            .DataSource = Pos.ListPosicao()
            .DataTextField = "DescricaoPosicao"
            .DataValueField = "IdPosicao"
            .DataBind()
            If vIdPosicao <> 2 Then
                For Each lst As ListItem In cboIdPosicao.Items
                    If lst.Text = "Renovação" Then
                        .Items.Remove(lst)
                        Exit For
                    End If
                Next
                Pos = Nothing
            Else
                .Enabled = False
            End If
        End With

    End Sub

    Private Sub Deflate()
        With Proposta
            .IdProposta = IIf(lblIdProposta.Text = "", 0, lblIdProposta.Text)
            .IdVendedor = cboIdVendedor.SelectedValue
            .IdAssociado = lblIdAssociado.Text
            .DataProposta = txtData_Proposta.Text
            .IdStatus = cboIdStatus.SelectedValue
            .RazaoSocial = lblRazaoSocial.Text
            .Endereco = txtEndereco.Text
            .Complemento = txtComplemento.Text
            .CEP = txtCep.Text
            .Cidade = txtCidade.Text
            .IdEstado = cboIdEstado.SelectedValue
            .Telefone = txtTelefone.Text
            .Fax = txtFax.Text
            .CNPJ = lblCnpj.Text
            .WebSite = txtWebSite.Text
            .EmailPrincipal = txtEmailPrincipal.Text
            .ContatoCad = txtContatoCad.Text
            .TelefoneContato = txtTelefoneContato.Text
            .FaxContato = txtFaxContato.Text
            .CelularContato = txtCelContato.Text
            .EmailContato = txtEmailContato.Text
            .Observacoes = txtObservacao.Text
            .ValidadeProposta = txtValidadeProposta.Text
            .IdTipoProposta = cboIdTipoProposta.SelectedValue
            If IRP.Value Then
                .IdPosicao = 2
            Else
                .IdPosicao = cboIdPosicao.SelectedValue
            End If
        End With
    End Sub

    Private Sub Inflate()
        lblIdProposta.Text = Proposta.IdProposta
        cboIdStatus.SelectedValue = Proposta.IdStatus
        ViewState("IdStatus") = Proposta.IdStatus
        txtData_Proposta.Text = Proposta.DataProposta
        XMSetListItemValue(cboIdVendedor, Proposta.IdVendedor)
        lblRazaoSocial.Text = Proposta.RazaoSocial
        lblIdAssociado.Text = Proposta.IdAssociado
        txtEndereco.Text = Proposta.Endereco
        txtComplemento.Text = Proposta.Complemento
        txtCep.Text = Proposta.CEP
        txtCidade.Text = Proposta.Cidade
        cboIdEstado.SelectedValue = Proposta.IdEstado
        txtTelefone.Text = Proposta.Telefone
        txtFax.Text = Proposta.Fax
        lblCnpj.Text = Proposta.CNPJ
        txtWebSite.Text = Proposta.WebSite
        txtEmailPrincipal.Text = Proposta.EmailPrincipal
        txtContatoCad.Text = Proposta.ContatoCad
        txtTelefoneContato.Text = Proposta.TelefoneContato
        txtFaxContato.Text = Proposta.FaxContato
        txtCelContato.Text = Proposta.CelularContato
        txtEmailContato.Text = Proposta.EmailContato
        txtObservacao.Text = Proposta.Observacoes
        txtValidadeProposta.Text = Proposta.ValidadeProposta
        'tdRenovacao.Visible = Proposta.Renovacao
        lblIdPropostaPai.Text = Proposta.IdPropostaPai
        cboIdTipoProposta.SelectedValue = Proposta.IdTipoProposta
        BindPosicao(Proposta.IdPosicao)
        cboIdPosicao.SelectedValue = Proposta.IdPosicao
        ViewState("EmailVendedor") = Proposta.EmailVendedor
        If ViewState("IdNumPedido") = 0 Then
            trNumPedido.Visible = False 'Proposta não gerou pedido
        Else
            trNumPedido.Visible = True 'Proposta gerou pedido
            lblNumPedido.Text = ViewState("IdNumPedido")
        End If

        BindContatosProposta()

    End Sub

    Public Sub InflateAssociado(ByVal v_IdAssociado As Integer)
        txtData_Proposta.Text = Now.Date
        If Not cboIdVendedor.Items.FindByValue(Associados.IdVendedor) Is Nothing Then
            cboIdVendedor.SelectedValue = Associados.IdVendedor
        End If
        lblRazaoSocial.Text = Associados.RazaoSocial
        lblIdAssociado.Text = Associados.Codigo
        txtEndereco.Text = Associados.Endereco
        txtComplemento.Text = Associados.Complemento
        txtCep.Text = Associados.CEP
        txtCidade.Text = Associados.Cidade
        cboIdEstado.SelectedValue = Associados.Estado
        txtTelefone.Text = Associados.Telefone
        txtFax.Text = Associados.Fax
        lblCnpj.Text = Associados.CNPJ
        txtWebSite.Text = Associados.WebSite
        txtEmailPrincipal.Text = Associados.EMail
        cboIdPosicao.SelectedValue = Associados.IdPosicao


        Dim clsContato As New clsContatoAssociados

        dtgContatos.DataSource = clsContato.List(v_IdAssociado)
        dtgContatos.DataBind()
        clsContato = Nothing

        dtgContatos.Columns(0).Visible = False
        trAddContato.Visible = False
        trNumPedido.Visible = False
    End Sub

    Private Sub CamposReadOnly()

        ''SE A PROPOSTA NÃO EXISTIR OU SE O STATUS FOR DIFERENTE DE 5 (EM EDIÇÃO) E 2 (FINALIZADA) OS CAMPOS NÃO PODERAM SOFRER ALTERAÇÕES
        If ViewState("IdProposta") = 0 Or ViewState("IdStatus") <> 5 And ViewState("IdStatus") <> 2 And ViewState("IdStatus") <> 7 Then

            cboIdVendedor.Enabled = False
            txtData_Proposta.ReadOnly = True
            txtEndereco.ReadOnly = True
            txtComplemento.ReadOnly = True
            txtCidade.ReadOnly = True
            cboIdEstado.Enabled = False
            txtCep.ReadOnly = True
            txtWebSite.ReadOnly = True
            txtEmailPrincipal.ReadOnly = True
            txtEndereco.ReadOnly = True
            txtComplemento.ReadOnly = True
            txtCep.ReadOnly = True
            cboIdEstado.Enabled = False
            txtTelefone.ReadOnly = True
            txtFax.ReadOnly = True
            txtWebSite.ReadOnly = True
            txtEmailPrincipal.ReadOnly = True
            txtContatoCad.ReadOnly = True
            txtEmailContato.ReadOnly = True
            txtTelefoneContato.ReadOnly = True
            txtEmailContato.ReadOnly = True
            txtTelefoneContato.ReadOnly = True
            txtCelContato.ReadOnly = True
            txtFaxContato.ReadOnly = True
            cboIdContato.Enabled = False
            btnAddOrcamento.Visible = False
            btnAprovarProp.Visible = False
            btnFinalizarProp.Visible = False
            btnCancelarProp.Visible = False
            dtgContatos.Columns(0).Visible = False
            txtObservacao.ReadOnly = True
            txtValidadeProposta.ReadOnly = True
            cboIdTipoProposta.Enabled = False
            cboIdPosicao.Enabled = False


            'SE O STATUS DA PROPOSTA FOR DIFERENTE DE 5 (EM EDIÇÃO) E 2 (FINALIZADA) A PROPOSTA NÃO PODERÁ SOFRER ALTERAÇÕES
            If ViewState("IdStatus") <> 5 And ViewState("IdStatus") <> 2 And ViewState("IdStatus") <> Nothing Then

                txtData_Proposta.ReadOnly = True
                cboIdVendedor.Enabled = False
                txtEndereco.ReadOnly = True
                txtComplemento.ReadOnly = True
                txtCidade.ReadOnly = True
                cboIdEstado.Enabled = False
                txtCep.ReadOnly = True
                txtTelefone.ReadOnly = True
                txtFax.ReadOnly = True
                txtWebSite.ReadOnly = True
                txtEmailPrincipal.ReadOnly = True
                txtContatoCad.ReadOnly = True
                txtEmailContato.ReadOnly = True
                txtTelefoneContato.ReadOnly = True
                txtEmailContato.ReadOnly = True
                txtTelefoneContato.ReadOnly = True
                txtCelContato.ReadOnly = True
                txtFaxContato.ReadOnly = True
                cboIdContato.Enabled = False
                btnAddOrcamento.Visible = False
                btnAprovarProp.Visible = False
                btnFinalizarProp.Visible = False
                btnCancelarProp.Visible = False
                txtObservacao.ReadOnly = True
                txtValidadeProposta.ReadOnly = True
                cboIdTipoProposta.Enabled = False

                BarraBotoesProposta.InativarBotoes(BarraBotoesProposta.Botoes_Ativos.Atualizar + BarraBotoesProposta.Botoes_Ativos.Excluir)
                dtgContatos.Columns(0).Visible = False
                btnAddContato.Enabled = False
                cboIdContato.Enabled = False

                'SE A PROPOSTA ESTIVER CANCELADA OU REPROVADA PELO CLIENTE, SÓ MOSTRA O BOTÃO INCLUIR E VOLTAR
                If ViewState("IdStatus") = 3 Or ViewState("IdStatus") = 4 Then
                    btnAprovarProp.Visible = False
                    btnReprovarProp.Visible = False
                    btnCancelarProp.Visible = False
                    btnImprimir.Visible = False
                    btnEnviarEmail.Visible = False
                    btnAddOrcamento.Visible = False
                    btnFinalizarProp.Visible = False
                    BarraBotoesProposta.InativarBotoes(BarraBotoesProposta.Botoes_Ativos.Excluir + BarraBotoesProposta.Botoes_Ativos.Atualizar)
                End If

                If ViewState("IdStatus") = 1 Then
                    btnGerarPedido.Visible = CheckPermission("Cadastro de Propostas", "GERAR PEDIDO")
                    btnReprovarProp.Visible = False
                    btnEnviarEmail.Visible = False
                    'btnRenovacao.Visible = CheckPermission("Cadastro de Propostas", "RENOVAR")
                End If

                If ViewState("IdStatus") = 6 Then
                    btnRenovacao.Visible = CheckPermission("Cadastro de Propostas", "RENOVAR")
                    btnEnviarEmail.Visible = False
                End If

            End If

        Else

            'SE O STATUS DA PROPOSTA FOR "EM EDIÇÃO" OU "FINALIZADA" OU "EM RENOVAÇÃO" OS CAMPOS PODEM SOFRER ALTERAÇÕES
            cboIdVendedor.Enabled = True
            txtData_Proposta.ReadOnly = False
            txtEndereco.ReadOnly = False
            txtComplemento.ReadOnly = False
            txtCidade.ReadOnly = False
            cboIdEstado.Enabled = True
            txtCep.ReadOnly = False
            txtWebSite.ReadOnly = False
            txtEmailPrincipal.ReadOnly = False
            txtEndereco.ReadOnly = False
            txtComplemento.ReadOnly = False
            txtCep.ReadOnly = False
            txtTelefone.ReadOnly = False
            txtFax.ReadOnly = False
            txtWebSite.ReadOnly = False
            txtEmailPrincipal.ReadOnly = False
            txtContatoCad.ReadOnly = False
            txtEmailContato.ReadOnly = False
            txtTelefoneContato.ReadOnly = False
            txtEmailContato.ReadOnly = False
            txtTelefoneContato.ReadOnly = False
            txtCelContato.ReadOnly = False
            txtFaxContato.ReadOnly = False
            cboIdContato.Enabled = True
            txtObservacao.ReadOnly = False
            txtValidadeProposta.ReadOnly = False
            cboIdTipoProposta.Enabled = True

            btnAddOrcamento.Visible = CheckPermission("Cadastro de Propostas", "INCLUIR ORCAMENTO")
            btnAprovarProp.Visible = CheckPermission("Cadastro de Propostas", "APROVAR")
            btnFinalizarProp.Visible = CheckPermission("Cadastro de Propostas", "FINALIZAR")
            btnCancelarProp.Visible = CheckPermission("Cadastro de Propostas", "CANCELAR")
            dtgContatos.Columns(0).Visible = CheckPermission("Cadastro de Propostas", "ATUALIZAR")
            trAddContato.Visible = CheckPermission("Cadastro de Propostas", "ATUALIZAR")

        End If

        If rptOrcamentos.Items.Count = 0 And ViewState("IdStatus") = 5 And ViewState("IdProposta") <> 0 Then
            btnImprimir.Visible = False
            btnEnviarEmail.Visible = False
            btnCancelarProp.Visible = False
            btnFinalizarProp.Visible = False
            btnAprovarProp.Visible = False
        End If

        If rptOrcamentos.Items.Count > 0 And ViewState("IdStatus") = 5 And ViewState("IdProposta") <> 0 Then
            BarraBotoesProposta.AtivarBotoes(BarraBotoesProposta.Botoes_Ativos.Incluir + BarraBotoesProposta.Botoes_Ativos.Excluir + BarraBotoesProposta.Botoes_Ativos.Atualizar + BarraBotoesProposta.Botoes_Ativos.Voltar)
            btnAddOrcamento.Visible = CheckPermission("Cadastro de Propostas", "INCLUIR ORCAMENTO")
            btnFinalizarProp.Visible = CheckPermission("Cadastro de Propostas", "FINALIZAR")
            btnImprimir.Visible = False
            btnEnviarEmail.Visible = False
            btnCancelarProp.Visible = False
            btnAprovarProp.Visible = False
        End If

        'SE A PROPOSTA ESTIVER FINALIZADA, MOSTRA O BOTÃO REPROVAR E APROVAR PROPOSTA
        If ViewState("IdStatus") = 2 Then
            btnFinalizarProp.Visible = False
            btnReprovarProp.Visible = CheckPermission("Cadastro de Propostas", "REPROVAR")
            btnAprovarProp.Visible = CheckPermission("Cadastro de Propostas", "APROVAR")
        End If


        'SE A PROPOSTA TIVER STATUS 7 (EM RENOVAÇÃO) E NO COMBO ESTIVER SELECIONADO A OPÇÃO 2 (RENOVAÇÃO) ALGUNS BOTÕES SÃO OCULTADOS
        If ViewState("IdStatus") = 7 And cboIdPosicao.SelectedValue = 2 Then
            btnAprovarProp.Visible = False
            btnImprimir.Visible = False
            btnEnviarEmail.Visible = False
        End If

        ListarOrcamentos()

    End Sub

    Private Sub Clear()

        lblIdProposta.Text = ""
        cboIdStatus.SelectedValue = 0
        txtData_Proposta.Text = ""
        cboIdVendedor.SelectedValue = 0
        lblRazaoSocial.Text = ""
        lblIdAssociado.Text = 0
        ViewState("IdAssociado") = 0
        txtEndereco.Text = ""
        txtComplemento.Text = ""
        txtCep.Text = ""
        txtCidade.Text = ""
        cboIdEstado.SelectedValue = 0
        txtTelefone.Text = ""
        txtFax.Text = ""
        lblCnpj.Text = ""
        txtWebSite.Text = ""
        txtEmailPrincipal.Text = ""
        txtContatoCad.Text = ""
        txtTelefoneContato.Text = ""
        txtFaxContato.Text = ""
        txtCelContato.Text = ""
        txtEmailContato.Text = ""
        cboIdTipoProposta.SelectedValue = 0

    End Sub

    Private Sub BarraBotoes_Atualizar() Handles BarraBotoesProposta.Atualizar
        Deflate()
        Proposta.Update()
        Log_Usuario("GRAVAR PROPOSTA", XMWebPage.MODULO.PROPOSTAS)
        Gravado("proposta.aspx?idproposta=" & CryptographyEncoded(Proposta.IdProposta))
    End Sub

    Private Sub BarraBotoes_Incluir() Handles BarraBotoesProposta.Incluir
        Response.Redirect("propostas.aspx?grdPropostas=false")
    End Sub

    Private Sub BarraBotoes_Voltar() Handles BarraBotoesProposta.Voltar
        Response.Redirect("propostas.aspx")
    End Sub

    Private Sub BarraBotoes_Excluir() Handles BarraBotoesProposta.Excluir
        Proposta.IdProposta = ViewState("IdProposta")
        If Proposta.Delete() = True Then
            Log_Usuario("APAGAR PROPOSTA", XMWebPage.MODULO.PROPOSTAS)
            Response.Redirect("propostas.aspx")
        End If
    End Sub

    Private Sub btnFinalizarProp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFinalizarProp.Click

        If ViewState("IdProposta") > 0 Then
            ViewState("IdStatus") = 2 'Proposta Finalizada
            cboIdStatus.SelectedValue = ViewState("IdStatus")
            Deflate()
            Proposta.Update()

            Log_Usuario("FINALIZAR PROPOSTA", XMWebPage.MODULO.PROPOSTAS)
            Response.Redirect("proposta.aspx?IdProposta=" & CryptographyEncoded(ViewState("IdProposta")))

        End If

    End Sub

    Protected Sub btnCancelarProp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelarProp.Click
        If ViewState("IdProposta") > 0 Then
            ViewState("IdStatus") = 3 'Proposta Cancelada
            cboIdStatus.SelectedValue = ViewState("IdStatus")
            Deflate()
            Proposta.Update()
            Log_Usuario("CANCELAR PROPOSTA", XMWebPage.MODULO.PROPOSTAS)
            CamposReadOnly()
        End If
    End Sub

    Private Sub btnReprovarProp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnReprovarProp.Click

        If ViewState("IdProposta") > 0 Then
            ViewState("IdStatus") = 4 'Proposta Reprovada pelo cliente
            cboIdStatus.SelectedValue = ViewState("IdStatus")
            Deflate()
            Proposta.Update()
            Log_Usuario("REPROVAR PROPOSTA", XMWebPage.MODULO.PROPOSTAS)
            CamposReadOnly()
        End If

        btnReprovarProp.Visible = False

    End Sub

    Private Sub btnGerarPedido_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGerarPedido.Click

        Dim gerPedido As New clsPedidos
        Dim p_NumPedido As Integer = gerPedido.GerarPedido(ViewState("IdProposta"))
        If p_NumPedido > 0 Then
            lblMensagem.Text = "Pedido nº " & p_NumPedido & " gerado com sucesso."
        Else
            lblMensagem.Text = "Houve um erro na geração do pedido. Se o problema persistir entre em contato com o administrador do sistema."
        End If

        plcMensagem.Visible = True
        plcMain.Visible = False

    End Sub

    Private Sub btnAprovarProp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAprovarProp.Click

        If ViewState("IdProposta") > 0 Then

            Dim p_IdOrcamentoAprovado As Integer = Request("rdOrcamento") 'RECUPERA O ID DO ORCAMENTO SELECIONADO

            Dim clsOrc As New clsPropostaOrcamentos
            clsOrc.Load(p_IdOrcamentoAprovado)
            clsOrc.AprovarOrcamento(ViewState("IdProposta"), p_IdOrcamentoAprovado)
            clsOrc = Nothing

            ViewState("IdStatus") = 1 'Proposta Aprovada
            cboIdStatus.SelectedValue = ViewState("IdStatus")
            Deflate()
            Proposta.Update()
            Log_Usuario("APROVAR PROPOSTA", XMWebPage.MODULO.PROPOSTAS)
            Response.Redirect("proposta.aspx?IdProposta=" & CryptographyEncoded(ViewState("IdProposta")))

        End If

    End Sub

    Private Sub btnAddContato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddContato.Click
        Dim contProp As New clsContatoAssociados
        contProp.UpdateContatoProposta(ViewState("IdProposta"), cboIdContato.SelectedValue)
        BindContatosProposta()
    End Sub

    Private Sub btnAddOrcamento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddOrcamento.Click
        Response.Redirect("propostaAdicOrc.aspx?IdProposta=" & CryptographyEncoded(ViewState("IdProposta")))
    End Sub

    Private Sub CarregaCidades(ByVal Estado As String, ByRef vCombo As ComboBox)

        vCombo.Clear()

        Dim Cid As New clsCidades
        With vCombo
            .CssClass = "f8"
            .CssClassValidator = "f8"
            .DataSource = Cid.ListCidades(Estado)
            .DataTextField = "CIDADE"
            .DataValueField = "CIDADE"
            .DataBind()
            Cid = Nothing
        End With

    End Sub

    Private Sub dtgContatos_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgContatos.ItemCommand

        If e.CommandName = "deleteItem" Then
            Dim IdContato As String = e.CommandArgument
            Dim Cont As New clsProposta
            Cont.DeleteItemContato(IdContato)
            BindContatosProposta()
        End If

    End Sub

    Protected Sub dtgPlanos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgPlanos.ItemDataBound

        If Not e.Item.ItemType = ListItemType.Header And Not e.Item.ItemType = ListItemType.Footer Then
            p_Value = p_Value + e.Item.Cells(3).Text
            sender.Columns(4).Visible = e.Item.DataItem("Renovacao") = 1
        ElseIf e.Item.ItemType = ListItemType.Header Then
            p_Value = 0
        End If



    End Sub

    Protected Sub rptIndi_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs)

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim lbl As Label = e.Item.FindControl("lblOrcamentoRS")
            lbl.Text = FormatNumber(p_Value, 2)

        End If

    End Sub

    Private Sub dtgContatos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgContatos.ItemDataBound

        If Not e.Item.ItemType = ListItemType.Header And Not e.Item.ItemType = ListItemType.Footer Then
            p_Contato = e.Item.Cells(4).Text
        End If

    End Sub

    Private Sub dtgAssociados_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgAssociados.ItemCommand

        Dim idAssociado As Integer = 0
        If e.CommandName = "carregaDados" Then
            idAssociado = e.CommandArgument
        End If
    End Sub


    Private Sub ListarOrcamentos()

        Dim PropOrc As New clsPropostaOrcamentos
        rptOrcamentos.DataSource = PropOrc.ListarOrcamentos(ViewState("IdProposta"))
        rptOrcamentos.DataBind()

    End Sub

    Function ListarOrcamentosItem(ByVal vIdOrcamento As Integer) As DataSet

        Dim PropOrc As New clsPropostaOrcamentos
        Dim ds As DataSet = PropOrc.ListPropostaOrcamentoItem(vIdOrcamento)
        Return ds

    End Function

    Private Sub VerificaPropostas(ByVal IdAssociado As Integer)

        Dim msgBox As String = ""
        If Request("IR") = 0 Or Request("IR") Is Nothing Then
            IRP.Value = 0
        Else
            IRP.Value = 1

            Dim Pro As New clsProposta
            Dim retorno As String = Pro.VerificaPropostaExistente(IdAssociado)

            If retorno <> "" Then
                msgBox = "<script language='javascript'>"
                msgBox += "     if (confirm('A última proposta criada para este associado foi a nº " & retorno & "! \nClique em Ok se você realmente deseja criar uma nova proposta como Renovação.')==false)"
                msgBox += "     {"
                msgBox += "         location.href='Propostas.aspx';"
                msgBox += "     }"
                msgBox += "</script>"

                ltrMsgBox.Text = msgBox
            End If
        End If

    End Sub

    Private Sub btnOKMensagem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOKMensagem.Click
        Response.Redirect("proposta.aspx?IdProposta=" & CryptographyEncoded(ViewState("IdProposta")))
    End Sub

    Private Sub btnRenovacao_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRenovacao.Click
        Dim Pro As New clsProposta
        Pro.RenovarProposta(ViewState("IdProposta"))
        ViewState("IdProposta") = Pro.IdProposta
        Response.Redirect("Proposta.aspx?IDProposta=" & CryptographyEncoded(ViewState("IdProposta")))
    End Sub
End Class

Imports ITCOffLine
Imports System.Data

Public Class PropostaAdicOrc
    Inherits XMWebPage

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dtgPlanos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dtgAssociados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents tblAssociadosDet As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblContatos As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblAssociado As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblOrcamento As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblProposta As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblPlanos As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblBotoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Table2 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Table3 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents trAddContato As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trDetalhesPagto As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdImgRenovacao As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tdRenovacao As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tdExpiraOrcamento As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tdPrimeiroVencto As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtRazaoFantasia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodigoAss As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataTermino As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtValor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPlanoEspecifico As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPrazo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCondPagamento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtData_Proposta As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndereco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtComplemento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCep As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCidade As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWebSite As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmailPrincipal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtContatoCad As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefoneContato As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFaxContato As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCelContato As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmailContato As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtavulso As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtValidadeProposta As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtValorRenovacao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtExpiraOrcamento As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPlanoEspecifico As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotal As System.Web.UI.WebControls.Label
    Protected WithEvents lblNumeroProposta As System.Web.UI.WebControls.Label
    Protected WithEvents lblIdAssociado As System.Web.UI.WebControls.Label
    Protected WithEvents lblRazaoSocial As System.Web.UI.WebControls.Label
    Protected WithEvents lblIdProposta As System.Web.UI.WebControls.Label
    Protected WithEvents lblCnpj As System.Web.UI.WebControls.Label
    Protected WithEvents lblIdOrcamento As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents cboIdPlano As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboIdEstado As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboIdVendedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboIdStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboRegistros As ComboBox
    Protected WithEvents cboIdTipoProposta As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboIdPosicao As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAddItem As System.Web.UI.WebControls.Button
    Protected WithEvents btnApagarOrcamento As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnVoltarProposta As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgRenovacao As System.Web.UI.WebControls.Image


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
    Dim CidadesFaturamento As DataSet
    Dim CidadesCobranca As DataSet
    Private p_Value As Double
    Private p_Contato As String

    Private ds As DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            If CheckPermission("Cadastro de Propostas", "INCLUIR ORCAMENTO") = False Then
                Response.Redirect("home.aspx")
            End If

            Dim objAssociado As Object = DeCryptography(Page.Request("IdAssociado"))
            Dim m_IdAssociado As Integer


            Dim objProposta As Object = DeCryptography(Page.Request("IDProposta"))
            Dim m_IdProposta As Integer
            If IsNumeric(objProposta) Then
                m_IdProposta = objProposta
            Else
                m_IdProposta = 0
            End If
            ViewState("IdProposta") = CInt(0 & m_IdProposta)


            Dim objOrcamento As Object = DeCryptography(Page.Request("IdOrcamento"))
            Dim m_IdOrcamento As Integer
            If IsNumeric(objOrcamento) Then
                m_IdOrcamento = objOrcamento
            Else
                m_IdOrcamento = 0
            End If
            ViewState("IdOrcamento") = CInt(0 & m_IdOrcamento)


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
            'cboIdVendedor.Items.Insert(0, New ListItem("Selecione..", "0")) *********** JÁ EXISTE UMA FUNÇÃO NO CONTROLE DE COMBOBOX QUE TRAZ O "SELECIONE..." *************

            Dim Pla As New clsPlanos
            With cboIdPlano
                .CssClass = "f8"
                .DataSource = Pla.ListPlanos(ViewState("IdProposta"), ViewState("IdOrcamento"), 0)
                .DataTextField = "CodigoPlano"
                .DataValueField = "IdPlano"
                .DataBind()
                Pla = Nothing
            End With
            cboIdPlano.Items.Insert(0, New ListItem("Selecione o plano...", "0"))


            With cboIdTipoProposta
                .Items.Insert(0, New ListItem("Selecione..", "0"))
                .Items.Insert(1, New ListItem("ITCnet", "1"))
                .Items.Insert(2, New ListItem("Guia de negócios", "2"))
            End With

            Dim Pos As New clsPosicao
            With cboIdPosicao
                .CssClass = "f8"
                .DataSource = Pos.ListPosicao()
                .DataTextField = "DescricaoPosicao"
                .DataValueField = "IdPosicao"
                .DataBind()
                .Enabled = False
                Pos = Nothing
            End With


            If ViewState("IdOrcamento") <> 0 Then
                BindOrcamentoPlanos()
            Else
                dtgPlanos.Visible = False
                trDetalhesPagto.Visible = False
            End If


            Proposta = New clsProposta
            Proposta.Load(ViewState("IdProposta"))
            ViewState("IdAssociado") = Proposta.IdAssociado

            If Proposta.Renovacao = 1 Then
                tdRenovacao.Visible = True
                tdExpiraOrcamento.Visible = True
                dtgPlanos.Columns(5).Visible = True
            End If

            Inflate()

        Else

            Proposta = New clsProposta

        End If

        btnAddItem.Attributes.Add("onClick", "if(fncValida('dtgPlano')==false)return false;")

        btnApagarOrcamento.Attributes.Add("onClick", "return fncConfirmExc();")

        CamposReadOnly()

    End Sub

    Private Sub BindOrcamentoPlanos()
        p_Value = 0
        Dim Planos As New clsPropostaOrcamentos
        dtgPlanos.DataSource = Planos.ListPropostaOrcamentoItem(ViewState("IdOrcamento"))
        dtgPlanos.DataBind()
        Planos.Load(ViewState("IdOrcamento"))
        lblIdOrcamento.Text = ViewState("IdOrcamento")
        txtExpiraOrcamento.Text = Planos.ExpiraOrcamento
        If p_Value <> 0 Then
            dtgPlanos.Visible = True
            trDetalhesPagto.Visible = True
        End If

        Planos = Nothing
        'If tblDetalhesPlano.Visible Then
        '    'Dim strScript As String = ""
        '    'strScript = "if(document.getElementById('" & txtCondPagamento.ClientID & "').value=='')"
        '    'strScript &= "{alert('Informe corretamente a Condição de Pagamento');return false;}"
        '    'strScript &= "else if(document.getElementById('" & tdImgRenovacao.ClientID & "').visible==True)"
        '    'strScript &= "{if(document.getElementById('" & txtPrimeiroVencto.ClientID & "').value=='' || document.getElementById('" & txtExpiraOrcamento.ClientID & "').value=='')"
        '    'strScript &= "{alert('Informe corretamente a Condição de Pagamento, o Primeiro Vencimento e a Data de Expiração!');return false;}}"
        '    'strScript &= "if(confirm('Tem certeza que deseja gravar estes dados ?')==false) {return false;}"
        '    'btnGravarDet.Attributes.Add("onClick", strScript)
        '    If tdImgRenovacao.Visible = True Then
        '        btnGravarDet.Attributes.Add("onClick", "return fncConfirm(1);")
        '    Else
        '        btnGravarDet.Attributes.Add("onClick", "return fncConfirm(0);")
        '    End If
        'End If
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
            .ValidadeProposta = txtValidadeProposta.Text
        End With
    End Sub

    Private Sub Inflate()
        lblIdProposta.Text = Proposta.IdProposta
        cboIdStatus.SelectedValue = Proposta.IdStatus
        txtData_Proposta.Text = Proposta.DataProposta
        cboIdVendedor.SelectedValue = Proposta.IdVendedor
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
        txtValidadeProposta.Text = Proposta.ValidadeProposta
        'tdImgRenovacao.Visible = Proposta.Renovacao
        cboIdTipoProposta.SelectedValue = Proposta.IdTipoProposta
        cboIdPosicao.SelectedValue = Proposta.IdPosicao

    End Sub

    Private Sub CamposReadOnly()

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
        txtValidadeProposta.ReadOnly = True
        btnApagarOrcamento.Visible = CheckPermission("Cadastro de Propostas", "INCLUIR ORCAMENTO")
        btnAddItem.Visible = CheckPermission("Cadastro de Propostas", "INCLUIR ORCAMENTO")

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
        txtValidadeProposta.Text = ""

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

    Private Sub btnAddItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddItem.Click

        Dim Orcamento As New clsPropostaOrcamentos
        Dim valor As String = "", valorRenovacao As String = ""
        If IsNumeric(txtValor.Text) Then
            valor = FormatNumber(txtValor.Text)
        Else
            valor = 0
        End If
        If IsNumeric(txtValorRenovacao.Text) Then
            valorRenovacao = FormatNumber(txtValorRenovacao.Text)
        Else
            valorRenovacao = 0
        End If
        Orcamento.SalvarPropostaOrcamentoItem(ViewState("IdProposta"), cboIdPlano.SelectedValue, IIf(txtDataInicio.Text = "", Nothing, txtDataInicio.Text), IIf(txtDataTermino.Text = "", Nothing, txtDataTermino.Text), valor, txtPlanoEspecifico.Text, txtPrazo.Text, valorRenovacao, txtCondPagamento.Text, ViewState("IdOrcamento"), ViewState("IdPropostaItem"), txtExpiraOrcamento.Text)
        ViewState("IdOrcamento") = Orcamento.IdOrcamento
        Response.Redirect("PropostaAdicOrc.aspx?idproposta=" & CryptographyEncoded(ViewState("IdProposta")) & "&idOrcamento=" & CryptographyEncoded(ViewState("IdOrcamento")))
        ViewState("IdPropostaItem") = 0

    End Sub


    Private Sub dtgPlanos_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgPlanos.ItemCommand

        If CheckPermission("Cadastro de Propostas", "INCLUIR ORCAMENTO") Then

            If e.CommandName = "deleteItem" Then
                Dim p_IdPropostaItem As String = e.CommandArgument
                Dim Pro As New clsPropostaOrcamentos
                Pro.DeleteItem(p_IdPropostaItem, ViewState("IdOrcamento"))
                BindOrcamentoPlanos()
                If dtgPlanos.Items.Count = 0 Then
                    Response.Redirect("Proposta.aspx?idproposta=" & CryptographyEncoded(ViewState("IdProposta")))
                Else
                    Response.Redirect("PropostaAdicOrc.aspx?idproposta=" & CryptographyEncoded(ViewState("IdProposta")) & "&idOrcamento=" & CryptographyEncoded(ViewState("IdOrcamento")))
                End If

            ElseIf e.CommandName = "editItem" Then
                Dim p_IdPropostaItem As String = e.CommandArgument
                BindEditarPlano(p_IdPropostaItem)
            End If

        End If

    End Sub

    Private Sub BindEditarPlano(ByVal idPropostaItem As Integer)
        ViewState("IdPropostaItem") = idPropostaItem
        Dim Pro As New clsPropostaOrcamentos
        Pro.Load(ViewState("IdOrcamento"), ViewState("IdPropostaItem"))
        cboIdPlano.SelectedValue = Pro.IdPlano
        txtPlanoEspecifico.Text = Pro.PlanoEspecifico
        txtDataInicio.Text = Pro.InicioPlano
        txtDataTermino.Text = Pro.FimPlano
        txtValor.Text = FormatNumber(Pro.Valor, 2)
        txtCondPagamento.Text = Pro.CondicaoPagamento
        txtValorRenovacao.Text = FormatNumber(Pro.ValorRenovacao, 2)
        txtPrazo.Text = Pro.Prazo
        If cboIdPlano.SelectedValue = 101 Or cboIdPlano.SelectedValue = 134 Then
            txtPlanoEspecifico.Enabled = True
            lblPlanoEspecifico.Enabled = True
        Else
            txtPlanoEspecifico.Enabled = False
            lblPlanoEspecifico.Enabled = False
        End If
    End Sub

    Private Sub dtgPlanos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgPlanos.ItemDataBound

        If Not e.Item.ItemType = ListItemType.Header And Not e.Item.ItemType = ListItemType.Footer Then

            p_Value = p_Value + e.Item.Cells(4).Text
            lblTotal.Text = FormatNumber(p_Value, 2)

            Dim btnDel As LinkButton = e.Item.FindControl("btnDeleteItem")
            If Not btnDel Is Nothing Then
                btnDel.Attributes.Add("onclick", "if(confirm('Tem certeza que deseja excluir este plano?')==false)return false")
            End If

        End If

    End Sub

    Private Sub dtgAssociados_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgAssociados.ItemCommand

        Dim idAssociado As Integer = 0
        If e.CommandName = "carregaDados" Then
            idAssociado = e.CommandArgument
        End If
    End Sub

    Private Sub cboIdPlano_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIdPlano.SelectedIndexChanged

        If cboIdPlano.SelectedValue = 101 Or cboIdPlano.SelectedValue = 134 Then
            txtPlanoEspecifico.Enabled = True
            lblPlanoEspecifico.Enabled = True
        Else
            txtPlanoEspecifico.Enabled = False
            lblPlanoEspecifico.Enabled = False
        End If

    End Sub

    Private Sub btnApagarOrcamento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnApagarOrcamento.Click
        Dim PropOrc As New clsPropostaOrcamentos
        PropOrc.IdProposta = ViewState("IdProposta")
        If PropOrc.DeleteOrcamento(ViewState("IdProposta"), ViewState("IdOrcamento")) = True Then
            Log_Usuario("APAGAR ORCAMENTO", XMWebPage.MODULO.PROPOSTAS)
            Response.Redirect("proposta.aspx?idproposta=" & CryptographyEncoded(ViewState("IdProposta")))
        End If
    End Sub

    Private Sub btnVoltarProposta_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltarProposta.Click
        Response.Redirect("proposta.aspx?idproposta=" & CryptographyEncoded(ViewState("IdProposta")))
    End Sub
End Class

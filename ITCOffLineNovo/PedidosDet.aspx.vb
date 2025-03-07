Imports ITCOffLine
Imports System.Data


Public Class PedidosDet

    Inherits XMWebPage

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents tblAssociadosDet As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblCodigo As System.Web.UI.WebControls.Label
    Protected WithEvents txtRazaoSocial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFantasia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndereco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtComplemento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCEP As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCidade As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboIdEstado As ComboBox
    Protected WithEvents cboIdRamo As ComboBox
    Protected WithEvents cboIdContato As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboIdPlano As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtEnderecoCobranca As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtComplementoCobranca As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCEPCobranca As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCidadeCobranca As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboIdEstadoCobranca As ComboBox
    Protected WithEvents txtEnderecoFaturamento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtComplementoFaturamento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCEPFaturamento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCidadeFaturamento As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboIdEstadoFaturamento As ComboBox
    Protected WithEvents txtCNPJ As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInscricaoEstadual As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWebSite As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtContrato As TextBox
    Protected WithEvents Barra As BarraBotoes2
    Protected WithEvents dtgContatos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dtgPlanos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dtgAssociados As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAddContato As System.Web.UI.WebControls.Button
    Protected WithEvents btnImprimir As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents btnImprimirVerso As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents cboRegistros As ComboBox
    Protected WithEvents cboIdAtividade As ComboBox
    Protected WithEvents cboCidadeCobranca As ComboBox
    Protected WithEvents cboCidadeFaturamento As ComboBox
    Protected WithEvents cboCidade As ComboBox
    Protected WithEvents cboIdPosicao As ComboBox
    Protected WithEvents txtRazaoFantasia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodigoAss As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtContato As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmailContato As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCelular As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelEntrega As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFaxEntrega As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelCobranca As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFaxCobranca As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelFaturamento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFaxFaturamento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPedidoRS As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtObservacao As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDataPedido As System.Web.UI.WebControls.Label
    Protected WithEvents lblNumeroPedido As System.Web.UI.WebControls.Label
    Protected WithEvents tblContatos As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblAssociado As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblPlanos As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblPedido As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents btnProcurar As Button
    Protected WithEvents lblPlanoEspecifico As System.Web.UI.WebControls.Label
    Protected WithEvents txtProdutos As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboIdTipoPedido As ComboBox
    Protected WithEvents btnFichaRosa As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents tblServico As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblObservacao As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblVendedor As System.Web.UI.WebControls.Label
    Protected WithEvents lblData As System.Web.UI.WebControls.Label
    Protected WithEvents lblNumPedido As System.Web.UI.WebControls.Label
    Protected WithEvents txtPrimeiroVencto As System.Web.UI.WebControls.TextBox
    Protected WithEvents tblBotoes As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents btnEnviarEmail As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents btnConfirmar As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnCancelar As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnDeleteContato As System.Web.UI.WebControls.ImageButton
    Protected WithEvents cboIdStatus As ComboBox
    Protected WithEvents lblContato As System.Web.UI.WebControls.Label
    Protected WithEvents txtPlanoEspecifico As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDataTermino As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtValor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCondPagamento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPeriodo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAddItem As System.Web.UI.WebControls.Button
    Protected WithEvents lnkLog As System.Web.UI.WebControls.LinkButton
    Protected WithEvents trLog As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trAddContato As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lstLog As System.Web.UI.WebControls.ListBox

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Declara��es"
    Private Associados As clsAssociados
    Private Pedidos As clsPedidos
    Dim Cid As New clsCidades
    Dim Cidades As DataSet
    Dim CidadesFaturamento As DataSet
    Dim CidadesCobranca As DataSet
    Private p_Value As Double
    Private p_Contato As String
    Private ds As DataSet
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            Dim objPedido As Object = DeCryptography(Page.Request("IdPedido"))
            Dim m_IdPedido As Integer
            If IsNumeric(objPedido) Then
                m_IdPedido = objPedido
            Else
                m_IdPedido = 0
            End If
            ViewState("IdPedido") = CInt(0 & m_IdPedido)

            BindEstados()
            BindRegistro()
            BindTipoPedido()
            BindStatus()
            BindPosicao()
            BindPlano()
            BindRamo()


            If CheckPermission("Cadastro de Pedidos", "Atualizar") = False Then
                dtgContatos.Columns(0).Visible = False
                trAddContato.Visible = False
                cboIdPlano.Enabled = False
                btnAddItem.Visible = False
                dtgPlanos.Columns(0).Visible = False
                dtgPlanos.Columns(7).Visible = False
                tblAssociado.Visible = False
                btnImprimir.Visible = False
                btnImprimirVerso.Visible = False
                btnFichaRosa.Visible = False
                btnEnviarEmail.Visible = False
                btnConfirmar.Visible = False
                btnCancelar.Visible = False
            Else
                Barra.AtivarBotoes(IIf(CheckPermission("Cadastro de Pedidos", "Atualizar"), BarraBotoes2.Botoes_Ativos.Atualizar, 0) + BarraBotoes2.Botoes_Ativos.Voltar)
            End If

            Pedidos = New clsPedidos(ViewState("IdPedido"))

            If ViewState("IdPedido") = 0 Then
                Clear()
                If CheckPermission("Cadastro de Pedidos", "Adicionar") = False Then
                    tblPlanos.Visible = False
                    tblContatos.Visible = False
                    lblData.Visible = False
                    lblNumPedido.Visible = False
                    lblDataPedido.Visible = False
                    lblNumeroPedido.Visible = False
                    tblPedido.Visible = False
                    tblObservacao.Visible = False
                    dtgPlanos.Visible = False
                    btnImprimir.Visible = False
                    btnImprimirVerso.Visible = False
                    btnFichaRosa.Visible = False
                    btnEnviarEmail.Visible = False
                    btnConfirmar.Visible = False
                    btnCancelar.Visible = False
                Else
                    tblAssociado.Visible = False
                    btnImprimir.Visible = True
                    btnImprimirVerso.Visible = True
                    btnFichaRosa.Visible = True
                    btnEnviarEmail.Visible = True
                    btnConfirmar.Visible = True
                    btnCancelar.Visible = True
                    btnConfirmar.Attributes.Add("onClick", "return fncConfirm(2);")
                    btnCancelar.Attributes.Add("onClick", "return fncConfirm(4);")
                    btnAddItem.Attributes.Add("onClick", "if(fncValida('dtgPlano')==false)return false;")
                End If

                End If
                Inflate()
                CamposReadOnly()
                BindContatos()
            Else

                Pedidos = New clsPedidos(ViewState("IdPedido"))
                BindLogs()
            End If

        '   btnConfirmar.Attributes.Add("onClick", "return fncConfirm(2);")
        '   btnCancelar.Attributes.Add("onClick", "return fncConfirm(4);")
        '   btnAddItem.Attributes.Add("onClick", "if(fncValida('dtgPlano')==false)return false;")

    End Sub

#Region "M�todos"

#Region "Bind Controles"

    Private Sub BindEstados()
        Dim Est As New clsEstados
        With cboIdEstado
            .CssClass = "f8"
            .CssClassValidator = "f8"
            .DataSource = Est.ListEstados
            .DataTextField = "UF"
            .DataValueField = "IdEstado"
            .DataBind()
        End With

        With cboIdEstadoCobranca
            .CssClass = "f8"
            .CssClassValidator = "f8"
            .DataSource = Est.ListEstados
            .DataTextField = "UF"
            .DataValueField = "IdEstado"
            .DataBind()
        End With

        With cboIdEstadoFaturamento
            .CssClass = "f8"
            .CssClassValidator = "f8"
            .DataSource = Est.ListEstados
            .DataTextField = "UF"
            .DataValueField = "IdEstado"
            .DataBind()
        End With

        Est = Nothing
    End Sub

    Private Sub BindRegistro()
        With cboRegistros
            .AddItem("0", "TODOS OS RESULTADOS")
            .AddItem("10", "10 RESULTADOS")
            .AddItem("25", "25 RESULTADOS")
            .AddItem("50", "50 RESULTADOS")
            .AddItem("100", "100 RESULTADOS")
            .Value = 10
        End With
    End Sub

    Private Sub BindTipoPedido()
        With cboIdTipoPedido
            .AddItem("0", "Selecione..")
            .AddItem("1", "ITCnet")
            .AddItem("2", "Guia de neg�cios")
            '.Value = 0
        End With
    End Sub

    Private Sub BindStatus()
        With cboIdStatus
            .AddItem("1", "Em Andamento")
            .AddItem("2", "Atual")
            .AddItem("3", "Antigo")
            .AddItem("4", "Cancelado")
            .AddItem("0", "N�o Identificado")
            .Value = 1
        End With
    End Sub

    Private Sub BindPosicao()
        Dim Pos As New clsPosicao
        With cboIdPosicao
            .CssClass = "f8"
            .CssClassValidator = "f8"
            .DataSource = Pos.ListPosicao()
            .DataTextField = "DescricaoPosicao"
            .DataValueField = "IdPosicao"
            .DataBind()
            Pos = Nothing
        End With
    End Sub

    Private Sub BindContatos()
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
    End Sub

    Private Sub BindPlano()
        Dim Pla As New clsPlanos
        With cboIdPlano
            .CssClass = "f8"
            .DataSource = Pla.ListPlanos(0, 0, (ViewState("IdPedido")))
            .DataTextField = "CodigoPlano"
            .DataValueField = "IdPlano"
            .DataBind()
            Pla = Nothing
        End With
        cboIdPlano.Items.Insert(0, New ListItem("Selecione o plano...", "0"))
    End Sub

    Private Sub BindRamo()
        Dim At As New clsRamosAtividades
        With cboIdRamo
            .AutoPostBack = True
            .CssClass = "f8"
            .CssClassValidator = "f8"
            .DataSource = At.ListRamos
            .DataTextField = "Descricaoramo"
            .DataValueField = "Idramo"
            .DataBind()
        End With
        At = Nothing
    End Sub

    Private Sub BindAtividades(ByVal IdRamo As Integer)
        If IdRamo > 0 Then
            Dim Ram As New clsRamosAtividades
            With cboIdAtividade
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Ram.ListAtividades(IdRamo)
                .DataTextField = "DescricaoAtividadeRamo"
                .DataValueField = "IdAtividadeRamo"
                .DataBind()
            End With
            Ram = Nothing
        Else
            cboIdAtividade.Clear()
            cboIdAtividade.AddItem(0, "Selecione o Ramo...   ")
        End If
    End Sub

    Private Sub BindEditarPlano(ByVal IdPedidoItem As Integer)
        ViewState("IdPedidoItem") = IdPedidoItem
        Dim ItemPed As New clsPedidoPlanos
        ItemPed.Load(ViewState("IdPedido"), ViewState("IdPedidoItem"))
        cboIdPlano.SelectedValue = ItemPed.IdPlano
        txtDataInicio.Text = ItemPed.DataInicio
        txtDataTermino.Text = ItemPed.DataTermino
        txtValor.Text = FormatNumber(ItemPed.Valor, 2)
        txtCondPagamento.Text = ItemPed.CondicaoPagamento
        txtPeriodo.Text = ItemPed.Periodo
        txtPlanoEspecifico.Text = ItemPed.PlanoEspecifico
        If cboIdPlano.SelectedValue = 101 Or cboIdPlano.SelectedValue = 134 Then
            txtPlanoEspecifico.Enabled = True
            lblPlanoEspecifico.Enabled = True
        Else
            txtPlanoEspecifico.Enabled = False
            lblPlanoEspecifico.Enabled = False
        End If
    End Sub

    Private Sub BindAssociados()
        Dim p_Codigo As Integer = IIf(IsNumeric(txtCodigoAss.Text), txtCodigoAss.Text, 0)
        Dim Associados As New clsAssociados
        ds = Associados.List(p_Codigo, txtRazaoFantasia.Text, "", cboRegistros.Value)
        dtgAssociados.DataSource = ds
        dtgAssociados.DataBind()
    End Sub

    Private Sub BindPlanosPedidos()
        Dim Planos As New clsPedidoPlanos
        dtgPlanos.DataSource = Planos.ListPedidoItem(ViewState("IdPedido"))
        dtgPlanos.DataBind()
        Planos = Nothing
    End Sub

    Private Sub BindLogs()
        lstLog.DataSource = Pedidos.ListLog(ViewState("IdPedido"))
        lstLog.DataBind()
        If lstLog.Items.Count = 0 Then
            lstLog.Items.Add("Este Pedido n�o sofreu altera��es!")
        End If
    End Sub

    Private Sub BindContatosPedido()
        Dim clsPedidos As New clsContatoAssociados(Me)
        dtgContatos.DataSource = clsPedidos.ListContatosPedido(ViewState("IdPedido"))
        dtgContatos.DataBind()
        clsPedidos = Nothing
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
#End Region

    Private Sub Deflate()
        With Pedidos
            .Codigo = lblCodigo.Text
            .Fantasia = txtFantasia.Text
            .RazaoSocial = txtRazaoSocial.Text
            .CNPJ = txtCNPJ.Text
            .InscricaoEstadual = txtInscricaoEstadual.Text
            .IdRamo = cboIdRamo.Value
            .IdAtividade = cboIdAtividade.Value
            .WebSite = txtWebSite.Text
            .EMail = txtEmail.Text
            .PrimeiroContrato = txtContrato.Text
            .Telefone = txtTelefone.Text
            .Fax = txtFax.Text
            .Contato = txtContato.Text
            .Fone = txtFone.Text
            .EmailContato = txtEmailContato.Text
            .Celular = txtCelular.Text

            .Endereco = txtEndereco.Text
            .Complemento = txtComplemento.Text
            .CEP = txtCEP.Text
            .Estado = cboIdEstado.Value
            .Cidade = cboCidade.ValueString
            .TelefoneEntrega = txtTelEntrega.Text
            .FaxEntrega = txtFaxEntrega.Text

            .EnderecoCobranca = txtEnderecoCobranca.Text
            .ComplementoCobranca = txtComplementoCobranca.Text
            .CEPCobranca = txtCEPCobranca.Text
            .EstadoCobranca = cboIdEstadoCobranca.Value
            .CidadeCobranca = cboCidadeCobranca.ValueString
            .TelefoneCobranca = txtTelCobranca.Text
            .FaxCobranca = txtFaxCobranca.Text

            .EnderecoFaturamento = txtEnderecoFaturamento.Text
            .ComplementoFaturamento = txtComplementoFaturamento.Text
            .CEPFaturamento = txtCEPFaturamento.Text
            .CidadeFaturamento = cboCidadeFaturamento.ValueString
            .EstadoFaturamento = cboIdEstadoFaturamento.Value
            .TelefoneFaturamento = txtTelFaturamento.Text
            .FaxFaturamento = txtFaxFaturamento.Text

            .IdPosicao = cboIdPosicao.Value
            .PrimeiroVencimento = txtPrimeiroVencto.Text
            .PedidoRS = 0 & txtPedidoRS.Text
            .Observacoes = txtObservacao.Text

            If ViewState("IdPedido") <> 0 Then
                .IdPedido = ViewState("IdPedido")
                .NumeroPedido = lblNumeroPedido.Text
            End If

            .IdTipoPedido = cboIdTipoPedido.Value
            .Produtos = txtProdutos.Text
            .IdStatus = cboIdStatus.Value
        End With
    End Sub

    Private Sub Inflate()

        With Pedidos
            lblCodigo.Text = .Codigo
            ViewState("IdAssociado") = .Codigo
            txtFantasia.Text = .Fantasia
            txtRazaoSocial.Text = .RazaoSocial
            txtCNPJ.Text = .CNPJ
            txtInscricaoEstadual.Text = .InscricaoEstadual
            txtWebSite.Text = .WebSite
            txtEmail.Text = .EMail
            txtTelefone.Text = .Telefone
            txtFax.Text = .Fax
            txtContato.Text = .Contato
            txtFone.Text = .Fone
            txtEmailContato.Text = .EmailContato
            txtCelular.Text = .Celular

            txtEndereco.Text = .Endereco
            txtComplemento.Text = .Complemento
            txtCEP.Text = .CEP
            txtTelEntrega.Text = .TelefoneEntrega
            txtFaxEntrega.Text = .FaxEntrega

            txtEnderecoCobranca.Text = .EnderecoCobranca
            txtComplementoCobranca.Text = .ComplementoCobranca
            txtCEPCobranca.Text = .CEPCobranca
            txtTelCobranca.Text = .TelefoneCobranca
            txtFaxCobranca.Text = .FaxCobranca

            txtEnderecoFaturamento.Text = .EnderecoFaturamento
            txtComplementoFaturamento.Text = .ComplementoFaturamento
            txtCEPFaturamento.Text = .CEPFaturamento
            txtTelFaturamento.Text = .TelefoneFaturamento
            txtFaxFaturamento.Text = .FaxFaturamento

            cboIdPosicao.Value = .IdPosicao
            If .PrimeiroVencimento <> "01/01/1900" Then
                txtPrimeiroVencto.Text = .PrimeiroVencimento
            End If
            txtObservacao.Text = .Observacoes
            lblVendedor.Text = .Vendedor
            lblDataPedido.Text = .DataPedido
            lblNumeroPedido.Text = .NumeroPedido

            cboIdRamo.Value = .IdRamo
            BindAtividades(cboIdRamo.Value)
            cboIdAtividade.Value = .IdAtividade

            cboIdEstadoFaturamento.Value = .EstadoFaturamento
            cboIdEstadoCobranca.Value = .EstadoCobranca
            cboIdEstado.Value = .Estado
            txtContrato.Text = .PrimeiroContrato
            cboIdTipoPedido.Value = .IdTipoPedido
            txtProdutos.Text = .Produtos
            cboIdStatus.Value = .IdStatus
            ViewState("IdStatus") = .IdStatus

            BindContatosPedido()
            BindPlanosPedidos()

            If .Codigo > 0 Then

                CarregaCidades(cboIdEstadoFaturamento.Text, cboCidadeFaturamento)
                CarregaCidades(cboIdEstadoCobranca.Text, cboCidadeCobranca)
                CarregaCidades(cboIdEstado.Text, cboCidade)

                cboCidade.ValueString = .Cidade
                cboCidadeFaturamento.ValueString = .CidadeFaturamento
                cboCidadeCobranca.ValueString = .CidadeCobranca

            End If
        End With

        'Barra.AtivarBotoes(IIf(CheckPermission("Cadastro de Pedidos", "Atualizar"), BarraBotoes2.Botoes_Ativos.Atualizar, 0) + IIf(CheckPermission("Cadastro de Pedidos", "Excluir"), BarraBotoes2.Botoes_Ativos.Excluir, 0) + BarraBotoes2.Botoes_Ativos.Voltar)

    End Sub

    Private Sub CamposReadOnly()

        'SE O PEDIDO N�O EXISTIR OU SE O STATUS FOR DIFERENTE DE "EM ANDAMENTO" OS CAMPOS N�O PODERAM SOFRER ALTERA��ES
        If ViewState("IdPedido") = 0 Or ViewState("IdStatus") <> 1 Then

            txtFantasia.ReadOnly = True
            txtCNPJ.ReadOnly = True
            txtRazaoSocial.ReadOnly = True
            txtInscricaoEstadual.ReadOnly = True
            txtContrato.ReadOnly = True
            cboIdRamo.Enabled = False
            cboIdAtividade.Enabled = False
            txtWebSite.ReadOnly = True
            txtEmail.ReadOnly = True
            txtEndereco.ReadOnly = True
            txtComplemento.ReadOnly = True
            txtCEP.ReadOnly = True
            cboIdEstado.Enabled = False
            cboCidade.Enabled = False
            txtEnderecoCobranca.ReadOnly = True
            txtComplementoCobranca.ReadOnly = True
            txtCEPCobranca.ReadOnly = True
            cboIdEstadoCobranca.Enabled = False
            cboCidadeCobranca.Enabled = False
            txtEnderecoFaturamento.ReadOnly = True
            txtComplementoFaturamento.ReadOnly = True
            txtCEPFaturamento.ReadOnly = True
            cboIdEstadoFaturamento.Enabled = False
            cboCidadeFaturamento.Enabled = False

            'SE O STATUS DO PEDIDO FOR DIFERENTE DE "EM ANDAMENTO" O PEDIDO N�O PODER� SOFRER ALTERA��ES
            If ViewState("IdStatus") <> 1 And ViewState("IdStatus") <> Nothing Then

                cboIdTipoPedido.Enabled = False
                txtTelefone.ReadOnly = True
                txtFax.ReadOnly = True
                txtContato.ReadOnly = True
                txtFone.ReadOnly = True
                txtEmailContato.ReadOnly = True
                txtCelular.ReadOnly = True
                txtTelEntrega.ReadOnly = True
                txtFaxEntrega.ReadOnly = True
                txtTelCobranca.ReadOnly = True
                txtFaxCobranca.ReadOnly = True
                txtTelFaturamento.ReadOnly = True
                txtFaxFaturamento.ReadOnly = True
                txtObservacao.ReadOnly = True
                txtProdutos.ReadOnly = True
                txtPedidoRS.ReadOnly = True
                Barra.InativarBotoes(BarraBotoes2.Botoes_Ativos.Atualizar)
                Barra.InativarBotoes(BarraBotoes2.Botoes_Ativos.Excluir)
                dtgContatos.Columns(0).Visible = False
                cboIdContato.Enabled = False
                btnAddContato.Enabled = False
                dtgPlanos.Columns(0).Visible = False
                dtgPlanos.Columns(7).Visible = False
                cboIdPlano.Enabled = False
                btnAddItem.Enabled = False
                btnConfirmar.Visible = False

                'SE O PEDIDO ESTIVER CANCELADO, S� MOSTRA O BOT�O VOLTAR
                If ViewState("IdStatus") = 4 Then 'Pedido Cancelado
                    btnConfirmar.Visible = False
                    btnCancelar.Visible = False
                    btnImprimir.Visible = False
                    btnImprimirVerso.Visible = False
                    btnFichaRosa.Visible = False
                    btnEnviarEmail.Visible = False
                    Barra.InativarBotoes(BarraBotoes2.Botoes_Ativos.Incluir)
                End If

            End If

        Else

            'SE O STATUS DO PEDIDO FOR "EM ANDAMENTO" OS CAMPOS PODEM SOFRER ALTERA��ES
            cboIdTipoPedido.Enabled = True
            txtFantasia.ReadOnly = False
            txtCNPJ.ReadOnly = False
            txtRazaoSocial.ReadOnly = False
            txtInscricaoEstadual.ReadOnly = False
            txtContrato.ReadOnly = False
            cboIdRamo.Enabled = True
            cboIdAtividade.Enabled = True
            txtWebSite.ReadOnly = False
            txtEmail.ReadOnly = False
            txtEndereco.ReadOnly = False
            txtComplemento.ReadOnly = False
            txtCEP.ReadOnly = False
            cboIdEstado.Enabled = True
            cboCidade.Enabled = True
            txtEnderecoCobranca.ReadOnly = False
            txtComplementoCobranca.ReadOnly = False
            txtCEPCobranca.ReadOnly = False
            cboIdEstadoCobranca.Enabled = True
            cboCidadeCobranca.Enabled = True
            txtEnderecoFaturamento.ReadOnly = False
            txtComplementoFaturamento.ReadOnly = False
            txtCEPFaturamento.ReadOnly = False
            cboIdEstadoFaturamento.Enabled = True
            cboCidadeFaturamento.Enabled = True

        End If

    End Sub

    Private Sub Clear()

        ViewState("IdPedido") = 0
        lblCodigo.Text = ""
        txtFantasia.Text = ""
        txtCNPJ.Text = ""
        txtInscricaoEstadual.Text = ""
        txtWebSite.Text = ""
        txtEmail.Text = ""
        txtContrato.Text = ""
        txtTelefone.Text = ""
        txtFax.Text = ""
        txtContato.Text = ""
        txtFone.Text = ""
        txtEmailContato.Text = ""
        txtCelular.Text = ""
        txtEndereco.Text = ""
        txtComplemento.Text = ""
        txtCEP.Text = ""
        txtTelEntrega.Text = ""
        txtFaxEntrega.Text = ""
        txtEnderecoCobranca.Text = ""
        txtComplementoCobranca.Text = ""
        txtCEPCobranca.Text = ""
        txtTelCobranca.Text = ""
        txtFaxCobranca.Text = ""
        txtEnderecoFaturamento.Text = ""
        txtComplementoFaturamento.Text = ""
        txtCEPFaturamento.Text = ""
        txtTelFaturamento.Text = ""
        txtFaxFaturamento.Text = ""
        txtPrimeiroVencto.Text = ""
        txtPedidoRS.Text = ""
        txtObservacao.Text = ""
        txtRazaoSocial.Text = ""
        lblNumeroPedido.Text = ""
        cboIdTipoPedido.Value = 0
        txtProdutos.Text = ""
        CamposReadOnly()

    End Sub

#Region "Eventos de Controles"

    '****************
    'DATAGRID PLANOS
    Private Sub dtgPlanos_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgPlanos.ItemCommand

        If e.CommandName = "deleteItem" Then
            Dim p_IdPedidoItem As String = e.CommandArgument
            Dim ItemPed As New clsPedidoPlanos
            ItemPed.DeleteItem(p_IdPedidoItem, Usuario.IDUsuario)
            BindPlanosPedidos()
        ElseIf e.CommandName = "editItem" Then
            Dim p_IdPedidoItem As String = e.CommandArgument
            BindEditarPlano(p_IdPedidoItem)
        End If

    End Sub

    Private Sub dtgPlanos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgPlanos.ItemDataBound

        If Not e.Item.ItemType = ListItemType.Header And Not e.Item.ItemType = ListItemType.Footer Then
            p_Value = p_Value + e.Item.Cells(4).Text
            txtPedidoRS.Text = FormatNumber(p_Value, 2)
        End If

    End Sub

    '*************
    'COMBO PLANOS
    Private Sub cboIdPlano_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIdPlano.SelectedIndexChanged

        If cboIdPlano.SelectedValue = 101 Or cboIdPlano.SelectedValue = 134 Then
            txtPlanoEspecifico.Enabled = True
            lblPlanoEspecifico.Enabled = True
        Else
            txtPlanoEspecifico.Enabled = False
            lblPlanoEspecifico.Enabled = False
        End If

    End Sub

    '******************
    'DATAGRID CONTATOS
    Private Sub dtgContatos_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgContatos.ItemCommand

        If e.CommandName = "deleteItem" Then
            Dim IdContato As String = e.CommandArgument
            Dim Cont As New clsPedidos
            Cont.DeleteItemContato(IdContato, Usuario.IDUsuario)
            BindContatosPedido()
        End If

    End Sub

    '*******************
    'BOT�O GRAVAR PLANO
    Private Sub btnAddItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddItem.Click

        Dim ItemPed As New clsPedidoPlanos
        ItemPed.Update(ViewState("IdPedido"), cboIdPlano.SelectedValue, IIf(txtDataInicio.Text = "", Nothing, txtDataInicio.Text), IIf(txtDataTermino.Text = "", Nothing, txtDataTermino.Text), txtValor.Text, txtPlanoEspecifico.Text, txtPeriodo.Text, txtCondPagamento.Text, Usuario.IDUsuario, ViewState("IdPedidoItem"))
        ViewState("IdPedido") = ItemPed.IdPedido
        'Response.Redirect("PropostaAdicOrc.aspx?idproposta=" & CryptographyEncoded(ViewState("IdProposta")) & "&idOrcamento=" & CryptographyEncoded(ViewState("IdOrcamento")))
        ViewState("IdPedidoItem") = 0
        BindPlanosPedidos()

        cboIdPlano.SelectedValue = 0
        txtPlanoEspecifico.Text = ""
        txtDataInicio.Text = ""
        txtDataTermino.Text = ""
        txtValor.Text = ""
        txtCondPagamento.Text = ""
        txtPeriodo.Text = ""
    End Sub

    '**************
    'BOT�O PROCURAR
    Private Sub btnProcurar_Click(sender As Object, e As System.EventArgs) Handles btnProcurar.Click
        tblPedido.Visible = False
        tblObservacao.Visible = False
        BindAssociados()
    End Sub

    '*******************
    'DATAGRID ASSOCIADOS
    Public Sub doPaging(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        dtgAssociados.CurrentPageIndex = e.NewPageIndex
        BindAssociados()
        Associados = Nothing
    End Sub

    '**********
    'COMBO RAMO
    Private Sub cboIdRamo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIdRamo.SelectedIndexChanged
        BindAtividades(cboIdRamo.Value)
    End Sub

    '**************
    'COMBO ESTADOS
    Private Sub cboIdEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIdEstado.SelectedIndexChanged
        CarregaCidades(cboIdEstado.Text, cboCidade)
    End Sub

    Private Sub cboIdEstadoCobranca_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIdEstadoCobranca.SelectedIndexChanged
        CarregaCidades(cboIdEstadoCobranca.Text, cboCidadeCobranca)
    End Sub

    Private Sub cboIdEstadoFaturamento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIdEstadoFaturamento.SelectedIndexChanged
        CarregaCidades(cboIdEstadoFaturamento.Text, cboCidadeFaturamento)
    End Sub

    '***************
    'BOT�O CONFIRMAR
    Private Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnConfirmar.Click

        If ViewState("IdPedido") > 0 Then
            ViewState("IdStatus") = 2 'Pedido Atual
            cboIdStatus.Value = ViewState("IdStatus")
            Deflate()
            Pedidos.Update(Usuario.IDUsuario)
            Log_Usuario("CONFIRMAR PEDIDO", XMWebPage.MODULO.PEDIDOS)
            CamposReadOnly()
        End If

    End Sub

    '***************
    'BOT�O CANCELAR
    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click

        If ViewState("IdPedido") > 0 Then
            ViewState("IdStatus") = 4 'Pedido Cancelado
            cboIdStatus.Value = ViewState("IdStatus")
            Deflate()
            Pedidos.Update(Usuario.IDUsuario)
            Log_Usuario("CANCELAR PEDIDO", XMWebPage.MODULO.PEDIDOS)
            CamposReadOnly()
        End If

    End Sub

    '***************
    'BARRA DE BOT�ES
    Private Sub BarraBotoes_Atualizar() Handles Barra.Gravar
        Deflate()
        Pedidos.Update(Usuario.IDUsuario)
        Log_Usuario("GRAVAR PEDIDO", XMWebPage.MODULO.PEDIDOS)
        Gravado("pedidosdet.aspx?idpedido=" & CryptographyEncoded(Pedidos.IdPedido))
    End Sub

    Private Sub BarraBotoes_Incluir() Handles Barra.Incluir
        Clear()
        lblData.Visible = False
        lblNumPedido.Visible = False
        lblDataPedido.Visible = False
        lblNumeroPedido.Visible = False
        tblPedido.Visible = False
        tblObservacao.Visible = False
        tblContatos.Visible = False
        tblPlanos.Visible = False
        tblAssociado.Visible = True
        btnImprimir.Visible = False
        btnImprimirVerso.Visible = False
        btnFichaRosa.Visible = False
        btnEnviarEmail.Visible = False
        btnConfirmar.Visible = False
        btnCancelar.Visible = False
        cboIdStatus.Value = 1 'Pedido em Andamento
        Barra.AtivarBotoes(BarraBotoes2.Botoes_Ativos.Voltar)
    End Sub

    Private Sub BarraBotoes_Voltar() Handles Barra.Voltar
        Response.Redirect("pedidos.aspx")
    End Sub

    Private Sub BarraBotoes_Excluir() Handles Barra.Excluir
        If Pedidos.Delete(ViewState("IdPedido")) = True Then
            Log_Usuario("APAGAR PEDIDO", XMWebPage.MODULO.PEDIDOS)
            Response.Redirect("pedidos.aspx")
        End If
    End Sub

    '***********************
    'BOT�O ADICIONAR CONTATO
    Private Sub btnAddContato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddContato.Click
        Dim contProp As New clsContatoAssociados
        contProp.UpdateContatoPedido(ViewState("IdPedido"), cboIdContato.SelectedValue, Usuario.IDUsuario)
        BindContatosPedido()
    End Sub

    '**************
    'LINKBUTTON LOG
    Private Sub lnkLog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLog.Click
        BindLogs()
        trLog.Visible = True
    End Sub

#End Region

#End Region
End Class

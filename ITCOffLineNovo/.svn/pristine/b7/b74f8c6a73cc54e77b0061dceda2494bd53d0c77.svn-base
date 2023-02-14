Imports ITCOffLine
Imports System.Data

'************************************************************
'Classe gerada por XM .NET Class Creator - 15/1/2003 11:47:40
'************************************************************

Public Class ObrasDet

    Inherits XMWebPage

    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents tblObrasDet As System.Web.UI.WebControls.Table
    Protected WithEvents lblCodigo As System.Web.UI.WebControls.Label
    Protected WithEvents txtCodigoAntigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPublicacao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNrDaRevisao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtProjeto As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtValor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAreaConstruida As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCapacidadeDeProducao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMateriaPrima As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndereco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtComplemento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCEP As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboEstado As ComboBox
    Protected WithEvents cboPesquisadores As ComboBox
    Protected WithEvents txtInicio As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTermino As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboEstagio As ComboBox
    Protected WithEvents cboIdTipoCotacao As ComboBox
    Protected WithEvents cboIDFase As ComboBox
    Protected WithEvents txtDescProj1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWebSite As System.Web.UI.WebControls.TextBox
    Protected WithEvents Barra As BarraBotoes2
    Protected WithEvents cboTipo As ComboBox
    Protected WithEvents cboIdSubTipo As ComboBox
    Protected WithEvents dtgEmpresasParticipantes As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dtgContatos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAdicionarContato As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnAdicionarEmpresa As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Comparevalidator2 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents Requiredfieldvalidator7 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Comparevalidator3 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents Requiredfieldvalidator8 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Comparevalidator4 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Comparevalidator1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents re As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents comp As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents Requiredfieldvalidator9 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Comparevalidator5 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents Requiredfieldvalidator10 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Comparevalidator6 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents txtInicioTermino As System.Web.UI.WebControls.TextBox
    Protected WithEvents CustomValidator1 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents lblMensagem As System.Web.UI.WebControls.Label
    Protected WithEvents btnVersoes As Button
    Private Obras As clsObras
    Private strMensagem As String = "CADASTRO INCOMPLETO - "
    Private blnEmpresas, blnContatos As Boolean
    Protected WithEvents txtVazio As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkDemo As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cboStatus As ComboBox
    Protected WithEvents cboVendedor As ComboBox
    Protected WithEvents txtDataCadastro As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblvendedor As System.Web.UI.WebControls.Label
    Protected WithEvents cboCidade As ComboBox
    Protected WithEvents txtValorDolar As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescEdificios As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescCasas As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescCond As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescPavim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescApart As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescDormit As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescSuites As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescBanh As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescLavabo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescSala As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescCopa As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescAreaServ As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescDepend As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescOutros As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkSalaoFestas As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtLazerOutros As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInfoAdicTotalunid As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInfoAdicAreaUtil As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInfoAdicAreaTerreno As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInfoAdicElevador As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInfoAdicVagasApart As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInfoAdicCoberturas As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInfoAdicArCond As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInfoAdicAquecimento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInfoAdicFundacoes As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInfoAdicEstrutura As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInfoAdicAcabamento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInfoAdicFachada As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblAgradece As System.Web.UI.WebControls.Label
    Protected WithEvents txtFoto As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMapa As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkSalaoJogos As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkPiscina As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkSauna As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkChurrasqueira As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkQuadra As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkPlayground As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkSpa As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkFitness As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkGourmet As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkBrinquedoteca As System.Web.UI.WebControls.CheckBox

    Private blnInsertObra As Boolean = False

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            cboCidade.EnableValidation = False

            Dim Cid As New clsCidades
            With cboCidade
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Cid.ListCidades("")
                .DataTextField = "CIDADE"
                .DataValueField = "CIDADE"
                .DataBind()
                Cid = Nothing
            End With

            Dim Estad As New clsEstados
            With cboEstado
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Estad.ListEstados
                .DataTextField = "UF"
                .DataValueField = "IdEstado"
                .DataBind()
            End With
            Estad = Nothing

            Dim Vend As New clsUsuario
            With cboVendedor
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Vend.ListUsuariosVenderores(Me.Usuario.IdEmpresa)
                .DataTextField = "USU_USUARIO_CHR"
                .DataValueField = "USU_USUARIO_INT_PK"
                .DataBind()
                Vend = Nothing
            End With

            Dim Fas As New clsFases
            With cboIDFase
                .AutoPostBack = True
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Fas.ListFases
                .DataTextField = "DESCRICAOFASE"
                .DataValueField = "IDFASE"
                .DataBind()
            End With
            Fas = Nothing

            Dim Pesq As New clsPesquisadores
            With cboPesquisadores
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Pesq.List(0)
                .DataTextField = "SIGLAPESQUISADOR"
                .DataValueField = "IDPESQUISADOR"
                .DataBind()
            End With

            With cboStatus
                .EnableValidation = False
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .AddItem(0, "INATIVO")
                .AddItem(1, "ATIVO")
                .AddItem(2, "PENDENTE")
            End With

            With cboIdTipoCotacao
                .EnableValidation = False
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .AddItem(1, "Cotação do dólar a R$")
                .AddItem(2, "O valor do investimento foi estimado pela ITC com dólar cotado a R$")
                .AddItem(3, "A área construída e o valor do investimento foram estimados pela ITC com dólar cotado a R$")
            End With

            Dim Tip As New clsTipos
            With cboTipo
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Tip.List
                .DataTextField = "DescricaoTipo"
                .DataValueField = "IDTipo"
                .DataBind()
                Tip = Nothing
            End With

            With cboIdSubTipo
                .EnableValidation = False
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .AddItem(1, "INDUSTRIAL")
                .AddItem(2, "COMERCIAL")
                .AddItem(3, "RESIDENCIAL")
            End With

            Dim objObra As Object = DeCryptography(Page.Request("Codigo"))
            Dim m_IdObra As Integer
            Dim objVersao As Object = DeCryptography(Page.Request("Vers"))
            Dim m_IdVersao As Integer

            If IsNumeric(objObra) Then
                m_IdObra = objObra
            Else
                m_IdObra = 0
            End If

            ViewState("Codigo") = CInt(0 & m_IdObra)
            Obras = New clsObras(ViewState("Codigo"), 0)
            Inflate()


            If IsNumeric(objVersao) Then

                m_IdVersao = objVersao

                ViewState("Versao") = CInt(0 & m_IdVersao)
                Obras = New clsObras(ViewState("Codigo"), ViewState("Versao"))

                Inflate()

            Else
                m_IdVersao = 0
            End If



        Else
            Obras = New clsObras()

        End If

        If ViewState("Codigo") = 0 Then
            btnAdicionarContato.Visible = False
            btnAdicionarEmpresa.Visible = False
            txtDataCadastro.Enabled = True
            cboCidade.Enabled = False
        Else
            btnAdicionarContato.Visible = True
            btnAdicionarEmpresa.Visible = True
            txtDataCadastro.Enabled = False
            cboCidade.Enabled = True
        End If
    End Sub


    Private Sub Deflate()
        With Obras

            .Codigo = lblCodigo.Text
            .CodigoAntigo = txtCodigoAntigo.Text
            If .Codigo = 0 Then
                If .ExisteCodigoObra Then
                    blnInsertObra = False
                    Exit Sub
                End If
            End If

            blnInsertObra = True

            .Pesquisador = cboPesquisadores.Value
            .Publicacao = txtPublicacao.Text
            .NrDaRevisao = txtNrDaRevisao.Text
            .Projeto = txtProjeto.Text

            'txtValor.Text = txtValor.Text.Replace(".", "")
            .Valor = txtValor.Text
            'If InStr(txtValor.Text, ",", CompareMethod.Text) > 0 Then
            '    .Valor = txtValor.Text.Substring(0, InStr(txtValor.Text, ",", CompareMethod.Text) - 1)
            'Else
            '    .Valor = txtValor.Text
            'End If

            .AreaConstruida = txtAreaConstruida.Text
            .CapacidadeDeProducao = txtCapacidadeDeProducao.Text
            .MateriaPrima = txtMateriaPrima.Text
            .Endereco = txtEndereco.Text
            .Complemento = txtComplemento.Text
            .CEP = txtCEP.Text
            .Cidade = cboCidade.ValueString
            .Estado = cboEstado.Value
            .Inicio = txtInicio.Text
            .Termino = txtTermino.Text
            .EstagioAtual = cboEstagio.Value
            .IDFase = cboIDFase.Value
            .IdTipo = cboTipo.Value
            .DescProj1 = txtDescProj1.Text
            .DataCadastro = txtDataCadastro.Text
            .InicioTermino = txtInicioTermino.Text
            .Demo = chkDemo.Checked
            .Ativo = cboStatus.Value

            .Vendedor = cboVendedor.Value

            .IdSubTipo = cboIdSubTipo.Value
            '.EstagioDetalhes
            .DescResidEdificio = txtDescEdificios.Text
            .DescResidResidenciais = txtDescCasas.Text
            .DescResidCondominios = txtDescCond.Text
            .DescResidPavimentos = txtDescPavim.Text
            .DescResidApartamentos = txtDescApart.Text
            .DescResidDormitorios = txtDescDormit.Text
            .DescResidSuite = txtDescSuites.Text
            .DescResidBanheiro = txtDescBanh.Text
            .DescResidLavabo = txtDescLavabo.Text
            .DescResidSala = txtDescSala.Text
            .DescResidCopa = txtDescCopa.Text
            .DescResidATV = txtDescAreaServ.Text
            .DescResidDepEmpreg = txtDescDepend.Text
            .DescResidOutros = txtDescOutros.Text

            Dim p_IdAreaLazer As Integer = 0
            p_IdAreaLazer += IIf(chkSalaoFestas.Checked, 1, 0)
            p_IdAreaLazer += IIf(chkSalaoJogos.Checked, 2, 0)
            p_IdAreaLazer += IIf(chkPiscina.Checked, 4, 0)
            p_IdAreaLazer += IIf(chkSauna.Checked, 8, 0)
            p_IdAreaLazer += IIf(chkChurrasqueira.Checked, 16, 0)
            p_IdAreaLazer += IIf(chkQuadra.Checked, 32, 0)
            p_IdAreaLazer += IIf(chkFitness.Checked, 64, 0)
            p_IdAreaLazer += IIf(chkGourmet.Checked, 128, 0)
            p_IdAreaLazer += IIf(chkPlayground.Checked, 256, 0)
            p_IdAreaLazer += IIf(chkSpa.Checked, 512, 0)
            p_IdAreaLazer += IIf(chkBrinquedoteca.Checked, 1024, 0)
            .IdAreaLazer = p_IdAreaLazer

            .DescInfoAdicTotalUnicades = txtInfoAdicTotalunid.Text
            .DescInfoAdicAreaUtil = txtInfoAdicAreaUtil.Text
            .DescInfoAdicAreaTerreno = txtInfoAdicAreaTerreno.Text
            .DescInfoAdicElevador = txtInfoAdicElevador.Text
            .DescInfoAdicVagas = txtInfoAdicVagasApart.Text
            .DescInfoAdicCobert = txtInfoAdicCoberturas.Text
            .DescInfoAdicArCondic = txtInfoAdicArCond.Text
            .DescInfoAdicAquecimento = txtInfoAdicAquecimento.Text
            .DescInfoAdicFundacoes = txtInfoAdicFundacoes.Text
            .DescInfoAdicEstrutura = txtInfoAdicEstrutura.Text
            .DescInfoAdicAcabamento = txtInfoAdicAcabamento.Text
            .DescInfoAdicFachada = txtInfoAdicFachada.Text
            .Foto = txtFoto.Text
            .Mapa = txtMapa.Text

            .UsuarioAlteracao = Usuario.Login
            .IDTipoCotacao = cboIdTipoCotacao.Value
            .ValorDolar = txtValorDolar.Text
            .OutrosAreaLazer = txtLazerOutros.Text

        End With
    End Sub

    Private Sub Inflate()
        With Obras

            lblCodigo.Text = .Codigo
            txtCodigoAntigo.Text = .CodigoAntigo
            txtPublicacao.Text = .Publicacao
            txtNrDaRevisao.Text = .NrDaRevisao
            txtProjeto.Text = .Projeto
            txtValor.Text = FormatNumber(.Valor, 2)
            txtAreaConstruida.Text = .AreaConstruida
            txtCapacidadeDeProducao.Text = .CapacidadeDeProducao
            txtMateriaPrima.Text = .MateriaPrima
            txtEndereco.Text = .Endereco
            txtComplemento.Text = .Complemento
            txtCEP.Text = .CEP
            cboCidade.ValueString = .Cidade
            cboEstado.Value = .Estado
            cboPesquisadores.Value = .Pesquisador
            txtInicio.Text = .Inicio
            txtTermino.Text = .Termino
            cboIDFase.Value = .IDFase
            If .IDFase = 0 Then
                cboEstagio.Clear()
                cboEstado.AddItem(0, "Selecione a fase...")
            Else
                BindEstagios(.IDFase)
                cboEstagio.Value = .EstagioAtual
            End If
            cboTipo.Value = .IdTipo
            txtDescProj1.Text = .DescProj1
            chkDemo.Checked = .Demo

            BindGrid(.Codigo)
            BindGridContatos(.Codigo)
            lblMensagem.Text = strMensagem
            If blnContatos Or blnEmpresas Then
                lblMensagem.Visible = True
            Else
                lblMensagem.Visible = False
            End If

            If .Codigo > 0 Then
                cboStatus.Value = .Ativo
                cboStatus.Enabled = True
                Barra.AtivarBotoes(IIf(CheckPermission("Cadastro de Obras", "Adicionar"), BarraBotoes2.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Obras", "Atualizar"), BarraBotoes2.Botoes_Ativos.Atualizar, 0) + IIf(CheckPermission("Cadastro de Obras", "Apagar"), BarraBotoes2.Botoes_Ativos.Excluir, 0) + BarraBotoes2.Botoes_Ativos.Voltar)
            Else
                cboStatus.Value = 2
                cboStatus.Enabled = False
                Barra.AtivarBotoes(IIf(CheckPermission("Cadastro de Obras", "Atualizar"), BarraBotoes2.Botoes_Ativos.Atualizar, 0) + BarraBotoes2.Botoes_Ativos.Voltar)
            End If

            txtDataCadastro.Text = .DataCadastro
            txtInicioTermino.Text = .InicioTermino
            cboVendedor.Value = .Vendedor
            cboIdSubTipo.Value = .IdSubTipo
            '.EstagioDetalhes

            Dim p_IdAreaLazer As Integer = .IdAreaLazer
            chkSalaoFestas.Checked = (p_IdAreaLazer And 1) > 0
            chkSalaoJogos.Checked = (p_IdAreaLazer And 2) > 0
            chkPiscina.Checked = (p_IdAreaLazer And 4) > 0
            chkSauna.Checked = (p_IdAreaLazer And 8) > 0
            chkChurrasqueira.Checked = (p_IdAreaLazer And 16) > 0
            chkQuadra.Checked = (p_IdAreaLazer And 32) > 0
            chkFitness.Checked = (p_IdAreaLazer And 64) > 0
            chkGourmet.Checked = (p_IdAreaLazer And 128) > 0
            chkPlayground.Checked = (p_IdAreaLazer And 256) > 0
            chkSpa.Checked = (p_IdAreaLazer And 512) > 0
            chkBrinquedoteca.Checked = (p_IdAreaLazer And 1024) > 0

            txtDescEdificios.Text = .DescResidEdificio
            txtDescCasas.Text = .DescResidResidenciais
            txtDescCond.Text = .DescResidCondominios
            txtDescPavim.Text = .DescResidPavimentos
            txtDescApart.Text = .DescResidApartamentos
            txtDescDormit.Text = .DescResidDormitorios
            txtDescSuites.Text = .DescResidSuite
            txtDescBanh.Text = .DescResidBanheiro
            txtDescLavabo.Text = .DescResidLavabo
            txtDescSala.Text = .DescResidSala
            txtDescCopa.Text = .DescResidCopa
            txtDescAreaServ.Text = .DescResidATV
            txtDescDepend.Text = .DescResidDepEmpreg
            txtDescOutros.Text = .DescResidOutros
            ' .AreaLazer_int
            txtInfoAdicTotalunid.Text = .DescInfoAdicTotalUnicades
            txtInfoAdicAreaUtil.Text = .DescInfoAdicAreaUtil
            txtInfoAdicAreaTerreno.Text = .DescInfoAdicAreaTerreno
            txtInfoAdicElevador.Text = .DescInfoAdicElevador
            txtInfoAdicVagasApart.Text = .DescInfoAdicVagas
            txtInfoAdicCoberturas.Text = .DescInfoAdicCobert
            txtInfoAdicArCond.Text = .DescInfoAdicArCondic
            txtInfoAdicAquecimento.Text = .DescInfoAdicAquecimento
            txtInfoAdicFundacoes.Text = .DescInfoAdicFundacoes
            txtInfoAdicEstrutura.Text = .DescInfoAdicEstrutura
            txtInfoAdicAcabamento.Text = .DescInfoAdicAcabamento
            txtInfoAdicFachada.Text = .DescInfoAdicFachada
            txtFoto.Text = .Foto
            txtMapa.Text = .Mapa
            cboIdTipoCotacao.Value = .IDTipoCotacao
            txtValorDolar.Text = .ValorDolar
            txtLazerOutros.Text = .OutrosAreaLazer

            If .Codigo > 0 Then
                lblAgradece.Visible = True
                lblAgradece.Text = "<a href='javas" & "cript:EnviaAgradecimento(""" & Server.UrlEncode(CryptographyEncoded(.Codigo)) & """)'>Agradece</a>"
            Else
                lblAgradece.Visible = False
            End If

        End With

    End Sub

    Private Sub BindEstagios(ByVal IdFase As Integer)
        Dim Est As New clsEstagios
        With cboEstagio
            .CssClass = "f8"
            .CssClassValidator = "f8"
            .DataSource = Est.List(IdFase)
            .DataTextField = "DescricaoEstagio"
            .DataValueField = "IdEstagio"
            .DataBind()

        End With
        Est = Nothing
    End Sub

    Private Sub BindGrid(ByVal IdCodigo As Integer)
        Dim ds As DataSet = Obras.ListEmpresas(IdCodigo)
        If ds.Tables(0).Rows.Count > 0 Then
            dtgEmpresasParticipantes.DataSource = ds
            dtgEmpresasParticipantes.DataBind()
            blnEmpresas = False
        Else
            If blnContatos Then
                strMensagem &= "e Cadastro de Empresas Participantes "
            Else
                strMensagem &= "Verificar Cadastro de Empresas Participantes "
            End If
            blnEmpresas = True
        End If
    End Sub

    Private Sub BindGridContatos(ByVal IdCodigo As Integer)
        Dim ds As DataSet = Obras.ListContatos(IdCodigo)
        If ds.Tables(0).Rows.Count > 0 Then
            dtgContatos.DataSource = ds
            dtgContatos.DataBind()
            blnContatos = False
        Else
            If blnEmpresas Then
                strMensagem &= "e Cadastro de Contatos "
            Else
                strMensagem &= "Verificar Cadastro de Contatos "
            End If
            blnContatos = True
        End If
    End Sub

    Private Sub BarraBotoes_Atualizar() Handles Barra.Gravar
        Deflate()
        If blnInsertObra = True Then
            Obras.Update()
            Log_Usuario("GRAVAR OBRA", XMWebPage.MODULO.OBRAS)
            Gravado("obrasdet.aspx?codigo=" & CryptographyEncoded(Obras.Codigo))
        Else
            Response.Write("<script language='javascript'>alert('ATENÇÃO\nCódigo de Obra já existe.\nVerifique...')</script>")
        End If
    End Sub

    Private Sub BarraBotoes_Incluir() Handles Barra.Incluir
        Response.Redirect("obrasdet.aspx")
    End Sub

    Private Sub BarraBotoes_Voltar() Handles Barra.Voltar
        Response.Redirect("obras.aspx")
    End Sub

    Private Sub btnAdicionarContato_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdicionarContato.Click
        Response.Redirect("contatosobras.aspx?idobra=" & CryptographyEncoded(ViewState("Codigo")))
    End Sub

    Private Sub btnAdicionarEmpresa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdicionarEmpresa.Click
        Response.Redirect("empresaobras.aspx?idobra=" & CryptographyEncoded(ViewState("Codigo")))
    End Sub

    Private Sub BarraBotoes_Excluir() Handles Barra.Excluir
        Obras = New clsObras(ViewState("Codigo"), 0)
        Obras.Apagar()
        Obras = Nothing
        Log_Usuario("APAGAR OBRA", XMWebPage.MODULO.OBRAS)
        Response.Redirect("obras.aspx")
    End Sub

    Private Sub cboIDFase_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDFase.SelectedIndexChanged
        If cboIDFase.Value > 0 Then
            BindEstagios(cboIDFase.Value)
        Else
            cboEstagio.Clear()
            cboEstagio.AddItem(0, "Selecione a fase...")
        End If
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEstado.SelectedIndexChanged

        CarregaCidades(cboEstado.Text)

    End Sub

    Private Sub CarregaCidades(ByVal Estado As String)

        cboCidade.Clear()
        cboCidade.Enabled = True

        Dim Cid As New clsCidades
        With cboCidade
            .CssClass = "f8"
            .CssClassValidator = "f8"
            .DataSource = Cid.ListCidades(cboEstado.Text)
            .DataTextField = "CIDADE"
            .DataValueField = "CIDADE"
            .DataBind()
            Cid = Nothing
        End With

    End Sub

    Private Sub btnVersoes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVersoes.Click
        Response.Redirect("ObrasVersoes.aspx?IdObra=" & CryptographyEncoded(ViewState("Codigo")))
    End Sub

    Private Sub cboIdSubTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIdSubTipo.SelectedIndexChanged
        Dim Tip As New clsTipos
        With cboTipo
            .CssClass = "f8"
            .CssClassValidator = "f8"
            .DataSource = Tip.List(cboIdSubTipo.Value)
            .DataTextField = "DescricaoTipo"
            .DataValueField = "IdTipo"
            .DataBind()
        End With
        Tip = Nothing
    End Sub
End Class

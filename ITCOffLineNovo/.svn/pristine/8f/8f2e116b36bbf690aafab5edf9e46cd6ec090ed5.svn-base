Imports ITCOffLine

'************************************************************
'Classe gerada por XM .NET Class Creator - 15/1/2003 12:03:46
'************************************************************

Public Class EmpresasDet

    Inherits XMWebPage

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents tblEmpresasDet As System.Web.UI.WebControls.Table
    Protected WithEvents lblCodigo As System.Web.UI.WebControls.Label
    Protected WithEvents txtAtualizacao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFantasia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRazaoSocial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndereco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtComplemento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCEP As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSkype As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboEstado As ComboBox
    Protected WithEvents txtCNPJ As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInscricaoEstadual As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInscricaoMunicipal As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboIdAtividade As ComboBox
    Protected WithEvents cboPesquisador As ComboBox
    Protected WithEvents txtNrDaRevisao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWebSite As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents Barra As BarraBotoes2
    Protected WithEvents BarraBotoes21 As BarraBotoes2
    Protected WithEvents dtgContatos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAdicionarContato As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    Protected WithEvents ValidationSummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents lblMensagem As System.Web.UI.WebControls.Label
    Protected WithEvents chkDemo As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cboStatus As ComboBox
    Protected WithEvents cboVendedor As ComboBox
    Protected WithEvents cboCidade As ComboBox
    Protected WithEvents txtObservacao As System.Web.UI.WebControls.TextBox

#End Region

    Private Empresas As clsEmpresas

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            cboCidade.Enabled = False
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

            Dim Est As New clsEstados
            cboEstado.CssClass = "f8"
            cboEstado.CssClassValidator = "f8"
            cboEstado.DataSource = Est.ListEstados
            cboEstado.DataTextField = "UF"
            cboEstado.DataValueField = "IdEstado"
            cboEstado.DataBind()
            Est = Nothing

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

            Dim At As New clsAtividades
            cboIdAtividade.CssClass = "f8"
            cboIdAtividade.CssClassValidator = "f8"
            cboIdAtividade.DataSource = At.List
            cboIdAtividade.DataValueField = "IdAtividade"
            cboIdAtividade.DataTextField = "DescricaoAtividade"
            cboIdAtividade.DataBind()
            At = Nothing

            Dim Pesq As New clsPesquisadores
            cboPesquisador.CssClass = "f8"
            cboPesquisador.CssClassValidator = "f8"
            cboPesquisador.DataSource = Pesq.List(0)
            cboPesquisador.DataValueField = "IdPesquisador"
            cboPesquisador.DataTextField = "SIGLAPESQUISADOR"
            cboPesquisador.DataBind()
            Pesq = Nothing

            With cboStatus
                .EnableValidation = False
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .AddItem(0, "INATIVO")
                .AddItem(1, "ATIVO")
                .AddItem(2, "PENDENTE")
            End With

            Dim objEmpresa As Object = DeCryptography(Page.Request("Codigo"))
            Dim m_IdEmpresa As Integer
            If IsNumeric(objEmpresa) Then
                m_IdEmpresa = objEmpresa
            Else
                m_IdEmpresa = 0
            End If
            ViewState("IdEmpresa") = CInt(0 & m_IdEmpresa)

            Empresas = New clsEmpresas(ViewState("IdEmpresa"))
            Inflate()
            BindContatos()

        Else

            Empresas = New clsEmpresas(ViewState("IdEmpresa"))

        End If

        If ViewState("IdEmpresa") = 0 Then
            btnAdicionarContato.Visible = False
        Else
            btnAdicionarContato.Visible = True
        End If

    End Sub

    Private Sub BindContatos()
        Dim clsContato As New clsContatoEmpresas(Me)
        dtgContatos.DataSource = clsContato.List(ViewState("IdEmpresa"))
        dtgContatos.DataBind()
        If ViewState("IdEmpresa") > 0 Then
            If dtgContatos.Items.Count = 0 Then
                lblMensagem.Visible = True
            Else
                lblMensagem.Visible = False
            End If
        Else
            lblMensagem.Visible = False
        End If
        clsContato = Nothing
    End Sub

    Private Sub Deflate()
        With Empresas
            .Codigo = lblCodigo.Text
            .Fantasia = txtFantasia.Text
            .RazaoSocial = txtRazaoSocial.Text
            .Endereco = txtEndereco.Text
            .Complemento = txtComplemento.Text
            .CEP = txtCEP.Text
            .Cidade = cboCidade.ValueString
            .IdEstado = cboEstado.Value
            .CNPJ = txtCNPJ.Text
            .InscricaoEstadual = txtInscricaoEstadual.Text
            .InscricaoMunicipal = txtInscricaoMunicipal.Text
            .IdAtividade = cboIdAtividade.Value
            .IdPesquisador = cboPesquisador.Value
            .Atualizacao = txtAtualizacao.Text
            .NrDaRevisao = txtNrDaRevisao.Text
            .CodigoAntigo = ""
            .WebSite = txtWebSite.Text
            .EMail = txtEmail.Text
            .Demo = chkDemo.Checked
            .Ativo = cboStatus.Value
            .Vendedor = cboVendedor.Value
            .Observacao = txtObservacao.Text
            .EMail2 = txtEmail2.Text
            .Skype = txtSkype.Text
        End With
    End Sub

    Private Sub Inflate()
        With Empresas
            lblCodigo.Text = .Codigo
            txtFantasia.Text = .Fantasia
            txtRazaoSocial.Text = .RazaoSocial
            txtEndereco.Text = .Endereco
            txtComplemento.Text = .Complemento
            txtCEP.Text = .CEP
            cboCidade.ValueString = .Cidade
            cboEstado.Value = .IdEstado

            txtCNPJ.Text = .CNPJ
            txtInscricaoEstadual.Text = .InscricaoEstadual
            txtInscricaoMunicipal.Text = .InscricaoMunicipal
            cboIdAtividade.Value = .IdAtividade
            cboPesquisador.Value = .IdPesquisador
            txtAtualizacao.Text = .Atualizacao
            txtNrDaRevisao.Text = .NrDaRevisao
            'txtCodigoAntigo.Text = .CodigoAntigo
            txtWebSite.Text = .WebSite
            txtEmail.Text = .EMail
            chkDemo.Checked = .Demo
            txtObservacao.Text = .Observacao
            txtEmail2.Text = .EMail2
            txtSkype.Text = .Skype

            If .Codigo > 0 Then
                cboStatus.Value = .Ativo
                cboStatus.Enabled = True
                BarraBotoes21.AtivarBotoes(IIf(CheckPermission("Cadastro de Empresas", "Adicionar"), BarraBotoes2.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Cadastro de Empresas", "Atualizar"), BarraBotoes2.Botoes_Ativos.Atualizar, 0) + IIf(CheckPermission("Cadastro de Empresas", "Apagar"), BarraBotoes2.Botoes_Ativos.Excluir, 0) + BarraBotoes2.Botoes_Ativos.Voltar)
            Else
                cboStatus.Value = 2
                cboStatus.Enabled = False
                BarraBotoes21.AtivarBotoes(IIf(CheckPermission("Cadastro de Empresas", "Atualizar"), BarraBotoes2.Botoes_Ativos.Atualizar, 0) + BarraBotoes2.Botoes_Ativos.Voltar)
            End If
            cboVendedor.Value = .Vendedor

        End With

    End Sub

    Private Sub BarraBotoes_Atualizar() Handles BarraBotoes21.Gravar
        If ViewState("IdEmpresa") = 0 And txtCNPJ.Text <> "" Then
            If Empresas.VerificaCNPJ(txtCNPJ.Text) = True Then
                ShowErro("CNPJ já existe")
                Exit Sub
            End If
        End If
        Deflate()
        Empresas.Update()
        Log_Usuario("GRAVAR EMPRESA", XMWebPage.MODULO.EMPRESAS)
        Gravado("empresasdet.aspx?codigo=" & CryptographyEncoded(Empresas.Codigo))
    End Sub

    Private Sub BarraBotoes_Incluir() Handles BarraBotoes21.Incluir
        Response.Redirect("empresasdet.aspx")
    End Sub

    Private Sub BarraBotoes_Voltar() Handles BarraBotoes21.Voltar
        Response.Redirect("empresas.aspx")
    End Sub

    Private Sub BarraBotoes_Excluir() Handles BarraBotoes21.Excluir
        Empresas = New clsEmpresas(ViewState("IdEmpresa"))
        Empresas.Apagar()
        Empresas = Nothing
        Log_Usuario("APAGAR EMPRESA", XMWebPage.MODULO.EMPRESAS)
        Response.Write("<script language='javascript'>alert('Empresa excluída com sucesso !');</script>")
        Response.Redirect("empresas.aspx")
    End Sub

    Private Sub btnAdicionarContato_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdicionarContato.Click
        Response.Redirect("contatosempresas.aspx?IDEmpresa=" & CryptographyEncoded(ViewState("IdEmpresa")))
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

End Class

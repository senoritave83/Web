'************************************************************
'Classe gerada por XM .NET Class Creator - 15/1/2003 12:03:46
'************************************************************

Public Class EmpresasDet

    Inherits XMWebPage

    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents tblEmpresasDet As HtmlTable
    Protected WithEvents lblCodigo As System.Web.UI.WebControls.Label
    Protected WithEvents txtAtualizacao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFantasia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRazaoSocial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndereco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtComplemento As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCEP As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCidade As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboEstado As ComboBox
    Protected WithEvents txtCNPJ As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInscricaoEstadual As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInscricaoMunicipal As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboIdAtividade As ComboBox
    Protected WithEvents cboPesquisador As ComboBox
    Protected WithEvents txtNrDaRevisao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWebSite As System.Web.UI.WebControls.TextBox
    Protected WithEvents dtgContatos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMensagem As System.Web.UI.WebControls.Label
    Protected WithEvents chkDemo As System.Web.UI.WebControls.CheckBox
    Protected WithEvents cboStatus As ComboBox
    Protected WithEvents lblVendedor As Label
    Protected WithEvents btnVoltar As Button
    Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSkype As System.Web.UI.WebControls.TextBox

    Private Empresas As clsEmpresas

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

            Dim Est As New clsEstados
            cboEstado.CssClass = "f8"
            cboEstado.CssClassValidator = "f8"
            cboEstado.DataSource = Est.ListEstados
            cboEstado.DataTextField = "UF"
            cboEstado.DataValueField = "IdEstado"
            cboEstado.DataBind()
            Est = Nothing

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

        'Componentes com edição desabilitada
        cboEstado.Enabled = False
        cboIdAtividade.Enabled = False
        cboPesquisador.Enabled = False
        cboStatus.Enabled = False
        chkDemo.Enabled = False

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
            .IdAssociado = Me.Usuario.IdEmpresa
            .Fantasia = txtFantasia.Text
            .RazaoSocial = txtRazaoSocial.Text
            .Endereco = txtEndereco.Text
            .Complemento = txtComplemento.Text
            .CEP = txtCEP.Text
            .Cidade = txtCidade.Text
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
            txtCidade.Text = .Cidade
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
            txtEmail2.Text = .EMail2
            txtSkype.Text = .Skype

            If .Codigo > 0 Then
                cboStatus.Value = .Ativo
                cboStatus.Enabled = True
                'BarraBotoes.AtivarBotoes(BarraBotoes.Botoes_Ativos.Voltar)
            Else
                cboStatus.Value = 2
                cboStatus.Enabled = False
                'BarraBotoes.AtivarBotoes(IIf(CheckPermission("Cadastro de Empresas", "Atualizar"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
                'BarraBotoes.AtivarBotoes(BarraBotoes.Botoes_Ativos.Voltar)
            End If

            lblVendedor.Text = .Vendedor

        End With

    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("empresas.aspx")
    End Sub
End Class

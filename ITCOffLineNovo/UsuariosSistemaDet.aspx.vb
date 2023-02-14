Imports ITCOffLine

Public Class UsuariosSistemaDet

    Inherits XMWebPage

    Protected WithEvents lbl As System.Web.UI.WebControls.Label
    Protected WithEvents lblCodigo As System.Web.UI.WebControls.Label
    Protected WithEvents Requiredfieldvalidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtLogin As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents valDescricao As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblArea As System.Web.UI.WebControls.TableCell
    Protected WithEvents lblGestor As System.Web.UI.WebControls.TableCell
    Protected WithEvents lblGestorCbo As System.Web.UI.WebControls.TableCell
    Protected WithEvents lblAreaCbo As System.Web.UI.WebControls.TableCell
    Protected WithEvents Especifico As System.Web.UI.WebControls.TableRow
    Protected WithEvents btnReset As System.Web.UI.WebControls.ImageButton
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Barra As BarraBotoes2
    Protected WithEvents btnGravar As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtTelefoneUsuario1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefoneUsuario2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCelularUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents Datagrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cboIdCargo As ComboBox
    Protected WithEvents cboIdGrupo As ComboBox
    Protected WithEvents cboTipoUsuario As ComboBox
    Protected WithEvents cboAreaITC As ComboBox
    Protected WithEvents cboGestor As ComboBox
    Protected WithEvents dtgGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents tblObrasDet As System.Web.UI.WebControls.Table
    Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents lblMensagem As Label
    Protected cls As clsUsuario


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

            Dim Car As New clsCargos(Me)
            With cboIdCargo
                .EnableValidation = True
                .DataTextField = "DESCRICAOCARGO"
                .DataValueField = "IDCARGO"
                .DataSource = Car.List
                .DataBind()
            End With
            Car = Nothing

            Dim gru As New clsGrupos
            With cboIdGrupo
                .EnableValidation = True
                .DataTextField = "DESCRICAOGRUPO"
                .DataValueField = "IDGRUPO"
                .DataSource = gru.List
                .DataBind()
            End With
            gru = Nothing

            With cboTipoUsuario
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataTextField = "TipoUsuario"
                .DataValueField = "IDTipo"
                .AddItem(0, "Selecione...")
                .AddItem(1, "Usuário Master")
                .AddItem(2, "Sub-Usuário")
                .AddItem(3, "Vendedor")
                .AddItem(4, "Gestor")
            End With

            Dim objIdUsuario As Object = DeCryptography(Request("IDUsuario"))
            If IsNumeric(objIdUsuario) Then
                ViewState("IDUsuario") = objIdUsuario
            Else
                ViewState("IDUsuario") = 0
            End If

            cls = New clsUsuario(ViewState("IDUsuario"), -1)
            Inflate()

            BindGrid()

            btnReset.Visible = (CheckPermission("Usuários do Sistema", "Renovar Senha") And ViewState("IDUsuario") <> 0)
            btnGravar.Visible = (CheckPermission("Usuários do Sistema", "Atualizar Permissões") And ViewState("IDUsuario") <> 0)

        Else

            cls = New clsUsuario(ViewState("IDUsuario"), -1)

        End If

    End Sub

    Private Sub BindGrid()
        dtgGrid.DataSource = cls.ListPermissoes(ViewState("IDUsuario"))
        dtgGrid.DataBind()
    End Sub

    Private Sub Deflate()
        With cls
            .Usuario = txtNome.Text
            .Login = txtLogin.Text
            .IDCargo = cboIdCargo.Value
            .Email = txtEmail.Text
            .IdEmpresa = -1
            .IDGrupo = cboIdGrupo.Value
            .IdTipoUsuario = cboTipoUsuario.Value
            .IdGestor = cboGestor.Value
            .IDArea = cboAreaITC.Value
            .TelefoneUsuario1 = txtTelefoneUsuario1.Text
            .TelefoneUsuario2 = txtTelefoneUsuario2.Text
            .CelularUsuario = txtCelularUsuario.Text
        End With
    End Sub

    Private Sub Inflate()

        With cls
            txtNome.Text = .Usuario
            txtLogin.Text = .Login
            txtEmail.Text = .Email
            cboIdCargo.Value = .IDCargo
            cboIdGrupo.Value = .IDGrupo
            cboTipoUsuario.Value = .IdTipoUsuario
            If .IdTipoUsuario = cls.TipoUsuario.SubUsuario Or .IdTipoUsuario = cls.TipoUsuario.Vendedor Then
                Especifico.Visible = True
                lblGestor.Visible = True
                lblGestorCbo.Visible = True
                CarregaGestor()
            End If
            cboGestor.Value = .IdGestor
            If .IdTipoUsuario = cls.TipoUsuario.Gestor Then
                Especifico.Visible = True
                lblArea.Visible = True
                lblAreaCbo.Visible = True
                CarregaAreaITC()
            End If
            cboAreaITC.Value = .IDArea
            txtTelefoneUsuario1.Text = .TelefoneUsuario1
            txtTelefoneUsuario2.Text = .TelefoneUsuario2
            txtCelularUsuario.Text = .CelularUsuario
        End With
        Barra.AtivarBotoes(IIf(CheckPermission("Usuários do Sistema", "Adicionar"), BarraBotoes2.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Usuários do Sistema", "Apagar"), BarraBotoes2.Botoes_Ativos.Excluir, 0) + IIf(CheckPermission("Usuários do Sistema", "Atualizar"), BarraBotoes2.Botoes_Ativos.Atualizar, 0) + BarraBotoes2.Botoes_Ativos.Voltar)

    End Sub

    Private Sub BarraBotoes_Atualizar() Handles Barra.Gravar

        If ViewState("IDUsuario") = 0 And CheckPermission("Usuários do Sistema", "Adicionar") = False Then
            ShowErro("Permissão negada")
            Exit Sub
        End If
        If ViewState("IDUsuario") > 0 And CheckPermission("Usuários do Sistema", "Atualizar") = False Then
            ShowErro("Permissão negada")
            Exit Sub
        End If
        Deflate()
        Dim intRetorno As Integer = cls.Update()
        Select Case intRetorno
            Case 1
                Gravado("usuariossistemadet.aspx?idusuario=" & CryptographyEncoded(cls.IDUsuario))
            Case 2
                lblMensagem.Text = "Ocorreram erros na gravação Se o problema persistir, entre em contato com o administrador do sistema"
            Case 3
                lblMensagem.Text = "O usuário já existe."
        End Select
        'If cls.Update Then
        '    Gravado("usuariossistemadet.aspx?idusuario=" & CryptographyEncoded(cls.IDUsuario))
        'End If
    End Sub

    Private Sub BarraBotoes_Excluir() Handles Barra.Excluir
        If CheckPermission("Usuários do Sistema", "Apagar") Then
            cls.Delete()
            Response.Redirect("usuariossistema.aspx")
        Else
            ShowErro("Permissão Negada")
        End If
    End Sub

    Private Sub BarraBotoes_Incluir() Handles Barra.Incluir
        If CheckPermission("Usuários do Sistema", "Adicionar") Then
            Response.Redirect("usuariossistemadet.aspx?idusuario=" & CryptographyEncoded("0"))
        Else
            ShowErro("Permissão Negada")
        End If
    End Sub

    Private Sub BarraBotoes_Voltar() Handles Barra.Voltar
        Response.Redirect("usuariossistema.aspx")
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnReset.Click
        If CheckPermission("Usuários do Sistema", "Renovar Senha") Then
            cls.AlterarSenha(ViewState("IDUsuario"), "itc")
            ShowErro("Senha redefinida com sucesso")
        Else
            ShowErro("Permissão Negada")
        End If
    End Sub

    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGravar.Click
        Dim strPermissoes As String = ""
        Dim i As Integer
        For i = 0 To dtgGrid.Items.Count - 1
            Dim CurrentCheckBox As CheckBox = dtgGrid.Items(i).FindControl("chkPermissao")
            If CurrentCheckBox.Checked Then
                If strPermissoes.Trim <> "" Then
                    strPermissoes += ","
                End If
                strPermissoes += dtgGrid.DataKeys.Item(dtgGrid.Items(i).ItemIndex).ToString()
            End If
        Next
        cls = New clsUsuario(ViewState("IDUsuario"), -1)
        cls.SavePermissoes(strPermissoes, ViewState("IDUsuario"))
        BindGrid()
        cls = Nothing
    End Sub

    Private Sub CarregaGestor()

        With cboGestor
            .Clear()
            .EnableValidation = True
            .DataTextField = "NomeGestor"
            .DataValueField = "IdGestor"
            .DataSource = cls.SelecionaGestores(-1, ViewState("IDUsuario"))
            .DataBind()
        End With

    End Sub

    Private Sub CarregaAreaITC()

        With cboAreaITC
            .Clear()
            .EnableValidation = True
            .DataTextField = "AreaITC"
            .DataValueField = "IdArea"
            .DataSource = cls.SelecionaAreasITC()
            .DataBind()
        End With

    End Sub

    Private Sub cboTipoUsuario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoUsuario.SelectedIndexChanged

        If cboTipoUsuario.Value = clsUsuario.TipoUsuario.Gestor Then

            Especifico.Visible = True

            lblGestor.Visible = False
            lblGestorCbo.Visible = False

            lblArea.Visible = True
            lblAreaCbo.Visible = True

            cboGestor.Clear()
            CarregaAreaITC()

        ElseIf cboTipoUsuario.Value = clsUsuario.TipoUsuario.SubUsuario Or _
        cboTipoUsuario.Value = clsUsuario.TipoUsuario.Vendedor Then

            Especifico.Visible = True

            lblArea.Visible = False
            lblAreaCbo.Visible = False

            lblGestor.Visible = True
            lblGestorCbo.Visible = True

            cboAreaITC.Clear()
            CarregaGestor()

        ElseIf cboTipoUsuario.Value = clsUsuario.TipoUsuario.Master Or cboTipoUsuario.Value = 0 Then

            Especifico.Visible = False

        End If
    End Sub
End Class

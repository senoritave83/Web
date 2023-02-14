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
    Protected WithEvents btnReset As Button
    Protected WithEvents btnVoltar As Button
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents BarraBotoes As BarraBotoes
    Protected WithEvents btnGravar As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtFone As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents lblCodigoInflate As System.Web.UI.WebControls.Label
    Protected WithEvents TxtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents Datagrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cboIdCargo As DropDownList
    Protected WithEvents cboIdGrupo As DropDownList
    Protected WithEvents cboTipoUsuario As DropDownList
    Protected WithEvents dtgGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents tblObrasDet As System.Web.UI.HtmlControls.HtmlTable
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
                .DataSource = Car.List
                .DataBind()
            End With
            Car = Nothing

            Dim gru As New clsGrupos
            With cboIdGrupo
                .DataSource = gru.List
                .DataBind()
                .Items.Insert(0, New ListItem("Não definido", 0))
            End With
            gru = Nothing

            With cboTipoUsuario
                .Items.Insert(0, New ListItem("Selecione...", 0))
                .Items.Insert(1, New ListItem("Usuário Master", 1))
                .Items.Insert(2, New ListItem("Sub-Usuário", 2))
                .Items.Insert(3, New ListItem("Vendedor", 3))
                .Items.Insert(4, New ListItem("Gestor", 4))
                .Enabled = False
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

            '******************************************
            'SUELI SOLICITOU QUE VOLTASSE O BOTÃO RESET
            '******************************************
            btnReset.Visible = (CheckPermission("Usuários do Sistema", "Renovar Senha") And ViewState("IDUsuario") <> 0)
            btnGravar.Visible = False '(CheckPermission("Usuários do Sistema", "Atualizar Permissões") And ViewState("IDUsuario") <> 0)
            If btnReset.Visible Then btnReset.Attributes.Add("onClick", "if(confirm('Confirma renovação de senha ?')==false) return false;")

        Else

            cls = New clsUsuario(ViewState("IDUsuario"), -1)

        End If

        'Componentes Desabilitados
        cboIdCargo.Enabled = False
        cboIdGrupo.Enabled = False
        cboTipoUsuario.Enabled = False

    End Sub

    Private Sub BindGrid()
        dtgGrid.DataSource = cls.ListPermissoes(ViewState("IDUsuario"))
        dtgGrid.DataBind()
    End Sub

    Private Sub Deflate()
        With cls
            .Usuario = txtNome.Text
            .Login = txtLogin.Text
            .IDCargo = XMGetListItemValue(cboIdCargo)
            .Email = ""
            .IdEmpresa = -1
            .IDGrupo = XMGetListItemValue(cboIdGrupo)
            .IdTipoUsuario = XMGetListItemValue(cboTipoUsuario)
            .Email = TxtEmail.Text
        End With
    End Sub

    Private Sub Inflate()

        With cls
            lblCodigoInflate.Text = Right("000" & .IDUsuario, 7)
            txtNome.Text = .Usuario
            txtLogin.Text = .Login
            TxtEmail.Text = .Email
            XMSetListItemValue(cboIdCargo, .IDCargo)
            XMSetListItemValue(cboIdGrupo, .IDGrupo)
            XMSetListItemValue(cboTipoUsuario, .IdTipoUsuario)
        End With
        'BarraBotoes.AtivarBotoes(IIf(CheckPermission("Usuários do Sistema", "Adicionar"), BarraBotoes.Botoes_Ativos.Incluir, 0) + IIf(CheckPermission("Usuários do Sistema", "Apagar"), BarraBotoes.Botoes_Ativos.Excluir, 0) + IIf(CheckPermission("Usuários do Sistema", "Atualizar"), BarraBotoes.Botoes_Ativos.Atualizar, 0) + BarraBotoes.Botoes_Ativos.Voltar)
        'BarraBotoes.AtivarBotoes(BarraBotoes.Botoes_Ativos.Voltar)

    End Sub

    Private Sub BarraBotoes_Atualizar() Handles BarraBotoes.Atualizar

        If ViewState("IDUsuario") = 0 And CheckPermission("Usuários do Sistema", "Adicionar") = False Then
            ShowErro("Permissão negada")
            Exit Sub
        End If
        If ViewState("IDUsuario") > 0 And CheckPermission("Usuários do Sistema", "Atualizar") = False Then
            ShowErro("Permissão negada")
            Exit Sub
        End If
        Deflate()
        If cls.Update Then
            Gravado("usuariossistemadet.aspx?idusuario=" & CryptographyEncoded(cls.IDUsuario))
        End If
    End Sub

    Private Sub BarraBotoes_Excluir() Handles BarraBotoes.Excluir
        If CheckPermission("Usuários do Sistema", "Apagar") Then
            cls.Delete()
            Response.Redirect("usuariossistema.aspx")
        Else
            ShowErro("Permissão Negada")
        End If
    End Sub

    Private Sub BarraBotoes_Incluir() Handles BarraBotoes.Incluir
        If CheckPermission("Usuários do Sistema", "Adicionar") Then
            Response.Redirect("usuariossistemadet.aspx?idusuario=" & CryptographyEncoded("0"))
        Else
            ShowErro("Permissão Negada")
        End If
    End Sub

    Private Sub BarraBotoes_Voltar() Handles BarraBotoes.Voltar
        Response.Redirect("usuariossistema.aspx")
    End Sub

    Private Sub btnVoltar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("usuariossistema.aspx")
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        If CheckPermission("Usuários do Sistema", "Renovar Senha") Then
            cls.AlterarSenha(CLng("0" & ViewState("IDUsuario")), "itc")
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
End Class

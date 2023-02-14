Imports ITCOffLine

Public Class GrupoDet

    Inherits XMWebPage

    Protected WithEvents lbl As System.Web.UI.WebControls.Label
    Protected WithEvents Requiredfieldvalidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Barra As BarraBotoes2
    Protected WithEvents dtgGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblGrupo As System.Web.UI.WebControls.Label
    Protected WithEvents txtGrupo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSalvarPermissoes As System.Web.UI.WebControls.ImageButton
    Protected cls As clsGrupos

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

            Dim objIdGrupo As Object = DeCryptography(Request("IdGrupo"))
            If IsNumeric(objIdGrupo) Then
                ViewState("IdGrupo") = objIdGrupo
            Else
                ViewState("IdGrupo") = 0
            End If
            cls = New clsGrupos(ViewState("IdGrupo"))
            Inflate()
            BindGrid()

        Else

            cls = New clsGrupos(ViewState("IdGrupo"))

        End If

    End Sub

    Private Sub BindGrid()

        If ViewState("IdGrupo") > 0 Then
            dtgGrid.DataSource = cls.ListPermissoes(ViewState("IdGrupo"))
            dtgGrid.DataBind()
        End If

    End Sub

    Private Sub Deflate()
        With cls
            .Grupo = txtGrupo.Text
        End With
    End Sub

    Private Sub Inflate()

        With cls
            txtGrupo.Text = .Grupo
        End With
        If ViewState("IdGrupo") = 0 Then
            btnSalvarPermissoes.Enabled = False
        Else
            btnSalvarPermissoes.Enabled = CheckPermission("Grupos", "Atualizar Permissões")
        End If
        Barra.AtivarBotoes(BarraBotoes2.Botoes_Ativos.Voltar)

    End Sub

    Private Sub BarraBotoes_Atualizar() Handles Barra.Gravar

        If ViewState("IdGrupo") = 0 And CheckPermission("Grupos", "Adicionar") = False Then
            ShowErro("Permissão negada")
            Exit Sub
        End If

        If ViewState("IdGrupo") > 0 And CheckPermission("Grupos", "Atualizar") = False Then
            ShowErro("Permissão negada")
            Exit Sub
        End If

        Deflate()

        If cls.Update Then
            UpdateTrustees()
            If Request("IDUsuario") = "0" Then Response.Redirect("grupodet.aspx?idgrupo=" & CryptographyEncoded(cls.IdGrupo), True)
            Inflate()
        End If

    End Sub

    Private Sub BarraBotoes_Incluir() Handles Barra.Incluir
        If CheckPermission("Grupos", "Adicionar") Then
            Response.Redirect("grupodet.aspx?IdGrupo=" & CryptographyEncoded("0"))
        Else
            ShowErro("Permissão Negada")
        End If
    End Sub

    Private Sub BarraBotoes_Voltar() Handles Barra.Voltar
        Response.Redirect("grupo.aspx")
    End Sub

    Private Sub UpdateTrustees()

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
        cls.SavePermissoes(strPermissoes)
        BindGrid()

    End Sub

    Private Sub btnSalvarPermissoes_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSalvarPermissoes.Click

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
        cls = New clsGrupos(ViewState("IdGrupo"))
        cls.SavePermissoes(strPermissoes)
        BindGrid()
        cls = Nothing

    End Sub

End Class

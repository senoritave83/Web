Imports Classes
Imports System.Configuration.ConfigurationManager

Namespace Pages.Cadastros

    Partial Public Class Permissao
        Inherits XMWebPage
        Dim cls As clsPermissao
        Protected Const VW_IDPERMISSAO As String = "IDPermissao"

        Protected Class tmpUsername
            Private m_strUserName As String
            Public Property UserName() As String
                Get
                    Return m_strUserName
                End Get
                Set(ByVal value As String)
                    m_strUserName = value
                End Set
            End Property

            Public Sub New(ByVal vUsername As String)
                m_strUserName = vUsername
            End Sub
        End Class

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPermissao()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta permiss�o?")
                ViewState(VW_IDPERMISSAO) = CInt("0" & Request("IDPermissao"))
                cls.Load(ViewState(VW_IDPERMISSAO))

                btnGravar.Enabled = fncPodeAlterar()
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = fncPodeApagar()

                Inflate()
                BindSelectedUsers()
            Else
                cls.Load(ViewState(VW_IDPERMISSAO))
            End If
        End Sub

        Function fncPodeApagar() As Boolean
            Dim blnPodeApagar As Boolean = True
            If CStr(AppSettings("IdPermissaoPromotor") & "") = CStr(ViewState(VW_IDPERMISSAO)) Or _
                CStr(AppSettings("IdPermissaoLider") & "") = CStr(ViewState(VW_IDPERMISSAO)) Or _
                CStr(AppSettings("IdPermissaoCoordenador") & "") = CStr(ViewState(VW_IDPERMISSAO)) Then
                blnPodeApagar = False
            Else
                If cls.isNew() Then
                    blnPodeApagar = False
                Else
                    blnPodeApagar = VerificaPermissao(SecaoAtual, ACAO_APAGAR)
                End If
            End If
            Return blnPodeApagar
        End Function

        Function fncPodeAlterar() As Boolean
            Dim blnPodeAlterar As Boolean = True
            If CStr(AppSettings("IdPermissaoPromotor") & "") = CStr(ViewState(VW_IDPERMISSAO)) Or _
                CStr(AppSettings("IdPermissaoLider") & "") = CStr(ViewState(VW_IDPERMISSAO)) Or _
                CStr(AppSettings("IdPermissaoCoordenador") & "") = CStr(ViewState(VW_IDPERMISSAO)) Then
                blnPodeAlterar = False
            Else
                If cls.isNew() Then
                    blnPodeAlterar = VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                Else
                    blnPodeAlterar = VerificaPermissao(SecaoAtual, ACAO_EDITAR)
                End If
            End If
            Return blnPodeAlterar
        End Function

        Protected Sub Inflate()
            txtPermissao.Text = cls.Permissao
            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If
            plhUsers.Visible = (cls.IDPermissao > 0)
        End Sub

        Protected Sub BindSelectedUsers()
            If cls.Permissao = "" Then
                grdUsersInRole.DataSource = Nothing
            Else
                grdUsersInRole.DataSource = GetUserList(Roles.GetUsersInRole(cls.Permissao))
                grdUsersInRole.DataBind()
            End If
        End Sub

        Protected Function GetUserList(ByVal vArray() As String) As Generic.List(Of tmpUsername)
            Dim a As New Generic.List(Of tmpUsername)
            For Each s As String In vArray
                a.Add(New tmpUsername(s))
            Next
            Return a
        End Function

        Protected Function GetUserList(ByVal vCol As MembershipUserCollection) As Generic.List(Of tmpUsername)
            Dim a As New Generic.List(Of tmpUsername)
            For Each s As MembershipUser In vCol
                a.Add(New tmpUsername(s.UserName))
            Next
            Return a
        End Function


        Protected Sub Deflate()
            cls.Permissao = txtPermissao.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.isNew() And VerificaPermissao(SecaoAtual, ACAO_ADICIONAR) = False) Or (cls.isNew() = False And VerificaPermissao(SecaoAtual, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("Permissao.aspx?idpermissao=" & cls.IDPermissao)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(SecaoAtual, ACAO_APAGAR) Then
                cls.Delete()
                Response.Redirect("Permissoes.aspx")
            End If
        End Sub

        Protected Sub chk_OnCheckedChange(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim checkbox As CheckBox = CType(sender, CheckBox)
            Dim row As GridViewRow = CType(checkbox.NamingContainer, GridViewRow)
            Dim strUsername As String = grdUsersInRole.DataKeys(row.DataItemIndex).Item(0)
            If Roles.IsUserInRole(strUsername, cls.Permissao) Then
                If checkbox.Checked = False Then Roles.RemoveUserFromRole(strUsername, cls.Permissao)
            Else
                If checkbox.Checked = True Then Roles.AddUserToRole(strUsername, cls.Permissao)
            End If
        End Sub

        Protected Sub grdUsersInRole_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdUsersInRole.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then
                Try
                    CType(e.Row.FindControl("chk"), CheckBox).Checked = Roles.IsUserInRole(e.Row.DataItem.UserName, cls.Permissao)
                Catch ex As Exception

                End Try
            End If
        End Sub

        Protected Sub btnProcurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.Click
            BindUsers(txtFiltro.Text, cboSearchType.SelectedValue)
        End Sub

        Protected Sub BindUsers(ByVal vFiltro As String, ByVal vTipo As String)
            If cls.Permissao = "" Then
                grdUsersInRole.DataSource = Nothing
            Else
                If vFiltro = "" Then
                    grdUsersInRole.DataSource = GetUserList(Membership.GetAllUsers())
                ElseIf vTipo = "email" Then
                    grdUsersInRole.DataSource = GetUserList(Membership.FindUsersByEmail(vFiltro))
                Else
                    grdUsersInRole.DataSource = GetUserList(Membership.FindUsersByName(vFiltro))
                End If
                grdUsersInRole.DataBind()
            End If
        End Sub

        Protected Sub Letras1_Item_Selected(ByVal vLetra As String) Handles Letras1.Item_Selected
            BindUsers(vLetra, "username")
        End Sub
    End Class

End Namespace



Imports Classes

Partial Class controls_Permissoes
    Inherits System.Web.UI.UserControl
    Implements XMWebEditPage.IEditPageObserver

#Region "Default Methods"

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If TypeOf (Me.Page) Is XMWebEditPage Then
            CType(Page, XMWebEditPage).AddObserver(Me)
        End If
    End Sub


    Public Property IDReferencia() As Integer
        Get
            If ViewState("IDReferencia") Is Nothing Then
                Return 0
            End If
            Return ViewState("IDReferencia")
        End Get
        Set(ByVal value As Integer)
            ViewState("IDReferencia") = value
        End Set
    End Property

    Public Property Entidade() As enTipoEntidade
        Get
            If ViewState("Entidade") Is Nothing Then
                Return 0
            End If
            Return ViewState("Entidade")
        End Get
        Set(ByVal value As enTipoEntidade)
            ViewState("Entidade") = value
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            If ViewState("Enabled") Is Nothing Then
                Return True
            End If
            Return ViewState("Enabled")
        End Get
        Set(ByVal value As Boolean)
            ViewState("Enabled") = value
        End Set
    End Property


#End Region

    Public Overrides Sub DataBind()
        Dim per As New clsPermissao
        grdRoles.DataSource = per.Listar()
        grdRoles.DataBind()
        per = Nothing
    End Sub

    Public Property IDCargo() As Integer
        Get
            Return ViewState("IDCargo")
        End Get
        Set(ByVal value As Integer)
            If ViewState("IDCargo") <> value Then
                ViewState("IDCargo") = value
                DataBind()
            End If
        End Set
    End Property

    Protected Sub grdRoles_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRoles.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Entidade = enTipoEntidade.Usuario Then
                Dim car As New clsCargo
                Dim cls As New clsUsuario
                Dim chk As CheckBox = e.Row.FindControl("chk")
                If car.Permissoes.Contains(grdRoles.DataKeys(e.Row.RowIndex).Values(0), IDCargo) Then
                    chk.Enabled = False
                    chk.Checked = True
                    chk.Text = "concedida pelo cargo"
                Else
                    chk.Enabled = True
                    chk.Checked = cls.Permissoes.Contains(grdRoles.DataKeys(e.Row.RowIndex).Values(0), IDReferencia)
                    'chk.Checked = Roles.IsUserInRole(cls.login, grdRoles.DataKeys(e.Row.RowIndex).Values(1))
                End If
            End If
        End If
    End Sub

    Public Sub NotifyDelete(ByVal vEntidade As Geral.enTipoEntidade, ByVal vID As Integer) Implements XMWebEditPage.IEditPageObserver.NotifyDelete

    End Sub

    Public Sub NotifyInflate(ByVal vEntidade As Geral.enTipoEntidade, ByVal vID As Integer) Implements XMWebEditPage.IEditPageObserver.NotifyInflate
        IDReferencia = vID
        Entidade = vEntidade
        DataBind()
    End Sub

    Public Sub NotifyUpdate(ByVal vEntidade As Geral.enTipoEntidade, ByVal vID As Integer) Implements XMWebEditPage.IEditPageObserver.NotifyUpdate

        If vEntidade = enTipoEntidade.Usuario Then
            Dim cls As New clsUsuario
            cls.Load(vID)
            For Each row As GridViewRow In grdRoles.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chk As CheckBox = CType(row.FindControl("chk"), CheckBox)
                    If chk.Enabled Then
                        Dim strRole As String = grdRoles.DataKeys(row.DataItemIndex).Values(1)
                        If strRole <> "" Then
                            If Roles.IsUserInRole(cls.login, strRole) Then
                                If chk.Checked = False Then Roles.RemoveUserFromRole(cls.login, strRole)
                            Else
                                If chk.Checked = True Then Roles.AddUserToRole(cls.login, strRole)
                            End If
                        End If
                    End If
                End If
            Next
        End If
    End Sub

End Class

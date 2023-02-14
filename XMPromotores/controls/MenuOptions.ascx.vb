Namespace XMControls

    <Themeable(True)> _
    Partial Class MenuOptions
        Inherits System.Web.UI.UserControl
        Protected WithEvents m_mnuSuperior As Menu
        Protected WithEvents m_mnuLateral As Menu



        Public Property SideMenuUseImage() As Boolean
            Get
                If ViewState("SideMenuUseImage") Is Nothing Then
                    Return False
                Else
                    Return ViewState("SideMenuUseImage")
                End If
            End Get
            Set(ByVal value As Boolean)
                ViewState("SideMenuUseImage") = value
            End Set
        End Property

        Public Property TopMenuVisible() As Boolean
            Get
                If ViewState("TopMenuVisible") Is Nothing Then
                    Return True
                Else
                    Return ViewState("TopMenuVisible")
                End If
            End Get
            Set(ByVal value As Boolean)
                ViewState("TopMenuVisible") = value
            End Set
        End Property

        Public Property SideMenuVisible() As Boolean
            Get
                If ViewState("SideMenuVisible") Is Nothing Then
                    Return True
                Else
                    Return ViewState("SideMenuVisible")
                End If
            End Get
            Set(ByVal value As Boolean)
                ViewState("SideMenuVisible") = value
            End Set
        End Property

        Public Property SideMenuShowFirstNode() As Boolean
            Get
                If ViewState("SideMenuShowFirstNode") Is Nothing Then
                    Return True
                Else
                    Return ViewState("SideMenuShowFirstNode")
                End If
            End Get
            Set(ByVal value As Boolean)
                ViewState("SideMenuShowFirstNode") = value
            End Set
        End Property

        Public Property TopMenuShowFirstNode() As Boolean
            Get
                If ViewState("TopMenuShowFirstNode") Is Nothing Then
                    Return False
                Else
                    Return ViewState("TopMenuShowFirstNode")
                End If
            End Get
            Set(ByVal value As Boolean)
                ViewState("TopMenuShowFirstNode") = value
            End Set
        End Property

        Public Property SideMenuCascading() As Boolean
            Get
                If ViewState("SideMenuCascading") Is Nothing Then
                    Return True
                Else
                    Return ViewState("SideMenuCascading")
                End If
            End Get
            Set(ByVal value As Boolean)
                ViewState("SideMenuCascading") = value
            End Set
        End Property

        <Themeable(False)> _
        Public Property IDMenuSuperior() As String
            Get
                Return ViewState("IDMenuSuperior") & ""
            End Get
            Set(ByVal value As String)
                ViewState("IDMenuSuperior") = value
            End Set
        End Property

        <Themeable(False)> _
        Public Property IDMenuLateral() As String
            Get
                Return ViewState("IDMenuLateral") & ""
            End Get
            Set(ByVal value As String)
                ViewState("IDMenuLateral") = value
            End Set
        End Property

        Private Function GetControl(ByVal vID As String) As Control
            Dim component As Control = Nothing
            Try
                component = Me.NamingContainer.FindControl(vID)
                If (component Is Nothing) Then
                    Return Nothing
                End If
            Catch

            End Try
            Return component
        End Function


        Protected Function isSelected(ByVal url As String) As Boolean
            Dim blnReturn As Boolean = False
            Dim strCurrentURL As String = Me.Request.AppRelativeCurrentExecutionFilePath.ToLower()
            If url.ToLower = strCurrentURL Then
                blnReturn = True
            Else
                Dim root As SiteMapNode = SiteMap.RootNode
                Dim allnodes As SiteMapNodeCollection = root.GetAllNodes

                For Each n As SiteMapNode In allnodes
                    If n.Url.ToLower = url Then
                        Dim childnodes As SiteMapNodeCollection = n.GetAllNodes()
                        For Each s As SiteMapNode In childnodes
                            If s.Url.ToLower = strCurrentURL Then
                                Return True
                            End If
                        Next
                    End If
                Next
            End If
            Return blnReturn
        End Function

        Protected Sub m_mnuSuperior_MenuItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles m_mnuSuperior.MenuItemDataBound
            If SideMenuCascading And SideMenuVisible Then
                e.Item.Selected = isSelected(e.Item.NavigateUrl)
                
                If Not String.IsNullOrEmpty(e.Item.DataItem("imgTop")) Then
                    e.Item.Text = "<img border='0' src='" & ResolveClientUrl(e.Item.DataItem("imgTop")) & "' />"
                End If
                
                If e.Item.Selected Then
                    dtsSiteMapLateral.StartingNodeUrl = e.Item.NavigateUrl
                End If
                If Not e.Item.DataItem("Enabled") Is Nothing Then
                    If e.Item.DataItem("Enabled") = False Then e.Item.Enabled = False
                End If
            End If
        End Sub

        Protected ReadOnly Property MenuLateral() As Menu
            Get
                If m_mnuLateral Is Nothing Then
                    m_mnuLateral = GetControl(IDMenuLateral)
                End If
                Return m_mnuLateral
            End Get
        End Property

        Protected ReadOnly Property MenuSuperior() As Menu
            Get
                If m_mnuSuperior Is Nothing Then
                    m_mnuSuperior = GetControl(IDMenuSuperior)
                End If
                Return m_mnuSuperior
            End Get
        End Property


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then

                'Binding Menus
                If Not MenuSuperior Is Nothing Then
                    dtsSiteMapSuperior.ShowStartingNode = TopMenuShowFirstNode
                    With MenuSuperior
                        .Visible = TopMenuVisible
                        .DataSource = dtsSiteMapSuperior
                        .DataBind()
                    End With
                End If
                If Not MenuLateral Is Nothing Then
                    If Not SideMenuCascading Then dtsSiteMapLateral.ShowStartingNode = SideMenuShowFirstNode
                    With MenuLateral
                        .Visible = SideMenuVisible
                        .DataSource = dtsSiteMapLateral
                        .DataBind()
                    End With
                End If
            End If

        End Sub

        Protected Sub m_mnuLateral_MenuItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles m_mnuLateral.MenuItemDataBound
            If SideMenuUseImage Then e.Item.ImageUrl = e.Item.DataItem("img")
            If Not e.Item.DataItem("Enabled") Is Nothing Then
                If e.Item.DataItem("Enabled") = False Then e.Item.Enabled = False
            End If
        End Sub

        Protected Sub m_mnuLateral_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_mnuLateral.PreRender
            Try
                For i As Integer = m_mnuLateral.Items.Count - 1 To 0 Step -1
                    Dim m As MenuItem = m_mnuLateral.Items(i)
                    If Not m.Enabled Then
                        m_mnuLateral.Items.Remove(m)
                    End If
                Next
            Catch
            End Try
        End Sub

        Protected Sub m_mnuSuperior_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_mnuSuperior.PreRender
            Try
                For i As Integer = m_mnuSuperior.Items.Count - 1 To 0 Step -1
                    Dim m As MenuItem = m_mnuSuperior.Items(i)
                    If Not m.Enabled Then
                        m_mnuSuperior.Items.Remove(m)
                    End If
                Next
            Catch
            End Try
        End Sub
    End Class

End Namespace

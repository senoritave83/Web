
Partial Class Principal2
    Inherits System.Web.UI.MasterPage

    Private m_strAjudaTela As String = ""

    Protected ReadOnly Property AjudaTela() As String
        Get
            Return m_strAjudaTela
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            SiteMapPath1.Provider = SiteMapDataSource1.Provider
            SiteMapPath1.DataBind()


        End If
    End Sub

    Protected Sub SiteMapPath1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SiteMapNodeItemEventArgs) Handles SiteMapPath1.ItemDataBound
        If e.Item.ItemType = SiteMapNodeItemType.Current Then
            'ltrDescricao.Text = "<p>" & e.Item.SiteMapNode.Description & "</p>"
            'ltrDescricao.Text = e.Item.SiteMapNode.Description
            ltrDescricao.Text = e.Item.SiteMapNode.Description
            If Not e.Item.SiteMapNode("ajuda") Is Nothing Then
                m_strAjudaTela = e.Item.SiteMapNode("ajuda")
                lnkAjudaTela.HRef = ResolveUrl("~/ajuda/" & m_strAjudaTela)
                lnkAjudaTela.Visible = True
            ElseIf Not e.Item.SiteMapNode("AJUDA") Is Nothing Then
                m_strAjudaTela = e.Item.SiteMapNode("AJUDA")
                lnkAjudaTela.HRef = ResolveUrl("~/ajuda/" & m_strAjudaTela)
                lnkAjudaTela.Visible = True
            Else
                lnkAjudaTela.Visible = False
                m_strAjudaTela = ""
                ltrScriptAjuda.Text = "function fncClickAjuda() {" & vbCrLf & "return false;" & vbCrLf & "}"
            End If
        End If

    End Sub

    Protected Function verificaArea(ByVal vIdArea As Integer) As String
        On Error Resume Next
        Dim strReturn As String = ""

        If SiteMap.CurrentNode.Item("Area") = vIdArea Then
            strReturn = "class='on'"
        End If

        Return strReturn

    End Function

    Protected Function verificaAcesso() As String
        Dim strReturn As String = ""
        Try
            If HttpContext.Current.Session.Item("Administrador") Then

                strReturn = "<li " & verificaArea(4) & "><a " & verificaArea(4) & "href='../configuracoes/default.aspx'><span><span>Configura&ccedil;&otilde;es</span></span></a></li>"
            End If
        Catch
            Response.Redirect("../home/sair.aspx")
        End Try

        Return strReturn
    End Function

End Class


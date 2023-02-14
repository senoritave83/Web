
Partial Class ajuda_Default
    Inherits XMProtectedPage

    Private Sub btnVoltar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("../home/default.aspx")
    End Sub

    'Private Sub fn_CarregaAjuda()
    '    Dim oAjuda As clsAjuda = New clsAjuda()
    '    Dim oDs As DataSet = oAjuda.fn_PNOL_SEL_ONLINE_HELP_ARVORE_WEB(1)


    '    'Dim Nodex As TreeNode

    '    'TreeView.CssClass = "TreeView"
    '    'TreeView.TreeStyle = VASPTVv4NET.ASPTreeView.ASPCCTreeStyle.tvwTreelinesPlusMinusPictureText
    '    'TreeView.LineStyle = VASPTVv4NET.ASPTreeView.ASPCCTreeLineStyle.tvwRootLines
    '    'TreeView.ImagePath = "../images/treeview"
    '    'TreeView.AutoScrolling = False
    '    'TreeView.SingleSelect = False
    '    'TreeView.QueryString = "" 'strNOLU=" + Request["strNOLU"] + "&strNOLP=" + Request["strNOLP"] + "&strNOLK=" + Request["strNOLK"] + "&intCodigo=" + Request["intCodigo"] + "&strTipo=" + Request["strTipo"] + "&strChave=" +  Request["strChave"] + "&strUsuario=" + Request["strUsuario"]
    '    'TreeView.LicenseKey = ""
    '    'TreeView.CheckBoxes = True
    '    'TreeView.UpLevelClientTree = False

    '    For Each oDr As DataRow In oDs.Tables(0).Rows


    '        'Nodex = New TreeNode()
    '        'Nodex.

    '        '    If IsDBNull(oDr("cd_item_online_help_pai")) Then
    '        '        Nodex.Relative = Nothing
    '        '    Else
    '        '        Nodex.Relative = "Item_" + oDr("cd_item_online_help_pai").ToString()
    '        '        Nodex.Relationship = VASPTVv4NET.ASPTreeView.ASPCCTreeRelationship.tvwChild
    '        '    End If
    '        '    Nodex.Key = "Item_" + oDr("CD_ITEM_ONLINE_HELP").ToString()
    '        '    Nodex.Text = oDr("NM_ITEM_ONLINE_HELP").ToString()
    '        '    If oDr("NM_LINK_ONLINE_HELP").ToString().Substring(0, 7).ToLower() = "http://" Then
    '        '        Nodex.URL = oDr("NM_LINK_ONLINE_HELP").ToString()
    '        '    Else
    '        '        Nodex.URL = "" + oDr("NM_LINK_ONLINE_HELP").ToString()
    '        '    End If
    '        '    Nodex.Target = "frmHelp"
    '        '    Nodex.ToolTipText = oDr("NM_ITEM_ONLINE_HELP").ToString()
    '        '    TreeView.Node = Nodex
    '    Next

    'End Sub

    	
    Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.SelectedNodeChanged
        Dim ob As Object = sender
        Dim s As String = TreeView1.SelectedNode.Value
        frmHelp.Attributes("src") = s

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        TreeView1.Attributes.Add("onSelectedIndexChange", "fncClick();")
    End Sub
End Class

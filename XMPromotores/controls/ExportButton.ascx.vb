
Partial Class controls_ExportButton
    Inherits System.Web.UI.UserControl

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If TypeOf (Me.Page) Is XMWebPage Then
            Dim wp As XMWebPage = CType(Me.Page, XMWebPage)
            Dim strName As String = wp.Request.Path.Substring(wp.Request.Path.LastIndexOf("/") + 1)
            'ltrExportar.Text = "<script type='text/javascript'>" & Environment.NewLine & "function fncExportar(){" & Environment.NewLine & "window.open('export/" & strName & "?" & wp.GetFiltroURL() & "', 'export', 'width=400, height=300, resizable=1,  ')" & Environment.NewLine & "}" & Environment.NewLine & "fncExportar();" & Environment.NewLine & "</script>"
            Dim strParams As String = wp.GetFiltroURL()
            strParams = strParams & IIf(strParams = "", "", "&") & Parameters
            hid_export.Value = "export/" & strName & "?" & strParams
        End If
    End Sub

    Public Property Parameters() As String
        Get
            Return ViewState("Parameters")
        End Get
        Set(ByVal value As String)
            ViewState("Parameters") = value
        End Set
    End Property


End Class

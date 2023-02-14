Public Class PesquisatTabelaTipoObras

    Inherits XMWebPage

    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dtgTiposObras As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable

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
        Dim TiposSubTipos As New clsTipos()
        dtgTiposObras.DataSource = TiposSubTipos.ListTiposHome()
        dtgTiposObras.DataBind()
        TiposSubTipos = Nothing
    End Sub

    Public Function SubTipos(ByVal IdTipo As Integer) As DataSet
        Dim TiposSubTipos As New clsTipos()
        Return TiposSubTipos.ListSubTiposHome(IdTipo)
        TiposSubTipos = Nothing
    End Function

    Private Sub dtgTiposObras_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgTiposObras.ItemDataBound

        With e.Item
            Dim rv As DataRow
            If .ItemType = ListItemType.AlternatingItem OrElse .ItemType = ListItemType.Item OrElse .ItemType = ListItemType.EditItem Then
                rv = CType(.DataItem, DataRowView).Row
                ' Change color
                If Not IsDBNull(rv("IdSegmento")) Then
                    Select Case rv("IdSegmento")
                        Case 1
                            .CssClass = "Industrial"
                        Case 2
                            .CssClass = "Comercial"
                        Case 3
                            .CssClass = "Residencial"
                    End Select
                End If
            End If
        End With

    End Sub

End Class

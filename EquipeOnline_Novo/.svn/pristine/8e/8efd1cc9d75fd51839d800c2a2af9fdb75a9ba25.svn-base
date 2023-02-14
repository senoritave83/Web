
Partial Class configuracoes_Etapas
    Inherits XMProtectedPage

    Private cls As clsEtapa

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsEtapa
        If Not IsPostBack Then
            BindGrid()
        End If
    End Sub

    Public Sub BindGrid()
        rptEtapas.DataSource = cls.Listar()
        rptEtapas.DataBind()
    End Sub

    Private Sub btnVoltar_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("default2.aspx")
    End Sub

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSalvar.Click
        Dim intPos As Integer = 1
        For Each row As RepeaterItem In rptEtapas.Items
            If row.ItemType = ListItemType.AlternatingItem Or row.ItemType = ListItemType.Item Then
                Dim txtEtapa As TextBox = row.FindControl("txtEtapa")
                Dim hidIDEtapa As HiddenField = row.FindControl("")
                Dim clrEtapa As controls.xmcolor = row.FindControl("clrEtapa")
                cls.Gravar(intPos, txtEtapa.Text, clrEtapa.Color)
                intPos += 1
            End If
        Next
        BindGrid()
        MostraGravado("default2.aspx")
    End Sub
End Class

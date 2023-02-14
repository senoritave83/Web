
Partial Class home_recados
    Inherits XMProtectedPage

    Protected clsRec As clsRecados

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsRec = New clsRecados()
        If Not IsPostBack Then

            ViewState("CurrentPage") = 0

            cboDestinatario.Items.Clear()
            Dim lst As ListItem, dr As IDataReader
            dr = clsRec.Destinatarios()
            Do While dr.Read
                lst = New ListItem(Server.HtmlDecode(dr.GetString(dr.GetOrdinal("NOME"))), dr.GetString(dr.GetOrdinal("IDDEST")))
                cboDestinatario.Items.Add(lst)
            Loop
            BindGrid()
        End If
    End Sub

    Public Sub BindGrid()
        dtgGrid.DataSource = clsRec.Listar(ViewState("Sort") & "", ViewState("CurrentPage"), 10)
        dtgGrid.DataBind()
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEnviar.Click
        Dim blnGrupo As Boolean
        If Not cboDestinatario.SelectedItem Is Nothing Then
            blnGrupo = (Left(cboDestinatario.SelectedItem.Value, 1) = "1")
            If clsRec.Enviar(blnGrupo, cboDestinatario.SelectedItem.Value.Substring(2), txtMensagem.Text) Then
                MostraGravado("recados.aspx?")
            Else
                lblMensagem.Visible = True
            End If
        End If
    End Sub

    Public Sub rptGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)

        If e.CommandName = "Order" Then
            ViewState("Desc") = Not ViewState("Desc")
            ViewState("Sort") = e.CommandArgument
        ElseIf e.CommandName = "Paginate" Then
            If e.CommandArgument = "inc" Then
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            Else
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            End If
        End If

        BindGrid()

    End Sub

End Class

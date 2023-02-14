
Partial Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim cls As New Classes.clsMensagemGeral
            rptMensagens.DataSource = cls.Listar()
            rptMensagens.DataBind()
        End If
    End Sub
End Class

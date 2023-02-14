Public Class SelecionaImagem
    Inherits System.Web.UI.Page
    Protected WithEvents ltHTML As System.Web.UI.WebControls.Literal
    Protected WithEvents fl As System.Web.UI.HtmlControls.HtmlInputFile

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

        If Page.IsPostBack Then
            Try

                Dim NomeArquivo As String = System.IO.Path.GetFileName(fl.PostedFile.FileName)
                fl.PostedFile.SaveAs(Server.MapPath("") & "\imagensindices\" & NomeArquivo)

                Dim strJavaScript As String = "<script language=""javascript"">" & vbCrLf
                strJavaScript += "window.opener.frmCad.txtNomeArquivo.value = '" & NomeArquivo & "';" & vbCrLf
                strJavaScript += "window.close();"
                strJavaScript += "</script>"
                ltHTML.Text = strJavaScript

            Catch ex As Exception
                ltHTML.Text = "<script>alert('Erro ao tentar carregar imagem \n" & ex.Message.ToUpper & "');</script>"
            End Try
        End If

    End Sub

End Class

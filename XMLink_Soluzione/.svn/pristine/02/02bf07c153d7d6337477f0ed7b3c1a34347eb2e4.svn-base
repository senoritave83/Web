Imports System.Xml

Public Class FotosThumb
    Inherits XMWebPage

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strServerPath As String = GetSetting("ImagePath", "")  'Server.MapPath("~/img_data/") ' Initialize objects
        Dim objImage, objThumbnail As System.Drawing.Image
        Dim strFilename As String
        Dim shtWidth, shtHeight As Short

        strFilename = strServerPath & "\" & Request.QueryString("filename")

        '*****************************************************
        'VERIFICA O NOME DO ARQUIVO PASSADO OU A IMAGEM PADRÃO
        '*****************************************************
        Try
            objImage = objImage.FromFile(strFilename)
        Catch ex As Exception
            objImage = objImage.FromFile(strServerPath & "\error.gif")
        End Try
        '*****************************************************
        'VERIFICA A LARGURA PASSADA
        '*****************************************************
        If Request.QueryString("width") = Nothing Then
            shtWidth = objImage.Width
        ElseIf Request.QueryString("width") < 1 Then
            shtWidth = 100
        Else
            shtWidth = Request.QueryString("width")
        End If
        '*****************************************************
        'CALCULA A ALTURA PROPORCIONAL
        '*****************************************************
        shtHeight = objImage.Height / (objImage.Width / shtWidth)

        '*****************************************************
        'CRIA O THUMBNAIL
        '*****************************************************
        objThumbnail = objImage.GetThumbnailImage(shtWidth, shtHeight, Nothing, System.IntPtr.Zero)
        Response.ContentType = "image/jpeg"
        objThumbnail.Save(Response.OutputStream, Imaging.ImageFormat.Jpeg)
        objImage.Dispose()
        objThumbnail.Dispose()

    End Sub

End Class

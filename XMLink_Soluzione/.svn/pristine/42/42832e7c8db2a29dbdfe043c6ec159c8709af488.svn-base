Imports System.Drawing

Public Class Foto    

    Inherits XMWebPage
    Protected WithEvents imgImagem As System.Web.UI.WebControls.Image

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnFiltrar As System.Web.UI.WebControls.Button
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents imgRotateUW As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgRotateCW As System.Web.UI.WebControls.ImageButton

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

        Response.Expires = 0
        Response.ExpiresAbsolute = Now().AddSeconds(-1)
        Response.AddHeader("pragma", "no-cache")
        Response.AddHeader("cache-control", "private")
        Response.CacheControl = "no-cache"

        Dim strServerPath As String = GetSetting("ImagePath", "")  'Server.MapPath("~/img_data/") ' Initialize objects
        Dim strFilename As String = ""

        If Not Page.IsPostBack Then

            If Request("img") <> "" Then

                Dim img As Image = Nothing

                Try

                    strFilename = strServerPath & "\" & Request.QueryString("img")
                    img = Image.FromFile(strFilename)
                    imgImagem.ImageUrl = ResolveUrl("~/../img_data/" & Request("img") & "?tmr=" & System.Environment.TickCount)

                    If CheckPermission("Consulta de Fotos", "Modificar Aparencia") Then
                        imgRotateUW.Visible = True
                        imgRotateCW.Visible = True
                    Else
                        imgRotateUW.Visible = False
                        imgRotateCW.Visible = False
                    End If

                Catch ex As Exception

                    imgImagem.ImageUrl = ResolveUrl("~/img_data/error.gif?tmr=" & System.Environment.TickCount)
                    imgImagem.Width = System.Web.UI.WebControls.Unit.Pixel(150)
                    imgImagem.Height = System.Web.UI.WebControls.Unit.Pixel(150)

                    imgRotateUW.Visible = False
                    imgRotateCW.Visible = False

                Finally

                    If Not img Is Nothing Then
                        img.Dispose()
                    End If
                    img = Nothing

                End Try

            End If


        End If

    End Sub

    Private Sub imgRotateUW_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgRotateUW.Click
        'Dim strPath As String = Server.MapPath("~/img_data/")
        'Dim bitmap As New Bitmap(strPath & Request("img"))
        'Dim btm_out As Bitmap = RotateImage(Bitmap, 90)
        'btm_out.Save(strPath & Request("img"))

        Dim strPath As String = Server.MapPath("~/img_data/")
        Dim strImage As String = strPath & Request("img")
        Dim img As Image = Image.FromFile(strImage)
        img.RotateFlip(RotateFlipType.Rotate270FlipNone)
        img.Save(strImage, System.Drawing.Imaging.ImageFormat.Jpeg)
        img.Dispose()
        img = Nothing

        Response.Redirect("foto.aspx?img=" & Request("img") & "&tmr=" & System.Environment.TickCount)

    End Sub

    Private Sub imgRotateCW_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgRotateCW.Click

        Dim strPath As String = Server.MapPath("~/img_data/")
        Dim strImage As String = strPath & Request("img")
        Dim img As Image = Image.FromFile(strImage)
        img.RotateFlip(RotateFlipType.Rotate90FlipNone)
        img.Save(strImage, System.Drawing.Imaging.ImageFormat.Jpeg)
        img.Dispose()
        img = Nothing

        Response.Redirect("foto.aspx?img=" & Request("img") & "&tmr=" & System.Environment.TickCount)

    End Sub
End Class
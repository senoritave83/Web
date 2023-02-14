<%@ WebHandler Language="VB" Class="Thumbnail" %>

Imports System
Imports System.Web
Imports System.Drawing
Imports XMSistemas.XMVirtualFile

Public Class Thumbnail : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        
        Dim objImage, objThumbnail As System.Drawing.Image
        Dim shtWidth, shtHeight As Short

        

        '*****************************************************
        'VERIFICA O NOME DO ARQUIVO PASSADO OU A IMAGEM PADRÃO
        '*****************************************************
        Dim stm As XMFileStream
        If VirtualFile.FileExists(context.Request.QueryString("filename")) Then
            stm = New XMFileStream(context.Request.QueryString("filename"), IO.FileMode.Open)
        Else
            stm = New XMFileStream(XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl(ConfigurationManager.AppSettings("DirFotos")) & _
                                   "noimage.png", IO.FileMode.Open)
        End If

        objImage = Image.FromStream(stm)
        
        '*****************************************************
        'VERIFICA A LARGURA PASSADA
        '*****************************************************
        If context.Request.QueryString("width") = Nothing Then
            shtWidth = objImage.Width
        ElseIf context.Request.QueryString("width") < 1 Then
            shtWidth = 100
        Else
            shtWidth = context.Request.QueryString("width")
        End If
        '*****************************************************
        'CALCULA A ALTURA PROPORCIONAL
        '*****************************************************
        shtHeight = objImage.Height / (objImage.Width / shtWidth)

        '*****************************************************
        'CRIA O THUMBNAIL
        '*****************************************************
        objThumbnail = objImage.GetThumbnailImage(shtWidth, shtHeight, Nothing, System.IntPtr.Zero)
        context.Response.ContentType = "image/jpeg"
        objThumbnail.Save(context.Response.OutputStream, Imaging.ImageFormat.Jpeg)
        objImage.Dispose()
        objThumbnail.Dispose()
        
        stm.Close()
        stm = Nothing
        
        
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class
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
            stm = New XMFileStream(context.Request.QueryString("filename"), IO.FileMode.Open, IO.FileAccess.Read)
        Else
            stm = New XMFileStream("~/imagens/noimage.png", IO.FileMode.Open, IO.FileAccess.Read)
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
        '***********************************************************************
        'CONDIÇÃO CRIADA P/ UTILIZAR O COMPONENTE NA PÁGINA CATALOGOPRODUTO.ASPX
        '***********************************************************************
        If Not context.Request.QueryString("height") Is Nothing Then
            
            If shtHeight > context.Request.QueryString("height") Then
                
                shtWidth = objImage.Width / (objImage.Height / context.Request.QueryString("height"))
                objThumbnail = objImage.GetThumbnailImage(shtWidth, context.Request.QueryString("height"), Nothing, System.IntPtr.Zero)
            Else
                objThumbnail = objImage.GetThumbnailImage(shtWidth, shtHeight, Nothing, System.IntPtr.Zero)
            End If
        Else
            objThumbnail = objImage.GetThumbnailImage(shtWidth, shtHeight, Nothing, System.IntPtr.Zero)
        End If
        
        context.Response.ContentType = "image/jpeg"
        objThumbnail.Save(context.Response.OutputStream, Imaging.ImageFormat.Jpeg)
        
        stm.Close()
        
        objImage.Dispose()
        objThumbnail.Dispose()
        stm.Dispose()
        
        objImage = Nothing
        objThumbnail = Nothing
        stm = Nothing        
        
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class
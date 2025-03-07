﻿Imports System.Drawing
Imports System.Configuration.ConfigurationManager
Imports System.IO
Imports XMSistemas.XMVirtualFile

Partial Class Sistema_Foto_popup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            ViewState("src") = Request("src")
            ViewState("name") = Request("name")
            imgfoto.Src = ViewState("src")
            '& "?dt=" & Now.ToString("ddMMyyyyhhmmsstt")
            imgfoto.Alt = ViewState("name")
        End If
    End Sub

    Public Sub Rotate(ByVal Way As String)
        Dim img As Image
        Dim path As String
        path = AppSettings("PhotoPath") & ViewState("name")
        Dim vf As New XMSistemas.XMVirtualFile.XMFileStream(path, FileMode.Open)

        Try
            img = Image.FromStream(vf)
            Dim img2 As Imaging.ImageFormat = New Imaging.ImageFormat(img.RawFormat.Guid)

            If Way = "Left" Then

                img.RotateFlip(RotateFlipType.Rotate90FlipXY)
            Else

                img.RotateFlip(RotateFlipType.Rotate270FlipXY)
            End If

            vf.Position = 0
            img.Save(vf, img2)
            vf.Close()
            img.Dispose()

            imgfoto.Src = ViewState("src")
            '& "?dt=" & Now.ToString("ddMMyyyyhhmmsstt")

            VirtualFile.CheckFile(path)

        Catch

            btnRotateLeft.Visible = False
            btnRotateRight.Visible = False
            imgfoto.Visible = False
            Response.Write("Erro ao tentar girar a foto!")
        End Try
    End Sub

    Protected Sub btnRotateLeft_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnRotateLeft.Click
        Rotate("Left")
    End Sub

    Protected Sub btnRotateRight_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnRotateRight.Click
        Rotate("Right")
    End Sub
End Class

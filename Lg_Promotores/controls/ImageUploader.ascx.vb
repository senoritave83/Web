Imports XMSistemas.XMVirtualFile
Imports System.IO

Partial Class inc_ImageUploader
    Inherits System.Web.UI.UserControl
    Private _hasErrors As Boolean = False
    Private _Imagem As String

    Public Event onSavingFile(ByRef filename As String)
    Public Event onFileSaved(ByRef filename As String)


    Public Property VirtualPath() As String
        Get
            Return ViewState("VirtualPath")
        End Get
        Set(ByVal Value As String)
            If Not Value.EndsWith("/") Then Value &= "/"
            ViewState("VirtualPath") = Value
        End Set
    End Property


    Public Property NoImage() As String
        Get
            If ViewState("NoImage") Is Nothing Then
                Return ""
            End If
            Return ViewState("NoImage")
        End Get
        Set(ByVal value As String)
            ViewState("NoImage") = value
        End Set
    End Property

    Public Property ShowSaveButton() As Boolean
        Get
            If ViewState("ShowSaveButton") Is Nothing Then
                Return True
            End If
            Return ViewState("ShowSaveButton")
        End Get
        Set(ByVal value As Boolean)
            ViewState("ShowSaveButton") = value
        End Set
    End Property

    Public Sub Gravar(ByVal vName As String)
        If filImagem.HasFile Then
            RaiseEvent onSavingFile(vName)
            Dim s As New XMFileStream(VirtualPath & vName, FileMode.Create)
            Try
                Dim buffer(255) As Byte
                Dim intBytesRead As Integer = 0

                intBytesRead = filImagem.PostedFile.InputStream.Read(buffer, 0, 255)
                Do While intBytesRead > 0
                    s.Write(buffer, 0, intBytesRead)
                    intBytesRead = filImagem.PostedFile.InputStream.Read(buffer, 0, 255)
                Loop
                s.Flush()
            Finally
                s.Close()
                s.Dispose()
            End Try
            Imagem = vName
            RaiseEvent onFileSaved(vName)
        End If

        '        flImagem.PostedFile.SaveAs(vPath & NomeImagem)
    End Sub

    Public Sub Gravar()
        If filImagem.HasFile Then
            Dim temp As String = filImagem.PostedFile.FileName
            If InStrRev(temp, "\") > 0 Then
                temp = temp.Substring(InStrRev(temp, "\"))
            End If

            Gravar(filImagem.PostedFile.FileName)
        End If

    End Sub


    Public Enum Tela
        Upload
        Edicao
    End Enum

    Private Function getTela() As Tela
        If divEdicao.Visible = True Then
            Return Tela.Edicao
        Else
            Return Tela.Upload
        End If
    End Function

    Private Sub MontaTela(ByVal obTela As inc_ImageUploader.Tela)
        Select Case obTela
            Case Tela.Upload
                divEdicao.Visible = False
                divUpload.Attributes.Remove("style")
                divUpload.Visible = True
                'divImagem.Visible = False
            Case Tela.Edicao
                divEdicao.Visible = True
                divUpload.Attributes.Add("style", "display:none;")
                'divImagem.Visible = True
        End Select
    End Sub

    Public Property Imagem() As String
        Get
            Return ViewState("Imagem")
        End Get
        Set(ByVal value As String)
            Me._Imagem = value
            ViewState("Imagem") = Me._Imagem
            If value = "" Then
                img.ImageUrl = VirtualFile.GetDirectAccessUrl(VirtualPath & NoImage)
            ElseIf Not VirtualFile.FileExists(VirtualPath & value) Then
                img.ImageUrl = VirtualFile.GetDirectAccessUrl(VirtualPath & NoImage)
            Else
                img.ImageUrl = VirtualFile.GetDirectAccessUrl(VirtualPath & value)
            End If
        End Set
    End Property

    Public ReadOnly Property HasPostedFile() As Boolean
        Get
            Return filImagem.HasFile
        End Get
    End Property


    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btTroca.Attributes.Add("onclick", "sDiv(" & Me.ClientID & "_divUpload);hDiv(" & Me.ClientID & "_divEdicao);fncTrocaImagem(" & img.ClientID & ", true)")
        If ShowSaveButton Then
            btnVoltar.Attributes.Add("onclick", "hDiv(" & Me.ClientID & "_divUpload);sDiv(" & Me.ClientID & "_divEdicao);if (this.value.length == 0) " & btnSubir.ClientID & ".disabled = true;fncTrocaImagem(" & img.ClientID & ", false)")
            filImagem.Attributes.Add("onChange", "if (this.value.length > 0) " & btnSubir.ClientID & ".disabled = false;")
            plhBotoes.Visible = True
        Else
            plhBotoes.Visible = False
        End If
    End Sub

    Protected Sub btnSubir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubir.Click
        Gravar()
    End Sub


End Class

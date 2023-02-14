Imports Ionic.Utils.Zip
Imports XMSistemas.Web.Base


Partial Class integracao_importar
    Inherits XMProtectedPage
    Dim cls As clsIntegracao

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("default.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsIntegracao()
        If Not Page.IsPostBack Then


            'Verifica permissões
            'btnEnviar.Enabled = Me.Identity.Administrador
            GridView1.Columns.Item(5).Visible = Me.Identity.Administrador

            BindGrid()
        End If
    End Sub

    Public Sub BindGrid()
        'Dim ret As IPaginaResult = cls.Listar(ViewState("Filtro"),txtDataInicial.Text, txtDataFinal.Text, cboTipo.SelectedValue, cboStatus.SelectedValue, SortExpression, SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
        Dim ret As IPaginaResult = cls.Listar(Paginate1.Filtro, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, Paginate1.PageSize)
        GridView1.DataSource = ret.Data
        GridView1.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()
        ret = Nothing

        ltrEspacoTotal.Text = FormatBytes(cls.Espaco.Total)
        ltrEspacoUtilizado.Text = FormatBytes(cls.Espaco.Utilizado)
        ltrEspacoLivre.Text = FormatBytes(cls.Espaco.Livre)
        ltrTamanhoMaximo.Text = FormatBytes(cls.Espaco.Livre)
    End Sub

    Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        BindGrid()
    End Sub

    Protected Function FormatBytes(ByVal vBytes As Integer) As String
        Dim nBytes As Integer
        Dim nBytes2 As Integer
        Dim nBytesConverted As String
        nBytes = Val(vBytes / 1024)
        nBytes2 = Val(nBytes / 1024)
        Select Case Len(vBytes)
            Case 1, 2, 3
                'BYTES
                nBytesConverted = vBytes & " Bytes"
            Case 4, 5, 6
                'KILO BYTES
                nBytesConverted = Format((vBytes / 1024), "0.00 KB")
            Case Else
                If Len(nBytes2) <= 3 Then
                    'MEGA BYTES
                    nBytesConverted = Format((nBytes2), "0 MB")
                Else
                    'GIGA BYTES
                    nBytesConverted = Format((nBytes2 / 1024), "0.00 GB")
                End If
        End Select
        FormatBytes = nBytesConverted
    End Function

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Processar" Then
            Dim strArquivo As String = e.CommandArgument
            Try
                If Not FileExists(strArquivo) Then
                    cls.GravaDetalhes(strArquivo, "Arquivo " & strArquivo & " não encontrado")
                    Exit Try
                End If
                cls.ProcessarArquivo(strArquivo, cls.GetPath)
            Catch ex As System.Exception
                cls.GravaDetalhes(strArquivo, "Erro: " & ex.Message)
            Finally
                BindGrid()
            End Try
        ElseIf e.CommandName = "Excluir" Then
            Dim strArquivo As String = e.CommandArgument
            cls.Delete(strArquivo)
            If FileExists(strArquivo) Then
                System.IO.File.Delete(cls.GetPath() & strArquivo)
            End If
            BindGrid()
        End If
    End Sub

    Protected Function FileExists(ByVal vArquivo As String) As Boolean
        Return IO.File.Exists(cls.GetPath() & vArquivo)
    End Function

    Private Sub GridView1_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Paginate1.SortExpression = e.SortExpression
        BindGrid()
    End Sub
    'Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
    '    Paginate1.CurrentPage = 0
    '    BindGrid()
    'End Sub


    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEnviar.Click

        Dim intTamanho As Integer = 0
        Dim strMessage As String = ""

        If txtArquivo.PostedFile.ContentLength <= cls.Espaco.Livre Then

            Dim strNome As String = ""

            If txtArquivo.PostedFile.FileName.ToLower.EndsWith(".zip") = True Then

                Dim zip As ZipFile = ZipFile.Read(txtArquivo.PostedFile.InputStream)

                If zip.EntryFilenames.Count = 1 Then
                    For Each f As ZipEntry In zip
                        If f.FileName.ToLower.EndsWith(".txt") Then
                            strNome = cls.InsereArquivo(1)
                            Dim s As New IO.FileStream(cls.GetPath() & strNome, IO.FileMode.Create)
                            f.Extract(s)
                            intTamanho = f.UncompressedSize
                            s.Close()
                        Else
                            strMessage = "O tipo do arquivo enviado não é permitido!"
                        End If
                    Next
                Else
                    strMessage = "Não pode ser enviado mais de um arquivo no mesmo arquivo compactado (zip)!"
                End If
                zip.Dispose()
            ElseIf txtArquivo.PostedFile.FileName.ToLower.EndsWith(".txt") Or txtArquivo.PostedFile.FileName.ToLower.EndsWith(".xml") Or txtArquivo.PostedFile.FileName.ToLower.EndsWith(".env") Then
                strNome = cls.InsereArquivo(1)
                intTamanho = txtArquivo.PostedFile.ContentLength
                txtArquivo.PostedFile.SaveAs(cls.GetPath() & strNome)
            Else
                strMessage = "O tipo do arquivo enviado não é permitido!"
            End If
            If strNome <> "" Then
                cls.GravaDetalhes(strNome, intTamanho, GetTipoArquivo(strNome))
                BindGrid()
            End If
        Else
            strMessage = "O tamanho do arquivo não pode ser superior ao dispon&iacute;vel!"
        End If
        lblMessage.Text = strMessage

    End Sub

    Private Function GetTipoArquivo(ByVal vArquivo As String) As Byte
        Dim ret As Byte = 0
        Try
            Dim fso As New IO.StreamReader(cls.GetPath() & vArquivo)
            Try
                Dim strLinha As String = fso.ReadLine
                Do While strLinha.Trim = ""
                    strLinha = fso.ReadLine
                Loop

                ret = cls.VerificaTipoArquivo(strLinha)
            Finally
                fso.Close()
                fso.Dispose()
            End Try
        Catch ex As Exception
            ret = 0
        End Try

        Return ret
    End Function

    Private Function CountString(ByVal value As String, ByVal find As String) As Integer
        Return Len(value) - Len(value.Replace(find, ""))

    End Function

End Class

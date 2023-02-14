Imports System.Data
Imports Ionic.Utils.Zip
Imports Classes
Imports System.IO

Namespace Pages.Integracao

    Partial Public Class Processos
        Inherits XMWebPage
        Dim cls As clsIntegracao

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsIntegracao()
            If Not Page.IsPostBack Then

                '***************************************************************
                'VERIFICANDO SE O USU�RIO TEM PERMISS�O DE ACESSAR ESTE M�DULO
                '***************************************************************
                If Not VerificaPermissao("Integra��o", "Importa��o de Arquivos") Then
                    Response.Redirect("default.aspx")
                End If

                Dim tip As New clsTipo
                Dim dr As IDataReader = tip.Listar()

                'Popula os combos de tipos de arquivos
                cboTipo.Items.Clear()
                cboTipoNovo.Items.Clear()
                Do While dr.Read
                    If VerificaPermissao("Integra��o", "Importa��o de Arquivos de " & dr.GetString(dr.GetOrdinal("Tipo"))) Then
                        cboTipo.Items.Add(New ListItem(dr.GetString(dr.GetOrdinal("Tipo")), dr.GetInt32(dr.GetOrdinal("IDTipo"))))
                        cboTipoNovo.Items.Add(New ListItem(dr.GetString(dr.GetOrdinal("Tipo")), dr.GetInt32(dr.GetOrdinal("IDTipo"))))
                    End If
                Loop
                cboTipo.Items.Insert(0, New ListItem("Todos", "0"))
                cboTipoNovo.Items.Insert(0, New ListItem("Selecione...", "0"))

                'Verifica permiss�es
                btnEnviar.Enabled = VerificaPermissao("Integra��o", "Subir arquivo de importa��o")
                GridView1.Columns.Item(5).Visible = VerificaPermissao("Integra��o", "Processar arquivo enviado")

                'Carrega grid
                Me.RecuperaFiltro(txtFiltro, Paginate1, txtDataInicial, txtDataFinal, cboTipo, cboStatus)
                BindGrid()
            End If
        End Sub

        Public Sub BindGrid()
            Dim ret As IPaginaResult = cls.Listar(Paginate1.Filtro, txtDataInicial.Text, txtDataFinal.Text, cboTipo.SelectedValue, cboStatus.SelectedValue, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            Me.GravaFiltro(txtFiltro, txtDataInicial, txtDataFinal, Paginate1, cboTipo, cboStatus)
        End Sub

        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindGrid()
        End Sub

        Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
            Paginate1.CurrentPage = 0
            Paginate1.Filtro = txtFiltro.Text
            BindGrid()
        End Sub

        Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
            If e.CommandName = "Processar" Then
                Dim strArquivo As String = e.CommandArgument
                lstErros.Items.Clear()
                Try
                    Processar(strArquivo)
                    ' cls.ProcessarArquivo(strArquivo, GetPath)
                Catch ex As System.Exception
                    lstErros.Items.Add("Erro ao processar o arquivo: " & strArquivo & " [" & ex.Message & "]")
                Finally
                    BindGrid()
                End Try
            End If
        End Sub

        Private Function GetProcessURL() As String
            Dim strRet As String = ConfigurationManager.AppSettings("Process_URL")
            If strRet = "" Then
                strRet = "http://tmlogy.xmlink.com.br/xmsend/verifica.aspx?u=VH0X2MYhZ5Y%3d&p=%2f7UjqvJe90t1fGEtJJvMmQ%3d%3d&Length=-1&file="
            End If
            Return strRet
        End Function

        Private Function Processar(ByVal strArquivo As String) As String
            Dim req As Net.HttpWebRequest
            Dim rsp As Net.HttpWebResponse
            Try
                req = Net.WebRequest.Create(GetProcessURL() & strArquivo)
                rsp = req.GetResponse
                Dim str As New IO.StreamReader(rsp.GetResponseStream())
                Processar = str.ReadToEnd
                rsp.Close()
            Catch e As Exception
                Processar = e.Message
            End Try
            rsp = Nothing
            req = Nothing
        End Function

        Protected Function FileExists(ByVal vArquivo As String) As Boolean
            Return IO.File.Exists(GetPath() & vArquivo)
        End Function

        Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
            BindGrid()
        End Sub


        Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
            Paginate1.CurrentPage = 0
            BindGrid()
        End Sub



        Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
            Paginate1.SortExpression = e.SortExpression
        End Sub

        Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
            Dim strNome, strPath As String
            strNome = cls.InsereArquivo(cboTipoNovo.SelectedItem.Value, txtArquivo.PostedFile.FileName.Substring(txtArquivo.PostedFile.FileName.LastIndexOf("\") + 1))
            strPath = ConfigurationManager.AppSettings("VirtualPath")
            lstErros.Items.Clear()

            If txtArquivo.PostedFile.FileName.EndsWith(".zip") = True Then

                Dim zip As ZipFile = ZipFile.Read(txtArquivo.PostedFile.InputStream)

                If zip.EntryFilenames.Count = 1 Then
                    For Each f As ZipEntry In zip
                        Dim s As New XMSistemas.XMVirtualFile.XMFileStream(GetPath() & strNome, IO.FileMode.Create)
                        f.Extract(s)
                        s.Close()
                    Next
                Else
                    'zip.Save(GetPath() & strNome & ".zip")
                    lstErros.Items.Add("N�o pode ser enviado mais de um arquivo no mesmo arquivo compactado (zip)!")
                End If
                zip.Dispose()
            Else
                Dim strm As New XMSistemas.XMVirtualFile.XMFileStream(GetPath() & strNome, IO.FileMode.Create)
                Try
                    strm.Write(txtArquivo.PostedFile.InputStream)
                Catch

                    Throw New ApplicationException("Erro ao enviar o arquivo!")
                Finally

                    strm.Close()
                End Try
            End If
            cboTipoNovo.SelectedIndex = 0
            BindGrid()
        End Sub



    End Class



End Namespace


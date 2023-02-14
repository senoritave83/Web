Imports System.Data
Imports Ionic.Utils.Zip
Imports Classes

Namespace Pages.Integracao

    Partial Public Class Processos
        Inherits XMWebPage
        Dim cls As clsIntegracao
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsIntegracao()
            If Not Page.IsPostBack Then

                '***************************************************************
                'VERIFICANDO SE O USUÁRIO TEM PERMISSÃO DE ACESSAR ESTE MÓDULO
                '***************************************************************
                If Not VerificaPermissao("Integração", "Importação de Arquivos") Then
                    Response.Redirect("default.aspx")
                End If

                Dim tip As New clsTipo
                Dim dr As IDataReader = tip.Listar()

                'Popula os combos de tipos de arquivos
                cboTipo.Items.Clear()
                cboTipoNovo.Items.Clear()
                Do While dr.Read
                    If VerificaPermissao("Integração", "Importação de Arquivos de " & dr.GetString(dr.GetOrdinal("Tipo"))) Then
                        cboTipo.Items.Add(New ListItem(dr.GetString(dr.GetOrdinal("Tipo")), dr.GetInt32(dr.GetOrdinal("IDTipo"))))
                        cboTipoNovo.Items.Add(New ListItem(dr.GetString(dr.GetOrdinal("Tipo")), dr.GetInt32(dr.GetOrdinal("IDTipo"))))
                    End If
                Loop
                cboTipo.Items.Insert(0, New ListItem("Todos", "0"))
                cboTipoNovo.Items.Insert(0, New ListItem("Selecione...", "0"))

                'Verifica permissões
                btnEnviar.Enabled = VerificaPermissao("Integração", "Subir arquivo de importação")
                GridView1.Columns.Item(5).Visible = VerificaPermissao("Integração", "Processar arquivo enviado")

                'Carrega grid
                Me.RecuperaFiltro(txtFiltro, Paginate1, txtDataInicial, txtDataFinal, cboTipo, cboStatus)
                BindGrid()
            End If
        End Sub

        Public Sub BindGrid()
            Dim ret As IPaginaResult = cls.Listar(ViewState("Filtro"), txtDataInicial.Text, txtDataFinal.Text, cboTipo.SelectedValue, cboStatus.SelectedValue, SortExpression, SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
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
            ViewState("Filtro") = txtFiltro.Text
            BindGrid()
        End Sub

        Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
            If e.CommandName = "Processar" Then
                Dim strArquivo As String = e.CommandArgument
                lstErros.Items.Clear()
                Try
                    cls.ProcessarArquivo(strArquivo, GetPath)
                Catch ex As System.Exception
                    lstErros.Items.Add("Erro ao processar o arquivo: " & strArquivo & " [" & ex.Message & "]")
                Finally
                    BindGrid()
                End Try
            End If
        End Sub

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

#Region "Sorting"


        Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
            If SortExpression = e.SortExpression Then
                If SortDirection = WebControls.SortDirection.Ascending Then
                    SortDirection = WebControls.SortDirection.Descending
                Else
                    SortDirection = WebControls.SortDirection.Ascending
                End If
            Else
                SortExpression = e.SortExpression
                SortDirection = WebControls.SortDirection.Ascending
            End If
        End Sub

        Protected Property SortExpression() As String
            Get
                If ViewState("SortExpression") Is Nothing Then
                    Return ""
                Else
                    Return ViewState("SortExpression")
                End If
            End Get
            Set(ByVal value As String)
                ViewState("SortExpression") = value
            End Set
        End Property

        Protected Property SortDirection() As SortDirection
            Get
                If ViewState("SortDirection") Is Nothing Then
                    Return WebControls.SortDirection.Descending
                Else
                    Return ViewState("SortDirection")
                End If
            End Get
            Set(ByVal value As SortDirection)
                ViewState("SortDirection") = value
            End Set
        End Property

#End Region

        Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
            Dim strNome, strMessage As String
            strNome = cls.InsereArquivo(cboTipoNovo.SelectedItem.Value)
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
                    zip.Save(GetPath() & strNome & ".zip")
                    strMessage = "Não pode ser enviado mais de um arquivo no mesmo arquivo compactado (zip)!"
                    lstErros.Items.Add(strMessage)
                End If
                zip.Dispose()
            Else
                Dim s As New XMSistemas.XMVirtualFile.XMFileStream(GetPath() & strNome, IO.FileMode.Create)
                s.Write(txtArquivo.PostedFile.InputStream)
                s.Close()
                s.Dispose()
            End If
            cboTipoNovo.SelectedIndex = 0
            BindGrid()
        End Sub



    End Class



End Namespace


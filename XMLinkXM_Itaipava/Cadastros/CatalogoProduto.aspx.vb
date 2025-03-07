Imports System.Configuration.ConfigurationManager
Imports Classes
Imports System.IO
Imports XMSistemas.XMVirtualFile

Namespace Pages.Cadastros

    Partial Public Class CatalogoProduto
        Inherits XMWebPage

        Protected Const SECAO As String = "Cadastro de Cat�logo de Produtos"
        Dim cls As clsCatalogoProduto
        Protected Const VW_IDPRODUTO As String = "IDProduto"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCatalogoProduto()
            If Not Page.IsPostBack Then
                ViewState(VW_IDPRODUTO) = CInt("0" & Request("IDProduto"))
                cls.Load(ViewState(VW_IDPRODUTO))

                If ViewState(VW_IDPRODUTO) = 0 Then
                    trProcCodProduto.Visible = True
                    trPrincipal.Visible = False
                Else
                    trInfoProduto.Visible = True
                    trPrincipal.Visible = True
                End If

                btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)

                lblProduto.Text = cls.DescricaoProduto
                BindFotos()
            Else
                cls.Load(ViewState(VW_IDPRODUTO))
            End If
        End Sub

        Protected Sub BindFotos()
            rptFotos.DataSource = cls.Listar(ViewState(VW_IDPRODUTO))
            rptFotos.DataBind()
        End Sub

        Protected Sub btnSubir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubir.Click
            If filUpload.HasFile Then
                Dim extension As String = filUpload.FileName.Substring(filUpload.FileName.LastIndexOf(".") + 1)
                Dim file_name As String
                Dim vIdProdutoFoto As Integer
                Dim savePath As String = AppSettings("PathFile")
                Try
                    vIdProdutoFoto = cls.NovaFoto(ViewState(VW_IDPRODUTO), extension.ToLower)
                    file_name = ViewState(VW_IDPRODUTO).ToString & "_" & vIdProdutoFoto.ToString

                    Dim xm As New XMSistemas.XMVirtualFile.XMFileStream(savePath & file_name & "." & extension.ToLower, IO.FileMode.CreateNew)
                    xm.Write(filUpload.PostedFile.InputStream)
                    xm.Close()
                Catch
                    cls.Delete(vIdProdutoFoto, ViewState(VW_IDPRODUTO))
                    ShowMsg("Falha ao gravar a foto. Por favor tente novamente.")
                End Try

                BindFotos()

            End If
        End Sub

        Protected Sub Checked_Change(ByVal source As Object, ByVal e As EventArgs)
            Dim di As DataListItem = CType(source, RadioButton).Parent
            Dim idfoto As Integer = (rptFotos.DataKeys(di.ItemIndex).ToString())
            cls.Load(ViewState(VW_IDPRODUTO), idfoto)
            cls.Capa = True
            cls.Update()
            BindFotos()
        End Sub

        Protected Sub rptFotos_ItemCommand1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles rptFotos.ItemCommand
            Dim pathfile As String = AppSettings("PathFile")
            If e.CommandName = "Apagar" Then
                Dim vArgs() As Object = e.CommandArgument.ToString().Split(",")
                Dim vFoto As String = vArgs(0)
                Dim vIdProdutoFoto As Integer = vArgs(1)
                If VirtualFile.FileExists(pathfile & vFoto) Then
                    VirtualFile.Delete(pathfile & vFoto)
                    cls.Delete(vIdProdutoFoto, ViewState(VW_IDPRODUTO))
                End If
            ElseIf e.CommandName = "Gravar" Then
                cls.Load(ViewState(VW_IDPRODUTO), e.CommandArgument)
                cls.Comentario = CType(e.Item.FindControl("txtComentario"), TextBox).Text
                cls.Update()
            End If

            BindFotos()

        End Sub

        Protected Sub btnProcurar_Click(sender As Object, e As System.EventArgs) Handles btnProcurar.Click

            If txtProcurarProduto.Text <> "" And IsNumeric(txtProcurarProduto.Text) Then

                Dim ds As Data.DataSet = cls.VerificaProduto(txtProcurarProduto.Text)
                If ds.Tables(0).Rows.Count > 0 Then
                    lblProduto.Text = ds.Tables(0).Rows(0).Item("Descricao")
                    ViewState(VW_IDPRODUTO) = ds.Tables(0).Rows(0).Item("IdProduto")
                    trInfoProduto.Visible = True
                    trPrincipal.Visible = True
                    trProcCodProduto.Visible = False
                    BindFotos()

                    Response.Redirect("CatalogoProduto.aspx?IDProduto=" & ViewState(VW_IDPRODUTO))
                End If

            End If

        End Sub


    End Class

End Namespace


Imports System.Data.SqlClient
Imports XMSistemas.Web.Base

Partial Class configuracoes_mensagens
    Inherits XMProtectedPage

    Protected Const PageSize As Integer = 15

    Protected cls As clsMensagem

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsMensagem()
        If Not IsPostBack Then

            ViewState("Desc") = 0 'False
            ViewState("Sort") = "Cliente"
            ViewState("Type") = Request("type")
            ViewState("CurrentPage") = CInt("0" & Request("CurrentPage"))
            BindGrid()

        End If

    End Sub

    Public Sub BindGrid()

        Dim ret As IPaginaResult = Nothing

        ret = cls.ListarMensagens(ViewState("Sort") & "", ViewState("CurrentPage"), PageSize, ViewState("Desc"))

        dtgGrid.DataSource = ret.Tables(0)
        dtgGrid.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()
    End Sub

    Private Sub dtgGrid_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles dtgGrid.Sorting
        ViewState("Sort") = e.SortExpression
        ViewState("Desc") = IIf(ViewState("Desc") = 0, 1, 0)
        BindGrid()
    End Sub

    Private Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNovo.Click
        cls.Nome = txtNome.Text
        cls.Mensagem = txtMensagem.Text
        Try
            cls.Update()
        Catch ex As SqlException
            If ex.Number = 50000 Then
                ShowError(ex.Message)
                Exit Sub
            Else
                Throw ex
            End If
        End Try
        MostraGravado("mensagens.aspx")
    End Sub

    Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnApagar.Click
        If Request("chkSelected") <> "" Then
            cls.Delete(Request("chkSelected"))
            BindGrid()
        End If

    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("default2.aspx")
    End Sub

    Protected Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        ViewState("CurrentPage") = Paginate1.CurrentPage
        BindGrid()
    End Sub

End Class

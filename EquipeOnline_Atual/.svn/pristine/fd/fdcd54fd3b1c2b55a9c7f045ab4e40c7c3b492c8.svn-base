
Partial Class configuracoes_usuarios
    Inherits XMProtectedPage

    Protected Const PageSize As Integer = 15

    Private cls As clsUsuario

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsUsuario()

        If Not IsPostBack Then

            If Not IsAdmin() Then Response.Redirect("../Default.aspx")

            ViewState("Desc") = 0 'False
            ViewState("Sort") = "Operador"
            ViewState("Type") = Request("type")
            ViewState("CurrentPage") = CInt("0" & Request("CurrentPage"))
            BindGrid()

        End If

    End Sub

    Public Sub BindGrid()

        Dim ret As IPaginaResult = Nothing

        ret = cls.ListarUsuarios(ViewState("Sort") & "", ViewState("CurrentPage"), PageSize, ViewState("Desc"))

        grdUsuarios.DataSource = ret.DataSet.Tables(0)
        grdUsuarios.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()
    End Sub

    Private Sub grdUsuarios_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdUsuarios.Sorting
        ViewState("Sort") = e.SortExpression
        ViewState("Desc") = IIf(ViewState("Desc") = 0, 1, 0)
        BindGrid()
    End Sub

    Private Sub btnVoltar_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("default.aspx")
    End Sub

    Protected Sub btnAdicionar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdicionar.Click
        Response.Redirect("usuariodet.aspx?idusuario=0")
    End Sub

    Protected Sub btnExcluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcluir.Click
        If CheckPermission("Cadastro de Usuarios", "Excluir Usuario") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(Request("chkSelected")) Then
            cls.Delete(Request("chkSelected"))
            BindGrid()
        End If
    End Sub

    Protected Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        ViewState("CurrentPage") = Paginate1.CurrentPage
        BindGrid()
    End Sub
End Class

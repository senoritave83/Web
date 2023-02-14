Imports System.Data.SqlClient
Imports XMSistemas.Web.Base

Partial Class home_pasta
    Inherits XMProtectedPage

    Protected Const PageSize As Integer = 15

    Protected clsOS As clsOrdemServico

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        clsOS = New clsOrdemServico()
        If Not IsPostBack Then

            Dim rsp As clsResponsaveis
            rsp = New clsResponsaveis()
            cboResponsavel.DataSource = rsp.Listar
            cboResponsavel.DataBind()
            cboResponsavel.Items.Insert(0, New ListItem("Todos", "0"))
            rsp = Nothing
            ViewState("Desc") = 0 'False
            ViewState("Sort") = "Numero"
            ViewState("Type") = Request("type")
            ViewState("CurrentPage") = CInt("0" & Request("CurrentPage"))
            BindGrid()

        End If

    End Sub

    Public Sub BindGrid()

        Dim ret As IPaginaResult = Nothing

        ret = clsOS.ListarOrdensGuardadas(CInt("0" & ViewState("IDResponsavel")), ViewState("Sort") & "", ViewState("CurrentPage"), PageSize, ViewState("Desc"))

        dtgGrid.DataSource = ret.Tables(0)
        dtgGrid.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()
        btnEnviar.Enabled = (dtgGrid.Rows.Count > 0)

    End Sub

    Private Sub dtgGrid_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles dtgGrid.Sorting
        ViewState("Sort") = e.SortExpression
        ViewState("Desc") = IIf(ViewState("Desc") = 0, 1, 0)
        BindGrid()
    End Sub

    Private Sub cboResponsavel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboResponsavel.SelectedIndexChanged
        ViewState("IDResponsavel") = cboResponsavel.SelectedValue
        BindGrid()
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEnviar.Click
        Dim vIDOS() As String
        vIDOS = Split(Request("chkSelected").Replace(" ", ""), ",")
        Dim i As Integer
        For i = 0 To UBound(vIDOS)
            clsOS.Enviar(CInt(vIDOS(i)))
        Next
        BindGrid()
    End Sub

    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnApagar.Click
        clsOS.Delete(Request("chkSelected"))
        BindGrid()
    End Sub

    Protected Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        ViewState("CurrentPage") = Paginate1.CurrentPage
        BindGrid()
    End Sub
End Class

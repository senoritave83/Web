Imports System.Data.SqlClient

Public Class motivos
    Inherits XMProtectedPage
    Protected WithEvents txtFiltro As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnFiltrar As System.Web.UI.WebControls.Button
    Protected WithEvents dtgGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lnkPrevious As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkNext As System.Web.UI.WebControls.LinkButton
    Protected WithEvents valRequired As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtMotivo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnNovo As System.Web.UI.WebControls.Button
    Protected WithEvents btnApagar As System.Web.UI.WebControls.Button
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected cls As clsMotivo
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsMotivo(Me)
        If Not Page.IsPostBack Then
            ViewState("CurrentPage") = 0
            ViewState("Desc") = True
            ViewState("Sort") = "Motivo"
            BindGrid()
            btnNovo.Enabled = CheckPermission("Cadastro de Motivos", "Adicionar Motivo")
            btnApagar.Enabled = CheckPermission("Cadastro de Motivos", "Apagar Motivo")
        End If
    End Sub

    Public Sub BindGrid()
        Dim ds As DataSet
        ds = cls.Listar(txtFiltro.Text, ViewState("Sort") & "", ViewState("Desc"), ViewState("CurrentPage"), PageSize)
        dtgGrid.DataSource = ds.Tables(0)
        dtgGrid.DataBind()
        Dim intMaxPages As Integer = ds.Tables(1).Rows(0).Item(0) \ PageSize
        If ViewState("CurrentPage") > intMaxPages Then
            ViewState("CurrentPage") = intMaxPages
        End If
        If ViewState("CurrentPage") > 0 Then
            lnkPrevious.Enabled = True
            lnkPrevious.CommandArgument = ViewState("CurrentPage") - 1
        Else
            lnkPrevious.Enabled = False
        End If
        If ViewState("CurrentPage") < intMaxPages Then
            lnkNext.Enabled = True
            lnkNext.CommandArgument = ViewState("CurrentPage") + 1
        Else
            lnkNext.Enabled = False
        End If
    End Sub

    Public Sub DataGrid_Command(ByVal source As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        If e.CommandName = "Order" Then
            ViewState("Desc") = Not ViewState("Desc")
            ViewState("Sort") = e.CommandArgument
        ElseIf e.CommandName = "Paginate" Then
            If e.CommandArgument = "inc" Then
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            Else
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            End If
        End If
        BindGrid()
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        BindGrid()
    End Sub


    Private Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovo.Click
        If CheckPermission("Cadastro de Motivos", "Adicionar Motivo") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        cls.Motivo = txtMotivo.Text
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
        MostraGravado("motivos.aspx")
    End Sub

    Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
        cls.Delete(Request("chkSelected"))
        BindGrid()
    End Sub


End Class

Public Class recados
    Inherits XMProtectedPage
    Protected WithEvents dtgGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ltrMessage As System.Web.UI.WebControls.Literal
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents cboDestinatario As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtMensagem As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMensagem As System.Web.UI.WebControls.Label
    Protected WithEvents btnEnviar As System.Web.UI.WebControls.Button
    Protected WithEvents btnEnviarEmail As System.Web.UI.WebControls.Literal
    Protected clsRec As clsRecados

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

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsRec = New clsRecados(Me)
        If Not Page.IsPostBack Then
            cboDestinatario.DataSource = clsRec.Destinatarios
            cboDestinatario.DataBind()
            BindGrid()
            btnEnviar.Enabled = CheckPermission("Recado Digital", "Enviar Recado Digital")            
        End If
    End Sub

    Public Sub DataGrid_Page(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        dtgGrid.CurrentPageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Public Sub BindGrid()
        Dim ds As DataSet
        ds = clsRec.Listar(ViewState("Sort") & "", dtgGrid.CurrentPageIndex, dtgGrid.PageSize)
        dtgGrid.DataSource = ds.Tables(0)
        dtgGrid.VirtualItemCount = ds.Tables(1).Rows(0).Item(0)
        dtgGrid.DataBind()
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Dim blnGrupo As Boolean
        If Not cboDestinatario.SelectedItem Is Nothing Then
            blnGrupo = (Left(cboDestinatario.SelectedItem.Value, 1) = "1")
            If clsRec.Enviar(blnGrupo, cboDestinatario.SelectedItem.Value.Substring(2), txtMensagem.Text) Then
                MostraGravado("recados.aspx")
            Else
                lblMensagem.Visible = True
            End If
        End If
    End Sub

    Public Sub cboDestinatario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDestinatario.SelectedIndexChanged
        Dim blnGrupo As Boolean
        If Not cboDestinatario.SelectedItem Is Nothing Then
            Dim strEmail As String = ""
            Dim ds As DataSet
            blnGrupo = (Left(cboDestinatario.SelectedItem.Value, 1) = "1")
            ds = clsRec.ListarEmails(blnGrupo, cboDestinatario.SelectedItem.Value.Substring(2))
            Dim intCurEmail As Integer = 0
            For intCurEmail = 0 To ds.Tables(0).Rows.Count - 1
                strEmail += ds.Tables(0).Rows(intCurEmail)(0) + ";"
            Next

            If strEmail.Length > 0 Then
                btnEnviarEmail.Text = "<a href='" & "mailto:marketing@aut.com.br" & "?bcc=" & strEmail & "'>" & "Envio de E-mail" & "</a>"
                Exit Sub
            Else
                btnEnviarEmail.Text = ""
            End If
        End If
        

    End Sub


End Class

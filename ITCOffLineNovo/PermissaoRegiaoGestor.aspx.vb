Imports ITCOffLine

Public Class PermissaoRegiaoGestor
    Inherits XMWebPage

    Protected WithEvents dtgGrid As DataGrid
    Protected WithEvents lblGestor As Label
    Protected WithEvents btnSalvarPermissoes As ImageButton
    Protected WithEvents btnVoltar As ImageButton

    Private Assoc As clsAssociados

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            ViewState("IdAssociado") = DeCryptography(Page.Request("IdAssociado"))
            If Not IsNumeric(ViewState("IdAssociado")) Then ViewState("IdAssociado") = 0
            Assoc = New clsAssociados(ViewState("IdAssociado"))

            ViewState("IdGestor") = DeCryptography(Page.Request("IdGestor"))
            If Not IsNumeric(ViewState("IdGestor")) Then ViewState("IdGestor") = 0

            Dim Usu As New clsUsuario(ViewState("IdGestor"), (ViewState("IdAssociado")))
            lblGestor.Text = Usu.Usuario
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()

        Dim Assoc As New clsAssociados(ViewState("IdAssociado"))
        dtgGrid.DataSource = Assoc.ListTiposRegioesGestor(ViewState("IdGestor"), ViewState("IdAssociado"))
        dtgGrid.DataBind()

    End Sub

    Private Sub btnSalvarPermissoes_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSalvarPermissoes.Click

        Dim strPermissoes As String = ""
        Dim i As Integer
        For i = 0 To dtgGrid.Items.Count - 1
            Dim CurrentCheckBox As CheckBox = dtgGrid.Items(i).FindControl("chkPermissao")
            If CurrentCheckBox.Checked Then
                If strPermissoes.Trim <> "" Then
                    strPermissoes += ","
                End If
                strPermissoes += dtgGrid.DataKeys.Item(dtgGrid.Items(i).ItemIndex).ToString()
            End If
        Next
        Dim Assoc As New clsAssociados(ViewState("IdAssociado"))
        Assoc.SalvarPermissoesGestor(ViewState("IdGestor"), strPermissoes)
        BindGrid()

    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click

        Response.Redirect("usuariosdet.aspx?codigo=" & CryptographyEncoded(ViewState("IdGestor")) & "&idassociado=" & CryptographyEncoded(ViewState("IdAssociado")))

    End Sub

End Class
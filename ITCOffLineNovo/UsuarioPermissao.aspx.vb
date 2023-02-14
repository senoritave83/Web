Imports ITCOffLine
Imports System.Data

Public Class UsuarioPermissao

    Inherits XMWebPage
    Protected WithEvents tblObrasDet As System.Web.UI.WebControls.Table
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dtgTipos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dtlRegioes As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlEstados As System.Web.UI.WebControls.DataList
    Protected WithEvents btnGravarAlteracoes_Down As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnGravarAlteracoes As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnVoltar As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblNomeUsuario As System.Web.UI.WebControls.Label
    Protected WithEvents lblCodigo As System.Web.UI.WebControls.Label
    Private Usu As clsUsuario

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

        If Not Page.IsPostBack Then

            Dim objIdUsuario, objIdAssociado As Object

            objIdUsuario = DeCryptography(Page.Request("Codigo"))
            If IsNumeric(objIdUsuario) Then
                ViewState("IdUsuario") = objIdUsuario
            Else
                ViewState("IdUsuario") = 0
            End If

            objIdAssociado = DeCryptography(Page.Request("IdAssociado"))
            If IsNumeric(objIdAssociado) Then
                ViewState("IdAssociado") = objIdAssociado
            Else
                ViewState("IdAssociado") = 0
            End If

            Usu = New clsUsuario(ViewState("IdUsuario"), ViewState("IdAssociado"))
            lblNomeUsuario.Text = Usu.Usuario
            lblCodigo.Text = Usu.IDUsuario
            BindGrids()
            Usu = Nothing

        End If

    End Sub

    Private Sub BindGrids()

        BindTipos()
        BindRegioes()
        BindEstados(0)

    End Sub

    Private Sub BindTipos()

        dtgTipos.DataSource = Usu.PermissoesTipo
        dtgTipos.DataBind()

    End Sub

    Private Sub BindRegioes()

        dtlRegioes.DataSource = Usu.PermissoesRegiao
        dtlRegioes.DataBind()

    End Sub

    Private Sub BindEstados(ByVal IdRegiao As Integer)

        dtlEstados.DataSource = Usu.PermissoesEstados(IdRegiao)
        dtlEstados.DataBind()

    End Sub

    Private Sub CmdRegioes(ByVal source As Object, ByVal e As DataGridCommandEventArgs)
        Dim strKey As String = dtlRegioes.DataKeys.Item(dtlRegioes.Items(e.Item.ItemIndex).ItemIndex).ToString()
    End Sub

    Private Sub SaveConfigurations()
        Dim strTipos = "", strRegioes = "", strEstados As String = ""
        Dim i As Integer

        For i = 0 To dtlRegioes.Items.Count - 1
            Dim CurrentCheckBox As CheckBox = dtlRegioes.Items(i).FindControl("chkRegiao")
            If CurrentCheckBox.Checked Then
                If strRegioes.Trim <> "" Then
                    strRegioes += ","
                End If
                strRegioes += dtlRegioes.DataKeys.Item(dtlRegioes.Items(i).ItemIndex).ToString()
            End If
        Next

        For i = 0 To dtgTipos.Items.Count - 1
            Dim CurrentCheckBox As CheckBox = dtgTipos.Items(i).FindControl("chkTipos")
            If CurrentCheckBox.Checked Then
                If strTipos.Trim <> "" Then
                    strTipos += ","
                End If
                strTipos += dtgTipos.DataKeys.Item(dtgTipos.Items(i).ItemIndex).ToString()
            End If
        Next

        For i = 0 To dtlEstados.Items.Count - 1
            Dim CurrentCheckBox As CheckBox = dtlEstados.Items(i).FindControl("chkEstados")
            If CurrentCheckBox.Checked Then
                If strEstados.Trim <> "" Then
                    strEstados += ","
                End If
                strEstados += dtlEstados.DataKeys.Item(dtlEstados.Items(i).ItemIndex).ToString()
            End If
        Next

        Usu.SalvarPermissoes(strTipos, strRegioes, strEstados)

    End Sub

    Private Sub btnGravarAlteracoes_Down_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGravarAlteracoes_Down.Click
        Usu = New clsUsuario(ViewState("IdUsuario"), ViewState("IdAssociado"))
        SaveConfigurations()
        BindGrids()
        Usu = Nothing
    End Sub

    Private Sub btnGravarAlteracoes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGravarAlteracoes.Click
        Usu = New clsUsuario(ViewState("IdUsuario"), ViewState("IdAssociado"))
        SaveConfigurations()
        BindGrids()
        Usu = Nothing
    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Page.Response.Redirect("usuariosdet.aspx?codigo=" & CryptographyEncoded(ViewState("IdUsuario")) & "&idassociado=" & CryptographyEncoded(ViewState("IdAssociado")))
    End Sub

    Private Sub dtgTipos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgTipos.ItemDataBound

        With e.Item
            Dim rv As DataRow
            If .ItemType = ListItemType.AlternatingItem OrElse .ItemType = ListItemType.Item OrElse .ItemType = ListItemType.EditItem Then
                rv = CType(.DataItem, DataRowView).Row
                ' Change color
                If Not IsDBNull(rv("SEG_SEGMENTO_INT_FK")) Then
                    Select Case rv("SEG_SEGMENTO_INT_FK")
                        Case 1
                            .CssClass = "Industrial"
                        Case 2
                            .CssClass = "Comercial"
                        Case 3
                            .CssClass = "Residencial"
                    End Select
                End If
            End If
        End With

    End Sub

End Class


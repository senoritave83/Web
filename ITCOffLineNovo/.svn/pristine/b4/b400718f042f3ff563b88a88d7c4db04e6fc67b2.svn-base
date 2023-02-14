Imports ITCOffLine
Imports System.Data

Public Class AssociadosTiposRegioes
    Inherits XMWebPage

    Protected WithEvents tblObrasDet As System.Web.UI.WebControls.Table
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dtgTiposRegioes As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnGravarAlteracoes As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnVoltar As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblRazaoSocial As System.Web.UI.WebControls.Label
    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    Private Assoc As clsAssociados

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
            ViewState("IdAssociado") = DeCryptography(Page.Request("IdAssociado"))
            If Not IsNumeric(ViewState("IdAssociado")) Then ViewState("IdAssociado") = 0
            Assoc = New clsAssociados(ViewState("IdAssociado"))
            lblRazaoSocial.Text = Assoc.RazaoSocial
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()

        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim ds As DataSet = Assoc.ListTiposRegioes(ViewState("IdAssociado"))

        If ds.Tables.Count > 0 Then
            With ds.Tables(0)
                If .Rows.Count > 0 Then

                    Dim i, j As Integer
                    Dim p_IdTipo As Integer = 0, p_IdRegiao As Integer = 0
                    Dim blnHeader As Boolean = False
                    Dim rw As DataRow
                    Dim it As DataGridItem, chk As CheckBox, col As DataGridColumnCollection, cl As TemplateColumn, bc As BoundColumn, dc As DataColumn, chkcol As checkboxColumn

                    'MONTA AS COLUNAS
                    'bc = New BoundColumn()
                    'bc.DataField = "DESCRICAOTIPO"
                    'bc.HeaderText = "Tipos de Obras"
                    'dtgTiposRegioes.Columns.Add(bc)

                    If i = 0 Then
                        For j = 2 To .Columns.Count - 1

                            dc = ds.Tables(0).Columns(j)
                            If dc.ColumnName.ToString().ToUpper() <> "IDSEGMENTO" Then
                                chkcol = New checkboxColumn
                                With chkcol
                                    .Name = "chk"
                                    .RowName = "IDTIPO"
                                    .DataValueField = dc.ColumnName
                                End With
                                cl = New TemplateColumn
                                cl.HeaderText = "<a alt='Clique aqui para selecionar a coluna toda' href=""javascript:CA('" & dc.ColumnName.Substring(0, 3) & "')""><font class=f8 color=#FFFFFF>" & dc.ColumnName.Substring(4) & "</font></a>"
                                cl.ItemTemplate = chkcol
                                cl.FooterText = dc.ColumnName.Substring(0, 3)
                                dtgTiposRegioes.Columns.Add(cl)
                            End If
                        Next
                    End If

                    dtgTiposRegioes.DataSource = ds
                    dtgTiposRegioes.DataBind()

                End If
            End With
        End If

    End Sub

    Private Sub btnGravarAlteracoes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGravarAlteracoes.Click
        Dim strItens As String = Page.Request("chkSelecao")
        Assoc = New clsAssociados(ViewState("IdAssociado"))
        Assoc.SalvaSelecao(strItens)
        Gravado("associadostiposregioes.aspx?idassociado=" & CryptographyEncoded(ViewState("IdAssociado")))
    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("associadosdet.aspx?codigo=" & CryptographyEncoded(ViewState("IdAssociado")))
    End Sub

    Private Sub dtgTiposRegioes_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgTiposRegioes.ItemDataBound

        With e.Item
            Dim rv As DataRow
            If .ItemType = ListItemType.AlternatingItem OrElse .ItemType = ListItemType.Item OrElse .ItemType = ListItemType.EditItem Then
                rv = CType(.DataItem, DataRowView).Row
                ' Change color
                If Not IsDBNull(rv("IdSegmento")) Then
                    Select Case rv("IdSegmento")
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


Public Class checkboxColumn
    Implements ITemplate
    Public DataValueField As String
    Public Name As String
    Public RowName As String

    Protected WithEvents label As Label

    Public Sub BindCheckBoxColumn(ByVal sender As Object, ByVal e As EventArgs)
        label = sender
        Dim container As DataGridItem = label.NamingContainer
        label.Text = "<input type=checkbox name='chkSelecao' value='" & container.DataItem(RowName) & "_" & DataValueField.Substring(0, 3) & "'" & IIf(Convert.ToBoolean(container.DataItem(DataValueField)) = True, " checked", "") & " >"
    End Sub

    Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) Implements System.Web.UI.ITemplate.InstantiateIn
        label = New Label()
        container.Controls.Add(label)
    End Sub

    Private Sub checkbox_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles label.DataBinding
        BindCheckBoxColumn(sender, e)
    End Sub

End Class


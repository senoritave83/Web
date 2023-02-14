
Partial Class include_SelectDestinatario
    Inherits System.Web.UI.UserControl



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            AutoCompleteExtender1.ContextKey = CType(Me.Page, XMWebPage).Identity.IDEmpresa

            Dim clsResp As New clsResponsaveis()
            If clsResp.Count > CType(Me.Page, XMWebPage).MaxSizeList() Then
                cboResponsavel.Visible = False
                txtResponsavel.Visible = True
            Else
                cboResponsavel.DataSource = clsResp.ListarDestinatarios
                cboResponsavel.DataBind()
                cboResponsavel.Items.Insert(0, New ListItem("todos", ""))
                cboResponsavel.Visible = True
                txtResponsavel.Visible = False
            End If
            clsResp = Nothing
        End If
    End Sub

    Public ReadOnly Property Destinatario() As String
        Get
            If txtResponsavel.Visible Then
                Return txtResponsavel.Text
            Else
                Return cboResponsavel.SelectedValue
            End If
        End Get
    End Property

    Public ReadOnly Property DropDown() As DropDownList
        Get
            Return cboResponsavel
        End Get
    End Property

    Public ReadOnly Property TextBox() As TextBox
        Get
            Return txtResponsavel
        End Get
    End Property

End Class

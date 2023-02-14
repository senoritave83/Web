
Partial Class include_SelectResponsaveis
    Inherits System.Web.UI.UserControl

    Implements IFiltroControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            AutoCompleteExtender1.ContextKey = CType(Me.Page, XMWebPage).Identity.IDEmpresa

            Dim clsResp As New clsResponsaveis()
            If clsResp.Count > CType(Me.Page, XMWebPage).MaxSizeList() Then
                cboResponsavel.Visible = False
                txtResponsavel.Visible = True
            Else
                cboResponsavel.DataSource = clsResp.Listar
                cboResponsavel.DataBind()
                cboResponsavel.Items.Insert(0, New ListItem("todos", ""))
                cboResponsavel.Visible = True
                txtResponsavel.Visible = False
            End If
            clsResp = Nothing

            If Not String.IsNullOrEmpty(Request("responsavel")) Then

                If txtResponsavel.Visible Then
                    txtResponsavel.Text = Request("responsavel")
                Else
                    cboResponsavel.SelectedValue = Request("responsavel")
                End If
            End If


        End If
    End Sub

    Public ReadOnly Property Responsavel() As String
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

    Public Property Value As Object Implements IFiltroControl.Value
        Get
            Return Responsavel
        End Get
        Set(ByVal value As Object)
            If txtResponsavel.Visible Then
                txtResponsavel.Text = value
            Else
                cboResponsavel.SelectedValue = value
            End If
        End Set
    End Property
End Class

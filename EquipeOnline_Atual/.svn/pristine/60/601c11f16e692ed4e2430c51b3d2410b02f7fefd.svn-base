
Partial Class include_SelectCliente
    Inherits System.Web.UI.UserControl

    Implements IFiltroControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            AutoCompleteExtender1.ContextKey = CType(Me.Page, XMWebPage).Identity.IDEmpresa

            Dim clsCli As New clsClientes()
            If clsCli.Count > CType(Me.Page, XMWebPage).MaxSizeList() Then
                cboCliente.Visible = False
                txtCliente.Visible = True
            Else
                cboCliente.DataSource = clsCli.Listar
                cboCliente.DataBind()
                cboCliente.Items.Insert(0, New ListItem("todos", ""))
                cboCliente.Visible = True
                txtCliente.Visible = False
            End If


            If Not String.IsNullOrEmpty(Request("cliente")) Then

                If txtCliente.Visible Then
                    txtCliente.Text = Request("cliente")
                Else
                    cboCliente.SelectedValue = Request("cliente")
                End If
            End If

            clsCli = Nothing
        End If
    End Sub

    Public ReadOnly Property Cliente() As String
        Get
            If txtCliente.Visible Then
                Return txtCliente.Text
            Else
                Return cboCliente.SelectedValue
            End If
        End Get
    End Property

    Public ReadOnly Property DropDownCliente() As DropDownList
        Get
            Return cboCliente
        End Get
    End Property

    Public ReadOnly Property TextBoxCliente() As TextBox
        Get
            Return txtCliente
        End Get
    End Property

    Public Property Value As Object Implements IFiltroControl.Value
        Get
            Return Cliente
        End Get
        Set(ByVal value As Object)
            If txtCliente.Visible Then
                txtCliente.Text = value
            Else
                cboCliente.SelectedValue = value
            End If
        End Set
    End Property
End Class

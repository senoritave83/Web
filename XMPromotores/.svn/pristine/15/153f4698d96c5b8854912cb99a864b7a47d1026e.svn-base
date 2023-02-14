Imports Classes
Imports System.Data


Partial Class controls_FiltroSuperior
    Inherits System.Web.UI.UserControl
    Implements IFiltroControl

    Public Class FiltroSuperiorEventArgs
        Inherits EventArgs
        Public IDSuperior As Integer
    End Class

    Public Event SelectedIndexChanged(ByVal sender As Object, ByVal FiltroSuperiorEventArgs As EventArgs)

    Public Property IDCargoBase() As Integer
        Get
            If ViewState("IDCargo") Is Nothing Then
                Return 1 'Promotor
            End If
            Return ViewState("IDCargo")
        End Get
        Set(ByVal value As Integer)
            If value <> IDCargoBase Then
                ViewState("IDCargo") = value
                BindItens()
            End If
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Overrides Sub DataBind()
        MyBase.DataBind()
        EnsureChildControls()
    End Sub

    Protected Overrides Sub CreateChildControls()
        If Not ChildControlsCreated Then
            MyBase.CreateChildControls()
            BindItens()
        End If
    End Sub

    Protected Sub BindItens()
        Dim car As New clsCargo
        rptSuperiores.DataSource = car.ListarCargosSuperiores(IDCargoBase)
        rptSuperiores.DataBind()
    End Sub

    Protected ReadOnly Property DataKeys() As Generic.List(Of Integer)
        Get
            If ViewState("DataKeys") Is Nothing Then
                ViewState("DataKeys") = New Generic.List(Of Integer)
            End If
            Return ViewState("DataKeys")
        End Get
    End Property

    Protected Sub rptSuperiores_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptSuperiores.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim cbo As DropDownList = e.Item.FindControl("cboIDUsuario")
            BindUsuarios(cbo, e.Item.DataItem("IDCargo"), 0)
            'SuperiorCol.Add(New SuperiorItem(e.Item.DataItem("IDCargo"), e.Item.DataItem("Cargo"), e.Item.DataItem("IDSuperior"), cbo.UniqueID))
            DataKeys.Add(e.Item.DataItem("IDCargo"))
        End If
    End Sub

    Protected Sub cboIDSuperior_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

        Dim _currentItem As Integer = sender.parent.ItemIndex
        Dim cbo As DropDownList = sender.parent.FindControl("cboIDUsuario")
        Dim intIDSuperior As Integer = CInt("0" & cbo.SelectedValue)
        Dim blnChanged As Boolean = False
        For Each row As RepeaterItem In rptSuperiores.Items
            If row.ItemIndex > _currentItem Then
                cbo = row.FindControl("cboIDUsuario")
                Dim intIDSelected As Integer = CInt("0" & cbo.SelectedValue)
                BindUsuarios(cbo, DataKeys.Item(row.ItemIndex), intIDSuperior)
                cbo.SelectedValue = intIDSelected
                blnChanged = True
                intIDSuperior = intIDSelected
            End If
        Next
        If blnChanged Then
            Dim ev As New FiltroSuperiorEventArgs
            ev.IDSuperior = IDSuperior
            RaiseEvent SelectedIndexChanged(Me, ev)
        End If
    End Sub


    Public Property IDSuperior() As Integer
        Get
            Dim _IDSuperior As Integer = 0
            For Each row As RepeaterItem In rptSuperiores.Items
                If row.ItemType = ListItemType.AlternatingItem Or row.ItemType = ListItemType.Item Then
                    Dim cbo As DropDownList = row.FindControl("cboIDUsuario")
                    If CInt("0" & cbo.SelectedValue) > 0 Then
                        _IDSuperior = CInt("0" & cbo.SelectedValue)
                    End If
                End If
            Next
            Return _IDSuperior
        End Get
        Set(ByVal value As Integer)
            For Each row As RepeaterItem In rptSuperiores.Items
                If row.ItemType = ListItemType.AlternatingItem Or row.ItemType = ListItemType.Item Then
                    Dim cbo As DropDownList = row.FindControl("cboIDUsuario")
                    cbo.SelectedValue = value
                End If
            Next
        End Set
    End Property

    Public Shadows Property Page() As XMWebPage
        Get
            Return MyBase.Page
        End Get
        Set(ByVal value As XMWebPage)

        End Set
    End Property

    Protected Sub BindUsuarios(ByVal cbo As DropDownList, ByVal vIDCargo As Integer, ByVal vIDSuperior As Integer)
        Dim usu As New clsUsuario
        If vIDCargo = Page.User.IDCargo Then
            Dim dr As IDataReader = usu.Listar(vIDCargo, vIDSuperior)
            cbo.Items.Clear()
            Do While dr.Read
                If dr.GetInt32(dr.GetOrdinal("IDUsuario")) = Page.User.IDUser Then
                    cbo.Items.Add(New ListItem(dr.GetString(dr.GetOrdinal("Usuario")), dr.GetInt32(dr.GetOrdinal("IDUsuario"))))
                End If
            Loop
        Else
            cbo.DataSource = usu.Listar(vIDCargo, vIDSuperior)
            cbo.DataBind()
            cbo.Items.Insert(0, New ListItem("Todos", 0))
        End If
    End Sub

    Public Property Value() As Object Implements XMSistemas.Web.Base.IFiltroControl.Value
        Get
            Dim ret As String = ""
            For Each row As RepeaterItem In rptSuperiores.Items
                If row.ItemType = ListItemType.AlternatingItem Or row.ItemType = ListItemType.Item Then
                    Dim cbo As DropDownList = row.FindControl("cboIDUsuario")
                    ret &= CInt("0" & cbo.SelectedValue) & ","
                End If
            Next
            Return ret
        End Get
        Set(ByVal value As Object)
            EnsureChildControls()
            Dim values() As String = Split(value, ",")
            For Each row As RepeaterItem In rptSuperiores.Items
                If row.ItemType = ListItemType.AlternatingItem Or row.ItemType = ListItemType.Item Then
                    Dim cbo As DropDownList = row.FindControl("cboIDUsuario")
                    If UBound(values) >= row.ItemIndex Then
                        cbo.SelectedValue = values(row.ItemIndex)
                    End If
                End If
            Next
        End Set
    End Property
End Class

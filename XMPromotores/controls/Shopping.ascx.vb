
Partial Class controls_Shopping

    Inherits System.Web.UI.UserControl

    Public Property TipoLoja() As Integer
        Get
            Return rdTipo.SelectedValue
        End Get
        Set(ByVal value As Integer)
            rdTipo.SelectedValue = value
            drpShopping.Visible = (rdTipo.SelectedValue <> 0)
        End Set
    End Property

    Public Property IdShopping() As Integer
        Get
            Return getComboValue(drpShopping)
        End Get
        Set(ByVal value As Integer)
            setComboValue(drpShopping, value.ToString)
        End Set
    End Property

    Public Property DataSource() As Object
        Get
            Return drpShopping.DataSource
        End Get
        Set(ByVal value As Object)
            drpShopping.DataSource = value
        End Set
    End Property

    Public Overrides Sub DataBind()
        drpShopping.DataBind()
    End Sub

    Protected Sub Tipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdTipo.SelectedIndexChanged

        drpShopping.Visible = (rdTipo.SelectedValue <> 0)

    End Sub

End Class

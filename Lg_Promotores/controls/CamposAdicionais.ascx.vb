
Partial Class controls_CamposAdicionais
    Inherits System.Web.UI.UserControl
    Protected cls As New Classes.clsCampoAdicional

    Public Property Entidade() As String
        Get
            Return ViewState("ENTIDADE")
        End Get
        Set(ByVal value As String)
            ViewState("ENTIDADE") = value
        End Set
    End Property

    Public Property IDReferencia() As Integer
        Get
            Return ViewState("IDReferencia")
        End Get
        Set(ByVal value As Integer)
            ViewState("IDReferencia") = value
        End Set
    End Property

    Public Sub CarregaDados(ByVal vIDReferencia As Integer)

        IDReferencia = vIDReferencia
        rptCamposAdicionais.DataSource = cls.ListarValores(Entidade, vIDReferencia)
        rptCamposAdicionais.DataBind()
    End Sub

    Public Sub GravarDados(ByVal vIDReferencia As Integer)
        IDReferencia = vIDReferencia
        For Each item As RepeaterItem In rptCamposAdicionais.Items
            If item.ItemType = ListItemType.Item Or item.ItemType = ListItemType.AlternatingItem Then
                Dim txt As TextBox = item.FindControl("txtValor")
                Dim cbo As DropDownList = item.FindControl("cboValor")
                Dim hid As HiddenField = item.FindControl("hidIDCampoAdicional")
                Dim strValor As String = ""
                If cbo.Visible Then
                    strValor = cbo.SelectedValue
                Else
                    strValor = txt.Text
                End If
                cls.GravarValor(vIDReferencia, Entidade, hid.Value, strValor)
            End If
        Next
    End Sub

    Protected Sub rptCamposAdicionais_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptCamposAdicionais.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim txt As TextBox = e.Item.FindControl("txtValor")
            Dim cbo As DropDownList = e.Item.FindControl("cboValor")
            Dim val As RequiredFieldValidator = e.Item.FindControl("valValor")
            If e.Item.DataItem("Tipo") = "1" Then
                cbo.Visible = True
                txt.Visible = False
                val.Enabled = False
                cbo.DataSource = cls.ListarOpcoes(Entidade, e.Item.DataItem("IDCampoAdicional"))
                cbo.DataBind()
                cbo.Items.Insert(0, New ListItem("", ""))
                cbo.Width = System.Web.UI.WebControls.Unit.Pixel(e.Item.DataItem("Tamanho"))
                setComboValue(cbo, e.Item.DataItem("Valor"))
            Else
                cbo.Visible = False
                txt.Visible = True
                txt.Width = System.Web.UI.WebControls.Unit.Pixel(e.Item.DataItem("Tamanho"))
                txt.MaxLength = e.Item.DataItem("TamanhoMaximo")
                val.Enabled = IIf(e.Item.DataItem("Requirido"), True, False)
                txt.Text = e.Item.DataItem("Valor")
            End If
        End If
    End Sub

End Class

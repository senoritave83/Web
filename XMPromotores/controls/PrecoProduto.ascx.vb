Imports Classes

<PersistChildren(True)> _
Partial Class controls_PrecoProduto

    Inherits System.Web.UI.UserControl
    Protected m_intProduto As Integer = 0
    Protected m_decProduto As Integer = 0
    Protected m_intMes As Integer = 0
    Protected m_intDiaSemana As Integer = 0
    Protected m_intSemanaMes As Integer = 0

    Dim clsProd As clsProduto



    Public Overridable Property IdProduto() As Integer
        Get
            Return m_intProduto
        End Get
        Set(ByVal Value As Integer)
            ViewState("IdProduto") = Value
            clsProd = New clsProduto
            ListarPrecos()
            clsProd = Nothing
        End Set
    End Property

    Public Sub ListarPrecos()

        grdPrecos.DataSource = clsProd.ListarPrecosProduto(ViewState("IdProduto"))
        grdPrecos.DataBind()

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim est As New clsEstado
            drpUF.DataSource = est.Listar()
            drpUF.DataBind()
            drpUF.Items.Insert(0, New ListItem("...", ""))

        End If

    End Sub

    Protected Sub btnIncluir_ServerClick(sender As Object, e As System.EventArgs) Handles btnIncluir.ServerClick

        If drpUF.SelectedIndex > 0 And IsNumeric(txtPrecoMinimoSugerido.Text) And IsNumeric(txtPrecoMaximoSugerido.Text) Then

            clsProd = New clsProduto

            With clsProd
                .AdicionarPrecosProduto(ViewState("IdProduto"), getComboValues(drpUF), txtPrecoMinimoSugerido.Text, txtPrecoMaximoSugerido.Text)
            End With

            drpUF.SelectedIndex = 0
            txtPrecoMinimoSugerido.Text = ""
            txtPrecoMaximoSugerido.Text = ""

            ListarPrecos()
            clsProd = Nothing

        End If

    End Sub


    Protected Sub grdPrecos_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdPrecos.RowCommand

        If e.CommandName = "Excluir" Then

            clsProd = New clsProduto
            clsProd.Load(ViewState("IdProduto"))

            Dim f_iIndex As Integer = Convert.ToInt32(e.CommandArgument)
            Dim p_UF As String = grdPrecos.DataKeys(f_iIndex).Value
            clsProd.ExcluirPrecoSugerido(ViewState("IdProduto"), p_UF)

            drpUF.SelectedIndex = 0
            txtPrecoMinimoSugerido.Text = ""
            txtPrecoMaximoSugerido.Text = ""

            ListarPrecos()
            clsProd = Nothing

        End If

    End Sub
End Class
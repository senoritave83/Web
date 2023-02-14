Imports Classes
Imports System.Web.Services
Imports XMSistemas.Web


Partial Class formulario_segmentos
    Inherits XMWebPage

    Protected cls As clsFormVisita

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsFormVisita
        If Not Page.IsPostBack Then
            ViewState("IDVISITA") = CInt("0" & Request("IDVisita"))
            ViewState("IDCATEGORIA") = CInt("0" & Request("cat"))
            ViewState("IDSUBCATEGORIA") = CInt("0" & Request("sct"))
            ViewState("IDFORNECEDOR") = CInt("0" & Request("for"))
        End If
        cls.Load(ViewState("IDVISITA"))

        If cls.IDVisita = 0 Then
            Response.Redirect("default.aspx")
        End If

        If Not Page.IsPostBack Then

            Dim clsLoj As New clsLoja()
            clsLoj.Load(cls.IDLoja)

            lblIdLoja.Text = clsLoj.IDLoja
            lblIdPromotor.Text = cls.IDPromotor
            lblPromotor.Text = cls.Promotor

            lblLoja.Text = clsLoj.Codigo & " - " & cls.Loja
            clsLoj = Nothing
            lblData.Text = cls.Data

            clsLoj = Nothing


            hidIdentifier.Value = XMCrypto.Encrypt(User.IDEmpresa & "_" & User.IDUser & "_" & ViewState("IDVISITA"))
            BindGrid()

        End If



    End Sub

    Protected Sub BindGrid()

        Dim ds As Data.DataSet = Nothing
        Dim ret As IPaginaResult
        ret = cls.ListarProdutosFormulario(ViewState("IDCATEGORIA"), ViewState("IDSUBCATEGORIA"), ViewState("IDFORNECEDOR"), "", False, Paginate1.CurrentPage, 20)
        Paginate1.DataSource = ret
        Paginate1.DataBind()
        xmProdutos.RowDataSource = ret.Tables(1).Rows
        xmProdutos.ColDataSource = ret.Tables(2).Rows
        xmProdutos.DataSource = ret.Tables(3).Rows
        xmProdutos.ColKeyNames = "IDPergunta"
        xmProdutos.RowKeyNames = "IDProduto"
        xmProdutos.DataKeyNames = "IDPergunta,IDProduto"
        xmProdutos.DataBind()


    End Sub

    Protected Function getPreco(ByVal data As Object, ByVal decimals As Integer) As String
        If IsDBNull(data) Then
            Return ""
        Else
            Return FormatNumber(data, decimals)
        End If
    End Function


    Protected Function getValue(ByVal data As Object) As String
        If IsDBNull(data) Then
            Return ""
        Else
            Return data
        End If
    End Function

    Protected Function GetBooleanCompare(ByVal data As Object, ByVal value As Boolean) As Boolean
        If data Is Nothing Then
            Return False
        ElseIf IsDBNull(data) Then
            Return False
        ElseIf data = value Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Function GetTinyintCompare(ByVal data As Object, ByVal value As Byte) As Boolean
        If data Is Nothing Then
            Return False
        ElseIf IsDBNull(data) Then
            Return False
        ElseIf data = value Then
            Return True
        Else
            Return False
        End If
    End Function

    <WebMethod()> _
    Public Shared Sub GravarXMLItem(ByVal vIdentifier As String, ByVal vIDProduto As Integer, ByVal vXML As String)
        Dim arrIdentifier() As String = Split(XMCrypto.Decrypt(vIdentifier), "_")
        Dim intIDVisita, intIDEmpresa, intIDUsuario As Integer

        intIDEmpresa = arrIdentifier(0)
        intIDUsuario = arrIdentifier(1)
        intIDVisita = arrIdentifier(2)

        Dim frm As New clsFormVisita.clsFormProduto
        frm.GravarPesquisa(intIDVisita, intIDUsuario, intIDEmpresa, vIDProduto, vXML)

    End Sub


    Protected Sub xmProdutos_ItemDataBound(ByVal sender As Object, ByVal e As XMSistemas.Web.UI.WebControls.XMCrossRepeaterItemEventArgs) Handles xmProdutos.ItemDataBound
        If e.Item.ItemType = XMSistemas.Web.UI.WebControls.XMCrossRepeater.CrossItemType.DataItem Then
            Dim ctr As control_pergunta = e.Item.FindControl("pergunta1")
            If (e.Item.DataItem("Acao") And 4) <> 0 Then

                Dim prds As New clsFormVisita.clsFormProduto
                Dim dr As Object = Nothing

                If e.Item.DataItem("TipoCampo") = 0 Then
                    dr = cls.ListarRespostasEntidade(enTipoEntidade.Produto, e.Item.DataItem("IDProduto"), e.Item.DataItem("IDPergunta"), DataClass.enReturnType.DataSet)
                End If
                ctr.Mostrar(e.Item.DataItem("IDPergunta"), dr, e.Item.DataItem("Respostas"))
                ctr.Visible = True
            Else
                ctr.Visible = False
            End If
        ElseIf e.Item.ItemType = XMSistemas.Web.UI.WebControls.XMCrossRepeater.CrossItemType.RowHeaderItem Then
            Dim txtPreco As TextBox = e.Item.FindControl("txtPreco")
            If e.Item.DataItem("PrecoMinimo") > 0 Then
                txtPreco.Attributes.Add("min", FormatNumber(e.Item.DataItem("PrecoMinimo"), 2))
            End If
            If e.Item.DataItem("PrecoMaximo") > 0 Then
                txtPreco.Attributes.Add("max", FormatNumber(e.Item.DataItem("PrecoMaximo"), 2))
            End If
            If (e.Item.DataItem("Acao") And 2) <> 0 Then
                txtPreco.Attributes.Add("validar", "true")
                txtPreco.Attributes.Add("obrigatorio", "true")
                txtPreco.Attributes.Add("campo", "Preço do produto " & e.Item.DataItem("Descricao"))
            End If
            Dim txtEstoque As TextBox = e.Item.FindControl("txtEstoque")
            If (e.Item.DataItem("Acao") And 1) <> 0 Then
                If CInt("0" & e.Item.DataItem("VisualizouEstoque")) = 1 Then
                    txtEstoque.Attributes.Add("validar", "true")
                    txtEstoque.Attributes.Add("obrigatorio", "true")
                End If
                txtEstoque.Attributes.Add("campo", "Estoque do produto " & e.Item.DataItem("Descricao"))
            End If


        End If
    End Sub

    Protected Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        BindGrid()
    End Sub
End Class


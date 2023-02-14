Imports Classes
Imports XMSistemas.Web
Imports System.Web.Services

Partial Class controls_respostas
    Inherits System.Web.UI.UserControl

    Protected cls As clsFormVisita

    Public Property [ReadOnly]() As Boolean
        Get
            If ViewState("ReadOnly") Is Nothing Then
                Return False
            End If
            Return ViewState("ReadOnly")
        End Get
        Set(ByVal value As Boolean)
            ViewState("ReadOnly") = value
        End Set
    End Property


    Public Shadows Property Page() As XMWebPage
        Get
            Return MyBase.Page
        End Get
        Set(ByVal value As XMWebPage)
            MyBase.Page = value
        End Set
    End Property

    Public Property IDVisita() As Integer
        Get
            Return ViewState("IDVISITA")
        End Get
        Set(ByVal value As Integer)
            ViewState("IDVISITA") = value
        End Set
    End Property

    Public Property TipoEntidade() As enTipoEntidade
        Get
            Return ViewState("TIPOENTIDADE")
        End Get
        Set(ByVal value As enTipoEntidade)
            ViewState("TIPOENTIDADE") = value
        End Set
    End Property

    Public Property IDReferencia() As Integer
        Get
            Return ViewState("IDREFERENCIA")
        End Get
        Set(ByVal value As Integer)
            ViewState("IDREFERENCIA") = value
        End Set
    End Property

    Public Property IDPesquisa() As Integer
        Get
            If ViewState("IDPESQUISA") Is Nothing Then
                Return 0
            End If
            Return ViewState("IDPESQUISA")
        End Get
        Set(ByVal value As Integer)
            ViewState("IDPESQUISA") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        cls = New clsFormVisita
        'If Not Page.IsPostBack Then
        '    ViewState("IDVISITA") = CInt("0" & Request("IDVisita"))
        '    ViewState("TIPOENTIDADE") = CInt("0" & Request("TipoEntidade"))
        '    ViewState("IDREFERENCIA") = CInt("0" & Request("IDReferencia"))
        'End If
        cls.Load(IDVisita)

        ScriptManager.GetCurrent(Me.Page).EnablePageMethods = True

        If cls.IDVisita > 0 Then
            If Not Page.IsPostBack Then
                hidIdentifier.Value = XMCrypto.Encrypt(Page.User.IDEmpresa & "_" & Page.User.IDUser & "_" & IDVisita & "_" & IDPesquisa)
                BindGrid()
                Me.Visible = True
            End If
        Else
            Me.Visible = False
        End If

    End Sub

    Protected Sub BindGrid()

        Dim ds As Data.DataSet = Nothing
        Dim ret As IPaginaResult
        ret = cls.ListarPerguntasFormulario(TipoEntidade, IDReferencia, IDPesquisa, "", False, Paginate1.CurrentPage, 20)
        Paginate1.DataSource = ret
        Paginate1.DataBind()
        xmProdutos.RowDataSource = ret.Tables(1).Rows
        xmProdutos.ColDataSource = ret.Tables(2).Rows
        xmProdutos.DataSource = ret.Tables(3).Rows
        xmProdutos.ColKeyNames = "IDPergunta"
        xmProdutos.RowKeyNames = "IDReferencia"
        xmProdutos.DataKeyNames = "IDPergunta,IDReferencia"
        xmProdutos.DataBind()
        Paginate1.Visible = (ret.PageCount > 1)


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
    Public Shared Sub GravarXMLEntidadeItem(ByVal vIdentifier As String, ByVal vTipoEntidade As Integer, ByVal vIDReferencia As Integer, ByVal vXML As String)
        Dim arrIdentifier() As String = Split(XMCrypto.Decrypt(vIdentifier), "_")
        Dim intIDVisita, intIDEmpresa, intIDUsuario, intIDPesquisa As Integer

        intIDEmpresa = arrIdentifier(0)
        intIDUsuario = arrIdentifier(1)
        intIDVisita = arrIdentifier(2)
        intIDPesquisa = arrIdentifier(3)

        Dim frm As New clsFormVisita
        frm.GravarEntidadePesquisa(intIDVisita, intIDUsuario, intIDEmpresa, vTipoEntidade, vIDReferencia, intIDPesquisa, vXML)

    End Sub

    Public Shared Sub ApagarXMLEntidadeItem(ByVal vIdentifier As String, ByVal vTipoEntidade As Integer, ByVal vIDReferencia As Integer)
        Dim arrIdentifier() As String = Split(XMCrypto.Decrypt(vIdentifier), "_")
        Dim intIDVisita, intIDEmpresa, intIDUsuario, intIDPesquisa As Integer

        intIDEmpresa = arrIdentifier(0)
        intIDUsuario = arrIdentifier(1)
        intIDVisita = arrIdentifier(2)
        intIDPesquisa = arrIdentifier(3)

        Dim frm As New clsFormVisita
        frm.ApagarEntidadePesquisa(intIDVisita, intIDUsuario, intIDEmpresa, vTipoEntidade, vIDReferencia, intIDPesquisa)

    End Sub



    Protected Sub xmProdutos_ItemDataBound(ByVal sender As Object, ByVal e As XMSistemas.Web.UI.WebControls.XMCrossRepeaterItemEventArgs) Handles xmProdutos.ItemDataBound
        If e.Item.ItemType = XMSistemas.Web.UI.WebControls.XMCrossRepeater.CrossItemType.DataItem Then
            Dim ctr As control_pergunta = e.Item.FindControl("pergunta1")
            Dim ltr As Literal = e.Item.FindControl("ltrResposta")
            If Me.ReadOnly Then
                ltr.Text = e.Item.DataItem("Respostas")
                ltr.Visible = True
                ctr.Visible = False
            Else
                Dim prds As New clsFormVisita.clsFormProduto
                Dim dr As Object = Nothing

                If e.Item.DataItem("TipoCampo") = 0 Then
                    dr = cls.ListarRespostasEntidade(e.Item.DataItem("TipoEntidade"), e.Item.DataItem("IDReferencia"), e.Item.DataItem("IDPergunta"), DataClass.enReturnType.DataSet)
                End If
                ctr.Mostrar(e.Item.DataItem("IDPergunta"), dr, e.Item.DataItem("Respostas"))
                ctr.Visible = True
                ltr.Visible = False
            End If
        End If
    End Sub

    Protected Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        BindGrid()
    End Sub


End Class

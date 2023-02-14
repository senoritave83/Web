Imports System.Configuration.ConfigurationManager
Imports XMSistemas.Web.Base

Partial Class home_listaos
    Inherits XMProtectedPage

    Protected Const PageSize As Integer = 15

    Protected clsOS As clsOrdemServico
    Protected orderCookie As HttpCookie

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        clsOS = New clsOrdemServico()
        If Not IsPostBack Then

            If Request("Desc") Is Nothing Then
                ViewState("Desc") = 0
            Else
                ViewState("Desc") = IIf(Request("Desc") = 0, 1, 0)
            End If

            ViewState("Sort") = IIf(Request("Sort") Is Nothing, AppSettings("OrdenacaoPadrao_OS"), Request("Sort"))

            GravaCookiesOrdenacao()

            ViewState("Type") = Request("type")
            ViewState("CurrentPage") = CInt("0" & Request("CurrentPage"))

            JavascriptOrdenacao()

        End If

        BindGrid()

        hlkApagar.Visible = IsAdmin()

    End Sub

    Public ReadOnly Property GetQuery() As String
        Get
            Return "type=" & ViewState("Type") & "&Cliente=" & Server.UrlEncode(Request("Cliente")) & "&Responsavel=" & Request("Responsavel") & "&status=" & Request("status") & "&CurrentPage=" & ViewState("CurrentPage") & "&txtDataInicial=" & Request("txtDataInicial") & "&txtDataFinal=" & Request("txtDataFinal")
        End Get
    End Property

    Protected Sub GravaCookiesOrdenacao()
        Try
            If Not Request.Cookies("Ordem") Is Nothing Then
                If ViewState("Sort") <> AppSettings("OrdenacaoPadrao_OS") And _
                (ViewState("Sort") <> Server.HtmlEncode(Request.Cookies("Ordem")("Sort")) Or _
                ViewState("Desc") <> Server.HtmlEncode(Request.Cookies("Ordem")("Desc"))) Then
                    orderCookie = New HttpCookie("Ordem")
                    orderCookie.Values("Sort") = ViewState("Sort")
                    orderCookie.Values("Desc") = ViewState("Desc")
                    orderCookie.Expires = DateTime.Now.AddDays(365)
                    Response.Cookies.Add(orderCookie)
                Else
                    ViewState("Sort") = Server.HtmlEncode(Request.Cookies("Ordem")("Sort"))
                    ViewState("Desc") = Server.HtmlEncode(Request.Cookies("Ordem")("Desc"))
                End If
            ElseIf ViewState("Sort") <> AppSettings("OrdenacaoPadrao_OS") Then
                orderCookie = New HttpCookie("Ordem")
                orderCookie.Values("Sort") = ViewState("Sort")
                orderCookie.Values("Desc") = ViewState("Desc")
                orderCookie.Expires = DateTime.Now.AddDays(365)
                Response.Cookies.Add(orderCookie)
            End If
        Catch
            Throw New ArgumentException("Erro ao tentar ordenar as OS.")
        End Try
    End Sub

    Public Sub BindGrid()

        Dim ret As IPaginaResult = Nothing

        ret = clsOS.ListarOrdens(Request("Cliente"), Request("Responsavel"), Request("txtDataInicial") & "", Request("txtDataFinal") & "", Request("Status") & "", ViewState("Sort") & "", ViewState("CurrentPage"), PageSize, ViewState("Desc"))

        Dim cls As New clsOrdemServico
        rptHistorico.DataSource = ret.Tables(0)
        rptHistorico.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()
    End Sub

    Public Sub rptGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)

        If e.CommandName = "Order" Then
            ViewState("Desc") = Not ViewState("Desc")
            ViewState("Sort") = e.CommandArgument
        ElseIf e.CommandName = "Paginate" Then
            If e.CommandArgument = "inc" Then
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            Else
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            End If
        End If

        BindGrid()

    End Sub

    Protected Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        ViewState("CurrentPage") = Paginate1.CurrentPage
        BindGrid()
    End Sub

    Protected Sub hlkApagar_Command(sender As Object, e As System.Web.UI.WebControls.CommandEventArgs) Handles hlkApagar.Command

        If e.CommandName = "ApagarOS" Then

            Dim strOS As String = Request("chkOS") & ""
            clsOS.Excluir(strOS)

            BindGrid()

        End If

    End Sub

    Public Function HeaderRepeater(ByVal p_Coluna As String, ByVal p_Ordem As String) As Boolean
        If ViewState("Sort") = p_Coluna And ViewState("Desc") = p_Ordem Then
            Return True
        ElseIf ViewState("Sort") = p_Coluna And ViewState("Desc") = p_Ordem Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub JavascriptOrdenacao()

        Dim fncJavascript As String = "function fncOrdenacao(p_Sort)"
        fncJavascript &= "  {"
        fncJavascript &= "      var vUrl = 'listaos.aspx?cliente="
        fncJavascript &= IIf(Request("cliente") Is Nothing, "", Request("cliente"))
        fncJavascript &= "&responsavel="
        fncJavascript &= IIf(Request("responsavel") Is Nothing, "", Request("responsavel"))
        fncJavascript &= "&status="
        fncJavascript &= IIf(Request("status") Is Nothing, "", Request("status"))
        fncJavascript &= "&txtDataInicial="
        fncJavascript &= IIf(Request("txtDataInicial") Is Nothing, "", Request("txtDataInicial"))
        fncJavascript &= "&txtDataFinal="
        fncJavascript &= IIf(Request("txtDataFinal") Is Nothing, "", Request("txtDataFinal"))
        fncJavascript &= "&type=2&Sort=' + p_Sort + "
        fncJavascript &= "'&Desc=" & ViewState("Desc") & "';"
        fncJavascript &= "window.location.href = vUrl;"
        fncJavascript &= "  }"

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "fncOrdenacao", fncJavascript, True)

    End Sub

End Class

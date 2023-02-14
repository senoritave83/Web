Imports Classes
Imports System.Data

Partial Class Relatorios_performancerevendaregiao_det
    Inherits XMWebPage
    Protected Soma As New Somarizador
    Protected pilhaIdRegional As Stack = New Stack

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            ViewState("pilhaIdRegional") = pilhaIdRegional
            Dim p_IdEmpresaUsuario As Integer = User.IDEmpresa

            If p_IdEmpresaUsuario = 0 Then

                Dim strIdRegional As String = Request("idreg")

                If Not IsNumeric(strIdRegional) Then

                    strIdRegional = User.IDRegional
                End If

                ViewState("pilhaIdRegional").Push(strIdRegional)
            Else

                ViewState("pilhaIdRegional").Push(0)
            End If

            If Request("pr") = "2" Then 'Abre pop up para Impressão
                Try
                    showData(Request("em"), Session("pilhaIdRegional").Peek, Request("di"), Request("df"))
                    Filtro1.Visible = False
                    lblPeriodoData.Text = "Período Selecionado: de " & Request("di") & " a " & Request("df")
                Catch
                    Filtro1.Visible = False
                    lblPeriodoData.Text = "O Tempo Limite para Impressão Expirou. Filtre o Relatório Novamente!"
                End Try
            Else

                showData(Filtro1.IDEmpresa, ViewState("pilhaIdRegional").Peek, Filtro1.DataInicial, Filtro1.DataFinal)
            End If

        End If

    End Sub

    Sub ItemCommandRegionais(Sender As Object, e As RepeaterCommandEventArgs)

        Dim strIdRegional As String = CType(e.CommandSource, LinkButton).CommandArgument

        If ViewState("pilhaIdRegional").Peek <> strIdRegional Then ViewState("pilhaIdRegional").Push(strIdRegional) 'Verificação para não inserir o mesmo IdRegional na Pilha.
        ViewState("IdRevenda") = ""

        showData(Filtro1.IDEmpresa, ViewState("pilhaIdRegional").Peek, Filtro1.DataInicial, Filtro1.DataFinal)
    End Sub

    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        showData(Filtro1.IDEmpresa, ViewState("pilhaIdRegional").Peek, Filtro1.DataInicial, Filtro1.DataFinal)
    End Sub

    Private Sub showData(ByVal vIdEmpresa As Integer, ByVal vIdRegional As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String)

        Dim dtsRoteiro As DataSet
        Dim rep As New clsRelatorio
        dtsRoteiro = rep.GetRelatorioPerformanceRevenda(vIdEmpresa, vIdRegional, vDataInicial, vDataFinal)

        If dtsRoteiro.Tables(1).Rows.Count = 0 Then

            divEmpty.Visible = True

        Else
            divEmpty.Visible = False

            ViewState("Tipo") = dtsRoteiro.Tables(0).Rows(0).Item("Tipo") & ""

            grdRelatorioRegionais.DataSource = dtsRoteiro.Tables(1)
            grdRelatorioRegionais.DataBind()

        End If

        rep = Nothing
        divVoltar.Visible = ViewState("pilhaIdRegional").Count > 1

        If Request("pr") <> "2" Then
            Session("pilhaIdRegional") = ViewState("pilhaIdRegional") 'Session("pilhaIdRegional") é usado para abrir o pop up de Impressão com as mesmas informações da tela de navegação.
        End If
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request("pr") = "2" Then
            Me.MasterPageFile = "imprimir.master"
        End If
    End Sub

    Protected Sub grdRelatorioRegionais_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles grdRelatorioRegionais.ItemDataBound

        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then

            Dim lnk As LinkButton = e.Item.FindControl("lnkItem")
            Dim lnkIdRevenda As HyperLink = e.Item.FindControl("lnkIdRevenda")

            If Not lnk Is Nothing Then

                If ViewState("Tipo") = "Revenda" Then

                    If Request("pr") <> "2" Then lnkIdRevenda.NavigateUrl = "performance_det.aspx?em=" & lnk.CommandArgument & "&di=" & Filtro1.DataInicial & "&df=" & Filtro1.DataFinal & "&pr=0"

                    lnkIdRevenda.Visible = True
                    lnk.Visible = False
                End If
            End If

        End If

    End Sub

    'Volta 1 Nível no resultado do Repeater (grdRelatorioRegionais).
    Protected Sub lnkVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkVoltar.Click

        If ViewState("pilhaIdRegional").Count > 1 Then 'Verificação para não esvaziar totalmente a pilha.

            ViewState("pilhaIdRegional").Pop()
        End If

        showData(Filtro1.IDEmpresa, ViewState("pilhaIdRegional").Peek, Filtro1.DataInicial, Filtro1.DataFinal)
    End Sub
End Class

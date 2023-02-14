Imports System.Configuration.ConfigurationManager
Imports XMSistemas.Web.UI.WebControls.ReportControls

Partial Class reports_Relatorio
    Inherits XMWebPage
    'Dim strIdSchedule As String = ""

    Public Property PossuiPeriodoDatas() As Boolean
        Get
            If ViewState("PossuiPeriodoDatas") Is Nothing Then
                Return False
            End If
            Return ViewState("PossuiPeriodoDatas")
        End Get
        Set(ByVal value As Boolean)
            ViewState("PossuiPeriodoDatas") = value
        End Set
    End Property

    Protected Enum enPageMode
            Filtros = 0
            Agendamento = 1
            Erro = 2
            Favoritos = 3
    End Enum

            'Protected Sub GravarPasta1_OnTelaChanged() Handles GravarPasta1.onTelaChanged
            '    btnFavoritosGravar.Visible = (GravarPasta1.TipoTela = GravarPasta.enTipoTela.Favorito)
            'End Sub

    Protected Property PageMode() As enPageMode
        Get
            If ViewState("PageMode") Is Nothing Then
                Return enPageMode.Filtros
            End If
            Return ViewState("PageMode")
        End Get
        Set(ByVal value As enPageMode)
            ViewState("PageMode") = value
            If value = enPageMode.Filtros Then
                btnVisualizar.Visible = True
                btnAgendar.Visible = True
                btnVoltar.Visible = False
                btnGravar.Visible = False
                'btnFavorito.Visible = True
                'plhFavorito.Visible = False
                'plhRelatorio.Visible = True
                XMReportFilters1.Mode = XMSistemas.Web.UI.WebControls.ReportControls.XMReportFilters.enMode.Filters
                'plhErro.Visible = False
                Dim strTeste As String = ""
            ElseIf value = enPageMode.Agendamento Then
                btnVisualizar.Visible = False
                btnAgendar.Visible = False
                btnVoltar.Visible = True
                btnGravar.Visible = True
                'btnFavorito.Visible = False
                'plhRelatorio.Visible = True
                'plhFavorito.Visible = False
                XMReportFilters1.Mode = XMSistemas.Web.UI.WebControls.ReportControls.XMReportFilters.enMode.Scheduling
                'plhErro.Visible = False
                'ElseIf value = enPageMode.Erro Then
                '    btnVisualizar.Visible = False
                '    btnAgendar.Visible = False
                '    btnVoltar.Visible = False
                '    btnGravar.Visible = False
                'btnFavorito.Visible = False
                'plhRelatorio.Visible = True
                'plhFavorito.Visible = False
                'plhErro.Visible = True
            ElseIf value = enPageMode.Favoritos Then
                'plhErro.Visible = False
                'plhFavorito.Visible = True
                'plhRelatorio.Visible = False
            End If
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim fgPeriodo As Byte = 0

        If Not Page.IsPostBack Then

            XMReportFilters1.FixedParameters.Add("IDEMPRESA", Me.User.IDEmpresa)
            XMReportFilters1.FixedParameters.Add("IDUSUARIO", Me.User.IDUser)

            ViewState("strIDSchedule") = Request("IDSchedule")
            If Not String.IsNullOrEmpty(ViewState("strIDSchedule")) Then
                XMReportFilters1.LoadScheduling(ViewState("strIDSchedule"))
            Else
                Dim strPath As String = SettingsExpression.GetProperty("reportspath", "", "/")
                strPath &= Request("path")
                'strPath &= XMSistemas.Web.XMCrypto.Decrypt(Request("path"))
                XMReportFilters1.ReportPath = strPath
            End If

            XMReportFilters1.ReportServerURL = AppSettings("ReportServerURL")


            For Each prm In XMReportFilters1.Parameters

                If prm.Name = "PERIODO" Then fgPeriodo += 1
                If prm.Name = "DATAINICIAL" Then fgPeriodo += 2
                If prm.Name = "DATAFINAL" Then fgPeriodo += 4

            Next

            PossuiPeriodoDatas = (fgPeriodo = 7)

            If PossuiPeriodoDatas Then

                XMReportFilters1.Parameters.Insert(0, New XMSistemas.Web.UI.WebControls.ReportControls.XMReportParameter("TipoDatas", "Tipo de Datas", enControlType.dropdown, False, True, False, RSService.ParameterTypeEnum.Integer))
                XMReportFilters1.Parameters("TipoDatas").EnableAutoPostBack = True

                XMReportFilters1.Parameters("DATAINICIAL").Value = ""
                XMReportFilters1.Parameters("DATAFINAL").Value = ""

            End If

            PageMode = enPageMode.Filtros

        End If
    End Sub

    Protected Sub btnAgendar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgendar.Click
        PageMode = enPageMode.Agendamento
    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        PageMode = enPageMode.Filtros
    End Sub

    Protected Sub btnVisualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        XMReportFilters1.PostXML("relatoriodet.aspx", "Width=1000px Height=600px scrollbars=yes resizable=yes", "report_view")
    End Sub

    Protected Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        XMReportFilters1.SaveScheduling()
        Response.Redirect("schedule.aspx")
    End Sub

    Protected Sub XMReportFilters1_OnError(ByVal ex As System.Exception) Handles XMReportFilters1.OnError
        PageMode = enPageMode.Erro
        'ltrErro.Text = ex.Message
    End Sub

    Protected Sub XMReportFilters1_OnFilterChanged(ByVal source As Object, ByVal args As XMSistemas.Web.UI.WebControls.ReportControls.XMReportBase.XMFilterArgs) Handles XMReportFilters1.OnFilterChanged
        If PossuiPeriodoDatas Then
            If args.Filter.ToUpper = "TIPODATAS" Then
                XMReportFilters1.Parameters("PERIODO").Visible = (XMReportFilters1.Parameters("TipoDatas").Value = 2)
                XMReportFilters1.Parameters("DATAINICIAL").Value = ""
                XMReportFilters1.Parameters("DATAFINAL").Value = ""
                XMReportFilters1.Parameters("DATAINICIAL").Visible = (XMReportFilters1.Parameters("TipoDatas").Value = 1)
                XMReportFilters1.Parameters("DATAFINAL").Visible = (XMReportFilters1.Parameters("TipoDatas").Value = 1)
            ElseIf args.Filter.ToUpper = "DATAINICIAL" Then
                If Not IsDate(XMReportFilters1.Parameters("DATAINICIAL").Value) Then
                    XMReportFilters1.Parameters("DATAINICIAL").Value = ""
                End If
            ElseIf args.Filter.ToUpper = "DATAFINAL" Then
                If Not IsDate(XMReportFilters1.Parameters("DATAFINAL").Value) Then
                    XMReportFilters1.Parameters("DATAFINAL").Value = ""
                End If
            End If
        End If
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        If Not Page.IsPostBack Then
            If PossuiPeriodoDatas Then
                Dim li As New ListItem("Entre Datas", "1")
                If XMReportFilters1.Parameters("TipoDatas").Value = "" Then
                    li.Selected = True
                    XMReportFilters1.Parameters("TipoDatas").Value = "1"
                    XMReportFilters1.Parameters("PERIODO").Visible = (XMReportFilters1.Parameters("TipoDatas").Value = 2)
                    XMReportFilters1.Parameters("DATAINICIAL").Visible = (XMReportFilters1.Parameters("TipoDatas").Value = 1)
                    XMReportFilters1.Parameters("DATAFINAL").Visible = (XMReportFilters1.Parameters("TipoDatas").Value = 1)
                End If
                XMReportFilters1.Parameters("TipoDatas").Itens.Add(li)
                XMReportFilters1.Parameters("TipoDatas").Itens.Add(New ListItem("Por Período", "2"))

                If Not String.IsNullOrEmpty(ViewState("strIDSchedule")) Then
                    RefreshFieldsTipoDatas()
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Método responsável por "recarregar" o agendamento e exibir o campo TipoData correspondente.
    ''' http://desenv.xmsistemas.com.br/wiki/tarefas/Tarefa.aspx?IDsubtarefa=3408
    ''' http://desenv.xmsistemas.com.br/wiki/tarefas/Tarefa.aspx?IDsubtarefa=3502
    ''' </summary>
    Protected Sub RefreshFieldsTipoDatas()

        XMReportFilters1.LoadScheduling(ViewState("strIDSchedule"))
        XMReportFilters1.Parameters("PERIODO").Visible = (XMReportFilters1.Parameters("TipoDatas").Value = 2)
        XMReportFilters1.Parameters("DATAINICIAL").Visible = (XMReportFilters1.Parameters("TipoDatas").Value = 1)
        XMReportFilters1.Parameters("DATAFINAL").Visible = (XMReportFilters1.Parameters("TipoDatas").Value = 1)
    End Sub

End Class

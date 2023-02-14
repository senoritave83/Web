Imports System
Imports System.Data
Imports Classes

Partial Class reports_rptRoteirosDet
    Inherits XMWebPage

    Dim rpt As clsReports
    Public lstDiasFolga As Generic.List(Of String)

    Private Sub MontaFolga(ByVal vDataInicial As String, ByVal vDataFinal As String)

        lstDiasFolga = New Generic.List(Of String)

        Dim r As New clsRoteiroPeriodo
        Dim dr As IDataReader = r.ListarDiasFolgaPromotor(0, vDataInicial, vDataFinal)

        Do While dr.Read
            lstDiasFolga.Add(dr(2) & "_" & Format(dr(3), "ddMMyyyy"))
        Loop

        r = Nothing
    End Sub



    Public Function VerificaDiaFolga(ByVal vData As String, ByVal vIdPromotor As Integer) As Boolean

        If lstDiasFolga Is Nothing Then MontaFolga(ViewState("pi"), ViewState("pn"))
        Return lstDiasFolga.Contains(vIdPromotor & "_" & vData)

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            Try

                ViewState("crd") = Request("crd")
                ViewState("lid") = Request("lid")
                ViewState("pro") = Request("pro")
                ViewState("cli") = Request("cli")
                ViewState("loj") = Request("loj")
                ViewState("shop") = Request("shop")
                ViewState("tiploj") = Request("tiploj")
                ViewState("regiao") = Request("regs")
                ViewState("sta") = Request("sta")
                ViewState("stap") = Request("stap")
                ViewState("est") = Request("est")
                ViewState("pertxt") = Request("pertxt") & ""
                ViewState("per") = Request("per")

                Dim p_Temp As Object = Split(ViewState("per"), "||", , CompareMethod.Text)
                ViewState("pi") = p_Temp(0)
                ViewState("pn") = p_Temp(1)

                MontaFolga(ViewState("pi"), ViewState("pn"))

                Me.User.Log("Relatório de Roteiros", "Visualização do Relatório")

                OpenReport()

                Response.Clear()
                Response.ClearHeaders()

                'Response.AddHeader("Content-Length", strOutput.Length)
                Response.AddHeader("Last-Modified", Now().ToString)
                Response.AddHeader("Content-Disposition", "inline; filename=RELATORIO_ROTEIROS_VERTICAL_" & Now.ToString("ddMMyyyyhhmmss") & ".xls")
                Response.ContentType = "application/vnd.ms-excel"
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")

            Catch ex As System.Exception

                Dim sb As New System.Text.StringBuilder

                sb.Append("<table border=0 align='center' cellspacing='0'>")
                sb.Append("<tr><td class='Mensagem'><b>Erro : " & ex.Message & "</b></td></tr>")
                sb.Append("</table>")

                ltrMessage.Text = sb.ToString()
            Finally

                rpt = Nothing

            End Try

        End If

    End Sub

    Public Function getDayName(ByVal p_DayOfWeek As Integer) As String
        Dim dtfi As System.Globalization.DateTimeFormatInfo = System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat
        Return dtfi.GetDayName(p_DayOfWeek - 1)
    End Function

    Private Sub OpenReport()

        Dim rptResult As clsReports.RelatorioData = Nothing
        rpt = New clsReports()
        Dim ds As DataSet = rpt.getRelatorioRoteirosVertical(Me.User.IDEmpresa, _
                                                ViewState("cli"), ViewState("loj"), ViewState("shop"), _
                                                ViewState("crd"), ViewState("lid"), ViewState("pro"), _
                                                ViewState("tiploj"), ViewState("regiao"), ViewState("sta"), _
                                                ViewState("stap"), ViewState("est"), ViewState("pi"), ViewState("pn"))

        rptRelatorio.DataSource = ds
        rptRelatorio.DataBind()

        
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Me.Theme = ""
    End Sub
End Class


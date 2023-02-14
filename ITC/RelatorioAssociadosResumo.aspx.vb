Public Class RelatorioAssociadosResumo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Protected WithEvents CodigoHTML As System.Web.UI.WebControls.Literal
    Private pesq As New clsPesquisas()
    Private strItens As String = ""
    Private MaxPage As Integer

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then
            Viewstate("Pagina") = CInt(0 & Page.Request("P"))
            ViewState("Associados") = Page.Request("O")
            Viewstate("Tipo") = CInt(0 & Page.Request("T"))
            Viewstate("Ord") = CInt(0 & Page.Request("OR"))

            If Viewstate("Pagina") <= 0 Then
                Viewstate("Pagina") = 1
            End If

            If Viewstate("Ord") <= 0 Then
                Viewstate("Ord") = 1
            End If

            If ViewState("Tipo") = 2 Then
                Dim obj As Object = Split(ViewState("Associados"), ",")
                strItens = obj(ViewState("Pagina") - 1)
                MaxPage = UBound(obj) + 1
            Else
                strItens = ViewState("Associados")
            End If

            Pesquisar()

        End If

    End Sub

    Private Function Pesquisar()

        Dim strHTML As String = ""

        If Viewstate("Tipo") = 2 Then
            strHTML += "				<table width='96%' border='0'>"
            strHTML += "					<tr>"
            If Viewstate("Pagina") > 1 Then
                strHTML += "					    <td align='left' width='50%' nowrap><a href='RelatorioAssociados.aspx?T=" & Viewstate("Tipo") & "&O=" & ViewState("Associados") & "&P=" & Viewstate("Pagina") - 1 & "'><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Anterior</font></a></td>"
            Else
                strHTML += "					    <td align='left' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Anterior</font></td>"
            End If
            If Viewstate("Pagina") < MaxPage Then
                strHTML += "					    <td align='left' width='50%' nowrap><a href='RelatorioAssociados.aspx?T=" & Viewstate("Tipo") & "&O=" & ViewState("Associados") & "&P=" & Viewstate("Pagina") + 1 & "'><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Próxima</font></a></td>"
            Else
                strHTML += "					    <td align='left' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Próxima</font></td>"
            End If
            strHTML += "					</tr>"
            strHTML += "				</table>"
        End If

        strHTML += "<p STYLE='page-break-after: always'>" & vbCrLf 'quebra de página

        'TÍTULO
        strHTML += "				<table width='100%' border='0'>" & vbCrLf
        strHTML += "					<tr>" & vbCrLf
        strHTML += "						<td align='left'>&nbsp;</td>" & vbCrLf
        strHTML += "						<td width=100% align='center'><img src='img/logonewitc.png' border=0></td>" & vbCrLf
        strHTML += "					</tr>" & vbCrLf
        strHTML += "				</table>" & vbCrLf

        strHTML += "				<table width='100%' border='0'>" & vbCrLf
        strHTML += "					<tr>" & vbCrLf
        strHTML += "						<td align='left'><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Emissão: " & Day(Now) & "/" & Month(Now) & "/" & Year(Now) & "  " & Hour(Now) & ":" & Minute(Now) & "</font></td>" & vbCrLf
        strHTML += "					</tr>" & vbCrLf
        strHTML += "				</table>" & vbCrLf

        strHTML += "				<table width='100%' border='0'>" & vbCrLf
        strHTML += "					<tr>" & vbCrLf
        strHTML += "						<td width=100% align='left' valign=top>" & vbCrLf
        strHTML += "							<table width=100%>" & vbCrLf

        strHTML += "								<tr>"
        strHTML += "								    <td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Cliente</b></font></td>" & vbCrLf
        If Viewstate("Ord") = 6 Then
            strHTML += "								    <td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Razão Social</b></font></td>" & vbCrLf
        Else
            strHTML += "								    <td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Fantasia</b></font></td>" & vbCrLf
        End If
        strHTML += "								    <td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Vendedor</b> </font></td>" & vbCrLf
        strHTML += "								    <td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Módulo</b> </font></td>" & vbCrLf
        strHTML += "								    <td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Fim Plano</b></font></td>" & vbCrLf
        strHTML += "								    <td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Contato</b></font></td>" & vbCrLf
        strHTML += "								    <td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Cargo</b></font></td>" & vbCrLf
        strHTML += "								    <td width='100'><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Telefone</b></font></td>" & vbCrLf
        strHTML += "								    <td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>E-Mail</b></font></td>" & vbCrLf
        strHTML += "								</tr>"

        strHTML += "					<tr><td colspan=10 width=100%><img height=1 width=100% src='imagens/linha_preta.gif'></td></tr>" & vbCrLf

        Dim ds As DataSet = pesq.RelatorioAssociadosResumo(strItens, Viewstate("Ord"))
        Dim i As Integer
        If ds.Tables.Count > 0 Then
            Dim iCodigoAnterior As Integer = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1

                Dim iLength As Integer = 0
                If ds.Tables(0).Rows(i).Item("NOMECONTATO").length >= 30 Then
                    iLength = 30
                Else
                    iLength = ds.Tables(0).Rows(i).Item("NOMECONTATO").length()
                End If

                strHTML += "<tr height=10>"
                strHTML += "<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'>" & IIf(iCodigoAnterior <> ds.Tables(0).Rows(i).Item("CODIGO"), ds.Tables(0).Rows(i).Item("CODIGO"), "") & "</font></td>"
                If Viewstate("Ord") = 6 Then
                    strHTML += "<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'>" & IIf(iCodigoAnterior <> ds.Tables(0).Rows(i).Item("CODIGO"), ds.Tables(0).Rows(i).Item("RAZAOSOCIAL"), "") & "</font></td>"
                Else
                    strHTML += "<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'>" & IIf(iCodigoAnterior <> ds.Tables(0).Rows(i).Item("CODIGO"), ds.Tables(0).Rows(i).Item("FANTASIA"), "") & "</font></td>"
                End If
                strHTML += "<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'>" & IIf(iCodigoAnterior <> ds.Tables(0).Rows(i).Item("CODIGO"), ds.Tables(0).Rows(i).Item("VENDEDOR"), "") & "</font></td>"
                strHTML += "<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'>" & IIf(iCodigoAnterior <> ds.Tables(0).Rows(i).Item("CODIGO"), ds.Tables(0).Rows(i).Item("MODULO"), "") & "</font></td>"
                strHTML += "<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'>" & IIf(iCodigoAnterior <> ds.Tables(0).Rows(i).Item("CODIGO"), ds.Tables(0).Rows(i).Item("DATAATIVACAO"), "") & "</font></td>"
                strHTML += "<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'>" & Left(ds.Tables(0).Rows(i).Item("NOMECONTATO"), 20) & "</font></td>"
                strHTML += "<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'>" & ds.Tables(0).Rows(i).Item("CARGO") & "</font></td>"
                strHTML += "<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'>" & ds.Tables(0).Rows(i).Item("TELEFONE") & "</font></td>"
                strHTML += "<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'>" & ds.Tables(0).Rows(i).Item("EMAIL") & "</font></td>"
                strHTML += "</tr>" & vbCrLf

                iCodigoAnterior = ds.Tables(0).Rows(i).Item("CODIGO")

            Next
        End If

        strHTML += "							</table>" & vbCrLf
        strHTML += "						</td>" & vbCrLf
        strHTML += "					</tr>" & vbCrLf
        strHTML += "				</table>" & vbCrLf

        strHTML += "				<table width='100%' border='0'>" & vbCrLf
        strHTML += "					<tr><td width=100%><img height=1 width=100% src='imagens/linha_preta.gif'></td></tr>" & vbCrLf
        strHTML += "				</table>" & vbCrLf

        strHTML += "</p>"

        If Viewstate("Tipo") = 2 Then
            strHTML += "				<table width='96%' border='0'>"
            strHTML += "					<tr>"
            If Viewstate("Pagina") > 1 Then
                strHTML += "					    <td align='left' width='50%' nowrap><a href='RelatorioAssociados.aspx?T=" & Viewstate("Tipo") & "&O=" & ViewState("Associados") & "&P=" & Viewstate("Pagina") - 1 & "'><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Anterior</font></a></td>"
            Else
                strHTML += "					    <td align='left' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Anterior</font></td>"
            End If
            If Viewstate("Pagina") < MaxPage Then
                strHTML += "					    <td align='left' width='50%' nowrap><a href='RelatorioAssociados.aspx?T=" & Viewstate("Tipo") & "&O=" & ViewState("Associados") & "&P=" & Viewstate("Pagina") + 1 & "'><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Próxima</font></a></td>"
            Else
                strHTML += "					    <td align='left' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Próxima</font></td>"
            End If
            strHTML += "					</tr>"
            strHTML += "				</table>"
        End If

        CodigoHTML.Text = strHTML

    End Function

End Class

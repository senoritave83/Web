Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected WithEvents CodigoHTML As System.Web.UI.WebControls.Literal
    Private pesq As New clsPesquisas

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            'recuperar todos os parametros passados pela primeira pagina (filtro)
            ViewState("Nome") = Page.Request("Nome")
            ViewState("Vendedor") = Page.Request("Vendedor")
            ViewState("DataIni") = Page.Request("DataIni")
            ViewState("DataFin") = Page.Request("DataFin")
            ViewState("DataAge") = Page.Request("DataAge")

            Pesquisar()

        End If
    End Sub

    Private Function Pesquisar()

        Dim strHTML As String

        strHTML = "<table width=700 cellspacing=0 border=1 bordercolor=#000000>"
        strHTML += "     <tr>"
        strHTML += "			<td width=100%>"
        strHTML += "				<table width='100%' border='0'>"
        strHTML += "					<tr>"
        strHTML += "						<td align='left'><img src='imagens/logoitcrelatorio.jpg'></td>"
        strHTML += "						<td width=100% align='center'><img src='imagens/TituloRelatorioFollowUp.jpg' border=0></td>"
        strHTML += "					</tr>"
        strHTML += "				</table>"
        strHTML += "				<table width='100%' border='0'>"
        strHTML += "					<tr>"
        strHTML += "						<td align='left'><font class='f8Rel' face='verdana'  style='font-size: 8pt'>Emissão: " & Day(Now) & "/" & Month(Now) & "/" & Year(Now) & "  " & Hour(Now) & ":" & Minute(Now) & "</font></td>"
        strHTML += "					</tr>"
        strHTML += "				</table>"

        strHTML += "				<table width='100%' border='0'>"
        strHTML += "					<tr>"
        strHTML += "						<td width=100%><img height=1 width=100% src='imagens/linha_preta.gif'></td>"
        strHTML += "					</tr>"
        strHTML += "				</table>"

        Dim ds As DataSet = pesq.RelatorioFollowUp(ViewState("Nome"), ViewState("Vendedor"), ViewState("DataAge"), ViewState("DataIni"), ViewState("DataFin"))
        Dim i As Integer
        If ds.Tables.Count > 0 Then

            strHTML += "				<table width='100%' border='0'>"
            strHTML += "					<tr>"
            strHTML += "						<td width=100% align='left' valign=top>"
            strHTML += "							<table width=100%>"

            For i = 0 To ds.Tables(0).Rows.Count - 1

                If i = 0 Then 'montando o cabecalho
                    strHTML += "								<tr>"
                    strHTML += "			    					<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b><center>Nome do Associado:</center></b></font></td>"
                    strHTML += "		    						<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b><center>Vendedor:</center></b></font></td>"
                    strHTML += "	    							<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b><center>Data Agendada:</center></b></font></td>"
                    strHTML += "    								<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b><center>Data de Criação:</center></b></font></td>"
                    strHTML += "    								<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b><center>Descrição:</center></b></font></td>"
                    strHTML += "								</tr>"
                End If

                strHTML += "								<tr " & IIf(i Mod 2 = 0, "bgcolor=#d3d3d3", "") & ">"
                strHTML += "	    							<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'>" & ds.Tables(0).Rows(i).Item("RazaoSocial") & "</font></td>"
                strHTML += "		    						<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'>" & ds.Tables(0).Rows(i).Item("Nome") & "</font></td>"
                strHTML += "			    					<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><center>" & ds.Tables(0).Rows(i).Item("DataAgenda") & "</center></font></td>"
                strHTML += "				    				<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'><center>" & ds.Tables(0).Rows(i).Item("Data") & "</font></center></td>"
                strHTML += "				    				<td><font class='f8Rel' face='verdana'  style='font-size: 8pt'>" & ds.Tables(0).Rows(i).Item("Descricao") & "</font></td>"
                strHTML += "								</tr>"

            Next

            strHTML += "							</table>"
            strHTML += "						</td>"
            strHTML += "					</tr>"
            strHTML += "				</table>"

        End If

        strHTML += "				<table width='100%' border='0'>"
        strHTML += "					<tr><td width=100%><img height=1 width=100% src='imagens/linha_preta.gif'></td></tr>"
        strHTML += "				</table>"
        strHTML += "				<table width='100%' border='0'>"
        strHTML += "					<tr><td align='middle' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>www.itc.etc.br</b></font></td><td align='middle' width='50%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>E-mail: itc@itc.etc.br</b></font></td></tr>"
        strHTML += "				</table>"
        strHTML += "				<table width='96%' border='0'>"
        strHTML += "					<tr><td align='middle' width='100%' nowrap><font class='f8Rel' face='verdana'  style='font-size: 8pt'><b>Rua Conselheiro Brotero, 589 - Sobreloja 2 - São Paulo - SP - CEP 01154-001 - Fone/Fax: (11)3825-7511</b></font></td></tr>"
        strHTML += "				</table>"

        strHTML += "			</td>"
        strHTML += "		</tr>"
        strHTML += "	</table>"

        CodigoHTML.Text = strHTML

    End Function

End Class

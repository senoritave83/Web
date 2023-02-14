Public Class RelFObrDet
    Inherits XMWebPage

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then

            showReport()

        End If

    End Sub

    Private Sub showReport()

        Dim p_NomeObra As String = Me.Request("na") & ""
        Dim p_NomeVendedor As String = Me.Request("nv") & ""
        Dim p_DataInicial As String = Me.Request("di") & ""
        Dim p_DataFinal As String = Me.Request("df") & ""
        Dim p_AgendamentoInicial As String = Me.Request("ai") & ""
        Dim p_AgendamentoFinal As String = Me.Request("af") & ""
        Dim p_Descricao As String = Me.Request("ds") & ""
        Dim p_Prioridade As String = Me.Request("pr") & ""

        Dim p_Boolean As Boolean = False
        Dim fol As New FollowUp
        Dim dr As SqlClient.SqlDataReader = fol.relObras(Me.Usuario.IdEmpresa, Me.Usuario.IDUsuario, _
                                                            p_NomeObra, p_NomeVendedor, p_DataInicial, _
                                                            p_DataFinal, p_AgendamentoInicial, p_AgendamentoFinal, _
                                                            p_Descricao, p_Prioridade)
        Dim strHTML As String

        strHTML += " <div id='Tudo'>"
        strHTML += "    <div id='TopoRelatorioObra' style='margin:5px 10px 10px 10px'>"
        strHTML += "        <p>Emissão: " & Day(Now) & "/" & Month(Now) & "/" & Year(Now) & "  " & Hour(Now) & ":" & Minute(Now) & "</p>"
        strHTML += "    </div>"

        strHTML += "    <table width='650' border='0' cellpadding='0' cellspacing='0' class='TableRelatorio'>"
        strHTML += "		<tr class='Tit'>"
        strHTML += "		    <td width='150'>Data do Relato</td>"
        strHTML += "            <td>Obra</td>"
        strHTML += "            <td>Relator</td>"
        strHTML += "            <td>Agendamento</td>"
        strHTML += "            <td>&nbsp;</td>"
        strHTML += "		</tr>"

        Dim i As Integer = 0
        Dim cont As Integer = 0

        Do While dr.Read

            i += 1

            strHTML += "	<tr id='pHide" & i & "-1' name='pHide'>"
            strHTML += "		<td style='padding:10 0 5 0'>" & dr("DATA") & "</td>"
            strHTML += "		<td style='padding:10 0 5 0'><b>" & dr("Obra") & "</b></td>"
            strHTML += "		<td style='padding:10 0 5 0'>" & dr("VENDEDOR") & "</td>"
            strHTML += "		<td style='padding:10 0 5 0'>&nbsp;" & XMCheckDate(dr("FOLLOWUP")) & "</td>"
            strHTML += "		<td style='padding:10 0 5 0'><input type='button' value='Desativar' onclick='fncXMHide(""pHide" & i & """)' onmousemove='this.style.cursor=""hand"";' id='btnHide" & i & "'>&nbsp;&nbsp;" & vbCrLf
            strHTML += "        <a href='#' target:""_blank"" onclick=""window.open('followupobradetmini.aspx?idobra=" & CryptographyEncoded(dr("IDEMPRESA_OBRA")) & "', 'Pagina', 'STATUS=NO, TOOLBAR=NO, LOCATION=NO, DIRECTORIES=NO, RESISABLE=NO, SCROLLBARS=YES, TOP=10, LEFT=10, WIDTH=775, HEIGHT=355');""><img src='imagens/arrow-right.gif' alt='Ver Follow-Up's' border=0></a></td>" & vbCrLf
            strHTML += "	</tr>"
            strHTML += "	<tr id='pHide" & i & "-2' name='pHide' class='follow'>"
            strHTML += "		<td colspan=5 style='padding:0 0 0 0' height='127'><div style='font-size: 8pt; text-align: justify; text-justify: newspaper'>" & dr("DESCRICAO") & "</div></td>"
            strHTML += "	</tr>"
            strHTML += "	<tr id='pHide" & i & "-2' name='pHide' class='follow'>"
            strHTML += "		<td colspan=5 class='follow' align='left' style='padding:0 0 0 0'><div style='font-size: 8pt; text-align: justify; text-justify: newspaper; color:#EC6400'>" & "<b style='color:black'>Prioridade: </b>" & dr("PRIORIDADE") & "</div></td>"
            strHTML += "	</tr>"

            p_Boolean = Not p_Boolean

            cont = dr("CONTADOR")

            If (i Mod 4 = 0) And (i <> cont) Then
                '--RODAPÉ--
                strHTML += "    </table>"
                strHTML += "	<div id='RodapeRelatorio' align='center'>"
                strHTML += "	    <p>www.itc.etc.br  - E-mail: itc@itc.etc.br </p>"
                strHTML += "        <p>Rua Conselheiro Brotero, 589 - Sobreloja 2 - São Paulo - SP - CEP 01154-001 - Fone/Fax: (11)3825-7511</p>"
                strHTML += "    </div >"
                strHTML += "     <p style='page-break-after:always'/>" & vbCrLf 'Quebra de página

                '--CABEÇALHO--
                strHTML += "    <div id='TopoRelatorioObra' style='margin:5px 10px 10px 10px'>"
                strHTML += "        <p>Emissão: " & Day(Now) & "/" & Month(Now) & "/" & Year(Now) & "  " & Hour(Now) & ":" & Minute(Now) & "</p>"
                strHTML += "    </div>"

                strHTML += "    <table width='650' border='0' cellpadding='0' cellspacing='0' class='TableRelatorio'>"
                strHTML += "		<tr class='Tit'>"
                strHTML += "		    <td width='150'>Data do Relato</td>"
                strHTML += "            <td>Empresa</td>"
                strHTML += "            <td>Relator</td>"
                strHTML += "            <td>Agendamento</td>"
                strHTML += "            <td>&nbsp;</td>"
                strHTML += "		</tr>"
            End If
        Loop

        dr.Close()
        fol = Nothing

        strHTML += "    </table>"
        strHTML += "	<div id='RodapeRelatorio'>"
        strHTML += "	    <p>www.itc.etc.br  - E-mail: itc@itc.etc.br </p>"
        strHTML += "        <p>Rua Conselheiro Brotero, 589 - Sobreloja 2 - São Paulo - SP - CEP 01154-001 - Fone/Fax: (11)3825-7511</p>"
        strHTML += "    </div>"

        strHTML += "</div>"

        strHTML += "<script language='javascript'>" & vbCrLf
        strHTML += "     function fncXMHide(p)" & vbCrLf
        strHTML += "     {" & vbCrLf
        strHTML += "         obj = document.getElementById(p+'-1').style.display = 'none';" & vbCrLf
        strHTML += "         obj = document.getElementById(p+'-2').style.display = 'none';" & vbCrLf
        strHTML += "         obj = document.getElementById(p+'-3').style.display = 'none';" & vbCrLf
        strHTML += "     }" & vbCrLf
        strHTML += "</script>" & vbCrLf

        Response.Clear()
        Response.ClearHeaders()
        Response.Write(strHTML)

    End Sub

End Class

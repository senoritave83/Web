Imports System.Data.SqlClient

Public Class RelatorioObrasResumoD

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
            ViewState("Obras") = Request("o")
            ViewState("Ordenacao") = Page.Request("Q")
            Pesquisar()
        End If
    End Sub

    Private Function Pesquisar()

        Dim strHTML As String
        Dim blnQuebra As Boolean = False

        strHTML += "<div id='Tudo'>"



        Dim ds As DataSet = pesq.RelatorioObras(ViewState("Obras"), ViewState("Ordenacao"))
        Dim i As Integer
        If ds.Tables.Count > 0 Then

            For i = 0 To ds.Tables(0).Rows.Count - 1

                If i Mod 6 = 0 Then

                    If blnQuebra Then strHTML += "    <p id='pHide" & i & "' " & IIf(i < ds.Tables(0).Rows.Count - 1, " style='page-break-after: always'", "") & " name='pHide'>" & vbCrLf 'quebra de página

                    strHTML += "    <div style='align:center;height:50px;width:679px;margin:0 0 5px 33px'>"
                    strHTML += "        <img src='img/topo_resumo.jpg' border='0'>"
                    strHTML += "        <p>Emissão: " & Day(Now) & "/" & Month(Now) & "/" & Year(Now) & "  " & Hour(Now) & ":" & Minute(Now) & "</p>"
                    strHTML += "    </div>"

                End If

                strHTML += "<div style='padding:0 0 0 33px;'>"
                strHTML += "    <h4 style='width:445px;border-bottom:none;'><strong>" & ds.Tables(0).Rows(i).Item("PROJETO") & "</strong></h4>"
                strHTML += "    <h4 style='width:233px;border-bottom:none;'><strong>Data da Publicação:</strong> " & Format(ds.Tables(0).Rows(i).Item("PUBLICACAO"), "dd/MM/yyyy") & "</h4>"
                strHTML += "    <br class='clear' />"
                strHTML += "</div>"

                strHTML += "<div class='resumo'>"
                strHTML += "    <cite style='width:250px;border-bottom:none;'><strong>Código ITC:</strong> " & ds.Tables(0).Rows(i).Item("CODIGOANTIGO") & "</cite>"
                strHTML += "<br class='clear' />"

                strHTML += "<cite style='width:340px;border-bottom:none;'><strong>Endereço:</strong> " & ds.Tables(0).Rows(i).Item("ENDERECO") & "</cite>"
                strHTML += "<cite style='border-bottom:none;'><strong>Cidade:</strong> " & ds.Tables(0).Rows(i).Item("CIDADE") & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Estado:</strong> " & ds.Tables(0).Rows(i).Item("ESTADO") & "</cite>"
                strHTML += "<br class='clear' />"

                strHTML += "<cite style='width:340px;border-bottom:none;'><strong>Segmento de Atuação:</strong> " & ds.Tables(0).Rows(i).Item("DESCRICAOTIPO") & "</cite>"
                strHTML += "<cite style='border-bottom:none;'><strong>Estágio Atual:</strong> " & ds.Tables(0).Rows(i).Item("DESCRICAOESTAGIO") & "</cite>"
                strHTML += "<br class='clear' />"

                strHTML += "<cite style='width:340px;border-bottom:none;'><strong>Área Construída m&sup2;:</strong> "
                If IsDBNull(ds.Tables(0).Rows(i).Item("AREACONSTRUIDA")) Then
                    strHTML += "0,00"
                Else
                    strHTML += FormatNumber(ds.Tables(0).Rows(i).Item("AREACONSTRUIDA"), 2)
                End If
                strHTML += "</cite>"

                strHTML += "<cite style='border-bottom:none;'><strong>Valor (US$ 1.000):</strong>"
                If IsDBNull(ds.Tables(0).Rows(i).Item("VALOR")) Then
                    strHTML += "0,00"
                Else
                    strHTML += FormatNumber(ds.Tables(0).Rows(i).Item("VALOR"), 2)
                End If
                strHTML += "</cite>"

                strHTML += "<br class='clear' />"

                strHTML += "<cite style='width:340px;border-bottom:none;'><strong>" & ds.Tables(0).Rows(i).Item("CARGOCONTATO") & ":</strong> " & ds.Tables(0).Rows(i).Item("CONTATO") & "</cite>"
                strHTML += "<cite style='border-bottom:none;'><strong>Empresa:</strong> " & ds.Tables(0).Rows(i).Item("FANTASIA") & "</cite>"
                strHTML += "<br class='clear' />"

                If ds.Tables(0).Rows(i).Item("DDD").Trim() <> "" And ds.Tables(0).Rows(i).Item("TELEFONE").Trim() <> "" Then
                    Select Case ds.Tables(0).Rows(i).Item("TIPOTELEFONE1")
                        Case 1
                            strHTML += "<cite style='width:340px;border-bottom:none;'><b>Telefone:</b>"
                        Case 2
                            strHTML += "<cite style='width:340px;border-bottom:none;'><b>Celular:</b>"
                        Case 3
                            strHTML += "<cite style='width:340px;border-bottom:none;'><b>Fax:</b>"
                        Case 4
                            strHTML += "<cite style='width:340px;border-bottom:none;'><b>PABX:</b>"
                        Case 5
                            strHTML += "<cite style='width:340px;border-bottom:none;'><b>Obra:</b>"
                    End Select
                    strHTML += "(" & ds.Tables(0).Rows(i).Item("DDD").Replace(" ", "") & ")" & ds.Tables(0).Rows(i).Item("TELEFONE").Replace(" ", "") & "</cite>"
                Else
                    strHTML += "&nbsp;"
                End If
                If ds.Tables(0).Rows(i).Item("DDDFAX").Trim() <> "" And ds.Tables(0).Rows(i).Item("FAX").Trim() <> "" Then
                    Select Case ds.Tables(0).Rows(i).Item("TIPOTELEFONE2")
                        Case 1
                            strHTML += "<cite style='border-bottom:none;'><b>Telefone:</b>"
                        Case 2
                            strHTML += "<cite style='border-bottom:none;'><b>Celular:</b>"
                        Case 3
                            strHTML += "<cite style='border-bottom:none;'><b>Fax:</b>"
                        Case 4
                            strHTML += "<cite style='border-bottom:none;'><b>PABX:</b>"
                        Case 5
                            strHTML += "<cite style='border-bottom:none;'><b>Obra:</b>"
                    End Select
                    strHTML += "(" & ds.Tables(0).Rows(i).Item("DDDFAX").Replace(" ", "") & ")" & ds.Tables(0).Rows(i).Item("FAX").Replace(" ", "") & "</cite>"
                Else
                    strHTML += "&nbsp;"
                End If
                If ds.Tables(0).Rows(i).Item("DDD2").Trim() <> "" And ds.Tables(0).Rows(i).Item("TELEFONE2").Trim() <> "" Then
                    Select Case ds.Tables(0).Rows(i).Item("TIPOTELEFONE3")
                        Case 1
                            strHTML += "<cite style='border-bottom:none;'><b>Telefone:</b>"
                        Case 2
                            strHTML += "<cite style='border-bottom:none;'><b>Celular:</b>"
                        Case 3
                            strHTML += "<cite style='border-bottom:none;'><b>Fax:</b>"
                        Case 4
                            strHTML += "<cite style='border-bottom:none;'><b>PABX:</b>"
                        Case 5
                            strHTML += "<cite style='border-bottom:none;'><b>Obra:</b>"
                    End Select
                    strHTML += "(" & ds.Tables(0).Rows(i).Item("DDD2").Replace(" ", "") & ")" & ds.Tables(0).Rows(i).Item("TELEFONE2").Replace(" ", "") & "</cite>"
                Else
                    strHTML += "&nbsp;"
                End If

                strHTML += "</div>"

                If i Mod 6 = 5 Then

                    strHTML += "    <div id='RodapeRelatorio'>"
                    strHTML += "    <p style='text-align: center'>www.itc.etc.br     -      E-mail: itc@itc.etc.br<br>"
                    strHTML += "    Rua Conselheiro Brotero, 589 - Sobreloja 2 - São Paulo - SP - CEP 01154-001 - Fone/Fax: (11)3825-7511</p>"
                    strHTML += "    </div>"

                    If blnQuebra Then strHTML += "    </p>"
                    blnQuebra = True

                End If

            Next

            If i Mod 6 <> 0 Then

                strHTML += "    <div id='RodapeRelatorio'>"
                strHTML += "    <p style='text-align: center'>www.itc.etc.br     -      E-mail: itc@itc.etc.br<br>"
                strHTML += "    Rua Conselheiro Brotero, 589 - Sobreloja 2 - São Paulo - SP - CEP 01154-001 - Fone/Fax: (11)3825-7511</p>"
                strHTML += "    </div>"

                If blnQuebra Then strHTML += "    </p>"

            End If

        End If

        strHTML += "</div>"

        CodigoHTML.Text = strHTML

    End Function

End Class

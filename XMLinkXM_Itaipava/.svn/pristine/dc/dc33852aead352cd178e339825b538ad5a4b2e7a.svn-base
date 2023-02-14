Imports Classes
Imports System.Data

Partial Class Relatorios_VolumeVendasEmbalagem
    Inherits XMWebPage
    Protected Soma As New Somarizador
    'Protected pilhaIdRegional As Stack = New Stack
    'Protected arrFiltro(3) As String


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            'Dim strIdEmpReg As String = Request("i")
            'If Not IsNumeric(strIdEmpReg) Then
            '    strIdEmpReg = User.IDRegional
            'End If

            'If Request("ss") <> "1" Then
            '    'Limpa a sessão caso a página seja chamada por outra página.
            '    Session.Remove("pilhaIdRegional")
            '    Session("pilhaIdRegional") = pilhaIdRegional

            '    Session.Remove("arrFiltro")
            '    Session("arrFiltro") = arrFiltro
            '    Session("arrFiltro")(0) = Filtro1.IDEmpresa
            '    Session("arrFiltro")(1) = Filtro1.DataInicial
            '    Session("arrFiltro")(2) = Filtro1.DataFinal
            '    Session("arrFiltro")(3) = Filtro1.Embalagem
            'Else

            '    Try

            '        Filtro1.IDEmpresa = CInt(Session("arrFiltro")(0))
            '        Filtro1.DataInicial = Session("arrFiltro")(1)
            '        Filtro1.DataFinal = Session("arrFiltro")(2)
            '        Filtro1.Embalagem = Session("arrFiltro")(3)
            '    Catch

            '        lblPeriodoData.Text = "Erro no processamento do relatório. Filtre o Relatório Novamente!"

            '    End Try

            'End If

            If Request("pr") = "2" Then
                Try

                    showData(User.IDEmpresa, User.IDRegional, Request("lin"), Request("di"), Request("df"))
                    Filtro1.Visible = False
                    lblPeriodoData.Text = "Período Selecionado: de " & Request("di") & " a " & Request("df")

                Catch

                    Filtro1.Visible = False
                    lblPeriodoData.Text = "O Tempo Limite para Impressão Expirou. Filtre o Relatório Novamente!"

                End Try
            Else

                Try

                    'Session("pilhaIdRegional").Push(strIdEmpReg)
                    showData(Me.User.IDEmpresa, User.IDRegional, Filtro1.Embalagem, Filtro1.DataInicial, Filtro1.DataFinal)

                Catch ex As Exception

                    lblPeriodoData.Text = "Erro no processamento do relatório. Filtre o Relatório Novamente! (" & ex.Message & ")"

                End Try
            End If

        End If
        

    End Sub

    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        Try

            'Session("arrFiltro")(0) = Filtro1.IDEmpresa
            'Session("arrFiltro")(1) = Filtro1.DataInicial
            'Session("arrFiltro")(2) = Filtro1.DataFinal
            'Session("arrFiltro")(3) = Filtro1.Embalagem

            showData(Filtro1.IDEmpresa, User.IDRegional, Filtro1.Embalagem, Filtro1.DataInicial, Filtro1.DataFinal)

        Catch ex As Exception

            lblPeriodoData.Text = "Erro no processamento do relatório. Filtre o Relatório Novamente! ( " & ex.Message & ")"

        End Try

    End Sub

    Public Sub showData(ByVal vIdEmpresa As Integer, ByVal vIdRegional As Integer, ByVal vIdEmbalagem As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String)

        lblPeriodoData.Text = ""

        Dim dt As DataSet
        Dim rep As New clsRelatorio
        dt = rep.GetRelatorioVendasPorEmbalagem(vIdEmpresa, vIdRegional, vIdEmbalagem, vDataInicial, vDataFinal)

        ViewState("Tipo") = dt.Tables(3).Rows(0).Item(0)

        XMCrossRepeater1.ColDataSource = dt.Tables(0).Rows
        XMCrossRepeater1.RowDataSource = dt.Tables(1).Rows
        XMCrossRepeater1.DataSource = dt.Tables(2).Rows
        XMCrossRepeater1.DataKeyNames = "IdRegional,IdLinha"
        XMCrossRepeater1.RowKeyNames = "IdRegional"
        XMCrossRepeater1.ColKeyNames = "IdLinha"

        XMCrossRepeater1.DataBind()

        rep = Nothing

        'Try
        '    divVoltar.Visible = Session("pilhaIdRegional").Count > 1 And Request("pr") <> "2"
        'Catch
        '    divVoltar.Visible = False
        'End Try

    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request("pr") = "2" Then
            Me.MasterPageFile = "imprimir.master"
        End If
    End Sub

    Protected Sub XMCrossRepeater1_ItemDataBound(sender As Object, e As XMSistemas.Web.UI.WebControls.XMCrossRepeaterItemEventArgs) Handles XMCrossRepeater1.ItemDataBound

        If e.Item.ItemType = XMSistemas.Web.UI.WebControls.XMCrossRepeater.CrossItemType.RowHeaderItem Then

            Dim lnk As Literal = e.Item.FindControl("ltrLink")
            If Not lnk Is Nothing Then

                If ViewState("Tipo") = "Regional" And Request("pr") <> "2" Then

                    lnk.Text = "<a href='volumevendasembalagem.aspx?i=" & e.Item.DataItem("IdRegional") & "&ss=1" & "'>" & e.Item.DataItem("Regional") & "</a>"
                Else

                    lnk.Text = e.Item.DataItem("Regional")
                End If
            End If

        End If

    End Sub

    'Volta 1 Nível no resultado do XMCrossRepeater1.
    Protected Sub lnkVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkVoltar.Click

        Try
            If Session("pilhaIdRegional").Count > 1 Then 'Verificação para não esvaziar totalmente a pilha.

                Session("pilhaIdRegional").Pop()
            End If

            showData(Filtro1.IDEmpresa, User.IDRegional, Filtro1.Embalagem, Filtro1.DataInicial, Filtro1.DataFinal)
        Catch

            Response.Redirect("volumevendasembalagem.aspx?i=0")
        End Try

    End Sub
End Class

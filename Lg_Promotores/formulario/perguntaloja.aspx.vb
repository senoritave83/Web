﻿Imports Classes
Imports System.Data

Partial Class formulario_perguntaloja
    Inherits XMWebPage

    Protected cls As clsFormVisita

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsFormVisita

        If Not Page.IsPostBack Then
            ViewState("IDVISITA") = Request("idvisita")
            IDCurrentPergunta = Request("idpergunta")
        End If

        cls.Load(ViewState("IDVISITA"))

        If Not Page.IsPostBack Then
            ExibirPergunta()
        End If

    End Sub

    Protected Property IDCurrentPergunta() As Integer
        Get
            Return CInt("0" & ViewState("IDCURRENTPERGUNTA"))
        End Get
        Set(ByVal value As Integer)
            ViewState("IDCURRENTPERGUNTA") = value
        End Set
    End Property


    Protected Sub ExibirPergunta()
        Dim dr As IDataReader
        dr = cls.ListarPerguntasLoja()
        Dim iTemp As Integer = 0
        Dim blnEncontrado As Boolean = False
        Dim strRespostaSimples As String = ""
        Do While dr.Read
            If dr.GetInt32(dr.GetOrdinal("IDPergunta")) = IDCurrentPergunta Then
                If Not dr.IsDBNull(dr.GetOrdinal("Resposta")) Then
                    strRespostaSimples = dr.GetString(dr.GetOrdinal("Resposta"))
                End If
                blnEncontrado = True
                Exit Do
            End If
        Loop
        dr.Close()
        dr.Dispose()

        If Not blnEncontrado Then
            Response.Redirect("visita.aspx?idvisita=" & ViewState("IDVISITA"))
        Else
            pergunta1.Mostrar(IDCurrentPergunta, cls.ListarRespostasLoja(IDCurrentPergunta), strRespostaSimples)
        End If

    End Sub

    Protected Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click

        Dim colRespostas As Generic.List(Of String)
        colRespostas = pergunta1.GetRespostas()

        If colRespostas.Count > 0 Then
            cls.AdicionarRespostasLoja(IDCurrentPergunta, colRespostas.ToArray())
            Response.Redirect("visita.aspx?idvisita=" & ViewState("IDVISITA"))
        Else
            pergunta1.VerificaExibicao(IDCurrentPergunta)
        End If
    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("visita.aspx?idvisita=" & ViewState("IDVISITA"))
    End Sub
End Class

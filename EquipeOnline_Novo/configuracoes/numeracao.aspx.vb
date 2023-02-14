Imports System.Data.SqlClient

Partial Class configuracoes_numeracao
    Inherits XMProtectedPage
    Protected cls As clsConfig

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsConfig()
        If Not IsPostBack Then
            Inflate()
        End If

    End Sub

    Protected Sub Inflate()
        With cls
            txtPrefixo.Text = .Prefixo
            txtFormato.Text = .Formato
            txtNumeroInicial.Text = .NumeroInicial
            txtIncremento.Text = .Incremento
            txtTempoLimite.Text = ConverterMinutos(.TempoLimite)
        End With
        btnSalvar.Enabled = True
    End Sub

    Protected Sub Deflate()
        With cls
            .Prefixo = txtPrefixo.Text
            .Formato = txtFormato.Text
            .NumeroInicial = txtNumeroInicial.Text
            .Incremento = txtIncremento.Text
            .TempoLimite = ConverterHoras(txtTempoLimite.Text)
        End With
    End Sub

    ''' <summary>
    ''' Método que transforma minutos em horas
    ''' </summary>
    ''' <param name="TempoLimite">Tempo em minutos</param>
    ''' <returns>Horas com formatação hh:mm</returns>
    Public Function ConverterMinutos(ByVal TempoLimite As Integer) As String
        Try
            Dim minutos As Integer
            Dim Tempo() As String = CStr(TempoLimite / 60).Split(",")
            If Tempo.Length > 1 Then
                Tempo(1) = CDec("0," & Tempo(1))
                minutos = CInt(Tempo(1) * 60)
            Else
                minutos = 0
            End If
            Return Right("0" & Tempo(0), 2) & ":" & Right("0" & minutos, 2)
        Catch
            Return "00:00"
        End Try
    End Function

    ''' <summary>
    ''' Método que transforma horas em minutos
    ''' </summary>
    ''' <param name="TempoLimite">Tempo em horas</param>
    ''' <returns>Minutos no formato inteiro</returns>
    Public Function ConverterHoras(ByVal TempoLimite As String) As Integer
        Try
            Dim minutos As Integer
            Dim horas() As String = TempoLimite.Split(":")
            If horas.Length > 1 Then
                minutos = horas(0) * 60
                minutos += horas(1)
            Else
                minutos = horas(0) * 60
            End If
            Return minutos
        Catch
            Return 0
        End Try
    End Function

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSalvar.Click
        Deflate()
        Try
            cls.Update()
            MostraGravado("default2.aspx")
        Catch ex As SqlException
            If ex.Number = 50000 Then
                ShowError(ex.Message)
                Exit Sub
            Else
                Throw ex
            End If
        End Try
    End Sub

    Private Sub btnVoltar_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("default2.aspx")
    End Sub

End Class

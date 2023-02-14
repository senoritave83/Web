Imports Classes
Imports System.Data

Partial Class Relatorios_historico_roteiro
    Inherits XMWebPage
    Protected Soma As New Somarizador
    Const VW_MEDIAINICIO As String = "MEDIAINICIO"
    Const VW_MEDIAFIM As String = "MEDIAFIM"
    Const VW_QUANTREG As String = "QUANTREG"
    Dim strMediaInicio As String = ""
    Dim strMediaTermino As String = ""
    Dim strDuracaoRoteiro As String = ""

    Public Property MediaInicio() As String
        Get
            Return strMediaInicio
        End Get
        Set(value As String)
            strMediaInicio = value
        End Set
    End Property

    Public Property MediaTermino() As String
        Get
            Return strMediaTermino
        End Get
        Set(value As String)
            strMediaTermino = value
        End Set
    End Property

    Public Property MediaDuracaoRoteiro() As String
        Get
            Return strDuracaoRoteiro
        End Get
        Set(value As String)
            strDuracaoRoteiro = value
        End Set
    End Property

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Request("pr") = "2" Then

            showData(CInt(Request("em")), CInt(Request("ger")), CInt(Request("sup")), CInt(Request("vend")), Request("di"), Request("df"))
            Filtro1.Visible = False
            lblPeriodoData.Text = "Período Selecionado: de " & Request("di") & " a " & Request("df")

        End If

    End Sub


    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        showData(Filtro1.IDEmpresa, Filtro1.IDGerente, Filtro1.IDSupervisor, Filtro1.IDVendedor, Filtro1.DataInicial, Filtro1.DataFinal)

    End Sub

    Private Sub showData(ByVal vIdEmpresa As Integer, ByVal vIdGerente As Integer, ByVal vIdSupervisor As Integer, ByVal vIDVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String)

        ViewState(VW_QUANTREG) = 0
        ViewState(VW_MEDIAINICIO) = 0
        ViewState(VW_MEDIAFIM) = 0

        Dim rep As New clsRelatorio
        Dim ds As DataSet
        ds = rep.GetRelatorioHistoricoRoteiro(vIdEmpresa, vIdGerente, vIdSupervisor, vIDVendedor, vDataInicial, vDataFinal)

        MediaInicio = ds.Tables(1).Rows(0).Item("MEDIAINICIOGERAL").ToString
        MediaTermino = ds.Tables(1).Rows(0).Item("MEDIATERMINOGERAL").ToString
        MediaDuracaoRoteiro = ds.Tables(1).Rows(0).Item("DURACAOROTEIROGERAL").ToString

        grdRelatorio.DataSource = ds.Tables(0)
        grdRelatorio.DataBind()
        rep = Nothing

    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request("pr") = "2" Then
            Me.MasterPageFile = "imprimir.master"
        End If
    End Sub

End Class

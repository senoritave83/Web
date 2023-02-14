
Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog

Public Class clsPesquisas

    Inherits DataClass

    Public Enum TipoPesquisa
        PesquisaObra = 1
        PesquisaEmpresa = 2
    End Enum

    Sub New()

    End Sub

    Public Function setReportGuid(ByVal p_IdAssociado As Integer, ByVal p_Link As String) As Object

        Return ExecuteScalar("SP_SV_RELATORIOGUID " & p_IdAssociado & ",'" & p_Link & "'")

    End Function

    Public Function getReportGuid_Data(ByVal p_Guid As String) As String

        Return ExecuteScalar("SP_SE_RELATORIOGUID '" & p_Guid & "'")

    End Function

    Public Function DadosPesquisa(ByVal IdPesquisa As Integer, ByVal IdUsuario As Integer, ByVal Tipo As TipoPesquisa) As DataSet
        Try
            If Tipo = TipoPesquisa.PesquisaEmpresa Then
                Return GetDataSet("SP_SE_USUARIOPESQUISAEMPRESA " & IdPesquisa & "," & IdUsuario)
            Else
                Return GetDataSet("SP_SE_USUARIOPESQUISA " & IdPesquisa & "," & IdUsuario)
            End If
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ExcluirPesquisaObras(ByVal IdPesquisa As Integer, ByVal IdUsuario As Integer) As Boolean
        Try
            ExecuteNonQuery("SP_DE_PESQUISAOBRAS " & IdPesquisa & "," & IdUsuario)
            Return True
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
            Return False
        End Try
    End Function

    Public Function ExcluirPesquisaEmpresa(ByVal IdPesquisa As Integer, ByVal IdUsuario As Integer) As Boolean
        Try
            ExecuteNonQuery("SP_DE_PESQUISAEMPRESAS " & IdPesquisa & "," & IdUsuario)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListSegmentos(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            ListSegmentos = GetDataSet("SP_SE_PESQUISASEGMENTOS " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try

    End Function

    Public Function ListTipos(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer, Optional ByVal p_IdSegmento As Integer = 0) As DataSet
        Try

            ListTipos = GetDataSet("SP_SE_PESQUISATIPOS " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa & "," & p_IdSegmento)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try

    End Function

    Public Function ListTiposDemo() As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISATIPOS_DEMO ")

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try

    End Function

    Public Function ListRegioes(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAREGIOES " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try

    End Function

    Public Function ListRegioesDemo() As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAREGIOES_DEMO ")

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try

    End Function

    Public Function ListStatus() As DataSet
        Try

            Return GetDataSet("SP_SE_STATUS")

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try

    End Function


    Public Function ListFormaPagto() As DataSet
        Try

            Return GetDataSet("SP_SE_FORMAPAGAMENTO")

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try

    End Function

    Public Function ListEstados(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAESTADOS " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListEstadosObrasNO(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAESTADOSNO " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListEstadosObrasNR(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAESTADOSNR " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListEstadosObrasSL(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAESTADOSSL " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListEstadosObrasSD(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAESTADOSSD " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListEstadosObrasCO(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAESTADOSCO " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListEstadosDemo() As DataSet
        Try
            Return GetDataSet("SP_SE_PESQUISAESTADOS_DEMO ")
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    Public Function ListEstadosEmpresas(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAESTADOSEMPRESA " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListEstadosEmpresasNo(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAESTADOSEMPRESANO " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListEstadosEmpresasNr(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAESTADOSEMPRESANR " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListEstadosEmpresasSl(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAESTADOSEMPRESASL " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListEstadosEmpresasSd(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAESTADOSEMPRESASD " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListEstadosEmpresasCo(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAESTADOSEMPRESACO " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListRamos() As DataSet
        Try

            Return GetDataSet("SP_SE_RAMO")

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListPosicao() As DataSet
        Try

            Return GetDataSet("SP_SE_POSICAO")

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListProdutos() As DataSet
        Try

            Return GetDataSet("SP_SE_PRODUTOS")

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListAtividades() As DataSet
        Try

            ListAtividades = GetDataSet("SP_SE_ATIVIDADES_RAMO")

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListAtividades(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAATIVIDADES " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListFases(ByVal IdUsuario As Integer, ByVal IdPesquisa As Integer, ByVal IdEmpresa As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAFASES " & IdUsuario & "," & IdPesquisa & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListFasesDemo() As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAFASES_DEMO")

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function ListEmpresas(ByVal IdUsuario As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISASEMPRESA " & IdUsuario)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function List(ByVal IdUsuario As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_PESQUISAS " & IdUsuario)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function SalvarPesquisa(ByVal IdPesquisa As Integer, _
                                ByVal IdUsuario As Integer, _
                                ByVal Tipos As String, _
                                ByVal Regioes As String, _
                                ByVal Estados As String, _
                                ByVal Fases As String, _
                                ByVal Estagios As String, _
                                ByVal NomePesquisa As String, _
                                ByVal CODIGOITC As String, _
                                ByVal ENDERECO As String, _
                                ByVal BAIRRO As String, _
                                ByVal IDCIDADE As Integer, _
                                ByVal DESCRICAO As String, _
                                ByVal CEPINICIAL As String, _
                                ByVal CEPFINAL As String, _
                                ByVal NRDAREVISAO As String, _
                                ByVal INICIOOBRA As String, _
                                ByVal TERMINOOBRA As String, _
                                ByVal IDPESQUISADOR As Integer, ByVal AREACONSTRUIDA As String, _
                                ByVal CHECAGEMAREA As Integer, ByVal VALOR As String, _
                                ByVal CHECAGEMVALOR As Integer, ByVal EMPRESAPARTIC As String, _
                                ByVal IDMODALIDADE As Integer, ByVal NOMEOBRA As String, _
                                ByVal ChecagemNrRevisao As Integer, ByVal IDESTADO As String) As Integer
        Try

            If CODIGOITC = "" Then
                CODIGOITC = "NULL"
            Else
                CODIGOITC = "'" & CODIGOITC & "'"
            End If

            If ENDERECO = "" Then
                ENDERECO = "NULL"
            Else
                ENDERECO = "'" & ENDERECO & "'"
            End If

            If BAIRRO = "" Then
                BAIRRO = "NULL"
            Else
                BAIRRO = "'" & BAIRRO & "'"
            End If

            'If CIDADE = "" Then
            '    CIDADE = "NULL"
            'Else
            '    CIDADE = "'" & CIDADE & "'"
            'End If

            If DESCRICAO = "" Then
                DESCRICAO = "NULL"
            Else
                DESCRICAO = "'" & DESCRICAO & "'"
            End If

            If CEPINICIAL = "" Then
                CEPINICIAL = "NULL"
            Else
                CEPINICIAL = "'" & CEPINICIAL & "'"
            End If

            If CEPFINAL = "" Then
                CEPFINAL = "NULL"
            Else
                CEPFINAL = "'" & CEPFINAL & "'"
            End If

            If NRDAREVISAO = "" Then
                NRDAREVISAO = "NULL"
            Else
                NRDAREVISAO = "'" & NRDAREVISAO & "'"
            End If

            If INICIOOBRA = "" Then
                INICIOOBRA = "NULL"
            Else
                INICIOOBRA = "'" & INICIOOBRA & "'"
            End If

            If TERMINOOBRA = "" Then
                TERMINOOBRA = "NULL"
            Else
                TERMINOOBRA = "'" & TERMINOOBRA & "'"
            End If

            If Not IsNumeric(AREACONSTRUIDA) Then
                AREACONSTRUIDA = 0
            End If

            If Not IsNumeric(VALOR) Then
                VALOR = 0
            End If

            If EMPRESAPARTIC = "" Then
                EMPRESAPARTIC = "NULL"
            Else
                EMPRESAPARTIC = "'" & EMPRESAPARTIC & "'"
            End If

            If NOMEOBRA = "" Then
                NOMEOBRA = "NULL"
            Else
                NOMEOBRA = "'" & NOMEOBRA & "'"
            End If

            Dim sql As String = "SP_SV_USUARIOPESQUISA " & IdPesquisa & "," & IdUsuario & ",'" & Regioes & "','" & Estados & "','" & Tipos & "','" & Fases & "','" & Estagios & "','" & NomePesquisa & "'," & CODIGOITC & "," & ENDERECO & "," & BAIRRO & "," & IDCIDADE & "," & DESCRICAO & "," & CEPINICIAL & "," & CEPFINAL & "," & NRDAREVISAO & "," & INICIOOBRA & "," & TERMINOOBRA & "," & IDPESQUISADOR & "," & AREACONSTRUIDA & "," & CHECAGEMAREA & "," & VALOR & "," & CHECAGEMVALOR & "," & EMPRESAPARTIC & "," & IDMODALIDADE & "," & NOMEOBRA & "," & ChecagemNrRevisao & ",'" & IDESTADO & "'"
            Dim ds As DataSet = GetDataSet(sql)
            Return ds.Tables(0).Rows(0).Item(0)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
            Return 0

        End Try
    End Function

    Public Function SalvarPesquisaEmpresa(ByVal IdPesquisa As Integer, ByVal IdUsuario As Integer, ByVal Estados As String, ByVal Atividades As String, ByVal NomePesquisa As String, ByVal RazaoSocial As String, ByVal Fantasia As String, ByVal Endereco As String, ByVal Cidade As String, ByVal CNPJ As String, ByVal CEPINICIAL As String, ByVal CEPFINAL As String, ByVal WebSite As String, ByVal EMail As String, ByVal Bairro As String, ByVal IdEstado As Integer) As Integer
        Try

            If RazaoSocial = "" Then
                RazaoSocial = "NULL"
            Else
                RazaoSocial = "'" & RazaoSocial & "'"
            End If
            If Fantasia = "" Then
                Fantasia = "NULL"
            Else
                Fantasia = "'" & Fantasia & "'"
            End If
            If Endereco = "" Then
                Endereco = "NULL"
            Else
                Endereco = "'" & Endereco & "'"
            End If
            If Cidade = "" Then
                Cidade = "NULL"
            Else
                Cidade = "'" & Cidade & "'"
            End If
            If Bairro = "" Then
                Bairro = "NULL"
            Else
                Bairro = "'" & Bairro & "'"
            End If
            If CNPJ = "" Then
                CNPJ = "NULL"
            Else
                CNPJ = "'" & CNPJ & "'"
            End If
            If CEPINICIAL = "" Then
                CEPINICIAL = "NULL"
            Else
                CEPINICIAL = "'" & CEPINICIAL & "'"
            End If
            If CEPFINAL = "" Then
                CEPFINAL = "NULL"
            Else
                CEPFINAL = "'" & CEPFINAL & "'"
            End If
            If WebSite = "" Then
                WebSite = "NULL"
            Else
                WebSite = "'" & WebSite & "'"
            End If
            If EMail = "" Then
                EMail = "NULL"
            Else
                EMail = "'" & EMail & "'"
            End If

            Dim sql As String = "SP_SV_USUARIOPESQUISA_EMPRESA " & IdPesquisa & "," & IdUsuario & ",'" & Estados & "','" & Atividades & "','" & NomePesquisa & "'," & RazaoSocial & "," & Fantasia & "," & Endereco & "," & Cidade & "," & CNPJ & "," & CEPINICIAL & "," & CEPFINAL & "," & WebSite & "," & EMail & "," & Bairro & "," & IdEstado
            Dim ds As DataSet = GetDataSet(sql)
            Return ds.Tables(0).Rows(0).Item(0)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
            Return 0

        End Try
    End Function


    Public Function Pesquisar(ByVal Tipos As String, ByVal Regioes As String, ByVal Estados As String, ByVal Fases As String, ByVal DataInicial As String, ByVal DataFinal As String, ByVal IdUsuario As Integer, ByVal NomeObra As String, ByVal Ordem As Integer, ByVal IdEmpresa As Integer, ByVal CODIGOITC As String, ByVal ENDERECO As String, ByVal BAIRRO As String, ByVal CIDADE As String, ByVal DESCRICAO As String, ByVal CEPINICIAL As String, ByVal CEPFINAL As String, ByVal NRDAREVISAO As String, ByVal INICIOOBRA As String, ByVal TERMINOOBRA As String, ByVal IDPESQUISADOR As Integer, ByVal AREACONSTRUIDA As String, ByVal CHECAGEMAREA As Integer, ByVal VALOR As String, ByVal CHECAGEMVALOR As Integer, ByVal EMPRESAPARTIC As String, ByVal IDMODALIDADE As Integer, ByVal Estagios As String, ByVal Uf As String, ByVal ChecagemNrRevisao As Integer, ByVal b_GSP As Integer, ByVal p_QuantRegistros As Integer, ByVal StatusSIG As Integer, Optional ByVal p_Demo As Boolean = False) As DataSet
        Try

            If Tipos.Trim = "" Then
                Tipos = "NULL"
            Else
                Tipos = "'" & Tipos & "'"
            End If

            If Regioes.Trim = "" Then
                Regioes = "NULL"
            Else
                Regioes = "'" & Regioes & "'"
            End If

            If Estados.Trim = "" Then
                Estados = "NULL"
            Else
                Estados = "'" & Estados & "'"
            End If

            If Fases.Trim = "" Then
                Fases = "NULL"
            Else
                Fases = "'" & Fases & "'"
            End If

            If IsDate(DataInicial) Then
                DataInicial = "'" & CDate(DataInicial).ToString("yyyy-MM-dd") & "'"
            Else
                DataInicial = "NULL"
            End If

            If IsDate(DataFinal) Then
                DataFinal = "'" & CDate(DataFinal).ToString("yyyy-MM-dd") & "'"
            Else
                DataFinal = "NULL"
            End If

            If NomeObra.Trim = "" Then
                NomeObra = "NULL"
            Else
                NomeObra = "'" & NomeObra & "'"
            End If

            If Ordem < 0 Then Ordem = 1

            If CODIGOITC = "" Then
                CODIGOITC = "NULL"
            Else
                CODIGOITC = "'" & CODIGOITC & "'"
            End If

            If ENDERECO = "" Then
                ENDERECO = "NULL"
            Else
                ENDERECO = "'" & ENDERECO & "'"
            End If

            If BAIRRO = "" Then
                BAIRRO = "NULL"
            Else
                BAIRRO = "'" & BAIRRO & "'"
            End If

            If CIDADE = "0" Then
                CIDADE = "NULL"
            Else
                CIDADE = "'" & CIDADE & "'"
            End If

            If DESCRICAO = "" Then
                DESCRICAO = "NULL"
            Else
                DESCRICAO = "'" & DESCRICAO & "'"
            End If

            If CEPINICIAL = "" Then
                CEPINICIAL = "NULL"
            Else
                CEPINICIAL = "'" & CEPINICIAL & "'"
            End If

            If CEPFINAL = "" Then
                CEPFINAL = "NULL"
            Else
                CEPFINAL = "'" & CEPFINAL & "'"
            End If

            If Not IsNumeric(NRDAREVISAO) Then
                NRDAREVISAO = "NULL"
            End If

            If Not IsDate(INICIOOBRA) Then
                INICIOOBRA = "NULL"
            Else
                INICIOOBRA = "'" & CDate(INICIOOBRA).ToString("yyyy-MM-dd") & "'"
            End If

            If Not IsDate(TERMINOOBRA) Then
                TERMINOOBRA = "NULL"
            Else
                TERMINOOBRA = "'" & CDate(TERMINOOBRA).ToString("yyyy-MM-dd") & "'"
            End If

            If Not IsNumeric(AREACONSTRUIDA) Then
                AREACONSTRUIDA = "NULL"
            End If

            If Not IsNumeric(VALOR) Then
                VALOR = "NULL"
            End If

            If EMPRESAPARTIC = "" Then
                EMPRESAPARTIC = "NULL"
            Else
                EMPRESAPARTIC = "'" & EMPRESAPARTIC & "'"
            End If

            If Estagios.Trim = "" Then
                Estagios = "NULL"
            Else
                Estagios = "'" & Estagios & "'"
            End If

            If Uf = "Selecione..." Then
                Uf = "NULL"
            Else
                Uf = "'" & Uf & "'"
            End If

            '================================================================================================================================================
            '********LOOP QUE VERIFICA A VARIÁVEL Estagios E SETA A VARIÁVEL Fases DE ACORDO COM OS ESTÁGIOS CORRESPONDENTES*********
            Dim splitEstagios As String = Replace(Estagios, "'", "")
            Dim estagiosArr() As String = splitEstagios.Split(",")
            For Each splitEstagios In estagiosArr
                If Fases <> "'1'" And Fases <> "'1,2'" And Fases <> "'1,2,3'" And Fases <> "'1,3'" Then
                    If splitEstagios = "1" Or splitEstagios = "2" Or splitEstagios = "3" Or splitEstagios = "4" Or splitEstagios = "5" Or splitEstagios = "15" Or splitEstagios = "16" Or splitEstagios = "18" Then
                        Fases = Replace(Fases, "NULL", "") + "',1'"
                    End If
                End If

                If Fases <> "'2'" And Fases <> "'1,2'" And Fases <> "'2,3'" And Fases <> "'1,2,3'" Then
                    If splitEstagios = "6" Or splitEstagios = "7" Or splitEstagios = "8" Or splitEstagios = "9" Or splitEstagios = "10" Or splitEstagios = "11" Or splitEstagios = "17" Or splitEstagios = "19" Or splitEstagios = "20" Then
                        Fases = Replace(Fases, "NULL", "") + "',2'"
                    End If
                End If

                If Fases <> "'3'" And Fases <> "'1,3'" And Fases <> "'2,3'" And Fases <> "'1,2,3'" Then
                    If splitEstagios = "12" Or splitEstagios = "13" Or splitEstagios = "14" Then
                        Fases = Replace(Fases, "NULL", "") + "',3'"
                    End If
                End If

                If Fases <> "NULL" Then
                    Fases = Replace(Fases, "'", "")
                    Fases = "'" + Fases + "'"
                End If
            Next
            '================================================================================================================================================

            Dim sql As String = "SP_SE_LISTAPESQUISA " & Fases & "," & Tipos & "," & Estados & "," & Regioes & "," & DataInicial & "," & DataFinal & "," & p_QuantRegistros & ", " & IdUsuario & "," & NomeObra & ", " & Ordem & "," & IdEmpresa & "," & CODIGOITC & "," & ENDERECO & "," & BAIRRO & "," & CIDADE & "," & DESCRICAO & "," & CEPINICIAL & "," & CEPFINAL & "," & NRDAREVISAO & "," & INICIOOBRA & "," & TERMINOOBRA & "," & IDPESQUISADOR & "," & AREACONSTRUIDA & "," & CHECAGEMAREA & "," & VALOR & "," & CHECAGEMVALOR & "," & EMPRESAPARTIC & "," & IDMODALIDADE & "," & Estagios & "," & Uf & "," & ChecagemNrRevisao & "," & b_GSP & "," & StatusSIG & "," & IIf(p_Demo, 1, 0)
            Return GetDataSet(sql)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
            Throw e

        End Try
    End Function

    Public Function PesquisarDemo(ByVal Tipos As String, ByVal Regioes As String, ByVal Estados As String, ByVal Fases As String, ByVal DataInicial As String, ByVal DataFinal As String, ByVal NomeObra As String, ByVal CODIGOITC As String, ByVal ENDERECO As String, ByVal BAIRRO As String, ByVal CIDADE As String, ByVal DESCRICAO As String, ByVal CEPINICIAL As String, ByVal CEPFINAL As String, ByVal NRDAREVISAO As String, ByVal INICIOOBRA As String, ByVal TERMINOOBRA As String, ByVal IDPESQUISADOR As Integer, ByVal AREACONSTRUIDA As String, ByVal CHECAGEMAREA As Integer, ByVal VALOR As String, ByVal CHECAGEMVALOR As Integer, ByVal EMPRESAPARTIC As String, ByVal IDMODALIDADE As Integer, ByVal Estagios As String, ByVal ChecagemNrRevisao As Integer) As DataSet
        Try

            If Tipos.Trim = "" Then
                Tipos = "NULL"
            Else
                Tipos = "'" & Tipos & "'"
            End If

            If Regioes.Trim = "" Then
                Regioes = "NULL"
            Else
                Regioes = "'" & Regioes & "'"
            End If

            If Estados.Trim = "" Then
                Estados = "NULL"
            Else
                Estados = "'" & Estados & "'"
            End If

            If Fases.Trim = "" Then
                Fases = "NULL"
            Else
                Fases = "'" & Fases & "'"
            End If

            If IsDate(DataInicial) Then
                DataInicial = "'" & CDate(DataInicial).ToString("yyyy-MM-dd") & "'"
            Else
                DataInicial = "NULL"
            End If

            If IsDate(DataFinal) Then
                DataFinal = "'" & CDate(DataFinal).ToString("yyyy-MM-dd") & "'"
            Else
                DataFinal = "NULL"
            End If

            If NomeObra.Trim = "" Then
                NomeObra = "NULL"
            Else
                NomeObra = "'" & NomeObra & "'"
            End If

            If CODIGOITC = "" Then
                CODIGOITC = "NULL"
            Else
                CODIGOITC = "'" & CODIGOITC & "'"
            End If

            If ENDERECO = "" Then
                ENDERECO = "NULL"
            Else
                ENDERECO = "'" & ENDERECO & "'"
            End If

            If BAIRRO = "" Then
                BAIRRO = "NULL"
            Else
                BAIRRO = "'" & BAIRRO & "'"
            End If

            If CIDADE = "" Then
                CIDADE = "NULL"
            Else
                CIDADE = "'" & CIDADE & "'"
            End If

            If DESCRICAO = "" Then
                DESCRICAO = "NULL"
            Else
                DESCRICAO = "'" & DESCRICAO & "'"
            End If

            If CEPINICIAL = "" Then
                CEPINICIAL = "NULL"
            Else
                CEPINICIAL = "'" & CEPINICIAL & "'"
            End If

            If CEPFINAL = "" Then
                CEPFINAL = "NULL"
            Else
                CEPFINAL = "'" & CEPFINAL & "'"
            End If

            If Not IsNumeric(NRDAREVISAO) Then
                NRDAREVISAO = "NULL"
            End If

            If Not IsDate(INICIOOBRA) Then
                INICIOOBRA = "NULL"
            Else
                INICIOOBRA = "'" & CDate(INICIOOBRA).ToString("yyyy-MM-dd") & "'"
            End If

            If Not IsDate(TERMINOOBRA) Then
                TERMINOOBRA = "NULL"
            Else
                TERMINOOBRA = "'" & CDate(TERMINOOBRA).ToString("yyyy-MM-dd") & "'"
            End If

            If Not IsNumeric(AREACONSTRUIDA) Then
                AREACONSTRUIDA = "NULL"
            End If

            If Not IsNumeric(VALOR) Then
                VALOR = "NULL"
            End If

            If EMPRESAPARTIC = "" Then
                EMPRESAPARTIC = "NULL"
            Else
                EMPRESAPARTIC = "'" & EMPRESAPARTIC & "'"
            End If

            If Estagios.Trim = "" Then
                Estagios = "NULL"
            Else
                Estagios = "'" & Estagios & "'"
            End If

            Return GetDataSet("SP_SE_LISTAPESQUISA_DEMO " & Fases & "," & Tipos & "," & Estados & "," & Regioes & "," & DataInicial & "," & DataFinal & ",0, " & NomeObra & ", " & CODIGOITC & "," & ENDERECO & "," & BAIRRO & "," & CIDADE & "," & DESCRICAO & "," & CEPINICIAL & "," & CEPFINAL & "," & NRDAREVISAO & "," & INICIOOBRA & "," & TERMINOOBRA & "," & IDPESQUISADOR & "," & AREACONSTRUIDA & "," & CHECAGEMAREA & "," & VALOR & "," & CHECAGEMVALOR & "," & EMPRESAPARTIC & "," & IDMODALIDADE & "," & Estagios & "," & ChecagemNrRevisao)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function PesquisarEmpresas(ByVal Atividades As String, ByVal Estados As String, ByVal RazaoSocial As String, ByVal IdUsuario As Integer, ByVal DataInicial As String, ByVal DataFinal As String, ByVal Ordem As Integer, ByVal IdEmpresa As Integer, ByVal Fantasia As String, ByVal Endereco As String, ByVal Cidade As String, ByVal CNPJ As String, ByVal CEPINICIAL As String, ByVal CEPFINAL As String, ByVal WebSite As String, ByVal EMail As String, ByVal Bairro As String, ByVal StatusSIG As Integer) As DataSet
        Try

            If Atividades.Trim = "" Then
                Atividades = "NULL"
            Else
                Atividades = "'" & Atividades & "'"
            End If

            If Estados.Trim = "" Then
                Estados = "NULL"
            Else
                Estados = "'" & Estados & "'"
            End If

            If Fantasia.Trim = "" Then
                Fantasia = "NULL"
            Else
                Fantasia = "'" & Fantasia & "'"
            End If

            If Not IsDate(DataInicial.Trim) Then
                DataInicial = "NULL"
            Else
                DataInicial = "'" & Year(DataInicial) & "-" & Month(DataInicial) & "-" & Day(DataInicial) & "'"
            End If

            If Not IsDate(DataFinal.Trim) Then
                DataFinal = "NULL"
            Else
                DataFinal = "'" & Year(DataFinal) & "-" & Month(DataFinal) & "-" & Day(DataFinal) & "'"
            End If

            If Ordem < 1 Then Ordem = 1

            If RazaoSocial = "" Then
                RazaoSocial = "NULL"
            Else
                RazaoSocial = "'" & RazaoSocial & "'"
            End If
            If Endereco = "" Then
                Endereco = "NULL"
            Else
                Endereco = "'" & Endereco & "'"
            End If
            If Cidade = "" Then
                Cidade = "NULL"
            Else
                Cidade = "'" & Cidade & "'"
            End If
            If CNPJ = "" Then
                CNPJ = "NULL"
            Else
                CNPJ = "'" & CNPJ & "'"
            End If
            If CEPINICIAL = "" Then
                CEPINICIAL = "NULL"
            Else
                CEPINICIAL = "'" & CEPINICIAL & "'"
            End If
            If CEPFINAL = "" Then
                CEPFINAL = "NULL"
            Else
                CEPFINAL = "'" & CEPFINAL & "'"
            End If
            If WebSite = "" Then
                WebSite = "NULL"
            Else
                WebSite = "'" & WebSite & "'"
            End If
            If EMail = "" Then
                EMail = "NULL"
            Else
                EMail = "'" & EMail & "'"
            End If
            If Bairro = "" Then
                Bairro = "NULL"
            Else
                Bairro = "'" & Bairro & "'"
            End If

            Dim sql As String = "SP_SE_LISTAPESQUISAEMPRESA " & Atividades & "," & Estados & "," & RazaoSocial & ",0, " & IdUsuario & "," & DataInicial & "," & DataFinal & ", " & Ordem & ", " & IdEmpresa & ", " & Fantasia & ", " & Endereco & ", " & Cidade & ", " & CNPJ & ", " & CEPINICIAL & ", " & CEPFINAL & ", " & WebSite & ", " & EMail & "," & Bairro & "," & StatusSIG
            Return GetDataSet(sql)

        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try

    End Function

    Public Function PesquisarAssociados(ByVal Atividade As String, ByVal Ramo As String, ByVal Posicao As String, ByVal Produto As String, ByVal DataInicial As String, ByVal DataFinal As String, ByVal Fantasia As String, ByVal RazaoSocial As String, ByVal Ordem As Integer, ByVal Status As String, ByVal IdVendedor As Integer, ByVal DataCancInicial As String, ByVal DataCancFinal As String, ByVal IdEstado As Integer, Optional ByVal FormaPagto As String = "") As DataSet
        Try

            If Atividade.Trim = "" Then
                Atividade = "NULL"
            Else
                Atividade = "'" & Atividade & "'"
            End If

            If Ramo.Trim = "" Then
                Ramo = "NULL"
            Else
                Ramo = "'" & Ramo & "'"
            End If

            If Posicao.Trim = "" Then
                Posicao = "NULL"
            Else
                Posicao = "'" & Posicao & "'"
            End If

            If Produto.Trim = "" Then
                Produto = "NULL"
            Else
                Produto = "'" & Produto & "'"
            End If

            If Fantasia.Trim = "" Then
                Fantasia = "NULL"
            Else
                Fantasia = "'" & Fantasia & "'"
            End If

            If RazaoSocial.Trim = "" Then
                RazaoSocial = "NULL"
            Else
                RazaoSocial = "'" & RazaoSocial & "'"
            End If

            If Not IsDate(DataInicial.Trim) Then
                DataInicial = "NULL"
            Else
                DataInicial = "'" & Year(DataInicial) & "-" & Month(DataInicial) & "-" & Day(DataInicial) & "'"
            End If

            If Not IsDate(DataFinal.Trim) Then
                DataFinal = "NULL"
            Else
                DataFinal = "'" & Year(DataFinal) & "-" & Month(DataFinal) & "-" & Day(DataFinal) & "'"
            End If

            If Not IsDate(DataCancInicial.Trim) Then
                DataCancInicial = "NULL"
            Else
                DataCancInicial = "'" & Year(DataCancInicial) & "-" & Month(DataCancInicial) & "-" & Day(DataCancInicial) & "'"
            End If

            If Not IsDate(DataCancFinal.Trim) Then
                DataCancFinal = "NULL"
            Else
                DataCancFinal = "'" & Year(DataCancFinal) & "-" & Month(DataCancFinal) & "-" & Day(DataCancFinal) & "'"
            End If

            If Status.Trim = "" Then
                Status = "NULL"
            Else
                Status = "'" & Status & "'"
            End If

            If FormaPagto.Trim = "" Then
                FormaPagto = "NULL"
            Else
                FormaPagto = "'" & FormaPagto & "'"
            End If

            If Ordem < 1 Then Ordem = 1

            Dim sql As String = "SP_SE_LISTAPESQUISAASSOCIADO " & Atividade & "," & Ramo & "," & Posicao & "," & _
                                Produto & "," & Fantasia & "," & RazaoSocial & "," & DataInicial & "," & DataFinal & ", " & _
                                Status & ", " & Ordem & "," & IdVendedor & "," & DataCancInicial & "," & DataCancFinal & "," & IdEstado & "," & FormaPagto

            Return GetDataSet(sql)

        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try

    End Function

    Public Function RelatorioEmpresas(ByVal IdEmpresas As String, ByVal Ordenacao As Integer, Optional ByVal IdEmpresa As Integer = 0) As DataSet
        Try

            Return GetDataSet("SP_SE_RELATORIOEMPRESAS '" & IdEmpresas & "'," & Ordenacao & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function RelatorioObras(ByVal IdObras As String, ByVal Ordenacao As Integer, Optional ByVal IdEmpresa As Integer = 0) As DataSet
        Try

            Return GetDataSet("SP_SE_RELATORIOOBRAS '" & IdObras & "'," & Ordenacao & "," & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function RelatorioFollowUp(ByVal Nome As String, ByVal Vendedor As String, ByVal DataAge As String, ByVal DataIni As String, ByVal DataFin As String) As DataSet
        Try

            Return GetDataSet("SP_SE_RELATORIOFOLLOWUP '" & Nome & "','" & Vendedor & "'," & XMCheckDate(DataAge, True, True) & "," & XMCheckDate(DataIni, True, True) & "," & XMCheckDate(DataFin, True, True))

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function RelatorioAssociadosResumo(ByVal IdAssociados As String, ByVal p_Order As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_RELATORIOASSOCIADOS_RESUMO '" & IdAssociados & "'," & p_Order)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function RelatorioAssociados(ByVal IdAssociados As String, ByVal p_Order As Integer) As DataSet
        Try

            Return GetDataSet("SP_SE_RELATORIOASSOCIADOS '" & IdAssociados & "'," & p_Order)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function RelatorioEmpresaExportar(ByVal IdEmpresas As String) As DataSet
        Try

            Return GetDataSet("SP_SE_RELATORIOEMPRESAS_EXPORTAR_2 '" & IdEmpresas & "'")

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function RelatorioObraExportar(ByVal IdObras As String) As DataSet
        Try

            Return GetDataSet("SP_SE_RELATORIOOBRAS_EXPORTAR_2 '" & IdObras & "'")

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function RelatorioContatosObras(ByVal IdObra As String) As DataSet
        Try

            Return GetDataSet("SP_SE_CONTATOSOBRAS 0,  " & IdObra)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function RelatorioEmpresasObras(ByVal IdObra As String) As DataSet
        Try

            RelatorioEmpresasObras = GetDataSet("SP_SE_OBRAS_EMPRESAS " & IdObra)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function RelatorioContatosEmpresas(ByVal IdEmpresa As String) As DataSet
        Try

            Return GetDataSet("SP_SE_CONTATOSEMPRESAS 0,  " & IdEmpresa)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

    Public Function RelatorioContatosAssociados(ByVal IdAssociado As String) As DataSet
        Try

            Return GetDataSet("SP_SE_CONTATOSASSOCIADOS 0,  " & IdAssociado)

        Catch e As Exception

            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")

        End Try
    End Function

End Class



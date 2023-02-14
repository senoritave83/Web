
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

    Public Class clsRoteiroPeriodo
        Inherits BaseClass

        Public Enum SelectionState
            NotSelected = 0
            Selected = 1
            Fixed = 2
        End Enum

        Public Structure LojaRoteiroDia
            Dim IdLoja As Integer
            Dim Dia As String
            Dim HoraInicio As String
            Dim HoraFim As String
            Dim HoraAlmocoInicio As String
            Dim HoraAlmocoFim As String
            Dim Selection As SelectionState
            Dim DiaFolga As Boolean
            Dim Pesquisa As Boolean
        End Structure

        ''' <summary>
        ''' 	Função que retorna uma listagem completa de lojas do promotor
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarLojas(ByVal vIDPromotor As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PROMOTOR_LOJAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem dos dias de folga do promotor 
        ''' </summary>
        ''' <param name="vIDPromotor">Id do promotor(int)</param>		
        ''' <param name="vDataInicial">Data Inicial a ser verificada(string)</param>		
        ''' <param name="vDataFinal">Data Final a ser verificada(string)</param>		
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarDiasFolgaPromotor(ByVal vIDPromotor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PROMOTOR_DIASFOLGA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = vDataFinal
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem dos motivos das folgas do promotor 
        ''' </summary>
        ''' <param name="vIDPromotor">Id do promotor(int)</param>		
        ''' <param name="vData">Data a ser verificada(string)</param>	
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarDiasFolgaMotivoPromotor(ByVal vIDPromotor As Integer, ByVal vData As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PROMOTOR_DIASFOLGAMOTIVO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = vData
            Return MyBase.ExecuteScalar(cmd)

        End Function

        Public Sub AdicionaLoja(ByVal vIDPromotor As Integer, ByVal vIDLoja As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_PROMOTOR_LOJA"
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = vIDLoja
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Roteiros por Periodo", "AdicionarLoja - IDPROMOTOR=" & vIDPromotor & " IDLOJA=" & vIDLoja)

        End Sub

        Public Sub GravaRoteiro(ByVal vIDPromotor As Integer, ByVal vData As Date, ByVal vLojas As String, ByVal vFolga As Byte, ByVal vFolgaMotivo As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_ROTEIRO_PROMOTOR"
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = vData
            cmd.Parameters.Add("@LOJAS", SqlDbType.VarChar, 8000).Value = Replace(vLojas, " ", "")
            cmd.Parameters.Add("@FOLGA", SqlDbType.TinyInt).Value = vFolga
            cmd.Parameters.Add("@IDFOLGAMOTIVO", SqlDbType.Int).Value = vFolgaMotivo

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Roteiros por Periodo", "GravaRoteiro - IDPROMOTOR=" & vIDPromotor & " DATA=" & vData & " LOJAS=" & vLojas & " FOLGA=" & vFolga & " =" & vFolgaMotivo)

        End Sub

        'Public Sub GravaRoteiro(ByVal vIDPromotor As Integer, ByVal vDadosRoteiro As String)

        '    Dim cmd As New SqlCommand()
        '    cmd.CommandType = CommandType.StoredProcedure
        '    cmd.CommandText = PREFIXO & "SV_ROTEIRO_PROMOTOR_HORA"
        '    cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
        '    cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
        '    cmd.Parameters.Add("@DADOSROTEIRO", SqlDbType.VarChar, 8000).Value = vDadosRoteiro

        '    ExecuteNonQuery(cmd)

        'End Sub


        Public Sub RetiraLoja(ByVal vIDPromotor As Integer, ByVal vIDLoja As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PROMOTOR_LOJA"
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = vIDLoja
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Roteiros por Periodo", "RetiraLoja - IDPROMOTOR=" & vIDPromotor & " IDLOJA=" & vIDLoja)

        End Sub


        Public Function VerificaLoja(ByVal vIDPromotor As Integer, ByVal vIDLoja As Integer, ByVal vData As Date) As SelectionState

            VerificaLoja = 0
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_PROMOTOR_LOJA_DIA"
                Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                parameter.Direction = ParameterDirection.ReturnValue
                cmd.Parameters.Add(parameter)
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
                cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = vIDLoja
                cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = _setDateTimeDBValue(vData)

                ExecuteNonQuery(cmd)
                VerificaLoja = cmd.Parameters("@RETURN_VALUE").Value
            Catch
            End Try

        End Function

        Public Function VerificaLojaRoteiroDia(ByVal vIDPromotor As Integer, ByVal vIDLoja As Integer, ByVal vData As Date) As LojaRoteiroDia

            Dim retLojaRoteiroDia As LojaRoteiroDia = Nothing
            Dim dr As IDataReader = Nothing
            Try

                retLojaRoteiroDia = New LojaRoteiroDia
                Dim cmd As New SqlCommand()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_PROMOTOR_LOJA_ROTEIRODIA"
                Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                parameter.Direction = ParameterDirection.ReturnValue
                cmd.Parameters.Add(parameter)
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
                cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = vIDLoja
                cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = _setDateTimeDBValue(vData)

                dr = ExecuteReader(cmd)
                If dr.Read Then
                    retLojaRoteiroDia.IdLoja = vIDLoja
                    retLojaRoteiroDia.Dia = dr("Dia")
                    retLojaRoteiroDia.HoraInicio = dr("DataHoraInicio")
                    retLojaRoteiroDia.HoraFim = dr("DataHoraFim")
                    retLojaRoteiroDia.HoraAlmocoInicio = dr("DataHoraAlmocoInicio")
                    retLojaRoteiroDia.HoraAlmocoFim = dr("DataHoraAlmocoFim")
                    retLojaRoteiroDia.Selection = dr("SelectionState")
                    retLojaRoteiroDia.DiaFolga = dr("DiaFolga")
                    retLojaRoteiroDia.Pesquisa = dr("Pesquisa")
                End If
            Finally
                If Not dr Is Nothing Then
                    dr.Close()
                    dr.Dispose()
                    dr = Nothing
                End If
            End Try

            Return retLojaRoteiroDia

        End Function

        Public Function VerificaLojaRoteiroDia(ByVal vIDPromotor As Integer, ByVal vIDLojas As String, ByVal vDatas As String) As LojaRoteiroDia

            Dim retLojaRoteiroDia As LojaRoteiroDia = Nothing
            Dim dr As IDataReader = Nothing
            Try

                retLojaRoteiroDia = New LojaRoteiroDia
                Dim cmd As New SqlCommand()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_PROMOTOR_LOJAS_ROTEIRO_DIAS"
                Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                parameter.Direction = ParameterDirection.ReturnValue
                cmd.Parameters.Add(parameter)
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
                cmd.Parameters.Add("@IDLOJAS", SqlDbType.VarChar, 8000).Value = vIDLojas
                cmd.Parameters.Add("@DATAS", SqlDbType.VarChar, 22).Value = _setDateTimeDBValue(vDatas)

                dr = ExecuteReader(cmd)
                If dr.Read Then
                    retLojaRoteiroDia.IdLoja = dr("IdLoja")
                    retLojaRoteiroDia.Dia = dr("Dia")
                    retLojaRoteiroDia.HoraInicio = dr("DataHoraInicio")
                    retLojaRoteiroDia.HoraFim = dr("DataHoraFim")
                    retLojaRoteiroDia.HoraAlmocoInicio = dr("DataHoraAlmocoInicio")
                    retLojaRoteiroDia.HoraAlmocoFim = dr("DataHoraAlmocoFim")
                    retLojaRoteiroDia.Selection = dr("SelectionState")
                    retLojaRoteiroDia.DiaFolga = dr("DiaFolga")
                    retLojaRoteiroDia.Pesquisa = dr("Pesquisa")
                End If
            Finally
                If Not dr Is Nothing Then
                    dr.Close()
                    dr.Dispose()
                    dr = Nothing
                End If
            End Try

            Return retLojaRoteiroDia

        End Function

    End Class

End Namespace

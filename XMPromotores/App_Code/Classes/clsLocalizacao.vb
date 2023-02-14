Imports System.Data
Imports System.Data.SqlClient


Namespace Classes

    Public Class clsLocalizacao
        Inherits BaseClass

        ''' <summary>
        ''' 	Função que retorna uma listagem completa de segmentos (lojas) da pesquisa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vEntidade As enTipoEntidade, ByVal vIDReferencia As Integer, Optional ByVal p_TipoFiltro As String = "", Optional ByVal p_Filtro As String = "", Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_LOCALIZACOES"
            cmd.Parameters.Add("@TIPOENTIDADE", SqlDbType.TinyInt).Value = vEntidade
            cmd.Parameters.Add("@IDREFERENCIA", SqlDbType.Int).Value = vIDReferencia
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@TIPOBUSCA", SqlDbType.VarChar, 20).Value = p_TipoFiltro
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 200).Value = p_Filtro
            Return MyBase.ExecuteCommand(cmd, vReturnType)


        End Function


        Public Sub Retirar(ByVal vEntidade As enTipoEntidade, ByVal vIDReferencia As Integer, ByVal vIDLocalizacao As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_LOCALIZACAO"
            cmd.Parameters.Add("@TIPOENTIDADE", SqlDbType.TinyInt).Value = vEntidade
            cmd.Parameters.Add("@IDREFERENCIA", SqlDbType.Int).Value = vIDReferencia
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDLOCALIZACAO", SqlDbType.Int).Value = vIDLocalizacao

            ExecuteNonQuery(cmd)

        End Sub


        Public Sub Adicionar(ByVal vEntidade As enTipoEntidade, ByVal vIDReferencia As Integer, ByVal vUF As String, ByVal vCidade As String, ByVal vIDCliente As Integer, ByVal vIDLoja As Integer, ByVal vIDRegiao As Integer, ByVal vIDTipoLoja As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_LOCALIZACAO"
            cmd.Parameters.Add("@TIPOENTIDADE", SqlDbType.TinyInt).Value = vEntidade
            cmd.Parameters.Add("@IDREFERENCIA", SqlDbType.Int).Value = vIDReferencia
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@UF", SqlDbType.Char, 2).Value = vUF
            cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar, 100).Value = vCidade
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = vIDLoja
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.Int).Value = vIDRegiao
            cmd.Parameters.Add("@IDTIPOLOJA", SqlDbType.Int).Value = vIDTipoLoja

            ExecuteNonQuery(cmd)

        End Sub

    End Class

End Namespace


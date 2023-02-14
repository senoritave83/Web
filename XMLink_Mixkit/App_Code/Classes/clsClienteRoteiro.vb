

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsClienteRoteiro
		Inherits BaseClass
		Implements IClientesRoteiro, IRoteirosCliente

	#Region "Declarations" 
		Protected m_intIDInterno As Integer	
	#End Region  
	
	Friend Sub New(ByVal vIDInterno As Integer)
		m_intIDInterno = vIDInterno
	End Sub

	Sub New()
		m_intIDInterno = 0
	End Sub
	
    #Region "Metodos"

        ''' <summary>
        ''' 	Função que adiciona um item na tabela
        ''' </summary>
        Public Sub Add(ByVal vIDCliente As Integer, ByVal vIDRoteiro As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_CLIENTE_ROTEIRO"
			cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).value = vIDCliente
			cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).value = vIDRoteiro
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          ExecuteNonQuery(cmd)
        End Sub

        ''' <summary>
        ''' 	Função que remove um item na tabela
        ''' </summary>
        Public Sub Delete(ByVal vIDCliente As Integer, ByVal vIDRoteiro As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_CLIENTE_ROTEIRO"
			cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).value = vIDCliente
			cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).value = vIDRoteiro
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          ExecuteNonQuery(cmd)
        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem de Clientes no Roteiro
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function ListarClientes(ByVal vIDRoteiro As Integer, Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_ROTEIRO_CLIENTES"
            cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).value = vIDRoteiro
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          	Return ExecuteCommand(cmd, vReturnType)

		End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem de Roteiros no Cliente
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function ListarRoteiros(ByVal vIDCliente As Integer, Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_CLIENTE_ROTEIROS"
            cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).value = vIDCliente
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          	Return ExecuteCommand(cmd, vReturnType)

		End Function

#End Region

#Region "Implementações da Interface  IClientesRoteiro" 
	
        Protected Sub IClientesRoteiro_Add(ByVal vIDCliente As Integer) Implements IClientesRoteiro.Add
			Add(vIDCliente, m_intIDInterno)
        End Sub

		Protected Sub IClientesRoteiro_Delete(ByVal vIDCliente As Integer) Implements IClientesRoteiro.Delete
			Delete(vIDCliente, m_intIDInterno)
        End Sub

        Protected Sub IClientesRoteiro_Clear() Implements IClientesRoteiro.Clear
			Delete(-1, m_intIDInterno)
        End Sub

        Protected Function IClientesRoteiro_GetFirstID() As Integer Implements IClientesRoteiro.GetFirstID
            Dim dr As IDataReader = ListarClientes(m_intIDInterno)
            If dr.Read Then
                IClientesRoteiro_GetFirstID = dr.GetInt32(dr.GetOrdinal("IDCliente"))
            End If
            dr.Close()
            dr.Dispose()
        End Function

		Protected Sub  IClientesRoteiro_SetOnlyID(ByVal vIDCliente As Integer) Implements  IClientesRoteiro.SetOnlyID
            Dim dr As IDataReader = ListarClientes(m_intIDInterno)
			Dim blnExiste as Boolean = false
            do while dr.Read
				if dr.GetInt32(dr.GetOrdinal("IDCliente")) <> vIDCliente Then 
					IClientesRoteiro_Delete(dr.GetInt32(dr.GetOrdinal("IDCliente")))
				Else
					blnExiste = True 
				End if
            loop
            dr.Close()
            dr.Dispose()
			if not blnExiste Then
				IClientesRoteiro_Add(vIDCliente)
			end if
		End Sub

		Protected Function IClientesRoteiro_Listar(Optional ByVal vReturnType As XMSistemas.Web.Base.DataClass.enReturnType = XMSistemas.Web.Base.DataClass.enReturnType.DataReader) As Object Implements IClientesRoteiro.Listar
			Return ListarClientes(m_intIDInterno, vReturnType)
		End Function 

        Public Interface IClientesRoteiro
            Sub Add(ByVal vIDCliente As Integer)
            Sub Delete(ByVal vIDCliente As Integer)
			Sub Clear()
			Function GetFirstID() As Integer
			Sub SetOnlyID(ByVal vIDCliente As Integer)
            Function Listar(Optional ByVal vReturnType As XMSistemas.Web.Base.DataClass.enReturnType = XMSistemas.Web.Base.DataClass.enReturnType.DataReader) As Object
        End Interface

#End Region

#Region "Implementações da Interface  IRoteirosCliente" 

		Protected Sub IRoteirosCliente_Add(ByVal vIDRoteiro As Integer) Implements IRoteirosCliente.Add
			Add(m_intIDInterno, vIDRoteiro)
        End Sub

        Protected Sub IRoteirosCliente_Delete(ByVal vIDRoteiro As Integer) Implements IRoteirosCliente.Delete
			Delete(m_intIDInterno, vIDRoteiro)
        End Sub

        Protected Sub IRoteirosCliente_Clear() Implements IRoteirosCliente.Clear
			Delete(m_intIDInterno, -1)
        End Sub

        Protected Function IRoteirosCliente_GetFirstID() As Integer Implements IRoteirosCliente.GetFirstID
            Dim dr As IDataReader = ListarRoteiros(m_intIDInterno)
            If dr.Read Then
                IRoteirosCliente_GetFirstID = dr.GetInt32(dr.GetOrdinal("IDRoteiro"))
            End If
            dr.Close()
            dr.Dispose()
        End Function

		Protected Sub  IRoteirosCliente_SetOnlyID(ByVal vIDRoteiro As Integer) Implements  IRoteirosCliente.SetOnlyID
            Dim dr As IDataReader = ListarRoteiros(m_intIDInterno)
			Dim blnExiste as Boolean = false
            do while dr.Read
				if dr.GetInt32(dr.GetOrdinal("IDRoteiro")) <> vIDRoteiro Then 
					IRoteirosCliente_Delete(dr.GetInt32(dr.GetOrdinal("IDRoteiro")))
				Else
					blnExiste = True 
				End if
            loop
            dr.Close()
            dr.Dispose()
			if not blnExiste Then
				IRoteirosCliente_Add(vIDRoteiro)
			end if
		End Sub

		Protected Function IRoteirosCliente_Listar(Optional ByVal vReturnType As XMSistemas.Web.Base.DataClass.enReturnType = XMSistemas.Web.Base.DataClass.enReturnType.DataReader) As Object Implements IRoteirosCliente.Listar
			Return ListarRoteiros(m_intIDInterno, vReturnType)
		End Function 

        Public Interface IRoteirosCliente
            Sub Add(ByVal vIDRoteiro As Integer)
            Sub Delete(ByVal vIDRoteiro As Integer)
			Sub Clear()
			Function GetFirstID() As Integer
			Sub SetOnlyID(ByVal vIDRoteiro As Integer)
            Function Listar(Optional ByVal vReturnType As XMSistemas.Web.Base.DataClass.enReturnType = XMSistemas.Web.Base.DataClass.enReturnType.DataReader) As Object
        End Interface

#End Region
	  
	End Class
End Namespace


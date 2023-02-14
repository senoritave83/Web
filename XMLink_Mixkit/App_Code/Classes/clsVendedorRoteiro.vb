

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsVendedorRoteiro
		Inherits BaseClass
		Implements IVendedoresRoteiro, IRoteirosVendedor

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
        Public Sub Add(ByVal vIDVendedor As Integer, ByVal vIDRoteiro As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_VENDEDOR_ROTEIRO"
			cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).value = vIDVendedor
			cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).value = vIDRoteiro
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          ExecuteNonQuery(cmd)
        End Sub

        ''' <summary>
        ''' 	Função que remove um item na tabela
        ''' </summary>
        Public Sub Delete(ByVal vIDVendedor As Integer, ByVal vIDRoteiro As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_VENDEDOR_ROTEIRO"
			cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).value = vIDVendedor
			cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).value = vIDRoteiro
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          ExecuteNonQuery(cmd)
        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem de Vendedores no Roteiro
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function ListarVendedores(ByVal vIDRoteiro As Integer, Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_ROTEIRO_VENDEDORES"
            cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).value = vIDRoteiro
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          	Return ExecuteCommand(cmd, vReturnType)

		End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem de Roteiros no Vendedor
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function ListarRoteiros(ByVal vIDVendedor As Integer, Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_VENDEDOR_ROTEIROS"
            cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).value = vIDVendedor
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          	Return ExecuteCommand(cmd, vReturnType)

		End Function

#End Region

#Region "Implementações da Interface  IVendedoresRoteiro" 
	
        Protected Sub IVendedoresRoteiro_Add(ByVal vIDVendedor As Integer) Implements IVendedoresRoteiro.Add
			Add(vIDVendedor, m_intIDInterno)
        End Sub

		Protected Sub IVendedoresRoteiro_Delete(ByVal vIDVendedor As Integer) Implements IVendedoresRoteiro.Delete
			Delete(vIDVendedor, m_intIDInterno)
        End Sub

        Protected Sub IVendedoresRoteiro_Clear() Implements IVendedoresRoteiro.Clear
			Delete(-1, m_intIDInterno)
        End Sub

        Protected Function IVendedoresRoteiro_GetFirstID() As Integer Implements IVendedoresRoteiro.GetFirstID
            Dim dr As IDataReader = ListarVendedores(m_intIDInterno)
            If dr.Read Then
                IVendedoresRoteiro_GetFirstID = dr.GetInt32(dr.GetOrdinal("IDVendedor"))
            End If
            dr.Close()
            dr.Dispose()
        End Function

		Protected Sub  IVendedoresRoteiro_SetOnlyID(ByVal vIDVendedor As Integer) Implements  IVendedoresRoteiro.SetOnlyID
            Dim dr As IDataReader = ListarVendedores(m_intIDInterno)
			Dim blnExiste as Boolean = false
            do while dr.Read
				if dr.GetInt32(dr.GetOrdinal("IDVendedor")) <> vIDVendedor Then 
					IVendedoresRoteiro_Delete(dr.GetInt32(dr.GetOrdinal("IDVendedor")))
				Else
					blnExiste = True 
				End if
            loop
            dr.Close()
            dr.Dispose()
			if not blnExiste Then
				IVendedoresRoteiro_Add(vIDVendedor)
			end if
		End Sub

		Protected Function IVendedoresRoteiro_Listar(Optional ByVal vReturnType As XMSistemas.Web.Base.DataClass.enReturnType = XMSistemas.Web.Base.DataClass.enReturnType.DataReader) As Object Implements IVendedoresRoteiro.Listar
			Return ListarVendedores(m_intIDInterno, vReturnType)
		End Function 

        Public Interface IVendedoresRoteiro
            Sub Add(ByVal vIDVendedor As Integer)
            Sub Delete(ByVal vIDVendedor As Integer)
			Sub Clear()
			Function GetFirstID() As Integer
			Sub SetOnlyID(ByVal vIDVendedor As Integer)
            Function Listar(Optional ByVal vReturnType As XMSistemas.Web.Base.DataClass.enReturnType = XMSistemas.Web.Base.DataClass.enReturnType.DataReader) As Object
        End Interface

#End Region

#Region "Implementações da Interface  IRoteirosVendedor" 

		Protected Sub IRoteirosVendedor_Add(ByVal vIDRoteiro As Integer) Implements IRoteirosVendedor.Add
			Add(m_intIDInterno, vIDRoteiro)
        End Sub

        Protected Sub IRoteirosVendedor_Delete(ByVal vIDRoteiro As Integer) Implements IRoteirosVendedor.Delete
			Delete(m_intIDInterno, vIDRoteiro)
        End Sub

        Protected Sub IRoteirosVendedor_Clear() Implements IRoteirosVendedor.Clear
			Delete(m_intIDInterno, -1)
        End Sub

        Protected Function IRoteirosVendedor_GetFirstID() As Integer Implements IRoteirosVendedor.GetFirstID
            Dim dr As IDataReader = ListarRoteiros(m_intIDInterno)
            If dr.Read Then
                IRoteirosVendedor_GetFirstID = dr.GetInt32(dr.GetOrdinal("IDRoteiro"))
            End If
            dr.Close()
            dr.Dispose()
        End Function

		Protected Sub  IRoteirosVendedor_SetOnlyID(ByVal vIDRoteiro As Integer) Implements  IRoteirosVendedor.SetOnlyID
            Dim dr As IDataReader = ListarRoteiros(m_intIDInterno)
			Dim blnExiste as Boolean = false
            do while dr.Read
				if dr.GetInt32(dr.GetOrdinal("IDRoteiro")) <> vIDRoteiro Then 
					IRoteirosVendedor_Delete(dr.GetInt32(dr.GetOrdinal("IDRoteiro")))
				Else
					blnExiste = True 
				End if
            loop
            dr.Close()
            dr.Dispose()
			if not blnExiste Then
				IRoteirosVendedor_Add(vIDRoteiro)
			end if
		End Sub

		Protected Function IRoteirosVendedor_Listar(Optional ByVal vReturnType As XMSistemas.Web.Base.DataClass.enReturnType = XMSistemas.Web.Base.DataClass.enReturnType.DataReader) As Object Implements IRoteirosVendedor.Listar
			Return ListarRoteiros(m_intIDInterno, vReturnType)
		End Function 

        Public Interface IRoteirosVendedor
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


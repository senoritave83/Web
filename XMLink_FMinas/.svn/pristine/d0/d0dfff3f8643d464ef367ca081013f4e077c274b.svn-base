Imports System.Data

<Serializable()> _
Public Class PaginateResult
    Implements IPaginaResult

    Protected m_objData As IDataReader
    Protected m_intCurrentPage As Integer
    Protected m_intPageCount As Integer
    Protected m_intPageSize As Integer
    Protected m_intRecordCount As Integer


    Public Property CurrentPage() As Integer Implements IPaginaResult.CurrentPage
        Get
            Return m_intCurrentPage
        End Get
        Set(ByVal value As Integer)
            m_intCurrentPage = value
        End Set
    End Property

    Public Property PageCount() As Integer Implements IPaginaResult.PageCount
        Get
            Return m_intPageCount
        End Get
        Set(ByVal value As Integer)
            m_intPageCount = value
        End Set
    End Property

    Public Property PageSize() As Integer Implements IPaginaResult.PageSize
        Get
            Return m_intPageSize
        End Get
        Set(ByVal value As Integer)
            m_intPageSize = value
            If m_intPageSize > 0 Then
                m_intPageCount = m_intRecordCount \ m_intPageSize
            Else
                m_intPageCount = 0
            End If
        End Set
    End Property

    Public Property RecordCount() As Integer Implements IPaginaResult.RecordCount
        Get
            Return m_intRecordCount
        End Get
        Set(ByVal value As Integer)
            m_intRecordCount = value
            If m_intPageSize > 0 Then
                m_intPageCount = m_intRecordCount \ m_intPageSize
            Else
                m_intPageCount = 0
            End If
        End Set
    End Property

    Public Property Data() As System.Data.IDataReader Implements IPaginaResult.Data
        Get
            Return m_objData
        End Get
        Set(ByVal value As System.Data.IDataReader)
            m_objData = value
        End Set
    End Property
End Class


Public Interface IPaginaResult
    Property CurrentPage() As Integer
    Property PageCount() As Integer
    Property PageSize() As Integer
    Property RecordCount() As Integer
    Property Data() As IDataReader

End Interface

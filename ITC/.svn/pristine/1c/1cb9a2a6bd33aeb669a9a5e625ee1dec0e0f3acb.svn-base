Public Class ControleVenObraEmp
    Inherits DataClass

    Private m_Vendedor As Integer
    Private m_Codigo As Integer
    Private m_Tipo As TIPO_CADASTRO

    Public ReadOnly Property IDVendedor() As Integer
        Get
            Return m_Vendedor
        End Get
    End Property

    Public ReadOnly Property Codigo() As Integer
        Get
            Return m_Codigo
        End Get
    End Property

    Private Sub Inflate(ByVal row As DataRow)
        Me.m_Vendedor = CInt(0 & row("IDVENDEDOR"))
    End Sub

    'Private Function Deflate(ByVal vIDAssociado As Integer) As String
    '    Dim strDeflate As String
    '    strDeflate &= vIDAssociado & ","
    '    strDeflate &= m_Vendedor & ","
    '    strDeflate &= TIPO_CADASTRO.OBRA & ","
    '    strDeflate &= m_Codigo
    '    Deflate = strDeflate
    'End Function

    Public Sub Update(ByVal vIDAssociado As Integer, ByVal vIDVendedor As Integer)
        Dim sql As String
        sql = "SP_SV_CONTROLEVENDOBREMP "
        sql &= vIDAssociado & ","
        sql &= vIDVendedor & ","
        sql &= m_Tipo & ","
        sql &= m_Codigo
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não houve retorno de dados!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub

    'Private Function DeflateEmp() As String
    '    Dim strDeflate As String
    '    strDeflate &= m_IdAssociado & ","
    '    strDeflate &= m_Vendedor & ","
    '    strDeflate &= vTipo & ","
    '    strDeflate &= m_Codigo
    '    DeflateEmp = strDeflate
    'End Function

    'Public Sub UpdateEmp()

    '    Dim sql As String
    '    sql = "SP_SV_CONTROLEVENDOBREMP " & DeflateEmp()
    '    Dim myData As DataSet
    '    myData = GetDataSet(sql)
    '    If myData.Tables(0).Rows.Count <= 0 Then
    '        Throw New ArgumentException("Não houve retorno de dados!")
    '    Else
    '        Inflate(myData.Tables(0).Rows(0))
    '    End If
    '    myData.Dispose()

    'End Sub

    Protected Sub Load(ByVal p_intCodigo As Integer, ByVal p_intTipo As Integer)
        If p_intCodigo = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet("SP_SE_CONTROLEVENDOBREMP " & p_intCodigo & "," & p_intTipo)
        If myData.Tables(0).Rows.Count <= 0 Then
            Clear()
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Private Sub Clear()
        m_Vendedor = 0
    End Sub

    Public Sub New(ByVal vIDCodigo As Integer, ByVal vTipo As TIPO_CADASTRO)
        m_Codigo = vIDCodigo
        m_Tipo = vTipo
        Load(m_Codigo, vTipo)
    End Sub
End Class

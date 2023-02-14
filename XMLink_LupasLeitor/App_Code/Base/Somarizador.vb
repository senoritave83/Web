Public Class Somarizador

    Private col As New Generic.Dictionary(Of String, clsSomarizadorItem)


    Public Function Add(ByVal value As Double, ByVal key As String) As Double
        If col.ContainsKey(key) Then
            col.Item(key).Add(value)
        Else
            col.Add(key, New clsSomarizadorItem(value))
        End If
        Return value
    End Function

    Public Function AddNonQuery(ByVal value As Double, ByVal key As String) As String
        Add(value, key)
        Return ""
    End Function

    Public ReadOnly Property Item(ByVal key As String) As clsSomarizadorItem
        Get
            If col.ContainsKey(key) Then
                Return col.Item(key)
            Else
                Return New clsSomarizadorItem(0)
            End If

        End Get
    End Property

    Public Class clsSomarizadorItem
        Private m_dblSum As Double
        Private m_dblMax As Double
        Private m_dblMin As Double
        Private m_intCount As Integer

        Public Sub New(ByVal Value As Double)
            m_dblSum = Value
            m_dblMax = Value
            m_dblMin = Value
            m_intCount = 1
        End Sub

        Public Sub Add(ByVal Value As Double)
            m_intCount += 1
            m_dblSum += Value
            If m_dblMax < Value Then m_dblMax = Value
            If m_dblMin > Value Then m_dblMin = Value
        End Sub

        Public ReadOnly Property Sum() As Double
            Get
                Return m_dblSum
            End Get
        End Property

        Public ReadOnly Property Max() As Double
            Get
                Return m_dblMax
            End Get
        End Property

        Public ReadOnly Property Min() As Double
            Get
                Return m_dblMin
            End Get
        End Property

        Public ReadOnly Property Avg() As Double
            Get
                If m_intCount > 0 Then
                    Return m_dblSum / m_intCount
                Else
                    Return 0
                End If
            End Get
        End Property

        Public ReadOnly Property Count() As Integer
            Get
                Return m_intCount
            End Get
        End Property


    End Class


End Class
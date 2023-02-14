Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace Settings

    'Geral
    Public Enum enTipoExibicao As Integer
        Nunca = 0
        NaListagem = 1
        NaTela = 2
        Sempre = 3
    End Enum


    Public Class clsXMLinkSettings
        Inherits Classes.BaseClass

        Public ExibirDataCriacao As enTipoExibicao = enTipoExibicao.Nunca

        Protected _vendedor As subclasses.Vendedor
        Protected _TipoCliente As subclasses.TipoCliente
        Protected _Regiao As subclasses.Regiao
        Protected _Tabela As subclasses.Tabela
        Protected _Roteiro As subclasses.Roteiro
        Protected _Cliente As subclasses.Cliente
        Protected _Produto As subclasses.Produto
        Protected _Linha As subclasses.Linha
        Protected _Marca As subclasses.Marca
        Protected _Grupo As subclasses.Grupo
        Protected _SubCategoria As subclasses.SubCategoria
        Protected _FormaPagamento As subclasses.FormaPagamento
        Protected _Bandeira As subclasses.Loja
        Protected _Categoria As subclasses.Categoria
        Protected _condicao As subclasses.Condicao


        Public ReadOnly Property Loja() As subclasses.Loja
            Get
                Return _Bandeira
            End Get
        End Property

        Public ReadOnly Property Categoria() As subclasses.Categoria
            Get
                Return _Categoria
            End Get
        End Property

        Public ReadOnly Property Condicao() As subclasses.Condicao
            Get
                Return _condicao
            End Get
        End Property

        Public ReadOnly Property FormaPagamento() As subclasses.FormaPagamento
            Get
                Return _FormaPagamento
            End Get
        End Property

        Public ReadOnly Property SubCategoria() As subclasses.SubCategoria
            Get
                Return _SubCategoria
            End Get
        End Property

        Public ReadOnly Property Grupo() As subclasses.Grupo
            Get
                Return _Grupo
            End Get
        End Property

        Public ReadOnly Property Marca() As subclasses.Marca
            Get
                Return _Marca
            End Get
        End Property

        Public ReadOnly Property Linha() As subclasses.Linha
            Get
                Return _Linha
            End Get
        End Property

        Public ReadOnly Property Produto() As subclasses.Produto
            Get
                Return _Produto
            End Get
        End Property

        Public ReadOnly Property Cliente() As subclasses.Cliente
            Get
                Return _Cliente
            End Get
        End Property

        Public ReadOnly Property Roteiro() As subclasses.Roteiro
            Get
                Return _Roteiro
            End Get
        End Property

        Public ReadOnly Property Tabela() As subclasses.Tabela
            Get
                Return _Tabela
            End Get
        End Property

        Public ReadOnly Property TipoCliente() As subclasses.TipoCliente
            Get
                Return _TipoCliente
            End Get
        End Property

        Public ReadOnly Property Regiao() As subclasses.Regiao
            Get
                Return _Regiao
            End Get
        End Property


        Public ReadOnly Property Vendedor() As subclasses.Vendedor
            Get
                Return _vendedor
            End Get
        End Property




        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Friend Sub Inflate(ByVal dr As IDataReader)
            _vendedor = New subclasses.Vendedor(dr)
            _condicao = New subclasses.Condicao(dr)
            _Categoria = New subclasses.Categoria(dr)
            _Bandeira = New subclasses.Loja(dr)
            _Marca = New subclasses.Marca(dr)
            _Linha = New subclasses.Linha(dr)
            _SubCategoria = New subclasses.SubCategoria(dr)
            _FormaPagamento = New subclasses.FormaPagamento(dr)
            _Grupo = New subclasses.Grupo(dr)
            _Roteiro = New subclasses.Roteiro(dr)
            _Tabela = New subclasses.Tabela(dr)
            _Cliente = New subclasses.Cliente(dr)
            _TipoCliente = New subclasses.TipoCliente(dr)
            _Regiao = New subclasses.Regiao(dr)
            _Produto = New subclasses.Produto(dr)
        End Sub



        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        Public Sub New()
            Inflate(Nothing)
            'Dim cmd As New SqlCommand()
            'cmd.CommandType = CommandType.StoredProcedure
            'cmd.CommandText = PREFIXO & "SE_SETTINGS"
            'cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            'Dim dr As IDataReader = ExecuteReader(cmd)
            'Try
            '    If dr.Read Then
            '        Inflate(dr)
            '    Else
            '        Inflate(Nothing)
            '    End If
            'Finally
            '    If (Not dr Is Nothing) Then
            '        dr.Close()
            '        dr = Nothing
            '    End If
            'End Try
        End Sub

        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_SETTINGS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            _vendedor.SetParameters(cmd.Parameters)
            _condicao.SetParameters(cmd.Parameters)
            _Categoria.SetParameters(cmd.Parameters)
            _Bandeira.SetParameters(cmd.Parameters)
            _Marca.SetParameters(cmd.Parameters)
            _Linha.SetParameters(cmd.Parameters)
            _SubCategoria.SetParameters(cmd.Parameters)
            _FormaPagamento.SetParameters(cmd.Parameters)
            _Grupo.SetParameters(cmd.Parameters)
            _Roteiro.SetParameters(cmd.Parameters)
            _Tabela.SetParameters(cmd.Parameters)
            _Cliente.SetParameters(cmd.Parameters)
            _TipoCliente.SetParameters(cmd.Parameters)
            _Regiao.SetParameters(cmd.Parameters)
            _Produto.SetParameters(cmd.Parameters)
            ExecuteNonQuery(cmd)
        End Sub



    End Class

End Namespace


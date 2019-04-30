'Imports System.Data.SqlClient
'Imports System.Data.OleDb

'Imports System.Configuration

''' <summary>
''' 本アプリで使用するメインモジュール
''' </summary>
''' <remarks></remarks>
Module modMain

#Region "Variable"

	Private _sqlConcStrBuilder As SqlConnectionStringBuilder = Nothing

	Private _isSqlConnect As Boolean = False
	Private _sqlConnection As SqlClient.SqlConnection = Nothing

	Private _lstTable As List(Of String) = Nothing

	Private _lstAllPerson As List(Of firstDBpersonTable) = Nothing

#End Region

#Region "Property"

	''' <summary>
	''' DB接続に成功したか否か
	''' </summary>
	''' <value></value>
	''' <returns>True:Connecting DB, False:Not Connecting DB</returns>
	''' <remarks></remarks>
	Public ReadOnly Property ConnectingDB() As Boolean
		Get
			Return _isSqlConnect
		End Get
	End Property

	''' <summary>
	''' oleDBConnection
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property Connection() As SqlConnection
		Get
			Return _sqlConnection
		End Get
	End Property

	''' <summary>
	''' 全テーブルの名称
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property TableName() As List(Of String)
		Get
			Return _lstTable
		End Get
	End Property


#End Region

	''' <summary>
	''' Entry Point
	''' </summary>
	''' <remarks></remarks>
	<STAThread> _
	Public Sub Main()
		'SetUp
		Preparation()

		'Show Main-Window
		Using _windowMain As New windowMain
			_windowMain.ShowDialog()
		End Using
	End Sub

	''' <summary>
	''' SetUp this module
	''' </summary>
	''' <remarks></remarks>
	Private Sub Preparation()
		'Connect DataBase
		ConnectDB()

		'Get all table names
		GetTableInfo()
	End Sub

	''' <summary>
	''' Connect DB
	''' </summary>
	''' <remarks></remarks>
	Private Sub ConnectDB()
		_isSqlConnect = True

		_sqlConcStrBuilder = New SqlConnectionStringBuilder

		With _sqlConcStrBuilder
			.DataSource = ".\SQLEXPRESS"
			.IntegratedSecurity = True
			.UserInstance = True
			.MultipleActiveResultSets = True
		End With

		'Using sqlConnect As New SqlConnection(_sqlConcStrBuilder.ToString)
		'	sqlConnect.Open()

		'	Dim schemaTable As DataTable = sqlConnect.GetSchema("tables")
		'	Dim con As Constraint = Nothing
		'	'Dim command As SqlCommand = sqlConnect.CreateCommand()


		'	For Each row As DataRow In schemaTable.Rows
		'		'Dim test As String = row.ToString
		'		'Dim obj As Object = row.Item(3)
		'		MessageBox.Show(row("TABLE_NAME").ToString)

		'	Next
		'	'For Each constColl As ConstraintCollection In schemaTable.Constraints
		'	'	For index As Integer = 1 To constColl.Count
		'	'		con = constColl.Item(index)

		'	'	Next
		'	'	'For Each contain As Constraint In constColl.Count

		'	'	'Next
		'	'Next

		'	'For Each rowCollection As DataRowCollection In schemaTable.Rows
		'	'	For Each row As DataRow In rowCollection

		'	'	Next
		'	'Next
		'End Using


		Try
			_sqlConnection = New SqlConnection("server = .\SQLEXPRESS;" _
														& "initial catalog=first;" _
														& "integrated security=SSPI")
			'_sqlConnection = New OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0")
		Catch ex As Exception
			_isSqlConnect = False

			MessageBox.Show(ex.ToString)
		End Try

	End Sub

	''' <summary>
	''' テーブル名を取得
	''' </summary>
	''' <remarks></remarks>
	Private Sub GetTableInfo()
		'Dim configMng As ConfigurationManager = Nothing
		'configMng = New ConfigurationManager
		Dim sqlQuery As SqlCommand = Nothing
		Dim sqlReader As SqlDataReader = Nothing
		Dim query As StringBuilder = Nothing

		_lstTable = New List(Of String)

		'Connect DB
		_sqlConnection.Open()
		sqlQuery = _sqlConnection.CreateCommand()

		'Make query
		query = New StringBuilder
		query.AppendLine("select t.name")
		query.AppendLine("from sys.tables t")
		query.AppendLine("order by t.name")

		sqlQuery.CommandText = query.ToString

		'Get data
		sqlReader = sqlQuery.ExecuteReader()

		'Store table names
		While sqlReader.Read
			_lstTable.Add(sqlReader(0).ToString)
		End While
	End Sub

	Private Function GetPersonFromQuery(ByVal no As Integer) As firstDBpersonTable
		Dim lstPerson As firstDBpersonTable = Nothing

		lstPerson = New firstDBpersonTable
		If _isSqlConnect Then
			lstPerson.DataGetOneRecoad(_sqlConnection, no)
		End If

		Return lstPerson
	End Function

	Private Function GetPersonFromQuery(ByVal query As String) As List(Of firstDBpersonTable)
		Dim lstPerson As List(Of firstDBpersonTable) = Nothing

		lstPerson = New List(Of firstDBpersonTable)

		Return lstPerson
	End Function

End Module

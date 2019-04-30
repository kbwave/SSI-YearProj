'Imports System.Data.SqlClient
'Imports System.Data.OleDb

''' <summary>
''' first-DBのperson-Table
''' </summary>
''' <remarks></remarks>
Public Class firstDBpersonTable
	Implements IDisposable, ITableClass

#Region "Interface"

#Region "ITableClass"

	''' <summary>
	''' DBからデータ取得
	''' </summary>
	''' <remarks></remarks>
	Public Sub GetData() Implements ITableClass.GetData

	End Sub

	''' <summary>
	''' DBでデータ登録
	''' </summary>
	''' <remarks></remarks>
	Public Sub RegistData() Implements ITableClass.RegistData

	End Sub
#End Region

#Region "IDisposable"
#Region "IDisposable Support"
	Private disposedValue As Boolean ' 重複する呼び出しを検出するには
	' IDisposable
	Protected Overridable Sub Dispose(disposing As Boolean)
		If Not Me.disposedValue Then
			If disposing Then
				' TODO: マネージ状態を破棄します (マネージ オブジェクト)。
			End If

			' TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下の Finalize() をオーバーライドします。
			' TODO: 大きなフィールドを null に設定します。
		End If
		Me.disposedValue = True
	End Sub

	' TODO: 上の Dispose(ByVal disposing As Boolean) にアンマネージ リソースを解放するコードがある場合にのみ、Finalize() をオーバーライドします。
	'Protected Overrides Sub Finalize()
	'    ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(ByVal disposing As Boolean) に記述します。
	'    Dispose(False)
	'    MyBase.Finalize()
	'End Sub

	' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
	Public Sub Dispose() Implements IDisposable.Dispose
		' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
		Dispose(True)
		GC.SuppressFinalize(Me)
	End Sub
#End Region
#End Region


#End Region

#Region "Property"

	Private _no As Integer = -1
	''' <summary>
	''' No
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property No() As Integer
		Get
			Return _no
		End Get
		Set(ByVal value As Integer)
			_no = value
		End Set
	End Property

	Private _name As String = String.Empty
	''' <summary>
	''' 氏名
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Name() As String
		Get
			Return _name
		End Get
		Set(ByVal value As String)
			_name = value
		End Set
	End Property

	Private _birthday As String = String.Empty
	''' <summary>
	''' 誕生日
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BirthDay() As String
		Get
			Return _birthday
		End Get
		Set(ByVal value As String)
			_birthday = value
		End Set
	End Property

	''' <summary>
	''' データを保持しているか否か
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property HavingData() As Boolean
		Get
			Return Me._no <> -1
		End Get
	End Property

#End Region

#Region "Enumerate"

	''' <summary>
	''' カラムの列Index定義
	''' </summary>
	''' <remarks></remarks>
	Private Enum col As Integer
		None = -1
		No
		Name
		Birthday

		Num
	End Enum



#End Region

#Region "Event"

	''' <summary>
	''' Instance
	''' </summary>
	''' <remarks></remarks>
	Public Sub New()
		Me.Initialize()
	End Sub

#End Region

#Region "Function"

	''' <summary>
	''' 初期化
	''' </summary>
	''' <remarks></remarks>
	Public Sub Initialize()
		With Me
			._no = -1
			._name = String.Empty
			._birthday = String.Empty
		End With
	End Sub

	''' <summary>
	''' 複製
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function Clone() As firstDBpersonTable
		Dim myClone As firstDBpersonTable = Nothing

		myClone = New firstDBpersonTable

		With myClone
			.No = Me._no
			.Name = Me._name
			.BirthDay = Me._birthday
		End With

		Return myClone
	End Function

	''' <summary>
	''' 主キーを指定してDBからデータ取得
	''' </summary>
	''' <param name="connection"></param>
	''' <param name="no"></param>
	''' <remarks></remarks>
	Public Function DataGetOneRecoad(ByVal connection As SqlConnection, ByVal no As Integer, Optional ByVal close As Boolean = True) As Boolean
		Dim query As SqlCommand = Nothing
		Dim sqlReader As SqlDataReader = Nothing

		'Set connection
		connection.Open()
		query = connection.CreateCommand()

		'Set query
		query.CommandText = "select * from person p where p.no = " & no.ToString & ""

		'Get data
		sqlReader = query.ExecuteReader()

		If sqlReader.Read() Then
			Me._no = CInt(sqlReader(col.No))
			Me._name = sqlReader(col.Name).ToString
			Me.BirthDay = sqlReader(col.Birthday).ToString
		Else
			Me.Initialize()
		End If

		If close Then
			modMain.Connection.Close()
		End If

		Return Me.HavingData
	End Function

	''' <summary>
	''' 自身の情報を文字列化
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Overrides Function ToString() As String
		If Me.HavingData Then
			Dim text As System.Text.StringBuilder = Nothing
			text = New System.Text.StringBuilder

			text.AppendLine("No = " & Me._no.ToString)
			text.AppendLine("Name = " & Me._name)
			text.AppendLine("Birthday = " & Me._birthday)

			Return text.ToString
		Else
			Return "データを持っていない"
		End If

		'Return MyBase.ToString()
	End Function

#End Region

End Class

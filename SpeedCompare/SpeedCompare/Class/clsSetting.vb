''' <summary>
''' 設定関係を管理
''' </summary>
''' <remarks></remarks>
Public Class clsSetting
	Implements IDisposable

#Region "Interface"

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

#Region "Property"

	Private _loop As Long = 0&
	''' <summary>
	''' 繰り返し回数
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property LoopNum() As Long
		Get
			Return _loop
		End Get
		Set(ByVal value As Long)
			_loop = value
		End Set
	End Property

	Private _testingNum As Integer = 0
	''' <summary>
	''' 試行回数
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property TestNum() As Integer
		Get
			Return _testingNum
		End Get
		Set(ByVal value As Integer)
			_testingNum = value
		End Set
	End Property

	Private _compareTypeIndex As Integer = 0
	''' <summary>
	''' 比較を行う種類
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CompareType() As Integer
		Get
			Return _compareTypeIndex
		End Get
		Set(ByVal value As Integer)
			_compareTypeIndex = value
		End Set
	End Property



#End Region

#Region "Event"

	Public Sub New()

	End Sub

#End Region

#Region "Function"

#End Region

End Class

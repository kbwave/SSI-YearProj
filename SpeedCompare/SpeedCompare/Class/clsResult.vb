''' <summary>
''' 結果を管理
''' </summary>
''' <remarks></remarks>
Public Class clsResult
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
			If Not Me._resultListA Is Nothing Then
				Me._resultListA.Clear()
				Me._resultListA = Nothing
			End If
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

	Private _resultListA As List(Of Long) = Nothing
	''' <summary>
	''' 測定結果Aのリスト
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ResultListA() As List(Of Long)
		Get
			Return _resultListA
		End Get
		Set(ByVal value As List(Of Long))
			_resultListA = value
		End Set
	End Property

	Private _resultListB As List(Of Long) = Nothing
	''' <summary>
	''' 測定結果Bのリスト
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ResultListB() As List(Of Long)
		Get
			Return _resultListB
		End Get
		Set(ByVal value As List(Of Long))
			_resultListB = value
		End Set
	End Property

	''' <summary>
	''' 測定結果数
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property ResultNum() As Integer
		Get
			If Me._resultListA Is Nothing OrElse Me._resultListB Is Nothing Then
				Return 0

			ElseIf Me._resultListA.Count <> Me._resultListB.Count Then
				Return 0

			Else
				Return Me._resultListA.Count
			End If
		End Get
	End Property


#End Region

#Region "Event"


	Public Sub New()
		Me._resultListA = New List(Of Long)
		Me._resultListB = New List(Of Long)
	End Sub

#End Region

#Region "Function"

	''' <summary>
	''' A部分の結果を追加
	''' </summary>
	''' <param name="result"></param>
	''' <remarks></remarks>
	Public Sub AddResultA(ByVal result As Long)
		Me._resultListA.Add(result)
	End Sub

	''' <summary>
	''' B部分の結果を追加
	''' </summary>
	''' <param name="result"></param>
	''' <remarks></remarks>
	Public Sub AddResultB(ByVal result As Long)
		Me._resultListB.Add(result)
	End Sub

	''' <summary>
	''' A部分結果の平均値を取得
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function GetAverageA() As String
		If Me.ResultNum <> 0 Then

		Else
			Return "結果なし"
		End If
	End Function

	''' <summary>
	''' B部分結果の平均値を取得
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function GetAverageB() As String
		If Me.ResultNum <> 0 Then

		Else
			Return "結果なし"
		End If
	End Function

#End Region

End Class

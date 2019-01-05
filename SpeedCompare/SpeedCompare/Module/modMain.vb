Imports System.Diagnostics

''' <summary>
''' 本アプリのメインモジュール
''' </summary>
''' <remarks></remarks>
Module modMain

#Region "PrivateVariable"

	Private _windowMain As windowMain = Nothing

	Private _stopWatch As Stopwatch = Nothing


#End Region

	''' <summary>
	''' エントリーポイント
	''' </summary>
	''' <remarks></remarks>
	<STAThread> _
	Public Sub Main()
		Preparation()

		_windowMain.ShowDialog()

		Terminate()
	End Sub

	''' <summary>
	''' 準備
	''' </summary>
	''' <remarks></remarks>
	Private Sub Preparation()

		If _windowMain Is Nothing Then
			_windowMain = New windowMain
		End If

		If _stopWatch Is Nothing Then
			_stopWatch = New Stopwatch
		End If


	End Sub

	''' <summary>
	''' 後処理
	''' </summary>
	''' <remarks></remarks>
	Private Sub Terminate()
		If Not _windowMain Is Nothing Then
			_windowMain.Dispose()
		End If

		If Not _stopWatch Is Nothing Then
			_stopWatch = Nothing
		End If

	End Sub

#Region "Public Function"

	''' <summary>
	''' ストップウォッチを開始
	''' </summary>
	''' <remarks></remarks>
	Public Sub StartStopWatch()
		If _stopWatch.IsRunning Then
			_stopWatch.Stop()
		End If

		_stopWatch.Reset()
		_stopWatch.Start()
	End Sub

	''' <summary>
	''' ウォッチタイマーの時間を取得
	''' </summary>
	''' <param name="StopFlag"></param>
	''' <remarks></remarks>
	Public Function GetWatchTimer(Optional ByVal StopFlag As Boolean = True) As String
		If StopFlag Then
			_stopWatch.Stop()
		End If

		Return _stopWatch.ElapsedTicks.ToString
	End Function

#End Region

End Module

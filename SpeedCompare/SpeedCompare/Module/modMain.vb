Imports System.Diagnostics
Imports System.Text

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
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function GetWatchTimer() As Long
		_stopWatch.Stop()

		Return _stopWatch.ElapsedTicks
		'Return _stopWatch.ElapsedMilliseconds
	End Function

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

	''' <summary>
	''' 比較種類のリストを取得
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function GetCompareTypeList() As List(Of String)
		Dim compareList As List(Of String) = Nothing
		compareList = New List(Of String)

		'Dim test As String = (1).ToString("D2")

		compareList.Add(modDefine.CompareTypeIndex.StringVsStringBuilder.GetHashCode.ToString("D2") & " " & modDefine.COMPTYPE_STRING_STRINGBUILDER)

		Return compareList
	End Function

	''' <summary>
	''' 試行開始
	''' </summary>
	''' <param name="settingInfo"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function StartTesting(ByVal settingInfo As clsSetting) As clsResult
		Dim resultInfo As clsResult = Nothing

		Select Case settingInfo.CompareType
			Case modDefine.CompareTypeIndex.StringVsStringBuilder
				resultInfo = StringVsStringBuilder(settingInfo)

		End Select

		Return resultInfo
	End Function

	''' <summary>
	''' StringとStringBuilderを比較
	''' </summary>
	''' <param name="settingInfo"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function StringVsStringBuilder(ByVal settingInfo As clsSetting) As clsResult
		Dim resultInfo As clsResult = Nothing
		resultInfo = New clsResult
		Dim stringStr As String = String.Empty
		Dim stringBuildStr As StringBuilder = Nothing

		For testCnt As Integer = 1 To settingInfo.TestNum
			modMain.StartStopWatch()
			For loopCnt As Long = 1& To settingInfo.LoopNum
				stringStr &= "a"
			Next
			'System.Threading.Thread.Sleep(100)
			resultInfo.AddResultA(modMain.GetWatchTimer())
			MessageBox.Show(modMain.GetWatchTimer(True))

			stringBuildStr = New StringBuilder
			modMain.StartStopWatch()
			For loopCnt As Long = 1& To settingInfo.LoopNum
				stringBuildStr.Append("a")
			Next
			'System.Threading.Thread.Sleep(500)
			resultInfo.AddResultB(modMain.GetWatchTimer())
			MessageBox.Show(modMain.GetWatchTimer(True))
		Next

		Return resultInfo
	End Function


#End Region

End Module

Imports System.Diagnostics
Imports System.Text

''' <summary>
''' 本アプリのメインモジュール
''' </summary>
''' <remarks></remarks>
Module modMain

#Region "PrivateVariable"

	''' <summary>
	''' メインウィンドウ
	''' </summary>
	''' <remarks></remarks>
	Private _windowMain As windowMain = Nothing

	''' <summary>
	''' ストップウォッチ
	''' </summary>
	''' <remarks></remarks>
	Private _stopWatch As Stopwatch = Nothing

	''' <summary>
	''' 比較辞書
	''' </summary>
	''' <remarks></remarks>
	Private _compareDic As Dictionary(Of Integer, String) = Nothing

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
		If Not kbwaveRegistryLogic.IsInitialized Then
			kbwaveRegistryLogic.StartUp()
		End If

		' 辞書を作成しないとメインウィンドウのインスタンス時にNothingのまま
		If _compareDic Is Nothing Then
			_compareDic = New Dictionary(Of Integer, String)
		End If
		MakeCompareDic()

		If _windowMain Is Nothing Then
			_windowMain = New windowMain
		End If

		If _stopWatch Is Nothing Then
			_stopWatch = New Stopwatch
		End If

	End Sub

	''' <summary>
	''' 比較の辞書を作成
	''' </summary>
	''' <remarks></remarks>
	Private Sub MakeCompareDic()
		With _compareDic
			.Clear()

			.Add(modDefine.CompareTypeIndex.StringVsStringBuilder.GetHashCode, modDefine.COMPNAME_STRING_STRINGBUILDER)
			.Add(modDefine.CompareTypeIndex.StringBuilderVsStringBuilderCapacity.GetHashCode, modDefine.COMPNAME_STRINGBUILDER_CAPACITY)
		End With
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
	''' ストップウォッチをリセット
	''' </summary>
	''' <remarks></remarks>
	Public Sub ResetStopWatch()
		_stopWatch.Reset()
	End Sub

	''' <summary>
	''' ストップウォッチを開始
	''' </summary>
	''' <remarks></remarks>
	Public Sub StartStopWatch()
		If _stopWatch.IsRunning Then
			_stopWatch.Stop()
		End If

		'ResetStopWatch()
		_stopWatch.Start()
	End Sub

	''' <summary>
	''' ウォッチタイマーの時間を取得
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function GetWatchTimerMicroSec() As Long
		_stopWatch.Stop()

		'Return _stopWatch.ElapsedTicks
		Return CLng(_stopWatch.Elapsed.TotalMilliseconds * 1000.0)
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
		'compareList.Add(modDefine.CompareTypeIndex.StringVsStringBuilder.GetHashCode.ToString("D2") & " " & modDefine.COMPTYPE_STRING_STRINGBUILDER)
		For i As Integer = 1 To modDefine.CompareTypeIndex.Num - 1
			If _compareDic.ContainsKey(i) Then
				compareList.Add(Format(i, "00") & " " & _compareDic.Item(i))
			End If
		Next

		Return compareList
	End Function

	''' <summary>
	''' 
	''' </summary>
	''' <param name="dicKey"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function GetCompareName(ByVal dicKey As Integer) As String
		If _compareDic.ContainsKey(dicKey) Then
			Return _compareDic.Item(dicKey)
		Else
			Return "比較名称取得エラー"
		End If
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
			modMain.ResetStopWatch()
			modMain.StartStopWatch()
			For loopCnt As Long = 1& To settingInfo.LoopNum
				stringStr &= "a"
			Next
			resultInfo.AddResultA(modMain.GetWatchTimerMicroSec())
			'#If DEBUG Then
			'			MessageBox.Show(modMain.GetWatchTimer(True))
			'#End If

			stringBuildStr = New StringBuilder
			modMain.ResetStopWatch()
			modMain.StartStopWatch()
			For loopCnt As Long = 1& To settingInfo.LoopNum
				stringBuildStr.Append("a")
			Next
			resultInfo.AddResultB(modMain.GetWatchTimerMicroSec())
			'#If DEBUG Then
			'			MessageBox.Show(modMain.GetWatchTimer(True))
			'#End If

			'modMain.ResetStopWatch()
			stringStr = String.Empty
			stringBuildStr.Clear()
		Next

		Return resultInfo
	End Function


#End Region

End Module

Imports System.Diagnostics
Imports System.Text
Imports System.IO

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
			.Add(modDefine.CompareTypeIndex.StringEmptyVsLength.GetHashCode, modDefine.COMPNAME_STREMPTY_LENGTH)
			.Add(modDefine.CompareTypeIndex.StrCompVsStringEqualsVerEmpty.GetHashCode, modDefine.COMPNAME_STRINGCOMP_STRINGEQUAL_EMPTY)
			.Add(modDefine.CompareTypeIndex.StrCompVsStringEquals.GetHashCode, modDefine.COMPNAME_STRINGCOMP_STRINGEQUAL)
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
	''' 渡されたグリッドの内容をCSVで保存
	''' </summary>
	''' <param name="grdTarget"></param>
	''' <remarks></remarks>
	Public Sub SaveCsvFromGrid(ByVal grdTarget As DataGridView)
		Dim willSave As Boolean = False
		Dim savePath As String = String.Empty
		Dim saveString As String = String.Empty

		Using saveFileWindow As New SaveFileDialog
			saveFileWindow.Title = "保存するCSVファイルを選択"
			saveFileWindow.Filter = "カンマ区切りファイル|*.csv"
			saveFileWindow.FilterIndex = 0

			Select Case saveFileWindow.ShowDialog()
				Case DialogResult.OK
					willSave = True
					savePath = saveFileWindow.FileName
			End Select
		End Using

		If willSave Then
			Using writer As New StreamWriter(savePath, False, System.Text.Encoding.GetEncoding("shift_jis"))
				writer.Write(GetGridString(grdTarget))
			End Using
		End If
	End Sub

	''' <summary>
	''' グリッドの中身の文字列を取得
	''' </summary>
	''' <param name="gridTarget"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function GetGridString(ByVal gridTarget As DataGridView) As String
		Dim gridString As StringBuilder = Nothing
		gridString = New StringBuilder

		' タイトル情報
		For col As Integer = 0 To gridTarget.Columns.Count - 1
			gridString.Append(gridTarget.Columns(col).HeaderText & ",")
		Next
		gridString.AppendLine(String.Empty)

		' データ情報
		For row As Integer = 0 To gridTarget.Rows.Count - 1
			For col As Integer = 0 To gridTarget.Columns.Count - 1
				gridString.Append(gridTarget.Rows(row).Cells(col).Value.ToString & ",")
			Next
			gridString.AppendLine(String.Empty)
		Next

		Return gridString.ToString
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

			Case modDefine.CompareTypeIndex.StringBuilderVsStringBuilderCapacity
				resultInfo = StringBuilderVsStringBuilderCapacity(settingInfo)

			Case modDefine.CompareTypeIndex.StringEmptyVsLength
				resultInfo = StringEmptyVsLength(settingInfo)

			Case modDefine.CompareTypeIndex.StrCompVsStringEqualsVerEmpty
				resultInfo = StrCompVsStringEqualsVerEmpty(settingInfo)

			Case modDefine.CompareTypeIndex.StrCompVsStringEquals
				resultInfo = StrCompVsStringEquals(settingInfo)

		End Select

		If Not resultInfo Is Nothing Then
			resultInfo.CompareName = settingInfo.CompareName
		Else
			resultInfo = New clsResult
		End If

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

	''' <summary>
	''' StringBuilderと容量指定のStringBuilderを比較
	''' </summary>
	''' <param name="settingInfo"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function StringBuilderVsStringBuilderCapacity(ByVal settingInfo As clsSetting) As clsResult
		Dim resultInfo As clsResult = Nothing
		Dim normalSB As StringBuilder = Nothing
		Dim capaedSB As StringBuilder = Nothing

		resultInfo = New clsResult

		For testNum As Integer = 1 To settingInfo.TestNum
			normalSB = New StringBuilder
			capaedSB = New StringBuilder

			normalSB.Capacity = 16
			modMain.ResetStopWatch()
			modMain.StartStopWatch()

			For loopCnt As Long = 1& To settingInfo.LoopNum
				normalSB.Append("a")
			Next
			resultInfo.AddResultA(modMain.GetWatchTimerMicroSec())

			capaedSB.Capacity = CInt(settingInfo.LoopNum)
			modMain.ResetStopWatch()
			modMain.StartStopWatch()

			For loopCnt As Long = 1& To settingInfo.LoopNum
				capaedSB.Append("a")
			Next
			resultInfo.AddResultB(modMain.GetWatchTimerMicroSec())

			normalSB = Nothing
			capaedSB = Nothing
		Next

		Return resultInfo
	End Function

	''' <summary>
	''' 空文字比較と文字列長の速度比較
	''' </summary>
	''' <param name="settingInfo"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function StringEmptyVsLength(ByVal settingInfo As clsSetting) As clsResult
		Dim resultInfo As clsResult = Nothing
		Dim EmptyString As String = String.Empty

		resultInfo = New clsResult

		For testNum As Integer = 1 To settingInfo.TestNum

			modMain.ResetStopWatch()
			modMain.StartStopWatch()
			For loopNum As Long = 1& To settingInfo.LoopNum

			Next
#If DEBUG Then
			MessageBox.Show("単純ループ所要時間：" & modMain.GetWatchTimerMicroSec().ToString)
#End If

			modMain.ResetStopWatch()
			modMain.StartStopWatch()
			For loopNum As Long = 1& To settingInfo.LoopNum
				If EmptyString = String.Empty Then

				End If
			Next
			resultInfo.AddResultA(modMain.GetWatchTimerMicroSec())

			modMain.ResetStopWatch()
			modMain.StartStopWatch()
			For loopNum As Long = 1& To settingInfo.LoopNum
				If EmptyString.Length = 0 Then

				End If
			Next
			resultInfo.AddResultB(modMain.GetWatchTimerMicroSec())
		Next

		Return resultInfo
	End Function

	''' <summary>
	''' 文字比較と文字列一致の速度比較
	''' </summary>
	''' <param name="settingInfo"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function StrCompVsStringEqualsVerEmpty(ByVal settingInfo As clsSetting) As clsResult
		Dim resultInfo As clsResult = Nothing
		Dim EmptyString As String = String.Empty

		resultInfo = New clsResult

		For testNum As Integer = 1 To settingInfo.TestNum

			modMain.ResetStopWatch()
			modMain.StartStopWatch()
			For loopNum As Long = 1& To settingInfo.LoopNum
				If StrComp(EmptyString, String.Empty) = 0 Then

				End If
			Next
			resultInfo.AddResultA(modMain.GetWatchTimerMicroSec())

			modMain.ResetStopWatch()
			modMain.StartStopWatch()
			For loopNum As Long = 1& To settingInfo.LoopNum
				If EmptyString.Equals(String.Empty) Then

				End If
			Next
			resultInfo.AddResultB(modMain.GetWatchTimerMicroSec())
		Next

		Return resultInfo
	End Function

	''' <summary>
	''' 文字比較と文字列一致の速度比較
	''' </summary>
	''' <param name="settingInfo"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function StrCompVsStringEquals(ByVal settingInfo As clsSetting) As clsResult
		Dim resultInfo As clsResult = Nothing
		Dim EmptyString As String = "abcd"

		resultInfo = New clsResult

		For testNum As Integer = 1 To settingInfo.TestNum

			modMain.ResetStopWatch()
			modMain.StartStopWatch()
			For loopNum As Long = 1& To settingInfo.LoopNum
				If StrComp(EmptyString, "abcd") = 0 Then

				End If
			Next
			resultInfo.AddResultA(modMain.GetWatchTimerMicroSec())

			modMain.ResetStopWatch()
			modMain.StartStopWatch()
			For loopNum As Long = 1& To settingInfo.LoopNum
				If EmptyString.Equals("abcd") Then

				End If
			Next
			resultInfo.AddResultB(modMain.GetWatchTimerMicroSec())
		Next

		Return resultInfo
	End Function


#End Region

End Module

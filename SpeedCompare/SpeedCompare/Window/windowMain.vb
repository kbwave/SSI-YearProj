''' <summary>
''' 速度比較画面
''' </summary>
''' <remarks></remarks>
Public Class windowMain

#Region "Property"

#End Region

#Region "Event"

	''' <summary>
	''' インスタンス
	''' </summary>
	''' <remarks></remarks>
	Public Sub New()
		' この呼び出しはデザイナーで必要です。
		InitializeComponent()

		' InitializeComponent() 呼び出しの後で初期化を追加します。
		Preparation()
	End Sub

	''' <summary>
	''' ボタンクリック
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btn_Click(sender As Object, e As EventArgs) Handles btnTesting.Click, btnSave.Click, btnClear.Click
		If sender.Equals(Me.btnTesting) Then
			' 試行開始ボタン
			StartTesting()

		ElseIf sender.Equals(Me.btnSave) Then
			' CSV保存ボタン
			modMain.SaveCsvFromGrid(Me.grdResult)

		ElseIf sender.Equals(Me.btnClear) Then
			' クリアボタン
			InitGrid()

		End If
	End Sub

	''' <summary>
	''' 比較種類コンボ選択Index変更時
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub cbxCompareType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCompareType.SelectedIndexChanged

	End Sub

#End Region

#Region "Function"

	''' <summary>
	''' 準備
	''' </summary>
	''' <remarks></remarks>
	Private Sub Preparation()
		InitCotrols()

	End Sub

	''' <summary>
	''' コントロールを初期化
	''' </summary>
	''' <remarks></remarks>
	Private Sub InitCotrols()
		' 比較の種類コンボボックス
		InitComboBox()

		' 比較結果のグリッド
		InitGrid()

	End Sub

	''' <summary>
	''' コンボボックスを初期化
	''' </summary>
	''' <remarks></remarks>
	Private Sub InitComboBox()
		' 比較の種類コンボボックス
		With Me.cbxCompareType
			.Items.Clear()

			For Each compareItem As String In modMain.GetCompareTypeList
				.Items.Add(compareItem)
			Next

			' デフォはString V.S. StringBuilderで
			.SelectedIndex = modDefine.CompareTypeIndex.StringVsStringBuilder.GetHashCode - 1
		End With
	End Sub

	''' <summary>
	''' グリッドを初期化
	''' </summary>
	''' <remarks></remarks>
	Private Sub InitGrid()
		' 比較結果のグリッド
		With Me.grdResult
			.RowHeadersVisible = False
			.AllowUserToAddRows = False

			.Rows.Clear()
			.ColumnCount = modDefine.grdResultCol.Num

			.Columns(modDefine.grdResultCol.TypeName).HeaderText = modDefine.GRID_RESULT_TITLE_TYPENAME
			.Columns(modDefine.grdResultCol.LoopNum).HeaderText = modDefine.GRID_RESULT_TITLE_LOOPNUM
			.Columns(modDefine.grdResultCol.TestNum).HeaderText = modDefine.GRID_RESULT_TITLE_TESTNUM
			.Columns(modDefine.grdResultCol.ResultA).HeaderText = modDefine.GRID_RESULT_TITLE_RESULTA
			.Columns(modDefine.grdResultCol.ResultB).HeaderText = modDefine.GRID_RESULT_TITLE_RESULTB
		End With
	End Sub

	''' <summary>
	''' 設定情報を作成
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function MakeSettingInfo() As clsSetting
		Dim settingInfo As clsSetting = Nothing
		settingInfo = New clsSetting

		With settingInfo
			.LoopNum = CInt(Me.numLoop.Value)
			.CompareType = Me.cbxCompareType.SelectedIndex + 1
			.CompareName = modMain.GetCompareName(.CompareType)
			.TestNum = CInt(Me.numTesting.Value)
		End With

		Return settingInfo
	End Function

	''' <summary>
	''' 試行開始してグリッドに結果を表示
	''' </summary>
	''' <remarks></remarks>
	Private Sub StartTesting()
		Dim resultInfo As clsResult = Nothing
		resultInfo = modMain.StartTesting(Me.MakeSettingInfo)

		AppendResult(resultInfo)
	End Sub

	''' <summary>
	''' 結果をグリッドへ追加
	''' </summary>
	''' <param name="resultInfo"></param>
	''' <remarks></remarks>
	Private Sub AppendResult(ByVal resultInfo As clsResult)
		Dim addedRowIndex As Integer = 0

		If Not Me.chkTestAlsoClear.Checked Then
			InitGrid()
		End If

		With Me.grdResult
			addedRowIndex = .Rows.Add()

			.Rows(addedRowIndex).Cells(modDefine.grdResultCol.TypeName).ValueType = GetType(String)
			.Rows(addedRowIndex).Cells(modDefine.grdResultCol.TypeName).Value = resultInfo.CompareName

			.Rows(addedRowIndex).Cells(modDefine.grdResultCol.LoopNum).ValueType = GetType(String)
			.Rows(addedRowIndex).Cells(modDefine.grdResultCol.LoopNum).Value = Me.numLoop.Value.ToString
			.Rows(addedRowIndex).Cells(modDefine.grdResultCol.TestNum).ValueType = GetType(String)
			.Rows(addedRowIndex).Cells(modDefine.grdResultCol.TestNum).Value = Me.numTesting.Value.ToString

			.Rows(addedRowIndex).Cells(modDefine.grdResultCol.ResultA).ValueType = GetType(String)
			.Rows(addedRowIndex).Cells(modDefine.grdResultCol.ResultA).Value = resultInfo.GetAverageA
			.Rows(addedRowIndex).Cells(modDefine.grdResultCol.ResultB).ValueType = GetType(String)
			.Rows(addedRowIndex).Cells(modDefine.grdResultCol.ResultB).Value = resultInfo.GetAverageB
		End With
	End Sub

	
#End Region

End Class

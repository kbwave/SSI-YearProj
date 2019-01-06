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
	Private Sub btn_Click(sender As Object, e As EventArgs) Handles btnTesting.Click, btnSave.Click
		If sender.Equals(Me.btnTesting) Then
			Dim resultInfo As clsResult = Nothing
			resultInfo = modMain.StartTesting(Me.MakeSettingInfo)

		ElseIf sender.Equals(Me.btnSave) Then


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

		'比較の種類コンボボックス
		With Me.cbxCompareType
			.Items.Clear()

			For Each compareItem As String In modMain.GetCompareTypeList
				.Items.Add(compareItem)
			Next

			'デフォはString V.S. StringBuilderで
			.SelectedIndex = modDefine.CompareTypeIndex.StringVsStringBuilder.GetHashCode - 1
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
			.TestNum = CInt(Me.numTesting.Value)
		End With

		Return settingInfo
	End Function

	''' <summary>
	''' 結果をグリッドへ追加
	''' </summary>
	''' <param name="resultInfo"></param>
	''' <remarks></remarks>
	Private Sub AppendResult(ByVal resultInfo As clsResult)

	End Sub

#End Region

End Class

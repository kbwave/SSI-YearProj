Public Class windowMain

#Region "Interface"

#End Region

#Region "Valiable"



#End Region

#Region "Const"

	Private Const CONNECT_STATE_TEXT As String = "接続状態："

#End Region

#Region "Event"

	''' <summary>
	''' 
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub windowMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		SetUp()
	End Sub

	''' <summary>
	''' データ取得ボタンクリック
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub btnDataGet_Click(sender As Object, e As EventArgs) Handles btnDataGet.Click
		GetTestData()
	End Sub

#End Region

#Region "Function"


	''' <summary>
	''' 使用準備
	''' </summary>
	''' <remarks></remarks>
	Private Sub SetUp()
		Me.btnDataGet.Enabled = False

		SetUpSQLConnectionState()

		SetTableName()
	End Sub

	''' <summary>
	''' DB接続状態を更新
	''' </summary>
	''' <remarks></remarks>
	Private Sub SetUpSQLConnectionState()
		If modMain.ConnectingDB Then
			Me.lblSuccessConect.Text = CONNECT_STATE_TEXT & "接続中"

			Me.btnDataGet.Enabled = True
		Else
			Me.lblSuccessConect.Text = CONNECT_STATE_TEXT & "切断中"
		End If
	End Sub

	''' <summary>
	''' テーブル名をセット
	''' </summary>
	''' <remarks></remarks>
	Private Sub SetTableName()
		Me.cmbTable.BeginUpdate()

		For Each tableName As String In modMain.TableName
			Me.cmbTable.Items.Add(tableName)
		Next

		If Me.cmbTable.Items.Count >= 1 Then
			Me.cmbTable.SelectedIndex = 0
		End If

		Me.cmbTable.EndUpdate()
	End Sub

	Private Sub GetTestData()
		Using test As New firstDBpersonTable
			If modMain.ConnectingDB Then
				test.DataGetOneRecoad(modMain.Connection, CInt(Me.numNo.Value))

				MessageBox.Show(test.ToString)
			End If
		End Using


	End Sub


#End Region

End Class

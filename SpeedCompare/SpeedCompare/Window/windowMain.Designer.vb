<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class windowMain
	Inherits System.Windows.Forms.Form

	'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Windows フォーム デザイナーで必要です。
	Private components As System.ComponentModel.IContainer

	'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
	'Windows フォーム デザイナーを使用して変更できます。  
	'コード エディターを使って変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.numLoop = New System.Windows.Forms.NumericUpDown()
		Me.lblLoop = New System.Windows.Forms.Label()
		Me.cbxCompareType = New System.Windows.Forms.ComboBox()
		Me.lblCompType = New System.Windows.Forms.Label()
		Me.grdResult = New System.Windows.Forms.DataGridView()
		Me.numTesting = New System.Windows.Forms.NumericUpDown()
		Me.lblTesting = New System.Windows.Forms.Label()
		Me.btnTesting = New System.Windows.Forms.Button()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.lblCompareA = New System.Windows.Forms.Label()
		Me.chkTestAlsoClear = New System.Windows.Forms.CheckBox()
		Me.btnClear = New System.Windows.Forms.Button()
		Me.chkShowDetailWindw = New System.Windows.Forms.CheckBox()
		CType(Me.numLoop, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.grdResult, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.numTesting, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'numLoop
		'
		Me.numLoop.Location = New System.Drawing.Point(118, 7)
		Me.numLoop.Maximum = New Decimal(New Integer() {-1, 0, 0, 0})
		Me.numLoop.Name = "numLoop"
		Me.numLoop.Size = New System.Drawing.Size(79, 25)
		Me.numLoop.TabIndex = 0
		Me.numLoop.Value = New Decimal(New Integer() {10000, 0, 0, 0})
		'
		'lblLoop
		'
		Me.lblLoop.AutoSize = True
		Me.lblLoop.Location = New System.Drawing.Point(12, 9)
		Me.lblLoop.Name = "lblLoop"
		Me.lblLoop.Size = New System.Drawing.Size(80, 18)
		Me.lblLoop.TabIndex = 1
		Me.lblLoop.Text = "繰り返し回数"
		'
		'cbxCompareType
		'
		Me.cbxCompareType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbxCompareType.FormattingEnabled = True
		Me.cbxCompareType.Location = New System.Drawing.Point(118, 38)
		Me.cbxCompareType.Name = "cbxCompareType"
		Me.cbxCompareType.Size = New System.Drawing.Size(251, 26)
		Me.cbxCompareType.TabIndex = 2
		'
		'lblCompType
		'
		Me.lblCompType.AutoSize = True
		Me.lblCompType.Location = New System.Drawing.Point(12, 41)
		Me.lblCompType.Name = "lblCompType"
		Me.lblCompType.Size = New System.Drawing.Size(80, 18)
		Me.lblCompType.TabIndex = 3
		Me.lblCompType.Text = "比較する種類"
		'
		'grdResult
		'
		Me.grdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdResult.Location = New System.Drawing.Point(3, 167)
		Me.grdResult.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
		Me.grdResult.Name = "grdResult"
		Me.grdResult.RowTemplate.Height = 21
		Me.grdResult.Size = New System.Drawing.Size(375, 183)
		Me.grdResult.TabIndex = 4
		'
		'numTesting
		'
		Me.numTesting.Location = New System.Drawing.Point(118, 70)
		Me.numTesting.Name = "numTesting"
		Me.numTesting.Size = New System.Drawing.Size(79, 25)
		Me.numTesting.TabIndex = 5
		Me.numTesting.Value = New Decimal(New Integer() {10, 0, 0, 0})
		'
		'lblTesting
		'
		Me.lblTesting.AutoSize = True
		Me.lblTesting.Location = New System.Drawing.Point(12, 72)
		Me.lblTesting.Name = "lblTesting"
		Me.lblTesting.Size = New System.Drawing.Size(56, 18)
		Me.lblTesting.TabIndex = 6
		Me.lblTesting.Text = "試行回数"
		'
		'btnTesting
		'
		Me.btnTesting.Location = New System.Drawing.Point(228, 112)
		Me.btnTesting.Name = "btnTesting"
		Me.btnTesting.Size = New System.Drawing.Size(150, 28)
		Me.btnTesting.TabIndex = 7
		Me.btnTesting.Text = "試行開始(&T)"
		Me.btnTesting.UseVisualStyleBackColor = True
		'
		'btnSave
		'
		Me.btnSave.Location = New System.Drawing.Point(253, 356)
		Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(116, 27)
		Me.btnSave.TabIndex = 8
		Me.btnSave.Text = "結果を保存(&S)"
		Me.btnSave.UseVisualStyleBackColor = True
		'
		'lblCompareA
		'
		Me.lblCompareA.AutoSize = True
		Me.lblCompareA.Location = New System.Drawing.Point(9, 143)
		Me.lblCompareA.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
		Me.lblCompareA.Name = "lblCompareA"
		Me.lblCompareA.Size = New System.Drawing.Size(56, 18)
		Me.lblCompareA.TabIndex = 10
		Me.lblCompareA.Text = "比較結果"
		'
		'chkTestAlsoClear
		'
		Me.chkTestAlsoClear.AutoSize = True
		Me.chkTestAlsoClear.Checked = True
		Me.chkTestAlsoClear.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkTestAlsoClear.Location = New System.Drawing.Point(6, 116)
		Me.chkTestAlsoClear.Name = "chkTestAlsoClear"
		Me.chkTestAlsoClear.Size = New System.Drawing.Size(111, 22)
		Me.chkTestAlsoClear.TabIndex = 11
		Me.chkTestAlsoClear.Text = "グリッドに追加"
		Me.chkTestAlsoClear.UseVisualStyleBackColor = True
		'
		'btnClear
		'
		Me.btnClear.Location = New System.Drawing.Point(3, 358)
		Me.btnClear.Name = "btnClear"
		Me.btnClear.Size = New System.Drawing.Size(89, 23)
		Me.btnClear.TabIndex = 12
		Me.btnClear.Text = "クリア(&C)"
		Me.btnClear.UseVisualStyleBackColor = True
		'
		'chkShowDetailWindw
		'
		Me.chkShowDetailWindw.AutoSize = True
		Me.chkShowDetailWindw.Location = New System.Drawing.Point(123, 116)
		Me.chkShowDetailWindw.Name = "chkShowDetailWindw"
		Me.chkShowDetailWindw.Size = New System.Drawing.Size(99, 22)
		Me.chkShowDetailWindw.TabIndex = 13
		Me.chkShowDetailWindw.Text = "詳細画面表示"
		Me.chkShowDetailWindw.UseVisualStyleBackColor = True
		'
		'windowMain
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(382, 390)
		Me.Controls.Add(Me.chkShowDetailWindw)
		Me.Controls.Add(Me.btnClear)
		Me.Controls.Add(Me.chkTestAlsoClear)
		Me.Controls.Add(Me.lblCompareA)
		Me.Controls.Add(Me.btnSave)
		Me.Controls.Add(Me.btnTesting)
		Me.Controls.Add(Me.lblTesting)
		Me.Controls.Add(Me.numTesting)
		Me.Controls.Add(Me.grdResult)
		Me.Controls.Add(Me.lblCompType)
		Me.Controls.Add(Me.cbxCompareType)
		Me.Controls.Add(Me.lblLoop)
		Me.Controls.Add(Me.numLoop)
		Me.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "windowMain"
		CType(Me.numLoop, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.grdResult, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.numTesting, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents numLoop As System.Windows.Forms.NumericUpDown
	Friend WithEvents lblLoop As System.Windows.Forms.Label
	Friend WithEvents cbxCompareType As System.Windows.Forms.ComboBox
	Friend WithEvents lblCompType As System.Windows.Forms.Label
	Friend WithEvents grdResult As System.Windows.Forms.DataGridView
	Friend WithEvents numTesting As System.Windows.Forms.NumericUpDown
	Friend WithEvents lblTesting As System.Windows.Forms.Label
	Friend WithEvents btnTesting As System.Windows.Forms.Button
	Friend WithEvents btnSave As System.Windows.Forms.Button
	Friend WithEvents lblCompareA As System.Windows.Forms.Label
	Friend WithEvents chkTestAlsoClear As System.Windows.Forms.CheckBox
	Friend WithEvents btnClear As System.Windows.Forms.Button
	Friend WithEvents chkShowDetailWindw As System.Windows.Forms.CheckBox

End Class

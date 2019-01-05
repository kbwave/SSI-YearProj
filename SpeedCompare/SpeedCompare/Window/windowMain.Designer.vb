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
		Me.ComboBox1 = New System.Windows.Forms.ComboBox()
		Me.lblCompType = New System.Windows.Forms.Label()
		CType(Me.numLoop, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'numLoop
		'
		Me.numLoop.Location = New System.Drawing.Point(86, 7)
		Me.numLoop.Maximum = New Decimal(New Integer() {65536, 0, 0, 0})
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
		Me.lblLoop.Size = New System.Drawing.Size(68, 18)
		Me.lblLoop.TabIndex = 1
		Me.lblLoop.Text = "繰り返し数"
		'
		'ComboBox1
		'
		Me.ComboBox1.FormattingEnabled = True
		Me.ComboBox1.Location = New System.Drawing.Point(86, 38)
		Me.ComboBox1.Name = "ComboBox1"
		Me.ComboBox1.Size = New System.Drawing.Size(225, 26)
		Me.ComboBox1.TabIndex = 2
		'
		'lblCompType
		'
		Me.lblCompType.AutoSize = True
		Me.lblCompType.Location = New System.Drawing.Point(12, 41)
		Me.lblCompType.Name = "lblCompType"
		Me.lblCompType.Size = New System.Drawing.Size(56, 18)
		Me.lblCompType.TabIndex = 3
		Me.lblCompType.Text = "比較種類"
		'
		'windowMain
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.ClientSize = New System.Drawing.Size(513, 384)
		Me.Controls.Add(Me.lblCompType)
		Me.Controls.Add(Me.ComboBox1)
		Me.Controls.Add(Me.lblLoop)
		Me.Controls.Add(Me.numLoop)
		Me.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "windowMain"
		Me.Text = "Form1"
		CType(Me.numLoop, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents numLoop As System.Windows.Forms.NumericUpDown
	Friend WithEvents lblLoop As System.Windows.Forms.Label
	Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
	Friend WithEvents lblCompType As System.Windows.Forms.Label

End Class

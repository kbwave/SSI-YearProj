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
		Me.grdDBData = New System.Windows.Forms.DataGridView()
		Me.btnDataGet = New System.Windows.Forms.Button()
		Me.lblSuccessConect = New System.Windows.Forms.Label()
		Me.numNo = New System.Windows.Forms.NumericUpDown()
		Me.cmbTable = New System.Windows.Forms.ComboBox()
		CType(Me.grdDBData, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.numNo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'grdDBData
		'
		Me.grdDBData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdDBData.Location = New System.Drawing.Point(12, 108)
		Me.grdDBData.Name = "grdDBData"
		Me.grdDBData.RowTemplate.Height = 21
		Me.grdDBData.Size = New System.Drawing.Size(373, 230)
		Me.grdDBData.TabIndex = 0
		'
		'btnDataGet
		'
		Me.btnDataGet.Location = New System.Drawing.Point(12, 76)
		Me.btnDataGet.Name = "btnDataGet"
		Me.btnDataGet.Size = New System.Drawing.Size(373, 26)
		Me.btnDataGet.TabIndex = 1
		Me.btnDataGet.Text = "データ取得"
		Me.btnDataGet.UseVisualStyleBackColor = True
		'
		'lblSuccessConect
		'
		Me.lblSuccessConect.AutoSize = True
		Me.lblSuccessConect.Location = New System.Drawing.Point(10, 9)
		Me.lblSuccessConect.Name = "lblSuccessConect"
		Me.lblSuccessConect.Size = New System.Drawing.Size(53, 12)
		Me.lblSuccessConect.TabIndex = 2
		Me.lblSuccessConect.Text = "接続状況"
		'
		'numNo
		'
		Me.numNo.Location = New System.Drawing.Point(12, 51)
		Me.numNo.Name = "numNo"
		Me.numNo.Size = New System.Drawing.Size(75, 19)
		Me.numNo.TabIndex = 3
		'
		'cmbTable
		'
		Me.cmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbTable.FormattingEnabled = True
		Me.cmbTable.Location = New System.Drawing.Point(12, 25)
		Me.cmbTable.Name = "cmbTable"
		Me.cmbTable.Size = New System.Drawing.Size(211, 20)
		Me.cmbTable.TabIndex = 4
		'
		'windowMain
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(397, 350)
		Me.Controls.Add(Me.cmbTable)
		Me.Controls.Add(Me.numNo)
		Me.Controls.Add(Me.lblSuccessConect)
		Me.Controls.Add(Me.btnDataGet)
		Me.Controls.Add(Me.grdDBData)
		Me.Name = "windowMain"
		Me.Text = "テストDB接続マン"
		CType(Me.grdDBData, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.numNo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents grdDBData As System.Windows.Forms.DataGridView
	Friend WithEvents btnDataGet As System.Windows.Forms.Button
	Friend WithEvents lblSuccessConect As System.Windows.Forms.Label
	Friend WithEvents numNo As System.Windows.Forms.NumericUpDown
	Friend WithEvents cmbTable As System.Windows.Forms.ComboBox

End Class

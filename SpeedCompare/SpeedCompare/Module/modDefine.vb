''' <summary>
''' 定義モジュール
''' </summary>
''' <remarks></remarks>
Module modDefine

#Region "Data"



#End Region

#Region "Const"

	' 比較の種類に関して
	Public Const COMPTYPE_STRING_STRINGBUILDER As String = "String V.S. StringBuilder"
	Public Const COMPNAME_STRING_STRINGBUILDER As String = "文字列VS文字列組み立て(Normal)"
	Public Const COMPTYPE_STRINGBUILDER_CAPACITY As String = "StringBuilder Capacity"
	Public Const COMPNAME_STRINGBUILDER_CAPACITY As String = "文字列組み立て(容量指定)"

	Public Const NO_DATA_TEXT As String = "0：結果なし"

	' 結果グリッドの列のタイトル名称
	Public Const GRID_RESULT_TITLE_TYPENAME As String = "比較種類"
	Public Const GRID_RESULT_TITLE_LOOPNUM As String = "反復回数"
	Public Const GRID_RESULT_TITLE_TESTNUM As String = "試行回数"
	Public Const GRID_RESULT_TITLE_RESULTA As String = "結果A"
	Public Const GRID_RESULT_TITLE_RESULTB As String = "結果B"

#End Region

#Region "Enumerate"

	''' <summary>
	''' 比較の種類
	''' </summary>
	''' <remarks>
	''' 1月：String V.S. StringBuilder
	''' </remarks>
	Public Enum CompareTypeIndex As Integer
		None = 0
		StringVsStringBuilder
		StringBuilderVsStringBuilderCapacity

		Num
	End Enum

	''' <summary>
	''' 比較結果グリッドの列Index
	''' </summary>
	''' <remarks></remarks>
	Public Enum grdResultCol As Integer
		None = -1
		TypeName
		LoopNum
		TestNum
		ResultA
		ResultB

		Num
	End Enum


#End Region

End Module

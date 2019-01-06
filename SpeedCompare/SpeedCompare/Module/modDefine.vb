''' <summary>
''' 定義モジュール
''' </summary>
''' <remarks></remarks>
Module modDefine

#Region "Const"

	Public Const COMPTYPE_STRING_STRINGBUILDER As String = "String V.S. StringBuilder"

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

		Num
	End Enum


#End Region

End Module

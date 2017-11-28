Module MyUtil

    '------------------------------------------------------------------------
    '　　分秒単位の走破タイムを秒数単位の走破タイムに変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		IJyoCD			= 分秒単位の走破タイム
    '	[戻り値]
    '		String			= 秒数に変換した走破タイム
    '------------------------------------------------------------------------
    Public Function TimeConversionFromMMSStoMM(ByVal Time As String) As String
        '走破タイム
        Dim souhaTime As Single = Time.Substring(1, 3) / 10
        If "1".Equals(Time.Substring(0, 1)) Then
            souhaTime += 60
        ElseIf "2".Equals(Time.Substring(0, 1)) Then
            souhaTime += 120
        ElseIf "3".Equals(Time.Substring(0, 1)) Then
            souhaTime += 180
        ElseIf "4".Equals(Time.Substring(0, 1)) Then
            souhaTime += 240
        ElseIf "5".Equals(Time.Substring(0, 1)) Then
            souhaTime += 300
        ElseIf "6".Equals(Time.Substring(0, 1)) Then
            souhaTime += 360
        End If
        Return souhaTime
    End Function

    '------------------------------------------------------------------------
    '　　組み合わせを計算する
    '------------------------------------------------------------------------
    '　 [引数]
    '		number			= 数
    '	[戻り値]
    '		Integer			= 組み合わせ
    '------------------------------------------------------------------------
    Public Function CalcCombination(ByVal number As Integer) As Integer
        Dim combination As Integer = 0
        If number > 0 Then
            combination = number * (number - 1) / 2
        End If
        Return combination
    End Function

    '------------------------------------------------------------------------
    '　　カンマ付き金額に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		kingaku			= 金額
    '	[戻り値]
    '		String			= カンマ付き金額
    '------------------------------------------------------------------------
    Public Function CommaSeparated(ByVal kingaku As Integer) As String
        Dim kingakuStr As String = kingaku.ToString
        Dim len As Integer = kingakuStr.Length
        Dim amari As Integer = len Mod 3
        Dim syou As Integer = Math.Floor(len / 3)
        Dim CommaSeparatedKingaku As New System.Text.StringBuilder()
        For i = 0 To syou
            If i = 0 AndAlso amari <> 0 Then
                CommaSeparatedKingaku.Append(kingakuStr.Substring(0, amari))
                CommaSeparatedKingaku.Append(",")
            ElseIf i = 0 AndAlso amari = 0 Then
            Else
                CommaSeparatedKingaku.Append(kingakuStr.Substring(amari + ((i - 1) * 3), 3))
                CommaSeparatedKingaku.Append(",")
            End If
        Next
        If amari = 0 AndAlso syou = 0 Then
            Return CommaSeparatedKingaku.ToString
        ElseIf amari = 0 AndAlso syou <> 0 Then
            Return CommaSeparatedKingaku.ToString.Substring(0, len + syou - 1)
        Else
            Return CommaSeparatedKingaku.ToString.Substring(0, len + syou)
        End If

    End Function

End Module

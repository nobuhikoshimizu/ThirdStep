Module CodeConversion

    '------------------------------------------------------------------------
    '　　異常区分コードを異常区分名に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		IJyoCD			= 異常区分コード
    '	[戻り値]
    '		String			= 異常区分名
    '------------------------------------------------------------------------
    Public Function IJyoCodeConversion(ByVal IJyoCD As String) As String
        Dim Ijyo As String = ""
        If "1".Equals(IJyoCD) Then
            Ijyo = "出走取消"
        ElseIf "2".Equals(IJyoCD) Then
            Ijyo = "発走除外"
        ElseIf "3".Equals(IJyoCD) Then
            Ijyo = "競走除外"
        ElseIf "4".Equals(IJyoCD) Then
            Ijyo = "競走中止"
        ElseIf "5".Equals(IJyoCD) Then
            Ijyo = "失格"
        ElseIf "6".Equals(IJyoCD) Then
            Ijyo = "落馬再騎乗"
        ElseIf "7".Equals(IJyoCD) Then
            Ijyo = "降着"
        End If
        Return Ijyo
    End Function

    '------------------------------------------------------------------------
    '　　脚質判定コードを脚質判定名に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		KyakusituCD		= 脚質判定コード
    '	[戻り値]
    '		String			= 脚質判定名
    '------------------------------------------------------------------------
    Public Function KyakusituCodeConversion(ByVal KyakusituCD As String) As String
        Dim Kyakusitu As String = ""
        If "1".Equals(KyakusituCD) Then
            Kyakusitu = "逃"
        ElseIf "2".Equals(KyakusituCD) Then
            Kyakusitu = "先"
        ElseIf "3".Equals(KyakusituCD) Then
            Kyakusitu = "差"
        ElseIf "4".Equals(KyakusituCD) Then
            Kyakusitu = "追"
        End If
        Return Kyakusitu
    End Function

    '------------------------------------------------------------------------
    '　　競馬場コードを競馬場名に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		JyoCD			= 競馬場コード
    '	[戻り値]
    '		String			= 競馬場名
    '------------------------------------------------------------------------
    Public Function KeibaJyoCodeConversion(ByVal JyoCD As String) As String
        Dim KeibaJyo As String = ""
        If "00".Equals(JyoCD) Then
            KeibaJyo = ""
        ElseIf "01".Equals(JyoCD) Then
            KeibaJyo = "札幌"
        ElseIf "02".Equals(JyoCD) Then
            KeibaJyo = "函館"
        ElseIf "03".Equals(JyoCD) Then
            KeibaJyo = "福島"
        ElseIf "04".Equals(JyoCD) Then
            KeibaJyo = "新潟"
        ElseIf "05".Equals(JyoCD) Then
            KeibaJyo = "東京"
        ElseIf "06".Equals(JyoCD) Then
            KeibaJyo = "中山"
        ElseIf "07".Equals(JyoCD) Then
            KeibaJyo = "中京"
        ElseIf "08".Equals(JyoCD) Then
            KeibaJyo = "京都"
        ElseIf "09".Equals(JyoCD) Then
            KeibaJyo = "阪神"
        ElseIf "10".Equals(JyoCD) Then
            KeibaJyo = "小倉"
        Else
            KeibaJyo = "その他"
        End If
        Return KeibaJyo
    End Function

    '------------------------------------------------------------------------
    '　　競馬場名を競馬場コードに変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		KeibaJyo			= 競馬場名
    '	[戻り値]
    '		String			= 競馬場コード
    '------------------------------------------------------------------------
    Public Function KeibaJyoConversion(ByVal KeibaJyo As String) As String
        Dim JyoCd As String = ""
        If "札幌".Equals(KeibaJyo) Then
            JyoCd = "01"
        ElseIf "函館".Equals(KeibaJyo) Then
            JyoCd = "02"
        ElseIf "福島".Equals(KeibaJyo) Then
            JyoCd = "03"
        ElseIf "新潟".Equals(KeibaJyo) Then
            JyoCd = "04"
        ElseIf "東京".Equals(KeibaJyo) Then
            JyoCd = "05"
        ElseIf "中山".Equals(KeibaJyo) Then
            JyoCd = "06"
        ElseIf "中京".Equals(KeibaJyo) Then
            JyoCd = "07"
        ElseIf "京都".Equals(KeibaJyo) Then
            JyoCd = "08"
        ElseIf "阪神".Equals(KeibaJyo) Then
            JyoCd = "09"
        ElseIf "小倉".Equals(KeibaJyo) Then
            JyoCd = "10"
        End If
        Return JyoCd
    End Function

    '------------------------------------------------------------------------
    '　　競走種別コードを競走種別名に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		SyubetuCD		= 競走種別コード
    '	[戻り値]
    '		String			= 競走種別名
    '------------------------------------------------------------------------
    Public Function KyosouSyubetuCodeConversion(ByVal SyubetuCD As String) As String
        Dim KyosouSyubetsu As String = ""
        If "00".Equals(SyubetuCD) Then
            KyosouSyubetsu = ""
        ElseIf "11".Equals(SyubetuCD) Then
            KyosouSyubetsu = "サラ系２歳"
        ElseIf "12".Equals(SyubetuCD) Then
            KyosouSyubetsu = "サラ系３歳"
        ElseIf "13".Equals(SyubetuCD) Then
            KyosouSyubetsu = "サラ系３歳以上"
        ElseIf "14".Equals(SyubetuCD) Then
            KyosouSyubetsu = "サラ系４歳以上"
        ElseIf "18".Equals(SyubetuCD) Then
            KyosouSyubetsu = "サラ障害３歳以上"
        ElseIf "19".Equals(SyubetuCD) Then
            KyosouSyubetsu = "サラ障害４歳以上"
        ElseIf "21".Equals(SyubetuCD) Then
            KyosouSyubetsu = "アラブ系２歳"
        ElseIf "22".Equals(SyubetuCD) Then
            KyosouSyubetsu = "アラブ系３歳"
        ElseIf "23".Equals(SyubetuCD) Then
            KyosouSyubetsu = "アラブ系３歳以上"
        ElseIf "24".Equals(SyubetuCD) Then
            KyosouSyubetsu = "アラブ系４歳以上"
        End If
        Return KyosouSyubetsu
    End Function

    '------------------------------------------------------------------------
    '　　競走記号コードを競走記号名に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		KigoCD			= 競走記号コード
    '	[戻り値]
    '		String			= 競走記号名
    '------------------------------------------------------------------------
    Public Function KyosouKigouCodeConversion(ByVal KigoCD As String) As String
        Dim KyosouKigou As String = ""
        If "000".Equals(KigoCD) Then
            KyosouKigou = ""
        ElseIf "001".Equals(KigoCD) Then
            KyosouKigou = "(指定)"
        ElseIf "002".Equals(KigoCD) Then
            KyosouKigou = "若手騎手"
        ElseIf "003".Equals(KigoCD) Then
            KyosouKigou = "[指定]"
        ElseIf "004".Equals(KigoCD) Then
            KyosouKigou = "(特指)"
        ElseIf "020".Equals(KigoCD) Then
            KyosouKigou = "牝"
        ElseIf "021".Equals(KigoCD) Then
            KyosouKigou = "牝(指定)"
        ElseIf "023".Equals(KigoCD) Then
            KyosouKigou = "牝[指定]"
        ElseIf "024".Equals(KigoCD) Then
            KyosouKigou = "牝(特指)"
        ElseIf "030".Equals(KigoCD) Then
            KyosouKigou = "牡・ｾﾝ"
        ElseIf "031".Equals(KigoCD) Then
            KyosouKigou = "牡・ｾﾝ(指定)"
        ElseIf "033".Equals(KigoCD) Then
            KyosouKigou = "牡・ｾﾝ[指定]"
        ElseIf "034".Equals(KigoCD) Then
            KyosouKigou = "牡・ｾﾝ(特指)"
        ElseIf "040".Equals(KigoCD) Then
            KyosouKigou = "牡・牝"
        ElseIf "041".Equals(KigoCD) Then
            KyosouKigou = "牡・牝(指定)"
        ElseIf "043".Equals(KigoCD) Then
            KyosouKigou = "牡・牝[指定]"
        ElseIf "044".Equals(KigoCD) Then
            KyosouKigou = "牡・牝(特指)"
        ElseIf "A00".Equals(KigoCD) Then
            KyosouKigou = "(混合)"
        ElseIf "A01".Equals(KigoCD) Then
            KyosouKigou = "(混合)(指定)"
        ElseIf "A02".Equals(KigoCD) Then
            KyosouKigou = "(混合)若手騎手"
        ElseIf "A03".Equals(KigoCD) Then
            KyosouKigou = "(混合)[指定]"
        ElseIf "A04".Equals(KigoCD) Then
            KyosouKigou = "(混合)(特指)"
        ElseIf "A10".Equals(KigoCD) Then
            KyosouKigou = "(混合)牡"
        ElseIf "A11".Equals(KigoCD) Then
            KyosouKigou = "(混合)牡(指定)"
        ElseIf "A13".Equals(KigoCD) Then
            KyosouKigou = "(混合)牡[指定]"
        ElseIf "A14".Equals(KigoCD) Then
            KyosouKigou = "(混合)牡(特指)"
        ElseIf "A20".Equals(KigoCD) Then
            KyosouKigou = "(混合)牝"
        ElseIf "A21".Equals(KigoCD) Then
            KyosouKigou = "(混合)牝(指定)"
        ElseIf "A23".Equals(KigoCD) Then
            KyosouKigou = "(混合)牝[指定]"
        ElseIf "A24".Equals(KigoCD) Then
            KyosouKigou = "(混合)牝(特指)"
        ElseIf "A30".Equals(KigoCD) Then
            KyosouKigou = "(混合)牡・ｾﾝ"
        ElseIf "A31".Equals(KigoCD) Then
            KyosouKigou = "(混合)牡・ｾﾝ(指定)"
        ElseIf "A33".Equals(KigoCD) Then
            KyosouKigou = "(混合)牡・ｾﾝ[指定]"
        ElseIf "A34".Equals(KigoCD) Then
            KyosouKigou = "(混合)牡・ｾﾝ(特指)"
        ElseIf "A40".Equals(KigoCD) Then
            KyosouKigou = "(混合)牡・牝"
        ElseIf "A41".Equals(KigoCD) Then
            KyosouKigou = "(混合)牡・牝(指定)"
        ElseIf "B00".Equals(KigoCD) Then
            KyosouKigou = "(父)"
        ElseIf "B01".Equals(KigoCD) Then
            KyosouKigou = "(父)(指定)"
        ElseIf "B03".Equals(KigoCD) Then
            KyosouKigou = "(父)[指定]"
        ElseIf "B04".Equals(KigoCD) Then
            KyosouKigou = "(父)(特指)"
        ElseIf "C00".Equals(KigoCD) Then
            KyosouKigou = "(市)"
        ElseIf "C01".Equals(KigoCD) Then
            KyosouKigou = "(市)(指定)"
        ElseIf "C03".Equals(KigoCD) Then
            KyosouKigou = "(市)[指定]"
        ElseIf "C04".Equals(KigoCD) Then
            KyosouKigou = "(市)(特指)"
        ElseIf "D00".Equals(KigoCD) Then
            KyosouKigou = "(抽)"
        ElseIf "D01".Equals(KigoCD) Then
            KyosouKigou = "(抽)(指定)"
        ElseIf "D03".Equals(KigoCD) Then
            KyosouKigou = "(抽)[指定]"
        ElseIf "E00".Equals(KigoCD) Then
            KyosouKigou = "[抽]"
        ElseIf "E01".Equals(KigoCD) Then
            KyosouKigou = "[抽](指定)"
        ElseIf "E03".Equals(KigoCD) Then
            KyosouKigou = "[抽][指定]"
        ElseIf "F00".Equals(KigoCD) Then
            KyosouKigou = "(市)(抽)"
        ElseIf "F01".Equals(KigoCD) Then
            KyosouKigou = "(市)(抽)(指定)"
        ElseIf "F03".Equals(KigoCD) Then
            KyosouKigou = "(市)(抽)[指定]"
        ElseIf "F04".Equals(KigoCD) Then
            KyosouKigou = "(市)(抽)(特指)"
        ElseIf "G00".Equals(KigoCD) Then
            KyosouKigou = "(抽)関西配布馬"
        ElseIf "G01".Equals(KigoCD) Then
            KyosouKigou = "(抽)関西配布馬(指定)"
        ElseIf "G03".Equals(KigoCD) Then
            KyosouKigou = "(抽)関西配布馬[指定]"
        ElseIf "H00".Equals(KigoCD) Then
            KyosouKigou = "(抽)関東配布馬"
        ElseIf "H01".Equals(KigoCD) Then
            KyosouKigou = "(抽)関東配布馬(指定)"
        ElseIf "I00".Equals(KigoCD) Then
            KyosouKigou = "[抽]関西配布馬"
        ElseIf "I01".Equals(KigoCD) Then
            KyosouKigou = "[抽]関西配布馬(指定)"
        ElseIf "I03".Equals(KigoCD) Then
            KyosouKigou = "[抽]関西配布馬[指定]"
        ElseIf "J00".Equals(KigoCD) Then
            KyosouKigou = "[抽]関東配布馬"
        ElseIf "J01".Equals(KigoCD) Then
            KyosouKigou = "[抽]関東配布馬(指定)"
        ElseIf "K00".Equals(KigoCD) Then
            KyosouKigou = "(市)(抽)関西配布馬"
        ElseIf "K01".Equals(KigoCD) Then
            KyosouKigou = "(市)(抽)関西配布馬(指定)"
        ElseIf "K03".Equals(KigoCD) Then
            KyosouKigou = "(市)(抽)関西配布馬[指定]"
        ElseIf "L00".Equals(KigoCD) Then
            KyosouKigou = "(市)(抽)関東配布馬"
        ElseIf "L01".Equals(KigoCD) Then
            KyosouKigou = "(市)(抽)関東配布馬(指定)"
        ElseIf "L03".Equals(KigoCD) Then
            KyosouKigou = "(市)(抽)関東配布馬[指定]"
        ElseIf "M00".Equals(KigoCD) Then
            KyosouKigou = "九州産馬"
        ElseIf "M01".Equals(KigoCD) Then
            KyosouKigou = "九州産馬(指定)"
        ElseIf "M03".Equals(KigoCD) Then
            KyosouKigou = "九州産馬[指定]"
        ElseIf "M04".Equals(KigoCD) Then
            KyosouKigou = "九州産馬(特指)"
        ElseIf "N00".Equals(KigoCD) Then
            KyosouKigou = "(国際)"
        ElseIf "N01".Equals(KigoCD) Then
            KyosouKigou = "(国際)(指定)"
        ElseIf "N03".Equals(KigoCD) Then
            KyosouKigou = "(国際)[指定]"
        ElseIf "N04".Equals(KigoCD) Then
            KyosouKigou = "(国際)(特指)"
        ElseIf "N20".Equals(KigoCD) Then
            KyosouKigou = "(国際)牝"
        ElseIf "N21".Equals(KigoCD) Then
            KyosouKigou = "(国際)牝(指定)"
        ElseIf "N23".Equals(KigoCD) Then
            KyosouKigou = "(国際)牝[指定]"
        ElseIf "N24".Equals(KigoCD) Then
            KyosouKigou = "(国際)牝(特指)"
        ElseIf "N30".Equals(KigoCD) Then
            KyosouKigou = "(国際)牡・ｾﾝ"
        ElseIf "N31".Equals(KigoCD) Then
            KyosouKigou = "(国際)牡・ｾﾝ(指定)"
        ElseIf "N40".Equals(KigoCD) Then
            KyosouKigou = "(国際)牡・牝"
        ElseIf "N41".Equals(KigoCD) Then
            KyosouKigou = "(国際)牡・牝(指定)"
        ElseIf "N44".Equals(KigoCD) Then
            KyosouKigou = "(国際)牡・牝(特指)"
        End If
        Return KyosouKigou
    End Function

    '------------------------------------------------------------------------
    '　　競走条件コード 2歳条件 3歳条件 4歳条件 5歳以上条件 最若年条件から
    '    競走条件コードを絞り込む
    '------------------------------------------------------------------------
    '　 [引数]
    '		JyokenCD		= 競走条件コード
    '	[戻り値]
    '		String			= 絞り込んだ競走条件コード
    '------------------------------------------------------------------------
    Public Function SelectKyosouJyoukenCode(ByVal JyokenCD As String()) As String
        Dim KyosouJyoukenCD As String = ""
        For i As Integer = 0 To JyokenCD.Length - 1
            If "000".Equals(JyokenCD(i)) Then
            Else
                KyosouJyoukenCD = JyokenCD(i)
            End If
        Next
        Return KyosouJyoukenCD
    End Function

    '------------------------------------------------------------------------
    '　　競走条件コードを競走条件名に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		JyokenCD		= 競走条件コード
    '	[戻り値]
    '		String			= 競走条件名
    '------------------------------------------------------------------------
    Public Function KyosouJyoukenCodeConversion(ByVal JyokenCD As String) As String
        Dim KyosouJyouken As String = ""
        If "001".Equals(JyokenCD) Then
            KyosouJyouken = "１００万円以下"
        ElseIf "002".Equals(JyokenCD) Then
            KyosouJyouken = "２００万円以下"
        ElseIf "003".Equals(JyokenCD) Then
            KyosouJyouken = "３００万円以下"
        ElseIf "004".Equals(JyokenCD) Then
            KyosouJyouken = "４００万円以下"
        ElseIf "005".Equals(JyokenCD) Then
            KyosouJyouken = "５００万円以下"
        ElseIf "006".Equals(JyokenCD) Then
            KyosouJyouken = "６００万円以下"
        ElseIf "007".Equals(JyokenCD) Then
            KyosouJyouken = "７００万円以下"
        ElseIf "008".Equals(JyokenCD) Then
            KyosouJyouken = "８００万円以下"
        ElseIf "009".Equals(JyokenCD) Then
            KyosouJyouken = "９００万円以下"
        ElseIf "010".Equals(JyokenCD) Then
            KyosouJyouken = "１０００万円以下"
        ElseIf "011".Equals(JyokenCD) Then
            KyosouJyouken = "１１００万円以下"
        ElseIf "012".Equals(JyokenCD) Then
            KyosouJyouken = "１２００万円以下"
        ElseIf "013".Equals(JyokenCD) Then
            KyosouJyouken = "１３００万円以下"
        ElseIf "014".Equals(JyokenCD) Then
            KyosouJyouken = "１４００万円以下"
        ElseIf "015".Equals(JyokenCD) Then
            KyosouJyouken = "１５００万円以下"
        ElseIf "016".Equals(JyokenCD) Then
            KyosouJyouken = "１６００万円以下"
        ElseIf "017".Equals(JyokenCD) Then
            KyosouJyouken = "１７００万円以下"
        ElseIf "018".Equals(JyokenCD) Then
            KyosouJyouken = "１８００万円以下"
        ElseIf "019".Equals(JyokenCD) Then
            KyosouJyouken = "１９００万円以下"
        ElseIf "020".Equals(JyokenCD) Then
            KyosouJyouken = "２０００万円以下"
        ElseIf "701".Equals(JyokenCD) Then
            KyosouJyouken = "新馬"
        ElseIf "702".Equals(JyokenCD) Then
            KyosouJyouken = "未出走"
        ElseIf "703".Equals(JyokenCD) Then
            KyosouJyouken = "未勝利"
        ElseIf "999".Equals(JyokenCD) Then
            KyosouJyouken = "オープン"
        End If
        Return KyosouJyouken
    End Function

    '------------------------------------------------------------------------
    '　　重量種別コードを重量種別名に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		JyuryoCD		= 重量種別コード
    '	[戻り値]
    '		String			= 重量種別名
    '------------------------------------------------------------------------
    Public Function JyuryoSyubetuCodeConversion(ByVal JyuryoCD As String) As String
        Dim Jyuryo As String = ""
        If "0".Equals(JyuryoCD) Then
            Jyuryo = ""
        ElseIf "1".Equals(JyuryoCD) Then
            Jyuryo = "ハンデ"
        ElseIf "2".Equals(JyuryoCD) Then
            Jyuryo = "別定"
        ElseIf "3".Equals(JyuryoCD) Then
            Jyuryo = "馬齢"
        ElseIf "4".Equals(JyuryoCD) Then
            Jyuryo = "定量"
        End If
        Return Jyuryo
    End Function

    '------------------------------------------------------------------------
    '　　グレードコードを重量種別名に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		GradeCD		    = グレードコード
    '	[戻り値]
    '		String			= グレード名
    '------------------------------------------------------------------------
    Public Function GradeCodeConversion(ByVal GradeCD As String) As String
        Dim Grade As String = ""
        If "A".Equals(GradeCD) Then
            Grade = "G1"
        ElseIf "B".Equals(GradeCD) Then
            Grade = "G2"
        ElseIf "C".Equals(GradeCD) Then
            Grade = "G3"
        ElseIf "F".Equals(GradeCD) Then
            Grade = "J･G1"
        ElseIf "G".Equals(GradeCD) Then
            Grade = "J･G2"
        ElseIf "H".Equals(GradeCD) Then
            Grade = "J･G3"
        End If
        Return Grade
    End Function


    '------------------------------------------------------------------------
    '　　トラックコードを重量種別名に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		TrackCD		    = トラックコード
    '	[戻り値]
    '		String			= トラック名
    '------------------------------------------------------------------------
    Public Function TrackCodeConversion(ByVal TrackCD As String) As String
        Dim Track As String = ""
        If "00".Equals(TrackCD) Then
            Track = ""
        ElseIf "10".Equals(TrackCD) Then
            Track = "平地芝直線"
        ElseIf "11".Equals(TrackCD) Then
            Track = "平地芝左回り"
        ElseIf "12".Equals(TrackCD) Then
            Track = "平地芝左回り外回り"
        ElseIf "13".Equals(TrackCD) Then
            Track = "平地芝左回り内－外回り"
        ElseIf "14".Equals(TrackCD) Then
            Track = "平地芝左回り外－内回り"
        ElseIf "15".Equals(TrackCD) Then
            Track = "平地芝左回り内２周"
        ElseIf "16".Equals(TrackCD) Then
            Track = "平地芝左回り外２周"
        ElseIf "17".Equals(TrackCD) Then
            Track = "平地芝右回り"
        ElseIf "18".Equals(TrackCD) Then
            Track = "平地芝右回り外回り"
        ElseIf "19".Equals(TrackCD) Then
            Track = "平地芝右回り内－外回り"
        ElseIf "20".Equals(TrackCD) Then
            Track = "平地芝右回り外－内回り"
        ElseIf "21".Equals(TrackCD) Then
            Track = "平地芝右回り内２周"
        ElseIf "22".Equals(TrackCD) Then
            Track = "平地芝右回り外２周"
        ElseIf "23".Equals(TrackCD) Then
            Track = "平地ダート左回り"
        ElseIf "24".Equals(TrackCD) Then
            Track = "平地ダート右回り"
        ElseIf "25".Equals(TrackCD) Then
            Track = "平地ダート左回り内回り"
        ElseIf "26".Equals(TrackCD) Then
            Track = "平地ダート右回り外回り"
        ElseIf "27".Equals(TrackCD) Then
            Track = "平地サンド左回り"
        ElseIf "28".Equals(TrackCD) Then
            Track = "平地サンド右回り"
        ElseIf "29".Equals(TrackCD) Then
            Track = "平地ダート直線"
        ElseIf "51".Equals(TrackCD) Then
            Track = "障害芝襷"
        ElseIf "52".Equals(TrackCD) Then
            Track = "障害芝ダート"
        ElseIf "53".Equals(TrackCD) Then
            Track = "障害芝・左"
        ElseIf "54".Equals(TrackCD) Then
            Track = "障害芝"
        ElseIf "55".Equals(TrackCD) Then
            Track = "障害芝外回り"
        ElseIf "56".Equals(TrackCD) Then
            Track = "障害芝外－内回り"
        ElseIf "57".Equals(TrackCD) Then
            Track = "障害芝内－外回り"
        ElseIf "58".Equals(TrackCD) Then
            Track = "障害芝内２周以上"
        ElseIf "59".Equals(TrackCD) Then
            Track = "障害芝外２周以上"
        End If
        Return Track
    End Function

    '------------------------------------------------------------------------
    '　　天候コードを馬場状態名に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		TenkoCD		    = 天候コード
    '	[戻り値]
    '		String			= 天候名
    '------------------------------------------------------------------------
    Public Function TenkoCodeConversion(ByVal TenkoCD As String) As String
        Dim Tenko As String = ""
        If "0".Equals(TenkoCD) Then
            Tenko = ""
        ElseIf "1".Equals(TenkoCD) Then
            Tenko = "晴"
        ElseIf "2".Equals(TenkoCD) Then
            Tenko = "曇"
        ElseIf "3".Equals(TenkoCD) Then
            Tenko = "雨"
        ElseIf "4".Equals(TenkoCD) Then
            Tenko = "小雨"
        ElseIf "5".Equals(TenkoCD) Then
            Tenko = "雪"
        ElseIf "6".Equals(TenkoCD) Then
            Tenko = "小雪"
        End If
        Return Tenko
    End Function

    '------------------------------------------------------------------------
    '　　馬場状態コードを馬場状態名に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		BabaCD		    = 馬場状態コード
    '	[戻り値]
    '		String			= 馬場状態名
    '------------------------------------------------------------------------
    Public Function BabaCodeConversion(ByVal BabaCD As String) As String
        Dim Baba As String = ""
        If "1".Equals(BabaCD) Then
            Baba = "良"
        ElseIf "2".Equals(BabaCD) Then
            Baba = "稍重"
        ElseIf "3".Equals(BabaCD) Then
            Baba = "重"
        ElseIf "4".Equals(BabaCD) Then
            Baba = "不良"
        End If
        Return Baba
    End Function

    '------------------------------------------------------------------------
    '　　性別コードを性別に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		SexCD			= 性別コード
    '	[戻り値]
    '		String			= 性別
    '------------------------------------------------------------------------
    Public Function SexCodeConversion(ByVal SexCD As String) As String
        Dim Sex As String = ""
        If "0".Equals(SexCD) Then
            Sex = ""
        ElseIf "1".Equals(SexCD) Then
            Sex = "牡馬"
        ElseIf "2".Equals(SexCD) Then
            Sex = "牝馬"
        ElseIf "3".Equals(SexCD) Then
            Sex = "セン"
        End If
        Return Sex
    End Function

    '------------------------------------------------------------------------
    '　　品種コードを品種名に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		HinsyuCD			= 品種コード
    '	[戻り値]
    '		String			= 品種名
    '------------------------------------------------------------------------
    Public Function HinsyuCodeConversion(ByVal HinsyuCD As String) As String
        Dim Hinsyu As String = ""
        If "0".Equals(HinsyuCD) Then
            Hinsyu = ""
        ElseIf "1".Equals(HinsyuCD) Then
            Hinsyu = "サラ"
        ElseIf "2".Equals(HinsyuCD) Then
            Hinsyu = "サラ系"
        ElseIf "3".Equals(HinsyuCD) Then
            Hinsyu = "準サラ"
        ElseIf "4".Equals(HinsyuCD) Then
            Hinsyu = "軽半"
        ElseIf "5".Equals(HinsyuCD) Then
            Hinsyu = "アア"
        ElseIf "6".Equals(HinsyuCD) Then
            Hinsyu = "アラ系"
        ElseIf "7".Equals(HinsyuCD) Then
            Hinsyu = "アラブ"
        ElseIf "8".Equals(HinsyuCD) Then
            Hinsyu = "中半"
        End If
        Return Hinsyu
    End Function


    '------------------------------------------------------------------------
    '　　品種コードを品種名に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		HinsyuCD			= 品種コード
    '	[戻り値]
    '		String			= 品種名
    '------------------------------------------------------------------------
    Public Function KeiroCodeConversion(ByVal KeiroCD As String) As String
        Dim Keiro As String = ""
        If "00".Equals(KeiroCD) Then
            Keiro = ""
        ElseIf "01".Equals(KeiroCD) Then
            Keiro = "栗毛"
        ElseIf "02".Equals(KeiroCD) Then
            Keiro = "栃栗毛"
        ElseIf "03".Equals(KeiroCD) Then
            Keiro = "鹿毛"
        ElseIf "04".Equals(KeiroCD) Then
            Keiro = "黒鹿毛"
        ElseIf "05".Equals(KeiroCD) Then
            Keiro = "青鹿毛"
        ElseIf "06".Equals(KeiroCD) Then
            Keiro = "青毛"
        ElseIf "07".Equals(KeiroCD) Then
            Keiro = "芦毛"
        ElseIf "08".Equals(KeiroCD) Then
            Keiro = "栗粕毛"
        ElseIf "09".Equals(KeiroCD) Then
            Keiro = "鹿粕毛"
        ElseIf "10".Equals(KeiroCD) Then
            Keiro = "青粕毛"
        ElseIf "11".Equals(KeiroCD) Then
            Keiro = "白毛"
        End If
        Return Keiro
    End Function
    '------------------------------------------------------------------------
    '      競走馬抹消区分コードを競走馬抹消区分名に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		DelKubunCD	    = 競走馬抹消区分コード
    '	[戻り値]
    '		String			= 競走馬抹消区分名
    '------------------------------------------------------------------------
    Public Function DelKubunCodeConversion(ByVal DelKubunCD As String) As String
        Dim DelKubun As String = ""
        If "0".Equals(DelKubunCD) Then
            DelKubun = "現役"
        ElseIf "1".Equals(DelKubunCD) Then
            DelKubun = "抹消"
        End If
        Return DelKubun
    End Function

    '------------------------------------------------------------------------
    '　　馬記号コードを馬記号名に変換する
    '------------------------------------------------------------------------
    '　 [引数]
    '		HinsyuCD			= 馬記号コード
    '	[戻り値]
    '		String			= 馬記号名
    '------------------------------------------------------------------------
    Public Function UmaKigoCodeConversion(ByVal UmaKigoCD As String) As String
        Dim UmaKigo As String = ""
        If "00".Equals(UmaKigoCD) Then
            UmaKigo = ""
        ElseIf "01".Equals(UmaKigoCD) Then
            UmaKigo = "(抽)"
        ElseIf "02".Equals(UmaKigoCD) Then
            UmaKigo = "[抽]"
        ElseIf "03".Equals(UmaKigoCD) Then
            UmaKigo = "(父)"
        ElseIf "04".Equals(UmaKigoCD) Then
            UmaKigo = "(市)"
        ElseIf "05".Equals(UmaKigoCD) Then
            UmaKigo = "(地)"
        ElseIf "06".Equals(UmaKigoCD) Then
            UmaKigo = "(外)"
        ElseIf "07".Equals(UmaKigoCD) Then
            UmaKigo = "(父)(抽)"
        ElseIf "08".Equals(UmaKigoCD) Then
            UmaKigo = "(父)(市)"
        ElseIf "09".Equals(UmaKigoCD) Then
            UmaKigo = "(父)(地)"
        ElseIf "10".Equals(UmaKigoCD) Then
            UmaKigo = "(市)(地)"
        ElseIf "11".Equals(UmaKigoCD) Then
            UmaKigo = "(外)(地)"
        ElseIf "12".Equals(UmaKigoCD) Then
            UmaKigo = "(父)(市)(地)"
        ElseIf "15".Equals(UmaKigoCD) Then
            UmaKigo = "(招)"
        ElseIf "16".Equals(UmaKigoCD) Then
            UmaKigo = "(招)(外)"
        ElseIf "17".Equals(UmaKigoCD) Then
            UmaKigo = "(招)(父)"
        ElseIf "18".Equals(UmaKigoCD) Then
            UmaKigo = "(招)(市)"
        ElseIf "19".Equals(UmaKigoCD) Then
            UmaKigo = "(招)(父)(市)"
        ElseIf "20".Equals(UmaKigoCD) Then
            UmaKigo = "(父)(外)"
        ElseIf "21".Equals(UmaKigoCD) Then
            UmaKigo = "[地]"
        ElseIf "22".Equals(UmaKigoCD) Then
            UmaKigo = "(外)[地]"
        ElseIf "23".Equals(UmaKigoCD) Then
            UmaKigo = "(父)[地]"
        ElseIf "24".Equals(UmaKigoCD) Then
            UmaKigo = "(市)[地]"
        ElseIf "25".Equals(UmaKigoCD) Then
            UmaKigo = "(父)(市)[地]"
        ElseIf "26".Equals(UmaKigoCD) Then
            UmaKigo = "[外]"
        ElseIf "27".Equals(UmaKigoCD) Then
            UmaKigo = "(父)[外]"
        ElseIf "31".Equals(UmaKigoCD) Then
            UmaKigo = "(持)"
        ElseIf "40".Equals(UmaKigoCD) Then
            UmaKigo = "(父)(外)(地)"
        ElseIf "41".Equals(UmaKigoCD) Then
            UmaKigo = "(父)(外)[地]"
        End If
        Return UmaKigo
    End Function
End Module

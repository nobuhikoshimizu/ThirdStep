Module CreateSQL

    '------------------------------------------------------------------------
    '　　JV_RA_RACE レース詳細テーブルInsert文発行
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= レース詳細テーブルInsert文
    '------------------------------------------------------------------------
    Public Function CreateJvRaRaceInsert() As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("INSERT INTO jv_ra_race (")
        InsertQuery.Append(" race_id,")
        InsertQuery.Append(" year,")
        InsertQuery.Append(" month,")
        InsertQuery.Append(" day,")
        InsertQuery.Append(" keibajyo,")
        InsertQuery.Append(" race_no,")
        InsertQuery.Append(" syubetu_cd,")
        InsertQuery.Append(" kigo_cd,")
        InsertQuery.Append(" jyoken_cd,")
        InsertQuery.Append(" jyuryo_cd,")
        InsertQuery.Append(" grade_cd,")
        InsertQuery.Append(" hondai,")
        InsertQuery.Append(" kyori,")
        InsertQuery.Append(" track_cd,")
        InsertQuery.Append(" course_kubun,")
        InsertQuery.Append(" tenko_cd,")
        InsertQuery.Append(" baba_cd,")
        InsertQuery.Append(" syusso_tosu,")
        InsertQuery.Append(" hasso_jikoku,")
        InsertQuery.Append(" data_kubun,")
        InsertQuery.Append(" data_sakusei_day )")
        InsertQuery.Append(" VALUES(")
        InsertQuery.Append(" ?val1,")
        InsertQuery.Append(" ?val2,")
        InsertQuery.Append(" ?val3,")
        InsertQuery.Append(" ?val4,")
        InsertQuery.Append(" ?val5,")
        InsertQuery.Append(" ?val6,")
        InsertQuery.Append(" ?val7,")
        InsertQuery.Append(" ?val8,")
        InsertQuery.Append(" ?val9,")
        InsertQuery.Append(" ?val10,")
        InsertQuery.Append(" ?val11,")
        InsertQuery.Append(" ?val12,")
        InsertQuery.Append(" ?val13,")
        InsertQuery.Append(" ?val14,")
        InsertQuery.Append(" ?val15,")
        InsertQuery.Append(" ?val16,")
        InsertQuery.Append(" ?val17,")
        InsertQuery.Append(" ?val18,")
        InsertQuery.Append(" ?val19,")
        InsertQuery.Append(" ?val20,")
        InsertQuery.Append(" ?val21 )")

        Return InsertQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　JV_RA_RACE レース詳細テーブルUpdate文発行
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= レース詳細テーブルUpdate文
    '------------------------------------------------------------------------
    Public Function CreateJvRaRaceUpDate() As String

        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE jv_ra_race  ")
        UpdateQuery.Append("SET ")
        UpdateQuery.Append("  syubetu_cd = ?val1 ")
        UpdateQuery.Append("  , kigo_cd = ?val2 ")
        UpdateQuery.Append("  , jyoken_cd = ?val3 ")
        UpdateQuery.Append("  , jyuryo_cd = ?val4 ")
        UpdateQuery.Append("  , grade_cd = ?val5 ")
        UpdateQuery.Append("  , hondai = ?val6 ")
        UpdateQuery.Append("  , kyori = ?val7 ")
        UpdateQuery.Append("  , track_cd = ?val8 ")
        UpdateQuery.Append("  , course_kubun = ?val9 ")
        UpdateQuery.Append("  , tenko_cd = ?val10 ")
        UpdateQuery.Append("  , baba_cd = ?val11 ")
        UpdateQuery.Append("  , syusso_tosu = ?val12 ")
        UpdateQuery.Append("  , hasso_jikoku = ?val13 ")
        UpdateQuery.Append("  , data_kubun = ?val14  ")
        UpdateQuery.Append("  , data_sakusei_day = ?val15  ")
        UpdateQuery.Append("WHERE ")
        UpdateQuery.Append("  race_id = ?val16 ")

        Return UpdateQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　JV_RA_RACE レース詳細テーブルSelect文発行
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= レース詳細テーブルSelect文
    '------------------------------------------------------------------------
    Public Function CreateJvRaRaceSelect(ByVal key As String) As String

        Dim SelectQuery As New System.Text.StringBuilder()
        SelectQuery.Append("SELECT")
        SelectQuery.Append("  race_id")
        SelectQuery.Append("  , year")
        SelectQuery.Append("  , month")
        SelectQuery.Append("  , day")
        SelectQuery.Append("  , keibajyo")
        SelectQuery.Append("  , race_no")
        SelectQuery.Append("  , syubetu_cd")
        SelectQuery.Append("  , kigo_cd")
        SelectQuery.Append("  , jyoken_cd")
        SelectQuery.Append("  , jyuryo_cd")
        SelectQuery.Append("  , grade_cd")
        SelectQuery.Append("  , hondai")
        SelectQuery.Append("  , kyori")
        SelectQuery.Append("  , track_cd")
        SelectQuery.Append("  , course_kubun")
        SelectQuery.Append("  , tenko_cd")
        SelectQuery.Append("  , baba_cd")
        SelectQuery.Append("  , syusso_tosu")
        SelectQuery.Append("  , hasso_jikoku")
        SelectQuery.Append("  , data_kubun ")
        SelectQuery.Append("FROM")
        SelectQuery.Append("  jv_ra_race ")
        SelectQuery.Append("WHERE race_id LIKE '")
        SelectQuery.Append(key)
        SelectQuery.Append("%' ")
        SelectQuery.Append("ORDER BY")
        SelectQuery.Append("  race_id")

        Return SelectQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　JV_SE_RACE_UMA 馬毎レース情報テーブルInsert文発行
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 馬毎レース情報テーブルInsert文
    '------------------------------------------------------------------------
    Public Function CreateJvSeRaceUmaInsert() As String

        ' StringBuilder クラスの新しいインスタンスを生成する
        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("INSERT INTO jv_se_race_uma (")
        InsertQuery.Append(" id,")
        InsertQuery.Append(" race_id,")
        InsertQuery.Append(" ketto_num,")
        InsertQuery.Append(" bamei,")
        InsertQuery.Append(" futan,")
        InsertQuery.Append(" ba_taijyu,")
        InsertQuery.Append(" zougen,")
        InsertQuery.Append(" i_jyo,")
        InsertQuery.Append(" kyakusitu,")
        InsertQuery.Append(" jyuni_one_c,")
        InsertQuery.Append(" jyuni_two_c,")
        InsertQuery.Append(" jyuni_three_c,")
        InsertQuery.Append(" jyuni_four_c,")
        InsertQuery.Append(" kakutei_jyuni,")
        InsertQuery.Append(" ninki,")
        InsertQuery.Append(" dochaku_kubun,")
        InsertQuery.Append(" dochaku_tosu,")
        InsertQuery.Append(" souha_time,")
        InsertQuery.Append(" tansho_odds,")
        InsertQuery.Append(" haron_last,")
        InsertQuery.Append(" time_diff,")
        InsertQuery.Append(" data_kubun,")
        InsertQuery.Append(" data_sakusei_day )")
        InsertQuery.Append(" VALUES(")
        InsertQuery.Append(" ?val1,")
        InsertQuery.Append(" ?val2,")
        InsertQuery.Append(" ?val3,")
        InsertQuery.Append(" ?val4,")
        InsertQuery.Append(" ?val5,")
        InsertQuery.Append(" ?val6,")
        InsertQuery.Append(" ?val7,")
        InsertQuery.Append(" ?val8,")
        InsertQuery.Append(" ?val9,")
        InsertQuery.Append(" ?val10,")
        InsertQuery.Append(" ?val11,")
        InsertQuery.Append(" ?val12,")
        InsertQuery.Append(" ?val13,")
        InsertQuery.Append(" ?val14,")
        InsertQuery.Append(" ?val15,")
        InsertQuery.Append(" ?val16,")
        InsertQuery.Append(" ?val17,")
        InsertQuery.Append(" ?val18,")
        InsertQuery.Append(" ?val19,")
        InsertQuery.Append(" ?val20,")
        InsertQuery.Append(" ?val21,")
        InsertQuery.Append(" ?val22,")
        InsertQuery.Append(" ?val23 )")

        Return InsertQuery.ToString

    End Function


    '------------------------------------------------------------------------
    '　　JV_SE_RACE_UMA 馬毎レース情報テーブルUpdate文発行
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 馬毎レース情報テーブルUpdate文
    '------------------------------------------------------------------------
    Public Function CreateJvSeRaceUmaUpdate() As String

        ' StringBuilder クラスの新しいインスタンスを生成する
        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE jv_se_race_uma ")
        UpdateQuery.Append("SET ")
        UpdateQuery.Append("  futan = ?val1")
        UpdateQuery.Append("  , ba_taijyu = ?val2")
        UpdateQuery.Append("  , zougen = ?val3")
        UpdateQuery.Append("  , i_jyo = ?val4")
        UpdateQuery.Append("  , kyakusitu = ?val5")
        UpdateQuery.Append("  , jyuni_one_c = ?val6")
        UpdateQuery.Append("  , jyuni_two_c = ?val7")
        UpdateQuery.Append("  , jyuni_three_c = ?val8")
        UpdateQuery.Append("  , jyuni_four_c = ?val9")
        UpdateQuery.Append("  , kakutei_jyuni = ?val10")
        UpdateQuery.Append("  , ninki = ?val11")
        UpdateQuery.Append("  , dochaku_kubun = ?val12")
        UpdateQuery.Append("  , dochaku_tosu = ?val13")
        UpdateQuery.Append("  , souha_time = ?val14")
        UpdateQuery.Append("  , tansho_odds =?val15")
        UpdateQuery.Append("  , haron_last = ?val16")
        UpdateQuery.Append("  , time_diff = ?val17 ")
        UpdateQuery.Append("  , data_kubun = ?val18 ")
        UpdateQuery.Append("  , data_sakusei_day = ?val19 ")
        UpdateQuery.Append(" WHERE")
        UpdateQuery.Append("  id = ?val20")

        Return UpdateQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　JV_SE_RACE_UMA 馬毎レース情報テーブルSelect文発行
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 馬毎レース情報テーブルSelect文
    '------------------------------------------------------------------------
    Public Function CreateJvSeRaceUmaSelect(ByVal key As String) As String

        ' StringBuilder クラスの新しいインスタンスを生成する
        Dim SelectQuery As New System.Text.StringBuilder()
        SelectQuery.Append("SELECT ")
        SelectQuery.Append("  a.id id")
        SelectQuery.Append("  ,a.race_id race_id")
        SelectQuery.Append("  ,a.ketto_num ketto_num")
        SelectQuery.Append("  ,a.bamei bamei")
        SelectQuery.Append("  ,a.futan futan")
        SelectQuery.Append("  ,a.ba_taijyu ba_taijyu")
        SelectQuery.Append("  ,a.zougen zougen")
        SelectQuery.Append("  ,a.i_jyo i_jyo")
        SelectQuery.Append("  ,a.kyakusitu kyakusitu")
        SelectQuery.Append("  ,a.jyuni_one_c jyuni_one_c")
        SelectQuery.Append("  ,a.jyuni_two_c jyuni_two_c")
        SelectQuery.Append("  ,a.jyuni_three_c jyuni_three_c")
        SelectQuery.Append("  ,a.jyuni_four_c jyuni_four_c")
        SelectQuery.Append("  ,a.kakutei_jyuni kakutei_jyuni")
        SelectQuery.Append("  ,a.ninki ninki")
        SelectQuery.Append("  ,a.dochaku_kubun dochaku_kubun")
        SelectQuery.Append("  ,a.dochaku_tosu dochaku_tosu")
        SelectQuery.Append("  ,a.souha_time souha_time")
        SelectQuery.Append("  ,a.tansho_odds tansho_odds")
        SelectQuery.Append("  ,a.haron_last haron_last")
        SelectQuery.Append("  ,a.time_diff time_diff")
        SelectQuery.Append("  ,a.data_kubun data_kubun")
        SelectQuery.Append("  ,b.kakutei_jyuni_average kakutei_jyuni_average")
        SelectQuery.Append("  ,b.ninki_average ninki_average")
        SelectQuery.Append("  ,b.time_diff_average time_diff_average")
        SelectQuery.Append("  ,b.rank rank")
        SelectQuery.Append("  ,b.race_interval race_interval")
        SelectQuery.Append("  ,c.uma_kigo_cd uma_kigo_cd")
        SelectQuery.Append("  ,c.sex_cd sex_cd")
        SelectQuery.Append("  ,c.hinsyu_cd hinsyu_cd")
        SelectQuery.Append("  ,c.keiro_cd keiro_cd")
        SelectQuery.Append("  ,c.del_kubun del_kubun")
        SelectQuery.Append("  ,c.titi titi")
        SelectQuery.Append("  ,c.haha_titi haha_titi ")
        SelectQuery.Append("FROM")
        SelectQuery.Append("  jv_se_race_uma a ")
        SelectQuery.Append("LEFT JOIN")
        SelectQuery.Append("  tyakusa_ninki b ")
        SelectQuery.Append("ON a.id = b.id ")
        SelectQuery.Append("LEFT JOIN")
        SelectQuery.Append("  jv_um_uma c ")
        SelectQuery.Append("ON a.ketto_num = c.ketto_num ")
        SelectQuery.Append("WHERE a. race_id ='")
        SelectQuery.Append(key)
        SelectQuery.Append("' ORDER BY a.id")

        Return SelectQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　JV_HR_PAY 払戻テーブルInsert文発行
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 払戻テーブルInsert文
    '------------------------------------------------------------------------
    Public Function CreateJvHrPayInsert() As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("INSERT INTO jv_hr_pay (")
        InsertQuery.Append(" race_id,")
        InsertQuery.Append(" year,")
        InsertQuery.Append(" month,")
        InsertQuery.Append(" day,")
        InsertQuery.Append(" keibajyo,")
        InsertQuery.Append(" race_no,")
        InsertQuery.Append(" tansho_one_umaban,")
        InsertQuery.Append(" tansho_one_harai_modoshi,")
        InsertQuery.Append(" tansho_one_ninki,")
        InsertQuery.Append(" tansho_two_umaban,")
        InsertQuery.Append(" tansho_two_harai_modoshi,")
        InsertQuery.Append(" tansho_two_ninki,")
        InsertQuery.Append(" tansho_three_umaban,")
        InsertQuery.Append(" tansho_three_harai_modoshi,")
        InsertQuery.Append(" tansho_three_ninki,")
        InsertQuery.Append(" umaren_one_kumi,")
        InsertQuery.Append(" umaren_one_harai_modoshi,")
        InsertQuery.Append(" umaren_one_ninki,")
        InsertQuery.Append(" umaren_two_kumi,")
        InsertQuery.Append(" umaren_two_harai_modoshi,")
        InsertQuery.Append(" umaren_two_ninki,")
        InsertQuery.Append(" umaren_three_kumi,")
        InsertQuery.Append(" umaren_three_harai_modoshi,")
        InsertQuery.Append(" umaren_three_ninki,")
        InsertQuery.Append(" sanrenpuku_one_kumi,")
        InsertQuery.Append(" sanrenpuku_one_harai_modoshi,")
        InsertQuery.Append(" sanrenpuku_one_ninki,")
        InsertQuery.Append(" sanrenpuku_two_kumi,")
        InsertQuery.Append(" sanrenpuku_two_harai_modoshi,")
        InsertQuery.Append(" sanrenpuku_two_ninki,")
        InsertQuery.Append(" sanrenpuku_three_kumi,")
        InsertQuery.Append(" sanrenpuku_three_harai_modoshi,")
        InsertQuery.Append(" sanrenpuku_three_ninki,")
        InsertQuery.Append(" sanrentan_one_kumi,")
        InsertQuery.Append(" sanrentan_one_harai_modoshi,")
        InsertQuery.Append(" sanrentan_one_ninki,")
        InsertQuery.Append(" sanrentan_two_kumi,")
        InsertQuery.Append(" sanrentan_two_harai_modoshi,")
        InsertQuery.Append(" sanrentan_two_ninki,")
        InsertQuery.Append(" sanrentan_three_kumi,")
        InsertQuery.Append(" sanrentan_three_harai_modoshi,")
        InsertQuery.Append(" sanrentan_three_ninki,")
        InsertQuery.Append(" sanrentan_four_kumi,")
        InsertQuery.Append(" sanrentan_four_harai_modoshi,")
        InsertQuery.Append(" sanrentan_four_ninki,")
        InsertQuery.Append(" sanrentan_five_kumi,")
        InsertQuery.Append(" sanrentan_five_harai_modoshi,")
        InsertQuery.Append(" sanrentan_five_ninki,")
        InsertQuery.Append(" sanrentan_six_kumi,")
        InsertQuery.Append(" sanrentan_six_harai_modoshi,")
        InsertQuery.Append(" sanrentan_six_ninki,")
        InsertQuery.Append(" wide_one_kumi,")
        InsertQuery.Append(" wide_one_harai_modoshi,")
        InsertQuery.Append(" wide_one_ninki,")
        InsertQuery.Append(" wide_two_kumi,")
        InsertQuery.Append(" wide_two_harai_modoshi,")
        InsertQuery.Append(" wide_two_ninki,")
        InsertQuery.Append(" wide_three_kumi,")
        InsertQuery.Append(" wide_three_harai_modoshi,")
        InsertQuery.Append(" wide_three_ninki,")
        InsertQuery.Append(" wide_four_kumi,")
        InsertQuery.Append(" wide_four_harai_modoshi,")
        InsertQuery.Append(" wide_four_ninki,")
        InsertQuery.Append(" wide_five_kumi,")
        InsertQuery.Append(" wide_five_harai_modoshi,")
        InsertQuery.Append(" wide_five_ninki,")
        InsertQuery.Append(" wide_six_kumi,")
        InsertQuery.Append(" wide_six_harai_modoshi,")
        InsertQuery.Append(" wide_six_ninki,")
        InsertQuery.Append(" wide_seven_kumi,")
        InsertQuery.Append(" wide_seven_harai_modoshi,")
        InsertQuery.Append(" wide_seven_ninki,")
        InsertQuery.Append(" umatan_one_kumi,")
        InsertQuery.Append(" umatan_one_harai_modoshi,")
        InsertQuery.Append(" umatan_one_ninki,")
        InsertQuery.Append(" umatan_two_kumi,")
        InsertQuery.Append(" umatan_two_harai_modoshi,")
        InsertQuery.Append(" umatan_two_ninki,")
        InsertQuery.Append(" umatan_three_kumi,")
        InsertQuery.Append(" umatan_three_harai_modoshi,")
        InsertQuery.Append(" umatan_three_ninki,")
        InsertQuery.Append(" umatan_four_kumi,")
        InsertQuery.Append(" umatan_four_harai_modoshi,")
        InsertQuery.Append(" umatan_four_ninki,")
        InsertQuery.Append(" umatan_five_kumi,")
        InsertQuery.Append(" umatan_five_harai_modoshi,")
        InsertQuery.Append(" umatan_five_ninki,")
        InsertQuery.Append(" umatan_six_kumi,")
        InsertQuery.Append(" umatan_six_harai_modoshi,")
        InsertQuery.Append(" umatan_six_ninki,")
        InsertQuery.Append(" data_kubun,")
        InsertQuery.Append(" data_sakusei_day )")
        InsertQuery.Append(" VALUES(")
        InsertQuery.Append(" ?val1,")
        InsertQuery.Append(" ?val2,")
        InsertQuery.Append(" ?val3,")
        InsertQuery.Append(" ?val4,")
        InsertQuery.Append(" ?val5,")
        InsertQuery.Append(" ?val6,")
        InsertQuery.Append(" ?val7,")
        InsertQuery.Append(" ?val8,")
        InsertQuery.Append(" ?val9,")
        InsertQuery.Append(" ?val10,")
        InsertQuery.Append(" ?val11,")
        InsertQuery.Append(" ?val12,")
        InsertQuery.Append(" ?val13,")
        InsertQuery.Append(" ?val14,")
        InsertQuery.Append(" ?val15,")
        InsertQuery.Append(" ?val16,")
        InsertQuery.Append(" ?val17,")
        InsertQuery.Append(" ?val18,")
        InsertQuery.Append(" ?val19,")
        InsertQuery.Append(" ?val20,")
        InsertQuery.Append(" ?val21,")
        InsertQuery.Append(" ?val22,")
        InsertQuery.Append(" ?val23,")
        InsertQuery.Append(" ?val24,")
        InsertQuery.Append(" ?val25,")
        InsertQuery.Append(" ?val26,")
        InsertQuery.Append(" ?val27,")
        InsertQuery.Append(" ?val28,")
        InsertQuery.Append(" ?val29,")
        InsertQuery.Append(" ?val30,")
        InsertQuery.Append(" ?val31,")
        InsertQuery.Append(" ?val32,")
        InsertQuery.Append(" ?val33,")
        InsertQuery.Append(" ?val34,")
        InsertQuery.Append(" ?val35,")
        InsertQuery.Append(" ?val36,")
        InsertQuery.Append(" ?val37,")
        InsertQuery.Append(" ?val38,")
        InsertQuery.Append(" ?val39,")
        InsertQuery.Append(" ?val40,")
        InsertQuery.Append(" ?val41,")
        InsertQuery.Append(" ?val42,")
        InsertQuery.Append(" ?val43,")
        InsertQuery.Append(" ?val44,")
        InsertQuery.Append(" ?val45,")
        InsertQuery.Append(" ?val46,")
        InsertQuery.Append(" ?val47,")
        InsertQuery.Append(" ?val48,")
        InsertQuery.Append(" ?val49,")
        InsertQuery.Append(" ?val50,")
        InsertQuery.Append(" ?val51,")
        InsertQuery.Append(" ?val52,")
        InsertQuery.Append(" ?val53,")
        InsertQuery.Append(" ?val54,")
        InsertQuery.Append(" ?val55,")
        InsertQuery.Append(" ?val56,")
        InsertQuery.Append(" ?val57,")
        InsertQuery.Append(" ?val58,")
        InsertQuery.Append(" ?val59,")
        InsertQuery.Append(" ?val60,")
        InsertQuery.Append(" ?val61,")
        InsertQuery.Append(" ?val62,")
        InsertQuery.Append(" ?val63,")
        InsertQuery.Append(" ?val64,")
        InsertQuery.Append(" ?val65,")
        InsertQuery.Append(" ?val66,")
        InsertQuery.Append(" ?val67,")
        InsertQuery.Append(" ?val68,")
        InsertQuery.Append(" ?val69,")
        InsertQuery.Append(" ?val70,")
        InsertQuery.Append(" ?val71,")
        InsertQuery.Append(" ?val72,")
        InsertQuery.Append(" ?val73,")
        InsertQuery.Append(" ?val74,")
        InsertQuery.Append(" ?val75,")
        InsertQuery.Append(" ?val76,")
        InsertQuery.Append(" ?val77,")
        InsertQuery.Append(" ?val78,")
        InsertQuery.Append(" ?val79,")
        InsertQuery.Append(" ?val80,")
        InsertQuery.Append(" ?val81,")
        InsertQuery.Append(" ?val82,")
        InsertQuery.Append(" ?val83,")
        InsertQuery.Append(" ?val84,")
        InsertQuery.Append(" ?val85,")
        InsertQuery.Append(" ?val86,")
        InsertQuery.Append(" ?val87,")
        InsertQuery.Append(" ?val88,")
        InsertQuery.Append(" ?val89,")
        InsertQuery.Append(" ?val90,")
        InsertQuery.Append(" ?val91,")
        InsertQuery.Append(" ?val92 )")

        Return InsertQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　JV_HR_PAY 払戻テーブルUpdate文発行
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 払戻テーブルUpdate文
    '------------------------------------------------------------------------
    Public Function CreateJvHrPayUpdate() As String

        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE jv_hr_pay ")
        UpdateQuery.Append("SET ")
        UpdateQuery.Append("  tansho_one_umaban = ?val1")
        UpdateQuery.Append("  , tansho_one_harai_modoshi = ?val2")
        UpdateQuery.Append("  , tansho_one_ninki = ?val3")
        UpdateQuery.Append("  , tansho_two_umaban = ?val4")
        UpdateQuery.Append("  , tansho_two_harai_modoshi = ?val5")
        UpdateQuery.Append("  , tansho_two_ninki = ?val6")
        UpdateQuery.Append("  , tansho_three_umaban = ?val7")
        UpdateQuery.Append("  , tansho_three_harai_modoshi = ?val8")
        UpdateQuery.Append("  , tansho_three_ninki = ?val9")
        UpdateQuery.Append("  , umaren_one_kumi = ?val10")
        UpdateQuery.Append("  , umaren_one_harai_modoshi = ?val11")
        UpdateQuery.Append("  , umaren_one_ninki = ?val12")
        UpdateQuery.Append("  , umaren_two_kumi = ?val13")
        UpdateQuery.Append("  , umaren_two_harai_modoshi = ?val14")
        UpdateQuery.Append("  , umaren_two_ninki = ?val15")
        UpdateQuery.Append("  , umaren_three_kumi = ?val16")
        UpdateQuery.Append("  , umaren_three_harai_modoshi = ?val17")
        UpdateQuery.Append("  , umaren_three_ninki = ?val18")
        UpdateQuery.Append("  , sanrenpuku_one_kumi = ?val19")
        UpdateQuery.Append("  , sanrenpuku_one_harai_modoshi = ?val20")
        UpdateQuery.Append("  , sanrenpuku_one_ninki = ?val21")
        UpdateQuery.Append("  , sanrenpuku_two_kumi = ?val22")
        UpdateQuery.Append("  , sanrenpuku_two_harai_modoshi = ?val23")
        UpdateQuery.Append("  , sanrenpuku_two_ninki = ?val24")
        UpdateQuery.Append("  , sanrenpuku_three_kumi = ?val25")
        UpdateQuery.Append("  , sanrenpuku_three_harai_modoshi = ?val26")
        UpdateQuery.Append("  , sanrenpuku_three_ninki = ?val27")
        UpdateQuery.Append("  , sanrentan_one_kumi = ?val28")
        UpdateQuery.Append("  , sanrentan_one_harai_modoshi = ?val29")
        UpdateQuery.Append("  , sanrentan_one_ninki = ?val30")
        UpdateQuery.Append("  , sanrentan_two_kumi = ?val31")
        UpdateQuery.Append("  , sanrentan_two_harai_modoshi = ?val32")
        UpdateQuery.Append("  , sanrentan_two_ninki = ?val33")
        UpdateQuery.Append("  , sanrentan_three_kumi = ?val34")
        UpdateQuery.Append("  , sanrentan_three_harai_modoshi = ?val35")
        UpdateQuery.Append("  , sanrentan_three_ninki = ?val36")
        UpdateQuery.Append("  , sanrentan_four_kumi = ?val37")
        UpdateQuery.Append("  , sanrentan_four_harai_modoshi = ?val38")
        UpdateQuery.Append("  , sanrentan_four_ninki = ?val39")
        UpdateQuery.Append("  , sanrentan_five_kumi = ?val40")
        UpdateQuery.Append("  , sanrentan_five_harai_modoshi = ?val41")
        UpdateQuery.Append("  , sanrentan_five_ninki = ?val42")
        UpdateQuery.Append("  , sanrentan_six_kumi = ?val43")
        UpdateQuery.Append("  , sanrentan_six_harai_modoshi = ?val44")
        UpdateQuery.Append("  , sanrentan_six_ninki = ?val45")
        UpdateQuery.Append("  , wide_one_kumi = ?val46")
        UpdateQuery.Append("  , wide_one_harai_modoshi = ?val47")
        UpdateQuery.Append("  , wide_one_ninki = ?val48")
        UpdateQuery.Append("  , wide_two_kumi = ?val49")
        UpdateQuery.Append("  , wide_two_harai_modoshi = ?val50")
        UpdateQuery.Append("  , wide_two_ninki = ?val51")
        UpdateQuery.Append("  , wide_three_kumi = ?val52")
        UpdateQuery.Append("  , wide_three_harai_modoshi = ?val53")
        UpdateQuery.Append("  , wide_three_ninki = ?val54")
        UpdateQuery.Append("  , wide_four_kumi = ?val55")
        UpdateQuery.Append("  , wide_four_harai_modoshi = ?val56")
        UpdateQuery.Append("  , wide_four_ninki = ?val57")
        UpdateQuery.Append("  , wide_five_kumi = ?val58")
        UpdateQuery.Append("  , wide_five_harai_modoshi = ?val59")
        UpdateQuery.Append("  , wide_five_ninki = ?val60")
        UpdateQuery.Append("  , wide_six_kumi = ?val61")
        UpdateQuery.Append("  , wide_six_harai_modoshi = ?val62")
        UpdateQuery.Append("  , wide_six_ninki = ?val63")
        UpdateQuery.Append("  , wide_seven_kumi = ?val64")
        UpdateQuery.Append("  , wide_seven_harai_modoshi = ?val65")
        UpdateQuery.Append("  , wide_seven_ninki = ?val66")
        UpdateQuery.Append("  , umatan_one_kumi = ?val67")
        UpdateQuery.Append("  , umatan_one_harai_modoshi = ?val68")
        UpdateQuery.Append("  , umatan_one_ninki = ?val69")
        UpdateQuery.Append("  , umatan_two_kumi = ?val70")
        UpdateQuery.Append("  , umatan_two_harai_modoshi = ?val71")
        UpdateQuery.Append("  , umatan_two_ninki = ?val72")
        UpdateQuery.Append("  , umatan_three_kumi = ?val73")
        UpdateQuery.Append("  , umatan_three_harai_modoshi = ?val74")
        UpdateQuery.Append("  , umatan_three_ninki = ?val75")
        UpdateQuery.Append("  , umatan_four_kumi = ?val76")
        UpdateQuery.Append("  , umatan_four_harai_modoshi = ?val77")
        UpdateQuery.Append("  , umatan_four_ninki = ?val78")
        UpdateQuery.Append("  , umatan_five_kumi = ?val79")
        UpdateQuery.Append("  , umatan_five_harai_modoshi = ?val80")
        UpdateQuery.Append("  , umatan_five_ninki = ?val81")
        UpdateQuery.Append("  , umatan_six_kumi = ?val82")
        UpdateQuery.Append("  , umatan_six_harai_modoshi = ?val83")
        UpdateQuery.Append("  , umatan_six_ninki = ?val84")
        UpdateQuery.Append("  , data_kubun = ?val85")
        UpdateQuery.Append("  , data_sakusei_day = ?val86 ")
        UpdateQuery.Append(" WHERE ")
        UpdateQuery.Append("  race_id = ?val87")

        Return UpdateQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　JV_UM_UMA 競走馬マスタテーブルInsert文発行
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 競走馬マスタテーブルInsert文
    '------------------------------------------------------------------------
    Public Function CreateJvUmUmaInsert() As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("INSERT INTO jv_um_uma (")
        InsertQuery.Append(" ketto_num,")
        InsertQuery.Append(" bamei,")
        InsertQuery.Append(" reg_date,")
        InsertQuery.Append(" uma_kigo_cd,")
        InsertQuery.Append(" sex_cd,")
        InsertQuery.Append(" hinsyu_cd,")
        InsertQuery.Append(" keiro_cd,")
        InsertQuery.Append(" ruikei_honsyo_heiti,")
        InsertQuery.Append(" ruikei_honsyo_syougai,")
        InsertQuery.Append(" titi,")
        InsertQuery.Append(" titi_titi,")
        InsertQuery.Append(" haha_titi,")
        InsertQuery.Append(" race_count,")
        InsertQuery.Append(" del_kubun,")
        InsertQuery.Append(" del_date,")
        InsertQuery.Append(" siba_tyoku_kaisuu_one,")
        InsertQuery.Append(" siba_tyoku_kaisuu_two,")
        InsertQuery.Append(" siba_tyoku_kaisuu_three,")
        InsertQuery.Append(" siba_tyoku_kaisuu_four,")
        InsertQuery.Append(" siba_tyoku_kaisuu_five,")
        InsertQuery.Append(" siba_tyoku_kaisuu_six,")
        InsertQuery.Append(" siba_migi_kaisuu_one,")
        InsertQuery.Append(" siba_migi_kaisuu_two,")
        InsertQuery.Append(" siba_migi_kaisuu_three,")
        InsertQuery.Append(" siba_migi_kaisuu_four,")
        InsertQuery.Append(" siba_migi_kaisuu_five,")
        InsertQuery.Append(" siba_migi_kaisuu_six,")
        InsertQuery.Append(" siba_hidari_kaisuu_one,")
        InsertQuery.Append(" siba_hidari_kaisuu_two,")
        InsertQuery.Append(" siba_hidari_kaisuu_three,")
        InsertQuery.Append(" siba_hidari_kaisuu_four,")
        InsertQuery.Append(" siba_hidari_kaisuu_five,")
        InsertQuery.Append(" siba_hidari_kaisuu_six,")
        InsertQuery.Append(" dirt_tyoku_kaisuu_one,")
        InsertQuery.Append(" dirt_tyoku_kaisuu_two,")
        InsertQuery.Append(" dirt_tyoku_kaisuu_three,")
        InsertQuery.Append(" dirt_tyoku_kaisuu_four,")
        InsertQuery.Append(" dirt_tyoku_kaisuu_five,")
        InsertQuery.Append(" dirt_tyoku_kaisuu_six,")
        InsertQuery.Append(" dirt_migi_kaisuu_one,")
        InsertQuery.Append(" dirt_migi_kaisuu_two,")
        InsertQuery.Append(" dirt_migi_kaisuu_three,")
        InsertQuery.Append(" dirt_migi_kaisuu_four,")
        InsertQuery.Append(" dirt_migi_kaisuu_five,")
        InsertQuery.Append(" dirt_migi_kaisuu_six,")
        InsertQuery.Append(" dirt_hidari_kaisuu_one,")
        InsertQuery.Append(" dirt_hidari_kaisuu_two,")
        InsertQuery.Append(" dirt_hidari_kaisuu_three,")
        InsertQuery.Append(" dirt_hidari_kaisuu_four,")
        InsertQuery.Append(" dirt_hidari_kaisuu_five,")
        InsertQuery.Append(" dirt_hidari_kaisuu_six,")
        InsertQuery.Append(" syougai_kaisuu_one,")
        InsertQuery.Append(" syougai_kaisuu_two,")
        InsertQuery.Append(" syougai_kaisuu_three,")
        InsertQuery.Append(" syougai_kaisuu_four,")
        InsertQuery.Append(" syougai_kaisuu_five,")
        InsertQuery.Append(" syougai_kaisuu_six,")
        InsertQuery.Append(" siba_ryo_kaisuu_one,")
        InsertQuery.Append(" siba_ryo_kaisuu_two,")
        InsertQuery.Append(" siba_ryo_kaisuu_three,")
        InsertQuery.Append(" siba_ryo_kaisuu_four,")
        InsertQuery.Append(" siba_ryo_kaisuu_five,")
        InsertQuery.Append(" siba_ryo_kaisuu_six,")
        InsertQuery.Append(" siba_yayaomo_kaisuu_one,")
        InsertQuery.Append(" siba_yayaomo_kaisuu_two,")
        InsertQuery.Append(" siba_yayaomo_kaisuu_three,")
        InsertQuery.Append(" siba_yayaomo_kaisuu_four,")
        InsertQuery.Append(" siba_yayaomo_kaisuu_five,")
        InsertQuery.Append(" siba_yayaomo_kaisuu_six,")
        InsertQuery.Append(" siba_omo_kaisuu_one,")
        InsertQuery.Append(" siba_omo_kaisuu_two,")
        InsertQuery.Append(" siba_omo_kaisuu_three,")
        InsertQuery.Append(" siba_omo_kaisuu_four,")
        InsertQuery.Append(" siba_omo_kaisuu_five,")
        InsertQuery.Append(" siba_omo_kaisuu_six,")
        InsertQuery.Append(" siba_furyo_kaisuu_one,")
        InsertQuery.Append(" siba_furyo_kaisuu_two,")
        InsertQuery.Append(" siba_furyo_kaisuu_three,")
        InsertQuery.Append(" siba_furyo_kaisuu_four,")
        InsertQuery.Append(" siba_furyo_kaisuu_five,")
        InsertQuery.Append(" siba_furyo_kaisuu_six,")
        InsertQuery.Append(" dirt_ryo_kaisuu_one,")
        InsertQuery.Append(" dirt_ryo_kaisuu_two,")
        InsertQuery.Append(" dirt_ryo_kaisuu_three,")
        InsertQuery.Append(" dirt_ryo_kaisuu_four,")
        InsertQuery.Append(" dirt_ryo_kaisuu_five,")
        InsertQuery.Append(" dirt_ryo_kaisuu_six,")
        InsertQuery.Append(" dirt_yayaomo_kaisuu_one,")
        InsertQuery.Append(" dirt_yayaomo_kaisuu_two,")
        InsertQuery.Append(" dirt_yayaomo_kaisuu_three,")
        InsertQuery.Append(" dirt_yayaomo_kaisuu_four,")
        InsertQuery.Append(" dirt_yayaomo_kaisuu_five,")
        InsertQuery.Append(" dirt_yayaomo_kaisuu_six,")
        InsertQuery.Append(" dirt_omo_kaisuu_one,")
        InsertQuery.Append(" dirt_omo_kaisuu_two,")
        InsertQuery.Append(" dirt_omo_kaisuu_three,")
        InsertQuery.Append(" dirt_omo_kaisuu_four,")
        InsertQuery.Append(" dirt_omo_kaisuu_five,")
        InsertQuery.Append(" dirt_omo_kaisuu_six,")
        InsertQuery.Append(" dirt_furyo_kaisuu_one,")
        InsertQuery.Append(" dirt_furyo_kaisuu_two,")
        InsertQuery.Append(" dirt_furyo_kaisuu_three,")
        InsertQuery.Append(" dirt_furyo_kaisuu_four,")
        InsertQuery.Append(" dirt_furyo_kaisuu_five,")
        InsertQuery.Append(" dirt_furyo_kaisuu_six,")
        InsertQuery.Append(" syougai_ryo_kaisuu_one,")
        InsertQuery.Append(" syougai_ryo_kaisuu_two,")
        InsertQuery.Append(" syougai_ryo_kaisuu_three,")
        InsertQuery.Append(" syougai_ryo_kaisuu_four,")
        InsertQuery.Append(" syougai_ryo_kaisuu_five,")
        InsertQuery.Append(" syougai_ryo_kaisuu_six,")
        InsertQuery.Append(" syougai_yayaomo_kaisuu_one,")
        InsertQuery.Append(" syougai_yayaomo_kaisuu_two,")
        InsertQuery.Append(" syougai_yayaomo_kaisuu_three,")
        InsertQuery.Append(" syougai_yayaomo_kaisuu_four,")
        InsertQuery.Append(" syougai_yayaomo_kaisuu_five,")
        InsertQuery.Append(" syougai_yayaomo_kaisuu_six,")
        InsertQuery.Append(" syougai_omo_kaisuu_one,")
        InsertQuery.Append(" syougai_omo_kaisuu_two,")
        InsertQuery.Append(" syougai_omo_kaisuu_three,")
        InsertQuery.Append(" syougai_omo_kaisuu_four,")
        InsertQuery.Append(" syougai_omo_kaisuu_five,")
        InsertQuery.Append(" syougai_omo_kaisuu_six,")
        InsertQuery.Append(" syougai_furyo_kaisuu_one,")
        InsertQuery.Append(" syougai_furyo_kaisuu_two,")
        InsertQuery.Append(" syougai_furyo_kaisuu_three,")
        InsertQuery.Append(" syougai_furyo_kaisuu_four,")
        InsertQuery.Append(" syougai_furyo_kaisuu_five,")
        InsertQuery.Append(" syougai_furyo_kaisuu_six,")
        InsertQuery.Append(" siba_sixteen_sita_kaisuu_one,")
        InsertQuery.Append(" siba_sixteen_sita_kaisuu_two,")
        InsertQuery.Append(" siba_sixteen_sita_kaisuu_three,")
        InsertQuery.Append(" siba_sixteen_sita_kaisuu_four,")
        InsertQuery.Append(" siba_sixteen_sita_kaisuu_five,")
        InsertQuery.Append(" siba_sixteen_sita_kaisuu_six,")
        InsertQuery.Append(" siba_twentytwo_sita_kaisuu_one,")
        InsertQuery.Append(" siba_twentytwo_sita_kaisuu_two,")
        InsertQuery.Append(" siba_twentytwo_sita_kaisuu_three,")
        InsertQuery.Append(" siba_twentytwo_sita_kaisuu_four,")
        InsertQuery.Append(" siba_twentytwo_sita_kaisuu_five,")
        InsertQuery.Append(" siba_twentytwo_sita_kaisuu_six,")
        InsertQuery.Append(" siba_twentytwo_ue_kaisuu_one,")
        InsertQuery.Append(" siba_twentytwo_ue_kaisuu_two,")
        InsertQuery.Append(" siba_twentytwo_ue_kaisuu_three,")
        InsertQuery.Append(" siba_twentytwo_ue_kaisuu_four,")
        InsertQuery.Append(" siba_twentytwo_ue_kaisuu_five,")
        InsertQuery.Append(" siba_twentytwo_ue_kaisuu_six,")
        InsertQuery.Append(" dirt_sixteen_sita_kaisuu_one,")
        InsertQuery.Append(" dirt_sixteen_sita_kaisuu_two,")
        InsertQuery.Append(" dirt_sixteen_sita_kaisuu_three,")
        InsertQuery.Append(" dirt_sixteen_sita_kaisuu_four,")
        InsertQuery.Append(" dirt_sixteen_sita_kaisuu_five,")
        InsertQuery.Append(" dirt_sixteen_sita_kaisuu_six,")
        InsertQuery.Append(" dirt_twentytwo_sita_kaisuu_one,")
        InsertQuery.Append(" dirt_twentytwo_sita_kaisuu_two,")
        InsertQuery.Append(" dirt_twentytwo_sita_kaisuu_three,")
        InsertQuery.Append(" dirt_twentytwo_sita_kaisuu_four,")
        InsertQuery.Append(" dirt_twentytwo_sita_kaisuu_five,")
        InsertQuery.Append(" dirt_twentytwo_sita_kaisuu_six,")
        InsertQuery.Append(" dirt_twentytwo_ue_kaisuu_one,")
        InsertQuery.Append(" dirt_twentytwo_ue_kaisuu_two,")
        InsertQuery.Append(" dirt_twentytwo_ue_kaisuu_three,")
        InsertQuery.Append(" dirt_twentytwo_ue_kaisuu_four,")
        InsertQuery.Append(" dirt_twentytwo_ue_kaisuu_five,")
        InsertQuery.Append(" dirt_twentytwo_ue_kaisuu_six,")
        InsertQuery.Append(" data_kubun,")
        InsertQuery.Append(" data_sakusei_day )")
        InsertQuery.Append(" VALUES(")
        InsertQuery.Append(" ?val1,")
        InsertQuery.Append(" ?val2,")
        InsertQuery.Append(" ?val3,")
        InsertQuery.Append(" ?val4,")
        InsertQuery.Append(" ?val5,")
        InsertQuery.Append(" ?val6,")
        InsertQuery.Append(" ?val7,")
        InsertQuery.Append(" ?val8,")
        InsertQuery.Append(" ?val9,")
        InsertQuery.Append(" ?val10,")
        InsertQuery.Append(" ?val11,")
        InsertQuery.Append(" ?val12,")
        InsertQuery.Append(" ?val13,")
        InsertQuery.Append(" ?val14,")
        InsertQuery.Append(" ?val15,")
        InsertQuery.Append(" ?val16,")
        InsertQuery.Append(" ?val17,")
        InsertQuery.Append(" ?val18,")
        InsertQuery.Append(" ?val19,")
        InsertQuery.Append(" ?val20,")
        InsertQuery.Append(" ?val21,")
        InsertQuery.Append(" ?val22,")
        InsertQuery.Append(" ?val23,")
        InsertQuery.Append(" ?val24,")
        InsertQuery.Append(" ?val25,")
        InsertQuery.Append(" ?val26,")
        InsertQuery.Append(" ?val27,")
        InsertQuery.Append(" ?val28,")
        InsertQuery.Append(" ?val29,")
        InsertQuery.Append(" ?val30,")
        InsertQuery.Append(" ?val31,")
        InsertQuery.Append(" ?val32,")
        InsertQuery.Append(" ?val33,")
        InsertQuery.Append(" ?val34,")
        InsertQuery.Append(" ?val35,")
        InsertQuery.Append(" ?val36,")
        InsertQuery.Append(" ?val37,")
        InsertQuery.Append(" ?val38,")
        InsertQuery.Append(" ?val39,")
        InsertQuery.Append(" ?val40,")
        InsertQuery.Append(" ?val41,")
        InsertQuery.Append(" ?val42,")
        InsertQuery.Append(" ?val43,")
        InsertQuery.Append(" ?val44,")
        InsertQuery.Append(" ?val45,")
        InsertQuery.Append(" ?val46,")
        InsertQuery.Append(" ?val47,")
        InsertQuery.Append(" ?val48,")
        InsertQuery.Append(" ?val49,")
        InsertQuery.Append(" ?val50,")
        InsertQuery.Append(" ?val51,")
        InsertQuery.Append(" ?val52,")
        InsertQuery.Append(" ?val53,")
        InsertQuery.Append(" ?val54,")
        InsertQuery.Append(" ?val55,")
        InsertQuery.Append(" ?val56,")
        InsertQuery.Append(" ?val57,")
        InsertQuery.Append(" ?val58,")
        InsertQuery.Append(" ?val59,")
        InsertQuery.Append(" ?val60,")
        InsertQuery.Append(" ?val61,")
        InsertQuery.Append(" ?val62,")
        InsertQuery.Append(" ?val63,")
        InsertQuery.Append(" ?val64,")
        InsertQuery.Append(" ?val65,")
        InsertQuery.Append(" ?val66,")
        InsertQuery.Append(" ?val67,")
        InsertQuery.Append(" ?val68,")
        InsertQuery.Append(" ?val69,")
        InsertQuery.Append(" ?val70,")
        InsertQuery.Append(" ?val71,")
        InsertQuery.Append(" ?val72,")
        InsertQuery.Append(" ?val73,")
        InsertQuery.Append(" ?val74,")
        InsertQuery.Append(" ?val75,")
        InsertQuery.Append(" ?val76,")
        InsertQuery.Append(" ?val77,")
        InsertQuery.Append(" ?val78,")
        InsertQuery.Append(" ?val79,")
        InsertQuery.Append(" ?val80,")
        InsertQuery.Append(" ?val81,")
        InsertQuery.Append(" ?val82,")
        InsertQuery.Append(" ?val83,")
        InsertQuery.Append(" ?val84,")
        InsertQuery.Append(" ?val85,")
        InsertQuery.Append(" ?val86,")
        InsertQuery.Append(" ?val87,")
        InsertQuery.Append(" ?val88,")
        InsertQuery.Append(" ?val89,")
        InsertQuery.Append(" ?val90,")
        InsertQuery.Append(" ?val91,")
        InsertQuery.Append(" ?val92,")
        InsertQuery.Append(" ?val93,")
        InsertQuery.Append(" ?val94,")
        InsertQuery.Append(" ?val95,")
        InsertQuery.Append(" ?val96,")
        InsertQuery.Append(" ?val97,")
        InsertQuery.Append(" ?val98,")
        InsertQuery.Append(" ?val99,")
        InsertQuery.Append(" ?val100,")
        InsertQuery.Append(" ?val101,")
        InsertQuery.Append(" ?val102,")
        InsertQuery.Append(" ?val103,")
        InsertQuery.Append(" ?val104,")
        InsertQuery.Append(" ?val105,")
        InsertQuery.Append(" ?val106,")
        InsertQuery.Append(" ?val107,")
        InsertQuery.Append(" ?val108,")
        InsertQuery.Append(" ?val109,")
        InsertQuery.Append(" ?val110,")
        InsertQuery.Append(" ?val111,")
        InsertQuery.Append(" ?val112,")
        InsertQuery.Append(" ?val113,")
        InsertQuery.Append(" ?val114,")
        InsertQuery.Append(" ?val115,")
        InsertQuery.Append(" ?val116,")
        InsertQuery.Append(" ?val117,")
        InsertQuery.Append(" ?val118,")
        InsertQuery.Append(" ?val119,")
        InsertQuery.Append(" ?val120,")
        InsertQuery.Append(" ?val121,")
        InsertQuery.Append(" ?val122,")
        InsertQuery.Append(" ?val123,")
        InsertQuery.Append(" ?val124,")
        InsertQuery.Append(" ?val125,")
        InsertQuery.Append(" ?val126,")
        InsertQuery.Append(" ?val127,")
        InsertQuery.Append(" ?val128,")
        InsertQuery.Append(" ?val129,")
        InsertQuery.Append(" ?val130,")
        InsertQuery.Append(" ?val131,")
        InsertQuery.Append(" ?val132,")
        InsertQuery.Append(" ?val133,")
        InsertQuery.Append(" ?val134,")
        InsertQuery.Append(" ?val135,")
        InsertQuery.Append(" ?val136,")
        InsertQuery.Append(" ?val137,")
        InsertQuery.Append(" ?val138,")
        InsertQuery.Append(" ?val139,")
        InsertQuery.Append(" ?val140,")
        InsertQuery.Append(" ?val141,")
        InsertQuery.Append(" ?val142,")
        InsertQuery.Append(" ?val143,")
        InsertQuery.Append(" ?val144,")
        InsertQuery.Append(" ?val145,")
        InsertQuery.Append(" ?val146,")
        InsertQuery.Append(" ?val147,")
        InsertQuery.Append(" ?val148,")
        InsertQuery.Append(" ?val149,")
        InsertQuery.Append(" ?val150,")
        InsertQuery.Append(" ?val151,")
        InsertQuery.Append(" ?val152,")
        InsertQuery.Append(" ?val153,")
        InsertQuery.Append(" ?val154,")
        InsertQuery.Append(" ?val155,")
        InsertQuery.Append(" ?val156,")
        InsertQuery.Append(" ?val157,")
        InsertQuery.Append(" ?val158,")
        InsertQuery.Append(" ?val159,")
        InsertQuery.Append(" ?val160,")
        InsertQuery.Append(" ?val161,")
        InsertQuery.Append(" ?val162,")
        InsertQuery.Append(" ?val163,")
        InsertQuery.Append(" ?val164,")
        InsertQuery.Append(" ?val165,")
        InsertQuery.Append(" ?val166,")
        InsertQuery.Append(" ?val167 )")

        Return InsertQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　JV_UM_UMA 競走馬マスタテーブルUpdate文発行
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 競走馬マスタテーブルUpdate文
    '------------------------------------------------------------------------
    Public Function CreateJvUmUmaUpdate() As String

        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE jv_um_uma  ")
        UpdateQuery.Append("SET ")
        UpdateQuery.Append("  bamei = ?val1 ")
        UpdateQuery.Append("  , reg_date = ?val2 ")
        UpdateQuery.Append("  , uma_kigo_cd = ?val3 ")
        UpdateQuery.Append("  , sex_cd = ?val4 ")
        UpdateQuery.Append("  , hinsyu_cd = ?val5 ")
        UpdateQuery.Append("  , keiro_cd = ?val6 ")
        UpdateQuery.Append("  , ruikei_honsyo_heiti = ?val7 ")
        UpdateQuery.Append("  , ruikei_honsyo_syougai = ?val8 ")
        UpdateQuery.Append("  , titi = ?val9 ")
        UpdateQuery.Append("  , titi_titi = ?val10 ")
        UpdateQuery.Append("  , haha_titi = ?val11 ")
        UpdateQuery.Append("  , race_count = ?val12 ")
        UpdateQuery.Append("  , del_kubun = ?val13 ")
        UpdateQuery.Append("  , del_date = ?val14 ")
        UpdateQuery.Append("  , siba_tyoku_kaisuu_one = ?val15 ")
        UpdateQuery.Append("  , siba_tyoku_kaisuu_two = ?val16 ")
        UpdateQuery.Append("  , siba_tyoku_kaisuu_three = ?val17 ")
        UpdateQuery.Append("  , siba_tyoku_kaisuu_four = ?val18 ")
        UpdateQuery.Append("  , siba_tyoku_kaisuu_five = ?val19 ")
        UpdateQuery.Append("  , siba_tyoku_kaisuu_six = ?val20 ")
        UpdateQuery.Append("  , siba_migi_kaisuu_one = ?val21 ")
        UpdateQuery.Append("  , siba_migi_kaisuu_two = ?val22 ")
        UpdateQuery.Append("  , siba_migi_kaisuu_three = ?val23 ")
        UpdateQuery.Append("  , siba_migi_kaisuu_four = ?val24 ")
        UpdateQuery.Append("  , siba_migi_kaisuu_five = ?val25 ")
        UpdateQuery.Append("  , siba_migi_kaisuu_six = ?val26 ")
        UpdateQuery.Append("  , siba_hidari_kaisuu_one = ?val27 ")
        UpdateQuery.Append("  , siba_hidari_kaisuu_two = ?val28 ")
        UpdateQuery.Append("  , siba_hidari_kaisuu_three = ?val29 ")
        UpdateQuery.Append("  , siba_hidari_kaisuu_four = ?val30 ")
        UpdateQuery.Append("  , siba_hidari_kaisuu_five = ?val31 ")
        UpdateQuery.Append("  , siba_hidari_kaisuu_six = ?val32 ")
        UpdateQuery.Append("  , dirt_tyoku_kaisuu_one = ?val33 ")
        UpdateQuery.Append("  , dirt_tyoku_kaisuu_two = ?val34 ")
        UpdateQuery.Append("  , dirt_tyoku_kaisuu_three = ?val35 ")
        UpdateQuery.Append("  , dirt_tyoku_kaisuu_four = ?val36 ")
        UpdateQuery.Append("  , dirt_tyoku_kaisuu_five = ?val37 ")
        UpdateQuery.Append("  , dirt_tyoku_kaisuu_six = ?val38 ")
        UpdateQuery.Append("  , dirt_migi_kaisuu_one = ?val39 ")
        UpdateQuery.Append("  , dirt_migi_kaisuu_two = ?val40 ")
        UpdateQuery.Append("  , dirt_migi_kaisuu_three = ?val41 ")
        UpdateQuery.Append("  , dirt_migi_kaisuu_four = ?val42 ")
        UpdateQuery.Append("  , dirt_migi_kaisuu_five = ?val43 ")
        UpdateQuery.Append("  , dirt_migi_kaisuu_six = ?val44 ")
        UpdateQuery.Append("  , dirt_hidari_kaisuu_one = ?val45 ")
        UpdateQuery.Append("  , dirt_hidari_kaisuu_two = ?val46 ")
        UpdateQuery.Append("  , dirt_hidari_kaisuu_three = ?val47 ")
        UpdateQuery.Append("  , dirt_hidari_kaisuu_four = ?val48 ")
        UpdateQuery.Append("  , dirt_hidari_kaisuu_five = ?val49 ")
        UpdateQuery.Append("  , dirt_hidari_kaisuu_six = ?val50 ")
        UpdateQuery.Append("  , syougai_kaisuu_one = ?val51 ")
        UpdateQuery.Append("  , syougai_kaisuu_two = ?val52 ")
        UpdateQuery.Append("  , syougai_kaisuu_three = ?val53 ")
        UpdateQuery.Append("  , syougai_kaisuu_four = ?val54 ")
        UpdateQuery.Append("  , syougai_kaisuu_five = ?val55 ")
        UpdateQuery.Append("  , syougai_kaisuu_six = ?val56 ")
        UpdateQuery.Append("  , siba_ryo_kaisuu_one = ?val57 ")
        UpdateQuery.Append("  , siba_ryo_kaisuu_two = ?val58 ")
        UpdateQuery.Append("  , siba_ryo_kaisuu_three = ?val59 ")
        UpdateQuery.Append("  , siba_ryo_kaisuu_four = ?val60 ")
        UpdateQuery.Append("  , siba_ryo_kaisuu_five = ?val61 ")
        UpdateQuery.Append("  , siba_ryo_kaisuu_six = ?val62 ")
        UpdateQuery.Append("  , siba_yayaomo_kaisuu_one = ?val63 ")
        UpdateQuery.Append("  , siba_yayaomo_kaisuu_two = ?val64 ")
        UpdateQuery.Append("  , siba_yayaomo_kaisuu_three = ?val65 ")
        UpdateQuery.Append("  , siba_yayaomo_kaisuu_four = ?val66 ")
        UpdateQuery.Append("  , siba_yayaomo_kaisuu_five = ?val67 ")
        UpdateQuery.Append("  , siba_yayaomo_kaisuu_six = ?val68 ")
        UpdateQuery.Append("  , siba_omo_kaisuu_one = ?val69 ")
        UpdateQuery.Append("  , siba_omo_kaisuu_two = ?val70 ")
        UpdateQuery.Append("  , siba_omo_kaisuu_three = ?val71 ")
        UpdateQuery.Append("  , siba_omo_kaisuu_four = ?val72 ")
        UpdateQuery.Append("  , siba_omo_kaisuu_five = ?val73 ")
        UpdateQuery.Append("  , siba_omo_kaisuu_six = ?val74 ")
        UpdateQuery.Append("  , siba_furyo_kaisuu_one = ?val75 ")
        UpdateQuery.Append("  , siba_furyo_kaisuu_two = ?val76 ")
        UpdateQuery.Append("  , siba_furyo_kaisuu_three = ?val77 ")
        UpdateQuery.Append("  , siba_furyo_kaisuu_four = ?val78 ")
        UpdateQuery.Append("  , siba_furyo_kaisuu_five = ?val79 ")
        UpdateQuery.Append("  , siba_furyo_kaisuu_six = ?val80 ")
        UpdateQuery.Append("  , dirt_ryo_kaisuu_one = ?val81 ")
        UpdateQuery.Append("  , dirt_ryo_kaisuu_two = ?val82 ")
        UpdateQuery.Append("  , dirt_ryo_kaisuu_three = ?val83 ")
        UpdateQuery.Append("  , dirt_ryo_kaisuu_four = ?val84 ")
        UpdateQuery.Append("  , dirt_ryo_kaisuu_five = ?val85 ")
        UpdateQuery.Append("  , dirt_ryo_kaisuu_six = ?val86 ")
        UpdateQuery.Append("  , dirt_yayaomo_kaisuu_one = ?val87 ")
        UpdateQuery.Append("  , dirt_yayaomo_kaisuu_two = ?val88 ")
        UpdateQuery.Append("  , dirt_yayaomo_kaisuu_three = ?val89 ")
        UpdateQuery.Append("  , dirt_yayaomo_kaisuu_four = ?val90 ")
        UpdateQuery.Append("  , dirt_yayaomo_kaisuu_five = ?val91 ")
        UpdateQuery.Append("  , dirt_yayaomo_kaisuu_six = ?val92 ")
        UpdateQuery.Append("  , dirt_omo_kaisuu_one = ?val93 ")
        UpdateQuery.Append("  , dirt_omo_kaisuu_two = ?val94 ")
        UpdateQuery.Append("  , dirt_omo_kaisuu_three = ?val95 ")
        UpdateQuery.Append("  , dirt_omo_kaisuu_four = ?val96 ")
        UpdateQuery.Append("  , dirt_omo_kaisuu_five = ?val97 ")
        UpdateQuery.Append("  , dirt_omo_kaisuu_six = ?val98 ")
        UpdateQuery.Append("  , dirt_furyo_kaisuu_one = ?val99 ")
        UpdateQuery.Append("  , dirt_furyo_kaisuu_two = ?val100 ")
        UpdateQuery.Append("  , dirt_furyo_kaisuu_three = ?val101 ")
        UpdateQuery.Append("  , dirt_furyo_kaisuu_four = ?val102 ")
        UpdateQuery.Append("  , dirt_furyo_kaisuu_five = ?val103 ")
        UpdateQuery.Append("  , dirt_furyo_kaisuu_six = ?val104 ")
        UpdateQuery.Append("  , syougai_ryo_kaisuu_one = ?val105 ")
        UpdateQuery.Append("  , syougai_ryo_kaisuu_two = ?val106 ")
        UpdateQuery.Append("  , syougai_ryo_kaisuu_three = ?val107 ")
        UpdateQuery.Append("  , syougai_ryo_kaisuu_four = ?val108 ")
        UpdateQuery.Append("  , syougai_ryo_kaisuu_five = ?val109 ")
        UpdateQuery.Append("  , syougai_ryo_kaisuu_six = ?val110 ")
        UpdateQuery.Append("  , syougai_yayaomo_kaisuu_one = ?val111 ")
        UpdateQuery.Append("  , syougai_yayaomo_kaisuu_two = ?val112 ")
        UpdateQuery.Append("  , syougai_yayaomo_kaisuu_three = ?val113 ")
        UpdateQuery.Append("  , syougai_yayaomo_kaisuu_four = ?val114 ")
        UpdateQuery.Append("  , syougai_yayaomo_kaisuu_five = ?val115 ")
        UpdateQuery.Append("  , syougai_yayaomo_kaisuu_six = ?val116 ")
        UpdateQuery.Append("  , syougai_omo_kaisuu_one = ?val117 ")
        UpdateQuery.Append("  , syougai_omo_kaisuu_two = ?val118 ")
        UpdateQuery.Append("  , syougai_omo_kaisuu_three = ?val119 ")
        UpdateQuery.Append("  , syougai_omo_kaisuu_four = ?val120 ")
        UpdateQuery.Append("  , syougai_omo_kaisuu_five = ?val121 ")
        UpdateQuery.Append("  , syougai_omo_kaisuu_six = ?val122 ")
        UpdateQuery.Append("  , syougai_furyo_kaisuu_one = ?val123 ")
        UpdateQuery.Append("  , syougai_furyo_kaisuu_two = ?val124 ")
        UpdateQuery.Append("  , syougai_furyo_kaisuu_three = ?val125 ")
        UpdateQuery.Append("  , syougai_furyo_kaisuu_four = ?val126 ")
        UpdateQuery.Append("  , syougai_furyo_kaisuu_five = ?val127 ")
        UpdateQuery.Append("  , syougai_furyo_kaisuu_six = ?val128 ")
        UpdateQuery.Append("  , siba_sixteen_sita_kaisuu_one = ?val129 ")
        UpdateQuery.Append("  , siba_sixteen_sita_kaisuu_two = ?val130 ")
        UpdateQuery.Append("  , siba_sixteen_sita_kaisuu_three = ?val131 ")
        UpdateQuery.Append("  , siba_sixteen_sita_kaisuu_four = ?val132 ")
        UpdateQuery.Append("  , siba_sixteen_sita_kaisuu_five = ?val133 ")
        UpdateQuery.Append("  , siba_sixteen_sita_kaisuu_six = ?val134 ")
        UpdateQuery.Append("  , siba_twentytwo_sita_kaisuu_one = ?val135 ")
        UpdateQuery.Append("  , siba_twentytwo_sita_kaisuu_two = ?val136 ")
        UpdateQuery.Append("  , siba_twentytwo_sita_kaisuu_three = ?val137 ")
        UpdateQuery.Append("  , siba_twentytwo_sita_kaisuu_four = ?val138 ")
        UpdateQuery.Append("  , siba_twentytwo_sita_kaisuu_five = ?val139 ")
        UpdateQuery.Append("  , siba_twentytwo_sita_kaisuu_six = ?val140 ")
        UpdateQuery.Append("  , siba_twentytwo_ue_kaisuu_one = ?val141 ")
        UpdateQuery.Append("  , siba_twentytwo_ue_kaisuu_two = ?val142 ")
        UpdateQuery.Append("  , siba_twentytwo_ue_kaisuu_three = ?val143 ")
        UpdateQuery.Append("  , siba_twentytwo_ue_kaisuu_four = ?val144 ")
        UpdateQuery.Append("  , siba_twentytwo_ue_kaisuu_five = ?val145 ")
        UpdateQuery.Append("  , siba_twentytwo_ue_kaisuu_six = ?val146 ")
        UpdateQuery.Append("  , dirt_sixteen_sita_kaisuu_one = ?val147 ")
        UpdateQuery.Append("  , dirt_sixteen_sita_kaisuu_two = ?val148 ")
        UpdateQuery.Append("  , dirt_sixteen_sita_kaisuu_three = ?val149 ")
        UpdateQuery.Append("  , dirt_sixteen_sita_kaisuu_four = ?val150 ")
        UpdateQuery.Append("  , dirt_sixteen_sita_kaisuu_five = ?val151 ")
        UpdateQuery.Append("  , dirt_sixteen_sita_kaisuu_six = ?val152 ")
        UpdateQuery.Append("  , dirt_twentytwo_sita_kaisuu_one = ?val153 ")
        UpdateQuery.Append("  , dirt_twentytwo_sita_kaisuu_two = ?val154 ")
        UpdateQuery.Append("  , dirt_twentytwo_sita_kaisuu_three = ?val155 ")
        UpdateQuery.Append("  , dirt_twentytwo_sita_kaisuu_four = ?val156 ")
        UpdateQuery.Append("  , dirt_twentytwo_sita_kaisuu_five = ?val157 ")
        UpdateQuery.Append("  , dirt_twentytwo_sita_kaisuu_six = ?val158 ")
        UpdateQuery.Append("  , dirt_twentytwo_ue_kaisuu_one = ?val159 ")
        UpdateQuery.Append("  , dirt_twentytwo_ue_kaisuu_two = ?val160 ")
        UpdateQuery.Append("  , dirt_twentytwo_ue_kaisuu_three = ?val161 ")
        UpdateQuery.Append("  , dirt_twentytwo_ue_kaisuu_four = ?val162 ")
        UpdateQuery.Append("  , dirt_twentytwo_ue_kaisuu_five = ?val163 ")
        UpdateQuery.Append("  , dirt_twentytwo_ue_kaisuu_six = ?val164 ")
        UpdateQuery.Append("  , data_kubun = ?val165  ")
        UpdateQuery.Append("  , data_sakusei_day = ?val166  ")
        UpdateQuery.Append(" WHERE ")
        UpdateQuery.Append("  ketto_num = ?val167 ")

        Return UpdateQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　JV_UM_UMA 競走馬マスタテーブルSelect文発行
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 競走馬マスタテーブルSelect文
    '------------------------------------------------------------------------
    Public Function CreateJvUmUmaSelect() As String

        Dim SelectQuery As New System.Text.StringBuilder()
        SelectQuery.Append("SELECT")
        SelectQuery.Append("  ketto_num")
        SelectQuery.Append("  , bamei")
        SelectQuery.Append("  , reg_date")
        SelectQuery.Append("  , uma_kigo_cd")
        SelectQuery.Append("  , sex_cd")
        SelectQuery.Append("  , hinsyu_cd")
        SelectQuery.Append("  , keiro_cd")
        SelectQuery.Append("  , ruikei_honsyo_heiti")
        SelectQuery.Append("  , ruikei_honsyo_syougai")
        SelectQuery.Append("  , titi")
        SelectQuery.Append("  , titi_titi")
        SelectQuery.Append("  , haha_titi")
        SelectQuery.Append("  , race_count")
        SelectQuery.Append("  , del_kubun")
        SelectQuery.Append("  , del_date")
        SelectQuery.Append("  , siba_tyoku_kaisuu_one")
        SelectQuery.Append("  , siba_tyoku_kaisuu_two")
        SelectQuery.Append("  , siba_tyoku_kaisuu_three")
        SelectQuery.Append("  , siba_tyoku_kaisuu_four")
        SelectQuery.Append("  , siba_tyoku_kaisuu_five")
        SelectQuery.Append("  , siba_tyoku_kaisuu_six")
        SelectQuery.Append("  , siba_migi_kaisuu_one")
        SelectQuery.Append("  , siba_migi_kaisuu_two")
        SelectQuery.Append("  , siba_migi_kaisuu_three")
        SelectQuery.Append("  , siba_migi_kaisuu_four")
        SelectQuery.Append("  , siba_migi_kaisuu_five")
        SelectQuery.Append("  , siba_migi_kaisuu_six")
        SelectQuery.Append("  , siba_hidari_kaisuu_one")
        SelectQuery.Append("  , siba_hidari_kaisuu_two")
        SelectQuery.Append("  , siba_hidari_kaisuu_three")
        SelectQuery.Append("  , siba_hidari_kaisuu_four")
        SelectQuery.Append("  , siba_hidari_kaisuu_five")
        SelectQuery.Append("  , siba_hidari_kaisuu_six")
        SelectQuery.Append("  , dirt_tyoku_kaisuu_one")
        SelectQuery.Append("  , dirt_tyoku_kaisuu_two")
        SelectQuery.Append("  , dirt_tyoku_kaisuu_three")
        SelectQuery.Append("  , dirt_tyoku_kaisuu_four")
        SelectQuery.Append("  , dirt_tyoku_kaisuu_five")
        SelectQuery.Append("  , dirt_tyoku_kaisuu_six")
        SelectQuery.Append("  , dirt_migi_kaisuu_one")
        SelectQuery.Append("  , dirt_migi_kaisuu_two")
        SelectQuery.Append("  , dirt_migi_kaisuu_three")
        SelectQuery.Append("  , dirt_migi_kaisuu_four")
        SelectQuery.Append("  , dirt_migi_kaisuu_five")
        SelectQuery.Append("  , dirt_migi_kaisuu_six")
        SelectQuery.Append("  , dirt_hidari_kaisuu_one")
        SelectQuery.Append("  , dirt_hidari_kaisuu_two")
        SelectQuery.Append("  , dirt_hidari_kaisuu_three")
        SelectQuery.Append("  , dirt_hidari_kaisuu_four")
        SelectQuery.Append("  , dirt_hidari_kaisuu_five")
        SelectQuery.Append("  , dirt_hidari_kaisuu_six")
        SelectQuery.Append("  , syougai_kaisuu_one")
        SelectQuery.Append("  , syougai_kaisuu_two")
        SelectQuery.Append("  , syougai_kaisuu_three")
        SelectQuery.Append("  , syougai_kaisuu_four")
        SelectQuery.Append("  , syougai_kaisuu_five")
        SelectQuery.Append("  , syougai_kaisuu_six")
        SelectQuery.Append("  , siba_ryo_kaisuu_one")
        SelectQuery.Append("  , siba_ryo_kaisuu_two")
        SelectQuery.Append("  , siba_ryo_kaisuu_three")
        SelectQuery.Append("  , siba_ryo_kaisuu_four")
        SelectQuery.Append("  , siba_ryo_kaisuu_five")
        SelectQuery.Append("  , siba_ryo_kaisuu_six")
        SelectQuery.Append("  , siba_yayaomo_kaisuu_one")
        SelectQuery.Append("  , siba_yayaomo_kaisuu_two")
        SelectQuery.Append("  , siba_yayaomo_kaisuu_three")
        SelectQuery.Append("  , siba_yayaomo_kaisuu_four")
        SelectQuery.Append("  , siba_yayaomo_kaisuu_five")
        SelectQuery.Append("  , siba_yayaomo_kaisuu_six")
        SelectQuery.Append("  , siba_omo_kaisuu_one")
        SelectQuery.Append("  , siba_omo_kaisuu_two")
        SelectQuery.Append("  , siba_omo_kaisuu_three")
        SelectQuery.Append("  , siba_omo_kaisuu_four")
        SelectQuery.Append("  , siba_omo_kaisuu_five")
        SelectQuery.Append("  , siba_omo_kaisuu_six")
        SelectQuery.Append("  , siba_furyo_kaisuu_one")
        SelectQuery.Append("  , siba_furyo_kaisuu_two")
        SelectQuery.Append("  , siba_furyo_kaisuu_three")
        SelectQuery.Append("  , siba_furyo_kaisuu_four")
        SelectQuery.Append("  , siba_furyo_kaisuu_five")
        SelectQuery.Append("  , siba_furyo_kaisuu_six")
        SelectQuery.Append("  , dirt_ryo_kaisuu_one")
        SelectQuery.Append("  , dirt_ryo_kaisuu_two")
        SelectQuery.Append("  , dirt_ryo_kaisuu_three")
        SelectQuery.Append("  , dirt_ryo_kaisuu_four")
        SelectQuery.Append("  , dirt_ryo_kaisuu_five")
        SelectQuery.Append("  , dirt_ryo_kaisuu_six")
        SelectQuery.Append("  , dirt_yayaomo_kaisuu_one")
        SelectQuery.Append("  , dirt_yayaomo_kaisuu_two")
        SelectQuery.Append("  , dirt_yayaomo_kaisuu_three")
        SelectQuery.Append("  , dirt_yayaomo_kaisuu_four")
        SelectQuery.Append("  , dirt_yayaomo_kaisuu_five")
        SelectQuery.Append("  , dirt_yayaomo_kaisuu_six")
        SelectQuery.Append("  , dirt_omo_kaisuu_one")
        SelectQuery.Append("  , dirt_omo_kaisuu_two")
        SelectQuery.Append("  , dirt_omo_kaisuu_three")
        SelectQuery.Append("  , dirt_omo_kaisuu_four")
        SelectQuery.Append("  , dirt_omo_kaisuu_five")
        SelectQuery.Append("  , dirt_omo_kaisuu_six")
        SelectQuery.Append("  , dirt_furyo_kaisuu_one")
        SelectQuery.Append("  , dirt_furyo_kaisuu_two")
        SelectQuery.Append("  , dirt_furyo_kaisuu_three")
        SelectQuery.Append("  , dirt_furyo_kaisuu_four")
        SelectQuery.Append("  , dirt_furyo_kaisuu_five")
        SelectQuery.Append("  , dirt_furyo_kaisuu_six")
        SelectQuery.Append("  , syougai_ryo_kaisuu_one")
        SelectQuery.Append("  , syougai_ryo_kaisuu_two")
        SelectQuery.Append("  , syougai_ryo_kaisuu_three")
        SelectQuery.Append("  , syougai_ryo_kaisuu_four")
        SelectQuery.Append("  , syougai_ryo_kaisuu_five")
        SelectQuery.Append("  , syougai_ryo_kaisuu_six")
        SelectQuery.Append("  , syougai_yayaomo_kaisuu_one")
        SelectQuery.Append("  , syougai_yayaomo_kaisuu_two")
        SelectQuery.Append("  , syougai_yayaomo_kaisuu_three")
        SelectQuery.Append("  , syougai_yayaomo_kaisuu_four")
        SelectQuery.Append("  , syougai_yayaomo_kaisuu_five")
        SelectQuery.Append("  , syougai_yayaomo_kaisuu_six")
        SelectQuery.Append("  , syougai_omo_kaisuu_one")
        SelectQuery.Append("  , syougai_omo_kaisuu_two")
        SelectQuery.Append("  , syougai_omo_kaisuu_three")
        SelectQuery.Append("  , syougai_omo_kaisuu_four")
        SelectQuery.Append("  , syougai_omo_kaisuu_five")
        SelectQuery.Append("  , syougai_omo_kaisuu_six")
        SelectQuery.Append("  , syougai_furyo_kaisuu_one")
        SelectQuery.Append("  , syougai_furyo_kaisuu_two")
        SelectQuery.Append("  , syougai_furyo_kaisuu_three")
        SelectQuery.Append("  , syougai_furyo_kaisuu_four")
        SelectQuery.Append("  , syougai_furyo_kaisuu_five")
        SelectQuery.Append("  , syougai_furyo_kaisuu_six")
        SelectQuery.Append("  , siba_sixteen_sita_kaisuu_one")
        SelectQuery.Append("  , siba_sixteen_sita_kaisuu_two")
        SelectQuery.Append("  , siba_sixteen_sita_kaisuu_three")
        SelectQuery.Append("  , siba_sixteen_sita_kaisuu_four")
        SelectQuery.Append("  , siba_sixteen_sita_kaisuu_five")
        SelectQuery.Append("  , siba_sixteen_sita_kaisuu_six")
        SelectQuery.Append("  , siba_twentytwo_sita_kaisuu_one")
        SelectQuery.Append("  , siba_twentytwo_sita_kaisuu_two")
        SelectQuery.Append("  , siba_twentytwo_sita_kaisuu_three")
        SelectQuery.Append("  , siba_twentytwo_sita_kaisuu_four")
        SelectQuery.Append("  , siba_twentytwo_sita_kaisuu_five")
        SelectQuery.Append("  , siba_twentytwo_sita_kaisuu_six")
        SelectQuery.Append("  , siba_twentytwo_ue_kaisuu_one")
        SelectQuery.Append("  , siba_twentytwo_ue_kaisuu_two")
        SelectQuery.Append("  , siba_twentytwo_ue_kaisuu_three")
        SelectQuery.Append("  , siba_twentytwo_ue_kaisuu_four")
        SelectQuery.Append("  , siba_twentytwo_ue_kaisuu_five")
        SelectQuery.Append("  , siba_twentytwo_ue_kaisuu_six")
        SelectQuery.Append("  , dirt_sixteen_sita_kaisuu_one")
        SelectQuery.Append("  , dirt_sixteen_sita_kaisuu_two")
        SelectQuery.Append("  , dirt_sixteen_sita_kaisuu_three")
        SelectQuery.Append("  , dirt_sixteen_sita_kaisuu_four")
        SelectQuery.Append("  , dirt_sixteen_sita_kaisuu_five")
        SelectQuery.Append("  , dirt_sixteen_sita_kaisuu_six")
        SelectQuery.Append("  , dirt_twentytwo_sita_kaisuu_one")
        SelectQuery.Append("  , dirt_twentytwo_sita_kaisuu_two")
        SelectQuery.Append("  , dirt_twentytwo_sita_kaisuu_three")
        SelectQuery.Append("  , dirt_twentytwo_sita_kaisuu_four")
        SelectQuery.Append("  , dirt_twentytwo_sita_kaisuu_five")
        SelectQuery.Append("  , dirt_twentytwo_sita_kaisuu_six")
        SelectQuery.Append("  , dirt_twentytwo_ue_kaisuu_one")
        SelectQuery.Append("  , dirt_twentytwo_ue_kaisuu_two")
        SelectQuery.Append("  , dirt_twentytwo_ue_kaisuu_three")
        SelectQuery.Append("  , dirt_twentytwo_ue_kaisuu_four")
        SelectQuery.Append("  , dirt_twentytwo_ue_kaisuu_five")
        SelectQuery.Append("  , dirt_twentytwo_ue_kaisuu_six ")
        SelectQuery.Append("FROM")
        SelectQuery.Append("  jv_um_uma ")
        SelectQuery.Append("WHERE")
        SelectQuery.Append("  ketto_num = ?val2")

        Return SelectQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　TYAKUSA_NINKI 着差人気平均テーブルInsert文発行
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 着差人気平均テーブルInsert文
    '------------------------------------------------------------------------
    Public Function TyakusaNinkiInsert() As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("INSERT INTO tyakusa_ninki (")
        InsertQuery.Append(" id,")
        InsertQuery.Append(" ketto_num,")
        InsertQuery.Append(" kakutei_jyuni_average,")
        InsertQuery.Append(" ninki_average,")
        InsertQuery.Append(" time_diff_average )")
        InsertQuery.Append(" VALUES(")
        InsertQuery.Append(" ?val1,")
        InsertQuery.Append(" ?val2,")
        InsertQuery.Append(" ?val3,")
        InsertQuery.Append(" ?val4,")
        InsertQuery.Append(" ?val5 )")

        Return InsertQuery.ToString

    End Function


    '------------------------------------------------------------------------
    '　　TYAKUSA_NINKI 着差人気平均テーブルUpdate文発行
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 着差人気平均テーブルUpdate文
    '------------------------------------------------------------------------
    Public Function TyakusaNinkiUpdate() As String

        ' StringBuilder クラスの新しいインスタンスを生成する
        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE tyakusa_ninki ")
        UpdateQuery.Append(" SET")
        UpdateQuery.Append("  kakutei_jyuni_average = ?val1")
        UpdateQuery.Append("  , ninki_average = ?val2")
        UpdateQuery.Append("  , time_diff_average = ?val3")
        UpdateQuery.Append(" WHERE")
        UpdateQuery.Append("  id = ?val4")

        Return UpdateQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　KAIME 買い目テーブルInsert文発行
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 買い目テーブルInsert文
    '------------------------------------------------------------------------
    Public Function KaimeInsert() As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("INSERT INTO kaime (")
        InsertQuery.Append(" race_id,")
        InsertQuery.Append(" kaime_kumiawase_list,")
        InsertQuery.Append(" ten_suu,")
        InsertQuery.Append(" kaime_kumiawase_list_sanren,")
        InsertQuery.Append(" ten_suu_sanren )")
        InsertQuery.Append(" VALUES(")
        InsertQuery.Append(" ?val1,")
        InsertQuery.Append(" ?val2,")
        InsertQuery.Append(" ?val3,")
        InsertQuery.Append(" ?val4,")
        InsertQuery.Append(" ?val5 )")

        Return InsertQuery.ToString

    End Function


    '------------------------------------------------------------------------
    '　　KAIME 買い目テーブルUpdate文発行
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 買い目テーブルUpdate文
    '------------------------------------------------------------------------
    Public Function KaimeUpdate() As String

        ' StringBuilder クラスの新しいインスタンスを生成する
        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE kaime ")
        UpdateQuery.Append(" SET")
        UpdateQuery.Append("  kaime_kumiawase_list = ?val1")
        UpdateQuery.Append("  , ten_suu = ?val2")
        UpdateQuery.Append("  , kaime_kumiawase_list_sanren = ?val3")
        UpdateQuery.Append("  , ten_suu_sanren = ?val4")
        UpdateQuery.Append(" WHERE")
        UpdateQuery.Append("  race_id = ?val5")

        Return UpdateQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateSanrenpukuAnalysisSelect1(ByVal jyuryou As String, ByVal jyoken As String) As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("count(a.sanrenpuku_one_harai_modoshi) total ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("( ")
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("race.keibajyo keibajyo, ")
        InsertQuery.Append("race.syubetu_cd syubetu_cd, ")
        InsertQuery.Append("race.kigo_cd kigo_cd, ")
        InsertQuery.Append("race.jyoken_cd jyoken_cd, ")
        InsertQuery.Append("race.jyuryo_cd jyuryo_cd, ")
        InsertQuery.Append("race.grade_cd grade_cd, ")
        InsertQuery.Append("race.kyori kyori, ")
        InsertQuery.Append("race.track_cd track_cd, ")
        InsertQuery.Append("race.tenko_cd tenko_cd, ")
        InsertQuery.Append("race.baba_cd baba_cd, ")
        InsertQuery.Append("pay.umaren_one_harai_modoshi umaren_one_harai_modoshi, ")
        InsertQuery.Append("pay.umaren_one_ninki umaren_one_ninki, ")
        InsertQuery.Append("pay.sanrenpuku_one_harai_modoshi sanrenpuku_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrenpuku_one_ninki sanrenpuku_one_ninki, ")
        InsertQuery.Append("pay.sanrentan_one_harai_modoshi sanrentan_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrentan_one_ninki sanrentan_one_ninki ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("jv_ra_race race ")
        InsertQuery.Append("INNER JOIN ")
        InsertQuery.Append("jv_hr_pay pay ")
        InsertQuery.Append("ON ")
        InsertQuery.Append("race.race_id = pay.race_id ")
        InsertQuery.Append(") a ")
        InsertQuery.Append("WHERE a.jyuryo_cd = '")
        InsertQuery.Append(jyuryou)
        InsertQuery.Append("' AND a.jyoken_cd = '")
        InsertQuery.Append(jyoken)
        InsertQuery.Append("'")

        Return InsertQuery.ToString

    End Function


    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateSanrenpukuAnalysisSelect2(ByVal ninki As String, ByVal jyuryou As String, ByVal jyoken As String) As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("avg(a.sanrenpuku_one_harai_modoshi) sanrenpuku ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("( ")
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("race.keibajyo keibajyo, ")
        InsertQuery.Append("race.syubetu_cd syubetu_cd, ")
        InsertQuery.Append("race.kigo_cd kigo_cd, ")
        InsertQuery.Append("race.jyoken_cd jyoken_cd, ")
        InsertQuery.Append("race.jyuryo_cd jyuryo_cd, ")
        InsertQuery.Append("race.grade_cd grade_cd, ")
        InsertQuery.Append("race.kyori kyori, ")
        InsertQuery.Append("race.track_cd track_cd, ")
        InsertQuery.Append("race.tenko_cd tenko_cd, ")
        InsertQuery.Append("race.baba_cd baba_cd, ")
        InsertQuery.Append("pay.umaren_one_harai_modoshi umaren_one_harai_modoshi, ")
        InsertQuery.Append("pay.umaren_one_ninki umaren_one_ninki, ")
        InsertQuery.Append("pay.sanrenpuku_one_harai_modoshi sanrenpuku_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrenpuku_one_ninki sanrenpuku_one_ninki, ")
        InsertQuery.Append("pay.sanrentan_one_harai_modoshi sanrentan_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrentan_one_ninki sanrentan_one_ninki ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("jv_ra_race race ")
        InsertQuery.Append("INNER JOIN ")
        InsertQuery.Append("jv_hr_pay pay ")
        InsertQuery.Append("ON ")
        InsertQuery.Append("race.race_id = pay.race_id ")
        InsertQuery.Append(") a ")
        InsertQuery.Append("WHERE a.jyuryo_cd = '")
        InsertQuery.Append(jyuryou)
        InsertQuery.Append("' AND a.sanrenpuku_one_ninki = '")
        InsertQuery.Append(ninki)
        InsertQuery.Append("' AND a.jyoken_cd = '")
        InsertQuery.Append(jyoken)
        InsertQuery.Append("'")

        Return InsertQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateSanrenpukuAnalysisSelect3(ByVal ninki As String, ByVal jyuryou As String, ByVal jyoken As String) As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("count(a.sanrenpuku_one_harai_modoshi) count ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("( ")
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("race.keibajyo keibajyo, ")
        InsertQuery.Append("race.syubetu_cd syubetu_cd, ")
        InsertQuery.Append("race.kigo_cd kigo_cd, ")
        InsertQuery.Append("race.jyoken_cd jyoken_cd, ")
        InsertQuery.Append("race.jyuryo_cd jyuryo_cd, ")
        InsertQuery.Append("race.grade_cd grade_cd, ")
        InsertQuery.Append("race.kyori kyori, ")
        InsertQuery.Append("race.track_cd track_cd, ")
        InsertQuery.Append("race.tenko_cd tenko_cd, ")
        InsertQuery.Append("race.baba_cd baba_cd, ")
        InsertQuery.Append("pay.umaren_one_harai_modoshi umaren_one_harai_modoshi, ")
        InsertQuery.Append("pay.umaren_one_ninki umaren_one_ninki, ")
        InsertQuery.Append("pay.sanrenpuku_one_harai_modoshi sanrenpuku_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrenpuku_one_ninki sanrenpuku_one_ninki, ")
        InsertQuery.Append("pay.sanrentan_one_harai_modoshi sanrentan_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrentan_one_ninki sanrentan_one_ninki ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("jv_ra_race race ")
        InsertQuery.Append("INNER JOIN ")
        InsertQuery.Append("jv_hr_pay pay ")
        InsertQuery.Append("ON ")
        InsertQuery.Append("race.race_id = pay.race_id ")
        InsertQuery.Append(") a ")
        InsertQuery.Append("WHERE a.jyuryo_cd = '")
        InsertQuery.Append(jyuryou)
        InsertQuery.Append("' AND a.sanrenpuku_one_ninki = '")
        InsertQuery.Append(ninki)
        InsertQuery.Append("' AND a.jyoken_cd = '")
        InsertQuery.Append(jyoken)
        InsertQuery.Append("'")

        Return InsertQuery.ToString

    End Function


    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateUmarenAnalysisSelect1(ByVal jyuryou As String, ByVal jyoken As String) As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("count(a.umaren_one_harai_modoshi) total ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("( ")
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("race.keibajyo keibajyo, ")
        InsertQuery.Append("race.syubetu_cd syubetu_cd, ")
        InsertQuery.Append("race.kigo_cd kigo_cd, ")
        InsertQuery.Append("race.jyoken_cd jyoken_cd, ")
        InsertQuery.Append("race.jyuryo_cd jyuryo_cd, ")
        InsertQuery.Append("race.grade_cd grade_cd, ")
        InsertQuery.Append("race.kyori kyori, ")
        InsertQuery.Append("race.track_cd track_cd, ")
        InsertQuery.Append("race.tenko_cd tenko_cd, ")
        InsertQuery.Append("race.baba_cd baba_cd, ")
        InsertQuery.Append("pay.umaren_one_harai_modoshi umaren_one_harai_modoshi, ")
        InsertQuery.Append("pay.umaren_one_ninki umaren_one_ninki, ")
        InsertQuery.Append("pay.sanrenpuku_one_harai_modoshi sanrenpuku_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrenpuku_one_ninki sanrenpuku_one_ninki, ")
        InsertQuery.Append("pay.sanrentan_one_harai_modoshi sanrentan_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrentan_one_ninki sanrentan_one_ninki ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("jv_ra_race race ")
        InsertQuery.Append("INNER JOIN ")
        InsertQuery.Append("jv_hr_pay pay ")
        InsertQuery.Append("ON ")
        InsertQuery.Append("race.race_id = pay.race_id ")
        InsertQuery.Append(") a ")
        InsertQuery.Append("WHERE a.jyuryo_cd = '")
        InsertQuery.Append(jyuryou)
        InsertQuery.Append("' AND a.jyoken_cd = '")
        InsertQuery.Append(jyoken)
        InsertQuery.Append("'")

        Return InsertQuery.ToString

    End Function


    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateUmarenAnalysisSelect2(ByVal ninki As String, ByVal jyuryou As String, ByVal jyoken As String) As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("avg(a.umaren_one_harai_modoshi) umaren ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("( ")
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("race.keibajyo keibajyo, ")
        InsertQuery.Append("race.syubetu_cd syubetu_cd, ")
        InsertQuery.Append("race.kigo_cd kigo_cd, ")
        InsertQuery.Append("race.jyoken_cd jyoken_cd, ")
        InsertQuery.Append("race.jyuryo_cd jyuryo_cd, ")
        InsertQuery.Append("race.grade_cd grade_cd, ")
        InsertQuery.Append("race.kyori kyori, ")
        InsertQuery.Append("race.track_cd track_cd, ")
        InsertQuery.Append("race.tenko_cd tenko_cd, ")
        InsertQuery.Append("race.baba_cd baba_cd, ")
        InsertQuery.Append("pay.umaren_one_harai_modoshi umaren_one_harai_modoshi, ")
        InsertQuery.Append("pay.umaren_one_ninki umaren_one_ninki, ")
        InsertQuery.Append("pay.sanrenpuku_one_harai_modoshi sanrenpuku_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrenpuku_one_ninki sanrenpuku_one_ninki, ")
        InsertQuery.Append("pay.sanrentan_one_harai_modoshi sanrentan_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrentan_one_ninki sanrentan_one_ninki ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("jv_ra_race race ")
        InsertQuery.Append("INNER JOIN ")
        InsertQuery.Append("jv_hr_pay pay ")
        InsertQuery.Append("ON ")
        InsertQuery.Append("race.race_id = pay.race_id ")
        InsertQuery.Append(") a ")
        InsertQuery.Append("WHERE a.jyuryo_cd = '")
        InsertQuery.Append(jyuryou)
        InsertQuery.Append("' AND a.umaren_one_ninki = '")
        InsertQuery.Append(ninki)
        InsertQuery.Append("' AND a.jyoken_cd = '")
        InsertQuery.Append(jyoken)
        InsertQuery.Append("'")

        Return InsertQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateUmarenAnalysisSelect3(ByVal ninki As String, ByVal jyuryou As String, ByVal jyoken As String) As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("count(a.umaren_one_harai_modoshi) count ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("( ")
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("race.keibajyo keibajyo, ")
        InsertQuery.Append("race.syubetu_cd syubetu_cd, ")
        InsertQuery.Append("race.kigo_cd kigo_cd, ")
        InsertQuery.Append("race.jyoken_cd jyoken_cd, ")
        InsertQuery.Append("race.jyuryo_cd jyuryo_cd, ")
        InsertQuery.Append("race.grade_cd grade_cd, ")
        InsertQuery.Append("race.kyori kyori, ")
        InsertQuery.Append("race.track_cd track_cd, ")
        InsertQuery.Append("race.tenko_cd tenko_cd, ")
        InsertQuery.Append("race.baba_cd baba_cd, ")
        InsertQuery.Append("pay.umaren_one_harai_modoshi umaren_one_harai_modoshi, ")
        InsertQuery.Append("pay.umaren_one_ninki umaren_one_ninki, ")
        InsertQuery.Append("pay.sanrenpuku_one_harai_modoshi sanrenpuku_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrenpuku_one_ninki sanrenpuku_one_ninki, ")
        InsertQuery.Append("pay.sanrentan_one_harai_modoshi sanrentan_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrentan_one_ninki sanrentan_one_ninki ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("jv_ra_race race ")
        InsertQuery.Append("INNER JOIN ")
        InsertQuery.Append("jv_hr_pay pay ")
        InsertQuery.Append("ON ")
        InsertQuery.Append("race.race_id = pay.race_id ")
        InsertQuery.Append(") a ")
        InsertQuery.Append("WHERE a.jyuryo_cd = '")
        InsertQuery.Append(jyuryou)
        InsertQuery.Append("' AND a.umaren_one_ninki = '")
        InsertQuery.Append(ninki)
        InsertQuery.Append("' AND a.jyoken_cd = '")
        InsertQuery.Append(jyoken)
        InsertQuery.Append("'")

        Return InsertQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateSanrentanAnalysisSelect1(ByVal jyuryou As String, ByVal jyoken As String) As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("count(a.sanrentan_one_harai_modoshi) total ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("( ")
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("race.keibajyo keibajyo, ")
        InsertQuery.Append("race.syubetu_cd syubetu_cd, ")
        InsertQuery.Append("race.kigo_cd kigo_cd, ")
        InsertQuery.Append("race.jyoken_cd jyoken_cd, ")
        InsertQuery.Append("race.jyuryo_cd jyuryo_cd, ")
        InsertQuery.Append("race.grade_cd grade_cd, ")
        InsertQuery.Append("race.kyori kyori, ")
        InsertQuery.Append("race.track_cd track_cd, ")
        InsertQuery.Append("race.tenko_cd tenko_cd, ")
        InsertQuery.Append("race.baba_cd baba_cd, ")
        InsertQuery.Append("pay.umaren_one_harai_modoshi umaren_one_harai_modoshi, ")
        InsertQuery.Append("pay.umaren_one_ninki umaren_one_ninki, ")
        InsertQuery.Append("pay.sanrenpuku_one_harai_modoshi sanrenpuku_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrenpuku_one_ninki sanrenpuku_one_ninki, ")
        InsertQuery.Append("pay.sanrentan_one_harai_modoshi sanrentan_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrentan_one_ninki sanrentan_one_ninki ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("jv_ra_race race ")
        InsertQuery.Append("INNER JOIN ")
        InsertQuery.Append("jv_hr_pay pay ")
        InsertQuery.Append("ON ")
        InsertQuery.Append("race.race_id = pay.race_id ")
        InsertQuery.Append(") a ")
        InsertQuery.Append("WHERE a.jyuryo_cd = '")
        InsertQuery.Append(jyuryou)
        InsertQuery.Append("' AND a.jyoken_cd = '")
        InsertQuery.Append(jyoken)
        InsertQuery.Append("'")

        Return InsertQuery.ToString

    End Function


    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateSanrentanAnalysisSelect2(ByVal ninki As String, ByVal jyuryou As String, ByVal jyoken As String) As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("avg(a.sanrentan_one_harai_modoshi) sanrentan ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("( ")
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("race.keibajyo keibajyo, ")
        InsertQuery.Append("race.syubetu_cd syubetu_cd, ")
        InsertQuery.Append("race.kigo_cd kigo_cd, ")
        InsertQuery.Append("race.jyoken_cd jyoken_cd, ")
        InsertQuery.Append("race.jyuryo_cd jyuryo_cd, ")
        InsertQuery.Append("race.grade_cd grade_cd, ")
        InsertQuery.Append("race.kyori kyori, ")
        InsertQuery.Append("race.track_cd track_cd, ")
        InsertQuery.Append("race.tenko_cd tenko_cd, ")
        InsertQuery.Append("race.baba_cd baba_cd, ")
        InsertQuery.Append("pay.umaren_one_harai_modoshi umaren_one_harai_modoshi, ")
        InsertQuery.Append("pay.umaren_one_ninki umaren_one_ninki, ")
        InsertQuery.Append("pay.sanrenpuku_one_harai_modoshi sanrenpuku_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrenpuku_one_ninki sanrenpuku_one_ninki, ")
        InsertQuery.Append("pay.sanrentan_one_harai_modoshi sanrentan_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrentan_one_ninki sanrentan_one_ninki ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("jv_ra_race race ")
        InsertQuery.Append("INNER JOIN ")
        InsertQuery.Append("jv_hr_pay pay ")
        InsertQuery.Append("ON ")
        InsertQuery.Append("race.race_id = pay.race_id ")
        InsertQuery.Append(") a ")
        InsertQuery.Append("WHERE a.jyuryo_cd = '")
        InsertQuery.Append(jyuryou)
        InsertQuery.Append("' AND a.sanrentan_one_ninki = '")
        InsertQuery.Append(ninki)
        InsertQuery.Append("' AND a.jyoken_cd = '")
        InsertQuery.Append(jyoken)
        InsertQuery.Append("'")

        Return InsertQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateSanrentanAnalysisSelect3(ByVal ninki As String, ByVal jyuryou As String, ByVal jyoken As String) As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("count(a.sanrentan_one_harai_modoshi) count ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("( ")
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("race.keibajyo keibajyo, ")
        InsertQuery.Append("race.syubetu_cd syubetu_cd, ")
        InsertQuery.Append("race.kigo_cd kigo_cd, ")
        InsertQuery.Append("race.jyoken_cd jyoken_cd, ")
        InsertQuery.Append("race.jyuryo_cd jyuryo_cd, ")
        InsertQuery.Append("race.grade_cd grade_cd, ")
        InsertQuery.Append("race.kyori kyori, ")
        InsertQuery.Append("race.track_cd track_cd, ")
        InsertQuery.Append("race.tenko_cd tenko_cd, ")
        InsertQuery.Append("race.baba_cd baba_cd, ")
        InsertQuery.Append("pay.umaren_one_harai_modoshi umaren_one_harai_modoshi, ")
        InsertQuery.Append("pay.umaren_one_ninki umaren_one_ninki, ")
        InsertQuery.Append("pay.sanrenpuku_one_harai_modoshi sanrenpuku_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrenpuku_one_ninki sanrenpuku_one_ninki, ")
        InsertQuery.Append("pay.sanrentan_one_harai_modoshi sanrentan_one_harai_modoshi, ")
        InsertQuery.Append("pay.sanrentan_one_ninki sanrentan_one_ninki ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("jv_ra_race race ")
        InsertQuery.Append("INNER JOIN ")
        InsertQuery.Append("jv_hr_pay pay ")
        InsertQuery.Append("ON ")
        InsertQuery.Append("race.race_id = pay.race_id ")
        InsertQuery.Append(") a ")
        InsertQuery.Append("WHERE a.jyuryo_cd = '")
        InsertQuery.Append(jyuryou)
        InsertQuery.Append("' AND a.sanrentan_one_ninki = '")
        InsertQuery.Append(ninki)
        InsertQuery.Append("' AND a.jyoken_cd = '")
        InsertQuery.Append(jyoken)
        InsertQuery.Append("'")

        Return InsertQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateNinkiAnalysisSelect(ByVal KeibajyoCode As String, ByVal JyuryoShubetuCd As String, ByVal KyosouJyoukenCd As String) As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("  count(*) count ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("  (  ")
        InsertQuery.Append("    SELECT ")
        InsertQuery.Append("      a.id id ")
        InsertQuery.Append("      , a.race_id race_id ")
        InsertQuery.Append("      , a.ketto_num ketto_num ")
        InsertQuery.Append("      , a.bamei bamei ")
        InsertQuery.Append("      , a.futan futan ")
        InsertQuery.Append("      , a.ba_taijyu ba_taijyu ")
        InsertQuery.Append("      , a.zougen zougen ")
        InsertQuery.Append("      , i_jyo i_jyo ")
        InsertQuery.Append("      , a.kyakusitu kyakusitu ")
        InsertQuery.Append("      , a.jyuni_one_c jyuni_one_c ")
        InsertQuery.Append("      , a.jyuni_two_c jyuni_two_c ")
        InsertQuery.Append("      , a.jyuni_three_c jyuni_three_c ")
        InsertQuery.Append("      , a.jyuni_four_c jyuni_four_c ")
        InsertQuery.Append("      , a.kakutei_jyuni kakutei_jyuni ")
        InsertQuery.Append("      , a.ninki ninki ")
        InsertQuery.Append("      , a.dochaku_kubun dochaku_kubun ")
        InsertQuery.Append("      , a.dochaku_tosu dochaku_tosu ")
        InsertQuery.Append("      , a.souha_time souha_time ")
        InsertQuery.Append("      , a.tansho_odds tansho_odds ")
        InsertQuery.Append("      , a.haron_last haron_last ")
        InsertQuery.Append("      , a.time_diff time_diff ")
        InsertQuery.Append("      , a.data_kubun data_kubun ")
        InsertQuery.Append("      , a.data_sakusei_day data_sakusei_day ")
        InsertQuery.Append("      , b.kakutei_jyuni_average kakutei_jyuni_average ")
        InsertQuery.Append("      , b.ninki_average ninki_average ")
        InsertQuery.Append("      , b.time_diff_average time_diff_average  ")
        InsertQuery.Append("      , d.jyoken_cd jyoken_cd  ")
        InsertQuery.Append("      , d.jyuryo_cd jyuryo_cd  ")
        InsertQuery.Append("    FROM ")
        InsertQuery.Append("      jv_se_race_uma a  ")
        InsertQuery.Append("      LEFT JOIN tyakusa_ninki b  ")
        InsertQuery.Append("        ON a.id = b.id  ")
        InsertQuery.Append("      LEFT JOIN jv_ra_race d ")
        InsertQuery.Append("        ON a.race_id = d.race_id ")
        InsertQuery.Append("    WHERE ")
        InsertQuery.Append("      kakutei_jyuni_average Is Not NULL ")
        InsertQuery.Append("  ) c  ")
        InsertQuery.Append("WHERE ")
        InsertQuery.Append("  c.ninki_average > ?val1 ")
        InsertQuery.Append("  And c.ninki_average <= ?val2  ")
        InsertQuery.Append("  And c.kakutei_jyuni = ?val3 ")
        If "".Equals(KeibajyoCode) Then
        Else
            InsertQuery.Append("  And SUBSTRING( c.id, 9, 2 ) = '")
            InsertQuery.Append(KeibajyoCode)
            InsertQuery.Append("'")
        End If
        If "".Equals(JyuryoShubetuCd) Then
        Else
            InsertQuery.Append("  And c.jyuryo_cd = '")
            InsertQuery.Append(JyuryoShubetuCd)
            InsertQuery.Append("'")
        End If
        If "".Equals(KyosouJyoukenCd) Then
        Else
            InsertQuery.Append("  And c.jyoken_cd = '")
            InsertQuery.Append(KyosouJyoukenCd)
            InsertQuery.Append("'")
        End If
        Return InsertQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateNinkiAnalysisAllSelect(ByVal KeibajyoCode As String, ByVal JyuryoShubetuCd As String, ByVal KyosouJyoukenCd As String) As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("  count(*) count ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("  (  ")
        InsertQuery.Append("    SELECT ")
        InsertQuery.Append("      a.id id ")
        InsertQuery.Append("      , a.race_id race_id ")
        InsertQuery.Append("      , a.ketto_num ketto_num ")
        InsertQuery.Append("      , a.bamei bamei ")
        InsertQuery.Append("      , a.futan futan ")
        InsertQuery.Append("      , a.ba_taijyu ba_taijyu ")
        InsertQuery.Append("      , a.zougen zougen ")
        InsertQuery.Append("      , i_jyo i_jyo ")
        InsertQuery.Append("      , a.kyakusitu kyakusitu ")
        InsertQuery.Append("      , a.jyuni_one_c jyuni_one_c ")
        InsertQuery.Append("      , a.jyuni_two_c jyuni_two_c ")
        InsertQuery.Append("      , a.jyuni_three_c jyuni_three_c ")
        InsertQuery.Append("      , a.jyuni_four_c jyuni_four_c ")
        InsertQuery.Append("      , a.kakutei_jyuni kakutei_jyuni ")
        InsertQuery.Append("      , a.ninki ninki ")
        InsertQuery.Append("      , a.dochaku_kubun dochaku_kubun ")
        InsertQuery.Append("      , a.dochaku_tosu dochaku_tosu ")
        InsertQuery.Append("      , a.souha_time souha_time ")
        InsertQuery.Append("      , a.tansho_odds tansho_odds ")
        InsertQuery.Append("      , a.haron_last haron_last ")
        InsertQuery.Append("      , a.time_diff time_diff ")
        InsertQuery.Append("      , a.data_kubun data_kubun ")
        InsertQuery.Append("      , a.data_sakusei_day data_sakusei_day ")
        InsertQuery.Append("      , b.kakutei_jyuni_average kakutei_jyuni_average ")
        InsertQuery.Append("      , b.ninki_average ninki_average ")
        InsertQuery.Append("      , b.time_diff_average time_diff_average  ")
        InsertQuery.Append("      , d.jyoken_cd jyoken_cd  ")
        InsertQuery.Append("      , d.jyuryo_cd jyuryo_cd  ")
        InsertQuery.Append("    FROM ")
        InsertQuery.Append("      jv_se_race_uma a  ")
        InsertQuery.Append("      LEFT JOIN tyakusa_ninki b  ")
        InsertQuery.Append("        ON a.id = b.id  ")
        InsertQuery.Append("      LEFT JOIN jv_ra_race d ")
        InsertQuery.Append("        ON a.race_id = d.race_id ")
        InsertQuery.Append("    WHERE ")
        InsertQuery.Append("      kakutei_jyuni_average Is Not NULL ")
        InsertQuery.Append("  ) c  ")
        InsertQuery.Append("WHERE ")
        InsertQuery.Append("  c.ninki_average > ?val1 ")
        InsertQuery.Append("  And c.ninki_average <= ?val2  ")
        If "".Equals(KeibajyoCode) Then
        Else
            InsertQuery.Append("  And SUBSTRING( c.id, 9, 2 ) = '")
            InsertQuery.Append(KeibajyoCode)
            InsertQuery.Append("'")
        End If
        If "".Equals(JyuryoShubetuCd) Then
        Else
            InsertQuery.Append("  And c.jyuryo_cd = '")
            InsertQuery.Append(JyuryoShubetuCd)
            InsertQuery.Append("'")
        End If
        If "".Equals(KyosouJyoukenCd) Then
        Else
            InsertQuery.Append("  And c.jyoken_cd = '")
            InsertQuery.Append(KyosouJyoukenCd)
            InsertQuery.Append("'")
        End If
        Return InsertQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateTyakujyunAnalysisSelect(ByVal KeibajyoCode As String, ByVal JyuryoShubetuCd As String, ByVal KyosouJyoukenCd As String) As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("  count(*) count ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("  (  ")
        InsertQuery.Append("    SELECT ")
        InsertQuery.Append("      a.id id ")
        InsertQuery.Append("      , a.race_id race_id ")
        InsertQuery.Append("      , a.ketto_num ketto_num ")
        InsertQuery.Append("      , a.bamei bamei ")
        InsertQuery.Append("      , a.futan futan ")
        InsertQuery.Append("      , a.ba_taijyu ba_taijyu ")
        InsertQuery.Append("      , a.zougen zougen ")
        InsertQuery.Append("      , i_jyo i_jyo ")
        InsertQuery.Append("      , a.kyakusitu kyakusitu ")
        InsertQuery.Append("      , a.jyuni_one_c jyuni_one_c ")
        InsertQuery.Append("      , a.jyuni_two_c jyuni_two_c ")
        InsertQuery.Append("      , a.jyuni_three_c jyuni_three_c ")
        InsertQuery.Append("      , a.jyuni_four_c jyuni_four_c ")
        InsertQuery.Append("      , a.kakutei_jyuni kakutei_jyuni ")
        InsertQuery.Append("      , a.ninki ninki ")
        InsertQuery.Append("      , a.dochaku_kubun dochaku_kubun ")
        InsertQuery.Append("      , a.dochaku_tosu dochaku_tosu ")
        InsertQuery.Append("      , a.souha_time souha_time ")
        InsertQuery.Append("      , a.tansho_odds tansho_odds ")
        InsertQuery.Append("      , a.haron_last haron_last ")
        InsertQuery.Append("      , a.time_diff time_diff ")
        InsertQuery.Append("      , a.data_kubun data_kubun ")
        InsertQuery.Append("      , a.data_sakusei_day data_sakusei_day ")
        InsertQuery.Append("      , b.kakutei_jyuni_average kakutei_jyuni_average ")
        InsertQuery.Append("      , b.ninki_average ninki_average ")
        InsertQuery.Append("      , b.time_diff_average time_diff_average  ")
        InsertQuery.Append("      , d.jyoken_cd jyoken_cd  ")
        InsertQuery.Append("      , d.jyuryo_cd jyuryo_cd  ")
        InsertQuery.Append("    FROM ")
        InsertQuery.Append("      jv_se_race_uma a  ")
        InsertQuery.Append("      LEFT JOIN tyakusa_ninki b  ")
        InsertQuery.Append("        ON a.id = b.id  ")
        InsertQuery.Append("      LEFT JOIN jv_ra_race d ")
        InsertQuery.Append("        ON a.race_id = d.race_id ")
        InsertQuery.Append("    WHERE ")
        InsertQuery.Append("      kakutei_jyuni_average IS NOT NULL ")
        InsertQuery.Append("  ) c  ")
        InsertQuery.Append("WHERE ")
        InsertQuery.Append("  c.kakutei_jyuni_average > ?val1 ")
        InsertQuery.Append("  AND c.kakutei_jyuni_average <= ?val2  ")
        InsertQuery.Append("  AND c.kakutei_jyuni = ?val3 ")
        If "".Equals(KeibajyoCode) Then
        Else
            InsertQuery.Append("  And SUBSTRING( c.id, 9, 2 ) = '")
            InsertQuery.Append(KeibajyoCode)
            InsertQuery.Append("'")
        End If
        If "".Equals(JyuryoShubetuCd) Then
        Else
            InsertQuery.Append("  And c.jyuryo_cd = '")
            InsertQuery.Append(JyuryoShubetuCd)
            InsertQuery.Append("'")
        End If
        If "".Equals(KyosouJyoukenCd) Then
        Else
            InsertQuery.Append("  And c.jyoken_cd = '")
            InsertQuery.Append(KyosouJyoukenCd)
            InsertQuery.Append("'")
        End If
        Return InsertQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateTyakujyunAnalysisAllSelect(ByVal KeibajyoCode As String, ByVal JyuryoShubetuCd As String, ByVal KyosouJyoukenCd As String) As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("  count(*) count ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("  (  ")
        InsertQuery.Append("    SELECT ")
        InsertQuery.Append("      a.id id ")
        InsertQuery.Append("      , a.race_id race_id ")
        InsertQuery.Append("      , a.ketto_num ketto_num ")
        InsertQuery.Append("      , a.bamei bamei ")
        InsertQuery.Append("      , a.futan futan ")
        InsertQuery.Append("      , a.ba_taijyu ba_taijyu ")
        InsertQuery.Append("      , a.zougen zougen ")
        InsertQuery.Append("      , i_jyo i_jyo ")
        InsertQuery.Append("      , a.kyakusitu kyakusitu ")
        InsertQuery.Append("      , a.jyuni_one_c jyuni_one_c ")
        InsertQuery.Append("      , a.jyuni_two_c jyuni_two_c ")
        InsertQuery.Append("      , a.jyuni_three_c jyuni_three_c ")
        InsertQuery.Append("      , a.jyuni_four_c jyuni_four_c ")
        InsertQuery.Append("      , a.kakutei_jyuni kakutei_jyuni ")
        InsertQuery.Append("      , a.ninki ninki ")
        InsertQuery.Append("      , a.dochaku_kubun dochaku_kubun ")
        InsertQuery.Append("      , a.dochaku_tosu dochaku_tosu ")
        InsertQuery.Append("      , a.souha_time souha_time ")
        InsertQuery.Append("      , a.tansho_odds tansho_odds ")
        InsertQuery.Append("      , a.haron_last haron_last ")
        InsertQuery.Append("      , a.time_diff time_diff ")
        InsertQuery.Append("      , a.data_kubun data_kubun ")
        InsertQuery.Append("      , a.data_sakusei_day data_sakusei_day ")
        InsertQuery.Append("      , b.kakutei_jyuni_average kakutei_jyuni_average ")
        InsertQuery.Append("      , b.ninki_average ninki_average ")
        InsertQuery.Append("      , b.time_diff_average time_diff_average  ")
        InsertQuery.Append("      , d.jyoken_cd jyoken_cd  ")
        InsertQuery.Append("      , d.jyuryo_cd jyuryo_cd  ")
        InsertQuery.Append("    FROM ")
        InsertQuery.Append("      jv_se_race_uma a  ")
        InsertQuery.Append("      LEFT JOIN tyakusa_ninki b  ")
        InsertQuery.Append("        ON a.id = b.id  ")
        InsertQuery.Append("      LEFT JOIN jv_ra_race d ")
        InsertQuery.Append("        ON a.race_id = d.race_id ")
        InsertQuery.Append("    WHERE ")
        InsertQuery.Append("      kakutei_jyuni_average IS NOT NULL ")
        InsertQuery.Append("  ) c  ")
        InsertQuery.Append("WHERE ")
        InsertQuery.Append("  c.kakutei_jyuni_average > ?val1 ")
        InsertQuery.Append("  AND c.kakutei_jyuni_average <= ?val2  ")
        If "".Equals(KeibajyoCode) Then
        Else
            InsertQuery.Append("  And SUBSTRING( c.id, 9, 2 ) = '")
            InsertQuery.Append(KeibajyoCode)
            InsertQuery.Append("'")
        End If
        If "".Equals(JyuryoShubetuCd) Then
        Else
            InsertQuery.Append("  And c.jyuryo_cd = '")
            InsertQuery.Append(JyuryoShubetuCd)
            InsertQuery.Append("'")
        End If
        If "".Equals(KyosouJyoukenCd) Then
        Else
            InsertQuery.Append("  And c.jyoken_cd = '")
            InsertQuery.Append(KyosouJyoukenCd)
            InsertQuery.Append("'")
        End If
        Return InsertQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateTyakusaAnalysisSelect(ByVal KeibajyoCode As String, ByVal JyuryoShubetuCd As String, ByVal KyosouJyoukenCd As String) As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("  count(*) count ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("  (  ")
        InsertQuery.Append("    SELECT ")
        InsertQuery.Append("      a.id id ")
        InsertQuery.Append("      , a.race_id race_id ")
        InsertQuery.Append("      , a.ketto_num ketto_num ")
        InsertQuery.Append("      , a.bamei bamei ")
        InsertQuery.Append("      , a.futan futan ")
        InsertQuery.Append("      , a.ba_taijyu ba_taijyu ")
        InsertQuery.Append("      , a.zougen zougen ")
        InsertQuery.Append("      , i_jyo i_jyo ")
        InsertQuery.Append("      , a.kyakusitu kyakusitu ")
        InsertQuery.Append("      , a.jyuni_one_c jyuni_one_c ")
        InsertQuery.Append("      , a.jyuni_two_c jyuni_two_c ")
        InsertQuery.Append("      , a.jyuni_three_c jyuni_three_c ")
        InsertQuery.Append("      , a.jyuni_four_c jyuni_four_c ")
        InsertQuery.Append("      , a.kakutei_jyuni kakutei_jyuni ")
        InsertQuery.Append("      , a.ninki ninki ")
        InsertQuery.Append("      , a.dochaku_kubun dochaku_kubun ")
        InsertQuery.Append("      , a.dochaku_tosu dochaku_tosu ")
        InsertQuery.Append("      , a.souha_time souha_time ")
        InsertQuery.Append("      , a.tansho_odds tansho_odds ")
        InsertQuery.Append("      , a.haron_last haron_last ")
        InsertQuery.Append("      , a.time_diff time_diff ")
        InsertQuery.Append("      , a.data_kubun data_kubun ")
        InsertQuery.Append("      , a.data_sakusei_day data_sakusei_day ")
        InsertQuery.Append("      , b.kakutei_jyuni_average kakutei_jyuni_average ")
        InsertQuery.Append("      , b.ninki_average ninki_average ")
        InsertQuery.Append("      , b.time_diff_average time_diff_average  ")
        InsertQuery.Append("      , d.jyoken_cd jyoken_cd  ")
        InsertQuery.Append("      , d.jyuryo_cd jyuryo_cd  ")
        InsertQuery.Append("    FROM ")
        InsertQuery.Append("      jv_se_race_uma a  ")
        InsertQuery.Append("      LEFT JOIN tyakusa_ninki b  ")
        InsertQuery.Append("        ON a.id = b.id  ")
        InsertQuery.Append("      LEFT JOIN jv_ra_race d ")
        InsertQuery.Append("        ON a.race_id = d.race_id ")
        InsertQuery.Append("    WHERE ")
        InsertQuery.Append("      kakutei_jyuni_average IS NOT NULL ")
        InsertQuery.Append("  ) c  ")
        InsertQuery.Append("WHERE ")
        InsertQuery.Append("  c.time_diff_average > ?val1 ")
        InsertQuery.Append("  AND c.time_diff_average <= ?val2  ")
        InsertQuery.Append("  AND c.kakutei_jyuni = ?val3 ")
        If "".Equals(KeibajyoCode) Then
        Else
            InsertQuery.Append("  And SUBSTRING( c.id, 9, 2 ) = '")
            InsertQuery.Append(KeibajyoCode)
            InsertQuery.Append("'")
        End If
        If "".Equals(JyuryoShubetuCd) Then
        Else
            InsertQuery.Append("  And c.jyuryo_cd = '")
            InsertQuery.Append(JyuryoShubetuCd)
            InsertQuery.Append("'")
        End If
        If "".Equals(KyosouJyoukenCd) Then
        Else
            InsertQuery.Append("  And c.jyoken_cd = '")
            InsertQuery.Append(KyosouJyoukenCd)
            InsertQuery.Append("'")
        End If
        Return InsertQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateTyakusaAnalysisAllSelect(ByVal KeibajyoCode As String, ByVal JyuryoShubetuCd As String, ByVal KyosouJyoukenCd As String) As String

        Dim InsertQuery As New System.Text.StringBuilder()
        InsertQuery.Append("SELECT ")
        InsertQuery.Append("  count(*) count ")
        InsertQuery.Append("FROM ")
        InsertQuery.Append("  (  ")
        InsertQuery.Append("    SELECT ")
        InsertQuery.Append("      a.id id ")
        InsertQuery.Append("      , a.race_id race_id ")
        InsertQuery.Append("      , a.ketto_num ketto_num ")
        InsertQuery.Append("      , a.bamei bamei ")
        InsertQuery.Append("      , a.futan futan ")
        InsertQuery.Append("      , a.ba_taijyu ba_taijyu ")
        InsertQuery.Append("      , a.zougen zougen ")
        InsertQuery.Append("      , i_jyo i_jyo ")
        InsertQuery.Append("      , a.kyakusitu kyakusitu ")
        InsertQuery.Append("      , a.jyuni_one_c jyuni_one_c ")
        InsertQuery.Append("      , a.jyuni_two_c jyuni_two_c ")
        InsertQuery.Append("      , a.jyuni_three_c jyuni_three_c ")
        InsertQuery.Append("      , a.jyuni_four_c jyuni_four_c ")
        InsertQuery.Append("      , a.kakutei_jyuni kakutei_jyuni ")
        InsertQuery.Append("      , a.ninki ninki ")
        InsertQuery.Append("      , a.dochaku_kubun dochaku_kubun ")
        InsertQuery.Append("      , a.dochaku_tosu dochaku_tosu ")
        InsertQuery.Append("      , a.souha_time souha_time ")
        InsertQuery.Append("      , a.tansho_odds tansho_odds ")
        InsertQuery.Append("      , a.haron_last haron_last ")
        InsertQuery.Append("      , a.time_diff time_diff ")
        InsertQuery.Append("      , a.data_kubun data_kubun ")
        InsertQuery.Append("      , a.data_sakusei_day data_sakusei_day ")
        InsertQuery.Append("      , b.kakutei_jyuni_average kakutei_jyuni_average ")
        InsertQuery.Append("      , b.ninki_average ninki_average ")
        InsertQuery.Append("      , b.time_diff_average time_diff_average  ")
        InsertQuery.Append("      , d.jyoken_cd jyoken_cd  ")
        InsertQuery.Append("      , d.jyuryo_cd jyuryo_cd  ")
        InsertQuery.Append("    FROM ")
        InsertQuery.Append("      jv_se_race_uma a  ")
        InsertQuery.Append("      LEFT JOIN tyakusa_ninki b  ")
        InsertQuery.Append("        ON a.id = b.id  ")
        InsertQuery.Append("      LEFT JOIN jv_ra_race d ")
        InsertQuery.Append("        ON a.race_id = d.race_id ")
        InsertQuery.Append("    WHERE ")
        InsertQuery.Append("      kakutei_jyuni_average IS NOT NULL ")
        InsertQuery.Append("  ) c  ")
        InsertQuery.Append("WHERE ")
        InsertQuery.Append("  c.time_diff_average > ?val1 ")
        InsertQuery.Append("  AND c.time_diff_average <= ?val2  ")
        If "".Equals(KeibajyoCode) Then
        Else
            InsertQuery.Append("  And SUBSTRING( c.id, 9, 2 ) = '")
            InsertQuery.Append(KeibajyoCode)
            InsertQuery.Append("'")
        End If
        If "".Equals(JyuryoShubetuCd) Then
        Else
            InsertQuery.Append("  And c.jyuryo_cd = '")
            InsertQuery.Append(JyuryoShubetuCd)
            InsertQuery.Append("'")
        End If
        If "".Equals(KyosouJyoukenCd) Then
        Else
            InsertQuery.Append("  And c.jyoken_cd = '")
            InsertQuery.Append(KyosouJyoukenCd)
            InsertQuery.Append("'")
        End If
        Return InsertQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    'Public Function CreateBakenAnalysisSelect() As String

    '    Dim SelectQuery As New System.Text.StringBuilder()
    '    SelectQuery.Append("SELECT ")
    '    SelectQuery.Append("  f.year year ")
    '    SelectQuery.Append("  , f.month month ")
    '    SelectQuery.Append("  , f.day day ")
    '    SelectQuery.Append("  , f.keibajyo keibajyo ")
    '    SelectQuery.Append("  , f.race_no race_no ")
    '    SelectQuery.Append("  , f.umaren_one_harai_modoshi umaren_one_harai_modoshi ")
    '    SelectQuery.Append("FROM ")
    '    SelectQuery.Append("( ")
    '    SelectQuery.Append("SELECT ")
    '    SelectQuery.Append("  count(c.kakutei_jyuni) count, ")
    '    SelectQuery.Append("  c.race_id race_id ")
    '    SelectQuery.Append("FROM ")
    '    SelectQuery.Append("  (  ")
    '    SelectQuery.Append("    SELECT ")
    '    SelectQuery.Append("      a.id id ")
    '    SelectQuery.Append("      , a.race_id race_id ")
    '    SelectQuery.Append("      , a.ketto_num ketto_num ")
    '    SelectQuery.Append("      , a.bamei bamei ")
    '    SelectQuery.Append("      , a.futan futan ")
    '    SelectQuery.Append("      , a.ba_taijyu ba_taijyu ")
    '    SelectQuery.Append("      , a.zougen zougen ")
    '    SelectQuery.Append("      , i_jyo i_jyo ")
    '    SelectQuery.Append("      , a.kyakusitu kyakusitu ")
    '    SelectQuery.Append("      , a.jyuni_one_c jyuni_one_c ")
    '    SelectQuery.Append("      , a.jyuni_two_c jyuni_two_c ")
    '    SelectQuery.Append("      , a.jyuni_three_c jyuni_three_c ")
    '    SelectQuery.Append("      , a.jyuni_four_c jyuni_four_c ")
    '    SelectQuery.Append("      , a.kakutei_jyuni kakutei_jyuni ")
    '    SelectQuery.Append("      , a.ninki ninki ")
    '    SelectQuery.Append("      , a.dochaku_kubun dochaku_kubun ")
    '    SelectQuery.Append("      , a.dochaku_tosu dochaku_tosu ")
    '    SelectQuery.Append("      , a.souha_time souha_time ")
    '    SelectQuery.Append("      , a.tansho_odds tansho_odds ")
    '    SelectQuery.Append("      , a.haron_last haron_last ")
    '    SelectQuery.Append("      , a.time_diff time_diff ")
    '    SelectQuery.Append("      , a.data_kubun data_kubun ")
    '    SelectQuery.Append("      , a.data_sakusei_day data_sakusei_day ")
    '    SelectQuery.Append("      , b.kakutei_jyuni_average kakutei_jyuni_average ")
    '    SelectQuery.Append("      , b.ninki_average ninki_average ")
    '    SelectQuery.Append("      , b.time_diff_average time_diff_average ")
    '    SelectQuery.Append("      , b.rank ")
    '    SelectQuery.Append("      , d.jyoken_cd jyoken_cd ")
    '    SelectQuery.Append("      , d.jyuryo_cd jyuryo_cd  ")
    '    SelectQuery.Append("    FROM ")
    '    SelectQuery.Append("      jv_se_race_uma a  ")
    '    SelectQuery.Append("      LEFT JOIN tyakusa_ninki b  ")
    '    SelectQuery.Append("        ON a.id = b.id  ")
    '    SelectQuery.Append("      LEFT JOIN jv_ra_race d  ")
    '    SelectQuery.Append("        ON a.race_id = d.race_id  ")
    '    SelectQuery.Append("    WHERE ")
    '    SelectQuery.Append("      b.kakutei_jyuni_average IS NOT NULL ")
    '    '=============================================================
    '    'TODO ↓の行を後で削除
    '    'SelectQuery.Append("      AND a.race_id LIKE '2016042403%' ")
    '    '=============================================================
    '    SelectQuery.Append("  ) c  ")
    '    SelectQuery.Append("WHERE ")
    '    SelectQuery.Append("  c.rank = 'A'  ")
    '    SelectQuery.Append("  AND c.kakutei_jyuni IN (1, 2)  ")
    '    SelectQuery.Append("GROUP BY ")
    '    SelectQuery.Append("  c.race_id ")
    '    SelectQuery.Append(") e ")
    '    SelectQuery.Append("LEFT JOIN jv_hr_pay f ")
    '    SelectQuery.Append("ON e.race_id = f.race_id ")
    '    SelectQuery.Append("WHERE e.count >= 2 ")
    '    Return SelectQuery.ToString

    'End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 購入馬券数Select文
    '------------------------------------------------------------------------
    'Public Function CreateKounyuuBakenSuuSelect() As String

    '    Dim SelectQuery As New System.Text.StringBuilder()
    '    SelectQuery.Append("SELECT ")
    '    SelectQuery.Append("  a.race_id race_id ")
    '    SelectQuery.Append("  , count(b.rank) count  ")
    '    SelectQuery.Append("FROM ")
    '    SelectQuery.Append("  jv_se_race_uma a  ")
    '    SelectQuery.Append("  LEFT JOIN tyakusa_ninki b  ")
    '    SelectQuery.Append("    ON a.id = b.id  ")
    '    SelectQuery.Append("WHERE ")
    '    SelectQuery.Append("  b.rank = 'A'  ")
    '    '=============================================================
    '    'TODO ↓の行を後で削除
    '    'SelectQuery.Append("      AND a.race_id LIKE '2016042403%' ")
    '    '=============================================================
    '    SelectQuery.Append("GROUP BY ")
    '    SelectQuery.Append("  race_id ")
    '    Return SelectQuery.ToString

    'End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateBakenAnalysisSelect() As String

        Dim SelectQuery As New System.Text.StringBuilder()
        SelectQuery.Append("SELECT ")
        SelectQuery.Append("  a.race_id race_id ")
        SelectQuery.Append("  , a.kaime_kumiawase_list kaime_kumiawase_list ")
        SelectQuery.Append("  , a.ten_suu ten_suu ")
        SelectQuery.Append("  , b.year year ")
        SelectQuery.Append("  , b.month month ")
        SelectQuery.Append("  , b.day day ")
        SelectQuery.Append("  , b.keibajyo keibajyo ")
        SelectQuery.Append("  , b.race_no race_no ")
        SelectQuery.Append("  , b.umaren_one_kumi umaren_one_kumi ")
        SelectQuery.Append("  , b.umaren_one_harai_modoshi umaren_one_harai_modoshi ")
        SelectQuery.Append("  , b.umaren_two_kumi umaren_two_kumi ")
        SelectQuery.Append("  , b.umaren_two_harai_modoshi umaren_two_harai_modoshi ")
        SelectQuery.Append("  , b.umaren_three_kumi umaren_three_kumi ")
        SelectQuery.Append("  , b.umaren_three_harai_modoshi umaren_three_harai_modoshi ")
        SelectQuery.Append("  , b.wide_one_kumi wide_one_kumi ")
        SelectQuery.Append("  , b.wide_one_harai_modoshi wide_one_harai_modoshi ")
        SelectQuery.Append("  , b.wide_two_kumi wide_two_kumi ")
        SelectQuery.Append("  , b.wide_two_harai_modoshi wide_two_harai_modoshi ")
        SelectQuery.Append("  , b.wide_three_kumi wide_three_kumi ")
        SelectQuery.Append("  , b.wide_three_harai_modoshi wide_three_harai_modoshi ")
        SelectQuery.Append("  , b.wide_four_kumi wide_four_kumi ")
        SelectQuery.Append("  , b.wide_four_harai_modoshi wide_four_harai_modoshi ")
        SelectQuery.Append("  , b.wide_five_kumi wide_five_kumi ")
        SelectQuery.Append("  , b.wide_five_harai_modoshi wide_five_harai_modoshi ")
        SelectQuery.Append("  , b.wide_six_kumi wide_six_kumi ")
        SelectQuery.Append("  , b.wide_six_harai_modoshi wide_six_harai_modoshi ")
        SelectQuery.Append("  , b.wide_seven_kumi wide_seven_kumi ")
        SelectQuery.Append("  , b.wide_seven_harai_modoshi wide_seven_harai_modoshi  ")
        SelectQuery.Append("  , b.umatan_one_kumi umatan_one_kumi ")
        SelectQuery.Append("  , b.umatan_one_harai_modoshi umatan_one_harai_modoshi ")
        SelectQuery.Append("  , b.umatan_two_kumi umatan_two_kumi ")
        SelectQuery.Append("  , b.umatan_two_harai_modoshi umatan_two_harai_modoshi ")
        SelectQuery.Append("  , b.umatan_three_kumi umatan_three_kumi ")
        SelectQuery.Append("  , b.umatan_three_harai_modoshi umatan_three_harai_modoshi ")
        SelectQuery.Append("  , b.umatan_four_kumi umatan_four_kumi ")
        SelectQuery.Append("  , b.umatan_four_harai_modoshi umatan_four_harai_modoshi ")
        SelectQuery.Append("  , b.umatan_five_kumi umatan_five_kumi ")
        SelectQuery.Append("  , b.umatan_five_harai_modoshi umatan_five_harai_modoshi ")
        SelectQuery.Append("  , b.umatan_six_kumi umatan_six_kumi ")
        SelectQuery.Append("  , b.umatan_six_harai_modoshi umatan_six_harai_modoshi ")
        SelectQuery.Append("FROM ")
        SelectQuery.Append("  kaime a  ")
        SelectQuery.Append("  INNER JOIN jv_hr_pay b  ")
        SelectQuery.Append("    ON a.race_id = b.race_id ")
        SelectQuery.Append("WHERE a.ten_suu > 0 ")
        Return SelectQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateBakenAnalysisSelect(ByVal year As String, ByVal keibajyo_cd As String) As String

        Dim SelectQuery As New System.Text.StringBuilder()
        SelectQuery.Append("SELECT ")
        SelectQuery.Append("  c.race_id race_id ")
        SelectQuery.Append("  , c.kaime_kumiawase_list kaime_kumiawase_list ")
        SelectQuery.Append("  , c.ten_suu ten_suu ")
        SelectQuery.Append("  , d.year year ")
        SelectQuery.Append("  , d.month month ")
        SelectQuery.Append("  , d.day day ")
        SelectQuery.Append("  , d.keibajyo keibajyo ")
        SelectQuery.Append("  , d.race_no race_no ")
        SelectQuery.Append("  , d.umaren_one_kumi umaren_one_kumi ")
        SelectQuery.Append("  , d.umaren_one_harai_modoshi umaren_one_harai_modoshi ")
        SelectQuery.Append("  , d.umaren_two_kumi umaren_two_kumi ")
        SelectQuery.Append("  , d.umaren_two_harai_modoshi umaren_two_harai_modoshi ")
        SelectQuery.Append("  , d.umaren_three_kumi umaren_three_kumi ")
        SelectQuery.Append("  , d.umaren_three_harai_modoshi umaren_three_harai_modoshi ")
        SelectQuery.Append("  , d.wide_one_kumi wide_one_kumi ")
        SelectQuery.Append("  , d.wide_one_harai_modoshi wide_one_harai_modoshi ")
        SelectQuery.Append("  , d.wide_two_kumi wide_two_kumi ")
        SelectQuery.Append("  , d.wide_two_harai_modoshi wide_two_harai_modoshi ")
        SelectQuery.Append("  , d.wide_three_kumi wide_three_kumi ")
        SelectQuery.Append("  , d.wide_three_harai_modoshi wide_three_harai_modoshi ")
        SelectQuery.Append("  , d.wide_four_kumi wide_four_kumi ")
        SelectQuery.Append("  , d.wide_four_harai_modoshi wide_four_harai_modoshi ")
        SelectQuery.Append("  , d.wide_five_kumi wide_five_kumi ")
        SelectQuery.Append("  , d.wide_five_harai_modoshi wide_five_harai_modoshi ")
        SelectQuery.Append("  , d.wide_six_kumi wide_six_kumi ")
        SelectQuery.Append("  , d.wide_six_harai_modoshi wide_six_harai_modoshi ")
        SelectQuery.Append("  , d.wide_seven_kumi wide_seven_kumi ")
        SelectQuery.Append("  , d.wide_seven_harai_modoshi wide_seven_harai_modoshi  ")
        SelectQuery.Append("  , d.umatan_one_kumi umatan_one_kumi ")
        SelectQuery.Append("  , d.umatan_one_harai_modoshi umatan_one_harai_modoshi ")
        SelectQuery.Append("  , d.umatan_two_kumi umatan_two_kumi ")
        SelectQuery.Append("  , d.umatan_two_harai_modoshi umatan_two_harai_modoshi ")
        SelectQuery.Append("  , d.umatan_three_kumi umatan_three_kumi ")
        SelectQuery.Append("  , d.umatan_three_harai_modoshi umatan_three_harai_modoshi ")
        SelectQuery.Append("  , d.umatan_four_kumi umatan_four_kumi ")
        SelectQuery.Append("  , d.umatan_four_harai_modoshi umatan_four_harai_modoshi ")
        SelectQuery.Append("  , d.umatan_five_kumi umatan_five_kumi ")
        SelectQuery.Append("  , d.umatan_five_harai_modoshi umatan_five_harai_modoshi ")
        SelectQuery.Append("  , d.umatan_six_kumi umatan_six_kumi ")
        SelectQuery.Append("  , d.umatan_six_harai_modoshi umatan_six_harai_modoshi ")
        SelectQuery.Append("FROM ")
        SelectQuery.Append("  (  ")
        SelectQuery.Append("    SELECT ")
        SelectQuery.Append("      a.race_id as race_id ")
        SelectQuery.Append("      , a.kaime_kumiawase_list as kaime_kumiawase_list ")
        SelectQuery.Append("      , a.ten_suu as ten_suu ")
        SelectQuery.Append("      , a.kaime_kumiawase_list_sanren as kaime_kumiawase_list_sanren ")
        SelectQuery.Append("      , a.ten_suu_sanren as ten_suu_sanren ")
        SelectQuery.Append("      , b.keibajyo_code  ")
        SelectQuery.Append("    FROM ")
        SelectQuery.Append("      kaime a  ")
        SelectQuery.Append("      LEFT JOIN (  ")
        SelectQuery.Append("        SELECT ")
        SelectQuery.Append("          race_id ")
        SelectQuery.Append("          , SUBSTRING(race_id, 9, 2) AS keibajyo_code  ")
        SelectQuery.Append("        from ")
        SelectQuery.Append("          kaime ")
        SelectQuery.Append("      ) b  ")
        SelectQuery.Append("        ON a.race_id = b.race_id  ")
        SelectQuery.Append("    WHERE ")
        If "".Equals(keibajyo_cd) Then
            SelectQuery.Append("      b.race_id Like '")
            SelectQuery.Append(year)
            SelectQuery.Append("%' ")
        ElseIf "".Equals(year) Then
            SelectQuery.Append("      b.keibajyo_code = '")
            SelectQuery.Append(keibajyo_cd)
            SelectQuery.Append("' ")
        Else
            SelectQuery.Append("      b.keibajyo_code = '")
            SelectQuery.Append(keibajyo_cd)
            SelectQuery.Append("' ")
            SelectQuery.Append("     AND b.race_id Like '")
            SelectQuery.Append(year)
            SelectQuery.Append("%' ")
        End If
        SelectQuery.Append("  ) c ")
        SelectQuery.Append("  INNER JOIN jv_hr_pay d  ")
        SelectQuery.Append("    ON c.race_id = d.race_id ")
        SelectQuery.Append("WHERE c.ten_suu > 0 ")
        Return SelectQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateBakenAnalysisSanrenSelect() As String

        Dim SelectQuery As New System.Text.StringBuilder()
        SelectQuery.Append("SELECT ")
        SelectQuery.Append("  a.race_id race_id ")
        SelectQuery.Append("  , a.kaime_kumiawase_list_sanren kaime_kumiawase_list_sanren ")
        SelectQuery.Append("  , a.ten_suu_sanren ten_suu_sanren ")
        SelectQuery.Append("  , b.year year ")
        SelectQuery.Append("  , b.month month ")
        SelectQuery.Append("  , b.day day ")
        SelectQuery.Append("  , b.keibajyo keibajyo ")
        SelectQuery.Append("  , b.race_no race_no ")
        SelectQuery.Append("  , b.sanrenpuku_one_kumi sanrenpuku_one_kumi ")
        SelectQuery.Append("  , b.sanrenpuku_one_harai_modoshi sanrenpuku_one_harai_modoshi ")
        SelectQuery.Append("  , b.sanrenpuku_two_kumi sanrenpuku_two_kumi ")
        SelectQuery.Append("  , b.sanrenpuku_two_harai_modoshi sanrenpuku_two_harai_modoshi ")
        SelectQuery.Append("  , b.sanrenpuku_three_kumi sanrenpuku_three_kumi ")
        SelectQuery.Append("  , b.sanrenpuku_three_harai_modoshi sanrenpuku_three_harai_modoshi ")
        SelectQuery.Append("FROM ")
        SelectQuery.Append("  kaime a  ")
        SelectQuery.Append("  INNER JOIN jv_hr_pay b  ")
        SelectQuery.Append("    ON a.race_id = b.race_id ")
        SelectQuery.Append("WHERE a.ten_suu_sanren > 0 ")
        Return SelectQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ************Select文
    '------------------------------------------------------------------------
    Public Function CreateBakenAnalysisSanrenSelect(ByVal year As String, ByVal keibajyo_cd As String) As String

        Dim SelectQuery As New System.Text.StringBuilder()
        SelectQuery.Append("SELECT ")
        SelectQuery.Append("  c.race_id race_id ")
        SelectQuery.Append("  , c.kaime_kumiawase_list_sanren kaime_kumiawase_list_sanren ")
        SelectQuery.Append("  , c.ten_suu_sanren ten_suu_sanren ")
        SelectQuery.Append("  , d.year year ")
        SelectQuery.Append("  , d.month month ")
        SelectQuery.Append("  , d.day day ")
        SelectQuery.Append("  , d.keibajyo keibajyo ")
        SelectQuery.Append("  , d.race_no race_no ")
        SelectQuery.Append("  , d.sanrenpuku_one_kumi sanrenpuku_one_kumi ")
        SelectQuery.Append("  , d.sanrenpuku_one_harai_modoshi sanrenpuku_one_harai_modoshi ")
        SelectQuery.Append("  , d.sanrenpuku_two_kumi sanrenpuku_two_kumi ")
        SelectQuery.Append("  , d.sanrenpuku_two_harai_modoshi sanrenpuku_two_harai_modoshi ")
        SelectQuery.Append("  , d.sanrenpuku_three_kumi sanrenpuku_three_kumi ")
        SelectQuery.Append("  , d.sanrenpuku_three_harai_modoshi sanrenpuku_three_harai_modoshi ")
        SelectQuery.Append("FROM ")
        SelectQuery.Append("  (  ")
        SelectQuery.Append("    SELECT ")
        SelectQuery.Append("      a.race_id as race_id ")
        SelectQuery.Append("      , a.kaime_kumiawase_list as kaime_kumiawase_list ")
        SelectQuery.Append("      , a.ten_suu as ten_suu ")
        SelectQuery.Append("      , a.kaime_kumiawase_list_sanren as kaime_kumiawase_list_sanren ")
        SelectQuery.Append("      , a.ten_suu_sanren as ten_suu_sanren ")
        SelectQuery.Append("      , b.keibajyo_code  ")
        SelectQuery.Append("    FROM ")
        SelectQuery.Append("      kaime a  ")
        SelectQuery.Append("      LEFT JOIN (  ")
        SelectQuery.Append("        SELECT ")
        SelectQuery.Append("          race_id ")
        SelectQuery.Append("          , SUBSTRING(race_id, 9, 2) AS keibajyo_code  ")
        SelectQuery.Append("        from ")
        SelectQuery.Append("          kaime ")
        SelectQuery.Append("      ) b  ")
        SelectQuery.Append("        ON a.race_id = b.race_id  ")
        SelectQuery.Append("    WHERE ")
        If "".Equals(keibajyo_cd) Then
            SelectQuery.Append("      b.race_id Like '")
            SelectQuery.Append(year)
            SelectQuery.Append("%' ")
        ElseIf "".Equals(year) Then
            SelectQuery.Append("      b.keibajyo_code = '")
            SelectQuery.Append(keibajyo_cd)
            SelectQuery.Append("' ")
        Else
            SelectQuery.Append("      b.keibajyo_code = '")
            SelectQuery.Append(keibajyo_cd)
            SelectQuery.Append("' ")
            SelectQuery.Append("     AND b.race_id Like '")
            SelectQuery.Append(year)
            SelectQuery.Append("%' ")
        End If
        SelectQuery.Append("  ) c ")
        SelectQuery.Append("  INNER JOIN jv_hr_pay d  ")
        SelectQuery.Append("    ON c.race_id = d.race_id ")
        SelectQuery.Append("WHERE c.ten_suu_sanren > 0 ")
        Return SelectQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************現在未使用
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ランクＡ決定Select文
    '------------------------------------------------------------------------
    Public Function CreateRankAKetteiSelect() As String

        Dim SelectQuery As New System.Text.StringBuilder()
        SelectQuery.Append("SELECT ")
        SelectQuery.Append("  c.id id ")
        SelectQuery.Append("FROM ")
        SelectQuery.Append("  (  ")
        SelectQuery.Append("    SELECT ")
        SelectQuery.Append("      a.id id ")
        SelectQuery.Append("      , a.race_id race_id ")
        SelectQuery.Append("      , a.ketto_num ketto_num ")
        SelectQuery.Append("      , a.bamei bamei ")
        SelectQuery.Append("      , a.futan futan ")
        SelectQuery.Append("      , a.ba_taijyu ba_taijyu ")
        SelectQuery.Append("      , a.zougen zougen ")
        SelectQuery.Append("      , a.i_jyo i_jyo ")
        SelectQuery.Append("      , a.kyakusitu kyakusitu ")
        SelectQuery.Append("      , a.jyuni_one_c jyuni_one_c ")
        SelectQuery.Append("      , a.jyuni_two_c jyuni_two_c ")
        SelectQuery.Append("      , a.jyuni_three_c jyuni_three_c ")
        SelectQuery.Append("      , a.jyuni_four_c jyuni_four_c ")
        SelectQuery.Append("      , a.kakutei_jyuni kakutei_jyuni ")
        SelectQuery.Append("      , a.ninki ninki ")
        SelectQuery.Append("      , a.dochaku_kubun dochaku_kubun ")
        SelectQuery.Append("      , a.dochaku_tosu dochaku_tosu ")
        SelectQuery.Append("      , a.souha_time souha_time ")
        SelectQuery.Append("      , a.tansho_odds tansho_odds ")
        SelectQuery.Append("      , a.haron_last haron_last ")
        SelectQuery.Append("      , a.time_diff time_diff ")
        SelectQuery.Append("      , a.data_kubun data_kubun ")
        SelectQuery.Append("      , a.data_sakusei_day data_sakusei_day ")
        SelectQuery.Append("      , b.kakutei_jyuni_average kakutei_jyuni_average ")
        SelectQuery.Append("      , b.ninki_average ninki_average ")
        SelectQuery.Append("      , b.time_diff_average time_diff_average ")
        SelectQuery.Append("      , d.jyoken_cd jyoken_cd ")
        SelectQuery.Append("      , d.jyuryo_cd jyuryo_cd ")
        SelectQuery.Append("      , d.track_cd track_cd  ")
        SelectQuery.Append("    FROM ")
        SelectQuery.Append("      jv_se_race_uma a  ")
        SelectQuery.Append("      LEFT JOIN tyakusa_ninki b  ")
        SelectQuery.Append("        ON a.id = b.id  ")
        SelectQuery.Append("      LEFT JOIN jv_ra_race d  ")
        SelectQuery.Append("        ON a.race_id = d.race_id  ")
        SelectQuery.Append("    WHERE ")
        SelectQuery.Append("      kakutei_jyuni_average IS NOT NULL ")
        SelectQuery.Append("  ) c  ")
        SelectQuery.Append("WHERE ")
        SelectQuery.Append("  c.jyoken_cd IN ('005', '010', '016', '999')  ")
        SelectQuery.Append("  AND c.track_cd NOT IN (  ")
        SelectQuery.Append("    '51' ")
        SelectQuery.Append("    , '52' ")
        SelectQuery.Append("    , '53' ")
        SelectQuery.Append("    , '54' ")
        SelectQuery.Append("    , '55' ")
        SelectQuery.Append("    , '56' ")
        SelectQuery.Append("    , '57' ")
        SelectQuery.Append("    , '58' ")
        SelectQuery.Append("    , '59' ")
        SelectQuery.Append("  )  ")
        SelectQuery.Append("  AND c.time_diff_average > 0.2  ")
        SelectQuery.Append("  AND c.time_diff_average <= 0.6  ")

        Return SelectQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　*****************************************現在未使用
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ランクＡ決定カウントSelect文
    '------------------------------------------------------------------------
    Public Function CreateRankAKetteiCountSelect() As String

        Dim SelectQuery As New System.Text.StringBuilder()
        SelectQuery.Append("SELECT ")
        SelectQuery.Append("  count(c.id) count ")
        SelectQuery.Append("FROM ")
        SelectQuery.Append("  (  ")
        SelectQuery.Append("    SELECT ")
        SelectQuery.Append("      a.id id ")
        SelectQuery.Append("      , a.race_id race_id ")
        SelectQuery.Append("      , a.ketto_num ketto_num ")
        SelectQuery.Append("      , a.bamei bamei ")
        SelectQuery.Append("      , a.futan futan ")
        SelectQuery.Append("      , a.ba_taijyu ba_taijyu ")
        SelectQuery.Append("      , a.zougen zougen ")
        SelectQuery.Append("      , a.i_jyo i_jyo ")
        SelectQuery.Append("      , a.kyakusitu kyakusitu ")
        SelectQuery.Append("      , a.jyuni_one_c jyuni_one_c ")
        SelectQuery.Append("      , a.jyuni_two_c jyuni_two_c ")
        SelectQuery.Append("      , a.jyuni_three_c jyuni_three_c ")
        SelectQuery.Append("      , a.jyuni_four_c jyuni_four_c ")
        SelectQuery.Append("      , a.kakutei_jyuni kakutei_jyuni ")
        SelectQuery.Append("      , a.ninki ninki ")
        SelectQuery.Append("      , a.dochaku_kubun dochaku_kubun ")
        SelectQuery.Append("      , a.dochaku_tosu dochaku_tosu ")
        SelectQuery.Append("      , a.souha_time souha_time ")
        SelectQuery.Append("      , a.tansho_odds tansho_odds ")
        SelectQuery.Append("      , a.haron_last haron_last ")
        SelectQuery.Append("      , a.time_diff time_diff ")
        SelectQuery.Append("      , a.data_kubun data_kubun ")
        SelectQuery.Append("      , a.data_sakusei_day data_sakusei_day ")
        SelectQuery.Append("      , b.kakutei_jyuni_average kakutei_jyuni_average ")
        SelectQuery.Append("      , b.ninki_average ninki_average ")
        SelectQuery.Append("      , b.time_diff_average time_diff_average ")
        SelectQuery.Append("      , d.jyoken_cd jyoken_cd ")
        SelectQuery.Append("      , d.jyuryo_cd jyuryo_cd ")
        SelectQuery.Append("      , d.track_cd track_cd  ")
        SelectQuery.Append("    FROM ")
        SelectQuery.Append("      jv_se_race_uma a  ")
        SelectQuery.Append("      LEFT JOIN tyakusa_ninki b  ")
        SelectQuery.Append("        ON a.id = b.id  ")
        SelectQuery.Append("      LEFT JOIN jv_ra_race d  ")
        SelectQuery.Append("        ON a.race_id = d.race_id  ")
        SelectQuery.Append("    WHERE ")
        SelectQuery.Append("      kakutei_jyuni_average IS NOT NULL ")
        SelectQuery.Append("  ) c  ")
        SelectQuery.Append("WHERE ")
        SelectQuery.Append("  c.jyoken_cd IN ('005', '010', '016', '999')  ")
        SelectQuery.Append("  AND c.track_cd NOT IN (  ")
        SelectQuery.Append("    '51' ")
        SelectQuery.Append("    , '52' ")
        SelectQuery.Append("    , '53' ")
        SelectQuery.Append("    , '54' ")
        SelectQuery.Append("    , '55' ")
        SelectQuery.Append("    , '56' ")
        SelectQuery.Append("    , '57' ")
        SelectQuery.Append("    , '58' ")
        SelectQuery.Append("    , '59' ")
        SelectQuery.Append("  )  ")
        SelectQuery.Append("  AND c.time_diff_average > 0.2  ")
        SelectQuery.Append("  AND c.time_diff_average <= 0.6  ")

        Return SelectQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************現在未使用
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ランクＢ決定Select文
    '------------------------------------------------------------------------
    Public Function CreateRankBKetteiSelect() As String

        Dim SelectQuery As New System.Text.StringBuilder()
        SelectQuery.Append("SELECT ")
        SelectQuery.Append("  c.id id ")
        SelectQuery.Append("FROM ")
        SelectQuery.Append("  (  ")
        SelectQuery.Append("    SELECT ")
        SelectQuery.Append("      a.id id ")
        SelectQuery.Append("      , a.race_id race_id ")
        SelectQuery.Append("      , a.ketto_num ketto_num ")
        SelectQuery.Append("      , a.bamei bamei ")
        SelectQuery.Append("      , a.futan futan ")
        SelectQuery.Append("      , a.ba_taijyu ba_taijyu ")
        SelectQuery.Append("      , a.zougen zougen ")
        SelectQuery.Append("      , a.i_jyo i_jyo ")
        SelectQuery.Append("      , a.kyakusitu kyakusitu ")
        SelectQuery.Append("      , a.jyuni_one_c jyuni_one_c ")
        SelectQuery.Append("      , a.jyuni_two_c jyuni_two_c ")
        SelectQuery.Append("      , a.jyuni_three_c jyuni_three_c ")
        SelectQuery.Append("      , a.jyuni_four_c jyuni_four_c ")
        SelectQuery.Append("      , a.kakutei_jyuni kakutei_jyuni ")
        SelectQuery.Append("      , a.ninki ninki ")
        SelectQuery.Append("      , a.dochaku_kubun dochaku_kubun ")
        SelectQuery.Append("      , a.dochaku_tosu dochaku_tosu ")
        SelectQuery.Append("      , a.souha_time souha_time ")
        SelectQuery.Append("      , a.tansho_odds tansho_odds ")
        SelectQuery.Append("      , a.haron_last haron_last ")
        SelectQuery.Append("      , a.time_diff time_diff ")
        SelectQuery.Append("      , a.data_kubun data_kubun ")
        SelectQuery.Append("      , a.data_sakusei_day data_sakusei_day ")
        SelectQuery.Append("      , b.kakutei_jyuni_average kakutei_jyuni_average ")
        SelectQuery.Append("      , b.ninki_average ninki_average ")
        SelectQuery.Append("      , b.time_diff_average time_diff_average ")
        SelectQuery.Append("      , d.jyoken_cd jyoken_cd ")
        SelectQuery.Append("      , d.jyuryo_cd jyuryo_cd ")
        SelectQuery.Append("      , d.track_cd track_cd  ")
        SelectQuery.Append("    FROM ")
        SelectQuery.Append("      jv_se_race_uma a  ")
        SelectQuery.Append("      LEFT JOIN tyakusa_ninki b  ")
        SelectQuery.Append("        ON a.id = b.id  ")
        SelectQuery.Append("      LEFT JOIN jv_ra_race d  ")
        SelectQuery.Append("        ON a.race_id = d.race_id  ")
        SelectQuery.Append("    WHERE ")
        SelectQuery.Append("      kakutei_jyuni_average IS NOT NULL ")
        SelectQuery.Append("  ) c  ")
        SelectQuery.Append("WHERE ")
        SelectQuery.Append("  c.jyoken_cd IN ('005', '010', '016', '999')  ")
        SelectQuery.Append("  AND c.track_cd NOT IN (  ")
        SelectQuery.Append("    '51' ")
        SelectQuery.Append("    , '52' ")
        SelectQuery.Append("    , '53' ")
        SelectQuery.Append("    , '54' ")
        SelectQuery.Append("    , '55' ")
        SelectQuery.Append("    , '56' ")
        SelectQuery.Append("    , '57' ")
        SelectQuery.Append("    , '58' ")
        SelectQuery.Append("    , '59' ")
        SelectQuery.Append("  )  ")
        SelectQuery.Append("  AND c.time_diff_average > 0.6  ")
        SelectQuery.Append("  AND c.time_diff_average <= 1.0  ")

        Return SelectQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　*****************************************現在未使用
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ランクＢ決定カウントSelect文
    '------------------------------------------------------------------------
    Public Function CreateRankBKetteiCountSelect() As String

        Dim SelectQuery As New System.Text.StringBuilder()
        SelectQuery.Append("SELECT ")
        SelectQuery.Append("  count(c.id) count ")
        SelectQuery.Append("FROM ")
        SelectQuery.Append("  (  ")
        SelectQuery.Append("    SELECT ")
        SelectQuery.Append("      a.id id ")
        SelectQuery.Append("      , a.race_id race_id ")
        SelectQuery.Append("      , a.ketto_num ketto_num ")
        SelectQuery.Append("      , a.bamei bamei ")
        SelectQuery.Append("      , a.futan futan ")
        SelectQuery.Append("      , a.ba_taijyu ba_taijyu ")
        SelectQuery.Append("      , a.zougen zougen ")
        SelectQuery.Append("      , a.i_jyo i_jyo ")
        SelectQuery.Append("      , a.kyakusitu kyakusitu ")
        SelectQuery.Append("      , a.jyuni_one_c jyuni_one_c ")
        SelectQuery.Append("      , a.jyuni_two_c jyuni_two_c ")
        SelectQuery.Append("      , a.jyuni_three_c jyuni_three_c ")
        SelectQuery.Append("      , a.jyuni_four_c jyuni_four_c ")
        SelectQuery.Append("      , a.kakutei_jyuni kakutei_jyuni ")
        SelectQuery.Append("      , a.ninki ninki ")
        SelectQuery.Append("      , a.dochaku_kubun dochaku_kubun ")
        SelectQuery.Append("      , a.dochaku_tosu dochaku_tosu ")
        SelectQuery.Append("      , a.souha_time souha_time ")
        SelectQuery.Append("      , a.tansho_odds tansho_odds ")
        SelectQuery.Append("      , a.haron_last haron_last ")
        SelectQuery.Append("      , a.time_diff time_diff ")
        SelectQuery.Append("      , a.data_kubun data_kubun ")
        SelectQuery.Append("      , a.data_sakusei_day data_sakusei_day ")
        SelectQuery.Append("      , b.kakutei_jyuni_average kakutei_jyuni_average ")
        SelectQuery.Append("      , b.ninki_average ninki_average ")
        SelectQuery.Append("      , b.time_diff_average time_diff_average ")
        SelectQuery.Append("      , d.jyoken_cd jyoken_cd ")
        SelectQuery.Append("      , d.jyuryo_cd jyuryo_cd ")
        SelectQuery.Append("      , d.track_cd track_cd  ")
        SelectQuery.Append("    FROM ")
        SelectQuery.Append("      jv_se_race_uma a  ")
        SelectQuery.Append("      LEFT JOIN tyakusa_ninki b  ")
        SelectQuery.Append("        ON a.id = b.id  ")
        SelectQuery.Append("      LEFT JOIN jv_ra_race d  ")
        SelectQuery.Append("        ON a.race_id = d.race_id  ")
        SelectQuery.Append("    WHERE ")
        SelectQuery.Append("      kakutei_jyuni_average IS NOT NULL ")
        SelectQuery.Append("  ) c  ")
        SelectQuery.Append("WHERE ")
        SelectQuery.Append("  c.jyoken_cd IN ('005', '010', '016', '999')  ")
        SelectQuery.Append("  AND c.track_cd NOT IN (  ")
        SelectQuery.Append("    '51' ")
        SelectQuery.Append("    , '52' ")
        SelectQuery.Append("    , '53' ")
        SelectQuery.Append("    , '54' ")
        SelectQuery.Append("    , '55' ")
        SelectQuery.Append("    , '56' ")
        SelectQuery.Append("    , '57' ")
        SelectQuery.Append("    , '58' ")
        SelectQuery.Append("    , '59' ")
        SelectQuery.Append("  )  ")
        SelectQuery.Append("  AND c.time_diff_average > 0.6  ")
        SelectQuery.Append("  AND c.time_diff_average <= 1.0  ")

        Return SelectQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '    [戻り値]
    '        String            = ランクS決定Update文
    '------------------------------------------------------------------------
    Public Function CreateRankXKetteiUpadate(ByVal time_diff_average1 As String, ByVal keibajyo As String) As String

        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE (  ")
        UpdateQuery.Append("  SELECT ")
        UpdateQuery.Append("    tyakusa_ninki.id  ")
        UpdateQuery.Append("  FROM ")
        UpdateQuery.Append("    tyakusa_ninki  ")
        UpdateQuery.Append("    LEFT JOIN jv_se_race_uma  ")
        UpdateQuery.Append("      ON tyakusa_ninki.id = jv_se_race_uma.id  ")
        UpdateQuery.Append("    LEFT JOIN jv_ra_race  ")
        UpdateQuery.Append("      ON jv_se_race_uma.race_id = jv_ra_race.race_id  ")
        UpdateQuery.Append("  WHERE ")
        UpdateQuery.Append("    tyakusa_ninki.time_diff_average < ")
        UpdateQuery.Append(time_diff_average1)
        UpdateQuery.Append("	AND jv_ra_race.keibajyo = '")
        UpdateQuery.Append(keibajyo)
        UpdateQuery.Append("' ")
        UpdateQuery.Append(") AS a ")
        UpdateQuery.Append(", tyakusa_ninki  ")
        UpdateQuery.Append("SET ")
        UpdateQuery.Append("  tyakusa_ninki.rank = 'X'  ")
        UpdateQuery.Append("WHERE ")
        UpdateQuery.Append("  a.id = tyakusa_ninki.id ")

        Return UpdateQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '    [戻り値]
    '        String            = ランクS決定Update文
    '------------------------------------------------------------------------
    Public Function CreateRankSKetteiUpadate(ByVal time_diff_average1 As String, ByVal time_diff_average2 As String, ByVal keibajyo As String) As String

        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE (  ")
        UpdateQuery.Append("  SELECT ")
        UpdateQuery.Append("    tyakusa_ninki.id  ")
        UpdateQuery.Append("  FROM ")
        UpdateQuery.Append("    tyakusa_ninki  ")
        UpdateQuery.Append("    LEFT JOIN jv_se_race_uma  ")
        UpdateQuery.Append("      ON tyakusa_ninki.id = jv_se_race_uma.id  ")
        UpdateQuery.Append("    LEFT JOIN jv_ra_race  ")
        UpdateQuery.Append("      ON jv_se_race_uma.race_id = jv_ra_race.race_id  ")
        UpdateQuery.Append("  WHERE ")
        UpdateQuery.Append("    tyakusa_ninki.time_diff_average < ")
        UpdateQuery.Append(time_diff_average2)
        UpdateQuery.Append("    AND tyakusa_ninki.time_diff_average >= ")
        UpdateQuery.Append(time_diff_average1)
        UpdateQuery.Append("	AND jv_ra_race.keibajyo = '")
        UpdateQuery.Append(keibajyo)
        UpdateQuery.Append("' ")
        UpdateQuery.Append(") AS a ")
        UpdateQuery.Append(", tyakusa_ninki  ")
        UpdateQuery.Append("SET ")
        UpdateQuery.Append("  tyakusa_ninki.rank = 'S'  ")
        UpdateQuery.Append("WHERE ")
        UpdateQuery.Append("  a.id = tyakusa_ninki.id ")

        Return UpdateQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '    [戻り値]
    '        String            = ランクA決定Update文
    '------------------------------------------------------------------------
    Public Function CreateRankAKetteiUpadate(ByVal time_diff_average1 As String, ByVal time_diff_average2 As String, ByVal keibajyo As String) As String

        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE (  ")
        UpdateQuery.Append("  SELECT ")
        UpdateQuery.Append("    tyakusa_ninki.id  ")
        UpdateQuery.Append("  FROM ")
        UpdateQuery.Append("    tyakusa_ninki  ")
        UpdateQuery.Append("    LEFT JOIN jv_se_race_uma  ")
        UpdateQuery.Append("      ON tyakusa_ninki.id = jv_se_race_uma.id  ")
        UpdateQuery.Append("    LEFT JOIN jv_ra_race  ")
        UpdateQuery.Append("      ON jv_se_race_uma.race_id = jv_ra_race.race_id  ")
        UpdateQuery.Append("  WHERE ")
        UpdateQuery.Append("    tyakusa_ninki.time_diff_average < ")
        UpdateQuery.Append(time_diff_average2)
        UpdateQuery.Append("    AND tyakusa_ninki.time_diff_average >= ")
        UpdateQuery.Append(time_diff_average1)
        UpdateQuery.Append("	AND jv_ra_race.keibajyo = '")
        UpdateQuery.Append(keibajyo)
        UpdateQuery.Append("' ")
        UpdateQuery.Append(") AS a ")
        UpdateQuery.Append(", tyakusa_ninki  ")
        UpdateQuery.Append("SET ")
        UpdateQuery.Append("  tyakusa_ninki.rank = 'A'  ")
        UpdateQuery.Append("WHERE ")
        UpdateQuery.Append("  a.id = tyakusa_ninki.id ")

        Return UpdateQuery.ToString

    End Function


    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '    [戻り値]
    '        String            = ランクB決定Update文
    '------------------------------------------------------------------------
    Public Function CreateRankBKetteiUpadate(ByVal time_diff_average1 As String, ByVal time_diff_average2 As String, ByVal keibajyo As String) As String

        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE (  ")
        UpdateQuery.Append("  SELECT ")
        UpdateQuery.Append("    tyakusa_ninki.id  ")
        UpdateQuery.Append("  FROM ")
        UpdateQuery.Append("    tyakusa_ninki  ")
        UpdateQuery.Append("    LEFT JOIN jv_se_race_uma  ")
        UpdateQuery.Append("      ON tyakusa_ninki.id = jv_se_race_uma.id  ")
        UpdateQuery.Append("    LEFT JOIN jv_ra_race  ")
        UpdateQuery.Append("      ON jv_se_race_uma.race_id = jv_ra_race.race_id  ")
        UpdateQuery.Append("  WHERE ")
        UpdateQuery.Append("    tyakusa_ninki.time_diff_average < ")
        UpdateQuery.Append(time_diff_average2)
        UpdateQuery.Append("    AND tyakusa_ninki.time_diff_average >= ")
        UpdateQuery.Append(time_diff_average1)
        UpdateQuery.Append("	AND jv_ra_race.keibajyo = '")
        UpdateQuery.Append(keibajyo)
        UpdateQuery.Append("' ")
        UpdateQuery.Append(") AS a ")
        UpdateQuery.Append(", tyakusa_ninki  ")
        UpdateQuery.Append("SET ")
        UpdateQuery.Append("  tyakusa_ninki.rank = 'B'  ")
        UpdateQuery.Append("WHERE ")
        UpdateQuery.Append("  a.id = tyakusa_ninki.id ")

        Return UpdateQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '    [戻り値]
    '        String            = ランクC決定Update文
    '------------------------------------------------------------------------
    Public Function CreateRankCKetteiUpadate(ByVal time_diff_average1 As String, ByVal time_diff_average2 As String, ByVal keibajyo As String) As String

        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE (  ")
        UpdateQuery.Append("  SELECT ")
        UpdateQuery.Append("    tyakusa_ninki.id  ")
        UpdateQuery.Append("  FROM ")
        UpdateQuery.Append("    tyakusa_ninki  ")
        UpdateQuery.Append("    LEFT JOIN jv_se_race_uma  ")
        UpdateQuery.Append("      ON tyakusa_ninki.id = jv_se_race_uma.id  ")
        UpdateQuery.Append("    LEFT JOIN jv_ra_race  ")
        UpdateQuery.Append("      ON jv_se_race_uma.race_id = jv_ra_race.race_id  ")
        UpdateQuery.Append("  WHERE ")
        UpdateQuery.Append("    tyakusa_ninki.time_diff_average < ")
        UpdateQuery.Append(time_diff_average2)
        UpdateQuery.Append("    AND tyakusa_ninki.time_diff_average >= ")
        UpdateQuery.Append(time_diff_average1)
        UpdateQuery.Append("	AND jv_ra_race.keibajyo = '")
        UpdateQuery.Append(keibajyo)
        UpdateQuery.Append("' ")
        UpdateQuery.Append(") AS a ")
        UpdateQuery.Append(", tyakusa_ninki  ")
        UpdateQuery.Append("SET ")
        UpdateQuery.Append("  tyakusa_ninki.rank = 'C'  ")
        UpdateQuery.Append("WHERE ")
        UpdateQuery.Append("  a.id = tyakusa_ninki.id ")

        Return UpdateQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '    [戻り値]
    '        String            = ランクD決定Update文
    '------------------------------------------------------------------------
    Public Function CreateRankDKetteiUpadate(ByVal time_diff_average1 As String, ByVal time_diff_average2 As String, ByVal keibajyo As String) As String

        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE (  ")
        UpdateQuery.Append("  SELECT ")
        UpdateQuery.Append("    tyakusa_ninki.id  ")
        UpdateQuery.Append("  FROM ")
        UpdateQuery.Append("    tyakusa_ninki  ")
        UpdateQuery.Append("    LEFT JOIN jv_se_race_uma  ")
        UpdateQuery.Append("      ON tyakusa_ninki.id = jv_se_race_uma.id  ")
        UpdateQuery.Append("    LEFT JOIN jv_ra_race  ")
        UpdateQuery.Append("      ON jv_se_race_uma.race_id = jv_ra_race.race_id  ")
        UpdateQuery.Append("  WHERE ")
        UpdateQuery.Append("    tyakusa_ninki.time_diff_average < ")
        UpdateQuery.Append(time_diff_average2)
        UpdateQuery.Append("    AND tyakusa_ninki.time_diff_average >= ")
        UpdateQuery.Append(time_diff_average1)
        UpdateQuery.Append("	AND jv_ra_race.keibajyo = '")
        UpdateQuery.Append(keibajyo)
        UpdateQuery.Append("' ")
        UpdateQuery.Append(") AS a ")
        UpdateQuery.Append(", tyakusa_ninki  ")
        UpdateQuery.Append("SET ")
        UpdateQuery.Append("  tyakusa_ninki.rank = 'D'  ")
        UpdateQuery.Append("WHERE ")
        UpdateQuery.Append("  a.id = tyakusa_ninki.id ")

        Return UpdateQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '    [戻り値]
    '        String            = ランクE決定Update文
    '------------------------------------------------------------------------
    Public Function CreateRankEKetteiUpadate(ByVal time_diff_average1 As String, ByVal time_diff_average2 As String, ByVal keibajyo As String) As String

        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE (  ")
        UpdateQuery.Append("  SELECT ")
        UpdateQuery.Append("    tyakusa_ninki.id  ")
        UpdateQuery.Append("  FROM ")
        UpdateQuery.Append("    tyakusa_ninki  ")
        UpdateQuery.Append("    LEFT JOIN jv_se_race_uma  ")
        UpdateQuery.Append("      ON tyakusa_ninki.id = jv_se_race_uma.id  ")
        UpdateQuery.Append("    LEFT JOIN jv_ra_race  ")
        UpdateQuery.Append("      ON jv_se_race_uma.race_id = jv_ra_race.race_id  ")
        UpdateQuery.Append("  WHERE ")
        UpdateQuery.Append("    tyakusa_ninki.time_diff_average < ")
        UpdateQuery.Append(time_diff_average2)
        UpdateQuery.Append("    AND tyakusa_ninki.time_diff_average >= ")
        UpdateQuery.Append(time_diff_average1)
        UpdateQuery.Append("	AND jv_ra_race.keibajyo = '")
        UpdateQuery.Append(keibajyo)
        UpdateQuery.Append("' ")
        UpdateQuery.Append(") AS a ")
        UpdateQuery.Append(", tyakusa_ninki  ")
        UpdateQuery.Append("SET ")
        UpdateQuery.Append("  tyakusa_ninki.rank = 'E'  ")
        UpdateQuery.Append("WHERE ")
        UpdateQuery.Append("  a.id = tyakusa_ninki.id ")

        Return UpdateQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '    [戻り値]
    '        String            = ランクF決定Update文
    '------------------------------------------------------------------------
    Public Function CreateRankFKetteiUpadate(ByVal time_diff_average1 As String, ByVal keibajyo As String) As String

        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE (  ")
        UpdateQuery.Append("  SELECT ")
        UpdateQuery.Append("    tyakusa_ninki.id  ")
        UpdateQuery.Append("  FROM ")
        UpdateQuery.Append("    tyakusa_ninki  ")
        UpdateQuery.Append("    LEFT JOIN jv_se_race_uma  ")
        UpdateQuery.Append("      ON tyakusa_ninki.id = jv_se_race_uma.id  ")
        UpdateQuery.Append("    LEFT JOIN jv_ra_race  ")
        UpdateQuery.Append("      ON jv_se_race_uma.race_id = jv_ra_race.race_id  ")
        UpdateQuery.Append("  WHERE ")
        UpdateQuery.Append("    tyakusa_ninki.time_diff_average >= ")
        UpdateQuery.Append(time_diff_average1)
        UpdateQuery.Append("	AND jv_ra_race.keibajyo = '")
        UpdateQuery.Append(keibajyo)
        UpdateQuery.Append("' ")
        UpdateQuery.Append(") AS a ")
        UpdateQuery.Append(", tyakusa_ninki  ")
        UpdateQuery.Append("SET ")
        UpdateQuery.Append("  tyakusa_ninki.rank = 'F'  ")
        UpdateQuery.Append("WHERE ")
        UpdateQuery.Append("  a.id = tyakusa_ninki.id ")

        Return UpdateQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '    [戻り値]
    '        String            = ランクG決定Update文
    '------------------------------------------------------------------------
    Public Function CreateRankGKetteiUpadate(ByVal param As String, ByVal keibajyo As String) As String

        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE (  ")
        UpdateQuery.Append("  SELECT ")
        UpdateQuery.Append("    tyakusa_ninki.id  ")
        UpdateQuery.Append("  FROM ")
        UpdateQuery.Append("    tyakusa_ninki  ")
        UpdateQuery.Append("    LEFT JOIN jv_se_race_uma  ")
        UpdateQuery.Append("      ON tyakusa_ninki.id = jv_se_race_uma.id  ")
        UpdateQuery.Append("    LEFT JOIN jv_ra_race  ")
        UpdateQuery.Append("      ON jv_se_race_uma.race_id = jv_ra_race.race_id  ")
        UpdateQuery.Append("  WHERE ")
        UpdateQuery.Append("    (ninki_average - kakutei_jyuni_average) < ")
        UpdateQuery.Append(param)
        UpdateQuery.Append("	AND jv_ra_race.keibajyo = '")
        UpdateQuery.Append(keibajyo)
        UpdateQuery.Append("' ")
        UpdateQuery.Append(") AS a ")
        UpdateQuery.Append(", tyakusa_ninki  ")
        UpdateQuery.Append("SET ")
        UpdateQuery.Append("  tyakusa_ninki.rank = 'G'  ")
        UpdateQuery.Append("WHERE ")
        UpdateQuery.Append("  a.id = tyakusa_ninki.id ")

        Return UpdateQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　*****************************************未使用
    '------------------------------------------------------------------------
    '    [戻り値]
    '        String            = ランクＡ決定Update文
    '------------------------------------------------------------------------
    Public Function CreateRankAKetteiUpadate() As String

        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE tyakusa_ninki  ")
        UpdateQuery.Append("SET ")
        UpdateQuery.Append("  rank = 'A'  ")
        UpdateQuery.Append("WHERE ")
        UpdateQuery.Append("  race_interval <= 15  ")
        UpdateQuery.Append("  AND race_interval >= 2  ")
        UpdateQuery.Append("  AND kakutei_jyuni_average <= 8  ")
        UpdateQuery.Append("  AND kakutei_jyuni_average >= 3 ")
        UpdateQuery.Append("  AND ninki_average <= 8  ")
        UpdateQuery.Append("  AND ninki_average >= 3 ")

        Return UpdateQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　*****************************************未使用
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ランクＢ決定Update文
    '------------------------------------------------------------------------
    Public Function CreateRankBKetteiUpadate() As String

        Dim UpdateQuery As New System.Text.StringBuilder()
        UpdateQuery.Append("UPDATE tyakusa_ninki  ")
        UpdateQuery.Append("SET ")
        UpdateQuery.Append("  rank = 'B'  ")
        UpdateQuery.Append("WHERE ")
        UpdateQuery.Append("  race_interval <= 6  ")
        UpdateQuery.Append("  AND race_interval >= 2  ")
        UpdateQuery.Append("  AND kakutei_jyuni_average <= 9  ")
        UpdateQuery.Append("  AND kakutei_jyuni_average > 8 ")
        UpdateQuery.Append("  AND ninki_average <= 9  ")
        UpdateQuery.Append("  AND ninki_average > 8 ")

        Return UpdateQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= ランクＡ,Ｂの購入馬券決定Select文
    '------------------------------------------------------------------------
    Public Function CreateRankAKounyuuBakenKetteiSelect(ByVal ymd As String) As String

        Dim SelectQuery As New System.Text.StringBuilder()
        SelectQuery.Append("SELECT ")
        SelectQuery.Append("  a.race_id race_id ")
        SelectQuery.Append("  , SUBSTRING(a.id, 17, 2) umaban ")
        SelectQuery.Append("  , b.rank rank  ")
        SelectQuery.Append("  , d.titi titi  ")
        SelectQuery.Append("  , c.track_cd track_cd  ")
        SelectQuery.Append("FROM ")
        SelectQuery.Append("  jv_se_race_uma a  ")
        SelectQuery.Append("  LEFT JOIN tyakusa_ninki b  ")
        SelectQuery.Append("    ON a.id = b.id  ")
        SelectQuery.Append("  LEFT JOIN jv_ra_race c  ")
        SelectQuery.Append("    ON a.race_id = c.race_id  ")
        SelectQuery.Append("  LEFT JOIN jv_um_uma d  ")
        SelectQuery.Append("    ON a.ketto_num = d.ketto_num  ")
        SelectQuery.Append("WHERE ")
        SelectQuery.Append("  b.rank IN ('S','A', 'B','C','D','E')  ")
        SelectQuery.Append("  AND d.keiro_cd NOT IN ('08', '09', '10', '11')  ")　'特定の毛色は除く
        SelectQuery.Append("  AND c.jyoken_cd IN ('005', '010', '016', '999')  ")
        'SelectQuery.Append("  AND c.jyoken_cd IN ('005', '010', '016', '703','999')  ")
        'SelectQuery.Append("  AND c.jyoken_cd IN ('010', '016', '999')  ")
        SelectQuery.Append("  AND c.jyuryo_cd IN ('1','2','4')  ")
        SelectQuery.Append("  AND b.race_interval <= 30  ") 'レース間隔が30週以下
        'SelectQuery.Append("  AND a.race_id > '2012010100000000'  ")
        SelectQuery.Append("  and a.race_id like '")
        SelectQuery.Append(ymd)
        SelectQuery.Append("%'  ")
        SelectQuery.Append("  AND c.track_cd NOT IN (  ")
        SelectQuery.Append("    '51' ")
        SelectQuery.Append("    , '52' ")
        SelectQuery.Append("    , '53' ")
        SelectQuery.Append("    , '54' ")
        SelectQuery.Append("    , '55' ")
        SelectQuery.Append("    , '56' ")
        SelectQuery.Append("    , '57' ")
        SelectQuery.Append("    , '58' ")
        SelectQuery.Append("    , '59' ")
        SelectQuery.Append("  )  ")

        Return SelectQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 上位種牡馬取得Select文
    '------------------------------------------------------------------------
    Public Function CreateJyouiRankTitiSelect(ByVal toDate As String, ByVal track_cd As String) As String
        Dim oneYearAgo As Integer = Integer.Parse(toDate.Substring(0, 4)) - 100
        Dim fromDate As String = oneYearAgo.ToString & toDate.Substring(4, 12)
        Dim SelectQuery As New System.Text.StringBuilder()
        SelectQuery.Append("SELECT ")
        SelectQuery.Append("  d.titi ")
        SelectQuery.Append("  , SUM(1) AS sum ")
        SelectQuery.Append("FROM ")
        SelectQuery.Append("  (  ")
        SelectQuery.Append("    SELECT ")
        SelectQuery.Append("      b.titi titi  ")
        SelectQuery.Append("    FROM ")
        SelectQuery.Append("      jv_se_race_uma a  ")
        SelectQuery.Append("      LEFT JOIN jv_um_uma b  ")
        SelectQuery.Append("        ON a.ketto_num = b.ketto_num  ")
        SelectQuery.Append("	  LEFT JOIN jv_ra_race c ")
        SelectQuery.Append("	    ON a.race_id = c.race_id ")
        SelectQuery.Append("    WHERE ")
        SelectQuery.Append("      a.kakutei_jyuni <= 3 ")
        SelectQuery.Append("	  AND a.race_id > '" & fromDate & "'")
        SelectQuery.Append("	  AND a.race_id < '" & toDate & "'")
        Select Case track_cd
            '芝の場合
            Case "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22"
                SelectQuery.Append("	  AND c.track_cd <= '22' ")
                SelectQuery.Append("	  AND c.track_cd >= '10' ")
            'ダートの場合
            Case "23", "24", "25", "26", "27", "28", "29"
                SelectQuery.Append("	  AND c.track_cd <= '29' ")
                SelectQuery.Append("	  AND c.track_cd >= '23' ")
        End Select
        SelectQuery.Append("  ) d ")
        SelectQuery.Append("GROUP BY d.titi ")
        SelectQuery.Append("ORDER BY sum DESC ")

        Return SelectQuery.ToString

    End Function
    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 馬連購入金額取得Select文
    '------------------------------------------------------------------------
    Public Function CreateUmarenkounyuuKingakuSelect(ByVal year As String, ByVal keibajyo_cd As String) As String
        Dim SelectQuery As New System.Text.StringBuilder()
        SelectQuery.Append("SELECT ")
        SelectQuery.Append("  SUM(c.ten_suu) as sum  ")
        SelectQuery.Append("FROM ")
        SelectQuery.Append("  (  ")
        SelectQuery.Append("    SELECT ")
        SelectQuery.Append("      a.race_id as race_id ")
        SelectQuery.Append("      , a.kaime_kumiawase_list as kaime_kumiawase_list ")
        SelectQuery.Append("      , a.ten_suu as ten_suu ")
        SelectQuery.Append("      , a.kaime_kumiawase_list_sanren as kaime_kumiawase_list_sanren ")
        SelectQuery.Append("      , a.ten_suu_sanren as ten_suu_sanren ")
        SelectQuery.Append("      , b.keibajyo_code  ")
        SelectQuery.Append("    FROM ")
        SelectQuery.Append("      kaime a  ")
        SelectQuery.Append("      LEFT JOIN (  ")
        SelectQuery.Append("        SELECT ")
        SelectQuery.Append("          race_id ")
        SelectQuery.Append("          , SUBSTRING(race_id, 9, 2) AS keibajyo_code  ")
        SelectQuery.Append("        from ")
        SelectQuery.Append("          kaime ")
        SelectQuery.Append("      ) b  ")
        SelectQuery.Append("        ON a.race_id = b.race_id  ")
        SelectQuery.Append("    WHERE ")
        If "".Equals(keibajyo_cd) Then
            SelectQuery.Append("      b.race_id Like '")
            SelectQuery.Append(year)
            SelectQuery.Append("%' ")
        ElseIf "".Equals(year) Then
            SelectQuery.Append("      b.keibajyo_code = '")
            SelectQuery.Append(keibajyo_cd)
            SelectQuery.Append("' ")
        Else
            SelectQuery.Append("      b.keibajyo_code = '")
            SelectQuery.Append(keibajyo_cd)
            SelectQuery.Append("' ")
            SelectQuery.Append("     AND b.race_id Like '")
            SelectQuery.Append(year)
            SelectQuery.Append("%' ")
        End If
        SelectQuery.Append("  ) c ")

        Return SelectQuery.ToString

    End Function

    '------------------------------------------------------------------------
    '　　*****************************************
    '------------------------------------------------------------------------
    '	[戻り値]
    '		String			= 三連複購入金額取得Select文
    '------------------------------------------------------------------------
    Public Function CreateSanrenkounyuuKingakuSelect(ByVal year As String, ByVal keibajyo_cd As String) As String
        Dim SelectQuery As New System.Text.StringBuilder()
        SelectQuery.Append("SELECT ")
        SelectQuery.Append("  SUM(c.ten_suu_sanren) as sum  ")
        SelectQuery.Append("FROM ")
        SelectQuery.Append("  (  ")
        SelectQuery.Append("    SELECT ")
        SelectQuery.Append("      a.race_id as race_id ")
        SelectQuery.Append("      , a.kaime_kumiawase_list as kaime_kumiawase_list ")
        SelectQuery.Append("      , a.ten_suu as ten_suu ")
        SelectQuery.Append("      , a.kaime_kumiawase_list_sanren as kaime_kumiawase_list_sanren ")
        SelectQuery.Append("      , a.ten_suu_sanren as ten_suu_sanren ")
        SelectQuery.Append("      , b.keibajyo_code  ")
        SelectQuery.Append("    FROM ")
        SelectQuery.Append("      kaime a  ")
        SelectQuery.Append("      LEFT JOIN (  ")
        SelectQuery.Append("        SELECT ")
        SelectQuery.Append("          race_id ")
        SelectQuery.Append("          , SUBSTRING(race_id, 9, 2) AS keibajyo_code  ")
        SelectQuery.Append("        from ")
        SelectQuery.Append("          kaime ")
        SelectQuery.Append("      ) b  ")
        SelectQuery.Append("        ON a.race_id = b.race_id  ")
        SelectQuery.Append("    WHERE ")
        If "".Equals(keibajyo_cd) Then
            SelectQuery.Append("      b.race_id Like '")
            SelectQuery.Append(year)
            SelectQuery.Append("%' ")
        ElseIf "".Equals(year) Then
            SelectQuery.Append("      b.keibajyo_code = '")
            SelectQuery.Append(keibajyo_cd)
            SelectQuery.Append("' ")
        Else
            SelectQuery.Append("      b.keibajyo_code = '")
            SelectQuery.Append(keibajyo_cd)
            SelectQuery.Append("' ")
            SelectQuery.Append("     AND b.race_id Like '")
            SelectQuery.Append(year)
            SelectQuery.Append("%' ")
        End If
        SelectQuery.Append("  ) c ")

        Return SelectQuery.ToString

    End Function
End Module

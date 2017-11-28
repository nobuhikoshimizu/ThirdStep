Imports MySql.Data.MySqlClient

Public Class getData

    Private lDownloadCount As Long ''JVOpen:総ダウロードファイル数''
    Private JVOpenFlg As Boolean ''JVOpen 状態フラグ Opne 時:Ture
    Private strFromTime As String = "" '' 引数 JVOpen:データ提供日付

    Private Sub getData_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sid As String
        Dim lReturnCode As Long
        '引数設定
        sid = "Test"
        'JVLink 初期化
        lReturnCode = Me.AxJVLink1.JVInit(sid)
        'エラー判定
        If lReturnCode <> 0 Then
            MsgBox("JVInit エラー コード：" & lReturnCode & "：", MessageBoxIcon.Error)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
    End Sub

    Private Sub getDataBtn_Click(sender As Object, e As EventArgs) Handles getDataBtn.Click

        Using con As MySqlConnection = DBManager.CreateMySqlConnection
            Try
                Dim CommandText As String = "SELECT count(race_id) FROM jv_ra_race"
                Dim Command As New MySqlCommand(CommandText, con)
                Dim JvRaRaceMax As String = "20050101"
                Dim JvSeRaceUmaMax As String = "20050101"
                Dim JvHrPayMax As String = "20050101"
                Dim count As Integer = Command.ExecuteScalar()
                If count > 0 Then
                    CommandText = "SELECT max(data_sakusei_day) FROM jv_ra_race"
                    Command = New MySqlCommand(CommandText, con)
                    JvRaRaceMax = Command.ExecuteScalar()
                End If
                CommandText = "SELECT count(race_id) FROM jv_se_race_uma"
                Command = New MySqlCommand(CommandText, con)
                count = Command.ExecuteScalar()
                If count > 0 Then
                    CommandText = "SELECT max(data_sakusei_day) FROM jv_se_race_uma"
                    Command = New MySqlCommand(CommandText, con)
                    JvSeRaceUmaMax = Command.ExecuteScalar()
                End If
                CommandText = "SELECT count(race_id) FROM jv_hr_pay"
                Command = New MySqlCommand(CommandText, con)
                count = Command.ExecuteScalar()
                If count > 0 Then
                    CommandText = "SELECT max(data_sakusei_day) FROM jv_hr_pay"
                    Command = New MySqlCommand(CommandText, con)
                    JvHrPayMax = Command.ExecuteScalar()
                End If
                If (JvRaRaceMax.CompareTo(JvHrPayMax) >= 0 AndAlso JvSeRaceUmaMax.CompareTo(JvHrPayMax) >= 0) Then
                    Me.strFromTime = Integer.Parse(JvHrPayMax) + 1 & "000000"
                ElseIf (JvRaRaceMax.CompareTo(JvSeRaceUmaMax) >= 0 AndAlso JvHrPayMax.CompareTo(JvSeRaceUmaMax) >= 0) Then
                    Me.strFromTime = Integer.Parse(JvSeRaceUmaMax) + 1 & "000000"
                ElseIf (JvSeRaceUmaMax.CompareTo(JvRaRaceMax) >= 0 AndAlso JvHrPayMax.CompareTo(JvRaRaceMax) >= 0) Then
                    Me.strFromTime = Integer.Parse(JvRaRaceMax) + 1 & "000000"
                End If
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            End Try
        End Using

        Dim lReturnCode As Long
        Try
            Dim strDataSpec As String '' 引数 JVOpen:ファイル識別子
            Dim lOption As Long '' 引数 JVOpen:オプション
            Dim lReadCount As Long '' JVLink 戻り値
            Dim strLastFileTimestamp As String = "" '' JVOpen: 最新ファイルのタイムスタンプ
            Const lBuffSize As Long = 110000 ''JVRead:データ格納バッファサイズ
            Const lNameSize As Integer = 256 ''JVRead:ファイル名サイズ
            Dim strBuff As String ''JVRead:データ格納バッファ
            Dim strFileName As String ''JVRead:ダウンロードファイル名
            Dim RaceInfo As JV_RA_RACE = New JV_RA_RACE() ''レース詳細構造体
            Dim RaceUmaInfo As JV_SE_RACE_UMA = New JV_SE_RACE_UMA() ''馬毎レース情報構造体
            Dim PayInfo As JV_HR_PAY = New JV_HR_PAY() ''払戻情報構造体
            '進捗表示初期設定
            TimerDownload.Enabled = False ''タイマー停止
            prgJVRead.Value = 0 ''JVData読み込み進捗
            '引数設定
            strDataSpec = "RACE"
            lOption = "1"
            'JVLink ダウンロード処理
            lReturnCode = Me.AxJVLink1.JVOpen(strDataSpec, Me.strFromTime, lOption,
            lReadCount, Me.lDownloadCount, strLastFileTimestamp)
            'エラー判定
            If lReturnCode = -1 Then
                MsgBox("取得データなし")
                Exit Sub
            Else
                If lReturnCode <> 0 Then
                    MsgBox("JVOpen エラー：" & lReturnCode)
                Else
                    MsgBox("戻り値 : " & lReturnCode & vbCrLf &
                    "読み込みファイル数 : " & lReadCount & vbCrLf &
                    "ダウンロードファイル数 : " & Me.lDownloadCount & vbCrLf &
                    "タイムスタンプ : " & strLastFileTimestamp)
                    TimerDownload.Enabled = True ''タイマー開始 
                    '進捗表示プログレスバー最大値設定
                    prgJVRead.Maximum = lReadCount
                    If lReadCount > 0 Then
                        Using con As MySqlConnection = DBManager.CreateMySqlConnection
                            Do
                                'バックグラウンドでの処理を実行
                                Application.DoEvents()
                                'バッファ作成
                                strBuff = New String(vbNullChar, lBuffSize)
                                strFileName = New String(vbNullChar, lNameSize)
                                'JVReadで１行読み込み
                                lReturnCode = Me.AxJVLink1.JVRead(strBuff, lBuffSize, strFileName)
                                'リターンコードにより処理を分枝
                                Select Case lReturnCode
                                    Case 0 ' 全ファイル読み込み終了
                                        prgJVRead.Value = prgJVRead.Maximum '進捗表示
                                        Exit Do
                                    Case -1 ' ファイル切り替わり
                                        prgJVRead.Value = prgJVRead.Value + 1
                                    Case -3 ' ダウンロード中
                                    Case -201 ' Initされてない
                                        MsgBox("JVInitが行われていません。")
                                        Exit Do
                                    Case -203 ' Openされてない
                                        MsgBox("JVOpenが行われていません。")
                                        Exit Do
                                    Case -503 ' ファイルがない
                                        MsgBox(strFileName & "が存在しません。")
                                        Exit Do
                                    Case Is > 0 ' 正常読み込み
                                        'レコード種別IDの識別
                                        If Mid(strBuff, 1, 2) = "RA" Then
                                            '馬毎レース情報構造体への展開
                                            RaceInfo.SetData(strBuff)
                                            If "01".Equals(RaceInfo.id.JyoCD) OrElse "02".Equals(RaceInfo.id.JyoCD) OrElse "03".Equals(RaceInfo.id.JyoCD) OrElse "04".Equals(RaceInfo.id.JyoCD) OrElse "05".Equals(RaceInfo.id.JyoCD) OrElse "06".Equals(RaceInfo.id.JyoCD) OrElse "07".Equals(RaceInfo.id.JyoCD) OrElse "08".Equals(RaceInfo.id.JyoCD) OrElse "09".Equals(RaceInfo.id.JyoCD) OrElse "10".Equals(RaceInfo.id.JyoCD) Then
                                                'レースID
                                                Dim raceid As String = RaceInfo.id.Year & RaceInfo.id.MonthDay & RaceInfo.id.JyoCD & RaceInfo.id.Kaiji & RaceInfo.id.Nichiji & RaceInfo.id.RaceNum
                                                '競馬場
                                                Dim KeibaJyo As String = KeibaJyoCodeConversion(RaceInfo.id.JyoCD)
                                                '競走条件
                                                Dim KyosouJyoukenCD As String = CodeConversion.SelectKyosouJyoukenCode(RaceInfo.JyokenInfo.JyokenCD)
                                                Dim KyosouJyouken As String = CodeConversion.KyosouJyoukenCodeConversion(KyosouJyoukenCD)
                                                '馬場状態
                                                Dim BabaCD As String = ""
                                                If "0".Equals(RaceInfo.TenkoBaba.SibaBabaCD) Then
                                                    BabaCD = RaceInfo.TenkoBaba.DirtBabaCD
                                                Else
                                                    BabaCD = RaceInfo.TenkoBaba.SibaBabaCD
                                                End If
                                                Try
                                                    Dim CommandText As String = "Select count(*) FROM jv_ra_race WHERE race_id = '" & raceid & "'"
                                                    Dim Command As New MySqlCommand(CommandText, con)
                                                    Dim count As Integer = Command.ExecuteScalar()
                                                    If count > 0 Then
                                                        CommandText = "SELECT data_kubun FROM jv_ra_race WHERE race_id = '" & raceid & "'"
                                                        Command = New MySqlCommand(CommandText, con)
                                                        Dim data_kubun As String = Command.ExecuteScalar()
                                                        'データ区分 1:出走馬名表(木曜)　2:出馬表(金･土曜)　3:速報成績(3着まで確定)　4:速報成績(5着まで確定) 
                                                        '5:速報成績(全馬着順確定)6:速報成績(全馬着順+コーナ通過順)　7:成績(月曜)　9:レース中止
                                                        If RaceInfo.head.DataKubun.CompareTo(data_kubun) > 0 Then 'データ区分の値が大きければ更新
                                                            Dim myCommand As New MySqlCommand(CreateSQL.CreateJvRaRaceUpDate(), con)
                                                            'プレースホルダーにバインド
                                                            myCommand.Parameters.AddWithValue("?val1", RaceInfo.JyokenInfo.SyubetuCD)
                                                            myCommand.Parameters.AddWithValue("?val2", RaceInfo.JyokenInfo.KigoCD)
                                                            myCommand.Parameters.AddWithValue("?val3", KyosouJyoukenCD)
                                                            myCommand.Parameters.AddWithValue("?val4", RaceInfo.JyokenInfo.JyuryoCD)
                                                            myCommand.Parameters.AddWithValue("?val5", RaceInfo.GradeCD)
                                                            myCommand.Parameters.AddWithValue("?val6", RaceInfo.RaceInfo.Hondai)
                                                            myCommand.Parameters.AddWithValue("?val7", Integer.Parse(RaceInfo.Kyori))
                                                            myCommand.Parameters.AddWithValue("?val8", RaceInfo.TrackCD)
                                                            myCommand.Parameters.AddWithValue("?val9", RaceInfo.CourseKubunCD)
                                                            myCommand.Parameters.AddWithValue("?val10", RaceInfo.TenkoBaba.TenkoCD)
                                                            myCommand.Parameters.AddWithValue("?val11", BabaCD)
                                                            myCommand.Parameters.AddWithValue("?val12", Integer.Parse(RaceInfo.SyussoTosu))
                                                            myCommand.Parameters.AddWithValue("?val13", RaceInfo.HassoTime)
                                                            myCommand.Parameters.AddWithValue("?val14", RaceInfo.head.DataKubun)
                                                            myCommand.Parameters.AddWithValue("?val15", RaceInfo.head.MakeDate.Year & RaceInfo.head.MakeDate.Month & RaceInfo.head.MakeDate.Day)
                                                            myCommand.Parameters.AddWithValue("?val16", raceid)
                                                            'SQLを実行
                                                            myCommand.ExecuteNonQuery()
                                                        End If
                                                    Else
                                                        Dim myCommand As New MySqlCommand(CreateSQL.CreateJvRaRaceInsert(), con)
                                                        'プレースホルダーにバインド
                                                        myCommand.Parameters.AddWithValue("?val1", raceid)
                                                        myCommand.Parameters.AddWithValue("?val2", RaceInfo.id.Year)
                                                        myCommand.Parameters.AddWithValue("?val3", RaceInfo.id.MonthDay.Substring(0, 2))
                                                        myCommand.Parameters.AddWithValue("?val4", RaceInfo.id.MonthDay.Substring(2, 2))
                                                        myCommand.Parameters.AddWithValue("?val5", KeibaJyo)
                                                        myCommand.Parameters.AddWithValue("?val6", RaceInfo.id.RaceNum)
                                                        myCommand.Parameters.AddWithValue("?val7", RaceInfo.JyokenInfo.SyubetuCD)
                                                        myCommand.Parameters.AddWithValue("?val8", RaceInfo.JyokenInfo.KigoCD)
                                                        myCommand.Parameters.AddWithValue("?val9", KyosouJyoukenCD)
                                                        myCommand.Parameters.AddWithValue("?val10", RaceInfo.JyokenInfo.JyuryoCD)
                                                        myCommand.Parameters.AddWithValue("?val11", RaceInfo.GradeCD)
                                                        myCommand.Parameters.AddWithValue("?val12", RaceInfo.RaceInfo.Hondai)
                                                        myCommand.Parameters.AddWithValue("?val13", Integer.Parse(RaceInfo.Kyori))
                                                        myCommand.Parameters.AddWithValue("?val14", RaceInfo.TrackCD)
                                                        myCommand.Parameters.AddWithValue("?val15", RaceInfo.CourseKubunCD)
                                                        myCommand.Parameters.AddWithValue("?val16", RaceInfo.TenkoBaba.TenkoCD)
                                                        myCommand.Parameters.AddWithValue("?val17", BabaCD)
                                                        myCommand.Parameters.AddWithValue("?val18", Integer.Parse(RaceInfo.SyussoTosu))
                                                        myCommand.Parameters.AddWithValue("?val19", RaceInfo.HassoTime)
                                                        myCommand.Parameters.AddWithValue("?val20", RaceInfo.head.DataKubun)
                                                        myCommand.Parameters.AddWithValue("?val21", RaceInfo.head.MakeDate.Year & RaceInfo.head.MakeDate.Month & RaceInfo.head.MakeDate.Day)
                                                        'SQLを実行
                                                        myCommand.ExecuteNonQuery()
                                                    End If
                                                Catch ex As MySqlException
                                                    MessageBox.Show(ex.Message)
                                                End Try
                                            End If
                                        ElseIf Mid(strBuff, 1, 2) = "SE" Then
                                            '馬毎レース情報構造体への展開
                                            RaceUmaInfo.SetData(strBuff)
                                            If "01".Equals(RaceUmaInfo.id.JyoCD) OrElse "02".Equals(RaceUmaInfo.id.JyoCD) OrElse "03".Equals(RaceUmaInfo.id.JyoCD) OrElse "04".Equals(RaceUmaInfo.id.JyoCD) OrElse "05".Equals(RaceUmaInfo.id.JyoCD) OrElse "06".Equals(RaceUmaInfo.id.JyoCD) OrElse "07".Equals(RaceUmaInfo.id.JyoCD) OrElse "08".Equals(RaceUmaInfo.id.JyoCD) OrElse "09".Equals(RaceUmaInfo.id.JyoCD) OrElse "10".Equals(RaceUmaInfo.id.JyoCD) Then
                                                'ID
                                                Dim id As String = RaceUmaInfo.id.Year & RaceUmaInfo.id.MonthDay & RaceUmaInfo.id.JyoCD & RaceUmaInfo.id.Kaiji & RaceUmaInfo.id.Nichiji & RaceUmaInfo.id.RaceNum & RaceUmaInfo.Umaban
                                                'レースID
                                                Dim raceId As String = RaceUmaInfo.id.Year & RaceUmaInfo.id.MonthDay & RaceUmaInfo.id.JyoCD & RaceUmaInfo.id.Kaiji & RaceUmaInfo.id.Nichiji & RaceUmaInfo.id.RaceNum

                                                '異常区分
                                                Dim Ijyo As String = CodeConversion.IJyoCodeConversion(RaceUmaInfo.IJyoCD)
                                                '増減符号&増減差
                                                Dim Zougen As Integer = 99
                                                If "".Equals(Trim(RaceUmaInfo.ZogenSa)) Then
                                                Else
                                                    Zougen = Integer.Parse(RaceUmaInfo.ZogenSa)
                                                    If "-".Equals(RaceUmaInfo.ZogenFugo) Then
                                                        Zougen = 0 - Zougen
                                                    End If
                                                End If
                                                '今回レース脚質判定
                                                Dim Kyakusitu As String = CodeConversion.KyakusituCodeConversion(RaceUmaInfo.KyakusituKubun)
                                                '走破タイム
                                                Dim souhaTime As Single = MyUtil.TimeConversionFromMMSStoMM(RaceUmaInfo.Time)
                                                If "00".Equals(RaceUmaInfo.Umaban) Then
                                                Else
                                                    Try
                                                        Dim CommandText As String = "SELECT count(*) FROM jv_se_race_uma WHERE id = '" & id & "'"
                                                        Dim Command As New MySqlCommand(CommandText, con)
                                                        Dim count As Integer = Command.ExecuteScalar()
                                                        If count > 0 Then
                                                            CommandText = "SELECT data_kubun FROM jv_se_race_uma WHERE id = '" & id & "'"
                                                            Command = New MySqlCommand(CommandText, con)
                                                            Dim data_kubun As String = Command.ExecuteScalar()
                                                            'データ区分 1:出走馬名表(木曜)　2:出馬表(金･土曜)　3:速報成績(3着まで確定)　4:速報成績(5着まで確定) 
                                                            '5:速報成績(全馬着順確定)6:速報成績(全馬着順+コーナ通過順)　7:成績(月曜)　9:レース中止
                                                            If RaceUmaInfo.head.DataKubun.CompareTo(data_kubun) > 0 Then 'データ区分の値が大きければ更新
                                                                Dim myCommand As New MySqlCommand(CreateSQL.CreateJvSeRaceUmaUpdate, con)
                                                                myCommand.Parameters.AddWithValue("?val1", Integer.Parse(RaceUmaInfo.Futan) / 10)
                                                                If "".Equals(RaceUmaInfo.BaTaijyu.Trim()) Then
                                                                    myCommand.Parameters.AddWithValue("?val2", 0)
                                                                Else
                                                                    myCommand.Parameters.AddWithValue("?val2", RaceUmaInfo.BaTaijyu)
                                                                End If
                                                                myCommand.Parameters.AddWithValue("?val3", Zougen)
                                                                myCommand.Parameters.AddWithValue("?val4", Ijyo)
                                                                myCommand.Parameters.AddWithValue("?val5", Kyakusitu)
                                                                myCommand.Parameters.AddWithValue("?val6", Integer.Parse(RaceUmaInfo.Jyuni1c))
                                                                myCommand.Parameters.AddWithValue("?val7", Integer.Parse(RaceUmaInfo.Jyuni2c))
                                                                myCommand.Parameters.AddWithValue("?val8", Integer.Parse(RaceUmaInfo.Jyuni3c))
                                                                myCommand.Parameters.AddWithValue("?val9", Integer.Parse(RaceUmaInfo.Jyuni4c))
                                                                myCommand.Parameters.AddWithValue("?val10", Integer.Parse(RaceUmaInfo.KakuteiJyuni))
                                                                myCommand.Parameters.AddWithValue("?val11", Integer.Parse(RaceUmaInfo.Ninki))
                                                                myCommand.Parameters.AddWithValue("?val12", Integer.Parse(RaceUmaInfo.DochakuKubun))
                                                                myCommand.Parameters.AddWithValue("?val13", Integer.Parse(RaceUmaInfo.DochakuTosu))
                                                                myCommand.Parameters.AddWithValue("?val14", souhaTime)
                                                                myCommand.Parameters.AddWithValue("?val15", Integer.Parse(RaceUmaInfo.Odds) / 10)
                                                                myCommand.Parameters.AddWithValue("?val16", Integer.Parse(RaceUmaInfo.HaronTimeL3) / 10)
                                                                myCommand.Parameters.AddWithValue("?val17", Integer.Parse(RaceUmaInfo.TimeDiff) / 10)
                                                                myCommand.Parameters.AddWithValue("?val18", RaceUmaInfo.head.DataKubun)
                                                                myCommand.Parameters.AddWithValue("?val19", RaceUmaInfo.head.MakeDate.Year & RaceUmaInfo.head.MakeDate.Month & RaceUmaInfo.head.MakeDate.Day)
                                                                myCommand.Parameters.AddWithValue("?val20", id)
                                                                'SQLを実行
                                                                myCommand.ExecuteNonQuery()
                                                            End If
                                                        Else
                                                            Dim myCommand As New MySqlCommand(CreateSQL.CreateJvSeRaceUmaInsert, con)
                                                            'プレースホルダーにバインド
                                                            myCommand.Parameters.AddWithValue("?val1", id)
                                                            myCommand.Parameters.AddWithValue("?val2", raceId)
                                                            myCommand.Parameters.AddWithValue("?val3", RaceUmaInfo.KettoNum)
                                                            myCommand.Parameters.AddWithValue("?val4", RaceUmaInfo.Bamei)
                                                            myCommand.Parameters.AddWithValue("?val5", Integer.Parse(RaceUmaInfo.Futan) / 10)
                                                            If "".Equals(RaceUmaInfo.BaTaijyu.Trim()) Then
                                                                myCommand.Parameters.AddWithValue("?val6", 0)
                                                            Else
                                                                myCommand.Parameters.AddWithValue("?val6", RaceUmaInfo.BaTaijyu)
                                                            End If
                                                            myCommand.Parameters.AddWithValue("?val7", Zougen)
                                                            myCommand.Parameters.AddWithValue("?val8", Ijyo)
                                                            myCommand.Parameters.AddWithValue("?val9", Kyakusitu)
                                                            myCommand.Parameters.AddWithValue("?val10", Integer.Parse(RaceUmaInfo.Jyuni1c))
                                                            myCommand.Parameters.AddWithValue("?val11", Integer.Parse(RaceUmaInfo.Jyuni2c))
                                                            myCommand.Parameters.AddWithValue("?val12", Integer.Parse(RaceUmaInfo.Jyuni3c))
                                                            myCommand.Parameters.AddWithValue("?val13", Integer.Parse(RaceUmaInfo.Jyuni4c))
                                                            myCommand.Parameters.AddWithValue("?val14", Integer.Parse(RaceUmaInfo.KakuteiJyuni))
                                                            myCommand.Parameters.AddWithValue("?val15", Integer.Parse(RaceUmaInfo.Ninki))
                                                            myCommand.Parameters.AddWithValue("?val16", Integer.Parse(RaceUmaInfo.DochakuKubun))
                                                            myCommand.Parameters.AddWithValue("?val17", Integer.Parse(RaceUmaInfo.DochakuTosu))
                                                            myCommand.Parameters.AddWithValue("?val18", souhaTime)
                                                            myCommand.Parameters.AddWithValue("?val19", Integer.Parse(RaceUmaInfo.Odds) / 10)
                                                            myCommand.Parameters.AddWithValue("?val20", Integer.Parse(RaceUmaInfo.HaronTimeL3) / 10)
                                                            myCommand.Parameters.AddWithValue("?val21", Integer.Parse(RaceUmaInfo.TimeDiff) / 10)
                                                            myCommand.Parameters.AddWithValue("?val22", RaceUmaInfo.head.DataKubun)
                                                            myCommand.Parameters.AddWithValue("?val23", RaceUmaInfo.head.MakeDate.Year & RaceUmaInfo.head.MakeDate.Month & RaceUmaInfo.head.MakeDate.Day)
                                                            'SQLを実行
                                                            myCommand.ExecuteNonQuery()
                                                        End If
                                                    Catch ex As MySqlException
                                                        MessageBox.Show(ex.Message)
                                                    End Try
                                                End If
                                            End If
                                        ElseIf Mid(strBuff, 1, 2) = "HR" Then
                                            '馬毎レース情報構造体への展開
                                            PayInfo.SetData(strBuff)
                                            If "01".Equals(PayInfo.id.JyoCD) OrElse "02".Equals(PayInfo.id.JyoCD) OrElse "03".Equals(PayInfo.id.JyoCD) OrElse "04".Equals(PayInfo.id.JyoCD) OrElse "05".Equals(PayInfo.id.JyoCD) OrElse "06".Equals(PayInfo.id.JyoCD) OrElse "07".Equals(PayInfo.id.JyoCD) OrElse "08".Equals(PayInfo.id.JyoCD) OrElse "09".Equals(PayInfo.id.JyoCD) OrElse "10".Equals(PayInfo.id.JyoCD) Then
                                                ' セルに値をセット
                                                'レースID
                                                Dim raceid As String = PayInfo.id.Year & PayInfo.id.MonthDay & PayInfo.id.JyoCD & PayInfo.id.Kaiji & PayInfo.id.Nichiji & PayInfo.id.RaceNum
                                                '年月日
                                                Dim ymd As String = PayInfo.id.Year & "年" & PayInfo.id.MonthDay.Substring(0, 2) & "月" & PayInfo.id.MonthDay.Substring(2, 2) & "日"
                                                '競馬場
                                                Dim KeibaJyo As String = KeibaJyoCodeConversion(PayInfo.id.JyoCD)
                                                '単勝払戻１[馬番]
                                                Dim TanshoHaraimodoshi1Umaban As String = PayInfo.PayTansyo(0).Umaban
                                                '単勝払戻１[金額]
                                                Dim TanshoHaraimodoshi1KinGaku As Integer = Integer.Parse(PayInfo.PayTansyo(0).Pay)
                                                '単勝払戻１[人気]
                                                Dim TanshoHaraimodoshi1Ninki As Integer = Integer.Parse(PayInfo.PayTansyo(0).Ninki)
                                                '単勝払戻２[馬番]
                                                Dim TanshoHaraimodoshi2Umaban As String = ""
                                                '単勝払戻２[金額]
                                                Dim TanshoHaraimodoshi2KinGaku As Integer = 0
                                                '単勝払戻２[人気]
                                                Dim TanshoHaraimodoshi2Ninki As Integer = 0
                                                '単勝払戻３[馬番]
                                                Dim TanshoHaraimodoshi3Umaban As String = ""
                                                '単勝払戻３[金額]
                                                Dim TanshoHaraimodoshi3KinGaku As Integer = 0
                                                '単勝払戻３[人気]
                                                Dim TanshoHaraimodoshi3Ninki As Integer = 0
                                                If "".Equals(PayInfo.PayTansyo(1).Umaban.Trim()) Then
                                                Else
                                                    TanshoHaraimodoshi2Umaban = PayInfo.PayTansyo(1).Umaban
                                                    TanshoHaraimodoshi2KinGaku = Integer.Parse(PayInfo.PayTansyo(1).Pay)
                                                    TanshoHaraimodoshi2Ninki = Integer.Parse(PayInfo.PayTansyo(1).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PayTansyo(2).Umaban.Trim()) Then
                                                Else
                                                    TanshoHaraimodoshi3Umaban = PayInfo.PayTansyo(2).Umaban
                                                    TanshoHaraimodoshi3KinGaku = Integer.Parse(PayInfo.PayTansyo(2).Pay)
                                                    TanshoHaraimodoshi3Ninki = Integer.Parse(PayInfo.PayTansyo(2).Ninki)
                                                End If
                                                '馬連払戻１[馬番]
                                                Dim UmarenHaraimodoshi1Umaban As String = PayInfo.PayUmaren(0).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmaren(0).Kumi.Substring(2, 2)
                                                '馬連払戻１[金額]
                                                Dim UmarenHaraimodoshi1KinGaku As Integer = Integer.Parse(PayInfo.PayUmaren(0).Pay)
                                                '馬連払戻１[人気]
                                                Dim UmarenHaraimodoshi1Ninki As Integer = Integer.Parse(PayInfo.PayUmaren(0).Ninki)
                                                '馬連払戻２[馬番]
                                                Dim UmarenHaraimodoshi2Umaban As String = ""
                                                '馬連払戻２[金額]
                                                Dim UmarenHaraimodoshi2KinGaku As Integer = 0
                                                '馬連払戻２[人気]
                                                Dim UmarenHaraimodoshi2Ninki As Integer = 0
                                                '馬連払戻３[馬番]
                                                Dim UmarenHaraimodoshi3Umaban As String = ""
                                                '馬連払戻３[金額]
                                                Dim UmarenHaraimodoshi3KinGaku As Integer = 0
                                                '馬連払戻３[人気]
                                                Dim UmarenHaraimodoshi3Ninki As Integer = 0
                                                If "".Equals(PayInfo.PayUmaren(1).Kumi.Trim()) Then
                                                Else
                                                    UmarenHaraimodoshi2Umaban = PayInfo.PayUmaren(1).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmaren(1).Kumi.Substring(2, 2)
                                                    UmarenHaraimodoshi2KinGaku = Integer.Parse(PayInfo.PayUmaren(1).Pay)
                                                    UmarenHaraimodoshi2Ninki = Integer.Parse(PayInfo.PayUmaren(1).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PayUmaren(2).Kumi.Trim()) Then
                                                Else
                                                    UmarenHaraimodoshi3Umaban = PayInfo.PayUmaren(2).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmaren(2).Kumi.Substring(2, 2)
                                                    UmarenHaraimodoshi3KinGaku = Integer.Parse(PayInfo.PayUmaren(2).Pay)
                                                    UmarenHaraimodoshi3Ninki = Integer.Parse(PayInfo.PayUmaren(2).Ninki)
                                                End If
                                                '三連複払戻１[馬番]
                                                Dim SanrenpukuHaraimodoshi1Umaban As String = PayInfo.PaySanrenpuku(0).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrenpuku(0).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrenpuku(0).Kumi.Substring(4, 2)
                                                '三連複払戻１[金額]
                                                Dim SanrenpukuHaraimodoshi1KinGaku As Integer = Integer.Parse(PayInfo.PaySanrenpuku(0).Pay)
                                                '三連複払戻１[人気]
                                                Dim SanrenpukuHaraimodoshi1Ninki As Integer = Integer.Parse(PayInfo.PaySanrenpuku(0).Ninki)
                                                '三連複払戻２[馬番]
                                                Dim SanrenpukuHaraimodoshi2Umaban As String = ""
                                                '三連複払戻２[金額]
                                                Dim SanrenpukuHaraimodoshi2KinGaku As Integer = 0
                                                '三連複払戻２[人気]
                                                Dim SanrenpukuHaraimodoshi2Ninki As Integer = 0
                                                '三連複払戻３[馬番]
                                                Dim SanrenpukuHaraimodoshi3Umaban As String = ""
                                                '三連複払戻３[金額]
                                                Dim SanrenpukuHaraimodoshi3KinGaku As Integer = 0
                                                '三連複払戻３[人気]
                                                Dim SanrenpukuHaraimodoshi3Ninki As Integer = 0
                                                If "".Equals(PayInfo.PaySanrenpuku(1).Kumi.Trim()) Then
                                                Else
                                                    SanrenpukuHaraimodoshi2Umaban = PayInfo.PaySanrenpuku(1).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrenpuku(1).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrenpuku(1).Kumi.Substring(4, 2)
                                                    SanrenpukuHaraimodoshi2KinGaku = Integer.Parse(PayInfo.PaySanrenpuku(1).Pay)
                                                    SanrenpukuHaraimodoshi2Ninki = Integer.Parse(PayInfo.PaySanrenpuku(1).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PaySanrenpuku(2).Kumi.Trim()) Then
                                                Else
                                                    SanrenpukuHaraimodoshi3Umaban = PayInfo.PaySanrenpuku(2).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrenpuku(2).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrenpuku(2).Kumi.Substring(4, 2)
                                                    SanrenpukuHaraimodoshi3KinGaku = Integer.Parse(PayInfo.PaySanrenpuku(2).Pay)
                                                    SanrenpukuHaraimodoshi3Ninki = Integer.Parse(PayInfo.PaySanrenpuku(2).Ninki)
                                                End If
                                                '三連単払戻１[馬番]
                                                Dim SanrentanHaraimodoshi1Umaban As String = PayInfo.PaySanrentan(0).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrentan(0).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrentan(0).Kumi.Substring(4, 2)
                                                '三連単払戻１[金額]
                                                Dim SanrentanHaraimodoshi1KinGaku As Integer = 0
                                                If "".Equals(PayInfo.PaySanrentan(0).Pay.Trim()) Then
                                                Else
                                                    SanrentanHaraimodoshi1KinGaku = Integer.Parse(PayInfo.PaySanrentan(0).Pay)
                                                End If
                                                '三連単払戻１[人気]
                                                Dim SanrentanHaraimodoshi1Ninki As Integer = 0
                                                If "".Equals(PayInfo.PaySanrentan(0).Ninki.Trim()) Then
                                                Else
                                                    SanrentanHaraimodoshi1Ninki = Integer.Parse(PayInfo.PaySanrentan(0).Ninki)
                                                End If
                                                '三連単払戻２[馬番]
                                                Dim SanrentanHaraimodoshi2Umaban As String = ""
                                                '三連単払戻２[金額]
                                                Dim SanrentanHaraimodoshi2KinGaku As Integer = 0
                                                '三連単払戻２[人気]
                                                Dim SanrentanHaraimodoshi2Ninki As Integer = 0
                                                '三連単払戻３[馬番]
                                                Dim SanrentanHaraimodoshi3Umaban As String = ""
                                                '三連単払戻３[金額]
                                                Dim SanrentanHaraimodoshi3KinGaku As Integer = 0
                                                '三連単払戻３[人気]
                                                Dim SanrentanHaraimodoshi3Ninki As Integer = 0
                                                '三連単払戻４[馬番]
                                                Dim SanrentanHaraimodoshi4Umaban As String = ""
                                                '三連単払戻４[金額]
                                                Dim SanrentanHaraimodoshi4KinGaku As Integer = 0
                                                '三連単払戻４[人気]
                                                Dim SanrentanHaraimodoshi4Ninki As Integer = 0
                                                '三連単払戻５[馬番]
                                                Dim SanrentanHaraimodoshi5Umaban As String = ""
                                                '三連単払戻５[金額]
                                                Dim SanrentanHaraimodoshi5KinGaku As Integer = 0
                                                '三連単払戻５[人気]
                                                Dim SanrentanHaraimodoshi5Ninki As Integer = 0
                                                '三連単払戻６[馬番]
                                                Dim SanrentanHaraimodoshi6Umaban As String = ""
                                                '三連単払戻６[金額]
                                                Dim SanrentanHaraimodoshi6KinGaku As Integer = 0
                                                '三連単払戻６[人気]
                                                Dim SanrentanHaraimodoshi6Ninki As Integer = 0
                                                If "".Equals(PayInfo.PaySanrentan(1).Kumi.Trim()) Then
                                                Else
                                                    SanrentanHaraimodoshi2Umaban = PayInfo.PaySanrentan(1).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrentan(1).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrentan(1).Kumi.Substring(4, 2)
                                                    SanrentanHaraimodoshi2KinGaku = Integer.Parse(PayInfo.PaySanrentan(1).Pay)
                                                    SanrentanHaraimodoshi2Ninki = Integer.Parse(PayInfo.PaySanrentan(1).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PaySanrentan(2).Kumi.Trim()) Then
                                                Else
                                                    SanrentanHaraimodoshi3Umaban = PayInfo.PaySanrentan(2).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrentan(2).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrentan(2).Kumi.Substring(4, 2)
                                                    SanrentanHaraimodoshi3KinGaku = Integer.Parse(PayInfo.PaySanrentan(2).Pay)
                                                    SanrentanHaraimodoshi3Ninki = Integer.Parse(PayInfo.PaySanrentan(2).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PaySanrentan(3).Kumi.Trim()) Then
                                                Else
                                                    SanrentanHaraimodoshi4Umaban = PayInfo.PaySanrentan(3).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrentan(3).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrentan(3).Kumi.Substring(4, 2)
                                                    SanrentanHaraimodoshi4KinGaku = Integer.Parse(PayInfo.PaySanrentan(3).Pay)
                                                    SanrentanHaraimodoshi4Ninki = Integer.Parse(PayInfo.PaySanrentan(3).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PaySanrentan(4).Kumi.Trim()) Then
                                                Else
                                                    SanrentanHaraimodoshi5Umaban = PayInfo.PaySanrentan(4).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrentan(4).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrentan(4).Kumi.Substring(4, 2)
                                                    SanrentanHaraimodoshi5KinGaku = Integer.Parse(PayInfo.PaySanrentan(4).Pay)
                                                    SanrentanHaraimodoshi5Ninki = Integer.Parse(PayInfo.PaySanrentan(4).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PaySanrentan(5).Kumi.Trim()) Then
                                                Else
                                                    SanrentanHaraimodoshi6Umaban = PayInfo.PaySanrentan(5).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrentan(5).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrentan(5).Kumi.Substring(4, 2)
                                                    SanrentanHaraimodoshi6KinGaku = Integer.Parse(PayInfo.PaySanrentan(5).Pay)
                                                    SanrentanHaraimodoshi6Ninki = Integer.Parse(PayInfo.PaySanrentan(5).Ninki)
                                                End If
                                                'ワイド払戻１[馬番]
                                                Dim WideHaraimodoshi1Umaban As String = PayInfo.PayWide(0).Kumi.Substring(0, 2) & "-" & PayInfo.PayWide(0).Kumi.Substring(2, 2)
                                                'ワイド払戻１[金額]
                                                Dim WideHaraimodoshi1KinGaku As Integer = Integer.Parse(PayInfo.PayWide(0).Pay)
                                                'ワイド払戻１[人気]
                                                Dim WideHaraimodoshi1Ninki As Integer = Integer.Parse(PayInfo.PayWide(0).Ninki)
                                                'ワイド払戻２[馬番]
                                                Dim WideHaraimodoshi2Umaban As String = ""
                                                'ワイド払戻２[金額]
                                                Dim WideHaraimodoshi2KinGaku As Integer = 0
                                                'ワイド払戻２[人気]
                                                Dim WideHaraimodoshi2Ninki As Integer = 0
                                                'ワイド払戻３[馬番]
                                                Dim WideHaraimodoshi3Umaban As String = ""
                                                'ワイド払戻３[金額]
                                                Dim WideHaraimodoshi3KinGaku As Integer = 0
                                                'ワイド払戻３[人気]
                                                Dim WideHaraimodoshi3Ninki As Integer = 0
                                                'ワイド払戻４[馬番]
                                                Dim WideHaraimodoshi4Umaban As String = ""
                                                'ワイド払戻４[金額]
                                                Dim WideHaraimodoshi4KinGaku As Integer = 0
                                                'ワイド払戻４[人気]
                                                Dim WideHaraimodoshi4Ninki As Integer = 0
                                                'ワイド払戻５[馬番]
                                                Dim WideHaraimodoshi5Umaban As String = ""
                                                'ワイド払戻５[金額]
                                                Dim WideHaraimodoshi5KinGaku As Integer = 0
                                                'ワイド払戻５[人気]
                                                Dim WideHaraimodoshi5Ninki As Integer = 0
                                                'ワイド払戻６[馬番]
                                                Dim WideHaraimodoshi6Umaban As String = ""
                                                'ワイド払戻６[金額]
                                                Dim WideHaraimodoshi6KinGaku As Integer = 0
                                                'ワイド払戻６[人気]
                                                Dim WideHaraimodoshi6Ninki As Integer = 0
                                                'ワイド払戻７[馬番]
                                                Dim WideHaraimodoshi7Umaban As String = ""
                                                'ワイド払戻７[金額]
                                                Dim WideHaraimodoshi7KinGaku As Integer = 0
                                                'ワイド払戻７[人気]
                                                Dim WideHaraimodoshi7Ninki As Integer = 0
                                                If "".Equals(PayInfo.PayWide(1).Kumi.Trim()) Then
                                                Else
                                                    WideHaraimodoshi2Umaban = PayInfo.PayWide(1).Kumi.Substring(0, 2) & "-" & PayInfo.PayWide(1).Kumi.Substring(2, 2)
                                                    WideHaraimodoshi2KinGaku = Integer.Parse(PayInfo.PayWide(1).Pay)
                                                    WideHaraimodoshi2Ninki = Integer.Parse(PayInfo.PayWide(1).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PayWide(2).Kumi.Trim()) Then
                                                Else
                                                    WideHaraimodoshi3Umaban = PayInfo.PayWide(2).Kumi.Substring(0, 2) & "-" & PayInfo.PayWide(2).Kumi.Substring(2, 2)
                                                    WideHaraimodoshi3KinGaku = Integer.Parse(PayInfo.PayWide(2).Pay)
                                                    WideHaraimodoshi3Ninki = Integer.Parse(PayInfo.PayWide(2).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PayWide(3).Kumi.Trim()) Then
                                                Else
                                                    WideHaraimodoshi4Umaban = PayInfo.PayWide(3).Kumi.Substring(0, 2) & "-" & PayInfo.PayWide(3).Kumi.Substring(2, 2)
                                                    WideHaraimodoshi4KinGaku = Integer.Parse(PayInfo.PayWide(3).Pay)
                                                    WideHaraimodoshi4Ninki = Integer.Parse(PayInfo.PayWide(3).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PayWide(4).Kumi.Trim()) Then
                                                Else
                                                    WideHaraimodoshi5Umaban = PayInfo.PayWide(4).Kumi.Substring(0, 2) & "-" & PayInfo.PayWide(4).Kumi.Substring(2, 2)
                                                    WideHaraimodoshi5KinGaku = Integer.Parse(PayInfo.PayWide(4).Pay)
                                                    WideHaraimodoshi5Ninki = Integer.Parse(PayInfo.PayWide(4).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PayWide(5).Kumi.Trim()) Then
                                                Else
                                                    WideHaraimodoshi6Umaban = PayInfo.PayWide(5).Kumi.Substring(0, 2) & "-" & PayInfo.PayWide(5).Kumi.Substring(2, 2)
                                                    WideHaraimodoshi6KinGaku = Integer.Parse(PayInfo.PayWide(5).Pay)
                                                    WideHaraimodoshi6Ninki = Integer.Parse(PayInfo.PayWide(5).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PayWide(6).Kumi.Trim()) Then
                                                Else
                                                    WideHaraimodoshi7Umaban = PayInfo.PayWide(6).Kumi.Substring(0, 2) & "-" & PayInfo.PayWide(6).Kumi.Substring(2, 2)
                                                    WideHaraimodoshi7KinGaku = Integer.Parse(PayInfo.PayWide(6).Pay)
                                                    WideHaraimodoshi7Ninki = Integer.Parse(PayInfo.PayWide(6).Ninki)
                                                End If
                                                '馬単払戻１[馬番]
                                                Dim UmatanHaraimodoshi1Umaban As String = PayInfo.PayUmatan(0).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmatan(0).Kumi.Substring(2, 2)
                                                '馬単払戻１[金額]
                                                Dim UmatanHaraimodoshi1KinGaku As Integer = Integer.Parse(PayInfo.PayUmatan(0).Pay)
                                                '馬単払戻１[人気]
                                                Dim UmatanHaraimodoshi1Ninki As Integer = Integer.Parse(PayInfo.PayUmatan(0).Ninki)
                                                '馬単払戻２[馬番]
                                                Dim UmatanHaraimodoshi2Umaban As String = ""
                                                '馬単払戻２[金額]
                                                Dim UmatanHaraimodoshi2KinGaku As Integer = 0
                                                '馬単払戻２[人気]
                                                Dim UmatanHaraimodoshi2Ninki As Integer = 0
                                                '馬単払戻３[馬番]
                                                Dim UmatanHaraimodoshi3Umaban As String = ""
                                                '馬単払戻３[金額]
                                                Dim UmatanHaraimodoshi3KinGaku As Integer = 0
                                                '馬単払戻３[人気]
                                                Dim UmatanHaraimodoshi3Ninki As Integer = 0
                                                '馬単払戻４[馬番]
                                                Dim UmatanHaraimodoshi4Umaban As String = ""
                                                '馬単払戻４[金額]
                                                Dim UmatanHaraimodoshi4KinGaku As Integer = 0
                                                '馬単払戻４[人気]
                                                Dim UmatanHaraimodoshi4Ninki As Integer = 0
                                                '馬単払戻５[馬番]
                                                Dim UmatanHaraimodoshi5Umaban As String = ""
                                                '馬単払戻５[金額]
                                                Dim UmatanHaraimodoshi5KinGaku As Integer = 0
                                                '馬単払戻５[人気]
                                                Dim UmatanHaraimodoshi5Ninki As Integer = 0
                                                '馬単払戻６[馬番]
                                                Dim UmatanHaraimodoshi6Umaban As String = ""
                                                '馬単払戻６[金額]
                                                Dim UmatanHaraimodoshi6KinGaku As Integer = 0
                                                '馬単払戻６[人気]
                                                Dim UmatanHaraimodoshi6Ninki As Integer = 0
                                                If "".Equals(PayInfo.PayUmatan(1).Kumi.Trim()) Then
                                                Else
                                                    UmatanHaraimodoshi2Umaban = PayInfo.PayUmatan(1).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmatan(1).Kumi.Substring(2, 2)
                                                    UmatanHaraimodoshi2KinGaku = Integer.Parse(PayInfo.PayUmatan(1).Pay)
                                                    UmatanHaraimodoshi2Ninki = Integer.Parse(PayInfo.PayUmatan(1).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PayUmatan(2).Kumi.Trim()) Then
                                                Else
                                                    UmatanHaraimodoshi3Umaban = PayInfo.PayUmatan(2).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmatan(2).Kumi.Substring(2, 2)
                                                    UmatanHaraimodoshi3KinGaku = Integer.Parse(PayInfo.PayUmatan(2).Pay)
                                                    UmatanHaraimodoshi3Ninki = Integer.Parse(PayInfo.PayUmatan(2).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PayUmatan(3).Kumi.Trim()) Then
                                                Else
                                                    UmatanHaraimodoshi4Umaban = PayInfo.PayUmatan(3).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmatan(3).Kumi.Substring(2, 2)
                                                    UmatanHaraimodoshi4KinGaku = Integer.Parse(PayInfo.PayUmatan(3).Pay)
                                                    UmatanHaraimodoshi4Ninki = Integer.Parse(PayInfo.PayUmatan(3).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PayUmatan(4).Kumi.Trim()) Then
                                                Else
                                                    UmatanHaraimodoshi5Umaban = PayInfo.PayUmatan(4).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmatan(4).Kumi.Substring(2, 2)
                                                    UmatanHaraimodoshi5KinGaku = Integer.Parse(PayInfo.PayUmatan(4).Pay)
                                                    UmatanHaraimodoshi5Ninki = Integer.Parse(PayInfo.PayUmatan(4).Ninki)
                                                End If
                                                If "".Equals(PayInfo.PayUmatan(5).Kumi.Trim()) Then
                                                Else
                                                    UmatanHaraimodoshi6Umaban = PayInfo.PayUmatan(5).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmatan(5).Kumi.Substring(2, 2)
                                                    UmatanHaraimodoshi6KinGaku = Integer.Parse(PayInfo.PayUmatan(5).Pay)
                                                    UmatanHaraimodoshi6Ninki = Integer.Parse(PayInfo.PayUmatan(5).Ninki)
                                                End If
                                                Try
                                                    Dim CommandText As String = "Select count(*) FROM jv_hr_pay WHERE race_id = '" & raceid & "'"
                                                    Dim Command As New MySqlCommand(CommandText, con)
                                                    Dim count As Integer = Command.ExecuteScalar()
                                                    If count > 0 Then
                                                        CommandText = "SELECT data_kubun FROM jv_hr_pay WHERE race_id = '" & raceid & "'"
                                                        Command = New MySqlCommand(CommandText, con)
                                                        Dim data_kubun As String = Command.ExecuteScalar()
                                                        'データ区分 1:速報成績(払戻金確定)　2:成績(月曜) 9:レース中止
                                                        If PayInfo.head.DataKubun.CompareTo(data_kubun) > 0 Then 'データ区分の値が大きければ更新
                                                            Dim myCommand As New MySqlCommand(CreateSQL.CreateJvHrPayUpdate(), con)
                                                            myCommand.Parameters.AddWithValue("?val1", TanshoHaraimodoshi1Umaban)
                                                            myCommand.Parameters.AddWithValue("?val2", TanshoHaraimodoshi1KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val3", TanshoHaraimodoshi1Ninki)
                                                            myCommand.Parameters.AddWithValue("?val4", TanshoHaraimodoshi2Umaban)
                                                            myCommand.Parameters.AddWithValue("?val5", TanshoHaraimodoshi2KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val6", TanshoHaraimodoshi2Ninki)
                                                            myCommand.Parameters.AddWithValue("?val7", TanshoHaraimodoshi3Umaban)
                                                            myCommand.Parameters.AddWithValue("?val8", TanshoHaraimodoshi3KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val9", TanshoHaraimodoshi3Ninki)
                                                            myCommand.Parameters.AddWithValue("?val10", UmarenHaraimodoshi1Umaban)
                                                            myCommand.Parameters.AddWithValue("?val11", UmarenHaraimodoshi1KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val12", UmarenHaraimodoshi1Ninki)
                                                            myCommand.Parameters.AddWithValue("?val13", UmarenHaraimodoshi2Umaban)
                                                            myCommand.Parameters.AddWithValue("?val14", UmarenHaraimodoshi2KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val15", UmarenHaraimodoshi2Ninki)
                                                            myCommand.Parameters.AddWithValue("?val16", UmarenHaraimodoshi3Umaban)
                                                            myCommand.Parameters.AddWithValue("?val17", UmarenHaraimodoshi3KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val18", UmarenHaraimodoshi3Ninki)
                                                            myCommand.Parameters.AddWithValue("?val19", SanrenpukuHaraimodoshi1Umaban)
                                                            myCommand.Parameters.AddWithValue("?val20", SanrenpukuHaraimodoshi1KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val21", SanrenpukuHaraimodoshi1Ninki)
                                                            myCommand.Parameters.AddWithValue("?val22", SanrenpukuHaraimodoshi2Umaban)
                                                            myCommand.Parameters.AddWithValue("?val23", SanrenpukuHaraimodoshi2KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val24", SanrenpukuHaraimodoshi2Ninki)
                                                            myCommand.Parameters.AddWithValue("?val25", SanrenpukuHaraimodoshi3Umaban)
                                                            myCommand.Parameters.AddWithValue("?val26", SanrenpukuHaraimodoshi3KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val27", SanrenpukuHaraimodoshi3Ninki)
                                                            myCommand.Parameters.AddWithValue("?val28", SanrentanHaraimodoshi1Umaban)
                                                            myCommand.Parameters.AddWithValue("?val29", SanrentanHaraimodoshi1KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val30", SanrentanHaraimodoshi1Ninki)
                                                            myCommand.Parameters.AddWithValue("?val31", SanrentanHaraimodoshi2Umaban)
                                                            myCommand.Parameters.AddWithValue("?val32", SanrentanHaraimodoshi2KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val33", SanrentanHaraimodoshi2Ninki)
                                                            myCommand.Parameters.AddWithValue("?val34", SanrentanHaraimodoshi3Umaban)
                                                            myCommand.Parameters.AddWithValue("?val35", SanrentanHaraimodoshi3KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val36", SanrentanHaraimodoshi3Ninki)
                                                            myCommand.Parameters.AddWithValue("?val37", SanrentanHaraimodoshi4Umaban)
                                                            myCommand.Parameters.AddWithValue("?val38", SanrentanHaraimodoshi4KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val39", SanrentanHaraimodoshi4Ninki)
                                                            myCommand.Parameters.AddWithValue("?val40", SanrentanHaraimodoshi5Umaban)
                                                            myCommand.Parameters.AddWithValue("?val41", SanrentanHaraimodoshi5KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val42", SanrentanHaraimodoshi5Ninki)
                                                            myCommand.Parameters.AddWithValue("?val43", SanrentanHaraimodoshi6Umaban)
                                                            myCommand.Parameters.AddWithValue("?val44", SanrentanHaraimodoshi6KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val45", SanrentanHaraimodoshi6Ninki)
                                                            myCommand.Parameters.AddWithValue("?val46", WideHaraimodoshi1Umaban)
                                                            myCommand.Parameters.AddWithValue("?val47", WideHaraimodoshi1KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val48", WideHaraimodoshi1Ninki)
                                                            myCommand.Parameters.AddWithValue("?val49", WideHaraimodoshi2Umaban)
                                                            myCommand.Parameters.AddWithValue("?val50", WideHaraimodoshi2KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val51", WideHaraimodoshi2Ninki)
                                                            myCommand.Parameters.AddWithValue("?val52", WideHaraimodoshi3Umaban)
                                                            myCommand.Parameters.AddWithValue("?val53", WideHaraimodoshi3KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val54", WideHaraimodoshi3Ninki)
                                                            myCommand.Parameters.AddWithValue("?val55", WideHaraimodoshi4Umaban)
                                                            myCommand.Parameters.AddWithValue("?val56", WideHaraimodoshi4KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val57", WideHaraimodoshi4Ninki)
                                                            myCommand.Parameters.AddWithValue("?val58", WideHaraimodoshi5Umaban)
                                                            myCommand.Parameters.AddWithValue("?val59", WideHaraimodoshi5KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val60", WideHaraimodoshi5Ninki)
                                                            myCommand.Parameters.AddWithValue("?val61", WideHaraimodoshi6Umaban)
                                                            myCommand.Parameters.AddWithValue("?val62", WideHaraimodoshi6KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val63", WideHaraimodoshi6Ninki)
                                                            myCommand.Parameters.AddWithValue("?val64", WideHaraimodoshi7Umaban)
                                                            myCommand.Parameters.AddWithValue("?val65", WideHaraimodoshi7KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val66", WideHaraimodoshi7Ninki)
                                                            myCommand.Parameters.AddWithValue("?val67", UmatanHaraimodoshi1Umaban)
                                                            myCommand.Parameters.AddWithValue("?val68", UmatanHaraimodoshi1KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val69", UmatanHaraimodoshi1Ninki)
                                                            myCommand.Parameters.AddWithValue("?val70", UmatanHaraimodoshi2Umaban)
                                                            myCommand.Parameters.AddWithValue("?val71", UmatanHaraimodoshi2KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val72", UmatanHaraimodoshi2Ninki)
                                                            myCommand.Parameters.AddWithValue("?val73", UmatanHaraimodoshi3Umaban)
                                                            myCommand.Parameters.AddWithValue("?val74", UmatanHaraimodoshi3KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val75", UmatanHaraimodoshi3Ninki)
                                                            myCommand.Parameters.AddWithValue("?val76", UmatanHaraimodoshi4Umaban)
                                                            myCommand.Parameters.AddWithValue("?val77", UmatanHaraimodoshi4KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val78", UmatanHaraimodoshi4Ninki)
                                                            myCommand.Parameters.AddWithValue("?val79", UmatanHaraimodoshi5Umaban)
                                                            myCommand.Parameters.AddWithValue("?val80", UmatanHaraimodoshi5KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val81", UmatanHaraimodoshi5Ninki)
                                                            myCommand.Parameters.AddWithValue("?val82", UmatanHaraimodoshi6Umaban)
                                                            myCommand.Parameters.AddWithValue("?val83", UmatanHaraimodoshi6KinGaku)
                                                            myCommand.Parameters.AddWithValue("?val84", UmatanHaraimodoshi6Ninki)
                                                            myCommand.Parameters.AddWithValue("?val85", PayInfo.head.DataKubun)
                                                            myCommand.Parameters.AddWithValue("?val86", PayInfo.head.MakeDate.Year & PayInfo.head.MakeDate.Month & PayInfo.head.MakeDate.Day)
                                                            myCommand.Parameters.AddWithValue("?val87", raceid)
                                                            'SQLを実行
                                                            myCommand.ExecuteNonQuery()
                                                        End If
                                                    Else
                                                        Dim myCommand As New MySqlCommand(CreateSQL.CreateJvHrPayInsert(), con)
                                                        'プレースホルダーにバインド
                                                        myCommand.Parameters.AddWithValue("?val1", raceid)
                                                        myCommand.Parameters.AddWithValue("?val2", PayInfo.id.Year)
                                                        myCommand.Parameters.AddWithValue("?val3", PayInfo.id.MonthDay.Substring(0, 2))
                                                        myCommand.Parameters.AddWithValue("?val4", PayInfo.id.MonthDay.Substring(2, 2))
                                                        myCommand.Parameters.AddWithValue("?val5", KeibaJyo)
                                                        myCommand.Parameters.AddWithValue("?val6", PayInfo.id.RaceNum)
                                                        myCommand.Parameters.AddWithValue("?val7", TanshoHaraimodoshi1Umaban)
                                                        myCommand.Parameters.AddWithValue("?val8", TanshoHaraimodoshi1KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val9", TanshoHaraimodoshi1Ninki)
                                                        myCommand.Parameters.AddWithValue("?val10", TanshoHaraimodoshi2Umaban)
                                                        myCommand.Parameters.AddWithValue("?val11", TanshoHaraimodoshi2KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val12", TanshoHaraimodoshi2Ninki)
                                                        myCommand.Parameters.AddWithValue("?val13", TanshoHaraimodoshi3Umaban)
                                                        myCommand.Parameters.AddWithValue("?val14", TanshoHaraimodoshi3KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val15", TanshoHaraimodoshi3Ninki)
                                                        myCommand.Parameters.AddWithValue("?val16", UmarenHaraimodoshi1Umaban)
                                                        myCommand.Parameters.AddWithValue("?val17", UmarenHaraimodoshi1KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val18", UmarenHaraimodoshi1Ninki)
                                                        myCommand.Parameters.AddWithValue("?val19", UmarenHaraimodoshi2Umaban)
                                                        myCommand.Parameters.AddWithValue("?val20", UmarenHaraimodoshi2KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val21", UmarenHaraimodoshi2Ninki)
                                                        myCommand.Parameters.AddWithValue("?val22", UmarenHaraimodoshi3Umaban)
                                                        myCommand.Parameters.AddWithValue("?val23", UmarenHaraimodoshi3KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val24", UmarenHaraimodoshi3Ninki)
                                                        myCommand.Parameters.AddWithValue("?val25", SanrenpukuHaraimodoshi1Umaban)
                                                        myCommand.Parameters.AddWithValue("?val26", SanrenpukuHaraimodoshi1KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val27", SanrenpukuHaraimodoshi1Ninki)
                                                        myCommand.Parameters.AddWithValue("?val28", SanrenpukuHaraimodoshi2Umaban)
                                                        myCommand.Parameters.AddWithValue("?val29", SanrenpukuHaraimodoshi2KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val30", SanrenpukuHaraimodoshi2Ninki)
                                                        myCommand.Parameters.AddWithValue("?val31", SanrenpukuHaraimodoshi3Umaban)
                                                        myCommand.Parameters.AddWithValue("?val32", SanrenpukuHaraimodoshi3KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val33", SanrenpukuHaraimodoshi3Ninki)
                                                        myCommand.Parameters.AddWithValue("?val34", SanrentanHaraimodoshi1Umaban)
                                                        myCommand.Parameters.AddWithValue("?val35", SanrentanHaraimodoshi1KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val36", SanrentanHaraimodoshi1Ninki)
                                                        myCommand.Parameters.AddWithValue("?val37", SanrentanHaraimodoshi2Umaban)
                                                        myCommand.Parameters.AddWithValue("?val38", SanrentanHaraimodoshi2KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val39", SanrentanHaraimodoshi2Ninki)
                                                        myCommand.Parameters.AddWithValue("?val40", SanrentanHaraimodoshi3Umaban)
                                                        myCommand.Parameters.AddWithValue("?val41", SanrentanHaraimodoshi3KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val42", SanrentanHaraimodoshi3Ninki)
                                                        myCommand.Parameters.AddWithValue("?val43", SanrentanHaraimodoshi4Umaban)
                                                        myCommand.Parameters.AddWithValue("?val44", SanrentanHaraimodoshi4KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val45", SanrentanHaraimodoshi4Ninki)
                                                        myCommand.Parameters.AddWithValue("?val46", SanrentanHaraimodoshi5Umaban)
                                                        myCommand.Parameters.AddWithValue("?val47", SanrentanHaraimodoshi5KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val48", SanrentanHaraimodoshi5Ninki)
                                                        myCommand.Parameters.AddWithValue("?val49", SanrentanHaraimodoshi6Umaban)
                                                        myCommand.Parameters.AddWithValue("?val50", SanrentanHaraimodoshi6KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val51", SanrentanHaraimodoshi6Ninki)
                                                        myCommand.Parameters.AddWithValue("?val52", WideHaraimodoshi1Umaban)
                                                        myCommand.Parameters.AddWithValue("?val53", WideHaraimodoshi1KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val54", WideHaraimodoshi1Ninki)
                                                        myCommand.Parameters.AddWithValue("?val55", WideHaraimodoshi2Umaban)
                                                        myCommand.Parameters.AddWithValue("?val56", WideHaraimodoshi2KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val57", WideHaraimodoshi2Ninki)
                                                        myCommand.Parameters.AddWithValue("?val58", WideHaraimodoshi3Umaban)
                                                        myCommand.Parameters.AddWithValue("?val59", WideHaraimodoshi3KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val60", WideHaraimodoshi3Ninki)
                                                        myCommand.Parameters.AddWithValue("?val61", WideHaraimodoshi4Umaban)
                                                        myCommand.Parameters.AddWithValue("?val62", WideHaraimodoshi4KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val63", WideHaraimodoshi4Ninki)
                                                        myCommand.Parameters.AddWithValue("?val64", WideHaraimodoshi5Umaban)
                                                        myCommand.Parameters.AddWithValue("?val65", WideHaraimodoshi5KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val66", WideHaraimodoshi5Ninki)
                                                        myCommand.Parameters.AddWithValue("?val67", WideHaraimodoshi6Umaban)
                                                        myCommand.Parameters.AddWithValue("?val68", WideHaraimodoshi6KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val69", WideHaraimodoshi6Ninki)
                                                        myCommand.Parameters.AddWithValue("?val70", WideHaraimodoshi7Umaban)
                                                        myCommand.Parameters.AddWithValue("?val71", WideHaraimodoshi7KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val72", WideHaraimodoshi7Ninki)
                                                        myCommand.Parameters.AddWithValue("?val73", UmatanHaraimodoshi1Umaban)
                                                        myCommand.Parameters.AddWithValue("?val74", UmatanHaraimodoshi1KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val75", UmatanHaraimodoshi1Ninki)
                                                        myCommand.Parameters.AddWithValue("?val76", UmatanHaraimodoshi2Umaban)
                                                        myCommand.Parameters.AddWithValue("?val77", UmatanHaraimodoshi2KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val78", UmatanHaraimodoshi2Ninki)
                                                        myCommand.Parameters.AddWithValue("?val79", UmatanHaraimodoshi3Umaban)
                                                        myCommand.Parameters.AddWithValue("?val80", UmatanHaraimodoshi3KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val81", UmatanHaraimodoshi3Ninki)
                                                        myCommand.Parameters.AddWithValue("?val82", UmatanHaraimodoshi4Umaban)
                                                        myCommand.Parameters.AddWithValue("?val83", UmatanHaraimodoshi4KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val84", UmatanHaraimodoshi4Ninki)
                                                        myCommand.Parameters.AddWithValue("?val85", UmatanHaraimodoshi5Umaban)
                                                        myCommand.Parameters.AddWithValue("?val86", UmatanHaraimodoshi5KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val87", UmatanHaraimodoshi5Ninki)
                                                        myCommand.Parameters.AddWithValue("?val88", UmatanHaraimodoshi6Umaban)
                                                        myCommand.Parameters.AddWithValue("?val89", UmatanHaraimodoshi6KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val90", UmatanHaraimodoshi6Ninki)
                                                        myCommand.Parameters.AddWithValue("?val91", PayInfo.head.DataKubun)
                                                        myCommand.Parameters.AddWithValue("?val92", PayInfo.head.MakeDate.Year & PayInfo.head.MakeDate.Month & PayInfo.head.MakeDate.Day)

                                                        'SQLを実行
                                                        myCommand.ExecuteNonQuery()
                                                    End If
                                                Catch ex As MySqlException
                                                    MessageBox.Show(ex.Message)
                                                End Try
                                            End If
                                        End If
                                End Select
                            Loop While (1)
                        End Using
                    End If
                    'タイマ有効時は、無効化する
                    If TimerDownload.Enabled = True Then
                        TimerDownload.Enabled = False
                    End If
                End If
            End If
        Catch
            Debug.WriteLine(Err.Description)
            Exit Sub
        End Try
        'JVLink 終了処理
        lReturnCode = Me.AxJVLink1.JVClose()
        If lReturnCode <> 0 Then
            MsgBox("JVClose エラー：" & lReturnCode)
        End If
        MsgBox("登録完了しました。")
    End Sub

    Private Sub getDiffBtn_Click(sender As Object, e As EventArgs) Handles getDiffBtn.Click
        Using con As MySqlConnection = DBManager.CreateMySqlConnection
            Try
                Dim CommandText As String = "SELECT count(data_sakusei_day) FROM jv_um_uma"
                Dim Command As New MySqlCommand(CommandText, con)
                Dim count As String = Command.ExecuteScalar()
                If count > 0 Then
                    CommandText = "SELECT max(data_sakusei_day) FROM jv_um_uma"
                    Command = New MySqlCommand(CommandText, con)
                    Dim max As String = Command.ExecuteScalar()
                    Me.strFromTime = Integer.Parse(max) & "000000"
                Else
                    Me.strFromTime = "20050101000000"
                End If
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            End Try
        End Using
        Dim lReturnCode As Long
        Try
            Dim strDataSpec As String '' 引数 JVOpen:ファイル識別子
            'Dim strFromTime As String '' 引数 JVOpen:データ提供日付
            Dim lOption As Long '' 引数 JVOpen:オプション
            Dim lReadCount As Long '' JVLink 戻り値
            Dim strLastFileTimestamp As String = "" '' JVOpen: 最新ファイルのタイムスタンプ
            Const lBuffSize As Long = 110000 ''JVRead:データ格納バッファサイズ
            Const lNameSize As Integer = 256 ''JVRead:ファイル名サイズ
            Dim strBuff As String ''JVRead:データ格納バッファ
            Dim strFileName As String ''JVRead:ダウンロードファイル名
            Dim KyousoubaMaster As JV_UM_UMA = New JV_UM_UMA() ''競走馬マスタ構造体
            '進捗表示初期設定
            TimerDownload.Enabled = False ''タイマー停止
            prgJVRead.Value = 0 ''JVData読み込み進捗
            '引数設定
            strDataSpec = "DIFF"
            'strFromTime = "20160415000000"
            lOption = "1"
            ' JVLinkダウンロード処理
            lReturnCode = Me.AxJVLink1.JVOpen(strDataSpec, Me.strFromTime, lOption,
            lReadCount, lDownloadCount, strLastFileTimestamp)
            'エラー判定
            If lReturnCode = -1 Then
                MsgBox("取得データなし")
                Exit Sub
            Else
                If lReturnCode <> 0 Then
                    MsgBox("JVOpenエラー：" & lReturnCode)
                Else
                    MsgBox("戻り値 : " & lReturnCode & vbCrLf &
                    "読み込みファイル数 : " & lReadCount & vbCrLf &
                    "ダウンロードファイル数 : " & lDownloadCount & vbCrLf &
                    "タイムスタンプ : " & strLastFileTimestamp)
                    '進捗表示プログレスバー最大値設定
                    prgJVRead.Maximum = lReadCount
                    If lReadCount > 0 Then
                        Using con As MySqlConnection = DBManager.CreateMySqlConnection
                            Do
                                'バックグラウンドでの処理を実行
                                Application.DoEvents()
                                'バッファ作成
                                strBuff = New String(vbNullChar, lBuffSize)
                                strFileName = New String(vbNullChar, lNameSize)
                                'JVReadで１行読み込み
                                lReturnCode = Me.AxJVLink1.JVRead(strBuff, lBuffSize, strFileName)
                                Dim CurrentFileTimeStamp As String = Me.AxJVLink1.m_CurrentFileTimeStamp
                                'リターンコードにより処理を分枝
                                Select Case lReturnCode
                                    Case 0 ' 全ファイル読み込み終了
                                        prgJVRead.Value = prgJVRead.Maximum '進捗表示
                                        Exit Do
                                    Case -1 ' ファイル切り替わり
                                        prgJVRead.Value = prgJVRead.Value + 1
                                    Case -3 ' ダウンロード中
                                    Case -201 ' Initされてない
                                        MsgBox("JVInitが行われていません。")
                                        Exit Do
                                    Case -203 ' Openされてない
                                        MsgBox("JVOpenが行われていません。")
                                        Exit Do
                                    Case -503 ' ファイルがない
                                        MsgBox(strFileName & "が存在しません。")
                                        Exit Do
                                    Case Is > 0 ' 正常読み込み
                                        'レコード種別IDの識別
                                        If Mid(strBuff, 1, 2) = "UM" Then
                                            '馬毎レース情報構造体への展開
                                            KyousoubaMaster.SetData(strBuff)
                                            '========================================================
                                            '<馬場別着回数>
                                            '========================================================
                                            '芝直・１着回数
                                            Dim SibaTyokuKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(0).Chakukaisu(0))
                                            '芝直・２着回数
                                            Dim SibaTyokuKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(0).Chakukaisu(1))
                                            '芝直・３着回数
                                            Dim SibaTyokuKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(0).Chakukaisu(2))
                                            '芝直・４着回数
                                            Dim SibaTyokuKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(0).Chakukaisu(3))
                                            '芝直・５着回数
                                            Dim SibaTyokuKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(0).Chakukaisu(4))
                                            '芝直・６着以下回数
                                            Dim SibaTyokuKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(0).Chakukaisu(5))
                                            '芝右・１着回数
                                            Dim SibaMigiKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(1).Chakukaisu(0))
                                            '芝右・２着回数
                                            Dim SibaMigiKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(1).Chakukaisu(1))
                                            '芝右・３着回数
                                            Dim SibaMigiKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(1).Chakukaisu(2))
                                            '芝右・４着回数
                                            Dim SibaMigiKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(1).Chakukaisu(3))
                                            '芝右・５着回数
                                            Dim SibaMigiKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(1).Chakukaisu(4))
                                            '芝右・６着以下回数
                                            Dim SibaMigiKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(1).Chakukaisu(5))
                                            '芝左・１着回数
                                            Dim SibaHidariKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(2).Chakukaisu(0))
                                            '芝左・２着回数
                                            Dim SibaHidariKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(2).Chakukaisu(1))
                                            '芝左・３着回数
                                            Dim SibaHidariKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(2).Chakukaisu(2))
                                            '芝左・４着回数
                                            Dim SibaHidariKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(2).Chakukaisu(3))
                                            '芝左・５着回数
                                            Dim SibaHidariKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(2).Chakukaisu(4))
                                            '芝左・６着以下回数
                                            Dim SibaHidariKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(2).Chakukaisu(5))
                                            'ダ直・１着回数
                                            Dim DirtTyokuKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(3).Chakukaisu(0))
                                            'ダ直・２着回数
                                            Dim DirtTyokuKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(3).Chakukaisu(1))
                                            'ダ直・３着回数
                                            Dim DirtTyokuKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(3).Chakukaisu(2))
                                            'ダ直・４着回数
                                            Dim DirtTyokuKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(3).Chakukaisu(3))
                                            'ダ直・５着回数
                                            Dim DirtTyokuKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(3).Chakukaisu(4))
                                            'ダ直・６着以下回数
                                            Dim DirtTyokuKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(3).Chakukaisu(5))
                                            'ダ右・１着回数
                                            Dim DirtMigiKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(4).Chakukaisu(0))
                                            'ダ右・２着回数
                                            Dim DirtMigiKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(4).Chakukaisu(1))
                                            'ダ右・３着回数
                                            Dim DirtMigiKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(4).Chakukaisu(2))
                                            'ダ右・４着回数
                                            Dim DirtMigiKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(4).Chakukaisu(3))
                                            'ダ右・５着回数
                                            Dim DirtMigiKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(4).Chakukaisu(4))
                                            'ダ右・６着以下回数
                                            Dim DirtMigiKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(4).Chakukaisu(5))
                                            'ダ左・１着回数
                                            Dim DirtHidariKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(5).Chakukaisu(0))
                                            'ダ左・２着回数
                                            Dim DirtHidariKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(5).Chakukaisu(1))
                                            'ダ左・３着回数
                                            Dim DirtHidariKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(5).Chakukaisu(2))
                                            'ダ左・４着回数
                                            Dim DirtHidariKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(5).Chakukaisu(3))
                                            'ダ左・５着回数
                                            Dim DirtHidariKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(5).Chakukaisu(4))
                                            'ダ左・６着以下回数
                                            Dim DirtHidariKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(5).Chakukaisu(5))
                                            '障害・１着回数
                                            Dim SyougaiKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(6).Chakukaisu(0))
                                            '障害・２着回数
                                            Dim SyougaiKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(6).Chakukaisu(1))
                                            '障害・３着回数
                                            Dim SyougaiKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(6).Chakukaisu(2))
                                            '障害・４着回数
                                            Dim SyougaiKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(6).Chakukaisu(3))
                                            '障害・５着回数
                                            Dim SyougaiKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(6).Chakukaisu(4))
                                            '障害・６着以下回数
                                            Dim SyougaiKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuBa(6).Chakukaisu(5))
                                            '========================================================
                                            '<馬場状態別着回数>
                                            '========================================================
                                            '芝良・１着回数
                                            Dim SibaRyoKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(0).Chakukaisu(0))
                                            '芝良・２着回数
                                            Dim SibaRyoKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(0).Chakukaisu(1))
                                            '芝良・３着回数
                                            Dim SibaRyoKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(0).Chakukaisu(2))
                                            '芝良・４着回数
                                            Dim SibaRyoKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(0).Chakukaisu(3))
                                            '芝良・５着回数
                                            Dim SibaRyoKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(0).Chakukaisu(4))
                                            '芝良・６着以下回数
                                            Dim SibaRyoKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(0).Chakukaisu(5))
                                            '芝稍・１着回数
                                            Dim SibaYayaOmoKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(1).Chakukaisu(0))
                                            '芝稍・２着回数
                                            Dim SibaYayaOmoKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(1).Chakukaisu(1))
                                            '芝稍・３着回数
                                            Dim SibaYayaOmoKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(1).Chakukaisu(2))
                                            '芝稍・４着回数
                                            Dim SibaYayaOmoKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(1).Chakukaisu(3))
                                            '芝稍・５着回数
                                            Dim SibaYayaOmoKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(1).Chakukaisu(4))
                                            '芝稍・６着以下回数
                                            Dim SibaYayaOmoKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(1).Chakukaisu(5))
                                            '芝重・１着回数
                                            Dim SibaOmoKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(2).Chakukaisu(0))
                                            '芝重・２着回数
                                            Dim SibaOmoKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(2).Chakukaisu(1))
                                            '芝重・３着回数
                                            Dim SibaOmoKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(2).Chakukaisu(2))
                                            '芝重・４着回数
                                            Dim SibaOmoKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(2).Chakukaisu(3))
                                            '芝重・５着回数
                                            Dim SibaOmoKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(2).Chakukaisu(4))
                                            '芝重・６着以下回数
                                            Dim SibaOmoKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(2).Chakukaisu(5))
                                            '芝不・１着回数
                                            Dim SibaFuryoKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(3).Chakukaisu(0))
                                            '芝不・２着回数
                                            Dim SibaFuryoKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(3).Chakukaisu(1))
                                            '芝不・３着回数
                                            Dim SibaFuryoKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(3).Chakukaisu(2))
                                            '芝不・４着回数
                                            Dim SibaFuryoKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(3).Chakukaisu(3))
                                            '芝不・５着回数
                                            Dim SibaFuryoKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(3).Chakukaisu(4))
                                            '芝不・６着以下回数
                                            Dim SibaFuryoKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(3).Chakukaisu(5))
                                            'ダ良・１着回数
                                            Dim DirtRyoKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(4).Chakukaisu(0))
                                            'ダ良・２着回数
                                            Dim DirtRyoKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(4).Chakukaisu(1))
                                            'ダ良・３着回数
                                            Dim DirtRyoKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(4).Chakukaisu(2))
                                            'ダ良・４着回数
                                            Dim DirtRyoKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(4).Chakukaisu(3))
                                            'ダ良・５着回数
                                            Dim DirtRyoKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(4).Chakukaisu(4))
                                            'ダ良・６着以下回数
                                            Dim DirtRyoKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(4).Chakukaisu(5))
                                            'ダ稍・１着回数
                                            Dim DirtYayaOmoKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(5).Chakukaisu(0))
                                            'ダ稍・２着回数
                                            Dim DirtYayaOmoKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(5).Chakukaisu(1))
                                            'ダ稍・３着回数
                                            Dim DirtYayaOmoKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(5).Chakukaisu(2))
                                            'ダ稍・４着回数
                                            Dim DirtYayaOmoKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(5).Chakukaisu(3))
                                            'ダ稍・５着回数
                                            Dim DirtYayaOmoKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(5).Chakukaisu(4))
                                            'ダ稍・６着以下回数
                                            Dim DirtYayaOmoKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(5).Chakukaisu(5))
                                            'ダ重・１着回数
                                            Dim DirtOmoKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(6).Chakukaisu(0))
                                            'ダ重・２着回数
                                            Dim DirtOmoKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(6).Chakukaisu(1))
                                            'ダ重・３着回数
                                            Dim DirtOmoKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(6).Chakukaisu(2))
                                            'ダ重・４着回数
                                            Dim DirtOmoKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(6).Chakukaisu(3))
                                            'ダ重・５着回数
                                            Dim DirtOmoKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(6).Chakukaisu(4))
                                            'ダ重・６着以下回数
                                            Dim DirtOmoKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(6).Chakukaisu(5))
                                            'ダ不・１着回数
                                            Dim DirtFuryoKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(7).Chakukaisu(0))
                                            'ダ不・２着回数
                                            Dim DirtFuryoKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(7).Chakukaisu(1))
                                            'ダ不・３着回数
                                            Dim DirtFuryoKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(7).Chakukaisu(2))
                                            'ダ不・４着回数
                                            Dim DirtFuryoKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(7).Chakukaisu(3))
                                            'ダ不・５着回数
                                            Dim DirtFuryoKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(7).Chakukaisu(4))
                                            'ダ不・６着以下回数
                                            Dim DirtFuryoKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(7).Chakukaisu(5))
                                            '障良・１着回数
                                            Dim SyougaiRyoKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(8).Chakukaisu(0))
                                            '障良・２着回数
                                            Dim SyougaiRyoKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(8).Chakukaisu(1))
                                            '障良・３着回数
                                            Dim SyougaiRyoKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(8).Chakukaisu(2))
                                            '障良・４着回数
                                            Dim SyougaiRyoKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(8).Chakukaisu(3))
                                            '障良・５着回数
                                            Dim SyougaiRyoKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(8).Chakukaisu(4))
                                            '障良・６着以下回数
                                            Dim SyougaiRyoKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(8).Chakukaisu(5))
                                            '障稍・１着回数
                                            Dim SyougaiYayaOmoKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(9).Chakukaisu(0))
                                            '障稍・２着回数
                                            Dim SyougaiYayaOmoKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(9).Chakukaisu(1))
                                            '障稍・３着回数
                                            Dim SyougaiYayaOmoKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(9).Chakukaisu(2))
                                            '障稍・４着回数
                                            Dim SyougaiYayaOmoKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(9).Chakukaisu(3))
                                            '障稍・５着回数
                                            Dim SyougaiYayaOmoKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(9).Chakukaisu(4))
                                            '障稍・６着以下回数
                                            Dim SyougaiYayaOmoKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(9).Chakukaisu(5))
                                            '障重・１着回数
                                            Dim SyougaiOmoKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(10).Chakukaisu(0))
                                            '障重・２着回数
                                            Dim SyougaiOmoKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(10).Chakukaisu(1))
                                            '障重・３着回数
                                            Dim SyougaiOmoKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(10).Chakukaisu(2))
                                            '障重・４着回数
                                            Dim SyougaiOmoKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(10).Chakukaisu(3))
                                            '障重・５着回数
                                            Dim SyougaiOmoKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(10).Chakukaisu(4))
                                            '障重・６着以下回数
                                            Dim SyougaiOmoKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(10).Chakukaisu(5))
                                            '障不・１着回数
                                            Dim SyougaiFuryoKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(11).Chakukaisu(0))
                                            '障不・２着回数
                                            Dim SyougaiFuryoKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(11).Chakukaisu(1))
                                            '障不・３着回数
                                            Dim SyougaiFuryoKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(11).Chakukaisu(2))
                                            '障不・４着回数
                                            Dim SyougaiFuryoKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(11).Chakukaisu(3))
                                            '障不・５着回数
                                            Dim SyougaiFuryoKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(11).Chakukaisu(4))
                                            '障不・６着以下回数
                                            Dim SyougaiFuryoKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuJyotai(11).Chakukaisu(5))
                                            '========================================================
                                            '<距離別着回数>
                                            '========================================================
                                            '芝16下・１着回数
                                            Dim Siba16sitaKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(0).Chakukaisu(0))
                                            '芝16下・２着回数
                                            Dim Siba16sitaKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(0).Chakukaisu(1))
                                            '芝16下・３着回数
                                            Dim Siba16sitaKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(0).Chakukaisu(2))
                                            '芝16下・４着回数
                                            Dim Siba16sitaKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(0).Chakukaisu(3))
                                            '芝16下・５着回数
                                            Dim Siba16sitaKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(0).Chakukaisu(4))
                                            '芝16下・６着以下回数
                                            Dim Siba16sitaKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(0).Chakukaisu(5))
                                            '芝22下・１着回数
                                            Dim Siba22sitaKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(1).Chakukaisu(0))
                                            '芝22下・２着回数
                                            Dim Siba22sitaKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(1).Chakukaisu(1))
                                            '芝22下・３着回数
                                            Dim Siba22sitaKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(1).Chakukaisu(2))
                                            '芝22下・４着回数
                                            Dim Siba22sitaKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(1).Chakukaisu(3))
                                            '芝22下・５着回数
                                            Dim Siba22sitaKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(1).Chakukaisu(4))
                                            '芝22下・６着以下回数
                                            Dim Siba22sitaKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(1).Chakukaisu(5))
                                            '芝22超・１着回数
                                            Dim Siba22ueKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(2).Chakukaisu(0))
                                            '芝22超・２着回数
                                            Dim Siba22ueKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(2).Chakukaisu(1))
                                            '芝22超・３着回数
                                            Dim Siba22ueKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(2).Chakukaisu(2))
                                            '芝22超・４着回数
                                            Dim Siba22ueKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(2).Chakukaisu(3))
                                            '芝22超・５着回数
                                            Dim Siba22ueKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(2).Chakukaisu(4))
                                            '芝22超・６着以下回数
                                            Dim Siba22ueKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(2).Chakukaisu(5))
                                            'ダ16下・１着回数
                                            Dim Dirt16sitaKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(3).Chakukaisu(0))
                                            'ダ16下・２着回数
                                            Dim Dirt16sitaKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(3).Chakukaisu(1))
                                            'ダ16下・３着回数
                                            Dim Dirt16sitaKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(3).Chakukaisu(2))
                                            'ダ16下・４着回数
                                            Dim Dirt16sitaKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(3).Chakukaisu(3))
                                            'ダ16下・５着回数
                                            Dim Dirt16sitaKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(3).Chakukaisu(4))
                                            'ダ16下・６着以下回数
                                            Dim Dirt16sitaKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(3).Chakukaisu(5))
                                            'ダ22下・１着回数
                                            Dim Dirt22sitaKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(4).Chakukaisu(0))
                                            'ダ22下・２着回数
                                            Dim Dirt22sitaKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(4).Chakukaisu(1))
                                            'ダ22下・３着回数
                                            Dim Dirt22sitaKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(4).Chakukaisu(2))
                                            'ダ22下・４着回数
                                            Dim Dirt22sitaKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(4).Chakukaisu(3))
                                            'ダ22下・５着回数
                                            Dim Dirt22sitaKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(4).Chakukaisu(4))
                                            'ダ22下・６着以下回数
                                            Dim Dirt22sitaKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(4).Chakukaisu(5))
                                            'ダ22超・１着回数
                                            Dim Dirt22ueKaisuu1 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(5).Chakukaisu(0))
                                            'ダ22超・２着回数
                                            Dim Dirt22ueKaisuu2 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(5).Chakukaisu(1))
                                            'ダ22超・３着回数
                                            Dim Dirt22ueKaisuu3 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(5).Chakukaisu(2))
                                            'ダ22超・４着回数
                                            Dim Dirt22ueKaisuu4 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(5).Chakukaisu(3))
                                            'ダ22超・５着回数
                                            Dim Dirt22ueKaisuu5 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(5).Chakukaisu(4))
                                            'ダ22超・６着以下回数
                                            Dim Dirt22ueKaisuu6 As Integer = Integer.Parse(KyousoubaMaster.ChakuKaisuKyori(5).Chakukaisu(5))

                                            Try
                                                Dim CommandText As String = "SELECT count(*) FROM jv_um_uma WHERE ketto_num = '" & KyousoubaMaster.KettoNum & "'"
                                                Dim Command As New MySqlCommand(CommandText, con)
                                                Dim count As Integer = Command.ExecuteScalar()
                                                If count > 0 Then
                                                    Dim myCommand As New MySqlCommand(CreateSQL.CreateJvUmUmaUpdate, con)
                                                    myCommand.Parameters.AddWithValue("?val1", KyousoubaMaster.Bamei.Trim())
                                                    myCommand.Parameters.AddWithValue("?val2", KyousoubaMaster.RegDate.Year & KyousoubaMaster.RegDate.Month & KyousoubaMaster.RegDate.Day)
                                                    myCommand.Parameters.AddWithValue("?val3", KyousoubaMaster.UmaKigoCD)
                                                    myCommand.Parameters.AddWithValue("?val4", KyousoubaMaster.SexCD)
                                                    myCommand.Parameters.AddWithValue("?val5", KyousoubaMaster.HinsyuCD)
                                                    myCommand.Parameters.AddWithValue("?val6", KyousoubaMaster.KeiroCD)
                                                    myCommand.Parameters.AddWithValue("?val7", Integer.Parse(KyousoubaMaster.RuikeiHonsyoHeiti))
                                                    myCommand.Parameters.AddWithValue("?val8", Integer.Parse(KyousoubaMaster.RuikeiHonsyoSyogai))
                                                    myCommand.Parameters.AddWithValue("?val9", KyousoubaMaster.Ketto3Info(0).Bamei.Trim())
                                                    myCommand.Parameters.AddWithValue("?val10", KyousoubaMaster.Ketto3Info(2).Bamei.Trim())
                                                    myCommand.Parameters.AddWithValue("?val11", KyousoubaMaster.Ketto3Info(4).Bamei.Trim())
                                                    myCommand.Parameters.AddWithValue("?val12", Integer.Parse(KyousoubaMaster.RaceCount))
                                                    myCommand.Parameters.AddWithValue("?val13", KyousoubaMaster.DelKubun)
                                                    myCommand.Parameters.AddWithValue("?val14", KyousoubaMaster.DelDate.Year & KyousoubaMaster.DelDate.Month & KyousoubaMaster.DelDate.Day)
                                                    myCommand.Parameters.AddWithValue("?val15", SibaTyokuKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val16", SibaTyokuKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val17", SibaTyokuKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val18", SibaTyokuKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val19", SibaTyokuKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val20", SibaTyokuKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val21", SibaMigiKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val22", SibaMigiKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val23", SibaMigiKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val24", SibaMigiKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val25", SibaMigiKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val26", SibaMigiKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val27", SibaHidariKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val28", SibaHidariKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val29", SibaHidariKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val30", SibaHidariKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val31", SibaHidariKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val32", SibaHidariKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val33", DirtTyokuKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val34", DirtTyokuKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val35", DirtTyokuKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val36", DirtTyokuKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val37", DirtTyokuKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val38", DirtTyokuKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val39", DirtMigiKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val40", DirtMigiKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val41", DirtMigiKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val42", DirtMigiKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val43", DirtMigiKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val44", DirtMigiKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val45", DirtHidariKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val46", DirtHidariKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val47", DirtHidariKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val48", DirtHidariKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val49", DirtHidariKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val50", DirtHidariKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val51", SyougaiKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val52", SyougaiKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val53", SyougaiKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val54", SyougaiKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val55", SyougaiKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val56", SyougaiKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val57", SibaRyoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val58", SibaRyoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val59", SibaRyoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val60", SibaRyoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val61", SibaRyoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val62", SibaRyoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val63", SibaYayaOmoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val64", SibaYayaOmoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val65", SibaYayaOmoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val66", SibaYayaOmoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val67", SibaYayaOmoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val68", SibaYayaOmoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val69", SibaOmoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val70", SibaOmoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val71", SibaOmoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val72", SibaOmoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val73", SibaOmoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val74", SibaOmoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val75", SibaFuryoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val76", SibaFuryoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val77", SibaFuryoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val78", SibaFuryoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val79", SibaFuryoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val80", SibaFuryoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val81", DirtRyoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val82", DirtRyoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val83", DirtRyoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val84", DirtRyoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val85", DirtRyoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val86", DirtRyoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val87", DirtYayaOmoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val88", DirtYayaOmoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val89", DirtYayaOmoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val90", DirtYayaOmoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val91", DirtYayaOmoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val92", DirtYayaOmoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val93", DirtOmoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val94", DirtOmoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val95", DirtOmoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val96", DirtOmoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val97", DirtOmoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val98", DirtOmoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val99", DirtFuryoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val100", DirtFuryoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val101", DirtFuryoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val102", DirtFuryoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val103", DirtFuryoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val104", DirtFuryoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val105", SyougaiRyoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val106", SyougaiRyoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val107", SyougaiRyoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val108", SyougaiRyoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val109", SyougaiRyoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val110", SyougaiRyoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val111", SyougaiYayaOmoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val112", SyougaiYayaOmoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val113", SyougaiYayaOmoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val114", SyougaiYayaOmoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val115", SyougaiYayaOmoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val116", SyougaiYayaOmoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val117", SyougaiOmoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val118", SyougaiOmoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val119", SyougaiOmoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val120", SyougaiOmoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val121", SyougaiOmoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val122", SyougaiOmoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val123", SyougaiFuryoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val124", SyougaiFuryoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val125", SyougaiFuryoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val126", SyougaiFuryoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val127", SyougaiFuryoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val128", SyougaiFuryoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val129", Siba16sitaKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val130", Siba16sitaKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val131", Siba16sitaKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val132", Siba16sitaKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val133", Siba16sitaKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val134", Siba16sitaKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val135", Siba22sitaKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val136", Siba22sitaKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val137", Siba22sitaKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val138", Siba22sitaKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val139", Siba22sitaKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val140", Siba22sitaKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val141", Siba22ueKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val142", Siba22ueKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val143", Siba22ueKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val144", Siba22ueKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val145", Siba22ueKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val146", Siba22ueKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val147", Dirt16sitaKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val148", Dirt16sitaKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val149", Dirt16sitaKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val150", Dirt16sitaKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val151", Dirt16sitaKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val152", Dirt16sitaKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val153", Dirt22sitaKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val154", Dirt22sitaKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val155", Dirt22sitaKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val156", Dirt22sitaKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val157", Dirt22sitaKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val158", Dirt22sitaKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val159", Dirt22ueKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val160", Dirt22ueKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val161", Dirt22ueKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val162", Dirt22ueKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val163", Dirt22ueKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val164", Dirt22ueKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val165", KyousoubaMaster.head.DataKubun)
                                                    myCommand.Parameters.AddWithValue("?val166", KyousoubaMaster.head.MakeDate.Year & KyousoubaMaster.head.MakeDate.Month & KyousoubaMaster.head.MakeDate.Day)
                                                    myCommand.Parameters.AddWithValue("?val167", KyousoubaMaster.KettoNum)
                                                    'SQLを実行
                                                    myCommand.ExecuteNonQuery()
                                                Else
                                                    Dim myCommand As New MySqlCommand(CreateSQL.CreateJvUmUmaInsert, con)
                                                    'プレースホルダーにバインド
                                                    myCommand.Parameters.AddWithValue("?val1", KyousoubaMaster.KettoNum)
                                                    myCommand.Parameters.AddWithValue("?val2", KyousoubaMaster.Bamei.Trim())
                                                    myCommand.Parameters.AddWithValue("?val3", KyousoubaMaster.RegDate.Year & KyousoubaMaster.RegDate.Month & KyousoubaMaster.RegDate.Day)
                                                    myCommand.Parameters.AddWithValue("?val4", KyousoubaMaster.UmaKigoCD)
                                                    myCommand.Parameters.AddWithValue("?val5", KyousoubaMaster.SexCD)
                                                    myCommand.Parameters.AddWithValue("?val6", KyousoubaMaster.HinsyuCD)
                                                    myCommand.Parameters.AddWithValue("?val7", KyousoubaMaster.KeiroCD)
                                                    myCommand.Parameters.AddWithValue("?val8", Integer.Parse(KyousoubaMaster.RuikeiHonsyoHeiti))
                                                    myCommand.Parameters.AddWithValue("?val9", Integer.Parse(KyousoubaMaster.RuikeiHonsyoSyogai))
                                                    myCommand.Parameters.AddWithValue("?val10", KyousoubaMaster.Ketto3Info(0).Bamei.Trim())
                                                    myCommand.Parameters.AddWithValue("?val11", KyousoubaMaster.Ketto3Info(2).Bamei.Trim())
                                                    myCommand.Parameters.AddWithValue("?val12", KyousoubaMaster.Ketto3Info(4).Bamei.Trim())
                                                    myCommand.Parameters.AddWithValue("?val13", Integer.Parse(KyousoubaMaster.RaceCount))
                                                    myCommand.Parameters.AddWithValue("?val14", KyousoubaMaster.DelKubun)
                                                    myCommand.Parameters.AddWithValue("?val15", KyousoubaMaster.DelDate.Year & KyousoubaMaster.DelDate.Month & KyousoubaMaster.DelDate.Day)
                                                    myCommand.Parameters.AddWithValue("?val16", SibaTyokuKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val17", SibaTyokuKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val18", SibaTyokuKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val19", SibaTyokuKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val20", SibaTyokuKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val21", SibaTyokuKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val22", SibaMigiKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val23", SibaMigiKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val24", SibaMigiKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val25", SibaMigiKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val26", SibaMigiKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val27", SibaMigiKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val28", SibaHidariKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val29", SibaHidariKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val30", SibaHidariKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val31", SibaHidariKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val32", SibaHidariKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val33", SibaHidariKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val34", DirtTyokuKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val35", DirtTyokuKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val36", DirtTyokuKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val37", DirtTyokuKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val38", DirtTyokuKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val39", DirtTyokuKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val40", DirtMigiKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val41", DirtMigiKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val42", DirtMigiKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val43", DirtMigiKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val44", DirtMigiKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val45", DirtMigiKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val46", DirtHidariKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val47", DirtHidariKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val48", DirtHidariKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val49", DirtHidariKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val50", DirtHidariKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val51", DirtHidariKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val52", SyougaiKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val53", SyougaiKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val54", SyougaiKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val55", SyougaiKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val56", SyougaiKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val57", SyougaiKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val58", SibaRyoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val59", SibaRyoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val60", SibaRyoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val61", SibaRyoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val62", SibaRyoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val63", SibaRyoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val64", SibaYayaOmoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val65", SibaYayaOmoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val66", SibaYayaOmoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val67", SibaYayaOmoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val68", SibaYayaOmoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val69", SibaYayaOmoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val70", SibaOmoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val71", SibaOmoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val72", SibaOmoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val73", SibaOmoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val74", SibaOmoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val75", SibaOmoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val76", SibaFuryoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val77", SibaFuryoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val78", SibaFuryoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val79", SibaFuryoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val80", SibaFuryoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val81", SibaFuryoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val82", DirtRyoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val83", DirtRyoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val84", DirtRyoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val85", DirtRyoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val86", DirtRyoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val87", DirtRyoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val88", DirtYayaOmoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val89", DirtYayaOmoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val90", DirtYayaOmoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val91", DirtYayaOmoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val92", DirtYayaOmoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val93", DirtYayaOmoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val94", DirtOmoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val95", DirtOmoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val96", DirtOmoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val97", DirtOmoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val98", DirtOmoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val99", DirtOmoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val100", DirtFuryoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val101", DirtFuryoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val102", DirtFuryoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val103", DirtFuryoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val104", DirtFuryoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val105", DirtFuryoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val106", SyougaiRyoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val107", SyougaiRyoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val108", SyougaiRyoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val109", SyougaiRyoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val110", SyougaiRyoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val111", SyougaiRyoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val112", SyougaiYayaOmoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val113", SyougaiYayaOmoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val114", SyougaiYayaOmoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val115", SyougaiYayaOmoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val116", SyougaiYayaOmoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val117", SyougaiYayaOmoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val118", SyougaiOmoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val119", SyougaiOmoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val120", SyougaiOmoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val121", SyougaiOmoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val122", SyougaiOmoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val123", SyougaiOmoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val124", SyougaiFuryoKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val125", SyougaiFuryoKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val126", SyougaiFuryoKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val127", SyougaiFuryoKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val128", SyougaiFuryoKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val129", SyougaiFuryoKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val130", Siba16sitaKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val131", Siba16sitaKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val132", Siba16sitaKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val133", Siba16sitaKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val134", Siba16sitaKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val135", Siba16sitaKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val136", Siba22sitaKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val137", Siba22sitaKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val138", Siba22sitaKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val139", Siba22sitaKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val140", Siba22sitaKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val141", Siba22sitaKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val142", Siba22ueKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val143", Siba22ueKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val144", Siba22ueKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val145", Siba22ueKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val146", Siba22ueKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val147", Siba22ueKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val148", Dirt16sitaKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val149", Dirt16sitaKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val150", Dirt16sitaKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val151", Dirt16sitaKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val152", Dirt16sitaKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val153", Dirt16sitaKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val154", Dirt22sitaKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val155", Dirt22sitaKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val156", Dirt22sitaKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val157", Dirt22sitaKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val158", Dirt22sitaKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val159", Dirt22sitaKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val160", Dirt22ueKaisuu1)
                                                    myCommand.Parameters.AddWithValue("?val161", Dirt22ueKaisuu2)
                                                    myCommand.Parameters.AddWithValue("?val162", Dirt22ueKaisuu3)
                                                    myCommand.Parameters.AddWithValue("?val163", Dirt22ueKaisuu4)
                                                    myCommand.Parameters.AddWithValue("?val164", Dirt22ueKaisuu5)
                                                    myCommand.Parameters.AddWithValue("?val165", Dirt22ueKaisuu6)
                                                    myCommand.Parameters.AddWithValue("?val166", KyousoubaMaster.head.DataKubun)
                                                    myCommand.Parameters.AddWithValue("?val167", KyousoubaMaster.head.MakeDate.Year & KyousoubaMaster.head.MakeDate.Month & KyousoubaMaster.head.MakeDate.Day)
                                                    'SQLを実行
                                                    myCommand.ExecuteNonQuery()
                                                End If
                                            Catch ex As MySqlException
                                                MessageBox.Show(ex.Message)
                                            End Try
                                        End If
                                End Select
                            Loop While (1)
                        End Using
                    End If
                    'タイマ有効時は、無効化する
                    If TimerDownload.Enabled = True Then
                        TimerDownload.Enabled = False
                    End If
                End If
            End If
        Catch
            Debug.WriteLine(Err.Description)
            Exit Sub
        End Try
        'JVLink終了処理
        lReturnCode = Me.AxJVLink1.JVClose()
        If lReturnCode <> 0 Then
            MsgBox("JVClseエラー：" & lReturnCode)
        End If
        MsgBox("登録完了しました。")
    End Sub

    Private Sub menuConfigJV_Click(sender As Object, e As EventArgs) Handles menuConfigJV.Click
        Try
            ' リターンコード
            Dim lReturnCode As Long
            ' 設定画面表示
            lReturnCode = AxJVLink1.JVSetUIProperties()
            If lReturnCode <> 0 Then
                MsgBox("JVSetUIPropertiesエラー コード：" & lReturnCode & "：", MessageBoxIcon.Error)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub getSokuhouBtn_Click(sender As Object, e As EventArgs) Handles getSokuhouBtn.Click
        Dim YmdList As New List(Of String)
        Dim ProgessBarMaxCount As Integer
        Dim sid As String
        Dim lReturnCode As Long
        '引数設定
        sid = "Test"
        'JVLink初期化
        lReturnCode = Me.AxJVLink1.JVInit(sid)
        'エラー判定
        If lReturnCode <> 0 Then
            MsgBox("JVInitエラー コード：" & lReturnCode & "：", MessageBoxIcon.Error)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        Try
            Using con As MySqlConnection = DBManager.CreateMySqlConnection
                Using cmd As New MySqlCommand
                    'コマンド生成
                    cmd.Connection = con
                    ' SQL文の設定
                    cmd.CommandText = "SELECT year, month, day FROM jv_ra_race WHERE data_kubun < '7' GROUP BY year, month, day"
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        ' 取得レコード有無チェック
                        If dr.HasRows = True Then
                            ' レコードが取得できた時の処理
                            While dr.Read()
                                YmdList.Add(dr("year") & dr("month") & dr("day"))
                            End While
                        Else
                            ' レコードが取得できなかった時の処理
                            MsgBox("更新データはありません。")
                            Exit Sub
                        End If
                        If YmdList.Count <= 0 Then
                            ' レコードが取得できなかった時の処理
                            MsgBox("更新データはありません。")
                            Exit Sub
                        End If
                    End Using
                    cmd.CommandText = "SELECT count(race_id) AS progess_bar_count FROM jv_ra_race WHERE data_kubun < '7'"
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        ' 取得レコード有無チェック
                        If dr.HasRows = True Then
                            ' レコードが取得できた時の処理
                            If dr.Read() Then
                                ProgessBarMaxCount = dr("progess_bar_count")
                            End If
                        End If
                    End Using
                End Using
                Dim strDataSpec As String '' 引数 JVOpen:ファイル識別子
                Dim key As String '' 引数 JVOpen:データ提供日付
                Dim strLastFileTimestamp As String = "" '' JVOpen: 最新ファイルのタイムスタンプ
                Const lBuffSize As Long = 110000 ''JVRead:データ格納バッファサイズ
                Const lNameSize As Integer = 256 ''JVRead:ファイル名サイズ
                Dim strBuff As String ''JVRead:データ格納バッファ
                Dim strFileName As String ''JVRead:ダウンロードファイル名
                Dim RaceUmaInfo As JV_SE_RACE_UMA = New JV_SE_RACE_UMA() ''馬毎レース情報構造体
                Dim RaceInfo As JV_RA_RACE = New JV_RA_RACE() ''レース詳細構造体
                Dim PayInfo As JV_HR_PAY = New JV_HR_PAY() ''払戻情報構造体
                '進捗表示初期設定
                TimerDownload.Enabled = True ''タイマー開始 
                prgJVRead.Value = 0 ''JVData読み込み進捗
                prgJVRead.Maximum = ProgessBarMaxCount

                '引数設定
                strDataSpec = "0B12"
                For Each key In YmdList
                    ' JVLinkダウンロード処理
                    lReturnCode = Me.AxJVLink1.JVRTOpen(strDataSpec, key)
                    'エラー判定
                    If lReturnCode <> 0 Then
                        MsgBox("更新データはありません。")
                        'タイマ有効時は、無効化する
                        If TimerDownload.Enabled = True Then
                            TimerDownload.Enabled = False
                        End If
                        Exit Sub
                    Else
                        Do
                            'バックグラウンドでの処理を実行
                            Application.DoEvents()
                            'バッファ作成
                            strBuff = New String(vbNullChar, lBuffSize)
                            strFileName = New String(vbNullChar, lNameSize)
                            'JVReadで１行読み込み
                            lReturnCode = Me.AxJVLink1.JVRead(strBuff, lBuffSize, strFileName)
                            'リターンコードにより処理を分枝
                            Select Case lReturnCode
                                Case 0 ' 全ファイル読み込み終了
                                    'ProgressBar1.Value = ProgressBar1.Maximum '進捗表示
                                    Exit Do
                                Case -1 ' ファイル切り替わり
                                'ProgressBar1.Value = ProgressBar1.Value + 1
                                Case -3 ' ダウンロード中
                                Case -201 ' Initされてない
                                    MsgBox("JVInitが行われていません。")
                                    Exit Do
                                Case -203 ' Openされてない
                                    MsgBox("JVOpenが行われていません。")
                                    Exit Do
                                Case -503 ' ファイルがない
                                    MsgBox(strFileName & "が存在しません。")
                                    Exit Do
                                Case Is > 0 ' 正常読み込み
                                    'レコード種別IDの識別
                                    If Mid(strBuff, 1, 2) = "RA" Then
                                        '馬毎レース情報構造体への展開
                                        RaceInfo.SetData(strBuff)
                                        If "01".Equals(RaceInfo.id.JyoCD) OrElse "02".Equals(RaceInfo.id.JyoCD) OrElse "03".Equals(RaceInfo.id.JyoCD) OrElse "04".Equals(RaceInfo.id.JyoCD) OrElse "05".Equals(RaceInfo.id.JyoCD) OrElse "06".Equals(RaceInfo.id.JyoCD) OrElse "07".Equals(RaceInfo.id.JyoCD) OrElse "08".Equals(RaceInfo.id.JyoCD) OrElse "09".Equals(RaceInfo.id.JyoCD) OrElse "10".Equals(RaceInfo.id.JyoCD) Then
                                            prgJVRead.Value = prgJVRead.Value + 1
                                            'レースID
                                            Dim raceid As String = RaceInfo.id.Year & RaceInfo.id.MonthDay & RaceInfo.id.JyoCD & RaceInfo.id.Kaiji & RaceInfo.id.Nichiji & RaceInfo.id.RaceNum
                                            '年月日
                                            Dim ymd As String = RaceInfo.id.Year & "年" & RaceInfo.id.MonthDay.Substring(0, 2) & "月" & RaceInfo.id.MonthDay.Substring(2, 2) & "日"
                                            '競馬場
                                            Dim KeibaJyo As String = KeibaJyoCodeConversion(RaceInfo.id.JyoCD)
                                            '競走条件
                                            Dim KyosouJyoukenCD As String = CodeConversion.SelectKyosouJyoukenCode(RaceInfo.JyokenInfo.JyokenCD)
                                            '馬場状態
                                            Dim BabaCD As String = ""
                                            If "0".Equals(RaceInfo.TenkoBaba.SibaBabaCD) Then
                                                BabaCD = RaceInfo.TenkoBaba.DirtBabaCD
                                            Else
                                                BabaCD = RaceInfo.TenkoBaba.SibaBabaCD
                                            End If
                                            Try
                                                Dim CommandText As String = "Select count(*) FROM jv_ra_race WHERE race_id = '" & raceid & "'"
                                                Dim Command As New MySqlCommand(CommandText, con)
                                                Dim count As Integer = Command.ExecuteScalar()
                                                If count > 0 Then
                                                    CommandText = "SELECT data_kubun FROM jv_ra_race WHERE race_id = '" & raceid & "'"
                                                    Command = New MySqlCommand(CommandText, con)
                                                    Dim data_kubun As String = Command.ExecuteScalar()
                                                    If RaceInfo.head.DataKubun.CompareTo(data_kubun) > 0 Then
                                                        Dim myCommand As New MySqlCommand(CreateSQL.CreateJvRaRaceUpDate(), con)
                                                        'プレースホルダーにバインド
                                                        myCommand.Parameters.AddWithValue("?val1", RaceInfo.JyokenInfo.SyubetuCD)
                                                        myCommand.Parameters.AddWithValue("?val2", RaceInfo.JyokenInfo.KigoCD)
                                                        myCommand.Parameters.AddWithValue("?val3", KyosouJyoukenCD)
                                                        myCommand.Parameters.AddWithValue("?val4", RaceInfo.JyokenInfo.JyuryoCD)
                                                        myCommand.Parameters.AddWithValue("?val5", RaceInfo.GradeCD)
                                                        myCommand.Parameters.AddWithValue("?val6", RaceInfo.RaceInfo.Hondai)
                                                        myCommand.Parameters.AddWithValue("?val7", Integer.Parse(RaceInfo.Kyori))
                                                        myCommand.Parameters.AddWithValue("?val8", RaceInfo.TrackCD)
                                                        myCommand.Parameters.AddWithValue("?val9", RaceInfo.CourseKubunCD)
                                                        myCommand.Parameters.AddWithValue("?val10", RaceInfo.TenkoBaba.TenkoCD)
                                                        myCommand.Parameters.AddWithValue("?val11", BabaCD)
                                                        myCommand.Parameters.AddWithValue("?val12", Integer.Parse(RaceInfo.SyussoTosu))
                                                        myCommand.Parameters.AddWithValue("?val13", RaceInfo.HassoTime)
                                                        myCommand.Parameters.AddWithValue("?val14", RaceInfo.head.DataKubun)
                                                        myCommand.Parameters.AddWithValue("?val15", RaceInfo.head.MakeDate.Year & RaceInfo.head.MakeDate.Month & RaceInfo.head.MakeDate.Day)
                                                        myCommand.Parameters.AddWithValue("?val16", raceid)
                                                        'SQLを実行
                                                        myCommand.ExecuteNonQuery()
                                                    End If

                                                Else
                                                    Dim myCommand As New MySqlCommand(CreateSQL.CreateJvRaRaceInsert(), con)
                                                    'プレースホルダーにバインド
                                                    myCommand.Parameters.AddWithValue("?val1", raceid)
                                                    myCommand.Parameters.AddWithValue("?val2", RaceInfo.id.Year)
                                                    myCommand.Parameters.AddWithValue("?val3", RaceInfo.id.MonthDay.Substring(0, 2))
                                                    myCommand.Parameters.AddWithValue("?val4", RaceInfo.id.MonthDay.Substring(2, 2))
                                                    myCommand.Parameters.AddWithValue("?val5", KeibaJyo)
                                                    myCommand.Parameters.AddWithValue("?val6", RaceInfo.id.RaceNum)
                                                    myCommand.Parameters.AddWithValue("?val7", RaceInfo.JyokenInfo.SyubetuCD)
                                                    myCommand.Parameters.AddWithValue("?val8", RaceInfo.JyokenInfo.KigoCD)
                                                    myCommand.Parameters.AddWithValue("?val9", KyosouJyoukenCD)
                                                    myCommand.Parameters.AddWithValue("?val10", RaceInfo.JyokenInfo.JyuryoCD)
                                                    myCommand.Parameters.AddWithValue("?val11", RaceInfo.GradeCD)
                                                    myCommand.Parameters.AddWithValue("?val12", RaceInfo.RaceInfo.Hondai)
                                                    myCommand.Parameters.AddWithValue("?val13", Integer.Parse(RaceInfo.Kyori))
                                                    myCommand.Parameters.AddWithValue("?val14", RaceInfo.TrackCD)
                                                    myCommand.Parameters.AddWithValue("?val15", RaceInfo.CourseKubunCD)
                                                    myCommand.Parameters.AddWithValue("?val16", RaceInfo.TenkoBaba.TenkoCD)
                                                    myCommand.Parameters.AddWithValue("?val17", BabaCD)
                                                    myCommand.Parameters.AddWithValue("?val18", Integer.Parse(RaceInfo.SyussoTosu))
                                                    myCommand.Parameters.AddWithValue("?val19", RaceInfo.HassoTime)
                                                    myCommand.Parameters.AddWithValue("?val20", RaceInfo.head.DataKubun)
                                                    myCommand.Parameters.AddWithValue("?val21", RaceInfo.head.MakeDate.Year & RaceInfo.head.MakeDate.Month & RaceInfo.head.MakeDate.Day)

                                                    'SQLを実行
                                                    myCommand.ExecuteNonQuery()
                                                End If
                                            Catch ex As MySqlException
                                                MessageBox.Show(ex.Message)
                                            End Try
                                        End If
                                    ElseIf Mid(strBuff, 1, 2) = "SE" Then
                                        '馬毎レース情報構造体への展開
                                        RaceUmaInfo.SetData(strBuff)
                                        If "01".Equals(RaceUmaInfo.id.JyoCD) OrElse "02".Equals(RaceUmaInfo.id.JyoCD) OrElse "03".Equals(RaceUmaInfo.id.JyoCD) OrElse "04".Equals(RaceUmaInfo.id.JyoCD) OrElse "05".Equals(RaceUmaInfo.id.JyoCD) OrElse "06".Equals(RaceUmaInfo.id.JyoCD) OrElse "07".Equals(RaceUmaInfo.id.JyoCD) OrElse "08".Equals(RaceUmaInfo.id.JyoCD) OrElse "09".Equals(RaceUmaInfo.id.JyoCD) OrElse "10".Equals(RaceUmaInfo.id.JyoCD) Then
                                            If "00".Equals(RaceUmaInfo.Umaban) Then
                                            Else
                                                Try
                                                    Dim id As String = RaceUmaInfo.id.Year & RaceUmaInfo.id.MonthDay & RaceUmaInfo.id.JyoCD & RaceUmaInfo.id.Kaiji & RaceUmaInfo.id.Nichiji & RaceUmaInfo.id.RaceNum & RaceUmaInfo.Umaban
                                                    Dim raceId As String = RaceUmaInfo.id.Year & RaceUmaInfo.id.MonthDay & RaceUmaInfo.id.JyoCD & RaceUmaInfo.id.Kaiji & RaceUmaInfo.id.Nichiji & RaceUmaInfo.id.RaceNum
                                                    '増減符号&増減差
                                                    Dim Zougen As Integer = 99
                                                    If "".Equals(Trim(RaceUmaInfo.ZogenSa)) Then

                                                    Else
                                                        Zougen = Integer.Parse(RaceUmaInfo.ZogenSa)
                                                        If "-".Equals(RaceUmaInfo.ZogenFugo) Then
                                                            Zougen = 0 - Zougen
                                                        End If
                                                    End If
                                                    Dim CommandText As String = "SELECT count(*) FROM jv_se_race_uma WHERE id = '" & id & "'"
                                                    Dim Command As New MySqlCommand(CommandText, con)
                                                    Dim count As Integer = Command.ExecuteScalar()
                                                    If count > 0 Then
                                                        CommandText = "SELECT data_kubun FROM jv_se_race_uma WHERE id = '" & id & "'"
                                                        Command = New MySqlCommand(CommandText, con)
                                                        Dim data_kubun As String = Command.ExecuteScalar()
                                                        If RaceUmaInfo.head.DataKubun.CompareTo(data_kubun) > 0 Then
                                                            Dim myCommand As New MySqlCommand(CreateSQL.CreateJvSeRaceUmaUpdate, con)
                                                            myCommand.Parameters.AddWithValue("?val1", Integer.Parse(RaceUmaInfo.Futan) / 10)
                                                            myCommand.Parameters.AddWithValue("?val2", RaceUmaInfo.BaTaijyu)
                                                            myCommand.Parameters.AddWithValue("?val3", Zougen)
                                                            myCommand.Parameters.AddWithValue("?val4", CodeConversion.IJyoCodeConversion(RaceUmaInfo.IJyoCD))
                                                            myCommand.Parameters.AddWithValue("?val5", CodeConversion.KyakusituCodeConversion(RaceUmaInfo.KyakusituKubun))
                                                            myCommand.Parameters.AddWithValue("?val6", Integer.Parse(RaceUmaInfo.Jyuni1c))
                                                            myCommand.Parameters.AddWithValue("?val7", Integer.Parse(RaceUmaInfo.Jyuni2c))
                                                            myCommand.Parameters.AddWithValue("?val8", Integer.Parse(RaceUmaInfo.Jyuni3c))
                                                            myCommand.Parameters.AddWithValue("?val9", Integer.Parse(RaceUmaInfo.Jyuni4c))
                                                            myCommand.Parameters.AddWithValue("?val10", Integer.Parse(RaceUmaInfo.KakuteiJyuni))
                                                            myCommand.Parameters.AddWithValue("?val11", Integer.Parse(RaceUmaInfo.Ninki))
                                                            myCommand.Parameters.AddWithValue("?val12", Integer.Parse(RaceUmaInfo.DochakuKubun))
                                                            myCommand.Parameters.AddWithValue("?val13", Integer.Parse(RaceUmaInfo.DochakuTosu))
                                                            myCommand.Parameters.AddWithValue("?val14", MyUtil.TimeConversionFromMMSStoMM(RaceUmaInfo.Time))
                                                            myCommand.Parameters.AddWithValue("?val15", Integer.Parse(RaceUmaInfo.Odds) / 10)
                                                            myCommand.Parameters.AddWithValue("?val16", Integer.Parse(RaceUmaInfo.HaronTimeL3) / 10)
                                                            myCommand.Parameters.AddWithValue("?val17", Integer.Parse(RaceUmaInfo.TimeDiff) / 10)
                                                            myCommand.Parameters.AddWithValue("?val18", RaceUmaInfo.head.DataKubun)
                                                            myCommand.Parameters.AddWithValue("?val19", RaceUmaInfo.head.MakeDate.Year & RaceUmaInfo.head.MakeDate.Month & RaceUmaInfo.head.MakeDate.Day)
                                                            myCommand.Parameters.AddWithValue("?val20", id)
                                                            'SQLを実行
                                                            myCommand.ExecuteNonQuery()
                                                        End If
                                                    Else
                                                        Dim myCommand As New MySqlCommand(CreateSQL.CreateJvSeRaceUmaInsert, con)
                                                        'プレースホルダーにバインド
                                                        myCommand.Parameters.AddWithValue("?val1", id)
                                                        myCommand.Parameters.AddWithValue("?val2", raceId)
                                                        myCommand.Parameters.AddWithValue("?val3", RaceUmaInfo.KettoNum)
                                                        myCommand.Parameters.AddWithValue("?val4", RaceUmaInfo.Bamei)
                                                        myCommand.Parameters.AddWithValue("?val5", Integer.Parse(RaceUmaInfo.Futan) / 10)
                                                        myCommand.Parameters.AddWithValue("?val6", RaceUmaInfo.BaTaijyu)
                                                        myCommand.Parameters.AddWithValue("?val7", Zougen)
                                                        myCommand.Parameters.AddWithValue("?val8", CodeConversion.IJyoCodeConversion(RaceUmaInfo.IJyoCD))
                                                        myCommand.Parameters.AddWithValue("?val9", CodeConversion.KyakusituCodeConversion(RaceUmaInfo.KyakusituKubun))
                                                        myCommand.Parameters.AddWithValue("?val10", Integer.Parse(RaceUmaInfo.Jyuni1c))
                                                        myCommand.Parameters.AddWithValue("?val11", Integer.Parse(RaceUmaInfo.Jyuni2c))
                                                        myCommand.Parameters.AddWithValue("?val12", Integer.Parse(RaceUmaInfo.Jyuni3c))
                                                        myCommand.Parameters.AddWithValue("?val13", Integer.Parse(RaceUmaInfo.Jyuni4c))
                                                        myCommand.Parameters.AddWithValue("?val14", Integer.Parse(RaceUmaInfo.KakuteiJyuni))
                                                        myCommand.Parameters.AddWithValue("?val15", Integer.Parse(RaceUmaInfo.Ninki))
                                                        myCommand.Parameters.AddWithValue("?val16", Integer.Parse(RaceUmaInfo.DochakuKubun))
                                                        myCommand.Parameters.AddWithValue("?val17", Integer.Parse(RaceUmaInfo.DochakuTosu))
                                                        myCommand.Parameters.AddWithValue("?val18", MyUtil.TimeConversionFromMMSStoMM(RaceUmaInfo.Time))
                                                        myCommand.Parameters.AddWithValue("?val19", Integer.Parse(RaceUmaInfo.Odds) / 10)
                                                        myCommand.Parameters.AddWithValue("?val20", Integer.Parse(RaceUmaInfo.HaronTimeL3) / 10)
                                                        myCommand.Parameters.AddWithValue("?val21", Integer.Parse(RaceUmaInfo.TimeDiff) / 10)
                                                        myCommand.Parameters.AddWithValue("?val22", RaceUmaInfo.head.DataKubun)
                                                        myCommand.Parameters.AddWithValue("?val23", RaceUmaInfo.head.MakeDate.Year & RaceUmaInfo.head.MakeDate.Month & RaceUmaInfo.head.MakeDate.Day)
                                                        'SQLを実行
                                                        myCommand.ExecuteNonQuery()
                                                    End If
                                                Catch ex As MySqlException
                                                    MessageBox.Show(ex.Message)
                                                End Try
                                            End If
                                        End If
                                    ElseIf Mid(strBuff, 1, 2) = "HR" Then
                                        PayInfo.SetData(strBuff)
                                        If "01".Equals(PayInfo.id.JyoCD) OrElse "02".Equals(PayInfo.id.JyoCD) OrElse "03".Equals(PayInfo.id.JyoCD) OrElse "04".Equals(PayInfo.id.JyoCD) OrElse "05".Equals(PayInfo.id.JyoCD) OrElse "06".Equals(PayInfo.id.JyoCD) OrElse "07".Equals(PayInfo.id.JyoCD) OrElse "08".Equals(PayInfo.id.JyoCD) OrElse "09".Equals(PayInfo.id.JyoCD) OrElse "10".Equals(PayInfo.id.JyoCD) Then
                                            'レースID
                                            Dim raceid As String = PayInfo.id.Year & PayInfo.id.MonthDay & PayInfo.id.JyoCD & PayInfo.id.Kaiji & PayInfo.id.Nichiji & PayInfo.id.RaceNum
                                            '年月日
                                            Dim ymd As String = PayInfo.id.Year & "年" & PayInfo.id.MonthDay.Substring(0, 2) & "月" & PayInfo.id.MonthDay.Substring(2, 2) & "日"
                                            '競馬場
                                            Dim KeibaJyo As String = KeibaJyoCodeConversion(PayInfo.id.JyoCD)
                                            'レース番号
                                            '単勝払戻１[馬番]
                                            Dim TanshoHaraimodoshi1Umaban As String = PayInfo.PayTansyo(0).Umaban
                                            '単勝払戻１[金額]
                                            Dim TanshoHaraimodoshi1KinGaku As Integer = Integer.Parse(PayInfo.PayTansyo(0).Pay)
                                            '単勝払戻１[人気]
                                            Dim TanshoHaraimodoshi1Ninki As Integer = Integer.Parse(PayInfo.PayTansyo(0).Ninki)
                                            '単勝払戻２[馬番]
                                            Dim TanshoHaraimodoshi2Umaban As String = ""
                                            '単勝払戻２[金額]
                                            Dim TanshoHaraimodoshi2KinGaku As Integer = 0
                                            '単勝払戻２[人気]
                                            Dim TanshoHaraimodoshi2Ninki As Integer = 0
                                            '単勝払戻３[馬番]
                                            Dim TanshoHaraimodoshi3Umaban As String = ""
                                            '単勝払戻３[金額]
                                            Dim TanshoHaraimodoshi3KinGaku As Integer = 0
                                            '単勝払戻３[人気]
                                            Dim TanshoHaraimodoshi3Ninki As Integer = 0
                                            If "".Equals(PayInfo.PayTansyo(1).Umaban.Trim()) Then
                                            Else
                                                TanshoHaraimodoshi2Umaban = PayInfo.PayTansyo(1).Umaban
                                                TanshoHaraimodoshi2KinGaku = Integer.Parse(PayInfo.PayTansyo(1).Pay)
                                                TanshoHaraimodoshi2Ninki = Integer.Parse(PayInfo.PayTansyo(1).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PayTansyo(2).Umaban.Trim()) Then
                                            Else
                                                TanshoHaraimodoshi3Umaban = PayInfo.PayTansyo(2).Umaban
                                                TanshoHaraimodoshi3KinGaku = Integer.Parse(PayInfo.PayTansyo(2).Pay)
                                                TanshoHaraimodoshi3Ninki = Integer.Parse(PayInfo.PayTansyo(2).Ninki)
                                            End If
                                            '馬連払戻１[馬番]
                                            Dim UmarenHaraimodoshi1Umaban As String = PayInfo.PayUmaren(0).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmaren(0).Kumi.Substring(2, 2)
                                            '馬連払戻１[金額]
                                            Dim UmarenHaraimodoshi1KinGaku As Integer = Integer.Parse(PayInfo.PayUmaren(0).Pay)
                                            '馬連払戻１[人気]
                                            Dim UmarenHaraimodoshi1Ninki As Integer = Integer.Parse(PayInfo.PayUmaren(0).Ninki)
                                            '馬連払戻２[馬番]
                                            Dim UmarenHaraimodoshi2Umaban As String = ""
                                            '馬連払戻２[金額]
                                            Dim UmarenHaraimodoshi2KinGaku As Integer = 0
                                            '馬連払戻２[人気]
                                            Dim UmarenHaraimodoshi2Ninki As Integer = 0
                                            '馬連払戻３[馬番]
                                            Dim UmarenHaraimodoshi3Umaban As String = ""
                                            '馬連払戻３[金額]
                                            Dim UmarenHaraimodoshi3KinGaku As Integer = 0
                                            '馬連払戻３[人気]
                                            Dim UmarenHaraimodoshi3Ninki As Integer = 0
                                            If "".Equals(PayInfo.PayUmaren(1).Kumi.Trim()) Then
                                            Else
                                                UmarenHaraimodoshi2Umaban = PayInfo.PayUmaren(1).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmaren(1).Kumi.Substring(2, 2)
                                                UmarenHaraimodoshi2KinGaku = Integer.Parse(PayInfo.PayUmaren(1).Pay)
                                                UmarenHaraimodoshi2Ninki = Integer.Parse(PayInfo.PayUmaren(1).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PayUmaren(2).Kumi.Trim()) Then
                                            Else
                                                UmarenHaraimodoshi3Umaban = PayInfo.PayUmaren(2).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmaren(2).Kumi.Substring(2, 2)
                                                UmarenHaraimodoshi3KinGaku = Integer.Parse(PayInfo.PayUmaren(2).Pay)
                                                UmarenHaraimodoshi3Ninki = Integer.Parse(PayInfo.PayUmaren(2).Ninki)
                                            End If
                                            '三連複払戻１[馬番]
                                            Dim SanrenpukuHaraimodoshi1Umaban As String = PayInfo.PaySanrenpuku(0).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrenpuku(0).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrenpuku(0).Kumi.Substring(4, 2)
                                            '三連複払戻１[金額]
                                            Dim SanrenpukuHaraimodoshi1KinGaku As Integer = Integer.Parse(PayInfo.PaySanrenpuku(0).Pay)
                                            '三連複払戻１[人気]
                                            Dim SanrenpukuHaraimodoshi1Ninki As Integer = Integer.Parse(PayInfo.PaySanrenpuku(0).Ninki)
                                            '三連複払戻２[馬番]
                                            Dim SanrenpukuHaraimodoshi2Umaban As String = ""
                                            '三連複払戻２[金額]
                                            Dim SanrenpukuHaraimodoshi2KinGaku As Integer = 0
                                            '三連複払戻２[人気]
                                            Dim SanrenpukuHaraimodoshi2Ninki As Integer = 0
                                            '三連複払戻３[馬番]
                                            Dim SanrenpukuHaraimodoshi3Umaban As String = ""
                                            '三連複払戻３[金額]
                                            Dim SanrenpukuHaraimodoshi3KinGaku As Integer = 0
                                            '三連複払戻３[人気]
                                            Dim SanrenpukuHaraimodoshi3Ninki As Integer = 0
                                            If "".Equals(PayInfo.PaySanrenpuku(1).Kumi.Trim()) Then
                                            Else
                                                SanrenpukuHaraimodoshi2Umaban = PayInfo.PaySanrenpuku(1).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrenpuku(1).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrenpuku(1).Kumi.Substring(4, 2)
                                                SanrenpukuHaraimodoshi2KinGaku = Integer.Parse(PayInfo.PaySanrenpuku(1).Pay)
                                                SanrenpukuHaraimodoshi2Ninki = Integer.Parse(PayInfo.PaySanrenpuku(1).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PaySanrenpuku(2).Kumi.Trim()) Then
                                            Else
                                                SanrenpukuHaraimodoshi3Umaban = PayInfo.PaySanrenpuku(2).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrenpuku(2).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrenpuku(2).Kumi.Substring(4, 2)
                                                SanrenpukuHaraimodoshi3KinGaku = Integer.Parse(PayInfo.PaySanrenpuku(2).Pay)
                                                SanrenpukuHaraimodoshi3Ninki = Integer.Parse(PayInfo.PaySanrenpuku(2).Ninki)
                                            End If
                                            '三連単払戻１[馬番]
                                            Dim SanrentanHaraimodoshi1Umaban As String = PayInfo.PaySanrentan(0).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrentan(0).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrentan(0).Kumi.Substring(4, 2)
                                            '三連単払戻１[金額]
                                            Dim SanrentanHaraimodoshi1KinGaku As Integer = Integer.Parse(PayInfo.PaySanrentan(0).Pay)
                                            '三連単払戻１[人気]
                                            Dim SanrentanHaraimodoshi1Ninki As Integer = Integer.Parse(PayInfo.PaySanrentan(0).Ninki)
                                            '三連単払戻２[馬番]
                                            Dim SanrentanHaraimodoshi2Umaban As String = ""
                                            '三連単払戻２[金額]
                                            Dim SanrentanHaraimodoshi2KinGaku As Integer = 0
                                            '三連単払戻２[人気]
                                            Dim SanrentanHaraimodoshi2Ninki As Integer = 0
                                            '三連単払戻３[馬番]
                                            Dim SanrentanHaraimodoshi3Umaban As String = ""
                                            '三連単払戻３[金額]
                                            Dim SanrentanHaraimodoshi3KinGaku As Integer = 0
                                            '三連単払戻３[人気]
                                            Dim SanrentanHaraimodoshi3Ninki As Integer = 0
                                            '三連単払戻４[馬番]
                                            Dim SanrentanHaraimodoshi4Umaban As String = ""
                                            '三連単払戻４[金額]
                                            Dim SanrentanHaraimodoshi4KinGaku As Integer = 0
                                            '三連単払戻４[人気]
                                            Dim SanrentanHaraimodoshi4Ninki As Integer = 0
                                            '三連単払戻５[馬番]
                                            Dim SanrentanHaraimodoshi5Umaban As String = ""
                                            '三連単払戻５[金額]
                                            Dim SanrentanHaraimodoshi5KinGaku As Integer = 0
                                            '三連単払戻５[人気]
                                            Dim SanrentanHaraimodoshi5Ninki As Integer = 0
                                            '三連単払戻６[馬番]
                                            Dim SanrentanHaraimodoshi6Umaban As String = ""
                                            '三連単払戻６[金額]
                                            Dim SanrentanHaraimodoshi6KinGaku As Integer = 0
                                            '三連単払戻６[人気]
                                            Dim SanrentanHaraimodoshi6Ninki As Integer = 0
                                            If "".Equals(PayInfo.PaySanrentan(1).Kumi.Trim()) Then
                                            Else
                                                SanrentanHaraimodoshi2Umaban = PayInfo.PaySanrentan(1).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrentan(1).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrentan(1).Kumi.Substring(4, 2)
                                                SanrentanHaraimodoshi2KinGaku = Integer.Parse(PayInfo.PaySanrentan(1).Pay)
                                                SanrentanHaraimodoshi2Ninki = Integer.Parse(PayInfo.PaySanrentan(1).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PaySanrentan(2).Kumi.Trim()) Then
                                            Else
                                                SanrentanHaraimodoshi3Umaban = PayInfo.PaySanrentan(2).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrentan(2).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrentan(2).Kumi.Substring(4, 2)
                                                SanrentanHaraimodoshi3KinGaku = Integer.Parse(PayInfo.PaySanrentan(2).Pay)
                                                SanrentanHaraimodoshi3Ninki = Integer.Parse(PayInfo.PaySanrentan(2).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PaySanrentan(3).Kumi.Trim()) Then
                                            Else
                                                SanrentanHaraimodoshi4Umaban = PayInfo.PaySanrentan(3).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrentan(3).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrentan(3).Kumi.Substring(4, 2)
                                                SanrentanHaraimodoshi4KinGaku = Integer.Parse(PayInfo.PaySanrentan(3).Pay)
                                                SanrentanHaraimodoshi4Ninki = Integer.Parse(PayInfo.PaySanrentan(3).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PaySanrentan(4).Kumi.Trim()) Then
                                            Else
                                                SanrentanHaraimodoshi5Umaban = PayInfo.PaySanrentan(4).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrentan(4).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrentan(4).Kumi.Substring(4, 2)
                                                SanrentanHaraimodoshi5KinGaku = Integer.Parse(PayInfo.PaySanrentan(4).Pay)
                                                SanrentanHaraimodoshi5Ninki = Integer.Parse(PayInfo.PaySanrentan(4).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PaySanrentan(5).Kumi.Trim()) Then
                                            Else
                                                SanrentanHaraimodoshi6Umaban = PayInfo.PaySanrentan(5).Kumi.Substring(0, 2) & "-" & PayInfo.PaySanrentan(5).Kumi.Substring(2, 2) & "-" & PayInfo.PaySanrentan(5).Kumi.Substring(4, 2)
                                                SanrentanHaraimodoshi6KinGaku = Integer.Parse(PayInfo.PaySanrentan(5).Pay)
                                                SanrentanHaraimodoshi6Ninki = Integer.Parse(PayInfo.PaySanrentan(5).Ninki)
                                            End If
                                            'ワイド払戻１[馬番]
                                            Dim WideHaraimodoshi1Umaban As String = PayInfo.PayWide(0).Kumi.Substring(0, 2) & "-" & PayInfo.PayWide(0).Kumi.Substring(2, 2)
                                            'ワイド払戻１[金額]
                                            Dim WideHaraimodoshi1KinGaku As Integer = Integer.Parse(PayInfo.PayWide(0).Pay)
                                            'ワイド払戻１[人気]
                                            Dim WideHaraimodoshi1Ninki As Integer = Integer.Parse(PayInfo.PayWide(0).Ninki)
                                            'ワイド払戻２[馬番]
                                            Dim WideHaraimodoshi2Umaban As String = ""
                                            'ワイド払戻２[金額]
                                            Dim WideHaraimodoshi2KinGaku As Integer = 0
                                            'ワイド払戻２[人気]
                                            Dim WideHaraimodoshi2Ninki As Integer = 0
                                            'ワイド払戻３[馬番]
                                            Dim WideHaraimodoshi3Umaban As String = ""
                                            'ワイド払戻３[金額]
                                            Dim WideHaraimodoshi3KinGaku As Integer = 0
                                            'ワイド払戻３[人気]
                                            Dim WideHaraimodoshi3Ninki As Integer = 0
                                            'ワイド払戻４[馬番]
                                            Dim WideHaraimodoshi4Umaban As String = ""
                                            'ワイド払戻４[金額]
                                            Dim WideHaraimodoshi4KinGaku As Integer = 0
                                            'ワイド払戻４[人気]
                                            Dim WideHaraimodoshi4Ninki As Integer = 0
                                            'ワイド払戻５[馬番]
                                            Dim WideHaraimodoshi5Umaban As String = ""
                                            'ワイド払戻５[金額]
                                            Dim WideHaraimodoshi5KinGaku As Integer = 0
                                            'ワイド払戻５[人気]
                                            Dim WideHaraimodoshi5Ninki As Integer = 0
                                            'ワイド払戻６[馬番]
                                            Dim WideHaraimodoshi6Umaban As String = ""
                                            'ワイド払戻６[金額]
                                            Dim WideHaraimodoshi6KinGaku As Integer = 0
                                            'ワイド払戻６[人気]
                                            Dim WideHaraimodoshi6Ninki As Integer = 0
                                            'ワイド払戻７[馬番]
                                            Dim WideHaraimodoshi7Umaban As String = ""
                                            'ワイド払戻７[金額]
                                            Dim WideHaraimodoshi7KinGaku As Integer = 0
                                            'ワイド払戻７[人気]
                                            Dim WideHaraimodoshi7Ninki As Integer = 0
                                            If "".Equals(PayInfo.PayWide(1).Kumi.Trim()) Then
                                            Else
                                                WideHaraimodoshi2Umaban = PayInfo.PayWide(1).Kumi.Substring(0, 2) & "-" & PayInfo.PayWide(1).Kumi.Substring(2, 2)
                                                WideHaraimodoshi2KinGaku = Integer.Parse(PayInfo.PayWide(1).Pay)
                                                WideHaraimodoshi2Ninki = Integer.Parse(PayInfo.PayWide(1).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PayWide(2).Kumi.Trim()) Then
                                            Else
                                                WideHaraimodoshi3Umaban = PayInfo.PayWide(2).Kumi.Substring(0, 2) & "-" & PayInfo.PayWide(2).Kumi.Substring(2, 2)
                                                WideHaraimodoshi3KinGaku = Integer.Parse(PayInfo.PayWide(2).Pay)
                                                WideHaraimodoshi3Ninki = Integer.Parse(PayInfo.PayWide(2).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PayWide(3).Kumi.Trim()) Then
                                            Else
                                                WideHaraimodoshi4Umaban = PayInfo.PayWide(3).Kumi.Substring(0, 2) & "-" & PayInfo.PayWide(3).Kumi.Substring(2, 2)
                                                WideHaraimodoshi4KinGaku = Integer.Parse(PayInfo.PayWide(3).Pay)
                                                WideHaraimodoshi4Ninki = Integer.Parse(PayInfo.PayWide(3).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PayWide(4).Kumi.Trim()) Then
                                            Else
                                                WideHaraimodoshi5Umaban = PayInfo.PayWide(4).Kumi.Substring(0, 2) & "-" & PayInfo.PayWide(4).Kumi.Substring(2, 2)
                                                WideHaraimodoshi5KinGaku = Integer.Parse(PayInfo.PayWide(4).Pay)
                                                WideHaraimodoshi5Ninki = Integer.Parse(PayInfo.PayWide(4).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PayWide(5).Kumi.Trim()) Then
                                            Else
                                                WideHaraimodoshi6Umaban = PayInfo.PayWide(5).Kumi.Substring(0, 2) & "-" & PayInfo.PayWide(5).Kumi.Substring(2, 2)
                                                WideHaraimodoshi6KinGaku = Integer.Parse(PayInfo.PayWide(5).Pay)
                                                WideHaraimodoshi6Ninki = Integer.Parse(PayInfo.PayWide(5).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PayWide(6).Kumi.Trim()) Then
                                            Else
                                                WideHaraimodoshi7Umaban = PayInfo.PayWide(6).Kumi.Substring(0, 2) & "-" & PayInfo.PayWide(6).Kumi.Substring(2, 2)
                                                WideHaraimodoshi7KinGaku = Integer.Parse(PayInfo.PayWide(6).Pay)
                                                WideHaraimodoshi7Ninki = Integer.Parse(PayInfo.PayWide(6).Ninki)
                                            End If
                                            '馬単払戻１[馬番]
                                            Dim UmatanHaraimodoshi1Umaban As String = PayInfo.PayUmatan(0).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmatan(0).Kumi.Substring(2, 2)
                                            '馬単払戻１[金額]
                                            Dim UmatanHaraimodoshi1KinGaku As Integer = Integer.Parse(PayInfo.PayUmatan(0).Pay)
                                            '馬単払戻１[人気]
                                            Dim UmatanHaraimodoshi1Ninki As Integer = Integer.Parse(PayInfo.PayUmatan(0).Ninki)
                                            '馬単払戻２[馬番]
                                            Dim UmatanHaraimodoshi2Umaban As String = ""
                                            '馬単払戻２[金額]
                                            Dim UmatanHaraimodoshi2KinGaku As Integer = 0
                                            '馬単払戻２[人気]
                                            Dim UmatanHaraimodoshi2Ninki As Integer = 0
                                            '馬単払戻３[馬番]
                                            Dim UmatanHaraimodoshi3Umaban As String = ""
                                            '馬単払戻３[金額]
                                            Dim UmatanHaraimodoshi3KinGaku As Integer = 0
                                            '馬単払戻３[人気]
                                            Dim UmatanHaraimodoshi3Ninki As Integer = 0
                                            '馬単払戻４[馬番]
                                            Dim UmatanHaraimodoshi4Umaban As String = ""
                                            '馬単払戻４[金額]
                                            Dim UmatanHaraimodoshi4KinGaku As Integer = 0
                                            '馬単払戻４[人気]
                                            Dim UmatanHaraimodoshi4Ninki As Integer = 0
                                            '馬単払戻５[馬番]
                                            Dim UmatanHaraimodoshi5Umaban As String = ""
                                            '馬単払戻５[金額]
                                            Dim UmatanHaraimodoshi5KinGaku As Integer = 0
                                            '馬単払戻５[人気]
                                            Dim UmatanHaraimodoshi5Ninki As Integer = 0
                                            '馬単払戻６[馬番]
                                            Dim UmatanHaraimodoshi6Umaban As String = ""
                                            '馬単払戻６[金額]
                                            Dim UmatanHaraimodoshi6KinGaku As Integer = 0
                                            '馬単払戻６[人気]
                                            Dim UmatanHaraimodoshi6Ninki As Integer = 0
                                            If "".Equals(PayInfo.PayUmatan(1).Kumi.Trim()) Then
                                            Else
                                                UmatanHaraimodoshi2Umaban = PayInfo.PayUmatan(1).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmatan(1).Kumi.Substring(2, 2)
                                                UmatanHaraimodoshi2KinGaku = Integer.Parse(PayInfo.PayUmatan(1).Pay)
                                                UmatanHaraimodoshi2Ninki = Integer.Parse(PayInfo.PayUmatan(1).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PayUmatan(2).Kumi.Trim()) Then
                                            Else
                                                UmatanHaraimodoshi3Umaban = PayInfo.PayUmatan(2).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmatan(2).Kumi.Substring(2, 2)
                                                UmatanHaraimodoshi3KinGaku = Integer.Parse(PayInfo.PayUmatan(2).Pay)
                                                UmatanHaraimodoshi3Ninki = Integer.Parse(PayInfo.PayUmatan(2).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PayUmatan(3).Kumi.Trim()) Then
                                            Else
                                                UmatanHaraimodoshi4Umaban = PayInfo.PayUmatan(3).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmatan(3).Kumi.Substring(2, 2)
                                                UmatanHaraimodoshi4KinGaku = Integer.Parse(PayInfo.PayUmatan(3).Pay)
                                                UmatanHaraimodoshi4Ninki = Integer.Parse(PayInfo.PayUmatan(3).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PayUmatan(4).Kumi.Trim()) Then
                                            Else
                                                UmatanHaraimodoshi5Umaban = PayInfo.PayUmatan(4).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmatan(4).Kumi.Substring(2, 2)
                                                UmatanHaraimodoshi5KinGaku = Integer.Parse(PayInfo.PayUmatan(4).Pay)
                                                UmatanHaraimodoshi5Ninki = Integer.Parse(PayInfo.PayUmatan(4).Ninki)
                                            End If
                                            If "".Equals(PayInfo.PayUmatan(5).Kumi.Trim()) Then
                                            Else
                                                UmatanHaraimodoshi6Umaban = PayInfo.PayUmatan(5).Kumi.Substring(0, 2) & "-" & PayInfo.PayUmatan(5).Kumi.Substring(2, 2)
                                                UmatanHaraimodoshi6KinGaku = Integer.Parse(PayInfo.PayUmatan(5).Pay)
                                                UmatanHaraimodoshi6Ninki = Integer.Parse(PayInfo.PayUmatan(5).Ninki)
                                            End If
                                            Try
                                                Dim CommandText As String = "Select count(*) FROM jv_hr_pay WHERE race_id = '" & raceid & "'"
                                                Dim Command As New MySqlCommand(CommandText, con)
                                                Dim count As Integer = Command.ExecuteScalar()
                                                If count > 0 Then
                                                    CommandText = "SELECT data_kubun FROM jv_hr_pay WHERE race_id = '" & raceid & "'"
                                                    Command = New MySqlCommand(CommandText, con)
                                                    Dim data_kubun As String = Command.ExecuteScalar()
                                                    If PayInfo.head.DataKubun.CompareTo(data_kubun) > 0 Then
                                                        Dim myCommand As New MySqlCommand(CreateSQL.CreateJvHrPayUpdate(), con)
                                                        myCommand.Parameters.AddWithValue("?val1", TanshoHaraimodoshi1Umaban)
                                                        myCommand.Parameters.AddWithValue("?val2", TanshoHaraimodoshi1KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val3", TanshoHaraimodoshi1Ninki)
                                                        myCommand.Parameters.AddWithValue("?val4", TanshoHaraimodoshi2Umaban)
                                                        myCommand.Parameters.AddWithValue("?val5", TanshoHaraimodoshi2KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val6", TanshoHaraimodoshi2Ninki)
                                                        myCommand.Parameters.AddWithValue("?val7", TanshoHaraimodoshi3Umaban)
                                                        myCommand.Parameters.AddWithValue("?val8", TanshoHaraimodoshi3KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val9", TanshoHaraimodoshi3Ninki)
                                                        myCommand.Parameters.AddWithValue("?val10", UmarenHaraimodoshi1Umaban)
                                                        myCommand.Parameters.AddWithValue("?val11", UmarenHaraimodoshi1KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val12", UmarenHaraimodoshi1Ninki)
                                                        myCommand.Parameters.AddWithValue("?val13", UmarenHaraimodoshi2Umaban)
                                                        myCommand.Parameters.AddWithValue("?val14", UmarenHaraimodoshi2KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val15", UmarenHaraimodoshi2Ninki)
                                                        myCommand.Parameters.AddWithValue("?val16", UmarenHaraimodoshi3Umaban)
                                                        myCommand.Parameters.AddWithValue("?val17", UmarenHaraimodoshi3KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val18", UmarenHaraimodoshi3Ninki)
                                                        myCommand.Parameters.AddWithValue("?val19", SanrenpukuHaraimodoshi1Umaban)
                                                        myCommand.Parameters.AddWithValue("?val20", SanrenpukuHaraimodoshi1KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val21", SanrenpukuHaraimodoshi1Ninki)
                                                        myCommand.Parameters.AddWithValue("?val22", SanrenpukuHaraimodoshi2Umaban)
                                                        myCommand.Parameters.AddWithValue("?val23", SanrenpukuHaraimodoshi2KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val24", SanrenpukuHaraimodoshi2Ninki)
                                                        myCommand.Parameters.AddWithValue("?val25", SanrenpukuHaraimodoshi3Umaban)
                                                        myCommand.Parameters.AddWithValue("?val26", SanrenpukuHaraimodoshi3KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val27", SanrenpukuHaraimodoshi3Ninki)
                                                        myCommand.Parameters.AddWithValue("?val28", SanrentanHaraimodoshi1Umaban)
                                                        myCommand.Parameters.AddWithValue("?val29", SanrentanHaraimodoshi1KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val30", SanrentanHaraimodoshi1Ninki)
                                                        myCommand.Parameters.AddWithValue("?val31", SanrentanHaraimodoshi2Umaban)
                                                        myCommand.Parameters.AddWithValue("?val32", SanrentanHaraimodoshi2KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val33", SanrentanHaraimodoshi2Ninki)
                                                        myCommand.Parameters.AddWithValue("?val34", SanrentanHaraimodoshi3Umaban)
                                                        myCommand.Parameters.AddWithValue("?val35", SanrentanHaraimodoshi3KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val36", SanrentanHaraimodoshi3Ninki)
                                                        myCommand.Parameters.AddWithValue("?val37", SanrentanHaraimodoshi4Umaban)
                                                        myCommand.Parameters.AddWithValue("?val38", SanrentanHaraimodoshi4KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val39", SanrentanHaraimodoshi4Ninki)
                                                        myCommand.Parameters.AddWithValue("?val40", SanrentanHaraimodoshi5Umaban)
                                                        myCommand.Parameters.AddWithValue("?val41", SanrentanHaraimodoshi5KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val42", SanrentanHaraimodoshi5Ninki)
                                                        myCommand.Parameters.AddWithValue("?val43", SanrentanHaraimodoshi6Umaban)
                                                        myCommand.Parameters.AddWithValue("?val44", SanrentanHaraimodoshi6KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val45", SanrentanHaraimodoshi6Ninki)
                                                        myCommand.Parameters.AddWithValue("?val46", WideHaraimodoshi1Umaban)
                                                        myCommand.Parameters.AddWithValue("?val47", WideHaraimodoshi1KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val48", WideHaraimodoshi1Ninki)
                                                        myCommand.Parameters.AddWithValue("?val49", WideHaraimodoshi2Umaban)
                                                        myCommand.Parameters.AddWithValue("?val50", WideHaraimodoshi2KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val51", WideHaraimodoshi2Ninki)
                                                        myCommand.Parameters.AddWithValue("?val52", WideHaraimodoshi3Umaban)
                                                        myCommand.Parameters.AddWithValue("?val53", WideHaraimodoshi3KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val54", WideHaraimodoshi3Ninki)
                                                        myCommand.Parameters.AddWithValue("?val55", WideHaraimodoshi4Umaban)
                                                        myCommand.Parameters.AddWithValue("?val56", WideHaraimodoshi4KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val57", WideHaraimodoshi4Ninki)
                                                        myCommand.Parameters.AddWithValue("?val58", WideHaraimodoshi5Umaban)
                                                        myCommand.Parameters.AddWithValue("?val59", WideHaraimodoshi5KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val60", WideHaraimodoshi5Ninki)
                                                        myCommand.Parameters.AddWithValue("?val61", WideHaraimodoshi6Umaban)
                                                        myCommand.Parameters.AddWithValue("?val62", WideHaraimodoshi6KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val63", WideHaraimodoshi6Ninki)
                                                        myCommand.Parameters.AddWithValue("?val64", WideHaraimodoshi7Umaban)
                                                        myCommand.Parameters.AddWithValue("?val65", WideHaraimodoshi7KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val66", WideHaraimodoshi7Ninki)
                                                        myCommand.Parameters.AddWithValue("?val67", UmatanHaraimodoshi1Umaban)
                                                        myCommand.Parameters.AddWithValue("?val68", UmatanHaraimodoshi1KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val69", UmatanHaraimodoshi1Ninki)
                                                        myCommand.Parameters.AddWithValue("?val70", UmatanHaraimodoshi2Umaban)
                                                        myCommand.Parameters.AddWithValue("?val71", UmatanHaraimodoshi2KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val72", UmatanHaraimodoshi2Ninki)
                                                        myCommand.Parameters.AddWithValue("?val73", UmatanHaraimodoshi3Umaban)
                                                        myCommand.Parameters.AddWithValue("?val74", UmatanHaraimodoshi3KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val75", UmatanHaraimodoshi3Ninki)
                                                        myCommand.Parameters.AddWithValue("?val76", UmatanHaraimodoshi4Umaban)
                                                        myCommand.Parameters.AddWithValue("?val77", UmatanHaraimodoshi4KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val78", UmatanHaraimodoshi4Ninki)
                                                        myCommand.Parameters.AddWithValue("?val79", UmatanHaraimodoshi5Umaban)
                                                        myCommand.Parameters.AddWithValue("?val80", UmatanHaraimodoshi5KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val81", UmatanHaraimodoshi5Ninki)
                                                        myCommand.Parameters.AddWithValue("?val82", UmatanHaraimodoshi6Umaban)
                                                        myCommand.Parameters.AddWithValue("?val83", UmatanHaraimodoshi6KinGaku)
                                                        myCommand.Parameters.AddWithValue("?val84", UmatanHaraimodoshi6Ninki)
                                                        myCommand.Parameters.AddWithValue("?val85", PayInfo.head.DataKubun)
                                                        myCommand.Parameters.AddWithValue("?val86", PayInfo.head.MakeDate.Year & PayInfo.head.MakeDate.Month & PayInfo.head.MakeDate.Day)
                                                        myCommand.Parameters.AddWithValue("?val87", raceid)
                                                        'SQLを実行
                                                        myCommand.ExecuteNonQuery()
                                                    End If
                                                Else
                                                    'Insert実行
                                                    Dim myCommand As New MySqlCommand(CreateSQL.CreateJvHrPayInsert(), con)
                                                    'プレースホルダーにバインド
                                                    myCommand.Parameters.AddWithValue("?val1", raceid)
                                                    myCommand.Parameters.AddWithValue("?val2", PayInfo.id.Year)
                                                    myCommand.Parameters.AddWithValue("?val3", PayInfo.id.MonthDay.Substring(0, 2))
                                                    myCommand.Parameters.AddWithValue("?val4", PayInfo.id.MonthDay.Substring(2, 2))
                                                    myCommand.Parameters.AddWithValue("?val5", KeibaJyo)
                                                    myCommand.Parameters.AddWithValue("?val6", PayInfo.id.RaceNum)
                                                    myCommand.Parameters.AddWithValue("?val7", TanshoHaraimodoshi1Umaban)
                                                    myCommand.Parameters.AddWithValue("?val8", TanshoHaraimodoshi1KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val9", TanshoHaraimodoshi1Ninki)
                                                    myCommand.Parameters.AddWithValue("?val10", TanshoHaraimodoshi2Umaban)
                                                    myCommand.Parameters.AddWithValue("?val11", TanshoHaraimodoshi2KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val12", TanshoHaraimodoshi2Ninki)
                                                    myCommand.Parameters.AddWithValue("?val13", TanshoHaraimodoshi3Umaban)
                                                    myCommand.Parameters.AddWithValue("?val14", TanshoHaraimodoshi3KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val15", TanshoHaraimodoshi3Ninki)
                                                    myCommand.Parameters.AddWithValue("?val16", UmarenHaraimodoshi1Umaban)
                                                    myCommand.Parameters.AddWithValue("?val17", UmarenHaraimodoshi1KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val18", UmarenHaraimodoshi1Ninki)
                                                    myCommand.Parameters.AddWithValue("?val19", UmarenHaraimodoshi2Umaban)
                                                    myCommand.Parameters.AddWithValue("?val20", UmarenHaraimodoshi2KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val21", UmarenHaraimodoshi2Ninki)
                                                    myCommand.Parameters.AddWithValue("?val22", UmarenHaraimodoshi3Umaban)
                                                    myCommand.Parameters.AddWithValue("?val23", UmarenHaraimodoshi3KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val24", UmarenHaraimodoshi3Ninki)
                                                    myCommand.Parameters.AddWithValue("?val25", SanrenpukuHaraimodoshi1Umaban)
                                                    myCommand.Parameters.AddWithValue("?val26", SanrenpukuHaraimodoshi1KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val27", SanrenpukuHaraimodoshi1Ninki)
                                                    myCommand.Parameters.AddWithValue("?val28", SanrenpukuHaraimodoshi2Umaban)
                                                    myCommand.Parameters.AddWithValue("?val29", SanrenpukuHaraimodoshi2KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val30", SanrenpukuHaraimodoshi2Ninki)
                                                    myCommand.Parameters.AddWithValue("?val31", SanrenpukuHaraimodoshi3Umaban)
                                                    myCommand.Parameters.AddWithValue("?val32", SanrenpukuHaraimodoshi3KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val33", SanrenpukuHaraimodoshi3Ninki)
                                                    myCommand.Parameters.AddWithValue("?val34", SanrentanHaraimodoshi1Umaban)
                                                    myCommand.Parameters.AddWithValue("?val35", SanrentanHaraimodoshi1KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val36", SanrentanHaraimodoshi1Ninki)
                                                    myCommand.Parameters.AddWithValue("?val37", SanrentanHaraimodoshi2Umaban)
                                                    myCommand.Parameters.AddWithValue("?val38", SanrentanHaraimodoshi2KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val39", SanrentanHaraimodoshi2Ninki)
                                                    myCommand.Parameters.AddWithValue("?val40", SanrentanHaraimodoshi3Umaban)
                                                    myCommand.Parameters.AddWithValue("?val41", SanrentanHaraimodoshi3KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val42", SanrentanHaraimodoshi3Ninki)
                                                    myCommand.Parameters.AddWithValue("?val43", SanrentanHaraimodoshi4Umaban)
                                                    myCommand.Parameters.AddWithValue("?val44", SanrentanHaraimodoshi4KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val45", SanrentanHaraimodoshi4Ninki)
                                                    myCommand.Parameters.AddWithValue("?val46", SanrentanHaraimodoshi5Umaban)
                                                    myCommand.Parameters.AddWithValue("?val47", SanrentanHaraimodoshi5KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val48", SanrentanHaraimodoshi5Ninki)
                                                    myCommand.Parameters.AddWithValue("?val49", SanrentanHaraimodoshi6Umaban)
                                                    myCommand.Parameters.AddWithValue("?val50", SanrentanHaraimodoshi6KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val51", SanrentanHaraimodoshi6Ninki)
                                                    myCommand.Parameters.AddWithValue("?val52", WideHaraimodoshi1Umaban)
                                                    myCommand.Parameters.AddWithValue("?val53", WideHaraimodoshi1KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val54", WideHaraimodoshi1Ninki)
                                                    myCommand.Parameters.AddWithValue("?val55", WideHaraimodoshi2Umaban)
                                                    myCommand.Parameters.AddWithValue("?val56", WideHaraimodoshi2KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val57", WideHaraimodoshi2Ninki)
                                                    myCommand.Parameters.AddWithValue("?val58", WideHaraimodoshi3Umaban)
                                                    myCommand.Parameters.AddWithValue("?val59", WideHaraimodoshi3KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val60", WideHaraimodoshi3Ninki)
                                                    myCommand.Parameters.AddWithValue("?val61", WideHaraimodoshi4Umaban)
                                                    myCommand.Parameters.AddWithValue("?val62", WideHaraimodoshi4KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val63", WideHaraimodoshi4Ninki)
                                                    myCommand.Parameters.AddWithValue("?val64", WideHaraimodoshi5Umaban)
                                                    myCommand.Parameters.AddWithValue("?val65", WideHaraimodoshi5KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val66", WideHaraimodoshi5Ninki)
                                                    myCommand.Parameters.AddWithValue("?val67", WideHaraimodoshi6Umaban)
                                                    myCommand.Parameters.AddWithValue("?val68", WideHaraimodoshi6KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val69", WideHaraimodoshi6Ninki)
                                                    myCommand.Parameters.AddWithValue("?val70", WideHaraimodoshi7Umaban)
                                                    myCommand.Parameters.AddWithValue("?val71", WideHaraimodoshi7KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val72", WideHaraimodoshi7Ninki)
                                                    myCommand.Parameters.AddWithValue("?val73", UmatanHaraimodoshi1Umaban)
                                                    myCommand.Parameters.AddWithValue("?val74", UmatanHaraimodoshi1KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val75", UmatanHaraimodoshi1Ninki)
                                                    myCommand.Parameters.AddWithValue("?val76", UmatanHaraimodoshi2Umaban)
                                                    myCommand.Parameters.AddWithValue("?val77", UmatanHaraimodoshi2KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val78", UmatanHaraimodoshi2Ninki)
                                                    myCommand.Parameters.AddWithValue("?val79", UmatanHaraimodoshi3Umaban)
                                                    myCommand.Parameters.AddWithValue("?val80", UmatanHaraimodoshi3KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val81", UmatanHaraimodoshi3Ninki)
                                                    myCommand.Parameters.AddWithValue("?val82", UmatanHaraimodoshi4Umaban)
                                                    myCommand.Parameters.AddWithValue("?val83", UmatanHaraimodoshi4KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val84", UmatanHaraimodoshi4Ninki)
                                                    myCommand.Parameters.AddWithValue("?val85", UmatanHaraimodoshi5Umaban)
                                                    myCommand.Parameters.AddWithValue("?val86", UmatanHaraimodoshi5KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val87", UmatanHaraimodoshi5Ninki)
                                                    myCommand.Parameters.AddWithValue("?val88", UmatanHaraimodoshi6Umaban)
                                                    myCommand.Parameters.AddWithValue("?val89", UmatanHaraimodoshi6KinGaku)
                                                    myCommand.Parameters.AddWithValue("?val90", UmatanHaraimodoshi6Ninki)
                                                    myCommand.Parameters.AddWithValue("?val91", PayInfo.head.DataKubun)
                                                    myCommand.Parameters.AddWithValue("?val92", PayInfo.head.MakeDate.Year & PayInfo.head.MakeDate.Month & PayInfo.head.MakeDate.Day)
                                                    'SQLを実行
                                                    myCommand.ExecuteNonQuery()
                                                End If
                                            Catch ex As MySqlException
                                                MessageBox.Show(ex.Message)
                                            End Try
                                        End If
                                    End If
                            End Select
                        Loop While (1)
                    End If
                    'JVLink終了処理
                    lReturnCode = Me.AxJVLink1.JVClose()
                    If lReturnCode <> 0 Then
                        MsgBox("JVClseエラー：" & lReturnCode)
                    End If
                Next
                'タイマ有効時は、無効化する
                If TimerDownload.Enabled = True Then
                    TimerDownload.Enabled = False
                End If
            End Using
        Catch
            Debug.WriteLine(Err.Description)
            Exit Sub
        End Try
        MsgBox("更新完了しました。")
    End Sub
End Class

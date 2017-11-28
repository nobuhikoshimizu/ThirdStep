Imports MySql.Data.MySqlClient

Module DBManager
    '------------------------------------------------------------------------
    '　　MySqlConnectionを確立し
    '------------------------------------------------------------------------
    '	[戻り値]
    '		MySqlConnection	   = MySql接続オブジェクト
    '------------------------------------------------------------------------
    Public Function CreateMySqlConnection() As MySqlConnection

        Dim con As MySqlConnection = New MySqlConnection
        '接続文字列を設定
        'ローカル用
        'con.ConnectionString = "Database=umagoro;Data Source=localhost;User Id=umagoro;Password=658umagoro658"
        'リモート用
        con.ConnectionString = "Database=umagoro;Data Source=voicesfromthesun.com;User Id=umagoro;Password=658umagoro658"
        ' DB接続
        con.Open()
        Return con
    End Function

End Module

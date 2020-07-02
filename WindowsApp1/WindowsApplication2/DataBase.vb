Imports System.Data.OleDb

Class DataBase

    ' SQLコネクション
    Private _con As OleDbConnection = Nothing
    ' トランザクション・オブジェクト
    Private _trn As OleDbTransaction = Nothing

    Private ReadOnly DB_PATH As String = ComConf.AppDataDir + "\" + AppConf.DBName

    ''' <summary>
    ''' DB接続
    ''' </summary>
    Public Sub Open()

        Try
            '接続文字列
            'mdb
            Dim conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & DB_PATH & ";Persist Security Info=False;" & "Jet OLEDB:Database Password=" & AppConf.DB_PWD & ";"

            _con = New OleDbConnection(conString)

            _con.Open()
        Catch ex As Exception

            'ログ出力
            AppLog.WriteLine("DB Connection Error: " & ex.Message)

            MessageBox.Show(ComConf.FncMsg("E01"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            '強制終了
            Environment.Exit(0)
        End Try
    End Sub

    ''' <summary>
    ''' DB切断
    ''' </summary>
    Public Sub Close()
        Try
            _con.Close()
            _con.Dispose()
        Catch ex As Exception
            Throw New Exception("DB Close Error: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' SQLの実行
    ''' </summary>
    ''' <param name="sql">SQL文</param>
    ''' <returns>データテーブル</returns>
    Public Function ExecuteSql(sql As String) As DataTable
        Dim dt As New DataTable()

        Try
            Dim sqlCommand As New OleDbCommand(sql, _con, _trn)

            Dim adapter As New OleDbDataAdapter(sqlCommand)

            adapter.Fill(dt)
        Catch ex As Exception
            'ログ出力
            AppLog.WriteLine(ex.Message & " " & sql)
            Throw New Exception("ExecuteSql Error: ", ex)
        End Try

        Return dt
    End Function

    ''' <summary>
    ''' 単体インサート専用
    ''' （トランザクション込のため複数テーブル更新時には利用しない）
    ''' </summary>
    ''' <param name="tbl">テーブル名</param>
    ''' <param name="fields">カラムと値の配列</param>
    Public Sub InsertSql(tbl As String, fields As Dictionary(Of String, String))

        Dim sqlCommand As New OleDbCommand()
        Dim trn As OleDbTransaction = _con.BeginTransaction()

        Try
            Dim columns As String = ""
            Dim value As String = ""
            Dim cnt As Integer = 0
            For Each key As String In fields.Keys
                If cnt > 0 Then
                    columns += ","
                    value += ","
                End If
                columns += key
                value += "'" & fields(key) & "'"
                cnt += 1
            Next
            sqlCommand.Connection = _con
            sqlCommand.Transaction = trn
            sqlCommand.CommandText = "INSERT INTO " & tbl & " (" & columns & ") values (" & value & ");"

            sqlCommand.ExecuteNonQuery()


            trn.Commit()
        Catch ex As Exception
            trn.Rollback()
            Throw New Exception("InsertSql Error: " & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 単体アップデート専用
    ''' （トランザクション込のため複数テーブル更新時には利用しない）
    ''' （AND条件のみ複雑なのはExecuteSqlを利用する）
    ''' </summary>
    ''' <param name="tbl">テーブル名</param>
    ''' <param name="fields">カラムと値の配列</param>
    ''' <param name="condition">条件（省略可）</param>
    Public Sub UpdateSql(tbl As String, fields As Dictionary(Of String, String), Optional condition As Dictionary(Of String, String) = Nothing)

        Dim sqlCommand As New OleDbCommand()
        Dim trn As OleDbTransaction = _con.BeginTransaction()

        Try
            Dim buf As String = ""
            Dim cnt As Integer = 0
            For Each key As String In fields.Keys
                If cnt > 0 Then
                    buf += ", "
                End If
                buf += key & " = '" & fields(key) & "'"
                cnt += 1
            Next

            cnt = 0
            Dim strWhere As String = ""
            If condition IsNot Nothing Then
                For Each key As String In condition.Keys
                    If cnt > 0 Then
                        strWhere = " AND "
                    Else
                        strWhere = " WHERE "
                    End If
                    strWhere += key & " = '" & condition(key) & "'"
                    cnt += 1

                Next
            End If

            sqlCommand.Connection = _con
            sqlCommand.Transaction = trn
            sqlCommand.CommandText = "UPDATE " & tbl & " SET " & buf & strWhere & ";"

            sqlCommand.ExecuteNonQuery()

            trn.Commit()
        Catch ex As Exception
            trn.Rollback()
            Throw New Exception("UpdateSql Error: " & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 単体デリート専用
    ''' （トランザクション込のため複数テーブル更新時には利用しない）
    ''' （AND条件のみ複雑なのはExecuteSqlを利用する）
    ''' </summary>
    ''' <param name="tbl">テーブル名</param>
    ''' <param name="condition">条件</param>
    Public Sub DeleteSql(tbl As String, condition As Dictionary(Of String, String))

        Dim sqlCommand As New OleDbCommand()
        Dim trn As OleDbTransaction = _con.BeginTransaction()

        Try
            Dim cnt As Integer = 0
            Dim strWhere As String = ""
            If condition IsNot Nothing Then
                For Each key As String In condition.Keys
                    If cnt > 0 Then
                        strWhere = " AND "
                    Else
                        strWhere = " WHERE "
                    End If
                    '数値かどうかの判断
                    If comFunc.IsNumeric(condition(key)) Then
                        strWhere += key & " = " & condition(key)
                    Else
                        strWhere += key & " = '" & condition(key) & "'"
                    End If
                    cnt += 1

                Next
            End If

            sqlCommand.Connection = _con
            sqlCommand.Transaction = trn
            sqlCommand.CommandText = "DELETE FROM " & tbl & strWhere & ";"

            sqlCommand.ExecuteNonQuery()


            trn.Commit()
        Catch ex As Exception
            trn.Rollback()
            Throw New Exception("DeleteSql Error: " & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' トランザクション開始
    ''' </summary>
    Public Sub Transaction()
        Try
            _trn = _con.BeginTransaction()
        Catch ex As Exception
            Throw New Exception("BeginTransaction Error: ", ex)
        End Try
    End Sub

    ''' <summary>
    ''' コミット
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Commit()
        Try
            If _trn IsNot Nothing Then
                _trn.Commit()
            End If
        Catch ex As Exception
            Throw New Exception("CommitTransaction Error: ", ex)
        Finally
            _trn = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' ロールバック
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Rollback()
        Try
            If _trn IsNot Nothing Then
                _trn.Rollback()
            End If
        Catch ex As Exception
            Throw New Exception("RollbackTransaction Error: ", ex)
        Finally
            _trn = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' デストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub Finalize()
        'Close();
        Try
        Finally
            MyBase.Finalize()
        End Try
    End Sub

End Class

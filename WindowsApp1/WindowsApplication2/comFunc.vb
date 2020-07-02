
'グローバル共通関数
Public NotInheritable Class comFunc
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 単語番号と問題種別から問題を設定する
    ''' 引数の単語番号が空であることのチェックは呼出前に行うこと
    ''' <param name="str単語番号">単語番号</param>
    ''' <param name="int小問種別">小問種別</param>
    ''' <param name="str設問">設問（参照渡し）</param>
    ''' <param name="str解答例">解答例（参照渡し）</param>
    ''' <returns>true:正常に返却 false:0件の場合はfalse</returns>
    ''' </summary>
    Public Shared Function Set問題内容(str単語番号 As String, int小問種別 As Integer, ByRef str設問 As String, ByRef str選択肢 As String, ByRef str解答例 As String) As Boolean
        ' 基礎となる問題の取得
        Dim strBaseSql As String = "SELECT tbl問題.設問, tbl問題.解答例, TRIM(tbl問題.選択肢1) AS 選択肢1, TRIM(tbl問題.選択肢2) AS 選択肢2, TRIM(tbl問題.選択肢3) AS 選択肢3, TRIM(tbl問題.選択肢4) AS 選択肢4, TRIM(tbl問題.選択肢5) AS 選択肢5 "
        strBaseSql += " FROM tbl問題 "
        strBaseSql += $" WHERE tbl問題.単語番号 = {str単語番号} AND tbl問題.問題種別 = {int小問種別} "
        Dim baseDb As New DataBase()
        Dim baseDt As New DataTable()
        Try
            baseDb.Open()
            baseDt = baseDb.ExecuteSql(strBaseSql)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            baseDb.Close()
        End Try

        ' 戻り値
        Dim result As Boolean = False

        ' レコードが存在する場合は取得結果から表示内容を設定
        If baseDt.Rows.Count > 0 Then
            ' 取得結果
            Dim strBase設問 As String = DirectCast(baseDt.Rows(0)("設問"), String)
            Dim strBase解答例 As String = DirectCast(baseDt.Rows(0)("解答例"), String)
            Dim strBase選択肢1 As String = Convert.ToString(baseDt.Rows(0)("選択肢1"))
            Dim strBase選択肢2 As String = Convert.ToString(baseDt.Rows(0)("選択肢2"))
            Dim strBase選択肢3 As String = Convert.ToString(baseDt.Rows(0)("選択肢3"))
            Dim strBase選択肢4 As String = Convert.ToString(baseDt.Rows(0)("選択肢4"))
            Dim strBase選択肢5 As String = Convert.ToString(baseDt.Rows(0)("選択肢5"))

            ' 共通で利用する設定内容
            Dim labelNumber As String() = GetLabelNumber()

            ' 入替種別により実行する処理を分ける
            Select Case ComConf.dic入替種別(int小問種別)
                    ' 選択肢のない通常の問題
                Case 0
                    str設問 = strBase設問
                    str解答例 = strBase解答例
                    Exit Select

                    ' 3択の選択問題
                Case 3
                    ' 3択の入替順のデータ取得
                    Dim strThreeSql As String = $"SELECT * FROM tbl三択入替 WHERE id = {GetRandom(1, 7)}"
                    Dim threeDb As New DataBase()
                    Dim threeDt As New DataTable()
                    Try
                        threeDb.Open()
                        threeDt = threeDb.ExecuteSql(strThreeSql)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    Finally
                        threeDb.Close()
                    End Try
                    ' 取得結果
                    Dim int三択入替順1 As Integer = CByte(threeDt.Rows(0)("入替順1"))
                    Dim int三択入替順2 As Integer = CByte(threeDt.Rows(0)("入替順2"))
                    Dim int三択入替順3 As Integer = CByte(threeDt.Rows(0)("入替順3"))

                    ' 選択肢文字列を作成する
                    Dim str三択設問 As String = ""
                    Dim str三択解答 As String = ""
                    For index選択 As Integer = 1 To 3
                        ' 選択肢のラベル設定
                        str三択設問 = $"{str三択設問}{ComConf.space}{labelNumber(index選択)}"

                        ' 入替順判定
                        If index選択 = int三択入替順1 Then
                            ' 設問に選択肢を設定
                            str三択設問 = $"{str三択設問}{strBase選択肢1}"
                            ' 前提としてmdbに保存されている選択肢1は解答のため解答例をここで作成
                            str三択解答 = labelNumber(index選択)
                        ElseIf index選択 = int三択入替順2 Then
                            ' 設問に選択肢を設定
                            str三択設問 = $"{str三択設問}{strBase選択肢2}"
                        ElseIf index選択 = int三択入替順3 Then
                            ' 設問に選択肢を設定
                            str三択設問 = $"{str三択設問}{strBase選択肢3}"

                        End If
                    Next

                    ' 設定した内容を参照渡しへ反映
                    str設問 = strBase設問
                    str選択肢 = str三択設問
                    str解答例 = str三択解答
                    Exit Select

                    ' 4択の選択問題
                Case 4
                    ' 4択の入替順のデータ取得
                    Dim strFourSql As String = $"SELECT * FROM tbl四択入替 WHERE id = {GetRandom(1, 25)}"
                    Dim fourDb As New DataBase()
                    Dim fourDt As New DataTable()
                    Try
                        fourDb.Open()
                        fourDt = fourDb.ExecuteSql(strFourSql)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    Finally
                        fourDb.Close()
                    End Try
                    ' 取得結果
                    Dim int四択入替順1 As Integer = CByte(fourDt.Rows(0)("入替順1"))
                    Dim int四択入替順2 As Integer = CByte(fourDt.Rows(0)("入替順2"))
                    Dim int四択入替順3 As Integer = CByte(fourDt.Rows(0)("入替順3"))
                    Dim int四択入替順4 As Integer = CByte(fourDt.Rows(0)("入替順4"))

                    ' 選択肢文字列を作成する
                    Dim str四択設問 As String = ""
                    Dim str四択解答 As String = ""
                    For index選択 As Integer = 1 To 4
                        ' 選択肢のラベル設定
                        str四択設問 = $"{str四択設問}{ComConf.space}{labelNumber(index選択)}"

                        ' 入替順判定
                        If index選択 = int四択入替順1 Then
                            ' 設問に選択肢を設定
                            str四択設問 = $"{str四択設問}{strBase選択肢1}"
                            ' 前提としてmdbに保存されている選択肢1は解答のため解答例をここで作成
                            str四択解答 = labelNumber(index選択)
                        ElseIf index選択 = int四択入替順2 Then
                            ' 設問に選択肢を設定
                            str四択設問 = $"{str四択設問}{strBase選択肢2}"
                        ElseIf index選択 = int四択入替順3 Then
                            ' 設問に選択肢を設定
                            str四択設問 = $"{str四択設問}{strBase選択肢3}"
                        ElseIf index選択 = int四択入替順4 Then
                            ' 設問に選択肢を設定
                            str四択設問 = $"{str四択設問}{strBase選択肢4}"

                        End If
                    Next

                    ' 設定した内容を参照渡しへ反映
                    str設問 = strBase設問
                    str選択肢 = str四択設問
                    str解答例 = str四択解答
                    Exit Select

                    ' 5択の選択問題
                Case 5
                    ' 4択の入替順のデータ取得
                    Dim strFiveSql As String = $"SELECT * FROM tbl五択入替 WHERE id = {GetRandom(1, 121)}"
                    Dim fiveDb As New DataBase()
                    Dim fiveDt As New DataTable()
                    Try
                        fiveDb.Open()
                        fiveDt = fiveDb.ExecuteSql(strFiveSql)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    Finally
                        fiveDb.Close()
                    End Try
                    ' 取得結果
                    Dim int五択入替順1 As Integer = CByte(fiveDt.Rows(0)("入替順1"))
                    Dim int五択入替順2 As Integer = CByte(fiveDt.Rows(0)("入替順2"))
                    Dim int五択入替順3 As Integer = CByte(fiveDt.Rows(0)("入替順3"))
                    Dim int五択入替順4 As Integer = CByte(fiveDt.Rows(0)("入替順4"))
                    Dim int五択入替順5 As Integer = CByte(fiveDt.Rows(0)("入替順5"))

                    ' 選択肢文字列を作成する
                    Dim str五択設問 As String = ""
                    Dim str五択解答 As String = ""
                    For index選択 As Integer = 1 To 5
                        ' 選択肢のラベル設定
                        str五択設問 = $"{str五択設問}{ComConf.space}{labelNumber(index選択)}"

                        ' 入替順判定
                        If index選択 = int五択入替順1 Then
                            ' 設問に選択肢を設定
                            str五択設問 = $"{str五択設問}{strBase選択肢1}"
                            ' 前提としてmdbに保存されている選択肢1は解答のため解答例をここで作成
                            str五択解答 = labelNumber(index選択)
                        ElseIf index選択 = int五択入替順2 Then
                            ' 設問に選択肢を設定
                            str五択設問 = $"{str五択設問}{strBase選択肢2}"
                        ElseIf index選択 = int五択入替順3 Then
                            ' 設問に選択肢を設定
                            str五択設問 = $"{str五択設問}{strBase選択肢3}"
                        ElseIf index選択 = int五択入替順4 Then
                            ' 設問に選択肢を設定
                            str五択設問 = $"{str五択設問}{strBase選択肢4}"
                        ElseIf index選択 = int五択入替順5 Then
                            ' 設問に選択肢を設定
                            str五択設問 = $"{str五択設問}{strBase選択肢5}"

                        End If
                    Next

                    ' 設定した内容を参照渡しへ反映
                    str設問 = strBase設問
                    str選択肢 = str五択設問
                    str解答例 = str五択解答
                    Exit Select
                Case Else

                    Exit Select
            End Select

            ' レコードは存在するためtrue
            result = True
        End If

        Return result
    End Function

    ''' <summary>
    ''' 乱数取得
    ''' <param name="min">最小値</param>
    ''' <param name="max">最大値</param>
    ''' <returns>乱数</returns>
    ''' </summary>
    Public Shared Function GetRandom(min As Integer, max As Integer) As Integer
        Dim r As New System.Random()
        ' min以上max未満の乱数を戻す
        Return r.Next(min, max)
    End Function

    ''' <summary>
    ''' 数値から問題ラベル番号を取得する際の変数取得
    ''' <returns>ラベル配列</returns>
    ''' </summary>
    Public Shared Function GetLabelNumber() As String()
        Dim labelNumber As String() = New String(99) {}
        labelNumber(1) = "①"
        labelNumber(2) = "②"
        labelNumber(3) = "③"
        labelNumber(4) = "④"
        labelNumber(5) = "⑤"
        Return labelNumber
    End Function

    ''' <summary>
    ''' シングルクォートをエスケープする
    ''' <param name="str">元の文字列</param>
    ''' <returns>エスケープ後の文字列</returns>
    ''' </summary>
    Public Shared Function escapeStringSQ(str As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(str, "'", "\'")
    End Function

    ''' <summary>
    ''' 文字列の指定した位置から指定した長さを取得する
    ''' </summary>
    ''' <param name="str">文字列</param>
    ''' <param name="start">開始位置</param>
    ''' <param name="len">長さ</param>
    ''' <returns>取得した文字列</returns>
    Public Shared Function Mid(str As String, start As Integer, len As Integer) As String
        If start <= 0 Then
            Throw New ArgumentException("引数'start'は1以上でなければなりません。")
        End If
        If len < 0 Then
            Throw New ArgumentException("引数'len'は0以上でなければなりません。")
        End If
        If str Is Nothing OrElse str.Length < start Then
            Return ""
        End If
        If str.Length < (start + len) Then
            Return str.Substring(start - 1)
        End If
        Return str.Substring(start - 1, len)
    End Function

    ''' <summary>
    ''' 文字列の指定した位置から末尾までを取得する
    ''' </summary>
    ''' <param name="str">文字列</param>
    ''' <param name="start">開始位置</param>
    ''' <returns>取得した文字列</returns>
    Public Shared Function Mid(str As String, start As Integer) As String
        Return Mid(str, start, str.Length)
    End Function

    ''' <summary>
    ''' 文字列の先頭から指定した長さの文字列を取得する
    ''' </summary>
    ''' <param name="str">文字列</param>
    ''' <param name="len">長さ</param>
    ''' <returns>取得した文字列</returns>
    Public Shared Function Left(str As String, len As Integer) As String
        If len < 0 Then
            Throw New ArgumentException("引数'len'は0以上でなければなりません。")
        End If
        If str Is Nothing Then
            Return ""
        End If
        If str.Length <= len Then
            Return str
        End If
        Return str.Substring(0, len)
    End Function

    ''' <summary>
    ''' 文字列の末尾から指定した長さの文字列を取得する
    ''' </summary>
    ''' <param name="str">文字列</param>
    ''' <param name="len">長さ</param>
    ''' <returns>取得した文字列</returns>
    Public Shared Function Right(str As String, len As Integer) As String
        If len < 0 Then
            Throw New ArgumentException("引数'len'は0以上でなければなりません。")
        End If
        If str Is Nothing Then
            Return ""
        End If
        If str.Length <= len Then
            Return str
        End If
        Return str.Substring(str.Length - len, len)
    End Function

    ''' <summary>
    ''' 文字列が数値であるかどうかを返す
    ''' </summary>
    ''' <param name="stTarget">検査対象となる文字列</param>
    ''' <returns>指定した文字列が数値であれば true  それ以外は false</returns>
    Public Shared Function IsNumeric(stTarget As String) As Boolean
        Dim dNullable As Double

        Return Double.TryParse(stTarget, System.Globalization.NumberStyles.Any, Nothing, dNullable)
    End Function

    ''' <summary>
    ''' 入力したキーボードのキー数値であるかどうかを返す
    ''' </summary>
    ''' <param name="e">検査対象となるキー。</param>
    ''' <param name="dotAllow">ドット(.)を許可するか否か</param>
    ''' <returns>指定したキーが数値であれば true  それ以外は false</returns>
    Public Shared Function IsNumericKeyPress(e As KeyPressEventArgs, Optional dotAllow As Boolean = False) As Boolean
        Dim result As Boolean = True
        ' 許可文字列
        Dim allowStr As String = "0123456789" & vbBack
        ' 第2引数がtrueの場合はドット(.)を追加
        If dotAllow Then
            allowStr += "."
        End If
        ' 許可した文字列内に存在しない場合はfalse
        If Not allowStr.Contains(e.KeyChar) Then
            result = False
        End If
        Return result
    End Function

    ''' <summary>
    ''' 入力したキーボードのキー数値、ハイフン、カンマであるかどうかを返す
    ''' </summary>
    ''' <param name="e">検査対象となるキー。</param>
    ''' <returns>指定したキーが数値であれば true  それ以外は false</returns>
    Public Shared Function IsNumericHyphenKeyPress(e As KeyPressEventArgs) As Boolean
        Dim result As Boolean = True
        ' 許可文字列
        Dim allowStr As String = "0123456789" & vbBack
        allowStr += "-,"
        ' 許可した文字列内に存在しない場合はfalse
        If Not allowStr.Contains(e.KeyChar) Then
            result = False
        End If
        Return result
    End Function

    ''' <summary>
    ''' 入力された一部の記号を置換して返す
    ''' KeyPressイベントではペーストに対応できないためこちらで補完
    ''' </summary>
    ''' <param name="str">置換対象の文字列。</param>
    ''' <returns>置換後の文字列</returns>
    Public Shared Function ReplaceSymbol(str As String) As String
        ' 不許可文字列(^:,/'|*<>?\")
        Dim notAllowStrArr As String() = {"^", ":", ",", "/", "'", "|",
                "*", "<", ">", "?", "\", """"}
        For Each notAllowStr As String In notAllowStrArr
            str = str.Replace(notAllowStr, "")
        Next
        Return str
    End Function

    ''' <summary>
    ''' ファイル名として使えない文字を削除する
    ''' </summary>
    ''' <param name="str">置換対象の文字列。</param>
    ''' <returns>置換後の文字列</returns>
    Public Shared Function ファイル名禁止文字削除(str As String) As String
        ' 不許可文字列(^:,/'|*<>?\")
        Dim notAllowStrArr As String() = {":", "/", "|", "*", "<", ">", "?", "\", """"}
        For Each notAllowStr As String In notAllowStrArr
            str = str.Replace(notAllowStr, "")
        Next
        Return str
    End Function

    ''' <summary>
    ''' 数字文字列を整数形式に置き換える
    ''' </summary>
    ''' <param name="strParam">検査対象となる文字列。</param>
    ''' <returns>指定した文字列が数値であれば true  それ以外は false</returns>
    Public Shared Function repInteger(strParam As String) As String
        Dim repInt As Integer

        '整数数字に変換
        If Not String.IsNullOrEmpty(strParam) Then
            repInt = Integer.Parse(strParam)
            strParam = repInt.ToString()
        End If
        Return strParam
    End Function

    ''' <summary>
    ''' カンマ区切りのチェック
    ''' </summary>
    ''' <param name="str">検査対象となる文字列。</param>
    ''' <returns>チェック後の文字列</returns>
    Public Shared Function RepCommaString(str As String) As String
        Dim rtn As String = ""
        Dim cnt As Integer = 0

        ' カンマ区切りで分割して配列に格納する
        Dim strArray As String() = str.Split(","c)

        ' 配列ごとの是正（空文字またはハイフンのみは除外する）
        For Each data As String In strArray
            If data = "" Then
                Continue For
            End If
            If Not Text.RegularExpressions.Regex.IsMatch(data, "^\d+$") Then
                If Not Text.RegularExpressions.Regex.IsMatch(data, "^[0-9]+-[0-9]+$") Then
                    If Not Text.RegularExpressions.Regex.IsMatch(data, "^-[0-9]+$") Then
                        If Not Text.RegularExpressions.Regex.IsMatch(data, "^[0-9]+-$") Then
                            Continue For
                        End If
                    End If
                End If
            End If
            If cnt > 0 Then
                rtn += ","
            End If
            rtn += data
            cnt += 1
        Next
        Return rtn
    End Function

    'バリアント→文字列変換
    Public Shared Function VarToStr(s As Object) As String
        If IsDBNull(s) Then
            Return ""
        End If
        Try
            Return CStr(s)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ' 文字列のShift-JISバイト数を取得する。
    Public Shared Function LenB(str As String) As Integer
        Dim result As Integer
        Dim s_jis As Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        result = s_jis.GetByteCount(str)
        Return result
    End Function

    ' DBエラーメッセージ出力
    Public Shared Sub outDbErr(ex As Exception)
        AppLog.WriteLine(ex.Message)
        MessageBox.Show(ComConf.FncMsg("E02") & " " & ex.Message & " " & ex.InnerException.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ' 想定外エラーメッセージ出力
    Public Shared Sub outErr(ex As Exception, title As String)
        AppLog.WriteLine(ex.Message)
        MessageBox.Show(ComConf.FncMsg("E99", title), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ' 文字列をシングルコーテーションで括る 
    Public Shared Function QuotedStr(str As String)
        ' 文字列にシングルコーテーションが含まれている場合、2つにする
        Return "'" & str.Replace("'", "''") & "'"
    End Function

    ' INIファイル
    Friend Shared Function createIni() As IniFile
        Dim settingPath As String = ComConf.AppDataDir & "\setting.ini"
        Dim ini As IniFile = New IniFile(settingPath)
        Return ini
    End Function

End Class



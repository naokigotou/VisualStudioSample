'
Imports System.IO


Class TextOutput
    Private FILE_PATH As String = ComConf.set_OutputDir + "\" + ComConf.set_FileName
    Private strText As String = ""

    Sub New(fileName As String)
        ' ファイル名の設定
        FILE_PATH = ComConf.set_OutputDir + "\" + fileName
    End Sub

    '出力内容
    ''' <summary>
    ''' 起動（特に何もせず）
    ''' </summary>
    Public Sub Open()
        ' ログ出力
        AppLog.WriteLine("テキスト出力開始")

        Try
            ' 一応初期化
            strText = ""
        Catch ex As Exception
            ' ログ出力
            AppLog.WriteLine(ex.Message)
        End Try
    End Sub


    ''' <summary>
    ''' 終了
    ''' </summary>
    Public Sub Close(Optional view As Boolean = False)
        Try
            ' 名前を付けて保存（同じファイル名は_nを付加）
            Dim fileName As String = FILE_PATH
            Dim fileName_bk As String = fileName
            Dim cnt As Integer = 1
            Dim flg As Boolean = False
            While flg = False
                If File.Exists(fileName & ".txt") Then
                    fileName = fileName_bk & "_" & cnt
                    cnt += 1
                Else
                    flg = True
                End If
            End While

            'ファイルが無ければ作成し書き込む
            Using sw As New StreamWriter(fileName & ".txt", True)
                sw.WriteLine(strText)
            End Using

            ' ログ出力
            AppLog.WriteLine("テキスト出力済")

            ' 作成後の表示
            If view Then
                System.Diagnostics.Process.Start(fileName & ".txt")
            End If
        Catch ex As Exception
            ' ログ出力
            AppLog.WriteLine(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 文書の末尾にテキストを追加する.
    ''' </summary>
    ''' <param name="text">文字列</param>
    Public Sub addText(text As String)
        strText += text & Environment.NewLine
    End Sub

    ''' <summary>
    ''' 改行追加
    ''' </summary>
    Public Sub addNewline()
        strText += Environment.NewLine
    End Sub

    ''' <summary>
    ''' ヘッダーを作成する.
    ''' </summary>
    ''' <param name="cnt">回数（省略可）</param>
    ''' <param name="gakunen">学年（省略可）</param>
    ''' <param name="kumi">組（省略可）</param>
    Public Sub addHeader(Optional cnt As String = "　", Optional gakunen As String = "   ",
                         Optional kumi As String = "   ", Optional biko As String = "")
        ' 空文字対処
        If cnt = "" Then
            cnt = "　"
        End If
        If gakunen = "" Then
            gakunen = "　"
        End If
        If kumi = "" Then
            kumi = "　"
        End If

        ' 回、月、日
        strText += "月" & Space(4) & "日" & Environment.NewLine

        ' タイトル
        strText += ComConf.set_FileName & biko & Environment.NewLine

        ' 年、組、名前、罫線
        strText += gakunen & "年" & kumi & "組" & Space(2) & "番" & Space(2) & "氏名" & Space(30) & "点" & Environment.NewLine

        ' 罫線下のスペース
        strText += Environment.NewLine
    End Sub

    ''' <summary>
    ''' 解答例ヘッダーを作成する.
    ''' </summary>
    ''' <param name="cnt">回数（省略可）</param>
    ''' <param name="gakunen">学年（省略可）</param>
    ''' <param name="kumi">組（省略可）</param>
    Public Sub addHeaderExmp(Optional cnt As String = "　", Optional gakunen As String = "   ",
                             Optional kumi As String = "   ", Optional biko As String = "")
        ' 空文字対処
        If cnt = "" Then
            cnt = "　"
        End If
        If gakunen = "" Then
            gakunen = "　"
        End If
        If kumi = "" Then
            kumi = "　"
        End If

        ' 仕切り
        strText += Environment.NewLine & Hyphen(50) & Environment.NewLine

        ' 回、月、日
        strText += "月" & Space(4) & "日" & Environment.NewLine

        ' タイトル
        strText += ComConf.set_FileName & biko & " 解答例" & Environment.NewLine

        ' 年、組、名前、罫線
        strText += gakunen & "年" & kumi & "組" & Environment.NewLine

        ' 罫線下のスペース
        strText += Environment.NewLine
    End Sub


    ''' <summary>
    ''' 問題文と解答欄
    ''' </summary>
    ''' <param name="que">問題文</param>
    ''' <param name="ans">解答文（省略可）</param>
    ''' <param name="choice">選択肢（省略可）</param>
    Public Sub addQuestion(que As String, Optional ans As String = "", Optional choice As String = "")

        ' 問題文
        strText += que & Environment.NewLine
        ' 選択肢
        If choice <> "" Then
            strText += choice & Environment.NewLine
        End If

        ' 解答欄
        strText += Space(65) & ans & Environment.NewLine
        strText += Space(60) & Hyphen(15) & Environment.NewLine

    End Sub


    ''' <summary>
    ''' 指定数字の全角ハイフン文字列を返す
    ''' </summary>
    ''' <param name="number">指定数字</param>
    Private Function Hyphen(number As Integer) As String
        Dim buf As String = ""
        For i As Integer = 0 To number - 1
            buf += "―"
        Next
        Return buf
    End Function


End Class


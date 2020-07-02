Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Module utils

    'フォルダがなければ作成する
    Sub MkDir(ByVal path As String)
        If Directory.Exists(path) = False Then
            Directory.CreateDirectory(path)
        End If
    End Sub

    ' ファイルを開くダイアログ
    Public Function OpenFileDialog(ByRef filePath As String, ByVal iniDir As String, ByVal ext As String) As Boolean
        Dim ofd As New OpenFileDialog With {
            .FileName = "",
            .InitialDirectory = iniDir,
            .Filter = ext,
            .FilterIndex = 1,
            .Title = "ファイルを選択してください",
            .RestoreDirectory = True,
            .CheckFileExists = True,
            .CheckPathExists = True
        }
        If ofd.ShowDialog() = DialogResult.OK Then
            filePath = ofd.FileName
            Return True
        Else
            Return False
        End If
    End Function

    ' EXEのパスの取得
    Public Function GetAppPath() As String
        Return Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly().Location)
    End Function


    ' ブランク検査
    Public Function IsBlank(s As Object) As Decimal
        Return IsDBNull(s) OrElse s = ""
    End Function


    ' 数値かチェック
    Public Function IsUnsignedIntegers(val As String) As Boolean
        Return New Regex("^[0-9]+$").IsMatch(val)
    End Function

    ' 整数かチェック 
    Public Function IsInteger(val As String) As Boolean
        Return New Regex("^[+-]?\d+$").IsMatch(val)
    End Function

    ' 数値かチェック（小数点可）
    Public Function IsDecimal(val As String) As Boolean
        Return IsNumeric(val) And IsInteger(val.Replace(".", ""))
    End Function

    ' コンソール出力
    Public Sub WriteLog(s As String)
        Dim tm As String = Format(Now(), "HHmmss")
        Console.WriteLine(tm + " " + s)
    End Sub


    'バリアント→文字列 変換
    Public Function VarToStr(s As Object) As String
        If IsDBNull(s) Then
            Return ""
        End If
        Try
            Return CStr(s)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    '文字列→整数 変換
    Public Function StrToInt(s As String) As Integer
        If s = "" Then
            Return 0
        End If
        Try
            Return CInt(s)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ' 文字列をシングルコーテーションで括る 
    Public Function QuotedStr(str As String)
        ' 文字列にシングルコーテーションが含まれている場合、2つにする
        Return "'" & str.Replace("'", "''") & "'"
    End Function


    '' 日時文字列取得
    'Public Function GetNowStr() As String
    '    Return Now.ToString(DATETIME_FORMART)
    'End Function

End Module

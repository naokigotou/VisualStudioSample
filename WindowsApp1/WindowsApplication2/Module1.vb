Module Module1

    Function QuotedStr(str As String)
        Return "'" & str.Replace("'", "''") & "'"
    End Function

    ''' <summary>
    ''' 特殊文字の強制置換
    ''' <param name="args">置換前文字列</param>
    ''' <returns>置換後文字列</returns>
    ''' </summary>
    Public Function fncSpCharConvert(args As String) As String
        args = args.Replace(",", "")
        args = args.Replace("\", "")
        args = args.Replace(":", "")
        args = args.Replace("?", "")
        args = args.Replace("<", "")
        args = args.Replace(">", "")
        args = args.Replace("/", "")
        args = args.Replace("|", "")
        args = args.Replace("'", "")
        args = args.Replace("'", "")
        args = args.Replace("^", "")
        args = args.Replace("*", "")
        args = args.Replace("""", "")
        Return args
    End Function


    ''' <summary>
    ''' 入力された一部の記号を置換して返す
    ''' KeyPressイベントではペーストに対応できないためこちらで補完
    ''' </summary>
    ''' <param name="str">置換対象の文字列。</param>
    ''' <returns>置換後の文字列</returns>
    Public Function ReplaceSymbol(str As String) As String
        ' 不許可文字列(^:,/'|*<>?\")
        Dim notAllowStrArr As String() = {"^", ":", ",", "/", "'", "|", "*", "<", ">", "?", "\", """"}
        For Each notAllowStr As String In notAllowStrArr
            str = str.Replace(notAllowStr, "")
        Next
        Return str
    End Function
End Module

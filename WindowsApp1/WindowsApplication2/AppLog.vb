Imports System.IO

''' <summary>
''' アプリケーション独自デバッグ用ログクラス
''' </summary>
Class AppLog

    ''' <summary>
    ''' 書き込み
    ''' </summary>
    ''' <param name="value">書き込む値</param>
    Public Shared Sub WriteLine(value As Object)
        ' クラス名とメソッド名の取得
        Dim callerFrame As New StackFrame(1)
        Dim className As String = callerFrame.GetMethod().ReflectedType.Name
        Dim methodName As String = callerFrame.GetMethod().Name

        '日付＋内容
        Dim logMessage As String = DateTimeOffset.Now.ToString("yyyy/MM/dd HH:mm:ss") & $" [{className}][{methodName}] " & Convert.ToString(value)

        'ファイルフルパス
        Dim FilePath As String = ComConf.AppDataDir & "\AppLog.log"

        Try
            'ファイルが無ければ作成し書き込む
            Using sw As New StreamWriter(FilePath, True)
                sw.WriteLine(logMessage)
            End Using
        Catch generatedExceptionName As Exception
            MessageBox.Show("ログファイルは別プロセスが使用中か書き込む権限がありません。")
        End Try
    End Sub



End Class

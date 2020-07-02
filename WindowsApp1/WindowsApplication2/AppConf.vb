
' アプリケーション設定
Public NotInheritable Class AppConf
    Private Sub New()
    End Sub

    Public Const AppName As String = "システム英単語〈５訂版〉テスト作成システム"
    Public Const AppNameEx As String = "_manual"
    Public Const AppVer As String = "0.9.0"           'SetupのVersionと合わせること
    Public Const PrtName As String = "Ver.1089.10"    '設問データVer.
    Public Const DBName As String = "EKaitei.mdb"
    Public Const DB_PWD As String = "SATTEKaitei2017"
    Public Const HelpFileName As String = "help.chm"
    Public Shared systemID As Integer = ComConf.SYSTEM_ID_BASE  ' Base版

    ' ログインフォーム起動のダミー処理
    Public Shared Sub callLogin()
    End Sub

End Class


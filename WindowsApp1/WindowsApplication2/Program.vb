Imports System.Threading
Imports System.IO


''' <summary>
''' アプリケーションのメイン エントリ ポイントです。
''' </summary>
Module Program
    ''' <summary>
    ''' Program entry point.
    ''' </summary>
    <STAThread>
    Public Sub Main()

        Application.EnableVisualStyles()
        ' .net 1互換
        Application.SetCompatibleTextRenderingDefault(False)

        ' ログインフォーム起動
        AppConf.callLogin()

        'スプラッシュ画面表示
        Dim sf As New SplashWindow()
        sf.Show()
        sf.Refresh()

        '-------------------------------------------------
        ' 起動前の準備は以下で実行する
        '-------------------------------------------------

        'Appフォルダ　無ければ作成（C:\Users\UserName\AppData\Roaming\駿台文庫\アプリ名）
        If Not Directory.Exists(ComConf.AppDataDir) Then
            Directory.CreateDirectory(ComConf.AppDataDir)
        End If

        '環境設定ファイルを読み込む、無ければ作成する
        Dim settingPath As String = ComConf.AppDataDir + "\setting.ini"
        Dim ini As New IniFile(settingPath)

        If File.Exists(settingPath) Then
            ComConf.set_Software = ini("LocalSetting", "Software")
            ComConf.set_PageSize = ini("LocalSetting", "PageSize")
            ComConf.set_PageMargin = ini("LocalSetting", "PageMargin")
            ComConf.set_FileName = ini("LocalSetting", "FileName")
            ComConf.set_OutputDir = ini("LocalSetting", "OutputDir")
            ComConf.set_OutputView = ini("LocalSetting", "OutputView") = CStr(True)
            ComConf.set_WordOrderRandom = ini.GetValue("LocalSetting", "WordOrderRandom", CStr(True)) = CStr(True)
            ComConf.set_DisplayHint = ini.GetValue("LocalSetting", "DisplayHint", CStr(True)) = CStr(True)
        Else
            '標準ファイルが無い場合、規定値を設定する
            ComConf.set_Software = ComConf.Initial_Software
            ComConf.set_PageSize = ComConf.Initial_PageSize
            ComConf.set_PageMargin = ComConf.Initial_PageMargin
            ComConf.set_FileName = ComConf.Initial_FileName
            ComConf.set_OutputDir = ComConf.Initial_OutputDir
            ComConf.set_OutputView = ComConf.Initial_OutputView
            ComConf.set_DisplayHint = ComConf.Initial_DisplayHint
            ComConf.set_WordOrderRandom = ComConf.Initial_WordOrderRandom

            ini("LocalSetting", "Software") = ComConf.Initial_Software
            ini("LocalSetting", "PageSize") = ComConf.Initial_PageSize
            ini("LocalSetting", "PageMargin") = ComConf.Initial_PageMargin
            ini("LocalSetting", "FileName") = ComConf.Initial_FileName
            ini("LocalSetting", "OutputDir") = ComConf.Initial_OutputDir
            ini("LocalSetting", "OutputView") = ComConf.Initial_OutputView.ToString()
            ini("LocalSetting", "WordOrderRandom") = ComConf.Initial_WordOrderRandom.ToString()
            ini("LocalSetting", "DisplayHint") = ComConf.Initial_DisplayHint.ToString()
        End If

        'デフォルト出力先ディレクトリ　無ければ作成する
        If Not Directory.Exists(ComConf.Initial_OutputDir) Then
            Directory.CreateDirectory(ComConf.Initial_OutputDir)
        End If

        'DBの作成
        If Not File.Exists(ComConf.AppDataDir + "\" + AppConf.DBName) Then

            'リソースから複製
            Dim dbFile As Byte() = DirectCast(My.Resources.ResourceManager.GetObject(AppConf.DBName), Byte())
            File.WriteAllBytes(ComConf.AppDataDir + "\" + AppConf.DBName, dbFile)

            '隠し属性を追加する
            Dim fi As New FileInfo(ComConf.AppDataDir + "\" + AppConf.DBName)
            fi.Attributes = fi.Attributes Or FileAttributes.Hidden
        End If

        'ヘルプファイルの作成
        If Not File.Exists(ComConf.AppDataDir + "\" + AppConf.HelpFileName) Then
            'リソースから複製
            ' Dim helpFile As Byte() = My.Resources.help
            ' File.WriteAllBytes(ComConf.AppDataDir + "\" + AppConf.HelpFileName, helpFile)
        End If

        ' スプラッシュ表示 0.5秒止める 
        Thread.Sleep(500)

        'スプラッシュ終了
        sf.Close()

        'メインフォーム起動
        ' Application.Run(New F00_MainForm())

    End Sub

    End Module



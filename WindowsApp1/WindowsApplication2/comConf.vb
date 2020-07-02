
'グローバル共通変数、定数
Public NotInheritable Class ComConf
    Private Sub New()
    End Sub

    ' 定数  
    Public Const SYSTEM_ID_BASE = 1   ' BASE版 
    Public Const SYSTEM_ID_BASIC = 2  ' BASIC版
    Public Const PAGE_MARGIN_NARROW = "やや狭い"
    Public Shared ReadOnly COLOR_ERR As Color = Color.Crimson  ' エラー時の背景色  
    Public Shared ReadOnly COLOR_WARN As Color = Color.Yellow  ' 既出行の背景色  

    ' ページ設定 余白 （やや狭い）  
    Public Const PAGE_MARGIN_TOP_NARROW = 25.4F
    Public Const PAGE_MARGIN_BOTTOM_NARROW = 25.4F
    Public Const PAGE_MARGIN_LEFT_NARROW = 19.05F
    Public Const PAGE_MARGIN_RIGHT_NARROW = 19.05F
    ' ページ設定 余白 （通常）
    Public Const PAGE_MARGIN_TOP_NORMAL = 35.01F
    Public Const PAGE_MARGIN_BOTTOM_NORMAL = 30
    Public Const PAGE_MARGIN_LEFT_NORMAL = 30
    Public Const PAGE_MARGIN_RIGHT_NORMAL = 30

    ' DBファイルなどのフォルダ
    Public Shared AppDataDir As String = "C:\Users\mao\Desktop\駿台文庫"

    ' 初期設定の内容
    Public Const Initial_Software As String = "Docx"
    Public Const Initial_PageSize As String = "A4"
    Public Const Initial_PageMargin As String = PAGE_MARGIN_NARROW
    Public Const Initial_FileName As String = "システム英単語〈５訂版〉"
    Public Shared Initial_OutputDir As String = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\駿台文庫\" + AppConf.AppName + AppConf.AppNameEx
    Public Shared Initial_OutputView As Boolean = False
    Public Const Initial_WordOrderRandom As Boolean = True
    Public Const Initial_DisplayHint As Boolean = True


    ' 設定値の内容（ローカルSettingから）
    Public Shared set_Software As String
    Public Shared set_PageSize As String
    Public Shared set_PageMargin As String
    Public Shared set_FileName As String
    Public Shared set_OutputDir As String
    Public Shared set_OutputView As Boolean
    Public Shared set_WordOrderRandom As Boolean
    Public Shared set_DisplayHint As Boolean

    ' システム値
    Public Const max小問数 As Integer = 100
    Public Const max問題数 As Integer = 100
    Public Const space As String = "   "

    ' 各tab毎のDataGridViewへの反映前に取得結果を格納して作業する変数
    Public Shared tabWork単語番号 As String(,) = New String(max小問数 - 1, max問題数 - 1) {}
    Public Shared tabWork設問 As String(,) = New String(max小問数 - 1, max問題数 - 1) {}
    Public Shared tabWork選択肢 As String(,) = New String(max小問数 - 1, max問題数 - 1) {}
    Public Shared tabWork解答例 As String(,) = New String(max小問数 - 1, max問題数 - 1) {}

    ' 一覧で選択された小問の数
    Public Shared 小問数 As Integer = 0

    ' 各tab毎の現在の項目値（indexではなく実数値）
    Public Shared tab小問種別 As Integer() = New Integer(max小問数 - 1) {}
    Public Shared tab設問数 As Integer() = New Integer(max小問数 - 1) {}

    ' 各tab毎のForm定義
    Public Shared tabFormDataGridView As DataGridView() = New DataGridView(max小問数 - 1) {}
    Public Shared tabFormComboBox As ComboBox() = New ComboBox(max小問数 - 1) {}
    Public Shared tabFormNumericUpDown As NumericUpDown() = New NumericUpDown(max小問数 - 1) {}
    Public Shared tabFormCheckbox As CheckBox() = New CheckBox(max小問数 - 1) {}

    ' テーブルに保持されている問題種別毎の入替種別
    Public Shared dic入替種別 As New Dictionary(Of Integer, Integer)()

    ' テーブルに保持されている設問文略称  
    Public Shared lst設問区分 As New List(Of String)(New String() {"キャンセル"})

    ' 一覧の設問毎の背景色  
    Public Shared lst設問色 As New List(Of Color)(New Color() {
        Color.White,
        Color.LightSalmon,
        Color.Khaki,
        Color.PaleGreen,
        Color.Aquamarine,
        Color.LightSkyBlue,
        Color.Plum,
        Color.Pink,
        Color.LightGray})

    ''' <summary>
    '''メッセージ関数（共通メッセージはここで定義）
    '''数字3桁（通常、想定エラー）、Exx（システム異常系）
    ''' <param name="argID">メッセージID</param>
    ''' <param name="argSub1">サブメッセージ（省略可）</param>
    ''' <returns>出力メッセージ</returns>
    ''' </summary>
    Public Shared Function FncMsg(argID As String, Optional argSub1 As String = "") As String
        Select Case argID
            Case "001"
                Return "指定した単語番号は存在しません。"
            Case "002"
                Return "問題を保存しました。"
            Case "003"
                Return "更新しました。"
            Case "004"
                Return "削除しました。"
            Case "005"
                Return "選択された履歴を削除します。よろしいですか？"
            Case "006"
                Return "選択された履歴を呼び出します。よろしいですか？"
            Case "007"
                Return "設問数は全小問で100までを指定してください。"
            Case "008"
                Return "学年、組を入力してください。"
            Case "009"
                Return "選択された問題種別に対して存在しない単語番号があります。" & Environment.NewLine & "そのため削除される行があります。処理を続行しますか？"
            Case "010"
                Return "設問が1つも設定されていません。"
            Case "012"
                Return "エラーの状態で問題は保存できません。"
            Case "013"
                Return "単語番号が重複して選択されています。処理を続行しますか？"
            Case "014"
                Return "保存済の年組を選択してください。"
            Case "015"
                Return "履歴を呼び出しました。"
            Case "016"
                Return "問題を作成しました。"
            Case "017"
                Return "問題を出力しました。"
            Case "018"
                Return "MS-Wordが起動できません。テキスト形式で問題を作成します。"
            Case "019"
                Return $"エラーの状態で問題を{argSub1}できません。"
            Case "020"
                Return "全ての設問をクリアします。よろしいですか？"
            Case "023"
                Return "該当する条件では問題が作成できませんでした。"
            Case "101"
                Return "指定した設問は存在しません。"
            Case "102"
                Return "設問が重複して選択されています。"
            Case "103"
                Return "検索条件が入力可能になりました。 "
            Case "104"
                Return "1件のみ選択してください。"
            Case "105"
                Return "検索条件がクリアされました。 "
            Case "106"
                Return "一括チェックが選択されていません。 "
            Case "107"
                Return "組は半角8桁、全角4桁まで入力可能です。"
            Case "108"
                Return "設問区分を選択してください。"
            Case "E01"
                Return "データベースが開けません。" & vbCr & vbLf & "アプリケーションを終了します。"
            Case "E02"
                Return "データベースの読み込みができませんでした。"
            Case "E03"
                Return "MS-Wordが開けませんでした。"
            Case "E04"
                Return "ログインIDまたはパスワードが違います。"
            Case "E05"
                Return "ログインIDとパスワードを入力してください。"
            Case "E10"
                Return "MS-Wordに保存できませんでした。"
            Case "E99"
                Return $"{argSub1}処理中に、エラーが発生しました。"
            Case Else
                Return "想定外のエラーです。"
        End Select
    End Function
End Class


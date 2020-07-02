Public Class Form2

    Private dt As New DataTable

    Public iwashi As String = "iwashi"

    Sub DataGridTest()
        Dim bufdate As Date
        Dim rand As New Random(1)

        'Column生成
        Dim colChk As New DataColumn("ColChk", GetType(Boolean))
        dt.Columns.Add(colChk)

        Dim colAccess As New DataColumn("ColAccess", GetType(Integer))
        dt.Columns.Add(colAccess)

        Dim colTangoAs As New DataColumn("ColTango", GetType(String))
        dt.Columns.Add(colTangoAs)

        Dim colPrintOrder As New DataColumn("PrintOrder", GetType(Integer))
        dt.Columns.Add(colPrintOrder)

        Dim colColumn1 As New DataColumn("Column1", GetType(String))
        dt.Columns.Add(colColumn1)

        Dim colComboBox As New DataColumn("ComboBox", GetType(String))
        dt.Columns.Add(colComboBox)

        '今日
        bufdate = Now.Date()
        'TestData生成
        For i = 0 To 5
            Dim row As DataRow = dt.NewRow()
            row("ColAccess") = rand.Next(1, 8) 'ランダム
            row("ColTango") = "mao" + CStr(i)
            dt.Rows.Add(row)
        Next
        'Me.dt.Select("ColAccess = 52")

        'データグリッドへ表示
        dgv_履歴一覧.DataSource = dt

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        iwashi = "鰯"

        DataGridTest()

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each r As DataGridViewRow In dgv_履歴一覧.SelectedRows
            Dim val = r.Cells("ColTango").Value
            Debug.Print(CStr(val))
        Next
    End Sub

    Function IsSelectRow(grid As DataGridView)
        Dim result As Boolean = False
        For Each r As DataGridViewRow In grid.SelectedRows
            Return True
        Next
        Return False
    End Function

    Private Sub dgv_履歴一覧_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_履歴一覧.SelectionChanged

        Button2.Enabled = IsSelectRow(dgv_履歴一覧)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim path = TextBox1.Text

        OpenFolderDialog(path)

        TextBox1.Text = path

    End Sub

    ' ファイルを開くダイアログ
    Public Function OpenFileDialog(ByRef filePath As String, ByVal iniDir As String, ByVal ext As String) As Boolean
        ' If iniDir
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

    ' フォルダを開くダイアログ
    Public Function OpenFolderDialog(ByRef path As String) As Boolean
        If path = "" Then
            ' EXEのパス
            path = utils.GetAppPath
        End If
        Dim fbd As New FolderBrowserDialog
        '上部に表示する説明テキスト
        fbd.Description = "フォルダを指定してください。"
        'ルートフォルダ Desktop
        fbd.RootFolder = Environment.SpecialFolder.Desktop
        '最初に選択するフォルダ
        fbd.SelectedPath = path
        'ユーザーが新しいフォルダを作成できるようにする
        fbd.ShowNewFolderButton = True
        If fbd.ShowDialog(Me) = DialogResult.OK Then
            path = fbd.SelectedPath
            Return True
        Else
            Return False
        End If
    End Function


End Class
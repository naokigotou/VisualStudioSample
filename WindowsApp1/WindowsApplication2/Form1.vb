Public Class Form1
    Private dataGridViewComboBox As DataGridViewComboBoxEditingControl = Nothing

    Private dt As New DataTable

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
        DataGridView1.DataSource = dt

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        DataGridTest() ' 

    End Sub

    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        '表示されているコントロールがDataGridViewComboBoxEditingControlか調べる
        If TypeOf e.Control Is DataGridViewComboBoxEditingControl Then
            Dim dgv As DataGridView = CType(sender, DataGridView)
            '該当する列か調べる
            If dgv.CurrentCell.OwningColumn.Name = "ComboBox" Then
                '編集のために表示されているコントロールを取得
                Me.dataGridViewComboBox = CType(e.Control, DataGridViewComboBoxEditingControl)
                'SelectedIndexChangedイベントハンドラを追加
                AddHandler Me.dataGridViewComboBox.SelectedIndexChanged, AddressOf dataGridViewComboBox_SelectedIndexChanged
            End If
        End If
    End Sub

    'CellEndEditイベントハンドラ
    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        'SelectedIndexChangedイベントハンドラを削除
        If Not (Me.dataGridViewComboBox Is Nothing) Then
            RemoveHandler Me.dataGridViewComboBox.SelectedIndexChanged, AddressOf dataGridViewComboBox_SelectedIndexChanged
            Me.dataGridViewComboBox = Nothing
        End If
    End Sub

    'DataGridViewに表示されているコンボボックスの SelectedIndexChangedイベントハンドラ
    Private Sub dataGridViewComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        '選択されたアイテムを表示
        Dim cb As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
        Console.WriteLine(cb.SelectedItem)

        DataGridView1.CurrentRow.Cells("ColTango").Value = cb.SelectedItem

        'If Not (Me.dataGridViewComboBox Is Nothing) Then
        '    RemoveHandler Me.dataGridViewComboBox.SelectedIndexChanged, AddressOf dataGridViewComboBox_SelectedIndexChanged
        '    Me.dataGridViewComboBox = Nothing
        'End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

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

    Private Sub print(s As String)
        Me.TextBox1.AppendText(s + vbCrLf)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

        If Me.CheckBox1.Checked Then
            Me.DataGridView1.EndEdit()
            print("BeginEdit")
        End If

        print("---")
        For Each row In dt.Rows
            print(row("ColTango"))
        Next

    End Sub
End Class

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
        DataGridView1.DataSource = dt

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        DataGridTest()

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

    Sub delEvent()
        'SelectedIndexChangedイベントハンドラを削除
        If Not (Me.dataGridViewComboBox Is Nothing) Then
            RemoveHandler Me.dataGridViewComboBox.SelectedIndexChanged, AddressOf dataGridViewComboBox_SelectedIndexChanged
            ' Me.dataGridViewComboBox = Nothing
        End If
    End Sub


    'CellEndEditイベントハンドラ
    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        delEvent()
    End Sub

    'DataGridViewに表示されているコンボボックスの SelectedIndexChangedイベントハンドラ
#Disable Warning IDE1006 ' 命名スタイル
    Private Sub dataGridViewComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
#Enable Warning IDE1006 ' 命名スタイル
        '選択されたアイテムを表示
        Dim cb As DataGridViewComboBoxEditingControl = CType(sender, DataGridViewComboBoxEditingControl)
        Console.WriteLine(cb.SelectedItem)

        ' MsgBox("吉井麻央")

        'DataGridView1.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Crimson
        'DataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Crimson

        'dt.Rows(DataGridView1.CurrentRow.Index)("ColTango") = "鰯"

        delEvent()

        dt.Rows(DataGridView1.CurrentRow.Index)("ComboBox") = cb.SelectedItem
        dt.Rows(DataGridView1.CurrentRow.Index)("ColTango") = cb.SelectedItem

        AddHandler Me.dataGridViewComboBox.SelectedIndexChanged, AddressOf dataGridViewComboBox_SelectedIndexChanged

        'Application.DoEvents()

        ' DataGridView1.CurrentRow.Cells("ColTango").Value = cb.SelectedItem

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

    Private Sub Print(s As String)
        Me.TextBox1.AppendText(s + vbCrLf)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

        If Me.CheckBox1.Checked Then
            Me.DataGridView1.EndEdit()
            Print("BeginEdit")
        End If

        Print("---")
        For Each row In dt.Rows
            Print(row("ColTango"))
        Next

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

        'Me.DataGridView1.EndEdit()

        ' DataGridView1.CurrentRow.DefaultCellStyle.ForeColor = Color.Crimson

        DataGridView1.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Crimson

        DataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Crimson

        ' doevents()
        Application.DoEvents()

        MsgBox("吉井麻央")

        ' DataGridView1.CurrentRow.cells .DefaultCellStyle.BackColor = Color.Crimson

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("まおまお")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If DataGridView1.SelectedRows.Count > 1 Then
            MsgBox("a")
        End If

        For Each row As DataGridViewRow In DataGridView1.SelectedRows

        Next

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        'MsgBox(DataGridView1.DisplayRectangle.Width)

        MsgBox(DataGridView1.DisplayRectangle.Height)

        ' DataGridView1.DisplayRectangle = New Size(1000, 50)

        Me.Height = Me.Height + (600 - DataGridView1.DisplayRectangle.Height)

        MsgBox(DataGridView1.DisplayRectangle.Height)

    End Sub

    Private Sub DataGridView1_CellToolTipTextNeeded(sender As Object, e As DataGridViewCellToolTipTextNeededEventArgs) Handles DataGridView1.CellToolTipTextNeeded

        ' e.ToolTipText = DataGridView1.Columns(e.ColumnIndex).HeaderText

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        'Debug.Print(QuotedStr("do'not i "))

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim pd As New Printing.PrintDocument
        'PrintPageイベントハンドラの追加
        AddHandler pd.PrintPage, AddressOf pd_PrintPage

        'PrintPreviewDialogオブジェクトの作成
        Dim ppd As New PrintPreviewDialog
        'プレビューするPrintDocumentを設定
        ppd.Document = pd

        ppd.PrintPreviewControl.Zoom = 1

        '印刷プレビューダイアログを表示する
        ppd.ShowDialog()
    End Sub

    Private Sub pd_PrintPage(ByVal sender As Object,
            ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        '画像を読み込む 
        Dim img As Image = Image.FromFile("C:\temp\sundai_logo.Png")
        '画像を描画する 
        e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height)
        '次のページがないことを通知する 
        e.HasMorePages = False
        '後始末をする 
        img.Dispose()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Print(fncSpCharConvert(" ^ , a: , ,, /, ', |, b*, <, >, ?, c\, """))

        Print(ReplaceSymbol(" ^ , a: , ,, /, ', |, b*, <, >, ?, c\, """))

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim sql As String = ""
        sql += "Select * "
        sql += " From tbl保存問題"
        Dim db As DataBase = New DataBase()
        Try
            db.Open()
            dt = db.ExecuteSql(sql)
            DataGridView1.DataSource = dt
        Catch ex As Exception
            comFunc.outDbErr(ex)
            Return
        Finally
            db.Close()
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim sql As String = ""
        sql += "insert into tbl4  select * from tbl3 "
        Dim db As DataBase = New DataBase()
        Try
            db.Open()
            For i As Integer = 1 To 900 ' * 1000 ' * 10
                db.ExecuteSql(sql)
            Next
            Print("Insert END")
        Catch ex As Exception
            comFunc.outDbErr(ex)
            Return
        Finally
            db.Close()
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        execSelect("Select max(id) From tbl2")
        'Dim sql As String = ""
        'sql += "Select max(id) "
        'sql += " From tbl2"
        'Dim db As DataBase = New DataBase()
        'Try
        '    db.Open()
        '    dt = db.ExecuteSql(sql)
        '    DataGridView1.DataSource = dt
        'Catch ex As Exception
        '    comFunc.outDbErr(ex)
        '    Return
        'Finally
        '    db.Close()
        'End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        execSQL("delete from tbl2 where id >  1093332 ")
        Print("END")
    End Sub

    Private Sub execSQL(sql As String)
        Dim db As DataBase = New DataBase()
        Try
            db.Open()
            db.ExecuteSql(sql)
        Catch ex As Exception
            comFunc.outDbErr(ex)
            Return
        Finally
            db.Close()
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        execSelect("select count(name1) as cnt from tbl2")
    End Sub

    Private Sub execSelect(sql As String)
        Dim db As DataBase = New DataBase()
        Try
            db.Open()
            dt = db.ExecuteSql(sql)
            DataGridView1.DataSource = dt
        Catch ex As Exception
            comFunc.outDbErr(ex)
            Return
        Finally
            db.Close()
        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Using f As New Form2
            f.ShowDialog(Me)
            MsgBox(f.iwashi)
        End Using

        ' MsgBox(f.iwashi)

        'Dim f As Form2 = Nothing

        '' MsgBox(f.iwashi)

        'f = New Form2()

        'f.ShowDialog(Me)
        'f.Dispose()

        '' f.Dispose()

        'MsgBox(f.iwashi)
        'MsgBox(f.Button1.Text)

    End Sub
End Class

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim i As Integer? = Nothing
        'Dim d As DateTime? = Nothing
        'MsgBox(CStr(d))
        Form2.ShowDialog()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    ' 半角２バイト換算での文字列のバイト数を取得する。
    Private Function LenB(str As String) As Integer
        Dim result As Integer
        Dim s_jis As Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        result = s_jis.GetByteCount(str)
        Return result
    End Function


    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        ''半角２バイト換算での文字列のバイト数を取得する。
        Dim str1 As String = "123あいう"
        Dim LenB As Integer
        'Encoding.GetByteCount メソッド
        '指定した文字配列をエンコードするために必要なバイト数を計算します
        LenB = Me.LenB(str1)
        'Debug.WriteLine(LenB.ToString)     '結果  12

        TextBox1.AppendText(CStr(LenB))

    End Sub

    Private Sub TextBox2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBox2.Validating

        If TextBox2.Text.Length > 10 Then
            e.Cancel = True
            MsgBox("だめ")
            ' TextBox2.Text = TextBox2.Text.Substring(0, 10)
        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        If TextBox2.Text.Length > 10 Then
            ' TextBox2.Text = TextBox2.Text.Substring(0, 10)
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '半角１バイト換算での文字列のバイト数を取得する。
        Dim str1 As String = "123あいう"
        Dim LenB As Integer
        Dim s_jis As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        LenB = s_jis.GetByteCount(str1)
        Debug.WriteLine(LenB.ToString)      '結果  9

        '又は
        LenB = System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(str1)
        Debug.WriteLine(LenB.ToString)      '結果  9

        LenB = System.Text.Encoding.GetEncoding(932).GetByteCount(str1)
        Debug.WriteLine(LenB.ToString)      '結果  9

        '参考  システムの現在の ANSI コード ページのエンコーディングに必要なバイト数
        Debug.WriteLine(System.Text.Encoding.Default.GetByteCount(str1))    '結果  9

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        ' Me.TreeView1.


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        createNodes()

    End Sub


    Private Sub createNodes()
        '親ノード
        Dim rootNode1 As New TreeNode(" 1 Fundamental Stage")
        Dim rootNode2 As New TreeNode(" 2 Essential Stage")
        Dim rootNode3 As New TreeNode(" 3 Advanced Stage")
        Dim rootNode4 As New TreeNode(" 4 Final Stage")
        Dim rootNode5 As New TreeNode(" 5 多義語のBrush Up")

        '子ノード
        Dim childNode11 As New TreeNode(" (1) Verbs 動詞")
        Dim childNode12 As New TreeNode(" (2) Nouns 名詞")
        Dim childNode13 As New TreeNode(" (3) Adjectives 形容詞")
        Dim childNode14 As New TreeNode(" (4) Adverbs etc. 副詞・その他")
        Dim childNode15 As New TreeNode(" (5) Verbs 名詞")
        Dim childNode16 As New TreeNode(" (6) Nouns 名詞")
        Dim childNode17 As New TreeNode(" (7) Adjectives 形容詞")
        Dim childNode18 As New TreeNode(" (8) Adverbs etc. 副詞・その他")

        Dim childNode21 As New TreeNode(" (1) Verbs 動詞")
        Dim childNode22 As New TreeNode(" (2) Nouns 名詞")
        Dim childNode23 As New TreeNode(" (3) Adjectives 形容詞")
        Dim childNode24 As New TreeNode(" (4) Adverbs etc. 副詞・その他")
        Dim childNode25 As New TreeNode(" (5) Verbs 名詞")
        Dim childNode26 As New TreeNode(" (6) Nouns 名詞")
        Dim childNode27 As New TreeNode(" (7) Adjectives 形容詞")
        Dim childNode28 As New TreeNode(" (8) Adverbs 副詞")

        Dim childNode31 As New TreeNode(" (1) Verbs 動詞")
        Dim childNode32 As New TreeNode(" (2) Nouns 名詞")
        Dim childNode33 As New TreeNode(" (3) Adjectives 形容詞")
        Dim childNode34 As New TreeNode(" (4) Verbs 名詞")
        Dim childNode35 As New TreeNode(" (5) Nouns 名詞")
        Dim childNode36 As New TreeNode(" (6) Adjectives 形容詞")
        Dim childNode37 As New TreeNode(" (7) Adverbs etc. 副詞・その他")

        Dim childNode41 As New TreeNode(" (1) Verbs 動詞")
        Dim childNode42 As New TreeNode(" (2) Nouns 名詞")
        Dim childNode43 As New TreeNode(" (3) Adjectives 形容詞")
        Dim childNode44 As New TreeNode(" (4) Adverbs etc. 副詞・その他")

        Dim childNode51 As New TreeNode(" (1) 動詞")
        Dim childNode52 As New TreeNode(" (2) 名詞")
        Dim childNode53 As New TreeNode(" (3) 形容詞・副詞")

        ' チェックボックスを表示する 
        TreeView1.CheckBoxes = True


        '親ノード
        TreeView1.Nodes.Add(rootNode1)
        TreeView1.Nodes.Add(rootNode2)
        TreeView1.Nodes.Add(rootNode3)
        TreeView1.Nodes.Add(rootNode4)
        TreeView1.Nodes.Add(rootNode5)

        '子ノード
        rootNode1.Nodes.Add(childNode11)
        rootNode1.Nodes.Add(childNode12)
        rootNode1.Nodes.Add(childNode13)
        rootNode1.Nodes.Add(childNode14)
        rootNode1.Nodes.Add(childNode15)
        rootNode1.Nodes.Add(childNode16)
        rootNode1.Nodes.Add(childNode17)
        rootNode1.Nodes.Add(childNode18)

        rootNode2.Nodes.Add(childNode21)
        rootNode2.Nodes.Add(childNode22)
        rootNode2.Nodes.Add(childNode23)
        rootNode2.Nodes.Add(childNode24)
        rootNode2.Nodes.Add(childNode25)
        rootNode2.Nodes.Add(childNode26)
        rootNode2.Nodes.Add(childNode27)
        rootNode2.Nodes.Add(childNode28)

        rootNode3.Nodes.Add(childNode31)
        rootNode3.Nodes.Add(childNode32)
        rootNode3.Nodes.Add(childNode33)
        rootNode3.Nodes.Add(childNode34)
        rootNode3.Nodes.Add(childNode35)
        rootNode3.Nodes.Add(childNode36)
        rootNode3.Nodes.Add(childNode37)

        rootNode4.Nodes.Add(childNode41)
        rootNode4.Nodes.Add(childNode42)
        rootNode4.Nodes.Add(childNode43)
        rootNode4.Nodes.Add(childNode44)

        rootNode5.Nodes.Add(childNode51)
        rootNode5.Nodes.Add(childNode52)
        rootNode5.Nodes.Add(childNode53)

        '全ノードを展開する
        TreeView1.ExpandAll()

        TreeView1.SelectedNode = rootNode1

    End Sub
End Class

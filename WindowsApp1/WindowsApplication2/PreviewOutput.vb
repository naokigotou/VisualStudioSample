

Class PreviewOutput
    Const FONT_NAME = "ＭＳ ゴシック"
    Public curQNo As Integer = 1     ' 問題番号
    Public cur小問No As Integer = 1  ' 小問番号
    Public maxQNo As Integer = 50    ' 最大設問番号
    Public isKaitourei As Boolean = False
    ' ヘッダーフォント
    Public headFont As New Font(FONT_NAME, 11, FontStyle.Bold)
    ' タイトルフォント
    Public titleFont As New Font(FONT_NAME, 18, FontStyle.Bold)
    ' 設問フォント
    Public 設問Font As New Font(FONT_NAME, 9, FontStyle.Bold)
    Public normalFont As New Font(FONT_NAME, 9)
    ' 右寄せ
    Public fmtFar As New StringFormat
    ' 中央
    Public fmtCenter As New StringFormat
    ' 左寄せ
    Public fmt As New StringFormat

    Public Sub New()
        fmtFar.Alignment = StringAlignment.Far
        fmtCenter.Alignment = StringAlignment.Center
        fmt.Alignment = StringAlignment.Near
    End Sub

    ' 文字列の追加
    Public Sub AddText(e As Printing.PrintPageEventArgs, text As String, x As Integer, y As Integer, fmt As StringFormat, Optional size As Single = 9, Optional bold As FontStyle = FontStyle.Regular)
        Dim textFont = New Font(FONT_NAME, size, bold)
        e.Graphics.DrawString(text, textFont, New SolidBrush(Color.Black), x, y, fmt)
    End Sub

    ''' <summary>
    ''' タイトルを出力する.
    ''' </summary>
    ''' <param name="title">タイトル</param>
    Public Sub AddTitle(ByRef curY As Integer, e As Printing.PrintPageEventArgs, title As String)
        Dim titleHeight = 40
        Dim iサイズ As Integer = e.Graphics.MeasureString(title, titleFont).Width
        Dim bタイトル複数 As Boolean = iサイズ > e.MarginBounds.Size.Width
        If bタイトル複数 Then
            titleHeight = 65
        End If
        Dim rect As New RectangleF(e.MarginBounds.Left, curY, e.MarginBounds.Size.Width, titleHeight)
        e.Graphics.DrawString(title, titleFont, New SolidBrush(Color.Black), rect, fmtCenter)
        curY += titleHeight
    End Sub

    ''' <summary>
    ''' ヘッダーを作成する.
    ''' </summary>
    ''' <param name="cnt">回数（省略可）</param>
    ''' <param name="gakunen">学年（省略可）</param>
    ''' <param name="kumi">組（省略可）</param>
    Public Sub AddHeader(ByRef curY As Integer, e As Printing.PrintPageEventArgs, Optional cnt As String = "　",
                         Optional gakunen As String = "   ", Optional kumi As String = "   ",
                         Optional biko As String = "")
        ' 空文字対処
        If cnt = "" Then
            cnt = "　"
        End If
        If gakunen = "" Then
            gakunen = "　"
        End If
        If kumi = "" Then
            kumi = "　　"
        End If

        ' 日付
        Dim x = e.MarginBounds.Right
        AddText(e, Space(4) & "月" & Space(4) & "日", x, curY, fmtFar, 11, FontStyle.Bold)
        curY += 25

        Dim タイトル As String = ComConf.set_FileName + biko
        AddTitle(curY, e, タイトル)

        ' 学年、組
        Dim g As Graphics = e.Graphics
        Dim blackPen As New Pen(Color.Black, 0.2)
        Dim br As Brush = Brushes.Black

        Dim y1 As Integer = curY
        Dim y2 As Integer = curY + 45

        Dim w1 As Integer = 125
        Dim w2 As Integer = 70
        Dim w3 As Integer = 55
        Dim w4 As Integer = 160
        Dim w5 As Integer = 75

        Dim x1 As Integer = e.MarginBounds.Right - (w1 + w2 + w3 + w4 + w5)
        Dim x2 As Integer = x1 + w1
        Dim x3 As Integer = x2 + w2
        Dim x4 As Integer = x3 + w3
        Dim x5 As Integer = x4 + w4
        Dim x6 As Integer = x5 + w5

        '横線
        g.DrawLine(blackPen, x1, y1, x6, y1)
        g.DrawLine(blackPen, x1, y2, x6, y2)

        '縦線
        g.DrawLine(blackPen, x1, y1, x1, y2)
        g.DrawLine(blackPen, x2, y1, x2, y2)
        g.DrawLine(blackPen, x3, y1, x3, y2)
        g.DrawLine(blackPen, x4, y1, x4, y2)
        g.DrawLine(blackPen, x5, y1, x5, y2)
        g.DrawLine(blackPen, x6, y1, x6, y2)

        Dim ym1 = 14
        Dim ym2 = 24
        Dim 年組 As String = gakunen & "年" & kumi & "組"
        '  右寄せ
        g.DrawString(" " & 年組, headFont, br, x2 - 2, y1 + ym1, fmtFar)
        g.DrawString("　　　番", headFont, br, x2, y1 + ym1)
        g.DrawString("　氏名", headFont, br, x3, y1 + ym1)
        g.DrawString("　　　 点", headFont, br, x5, y1 + ym2)

        curY = y2 + 18

    End Sub

    ''' <summary>
    ''' 解答例ヘッダーを作成する.
    ''' </summary>
    ''' <param name="cnt">回数（省略可）</param>
    ''' <param name="gakunen">学年（省略可）</param>
    ''' <param name="kumi">組（省略可）</param>
    Public Sub AddHeaderExmp(ByRef curY As Integer, e As Printing.PrintPageEventArgs, Optional cnt As String = "　",
                             Optional gakunen As String = "   ", Optional kumi As String = "   ", Optional biko As String = "")
        ' 空文字対処
        If cnt = "" Then
            cnt = "　"
        End If
        If gakunen = "" Then
            gakunen = "　"
        End If
        If kumi = "" Then
            kumi = "　　"
        End If

        ' 日付
        Dim x = e.MarginBounds.Right
        AddText(e, Space(4) & "月" & Space(4) & "日", x, curY, fmtFar, 11, FontStyle.Bold)
        curY += 25

        ' タイトル
        Dim タイトル As String = ComConf.set_FileName + biko & " 解答例"
        AddTitle(curY, e, タイトル)

        Dim g As Graphics = e.Graphics
        Dim blackPen As New Pen(Color.Black, 0.2)
        Dim br As Brush = Brushes.Black

        Dim y1 As Integer = curY
        Dim y2 As Integer = curY + 20
        Dim w1 As Integer = 130
        Dim x1 As Integer = e.MarginBounds.Right - w1
        Dim x2 As Integer = x1 + w1

        '横線
        g.DrawLine(blackPen, x1, y2, x2, y2)
        g.DrawString("　　" + gakunen & "年" & kumi & "組", headFont, br, e.MarginBounds.Right, y1, fmtFar)
        curY = y2 + 15

    End Sub

    ''' <summary>
    ''' 問題文.
    ''' </summary>
    Public Sub AddQuestion(ByRef curY As Integer, e As Printing.PrintPageEventArgs, que As String,
                           Optional ans As String = "", Optional choice As String = "")
        Dim x As Integer = e.MarginBounds.Left

        ' 問題文
        Dim qHeight = 20

        ' 問題文が複数行か判定する
        Dim b問題文複数 As Boolean = e.Graphics.MeasureString(que, normalFont).Width > e.MarginBounds.Size.Width
        If b問題文複数 Then
            qHeight = 35
        End If

        Dim rect As New RectangleF(x, curY, e.MarginBounds.Size.Width, qHeight)
        e.Graphics.DrawString(que, normalFont, New SolidBrush(Color.Black), rect, fmt)

        If b問題文複数 Then
            curY += 15
        End If

        ' 選択肢
        If choice <> "" Then
            e.Graphics.DrawString(" " + choice, normalFont, New SolidBrush(Color.Black), x, curY + 20, fmt)
            curY += 20
        End If

        ' 解答欄
        Dim g As Graphics = e.Graphics
        Dim blackPen As New Pen(Color.Black, 0.2)
        Dim br As Brush = Brushes.Black

        Dim y1 As Integer = curY + 28
        Dim w1 As Integer = 460
        Dim x1 As Integer = e.MarginBounds.Right - w1
        Dim x2 As Integer = x1 + w1

        '横線
        g.DrawLine(blackPen, x1, y1, x2, y1)

        ' 解答
        If ans <> "" Then
            e.Graphics.DrawString(" " + ans, normalFont, New SolidBrush(Color.Black), x1, curY + 14, fmt)
        End If

        curY += 32

    End Sub

    ''' <summary>
    ''' 設問.
    ''' </summary>
    Public Sub Add小問(ByRef curY As Integer, e As Printing.PrintPageEventArgs, val As String)
        Dim x As Integer = e.MarginBounds.Left

        ' 問題文
        Dim qHeight = 20

        ' 問題文が複数行か判定する
        Dim b複数 As Boolean = e.Graphics.MeasureString(val, 設問Font).Width > e.MarginBounds.Size.Width
        If b複数 Then
            qHeight = 35
        End If

        Dim rect As New RectangleF(x, curY, e.MarginBounds.Size.Width, qHeight)
        e.Graphics.DrawString(val, 設問Font, New SolidBrush(Color.Black), rect, fmt)
        curY += qHeight
    End Sub

End Class



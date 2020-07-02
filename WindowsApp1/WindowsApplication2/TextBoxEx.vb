    Public Class TextBoxEx

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)

            'カスタム描画コードをここに追加します。
        End Sub

        Private _placeholder As String = String.Empty
        Public Property Placeholder() As String
            Get
                Return _placeholder
            End Get
            Set(ByVal value As String)
                _placeholder = value
            End Set
        End Property


        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            MyBase.WndProc(m)

            If m.Msg = 15 Then
            '  WM_PAINT == 15
            If Me.Enabled AndAlso Not Me.ReadOnly AndAlso Not Me.Focused AndAlso (_placeholder IsNot Nothing) AndAlso (_placeholder.Length > 0) AndAlso (Me.TextLength = 0) Then
                Using g = Me.CreateGraphics()
                    ' 描画を一旦消してしまう
                    g.FillRectangle(New System.Drawing.SolidBrush(Me.BackColor), Me.ClientRectangle)

                    ' プレースホルダのテキスト色を、前景色と背景色の中間として文字列を描画する
                    Dim placeholderTextColor = System.Drawing.Color.FromArgb((Me.ForeColor.A >> 1 + Me.BackColor.A >> 1), (Me.ForeColor.R >> 1 + Me.BackColor.R >> 1), ((Me.ForeColor.G >> 1 + Me.BackColor.G) >> 1), (Me.ForeColor.B >> 1 + Me.BackColor.B >> 1))
                    g.DrawString(_placeholder, Me.Font, New System.Drawing.SolidBrush(placeholderTextColor), 1, 1)
                End Using
            End If
        End If
        End Sub

    End Class


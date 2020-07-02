Public Class TreeViewEx
    Inherits TreeView

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        ' 不具合回避のため、 WM_LBUTTONDBLCLK イベントを無視する
        If m.Msg = &H203 Then
            m.Result = IntPtr.Zero
        Else
            MyBase.WndProc(m)
        End If
    End Sub

End Class

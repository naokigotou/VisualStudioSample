Public Class Form1

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


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim mao(5) As String

        mao(1) = "まおまお"

        print(mao(1))

        print(mao.GetUpperBound(0))


    End Sub
End Class

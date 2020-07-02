<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProgressDialog
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cancelAsyncButton = New System.Windows.Forms.Button()
        Me.colorProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'label2
        '
        Me.label2.BackColor = System.Drawing.Color.Transparent
        Me.label2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.label2.Location = New System.Drawing.Point(17, 28)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(246, 15)
        Me.label2.TabIndex = 8
        Me.label2.Text = "処理中"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.label1.Location = New System.Drawing.Point(35, 92)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(40, 15)
        Me.label1.TabIndex = 7
        Me.label1.Text = "100％"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cancelAsyncButton
        '
        Me.cancelAsyncButton.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cancelAsyncButton.Location = New System.Drawing.Point(164, 101)
        Me.cancelAsyncButton.Name = "cancelAsyncButton"
        Me.cancelAsyncButton.Size = New System.Drawing.Size(95, 34)
        Me.cancelAsyncButton.TabIndex = 6
        Me.cancelAsyncButton.Text = "キャンセル"
        Me.cancelAsyncButton.UseVisualStyleBackColor = True
        Me.cancelAsyncButton.Visible = False
        '
        'colorProgressBar1
        '
        Me.colorProgressBar1.Location = New System.Drawing.Point(17, 66)
        Me.colorProgressBar1.Name = "colorProgressBar1"
        Me.colorProgressBar1.Size = New System.Drawing.Size(246, 23)
        Me.colorProgressBar1.TabIndex = 9
        '
        'ProgressDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(276, 164)
        Me.Controls.Add(Me.colorProgressBar1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.cancelAsyncButton)
        Me.Name = "ProgressDialog"
        Me.Text = "ProgressDialog"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private WithEvents label2 As Label
    Private WithEvents label1 As Label
    Private WithEvents cancelAsyncButton As Button
    Friend WithEvents colorProgressBar1 As ProgressBar
End Class

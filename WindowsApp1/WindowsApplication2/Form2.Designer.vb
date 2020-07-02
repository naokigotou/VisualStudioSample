<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgv_履歴一覧 = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.作成日時 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.学年 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.組 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.印字備考 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.備考 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBoxEx1 = New まお.TextBoxEx()
        Me.TextBoxEx2 = New まお.TextBoxEx()
        CType(Me.dgv_履歴一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(26, 39)
        Me.Button1.Margin = New System.Windows.Forms.Padding(6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(274, 41)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgv_履歴一覧
        '
        Me.dgv_履歴一覧.AllowUserToAddRows = False
        Me.dgv_履歴一覧.AllowUserToDeleteRows = False
        Me.dgv_履歴一覧.AllowUserToResizeColumns = False
        Me.dgv_履歴一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ 明朝", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_履歴一覧.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_履歴一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_履歴一覧.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.作成日時, Me.学年, Me.組, Me.印字備考, Me.備考})
        Me.dgv_履歴一覧.Location = New System.Drawing.Point(11, 122)
        Me.dgv_履歴一覧.Margin = New System.Windows.Forms.Padding(2)
        Me.dgv_履歴一覧.Name = "dgv_履歴一覧"
        Me.dgv_履歴一覧.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ 明朝", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_履歴一覧.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_履歴一覧.RowHeadersVisible = False
        Me.dgv_履歴一覧.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgv_履歴一覧.RowTemplate.Height = 21
        Me.dgv_履歴一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_履歴一覧.ShowEditingIcon = False
        Me.dgv_履歴一覧.Size = New System.Drawing.Size(1227, 328)
        Me.dgv_履歴一覧.TabIndex = 41
        '
        'id
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.id.DefaultCellStyle = DataGridViewCellStyle2
        Me.id.FillWeight = 60.0!
        Me.id.HeaderText = "No."
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.id.Width = 60
        '
        '作成日時
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.作成日時.DefaultCellStyle = DataGridViewCellStyle3
        Me.作成日時.HeaderText = "作成日時"
        Me.作成日時.Name = "作成日時"
        Me.作成日時.ReadOnly = True
        Me.作成日時.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.作成日時.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.作成日時.Width = 120
        '
        '学年
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.学年.DefaultCellStyle = DataGridViewCellStyle4
        Me.学年.HeaderText = "学年"
        Me.学年.Name = "学年"
        Me.学年.ReadOnly = True
        Me.学年.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.学年.Width = 40
        '
        '組
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.組.DefaultCellStyle = DataGridViewCellStyle5
        Me.組.HeaderText = "組"
        Me.組.Name = "組"
        Me.組.ReadOnly = True
        Me.組.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.組.Width = 65
        '
        '印字備考
        '
        Me.印字備考.HeaderText = "備考(印字用)"
        Me.印字備考.Name = "印字備考"
        Me.印字備考.ReadOnly = True
        Me.印字備考.Width = 262
        '
        '備考
        '
        Me.備考.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Meiryo UI", 9.0!)
        Me.備考.DefaultCellStyle = DataGridViewCellStyle6
        Me.備考.HeaderText = "備考"
        Me.備考.Name = "備考"
        Me.備考.ReadOnly = True
        Me.備考.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(322, 40)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(225, 38)
        Me.Button2.TabIndex = 42
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(566, 42)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(178, 34)
        Me.Button3.TabIndex = 43
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(873, 51)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(327, 31)
        Me.TextBox1.TabIndex = 44
        '
        'TextBoxEx1
        '
        Me.TextBoxEx1.Location = New System.Drawing.Point(211, 504)
        Me.TextBoxEx1.Name = "TextBoxEx1"
        Me.TextBoxEx1.Placeholder = ""
        Me.TextBoxEx1.Size = New System.Drawing.Size(533, 31)
        Me.TextBoxEx1.TabIndex = 45
        '
        'TextBoxEx2
        '
        Me.TextBoxEx2.Location = New System.Drawing.Point(822, 495)
        Me.TextBoxEx2.Name = "TextBoxEx2"
        Me.TextBoxEx2.Placeholder = ""
        Me.TextBoxEx2.Size = New System.Drawing.Size(251, 31)
        Me.TextBoxEx2.TabIndex = 46
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1265, 615)
        Me.Controls.Add(Me.TextBoxEx2)
        Me.Controls.Add(Me.TextBoxEx1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.dgv_履歴一覧)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("ＭＳ 明朝", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        CType(Me.dgv_履歴一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Private WithEvents dgv_履歴一覧 As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents 作成日時 As DataGridViewTextBoxColumn
    Friend WithEvents 学年 As DataGridViewTextBoxColumn
    Friend WithEvents 組 As DataGridViewTextBoxColumn
    Friend WithEvents 印字備考 As DataGridViewTextBoxColumn
    Friend WithEvents 備考 As DataGridViewTextBoxColumn
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBoxEx1 As TextBoxEx
    Friend WithEvents TextBoxEx2 As TextBoxEx
End Class

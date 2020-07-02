Imports System.ComponentModel

Public Class ProgressDialog
    Public Sub New(caption As String, doWork As DoWorkEventHandler, argument As Object)
        InitializeComponent()

        '初期設定
        Me.workerArgument = argument
        Me.Text = caption
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.ShowInTaskbar = False
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ControlBox = False
        Me.CancelButton = Me.cancelAsyncButton
        label1.Text = ""

        Me.colorProgressBar1.Minimum = 0
        Me.colorProgressBar1.Maximum = 100
        Me.colorProgressBar1.Value = 0

        Me.cancelAsyncButton.Text = "キャンセル"
        Me.cancelAsyncButton.Enabled = True
        Me.backgroundWorker1.WorkerReportsProgress = True
        Me.backgroundWorker1.WorkerSupportsCancellation = True

        'イベント
        AddHandler Me.Shown, New EventHandler(AddressOf ProgressDialog_Shown)
        AddHandler Me.cancelAsyncButton.Click, New EventHandler(AddressOf cancelAsyncButton_Click)
        AddHandler Me.backgroundWorker1.DoWork, doWork
        AddHandler Me.backgroundWorker1.ProgressChanged, New ProgressChangedEventHandler(AddressOf backgroundWorker1_ProgressChanged)


        AddHandler Me.backgroundWorker1.RunWorkerCompleted, New RunWorkerCompletedEventHandler(AddressOf backgroundWorker1_RunWorkerCompleted)
    End Sub

    ''' <summary>
    ''' ProgressDialogクラスのコンストラクタ
    ''' </summary>
    Public Sub New(formTitle As String, doWorkHandler As DoWorkEventHandler)
        Me.New(formTitle, doWorkHandler, Nothing)
    End Sub

    Private workerArgument As Object = Nothing

    Private Sub ProgressDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private _result As Object = Nothing
    ''' <summary>
    ''' DoWorkイベントハンドラで設定された結果
    ''' </summary>
    Public ReadOnly Property Result() As Object
        Get
            Return Me._result
        End Get
    End Property

    Private _error As Exception = Nothing
    ''' <summary>
    ''' バックグラウンド処理中に発生したエラー
    ''' </summary>
    Public ReadOnly Property [Error]() As Exception
        Get
            Return Me._error
        End Get
    End Property

    ''' <summary>
    ''' 進行状況ダイアログで使用しているBackgroundWorkerクラス
    ''' </summary>
    Public ReadOnly Property BackgroundWorker() As BackgroundWorker
        Get
            Return Me.backgroundWorker1
        End Get
    End Property

    'フォームが表示されたときにバックグラウンド処理を開始
    Private Sub ProgressDialog_Shown(sender As Object, e As EventArgs)
        Me.backgroundWorker1.RunWorkerAsync(Me.workerArgument)
    End Sub

    'キャンセルボタンが押されたとき
    Private Sub cancelAsyncButton_Click(sender As Object, e As EventArgs) Handles cancelAsyncButton.Click
        cancelAsyncButton.Enabled = False
        backgroundWorker1.CancelAsync()
    End Sub

    'ReportProgressメソッドが呼び出されたとき
    Private Sub backgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)

        If e.ProgressPercentage < Me.colorProgressBar1.Minimum Then
            Me.colorProgressBar1.Value = Me.colorProgressBar1.Minimum
        ElseIf Me.colorProgressBar1.Maximum < e.ProgressPercentage Then
            Me.colorProgressBar1.Value = Me.colorProgressBar1.Maximum
        Else
            Me.colorProgressBar1.Value = e.ProgressPercentage
        End If

        'メッセージのテキストを変更する
        Me.label1.Text = DirectCast(e.UserState, String)
    End Sub

    'バックグラウンド処理が終了したとき
    Private Sub backgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        If e.Error IsNot Nothing Then
            MessageBox.Show(Me, "エラー", "エラーが発生しました。" & vbLf & vbLf & e.Error.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me._error = e.Error
            Me.DialogResult = DialogResult.Abort
        ElseIf e.Cancelled Then
            Me.DialogResult = DialogResult.Cancel
        Else
            Me._result = e.Result
            Me.DialogResult = DialogResult.OK
        End If

        Me.Close()
    End Sub
End Class
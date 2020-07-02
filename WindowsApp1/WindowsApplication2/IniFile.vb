Imports System.Text

Imports System.Runtime.InteropServices

''' <summary>
''' INIファイルを読み書きするクラス
''' </summary>
Class IniFile

    <DllImport("kernel32.dll")>
    Private Shared Function GetPrivateProfileString(lpApplicationName As String, lpKeyName As String, lpDefault As String, lpReturnedstring As StringBuilder, nSize As Integer, lpFileName As String) As Integer
    End Function

    <DllImport("kernel32.dll")>
    Private Shared Function WritePrivateProfileString(lpApplicationName As String, lpKeyName As String, lpstring As String, lpFileName As String) As Integer
    End Function

    Private ReadOnly filePath As String

    ''' <summary>
    ''' ファイル名を指定して初期化します。
    ''' ファイルが存在しない場合は初回書き込み時に作成されます。
    ''' </summary>
    Public Sub New(filePath As String)
        Me.filePath = filePath
    End Sub


    ''' <summary>
    ''' sectionとkeyからiniファイルの設定値を取得、設定します。 
    ''' </summary>
    ''' <returns>指定したsectionとkeyの組合せが無い場合は""が返ります。</returns>
    Default Public Property Item(section As String, key As String) As String
        Get
            Dim sb As New StringBuilder(256)
            GetPrivateProfileString(section, key, String.Empty, sb, sb.Capacity, filePath)
            Return sb.ToString()
        End Get
        Set
            WritePrivateProfileString(section, key, Value, filePath)
        End Set
    End Property


    ''' <summary>
    ''' sectionとkeyからiniファイルの設定値を取得します。
    ''' 指定したsectionとkeyの組合せが無い場合はdefaultvalueで指定した値が返ります。
    ''' </summary>
    ''' <returns>
    ''' 指定したsectionとkeyの組合せが無い場合はdefaultvalueで指定した値が返ります。
    ''' </returns>
    Public Function GetValue(section As String, key As String, defaultvalue As String) As String
        Dim sb As New StringBuilder(256)
        GetPrivateProfileString(section, key, defaultvalue, sb, sb.Capacity, filePath)
        Return sb.ToString()
    End Function
End Class

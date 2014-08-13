Imports System.IO

Public Class Form4

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Form4_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim r1 As Process() = Process.GetProcessesByName("nginx")
        If r1.Length > 0 Then
            MsgBox("nginx正在執行 請等待nginx關閉 在開啟記錄檔")
            Return
        End If

        Dim re As StreamReader = New StreamReader("C:\nginx\logs\access.log")
        TextBox1.Text = re.ReadToEnd
        re.Close()
    End Sub
End Class
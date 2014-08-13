Imports System.Threading
Imports System.IO

Public Class Form3

    Private Sub Form3_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
       
    End Sub

    Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = Now + " " + ":" + "Nginx正在關閉......"
        TextBox1.Text += vbCrLf
        Dim s1 As Process = Process.Start("C:\nginx\stopnginx.exe")
        s1.WaitForExit()
        TextBox1.Text = vbCrLf + TextBox1.Text + vbCrLf + Now + " " + ":" + "Nginx已關閉"

        TextBox1.Text += vbCrLf
        TextBox1.Text = TextBox1.Text + vbCrLf + Now + " " + ":" + "PHP正在關閉......"

        TextBox1.Text += vbCrLf
        Dim s2 As Process = Process.Start("C:\nginx\stopphp.exe")
        s2.WaitForExit()
        TextBox1.Text = TextBox1.Text + vbCrLf + Now + " " + ":" + "PHP已關閉"
        TextBox1.Text += vbCrLf

        TextBox1.Text = TextBox1.Text + vbCrLf + Now + " " + ":" + "MYSQL正在關閉....."
        TextBox1.Text += vbCrLf
        Thread.Sleep(1000)
        Dim s3 As Process = Process.Start("C:\nginx\stopsql.exe")
        s3.WaitForExit()
        TextBox1.Text = TextBox1.Text + vbCrLf + Now + " " + ":" + "MYSQL已關閉"
        TextBox1.Text += vbCrLf
        Dim w1 As Process() = Process.GetProcessesByName("FileZilla Server")
        If w1.Length > 0 Then
            Dim a1() As Process = Process.GetProcessesByName("FileZilla Server")
            For Each Process1 As Process In a1
                Process1.Kill()
            Next
        End If
        TextBox1.Text = TextBox1.Text + vbCrLf + Now + " " + ":" + "FileZilla Server已關閉"
        TextBox1.Text += vbCrLf
        Dim eh As StreamWriter = New StreamWriter("C:\nginx\logs\history.txt", True)
        eh.Write(TextBox1.Text)
        eh.Close()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = " "
        Me.Close()
    End Sub
End Class
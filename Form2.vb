Imports System.Threading
Imports System.IO

Public Class Form2

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        TextBox1.Text = Now + " " + ":" + "Nginx正在啟動......"
        TextBox1.Text += vbCrLf
        Dim s1 As Process = Process.Start("C:\nginx\startnginx.bat")
        s1.WaitForExit()
        TextBox1.Text = vbCrLf + TextBox1.Text + vbCrLf + Now + " " + ":" + "Nginx已啟動"
        TextBox1.Text += vbCrLf
        TextBox1.Text = TextBox1.Text + vbCrLf + Now + " " + ":" + "PHP正在啟動......"
        TextBox1.Text += vbCrLf
        Dim s2 As Process = Process.Start("C:\nginx\startphp.bat")
        Thread.Sleep(1000)
        TextBox1.Text = TextBox1.Text + vbCrLf + Now + " " + ":" + "PHP已啟動"
        TextBox1.Text += vbCrLf

        TextBox1.Text = TextBox1.Text + vbCrLf + Now + " " + ":" + "MYSQL正在啟動....."
        TextBox1.Text += vbCrLf

        Dim s3 As Process = Process.Start("C:\nginx\mysql\bin\startsql.exe")
        s3.WaitForExit()
        TextBox1.Text = TextBox1.Text + vbCrLf + Now + " " + ":" + "MYSQL已啟動"
        TextBox1.Text += vbCrLf

        TextBox1.Text = TextBox1.Text + vbCrLf + Now + " " + ":" + "Filezlla正在啟動......"
        TextBox1.Text += vbCrLf
        Dim s4 As Process = Process.Start("C:\nginx\FileZilla Server\FileZilla Server.exe")
        s4.WaitForExit()
        Process.Start("C:\nginx\FileZilla Server\FileZilla Server Interface.exe")
        TextBox1.Text = TextBox1.Text + vbCrLf + Now + " " + ":" + "Filezlla已啟動......"
        TextBox1.Text += vbCrLf
        Dim eh As StreamWriter = New StreamWriter("C:\nginx\logs\history.txt", True)
        eh.Write(TextBox1.Text)
        eh.Close()
        Me.Close()


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = " "
        Me.Hide()
    End Sub
End Class
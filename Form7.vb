Imports System.IO

Public Class Form7

    Private Sub Form7_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim phperror As StreamReader = New StreamReader("C:\nginx\php\php.log")
        TextBox1.Text = phperror.ReadToEnd()
        phperror.Close()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
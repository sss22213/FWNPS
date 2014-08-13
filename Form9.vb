Imports System.IO

Public Class Form9

    Private Sub Form9_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim mysqla As StreamReader = New StreamReader("c:\nginx\mysql\data\" + Environ("COMPUTERNAME") + ".err")
        TextBox1.Text = mysqla.ReadToEnd
        mysqla.Close()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
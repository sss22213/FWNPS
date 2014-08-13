Imports System.IO

Public Class Form6

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        

        Me.Close()
    End Sub

    Private Sub Form6_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim rs As StreamReader = New StreamReader("C:\nginx\logs\history.txt")
        TextBox1.Text = rs.ReadToEnd

        rs.Close()
    End Sub
End Class
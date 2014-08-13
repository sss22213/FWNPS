Imports System.Threading
Imports System.IO

Public Class Form1
    Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Private Sub write1(abc)
        Dim eu As StreamWriter = New StreamWriter("C:\nginx\logs\history.txt", True)
        eu.Write(abc)
        eu.Flush()
        eu.Close()


    End Sub
    Private Function process01(abcd)
        Dim myProcess As Process() = Process.GetProcessesByName(abcd)
        If myProcess.Length > 0 Then

            MsgBox("請先關閉" + abcd)
            Return 1

        Else
            Return 0
        End If

    End Function
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim s1 As Process = Process.Start("C:\nginx\startnginx.bat")
        s1.WaitForExit()

        Dim myProcess As Process() = Process.GetProcessesByName("nginx")
        If myProcess.Length > 0 Then
            Button1.Enabled = False
            Button2.Enabled = True
            write1(vbCrLf + Now + ":" + " " + "開啟nginx 成功")

        Else
            MsgBox("Nginx開起失敗")
            write1(vbCrLf + Now + ":" + " " + "開啟nginx 失敗")
        End If





    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Process.Start("C:\nginx\stopnginx.exe")
        Button2.Enabled = False
        Button1.Enabled = True
        write1(vbCrLf + Now + ":" + " " + "關閉nginx")
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Process.Start("C:\nginx\startphp.bat")
        Button3.Enabled = False
        Button4.Enabled = True
        write1(vbCrLf + Now + ":" + " " + "開啟PHP")
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Process.Start("C:\nginx\stopphp.exe")
        Button4.Enabled = False
        Button3.Enabled = True
        write1(vbCrLf + Now + ":" + " " + "關閉PHP")
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click

       
        Dim s1 As Process = Process.Start("C:\nginx\FileZilla Server\FileZilla Server.exe")
        s1.WaitForExit()
        Thread.Sleep(5000)
        Dim s2 As Process = Process.Start("C:\nginx\FileZilla Server\FileZilla Server Interface.exe")
        Dim s3 As Process() = Process.GetProcessesByName("FileZilla Server")
        If s3.Length > 0 Then
            Button5.Enabled = False
            Button13.Enabled = True
        Else
            MsgBox("FileZilla Server開啟失敗")
            write1(vbCrLf + Now + ":" + " " + "FileZilla Server開啟失敗")
        End If
        write1(vbCrLf + Now + ":" + " " + "FileZilla Server開啟成功")

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click

        Dim s1 As Process = Process.Start("C:\nginx\mysql\bin\startsql.exe")
        s1.WaitForExit()
        Dim myProcess As Process() = Process.GetProcessesByName("mysqld")
        If myProcess.Length > 0 Then
            Button6.Enabled = False
            Button7.Enabled = True
            write1(vbCrLf + Now + ":" + " " + "開啟SQL成功")
        Else
            MsgBox("MYSQL開啟失敗")
            write1(vbCrLf + Now + ":" + " " + "MYSQL開啟失敗")
        End If
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Process.Start("C:\nginx\stopsql.exe")
        Button7.Enabled = False
        Button6.Enabled = True
        write1(vbCrLf + Now + ":" + " " + "關閉SQL")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("C:\nginx\conf\nginx.conf")
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click

        Dim myProcess As Process() = Process.GetProcessesByName("nginx")
        If myProcess.Length > 0 Then
           
            MsgBox("請先關閉Nginx")
            Return

        Else
             Form5.Show()
        End If

    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click

        Dim myProcess As Process() = Process.GetProcessesByName("nginx")
        If myProcess.Length > 0 Then

            MsgBox("請先關閉Nginx")
            Return

        Else
            Form4.Show()
        End If

    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
       
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim s1 As Process() = Process.GetProcessesByName("nginx")
        If s1.Length > 0 Then
            Dim s2 As Process = Process.Start("C:\nginx\stopnginx.exe")
            s2.WaitForExit()
        End If

        Dim s3 As Process() = Process.GetProcessesByName("mysqld")
        If s3.Length > 0 Then
            Dim s4 As Process = Process.Start("C:\nginx\stopsql.exe")
            s4.WaitForExit()
        End If

        Dim s5 As Process() = Process.GetProcessesByName("php-cgi")
        If s5.Length > 0 Then
            Process.Start("C:\nginx\stopphp.exe")

        End If


    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Form2.Show()
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = True
        Button6.Enabled = False
        Button7.Enabled = True
        Button9.Visible = False
        Button10.Visible = True
        Button5.Enabled = False
        Button13.Enabled = True

    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        Form3.Show()
        Button2.Enabled = False
        Button1.Enabled = True
        Button4.Enabled = False
        Button3.Enabled = True
        Button7.Enabled = False
        Button6.Enabled = True
        Button10.Visible = False
        Button9.Visible = True
        Button13.Enabled = False
        Button5.Enabled = True
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("C:\nginx\php\php.ini")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("C:\nginx\mysql\my.ini")
    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub 關閉ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 關閉ToolStripMenuItem.Click

        '
        Dim s1 As Process() = Process.GetProcessesByName("nginx")
        If s1.Length > 0 Then
            Dim s2 As Process = Process.Start("C:\nginx\stopnginx.exe")
            s2.WaitForExit()
        End If
       
        Dim s3 As Process() = Process.GetProcessesByName("mysqld")
        If s3.Length > 0 Then
            Dim s4 As Process = Process.Start("C:\nginx\stopsql.exe")
            s4.WaitForExit()
        End If

        Dim s5 As Process() = Process.GetProcessesByName("php-cgi")
        If s5.Length > 0 Then
            Process.Start("C:\nginx\stopphp.exe")

        End If
        Dim w1 As Process() = Process.GetProcessesByName("FileZilla Server")
        If w1.Length > 0 Then
            Dim a1() As Process = Process.GetProcessesByName("FileZilla Server")
            For Each Process1 As Process In a1
                Process1.Kill()
            Next
        End If
        Me.Close()
    End Sub

    Private Sub Button12_Click_1(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        Process.Start("C:\nginx\html")
    End Sub

    Private Sub FWNMP記錄檔ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FWNMP記錄檔ToolStripMenuItem.Click
        'Dim a1 As StreamReader = New StreamReader("C:\nginx\logs\history.txt")
        'MsgBox(a1.ReadToEnd)
        'a1.Close()

        Form6.Show()

    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        Dim a1() As Process = Process.GetProcessesByName("FileZilla Server")
        For Each Process1 As Process In a1
            Process1.Kill()
        Next
        Dim a2 As Process() = Process.GetProcessesByName("FileZilla Server")
        If a2.Length = 0 Then
            write1(vbCrLf + Now + ":" + " " + "FileZilla Server關閉成功")
            Button13.Enabled = False
            Button5.Enabled = True
        Else
            write1(vbCrLf + Now + ":" + " " + "FileZilla Server關閉失敗")
        End If
       
    End Sub

    Private Sub 測試SERVER是否正常ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 測試SERVER是否正常ToolStripMenuItem.Click
        Process.Start("http://127.0.0.1/information.php")
        Process.Start("http://127.0.0.1/phpMyAdmin/index.php")

    End Sub

    Private Sub 開啟MYSQL管理ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub 開啟phpMyAdminToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 開啟phpMyAdminToolStripMenuItem.Click
        Process.Start("http://127.0.0.1/phpMyAdmin/index.php")
    End Sub

    Private Sub 開啟PHP探針ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 開啟PHP探針ToolStripMenuItem.Click
        Process.Start("http://127.0.0.1/information.php")
    End Sub

    Private Sub 說明文件ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 說明文件ToolStripMenuItem.Click
        Process.Start("file:///C:/nginx/fwnmp/help/basic.html")
    End Sub

    Private Sub 關於ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 關於ToolStripMenuItem.Click
        Form8.Show()
    End Sub

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click

        Dim s5 As Process() = Process.GetProcessesByName("php-cgi")
        If s5.Length > 0 Then

            MsgBox("請先關閉PHP")
            Return
        Else
            Form7.Show()

        End If
    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click

        
        Dim myProcess As Process() = Process.GetProcessesByName("mysqld")
        If myProcess.Length > 0 Then

            MsgBox("請先關閉MySql")
            Return
        Else
            Form9.Show()
        End If
    End Sub

    Private Sub 開發文件ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 開發文件ToolStripMenuItem.Click
        MsgBox("目前尚未開放")
    End Sub

    Private Sub 清楚記錄檔ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub FWNMP記錄檔ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles FWNMP記錄檔ToolStripMenuItem1.Click
        Dim rs As StreamWriter = New StreamWriter("C:\nginx\logs\history.txt", False)
        rs.Flush()
        rs.Close()
        MsgBox("刪除完畢")

    End Sub

    Private Sub 錯誤記錄檔ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 錯誤記錄檔ToolStripMenuItem.Click
        If process01("nginx") = 0 Then
            Dim rs As StreamWriter = New StreamWriter("C:\nginx\logs\error.log", False)
            rs.Flush()
            rs.Close()
            MsgBox("刪除完畢")
        Else
            Return
        End If
    End Sub

    Private Sub 連線記錄檔ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 連線記錄檔ToolStripMenuItem.Click
        If process01("nginx") = 0 Then
            Dim rs As StreamWriter = New StreamWriter("C:\nginx\logs\access.log", False)
            rs.Flush()
            rs.Close()
            MsgBox("刪除完畢")
        Else
            Return
        End If
    End Sub

    Private Sub PHP紀錄ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PHP紀錄ToolStripMenuItem.Click
        If process01("php-cgi") = 0 Then
            Dim rs As StreamWriter = New StreamWriter("C:\nginx\php\php.log", False)
            rs.Flush()
            rs.Close()
            MsgBox("刪除完畢")
        Else
            Return
        End If
    End Sub

    Private Sub MySqlToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MySqlToolStripMenuItem.Click
        If process01("mysqld") = 0 Then
            Dim rs As StreamWriter = New StreamWriter("c:\nginx\mysql\data\" + Environ("COMPUTERNAME") + ".err", False)
            rs.Flush()
            rs.Close()
            MsgBox("刪除完畢")
        Else
            Return
        End If
    End Sub

    Private Sub 全部刪除ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 全部刪除ToolStripMenuItem.Click
        MySqlToolStripMenuItem.PerformClick()
        PHP紀錄ToolStripMenuItem.PerformClick()
        連線記錄檔ToolStripMenuItem.PerformClick()
        錯誤記錄檔ToolStripMenuItem.PerformClick()
        FWNMP記錄檔ToolStripMenuItem1.PerformClick()

    End Sub
End Class

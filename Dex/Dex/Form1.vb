﻿Imports System.IO

Public Class Form1
    Dim records(50) As String
    Dim count As Integer
    Dim current As Integer

    Private Sub NewToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem1.Click
        field1.Text = ""
        Field2.Text = ""
        Field3.Text = ""
        Field4.Text = ""
        Field5.Text = ""
        PictureBox1.Image = Nothing
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim outFile As New IO.StreamWriter("data.txt")
        outFile.Write(field1.Text)
        outFile.Write("|")
        outFile.Write(Field2.Text)
        outFile.Write("|")
        outFile.Write(Field3.Text)
        outFile.Write("|")
        outFile.Write(Field4.Text)
        outFile.Write("|")
        outFile.Write(Field5.Text)
        outFile.Write("|")
        outFile.WriteLine(PictureBox1.ImageLocation)
        outFile.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        PictureBox1.Load(OpenFileDialog1.FileName)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists("data.txt") Then
            Dim inFile As New StreamReader("data.txt")
            While Not inFile.EndOfStream
                records(count) = inFile.ReadLine
                count = count + 1
            End While
            inFile.Close()
            showrecord(0)
        End If
    End Sub
    Public Sub showrecord(index As Integer)
        Dim fields() As String
        If records(index) <> Nothing Then
            fields = records(index).Split("|")
        field1.Text = fields(0)
        Field2.Text = fields(1)
        Field3.Text = fields(2)
        Field4.Text = fields(3)
        Field5.Text = fields(4)
            If File.Exists(fields(5)) Then
                PictureBox1.Load(fields(5))

            End If
        End If
    End Sub

    Private Sub firstbutton_Click(sender As Object, e As EventArgs) Handles firstbutton.Click
        current = 0
        showrecord(current)
    End Sub

    Private Sub lastbutton_Click(sender As Object, e As EventArgs) Handles lastbutton.Click
        current = count - 1
        showrecord(current)
    End Sub

    Private Sub prevbutton_Click(sender As Object, e As EventArgs) Handles prevbutton.Click
        If current > 0 Then
            current = current - 1
            showrecord(current)
        End If
    End Sub

    Private Sub nextbutton_Click(sender As Object, e As EventArgs) Handles nextbutton.Click
        If current < count - 1 Then
            current = current + 1
            showrecord(current)
        End If
    End Sub
End Class

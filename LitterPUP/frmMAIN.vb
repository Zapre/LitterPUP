Imports System.Xml
Imports System.Net
Imports System.Text
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Public Class frmMAIN
    Private Sub frmMAIN_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TransparencyKey = Color.Magenta
        Me.Icon = My.Resources.favicon
        loadVER.Text = Application.ProductVersion()
    End Sub

    Private Sub ChromeButton1_Click(sender As Object, e As EventArgs) Handles ChromeButton1.Click
        Dim documentation As String = TextBox1.Text
        Dim paraspace As String = ""
        Dim splitted As String() = documentation.Split(New Char() {"."c})
        Dim newstring As String
        For Each newstring In splitted
            lstSentences.Items.Add(newstring)
        Next
    End Sub

    Private Sub ChromeButton2_Click(sender As Object, e As EventArgs) Handles ChromeButton2.Click
        Dim itemcount As Integer = ListBox1.Items.Count
        If itemcount = 0 Then
            lstSentences.SelectedItem = lstSentences.Items.Item(0)
            Dim asdd As String = ","
            Dim s As String = lstSentences.SelectedItem.ToString()
            Dim words As String() = s.Split(New Char() {" "c})
            Dim word As String
            For Each word In words
                ListBox1.Items.Add(word)
            Next
            ListBox1.SelectedItem = ListBox1.Items.Item(0)
                currentword.Text = ListBox1.SelectedItem.ToString() + ":"
                Dim sourceString As String = New System.Net.WebClient().DownloadString("https://www.dictionaryapi.com/api/v1/references/thesaurus/xml/" + ListBox1.SelectedItem.ToString() + "?key=75f47179-b628-47b6-8745-153180d309e4")
                txtsrc.Text = sourceString
                Dim asd As String = txtsrc.Text
                Dim pattern1 As String = "<syn>(.*)</syn>"
                Dim m As Match = Regex.Match(asd, pattern1)
                If m.Success Then
                    TextBox2.Text = (m.Groups(1).Value)
                End If
                Dim z As String = TextBox2.Text.ToString()
                Dim wordz As String() = z.Split(New Char() {asdd + " "c})
                Dim wordzz As String

                Dim i As Int16 : i = 0
                For Each wordzz In wordz
                    choosewords.Items.Add(wordz(i))
                    i += 1
                Next
            Else
                choosewords.Items.Clear()
            ListBox1.SelectedItem = ListBox1.Items.Item(0)
            currentword.Text = ListBox1.SelectedItem.ToString() + ":"
            Dim sourceString As String = New System.Net.WebClient().DownloadString("https://www.dictionaryapi.com/api/v1/references/thesaurus/xml/" + ListBox1.SelectedItem.ToString() + "?key=75f47179-b628-47b6-8745-153180d309e4")
            txtsrc.Text = sourceString
            Dim asd As String = txtsrc.Text
            Dim pattern1 As String = "<syn>(.*)</syn>"
            Dim m As Match = Regex.Match(asd, pattern1)
            If m.Success Then
                TextBox2.Text = (m.Groups(1).Value)
            End If
            My.Computer.Clipboard.SetText(TextBox2.Text)
            Dim asdd As String = ","
            Dim z As String = TextBox2.Text.ToString()
            Dim wordz As String() = z.Split(New Char() {asdd + " "c})
            Dim wordzz As String

            Dim i As Int16 : i = 0
            For Each wordzz In wordz
                choosewords.Items.Add(wordz(i))
                i += 1
            Next
        End If
    End Sub

    Private Sub ChromeButton3_Click(sender As Object, e As EventArgs) Handles ChromeButton3.Click
        If TextBox1.Text.Contains(ListBox1.SelectedItem.ToString()) Then
            TextBox1.Text = TextBox1.Text.Replace(ListBox1.SelectedItem.ToString(), choosewords.SelectedItem.ToString())
        End If
    End Sub

    Private Sub ChromeButton4_Click(sender As Object, e As EventArgs) Handles ChromeButton4.Click
        Try
            TextBox1.Text = TextBox1.Text.Replace("  ", " ")
            My.Computer.Clipboard.SetText(TextBox1.Text)
            MsgBox("Copied Paragraph to clipboard!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(lstSentences.SelectedItem.ToString())
    End Sub

    Private Sub DeleteSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteSelectedToolStripMenuItem.Click
        lstSentences.Items.Remove(lstSentences.SelectedItem)
    End Sub

    Private Sub DeleteAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteAllToolStripMenuItem.Click
        lstSentences.Items.Clear()
    End Sub

    Private Sub CopyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem1.Click
        My.Computer.Clipboard.SetText(ListBox1.SelectedItem.ToString())
    End Sub

    Private Sub RemoveSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveSelectedToolStripMenuItem.Click
        ListBox1.Items.Remove(ListBox1.SelectedItem)
    End Sub

    Private Sub RemoveAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveAllToolStripMenuItem.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub NextSentenceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NextSentenceToolStripMenuItem.Click
        ListBox1.Items.Clear()
        lstSentences.SelectedItem = lstSentences.Items.Item(0)
        lstSentences.Items.Remove(lstSentences.SelectedItem)
        lstSentences.SelectedItem = lstSentences.Items.Item(0)
        lstSentences.SelectedItem = lstSentences.Items.Item(0)
        Dim asdd As String = ","
        Dim s As String = lstSentences.SelectedItem.ToString()
        Dim words As String() = s.Split(New Char() {" "c})
        Dim word As String
        For Each word In words
            ListBox1.Items.Add(word)
        Next
    End Sub

    Private Sub frmMAIN_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Delete Then
            ListBox1.Items.Remove(ListBox1.SelectedItem)
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://youtube.com/c/zapre/")
        System.Diagnostics.Process.Start("https://github.com/zapre/")
    End Sub
End Class
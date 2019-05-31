Imports System.Windows.Forms

Public Class frm_options
  Dim isFirstLaunch As Boolean

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    glob.saveTuttiFrutti(Me)
    If chkAccept.Checked Then glob.para("acceptedTerms") = "true"
    glob.saveParaFile()

    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub frm_options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    glob.readTuttiFrutti(Me)
    RichTextBox1.Rtf = My.Resources.HelpText

    If glob.para("progRegistered", "false") = "true" Then
      labReg.Text = "Registriert für: " + glob.para("progRegName") + vbNewLine + "Vielen Dank!"
      labReg.Font = New Font(labReg.Font, FontStyle.Bold)
      labReg.ForeColor = Color.Black
      labReg.Cursor = Cursors.Default
    Else
      labReg.Text = "Bitte registriere deine Version ..."
      labReg.Font = New Font(labReg.Font, FontStyle.Bold Or FontStyle.Underline)
      labReg.ForeColor = Color.Blue
      labReg.Cursor = Cursors.Hand
    End If
  End Sub

  Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    Process.Start(sender.text)
  End Sub

  Private Sub RichTextBox1_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
    Dim txt = e.LinkText
    If txt.StartsWith("file://") Then
      Dim arg = "/e,""" + txt.Substring(7).Replace("/", "\") + """"
      Process.Start("explorer.exe", arg)
    Else
      Process.Start(txt)
    End If
  End Sub

  Property firstLaunch() As Boolean
    Get
      Return isFirstLaunch
    End Get
    Set(ByVal value As Boolean)
      chkAccept.Visible = value
      chkAccept.Checked = False
      OK_Button.Enabled = False

      Cancel_Button.Enabled = Not value
      Button1.Visible = value

      labReg.Visible = Not value
      isFirstLaunch = value
    End Set
  End Property

  Property startup() As Boolean
    Get

    End Get
    Set(ByVal value As Boolean)
      labReg.Visible = Not value

      If value Then
        chkDontRegister.Visible = False
      Else
        chkDontRegister.Visible = glob.para("progRegistered", "false") <> "true"
      End If

      If glob.para("frm_options__chkDontRegister") = "TRUE" And firstLaunch = False Then
        labReg.Visible = True
      End If
    End Set
  End Property

  Private Sub chkAccept_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAccept.CheckedChanged
    If chkAccept.Visible Then
      OK_Button.Enabled = chkAccept.Checked
    Else
      OK_Button.Enabled = True
    End If
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    End

  End Sub

  Private Sub rbFiletype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFiletype__png.Click, rbFiletype__jpg.Click, rbFiletype__bmp.Click
    txtBmpPath.Text = IO.Path.ChangeExtension(txtBmpPath.Text, sender.tag)
  End Sub

  Function getFiletype() As RadioButton
    If rbFiletype__bmp.Checked Then : Return rbFiletype__bmp
    ElseIf rbFiletype__jpg.Checked Then : Return rbFiletype__jpg
    ElseIf rbFiletype__png.Checked Then : Return rbFiletype__png
    End If
  End Function

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    Using sfd As New SaveFileDialog
      Dim rb = getFiletype()
      sfd.Filter = rb.Text + " (*." + rb.Tag + ")|*." + rb.Tag
      sfd.FileName = txtBmpPath.Text
      If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
        txtBmpPath.Text = sfd.FileName
      End If
    End Using
  End Sub

  Private Sub labReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles labReg.Click
    If labReg.Cursor = Cursors.Hand Then
      frm_reg.ShowDialog()

    End If
  End Sub
End Class

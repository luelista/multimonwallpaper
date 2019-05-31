Public Class frm_reg

  Public Function SendRegistration(ByVal user As String, ByVal mail As String, ByVal info As String) As Boolean
    Dim data = "U=" + stringToBase64(user) + "&E=" + stringToBase64(mail) + "&I=" + stringToBase64(info) + "&PC=" + stringToBase64(My.User.Name) + "&D=" + stringToBase64(glob.para("progRegDate"))

    Dim ok As String = TwAjax.postUrl("https://secure.teamwiki.net/q/mw_app_register.php?app=MultimonWallpaper", "v=" + My.Application.Info.Version.ToString + "&" + data)
    If ok.Contains("<result>success</result>") Then
      Return True
    End If
  End Function

  Private Sub btnLater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLater.Click
    Me.Close()
  End Sub

  Private Sub btnReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReg.Click
    glob.para("progRegistered") = "true"

    glob.para("progRegName") = TextBox1.Text
    glob.para("progRegEMail") = TextBox2.Text
    glob.para("progRegDate") = Now.ToLongDateString + " " + Now.ToLongTimeString
    glob.para("progRegInfo") = If(CheckBox1.Checked, "MailOK=TRUE", "MailOK=FALSE")

    Me.Enabled = False

    Dim ok = SendRegistration(glob.para("progRegName"), glob.para("progRegEMail"), glob.para("progRegInfo"))

    If ok Then
      glob.para("progRegisteredDone") = "true"
      Me.Enabled = True
      btnReg.Visible = False
      btnLater.Text = "OK"
      Panel1.Enabled = False
      Label3.Text = "VIELEN DANK, DASS DU MULTIMONWALLPAPER REGISTRIERT HAST!"
    Else

      Me.Enabled = True
      btnReg.Visible = False
      btnLater.Text = "OK"
      Panel1.Enabled = False
      Label3.Text = "VIELEN DANK, DASS DU MULTIMONWALLPAPER REGISTRIERT HAST!" + vbNewLine + "Die Daten konnten nicht übertragen werden, es wird später wieder versucht ..."


    End If

  End Sub

  Function stringToBase64(ByVal str As String) As String
    If String.IsNullOrEmpty(str) Then Return ""
    Dim b = System.Text.Encoding.Default.GetBytes(str)
    Return Convert.ToBase64String(b)
  End Function

  Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged, TextBox1.TextChanged
    btnReg.Enabled = TextBox1.TextLength > 3 Or TextBox2.TextLength > 3
  End Sub
End Class
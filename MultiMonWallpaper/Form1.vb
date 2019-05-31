Public Class Form1

  ' Das nimmt langsam ueberhand mit den Arrays -- sollte auf eine Structure umgestellt werden...
  Dim monWidth(), monHeight(), gesamtWidth, gesamtHeight As Integer
  Dim scr() As Screen, thumb() As Image, thumbRect() As Rectangle

  Dim minX, minY, maxX, maxY As Integer
  Dim monProp(), gesamtProp As Single
  Dim dragOK = False
  Dim picFile() As String, picFileSize() As Size, picStretch() As Boolean, picBg() As Color

  Dim recentFiles As New List(Of recentFile)
  Dim rcDragStartPos As Point

  Dim WithEvents bgwApply As New System.ComponentModel.BackgroundWorker()

  Structure recentFile
    Public fileSpec As String, thumb As Image, imgSize As Size
    Public Sub New(ByVal imgFilespec As String)
      fileSpec = imgFilespec
      Using img = Image.FromFile(imgFilespec)
        imgSize = img.Size
        thumb = New Bitmap(120, 80)
        Dim g As Graphics = Graphics.FromImage(thumb)
        g.DrawImage(img, 0, 0, 120, 80)
        g.Dispose()
      End Using
    End Sub
  End Structure

  Dim dropDstPicIndex As Integer = -1

  Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    glob.saveFormPos(Me)
    glob.saveTuttiFrutti(Me)
  End Sub

  Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.F5 Or (e.Control And e.KeyCode = Keys.R) Then
      getScreensizes()
      calculateThumbSize()
      loadPictureFiles()
    End If
    If e.KeyCode = Keys.F1 Then
      frm_options.firstLaunch = False
      frm_options.startup = False
      frm_options.ShowDialog()
    End If
    If e.KeyCode = Keys.F2 Then
      ApplyWallpaper()
    End If
  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    glob.readFormPos(Me)

    Me.Text = "MultiMonWallpaper " + My.Application.Info.Version.ToString(2)

    If Screen.AllScreens.Length < 2 Then
      Me.Enabled = False
      Show()
      MsgBox("Dieses Programm ist nur für Multimonitor-Systeme geeignet und sinnvoll!" + vbNewLine + _
             "Bitte einen zweiten Monitor kaufen ...", MsgBoxStyle.Exclamation)

      ' Application.Exit()
    End If

    getScreensizes()
    calculateThumbSize()
    loadPictureFiles()

    Dim lst() As String = Split(glob.para("recentFiles"), vbNewLine)
    For Each item In lst
      If IO.File.Exists(item) Then
        recentFiles.Add(New recentFile(item))
      End If
    Next
  End Sub
  Sub getScreensizes()
    scr = Screen.AllScreens
    Dim max = scr.Length - 1
    ReDim monWidth(max), monHeight(max), monProp(max), picFile(max), picFileSize(max), picStretch(max), picBg(max), thumb(max), thumbRect(max)

    pbDisplay.Controls.Clear()
    Dim r As New Random

    For i = 0 To max
      monWidth(i) = scr(i).Bounds.Width
      monHeight(i) = scr(i).Bounds.Height
      minX = Math.Min(minX, scr(i).Bounds.X)
      minY = Math.Min(minY, scr(i).Bounds.Y)
      maxX = Math.Max(maxX, scr(i).Bounds.Right)
      maxY = Math.Max(maxY, scr(i).Bounds.Bottom)

      picFile(i) = glob.para("picFile" & i)
      picStretch(i) = glob.para("picStretch" & i, "true") = "true"
      Try
        picBg(i) = ColorTranslator.FromHtml(glob.para("picBgColor" & i, "#000011"))
      Catch : picBg(i) = Color.Maroon : End Try

      'pcb(i) = New PictureBox
      'pcb(i).BackColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))
      'Panel1.Controls.Add(pcb(i))
    Next

    gesamtWidth = maxX - minX
    gesamtHeight = maxY - minY


  End Sub

  Sub calculateThumbSize()
    If gesamtWidth = 0 Then Exit Sub

    Dim scale As Double = pbDisplay.Width / gesamtWidth
    Dim hght As Integer = gesamtHeight * scale

    ' pbDisplay.Height = hght

    Dim bnd As Rectangle

    For i = 0 To scr.Length - 1
      bnd = scr(i).Bounds
      thumbRect(i) = New Rectangle((bnd.Left - minX) * scale + 2, _
                                   (bnd.Top - minY) * scale + 2, _
                                   bnd.Width * scale - 4, _
                                   bnd.Height * scale - 4)
    Next

  End Sub

  Sub loadPictureFiles()
    For i = 0 To scr.Length - 1
      If String.IsNullOrEmpty(picFile(i)) OrElse IO.File.Exists(picFile(i)) = False Then
        picFileSize(i) = Nothing : thumb(i) = Nothing : Continue For
      End If
      Using img = Image.FromFile(picFile(i))
        picFileSize(i) = img.Size
        thumb(i) = img.GetThumbnailImage(thumbRect(i).Width, thumbRect(i).Height, Nothing, IntPtr.Zero)
      End Using
    Next
    pbDisplay.Invalidate()
  End Sub

  Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    If Me.WindowState = FormWindowState.Minimized Then Exit Sub
    'Me.Height = Me.Width * gesamtProp
    calculateThumbSize()
    pbDisplay.Invalidate()
  End Sub

  Private Sub Panel1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbDisplay.DragDrop
    dropDstPicIndex = -1
    If dragOK Then
      Dim pt As Point = pbDisplay.PointToClient(New Point(e.X, e.Y))
      Dim idx = getMonitorIdxFromThumbPos(pt.X, pt.Y)
      If idx > -1 Then
        setBgImage(idx, e.Data.GetData("FileDrop")(0))
      End If
    End If
  End Sub

  Sub setBgImage(ByVal idx As Integer, ByVal fileSpec As String)
    picFile(idx) = fileSpec : glob.para("picFile" & idx) = fileSpec
    addRecentFile(fileSpec)
    loadPictureFiles()

    If glob.para("frm_options__chkAutoApply") = "TRUE" Then
      ApplyWallpaper()
    End If
  End Sub

  Private Sub Panel1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbDisplay.DragEnter
    dragOK = False
    dropDstPicIndex = -1
    If e.Data.GetDataPresent("FileDrop") Then
      Dim fileName As String = e.Data.GetData("FileDrop")(0).toupper
      If fileName.EndsWith(".JPG") Or fileName.EndsWith(".PNG") Or fileName.EndsWith(".JPEG") Or fileName.EndsWith(".BMP") Then
        dragOK = True
      End If
    End If
  End Sub

  Private Sub Panel1_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbDisplay.DragLeave
    dropDstPicIndex = -1
    pbDisplay.Invalidate()
  End Sub

  Private Sub Panel1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbDisplay.DragOver
    If dragOK Then
      Dim pt As Point = pbDisplay.PointToClient(New Point(e.X, e.Y))
      Dim idx = getMonitorIdxFromThumbPos(pt.X, pt.Y)
      If dropDstPicIndex = idx Then Exit Sub
      dropDstPicIndex = idx

      If idx = -1 Then
        e.Effect = DragDropEffects.None
      Else
        e.Effect = DragDropEffects.Copy
      End If
      pbDisplay.Invalidate()
    End If
  End Sub

  Function getMonitorIdxFromThumbPos(ByVal x As Integer, ByVal y As Integer) As Integer
    For I = 0 To scr.Length - 1
      If thumbRect(I).Contains(x, y) Then
        Return I
      End If
    Next
    Return -1
  End Function

  Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbDisplay.Paint
    Dim fnt As New Font("Microsoft Sans Serif", 8, FontStyle.Regular, GraphicsUnit.Point)
    Dim dfltPen As New Pen(Color.Black, 1)
    Dim actPen As New Pen(Color.FromArgb(20, 20, 1), 4)

    Dim rct As Rectangle
    For i = 0 To scr.Length - 1
      rct = thumbRect(i)

      If thumb(i) IsNot Nothing Then
        e.Graphics.DrawImage(thumb(i), rct)

        Dim txt = picFile(i) & vbNewLine & _
                  "Datei: " & picFileSize(i).Width & "x" & picFileSize(i).Height & _
                  "   Screen: " & scr(i).Bounds.Width & "x" & scr(i).Bounds.Height
        If picFileSize(i).Width < scr(i).Bounds.Width Or picFileSize(i).Height < scr(i).Bounds.Height Then _
          txt &= vbNewLine & "Achtung: Datei kleiner als Bildschirm"

        rct.Offset(1, 1)
        e.Graphics.DrawString(txt, fnt, Brushes.White, rct)
        e.Graphics.DrawString(txt, fnt, Brushes.Black, thumbRect(i))

      End If

      e.Graphics.DrawRectangle(dfltPen, rct)

    Next

    If dropDstPicIndex > -1 Then
      Dim br As New SolidBrush(Color.FromArgb(160, 255, 255, 155))
      e.Graphics.FillRectangle(br, thumbRect(dropDstPicIndex))
      e.Graphics.DrawRectangle(actPen, thumbRect(dropDstPicIndex))
      br.Dispose()
    End If
    dfltPen.Dispose() : actPen.Dispose()
    fnt.Dispose()
  End Sub


  Sub ApplyWallpaper()
    Try
      Using rk As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\Desktop", True)
        If rk.GetValue("TileWallpaper") <> 1 Then
          If MsgBoxResult.Yes = MsgBox("Damit MultiMonWallpaper funktioniert, muss der Anzeigemodus des Hintergrundbildes auf ""Nebeneinander"" geändert werden." + vbNewLine + vbNewLine + "Soll diese Änderung jetzt durchgeführt werden?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Frage") Then
            rk.SetValue("TileWallpaper", "1", Microsoft.Win32.RegistryValueKind.String)
            rk.SetValue("WallpaperStyle", "0", Microsoft.Win32.RegistryValueKind.String)
          Else
            Exit Sub
          End If
        End If
      End Using

      btnApply.Enabled = False

      If bgwApply.IsBusy Then
        tmrPendingApplyRequest.Start()
      Else
        bgwApply.RunWorkerAsync()
      End If

    Catch ex As Exception
      MsgBox("Leider ist irgendwas schiefgegangen und das Hintergrundbild konnte nicht geändert werden!" + vbNewLine + vbNewLine + ex.Message, MsgBoxStyle.Critical, "Fehler (a)")
      btnApply.Enabled = True
    End Try
  End Sub
  Private Sub tmrPendingApplyRequest_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPendingApplyRequest.Tick
    If bgwApply.IsBusy = False Then
      tmrPendingApplyRequest.Enabled = False
      bgwApply.RunWorkerAsync()
    End If
  End Sub
  Private Sub bgwApply_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwApply.DoWork
    Try
      e.Result = New Object() {Nothing, Nothing, Nothing}

      Dim wallpaper As New Bitmap(gesamtWidth, Math.Max(monHeight(0), monHeight(1)))
      Dim g = Graphics.FromImage(wallpaper)

      Dim tmpImg As Image, bnd As Rectangle
      For i = 0 To scr.Length - 1
        bnd = scr(i).Bounds

        Dim b As New SolidBrush(picBg(i))
        g.FillRectangle(b, bnd.X - minX, bnd.Y - minY, bnd.Width, bnd.Height)
        b.Dispose()

        If String.IsNullOrEmpty(picFile(i)) Then
          ' Kein Bild angegeben

        ElseIf IO.File.Exists(picFile(i)) = False Then
          ' Bilddatei existiert nicht
          g.DrawString("File not found", New Font("Courier New", 60, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point), Brushes.White, bnd.X - minX + 150, bnd.Y - minY + 300)

        Else
          ' Bild kann gezeichnet werden
          tmpImg = Image.FromFile(picFile(i))

          If picStretch(i) Then
            g.DrawImage(tmpImg, bnd.X - minX, bnd.Y - minY, bnd.Width, bnd.Height)
          Else
            DrawImageUnscaledAndCentered(tmpImg, g, New Rectangle(bnd.X - minX, bnd.Y - minY, bnd.Width, bnd.Height))
          End If

          tmpImg.Dispose()
        End If

      Next

      Dim targetFilespec As String = glob.para("frm_options__txtBmpPath", "C:\Windows\web\composed_wallpaper.bmp")
      Dim fmt As Imaging.ImageFormat
      Select Case glob.para("frm_options__rbFiletype", "bmp")
        Case "bmp" : fmt = Imaging.ImageFormat.Bmp
        Case "jpg" : fmt = Imaging.ImageFormat.Jpeg
        Case "png" : fmt = Imaging.ImageFormat.Png
      End Select
      wallpaper.Save(targetFilespec, fmt)
      changeSystemWallpaper(targetFilespec)



      wallpaper.Dispose()

    Catch ex As Exception
      e.Result(1) = "Leider ist irgendwas schiefgegangen und das Hintergrundbild konnte nicht geändert werden!" + vbNewLine + vbNewLine + ex.Message
    End Try

  End Sub

  Private Sub bgwApply_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwApply.RunWorkerCompleted
    Dim res() As Object = e.Result
    If res(1) IsNot Nothing Then
      MsgBox(res(1), MsgBoxStyle.Critical, "Fehler (b)")
    End If
    btnApply.Enabled = True
  End Sub

  Function phyt(ByVal pt1 As Point, ByVal pt2 As Point) As Integer
    Return Math.Sqrt((pt1.X - pt2.X) ^ 2 + (pt1.Y - pt2.Y) ^ 2)
  End Function

  Private Sub pbLastUsed_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbLastUsed.MouseDoubleClick
    Dim idx As Integer = rcDragStartPos.X \ 125
    If idx >= recentFiles.Count Then Exit Sub

    Dim f As recentFile = recentFiles(idx)

    Process.Start(f.fileSpec)
  End Sub

  Private Sub pbLastUsed_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbLastUsed.MouseDown
    rcDragStartPos = e.Location
  End Sub

  Private Sub pbLastUsed_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbLastUsed.MouseMove
    If e.Button = Windows.Forms.MouseButtons.Left AndAlso phyt(rcDragStartPos, e.Location) > 7 Then
      Dim dat As New DataObject
      Dim idx As Integer = rcDragStartPos.X \ 125
      If idx >= recentFiles.Count Then Exit Sub

      Dim f As recentFile = recentFiles(idx)

      dat.SetText(f.fileSpec)
      dat.SetImage(f.thumb)
      dat.SetData("FileDrop", New String() {f.fileSpec})
      pbLastUsed.DoDragDrop(dat, DragDropEffects.All)
    End If
  End Sub

  Private Sub pbLastUsed_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbLastUsed.Paint
    Dim txt As String
    Dim rct As Rectangle, fnt As New Font("Microsoft Sans Serif", 8, FontStyle.Bold, GraphicsUnit.Point)
    rct.Width = 115 : rct.Height = 80

    For i = 0 To recentFiles.Count - 1
      e.Graphics.DrawImageUnscaled(recentFiles(i).thumb, i * 125, 0)

      txt = recentFiles(i).imgSize.Width & "x" & recentFiles(i).imgSize.Height
      rct.X = i * 125 + 5 : rct.Y = 5
      e.Graphics.DrawString(txt, fnt, Brushes.White, rct)
      rct.Offset(-1, -1)
      e.Graphics.DrawString(txt, fnt, Brushes.Black, rct)
    Next

    fnt.Dispose()
  End Sub

  Sub addRecentFile(ByVal fs As String)
    If String.IsNullOrEmpty(fs) Then Exit Sub

    For i = 0 To recentFiles.Count - 1
      If recentFiles(i).fileSpec.ToLower = LCase(fs) Then
        Dim f = recentFiles(i)
        recentFiles.RemoveAt(i)
        recentFiles.Insert(0, f)
        pbLastUsed.Invalidate()
        Exit Sub
      End If
    Next

    recentFiles.Insert(0, New recentFile(fs))
    pbLastUsed.Invalidate()

    Dim max As Integer = Math.Min(recentFiles.Count - 1, 20)
    Dim out(max) As String
    For i = 0 To max
      out(i) = recentFiles(i).fileSpec
    Next
    glob.para("recentFiles") = Join(out, vbNewLine)
  End Sub

  Private Sub pbLastUsed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbLastUsed.Click

  End Sub

  Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
    frm_options.firstLaunch = False
    frm_options.startup = False
    frm_options.ShowDialog()
  End Sub

  Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
    ApplyWallpaper()
  End Sub

  Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

    If glob.para("acceptedTerms", "false") <> "true" Then
      frm_options.firstLaunch = True
      frm_options.startup = True
      frm_options.ShowDialog()

    ElseIf glob.para("frm_options__chkShowAlways", "TRUE") = "TRUE" Then
      frm_options.firstLaunch = False
      frm_options.startup = True
      frm_options.ShowDialog()
    End If




    If glob.para("progRegistered", "false") <> "true" And glob.para("frm_options__chkDontRegister") <> "TRUE" Then
      frm_reg.ShowDialog()

    Else
      If glob.para("progRegisteredDone", "false") <> "true" Then

        Dim ok = frm_reg.SendRegistration(glob.para("progRegName"), glob.para("progRegEMail"), glob.para("progRegInfo"))

        If ok Then
          glob.para("progRegisteredDone") = "true"
          frm_reg.Enabled = True
          frm_reg.btnReg.Visible = False
          frm_reg.btnLater.Text = "OK"
          frm_reg.Panel1.Enabled = False
          frm_reg.Label3.Text = "VIELEN DANK, DASS DU MULTIMONWALLPAPER REGISTRIERT HAST!" + vbNewLine + "Deine Registrierungsdaten wurden jetzt erfolgreich übertragen!"
          frm_reg.ShowDialog()
        End If
      End If
    End If


  End Sub

  Private Sub pbDisplay_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbDisplay.MouseDoubleClick
    If e.Button <> Windows.Forms.MouseButtons.Left Then Exit Sub

    Dim idx = getMonitorIdxFromThumbPos(e.X, e.Y)
    If idx = -1 Then Exit Sub

    onMonitorWallpaperSelect(idx)
  End Sub

  Sub onMonitorWallpaperSelect(ByVal idx As Integer)

    Using ofd As New OpenFileDialog
      ofd.Title = "Wähle ein Hintergrundbild für Bildschirm " + scr(idx).DeviceName + " ..."
      ofd.FileName = picFile(idx)
      ofd.Filter = "Bilddateien (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp"
      If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
        setBgImage(idx, ofd.FileName)
      End If
    End Using

  End Sub

  Private Sub pbDisplay_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbDisplay.MouseUp

  End Sub

  Private Sub pbDisplay_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbDisplay.MouseClick
    If e.Button = Windows.Forms.MouseButtons.Right Then
      Dim idx = getMonitorIdxFromThumbPos(e.X, e.Y)
      If idx = -1 Then Exit Sub

      ContextMenuStrip1.Tag = idx
      DISPLAYNAMEToolStripMenuItem.Text = scr(idx).DeviceName
      AnBildschirmAnpassenToolStripMenuItem.Checked = picStretch(idx)
      ContextMenuStrip1.Show(sender, e.Location)

    End If
  End Sub

  Private Sub DateiOeffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateiOeffnenToolStripMenuItem.Click
    Dim idx As Integer = ContextMenuStrip1.Tag
    onMonitorWallpaperSelect(idx)
  End Sub

  Private Sub AuswahlEntfernenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuswahlEntfernenToolStripMenuItem.Click
    Dim idx As Integer = ContextMenuStrip1.Tag
    setBgImage(idx, "")
    ApplyWallpaper()
  End Sub

  Private Sub AnBildschirmAnpassenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnBildschirmAnpassenToolStripMenuItem.Click
    Dim idx As Integer = ContextMenuStrip1.Tag
    picStretch(idx) = Not picStretch(idx)
    glob.para("picStretch" & idx) = If(picStretch(idx), "true", "false")
    ApplyWallpaper()
  End Sub

  Private Sub HintergrundfarbeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HintergrundfarbeToolStripMenuItem.Click
    Dim idx As Integer = ContextMenuStrip1.Tag
    Using c As New ColorDialog
      c.Color = picBg(idx)
      c.FullOpen = True
      If c.ShowDialog = Windows.Forms.DialogResult.OK Then
        picBg(idx) = c.Color
        glob.para("picBgColor" & idx) = ColorTranslator.ToHtml(c.Color)
        ApplyWallpaper()
      End If
    End Using
  End Sub

End Class

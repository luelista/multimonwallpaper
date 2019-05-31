<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_options
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
    Me.OK_Button = New System.Windows.Forms.Button
    Me.Cancel_Button = New System.Windows.Forms.Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.txtBmpPath = New System.Windows.Forms.TextBox
    Me.rbFiletype__bmp = New System.Windows.Forms.RadioButton
    Me.Label2 = New System.Windows.Forms.Label
    Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
    Me.rbFiletype__jpg = New System.Windows.Forms.RadioButton
    Me.rbFiletype__png = New System.Windows.Forms.RadioButton
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.chkAccept = New System.Windows.Forms.CheckBox
    Me.Button1 = New System.Windows.Forms.Button
    Me.chkShowAlways = New System.Windows.Forms.CheckBox
    Me.Button2 = New System.Windows.Forms.Button
    Me.labReg = New System.Windows.Forms.Label
    Me.chkAutoApply = New System.Windows.Forms.CheckBox
    Me.chkDontRegister = New System.Windows.Forms.CheckBox
    Me.TableLayoutPanel1.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(329, 456)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(189, 29)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'OK_Button
    '
    Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
    Me.OK_Button.Location = New System.Drawing.Point(3, 3)
    Me.OK_Button.Name = "OK_Button"
    Me.OK_Button.Size = New System.Drawing.Size(88, 23)
    Me.OK_Button.TabIndex = 0
    Me.OK_Button.Text = "OK"
    '
    'Cancel_Button
    '
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Cancel_Button.Location = New System.Drawing.Point(97, 3)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(89, 23)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "Abbrechen"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(10, 22)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(181, 13)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Zielpfad für zusammengesetztes Bild:"
    '
    'txtBmpPath
    '
    Me.txtBmpPath.Location = New System.Drawing.Point(13, 38)
    Me.txtBmpPath.Name = "txtBmpPath"
    Me.txtBmpPath.Size = New System.Drawing.Size(431, 20)
    Me.txtBmpPath.TabIndex = 2
    Me.txtBmpPath.Text = "C:\Windows\web\composed_wallpaper.bmp"
    '
    'rbFiletype__bmp
    '
    Me.rbFiletype__bmp.AutoSize = True
    Me.rbFiletype__bmp.Checked = True
    Me.rbFiletype__bmp.Location = New System.Drawing.Point(76, 65)
    Me.rbFiletype__bmp.Name = "rbFiletype__bmp"
    Me.rbFiletype__bmp.Size = New System.Drawing.Size(57, 17)
    Me.rbFiletype__bmp.TabIndex = 3
    Me.rbFiletype__bmp.TabStop = True
    Me.rbFiletype__bmp.Tag = "bmp"
    Me.rbFiletype__bmp.Text = "Bitmap"
    Me.rbFiletype__bmp.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(10, 67)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(49, 13)
    Me.Label2.TabIndex = 4
    Me.Label2.Text = "Dateityp:"
    '
    'RichTextBox1
    '
    Me.RichTextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.RichTextBox1.BackColor = System.Drawing.Color.White
    Me.RichTextBox1.Location = New System.Drawing.Point(16, 13)
    Me.RichTextBox1.Name = "RichTextBox1"
    Me.RichTextBox1.ReadOnly = True
    Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
    Me.RichTextBox1.ShortcutsEnabled = False
    Me.RichTextBox1.ShowSelectionMargin = True
    Me.RichTextBox1.Size = New System.Drawing.Size(500, 234)
    Me.RichTextBox1.TabIndex = 5
    Me.RichTextBox1.Text = ""
    '
    'rbFiletype__jpg
    '
    Me.rbFiletype__jpg.AutoSize = True
    Me.rbFiletype__jpg.Location = New System.Drawing.Point(150, 65)
    Me.rbFiletype__jpg.Name = "rbFiletype__jpg"
    Me.rbFiletype__jpg.Size = New System.Drawing.Size(52, 17)
    Me.rbFiletype__jpg.TabIndex = 6
    Me.rbFiletype__jpg.Tag = "jpg"
    Me.rbFiletype__jpg.Text = "JPEG"
    Me.rbFiletype__jpg.UseVisualStyleBackColor = True
    '
    'rbFiletype__png
    '
    Me.rbFiletype__png.AutoSize = True
    Me.rbFiletype__png.Location = New System.Drawing.Point(219, 65)
    Me.rbFiletype__png.Name = "rbFiletype__png"
    Me.rbFiletype__png.Size = New System.Drawing.Size(48, 17)
    Me.rbFiletype__png.TabIndex = 7
    Me.rbFiletype__png.Tag = "png"
    Me.rbFiletype__png.Text = "PNG"
    Me.rbFiletype__png.UseVisualStyleBackColor = True
    '
    'GroupBox1
    '
    Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox1.Controls.Add(Me.chkAutoApply)
    Me.GroupBox1.Controls.Add(Me.Button2)
    Me.GroupBox1.Controls.Add(Me.rbFiletype__png)
    Me.GroupBox1.Controls.Add(Me.rbFiletype__jpg)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.rbFiletype__bmp)
    Me.GroupBox1.Controls.Add(Me.txtBmpPath)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Location = New System.Drawing.Point(16, 259)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(500, 130)
    Me.GroupBox1.TabIndex = 8
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Einstellungen"
    '
    'chkAccept
    '
    Me.chkAccept.AutoSize = True
    Me.chkAccept.Location = New System.Drawing.Point(16, 432)
    Me.chkAccept.Name = "chkAccept"
    Me.chkAccept.Size = New System.Drawing.Size(312, 17)
    Me.chkAccept.TabIndex = 9
    Me.chkAccept.Text = "Ich habe alle Hinweise gelesen und bin damit einverstanden."
    Me.chkAccept.UseVisualStyleBackColor = True
    Me.chkAccept.Visible = False
    '
    'Button1
    '
    Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Button1.Location = New System.Drawing.Point(16, 459)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(133, 23)
    Me.Button1.TabIndex = 10
    Me.Button1.Text = "Beenden"
    Me.Button1.UseVisualStyleBackColor = True
    Me.Button1.Visible = False
    '
    'chkShowAlways
    '
    Me.chkShowAlways.AutoSize = True
    Me.chkShowAlways.Checked = True
    Me.chkShowAlways.CheckState = System.Windows.Forms.CheckState.Checked
    Me.chkShowAlways.Location = New System.Drawing.Point(16, 408)
    Me.chkShowAlways.Name = "chkShowAlways"
    Me.chkShowAlways.Size = New System.Drawing.Size(180, 17)
    Me.chkShowAlways.TabIndex = 11
    Me.chkShowAlways.Text = "Fenster bei jedem Start anzeigen"
    Me.chkShowAlways.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(451, 36)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(38, 23)
    Me.Button2.TabIndex = 8
    Me.Button2.Text = "..."
    Me.Button2.UseVisualStyleBackColor = True
    '
    'labReg
    '
    Me.labReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.labReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.labReg.Location = New System.Drawing.Point(16, 440)
    Me.labReg.Name = "labReg"
    Me.labReg.Size = New System.Drawing.Size(268, 42)
    Me.labReg.TabIndex = 12
    Me.labReg.Text = "Noch nicht registriert ..."
    Me.labReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    Me.labReg.Visible = False
    '
    'chkAutoApply
    '
    Me.chkAutoApply.AutoSize = True
    Me.chkAutoApply.Location = New System.Drawing.Point(13, 98)
    Me.chkAutoApply.Name = "chkAutoApply"
    Me.chkAutoApply.Size = New System.Drawing.Size(188, 17)
    Me.chkAutoApply.TabIndex = 9
    Me.chkAutoApply.Text = "Hintergrundbild sofort übernehmen"
    Me.chkAutoApply.UseVisualStyleBackColor = True
    '
    'chkDontRegister
    '
    Me.chkDontRegister.AutoSize = True
    Me.chkDontRegister.Location = New System.Drawing.Point(235, 408)
    Me.chkDontRegister.Name = "chkDontRegister"
    Me.chkDontRegister.Size = New System.Drawing.Size(238, 17)
    Me.chkDontRegister.TabIndex = 13
    Me.chkDontRegister.Text = "Ich möchte meine Version NICHT registrieren"
    Me.chkDontRegister.UseVisualStyleBackColor = True
    '
    'frm_options
    '
    Me.AcceptButton = Me.OK_Button
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel_Button
    Me.ClientSize = New System.Drawing.Size(530, 497)
    Me.Controls.Add(Me.chkDontRegister)
    Me.Controls.Add(Me.labReg)
    Me.Controls.Add(Me.chkShowAlways)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.chkAccept)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.RichTextBox1)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_options"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Einstellungen"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtBmpPath As System.Windows.Forms.TextBox
  Friend WithEvents rbFiletype__bmp As System.Windows.Forms.RadioButton
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
  Friend WithEvents rbFiletype__jpg As System.Windows.Forms.RadioButton
  Friend WithEvents rbFiletype__png As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents chkAccept As System.Windows.Forms.CheckBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents chkShowAlways As System.Windows.Forms.CheckBox
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents labReg As System.Windows.Forms.Label
  Friend WithEvents chkAutoApply As System.Windows.Forms.CheckBox
  Friend WithEvents chkDontRegister As System.Windows.Forms.CheckBox

End Class

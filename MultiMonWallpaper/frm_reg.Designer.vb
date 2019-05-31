<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reg
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reg))
    Me.Label5 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.TextBox2 = New System.Windows.Forms.TextBox
    Me.btnReg = New System.Windows.Forms.Button
    Me.btnLater = New System.Windows.Forms.Button
    Me.CheckBox1 = New System.Windows.Forms.CheckBox
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(5, 37)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(80, 13)
    Me.Label5.TabIndex = 2
    Me.Label5.Text = "E-Mail-Adresse:"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(5, 11)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(38, 13)
    Me.Label4.TabIndex = 1
    Me.Label4.Text = "Name:"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(70, 13)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(397, 58)
    Me.Label3.TabIndex = 0
    Me.Label3.Text = resources.GetString("Label3.Text")
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(12, 17)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox1.TabIndex = 3
    Me.PictureBox1.TabStop = False
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(121, 8)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(271, 20)
    Me.TextBox1.TabIndex = 4
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(121, 34)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(271, 20)
    Me.TextBox2.TabIndex = 5
    '
    'btnReg
    '
    Me.btnReg.Enabled = False
    Me.btnReg.Location = New System.Drawing.Point(173, 68)
    Me.btnReg.Name = "btnReg"
    Me.btnReg.Size = New System.Drawing.Size(135, 23)
    Me.btnReg.TabIndex = 6
    Me.btnReg.Text = "Jetzt registrieren!"
    Me.btnReg.UseVisualStyleBackColor = True
    '
    'btnLater
    '
    Me.btnLater.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnLater.Location = New System.Drawing.Point(378, 138)
    Me.btnLater.Name = "btnLater"
    Me.btnLater.Size = New System.Drawing.Size(79, 23)
    Me.btnLater.TabIndex = 7
    Me.btnLater.Text = "Später"
    Me.btnLater.UseVisualStyleBackColor = True
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Location = New System.Drawing.Point(8, 72)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(155, 17)
    Me.CheckBox1.TabIndex = 8
    Me.CheckBox1.Text = "E-Mail bei Programmupdate"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.CheckBox1)
    Me.Panel1.Controls.Add(Me.btnReg)
    Me.Panel1.Controls.Add(Me.TextBox2)
    Me.Panel1.Controls.Add(Me.TextBox1)
    Me.Panel1.Controls.Add(Me.Label5)
    Me.Panel1.Controls.Add(Me.Label4)
    Me.Panel1.Location = New System.Drawing.Point(65, 70)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(401, 101)
    Me.Panel1.TabIndex = 9
    '
    'frm_reg
    '
    Me.AcceptButton = Me.btnReg
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.btnLater
    Me.ClientSize = New System.Drawing.Size(470, 178)
    Me.Controls.Add(Me.btnLater)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.Label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_reg"
    Me.ShowIcon = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Programm registrieren"
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents btnReg As System.Windows.Forms.Button
  Friend WithEvents btnLater As System.Windows.Forms.Button
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
    Me.pbDisplay = New System.Windows.Forms.PictureBox
    Me.Panel2 = New System.Windows.Forms.Panel
    Me.pbLastUsed = New System.Windows.Forms.PictureBox
    Me.btnSettings = New System.Windows.Forms.Button
    Me.btnApply = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.DISPLAYNAMEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
    Me.DateiOeffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.HintergrundfarbeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.AnBildschirmAnpassenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.AuswahlEntfernenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.tmrPendingApplyRequest = New System.Windows.Forms.Timer(Me.components)
    CType(Me.pbDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel2.SuspendLayout()
    CType(Me.pbLastUsed, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel1.SuspendLayout()
    Me.ContextMenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'pbDisplay
    '
    Me.pbDisplay.AllowDrop = True
    Me.pbDisplay.BackColor = System.Drawing.Color.DimGray
    Me.pbDisplay.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pbDisplay.Location = New System.Drawing.Point(10, 10)
    Me.pbDisplay.Name = "pbDisplay"
    Me.pbDisplay.Size = New System.Drawing.Size(783, 266)
    Me.pbDisplay.TabIndex = 3
    Me.pbDisplay.TabStop = False
    '
    'Panel2
    '
    Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
    Me.Panel2.Controls.Add(Me.pbLastUsed)
    Me.Panel2.Controls.Add(Me.btnSettings)
    Me.Panel2.Controls.Add(Me.btnApply)
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.Panel2.Location = New System.Drawing.Point(0, 286)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(803, 94)
    Me.Panel2.TabIndex = 4
    '
    'pbLastUsed
    '
    Me.pbLastUsed.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.pbLastUsed.BackColor = System.Drawing.Color.Transparent
    Me.pbLastUsed.Location = New System.Drawing.Point(203, 8)
    Me.pbLastUsed.Name = "pbLastUsed"
    Me.pbLastUsed.Size = New System.Drawing.Size(599, 80)
    Me.pbLastUsed.TabIndex = 2
    Me.pbLastUsed.TabStop = False
    '
    'btnSettings
    '
    Me.btnSettings.BackColor = System.Drawing.Color.DarkGray
    Me.btnSettings.Image = CType(resources.GetObject("btnSettings.Image"), System.Drawing.Image)
    Me.btnSettings.Location = New System.Drawing.Point(102, 8)
    Me.btnSettings.Name = "btnSettings"
    Me.btnSettings.Size = New System.Drawing.Size(89, 79)
    Me.btnSettings.TabIndex = 1
    Me.btnSettings.Text = "Hilfe && Einstellungen"
    Me.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.btnSettings.UseVisualStyleBackColor = True
    '
    'btnApply
    '
    Me.btnApply.BackColor = System.Drawing.Color.DarkGray
    Me.btnApply.Image = CType(resources.GetObject("btnApply.Image"), System.Drawing.Image)
    Me.btnApply.Location = New System.Drawing.Point(12, 8)
    Me.btnApply.Name = "btnApply"
    Me.btnApply.Size = New System.Drawing.Size(89, 79)
    Me.btnApply.TabIndex = 0
    Me.btnApply.Text = "Wallpaper übernehmen"
    Me.btnApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.btnApply.UseVisualStyleBackColor = True
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.Color.DimGray
    Me.Panel1.Controls.Add(Me.pbDisplay)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Padding = New System.Windows.Forms.Padding(10)
    Me.Panel1.Size = New System.Drawing.Size(803, 286)
    Me.Panel1.TabIndex = 5
    '
    'ContextMenuStrip1
    '
    Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DISPLAYNAMEToolStripMenuItem, Me.ToolStripMenuItem1, Me.DateiOeffnenToolStripMenuItem, Me.HintergrundfarbeToolStripMenuItem, Me.AnBildschirmAnpassenToolStripMenuItem, Me.AuswahlEntfernenToolStripMenuItem})
    Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
    Me.ContextMenuStrip1.Size = New System.Drawing.Size(210, 120)
    '
    'DISPLAYNAMEToolStripMenuItem
    '
    Me.DISPLAYNAMEToolStripMenuItem.Enabled = False
    Me.DISPLAYNAMEToolStripMenuItem.Name = "DISPLAYNAMEToolStripMenuItem"
    Me.DISPLAYNAMEToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
    Me.DISPLAYNAMEToolStripMenuItem.Text = "DISPLAY NAME"
    '
    'ToolStripMenuItem1
    '
    Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
    Me.ToolStripMenuItem1.Size = New System.Drawing.Size(206, 6)
    '
    'DateiOeffnenToolStripMenuItem
    '
    Me.DateiOeffnenToolStripMenuItem.Name = "DateiOeffnenToolStripMenuItem"
    Me.DateiOeffnenToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
    Me.DateiOeffnenToolStripMenuItem.Text = "Datei öffnen..."
    '
    'HintergrundfarbeToolStripMenuItem
    '
    Me.HintergrundfarbeToolStripMenuItem.Name = "HintergrundfarbeToolStripMenuItem"
    Me.HintergrundfarbeToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
    Me.HintergrundfarbeToolStripMenuItem.Text = "Hintergrundfarbe wählen ..."
    '
    'AnBildschirmAnpassenToolStripMenuItem
    '
    Me.AnBildschirmAnpassenToolStripMenuItem.Checked = True
    Me.AnBildschirmAnpassenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
    Me.AnBildschirmAnpassenToolStripMenuItem.Name = "AnBildschirmAnpassenToolStripMenuItem"
    Me.AnBildschirmAnpassenToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
    Me.AnBildschirmAnpassenToolStripMenuItem.Text = "An Bildschirm anpassen"
    '
    'AuswahlEntfernenToolStripMenuItem
    '
    Me.AuswahlEntfernenToolStripMenuItem.Name = "AuswahlEntfernenToolStripMenuItem"
    Me.AuswahlEntfernenToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
    Me.AuswahlEntfernenToolStripMenuItem.Text = "Bild entfernen"
    '
    'tmrPendingApplyRequest
    '
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(803, 380)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.Panel2)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimumSize = New System.Drawing.Size(800, 300)
    Me.Name = "Form1"
    Me.Text = "MultiMonitor Wallpaper"
    CType(Me.pbDisplay, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel2.ResumeLayout(False)
    CType(Me.pbLastUsed, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel1.ResumeLayout(False)
    Me.ContextMenuStrip1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents pbDisplay As System.Windows.Forms.PictureBox
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents btnSettings As System.Windows.Forms.Button
  Friend WithEvents btnApply As System.Windows.Forms.Button
  Friend WithEvents pbLastUsed As System.Windows.Forms.PictureBox
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents DateiOeffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents AuswahlEntfernenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents DISPLAYNAMEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents AnBildschirmAnpassenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents HintergrundfarbeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents tmrPendingApplyRequest As System.Windows.Forms.Timer

End Class

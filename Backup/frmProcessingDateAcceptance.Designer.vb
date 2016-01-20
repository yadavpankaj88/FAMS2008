<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcessingDateAcceptance
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
        Me.btnNext = New System.Windows.Forms.Button()
        Me.lblProcessingDate = New System.Windows.Forms.Label()
        Me.dtpProcessingDate = New System.Windows.Forms.DateTimePicker()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(20, 81)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(88, 28)
        Me.btnNext.TabIndex = 5
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'lblProcessingDate
        '
        Me.lblProcessingDate.AutoSize = True
        Me.lblProcessingDate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessingDate.Location = New System.Drawing.Point(13, 32)
        Me.lblProcessingDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProcessingDate.Name = "lblProcessingDate"
        Me.lblProcessingDate.Size = New System.Drawing.Size(95, 15)
        Me.lblProcessingDate.TabIndex = 4
        Me.lblProcessingDate.Text = "Processing Date"
        '
        'dtpProcessingDate
        '
        Me.dtpProcessingDate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpProcessingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProcessingDate.Location = New System.Drawing.Point(118, 32)
        Me.dtpProcessingDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpProcessingDate.Name = "dtpProcessingDate"
        Me.dtpProcessingDate.Size = New System.Drawing.Size(138, 23)
        Me.dtpProcessingDate.TabIndex = 3
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(149, 81)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 28)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmProcessingDateAcceptance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 131)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.lblProcessingDate)
        Me.Controls.Add(Me.dtpProcessingDate)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProcessingDateAcceptance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Processing Date Acceptance"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents lblProcessingDate As System.Windows.Forms.Label
    Private WithEvents dtpProcessingDate As System.Windows.Forms.DateTimePicker
    Private WithEvents btnCancel As System.Windows.Forms.Button

End Class

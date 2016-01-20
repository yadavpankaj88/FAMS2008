<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInstitutionSelection
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
        Me.drpInstitutionList = New System.Windows.Forms.ComboBox()
        Me.lblInstitutions = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(8, 72)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(87, 29)
        Me.btnNext.TabIndex = 5
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'drpInstitutionList
        '
        Me.drpInstitutionList.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpInstitutionList.FormattingEnabled = True
        Me.drpInstitutionList.Location = New System.Drawing.Point(78, 30)
        Me.drpInstitutionList.Name = "drpInstitutionList"
        Me.drpInstitutionList.Size = New System.Drawing.Size(188, 23)
        Me.drpInstitutionList.TabIndex = 4
        '
        'lblInstitutions
        '
        Me.lblInstitutions.AutoSize = True
        Me.lblInstitutions.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstitutions.Location = New System.Drawing.Point(3, 33)
        Me.lblInstitutions.Name = "lblInstitutions"
        Me.lblInstitutions.Size = New System.Drawing.Size(69, 15)
        Me.lblInstitutions.TabIndex = 3
        Me.lblInstitutions.Text = "Institutions"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(134, 71)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 29)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmInstitutionSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 122)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.drpInstitutionList)
        Me.Controls.Add(Me.lblInstitutions)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInstitutionSelection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Institution Selection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents drpInstitutionList As System.Windows.Forms.ComboBox
    Private WithEvents lblInstitutions As System.Windows.Forms.Label
    Private WithEvents btnCancel As System.Windows.Forms.Button
End Class

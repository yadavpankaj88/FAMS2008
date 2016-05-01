<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SA4_Certificate
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
        Me.ComboBoxCertificate = New System.Windows.Forms.ComboBox
        Me.LabelCertificate = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ComboBoxCertificate
        '
        Me.ComboBoxCertificate.FormattingEnabled = True
        Me.ComboBoxCertificate.Location = New System.Drawing.Point(203, 42)
        Me.ComboBoxCertificate.Name = "ComboBoxCertificate"
        Me.ComboBoxCertificate.Size = New System.Drawing.Size(471, 21)
        Me.ComboBoxCertificate.TabIndex = 0
        '
        'LabelCertificate
        '
        Me.LabelCertificate.AutoSize = True
        Me.LabelCertificate.Location = New System.Drawing.Point(12, 42)
        Me.LabelCertificate.Name = "LabelCertificate"
        Me.LabelCertificate.Size = New System.Drawing.Size(120, 13)
        Me.LabelCertificate.TabIndex = 1
        Me.LabelCertificate.Text = "Certificate course Name"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(203, 119)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(246, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Generate Report "
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SA4_Certificate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PeachPuff
        Me.ClientSize = New System.Drawing.Size(699, 199)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LabelCertificate)
        Me.Controls.Add(Me.ComboBoxCertificate)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Name = "SA4_Certificate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CERTIFICATE COURSE FEES INFORMATION"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBoxCertificate As System.Windows.Forms.ComboBox
    Friend WithEvents LabelCertificate As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class

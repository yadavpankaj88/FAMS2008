<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFillDaybookCode
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
        Me.dgvDaybookCode = New System.Windows.Forms.DataGridView()
        CType(Me.dgvDaybookCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDaybookCode
        '
        Me.dgvDaybookCode.AllowUserToAddRows = False
        Me.dgvDaybookCode.AllowUserToDeleteRows = False
        Me.dgvDaybookCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDaybookCode.Location = New System.Drawing.Point(24, 18)
        Me.dgvDaybookCode.Name = "dgvDaybookCode"
        Me.dgvDaybookCode.Size = New System.Drawing.Size(210, 207)
        Me.dgvDaybookCode.TabIndex = 1
        '
        'frmFillDaybookCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(258, 246)
        Me.Controls.Add(Me.dgvDaybookCode)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFillDaybookCode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.dgvDaybookCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDaybookCode As System.Windows.Forms.DataGridView
End Class

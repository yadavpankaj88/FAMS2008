<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBankRecV
    Inherits FAMS.frmBaseMaster

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
        Me.dgvBankRecV = New System.Windows.Forms.DataGridView()
        CType(Me.dgvBankRecV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvBankRecV
        '
        Me.dgvBankRecV.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvBankRecV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBankRecV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBankRecV.Location = New System.Drawing.Point(0, 0)
        Me.dgvBankRecV.Name = "dgvBankRecV"
        Me.dgvBankRecV.Size = New System.Drawing.Size(737, 305)
        Me.dgvBankRecV.TabIndex = 2
        '
        'frmBankRecV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(737, 343)
        Me.Controls.Add(Me.dgvBankRecV)
        Me.Name = "frmBankRecV"
        Me.Text = "Bank Receipt Vouchers"
        Me.Controls.SetChildIndex(Me.dgvBankRecV, 0)
        CType(Me.dgvBankRecV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvBankRecV As System.Windows.Forms.DataGridView
End Class

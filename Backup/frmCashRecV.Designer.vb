<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashRecV
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
        Me.dgvCashRecV = New System.Windows.Forms.DataGridView()
        CType(Me.dgvCashRecV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCashRecV
        '
        Me.dgvCashRecV.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvCashRecV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCashRecV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCashRecV.Location = New System.Drawing.Point(0, 0)
        Me.dgvCashRecV.Name = "dgvCashRecV"
        Me.dgvCashRecV.Size = New System.Drawing.Size(737, 305)
        Me.dgvCashRecV.TabIndex = 2
        '
        'frmCashBBMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 343)
        Me.Controls.Add(Me.dgvCashRecV)
        Me.Name = "frmCashRecV"
        Me.Text = "Cash Receipt Voucher"
        Me.Controls.SetChildIndex(Me.dgvCashRecV, 0)
        CType(Me.dgvCashRecV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvCashRecV As System.Windows.Forms.DataGridView
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashBankContraV
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
        Me.dgvCBCV = New System.Windows.Forms.DataGridView()
        CType(Me.dgvCBCV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCBCV
        '
        Me.dgvCBCV.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvCBCV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCBCV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCBCV.Location = New System.Drawing.Point(0, 0)
        Me.dgvCBCV.Name = "dgvCBCV"
        Me.dgvCBCV.Size = New System.Drawing.Size(762, 384)
        Me.dgvCBCV.TabIndex = 2
        '
        'frmCashBankContraV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 422)
        Me.Controls.Add(Me.dgvCBCV)
        Me.Name = "frmCashBankContraV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cash Bank Contra Vouchers"
        Me.Controls.SetChildIndex(Me.dgvCBCV, 0)
        CType(Me.dgvCBCV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvCBCV As System.Windows.Forms.DataGridView
End Class

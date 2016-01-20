<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashPayV
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
        Me.dgvCashPayv = New System.Windows.Forms.DataGridView()
        CType(Me.dgvCashPayv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCashPayv
        '
        Me.dgvCashPayv.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvCashPayv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCashPayv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCashPayv.Location = New System.Drawing.Point(0, 0)
        Me.dgvCashPayv.Name = "dgvCashPayv"
        Me.dgvCashPayv.Size = New System.Drawing.Size(737, 305)
        Me.dgvCashPayv.TabIndex = 2
        '
        'frmCashPayV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 343)
        Me.Controls.Add(Me.dgvCashPayv)
        Me.Name = "frmCashPayV"
        Me.Text = "Cash Payment Vouchers"
        Me.Controls.SetChildIndex(Me.dgvCashPayv, 0)
        CType(Me.dgvCashPayv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvCashPayv As System.Windows.Forms.DataGridView
End Class

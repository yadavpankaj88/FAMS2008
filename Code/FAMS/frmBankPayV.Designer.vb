<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBankPayV
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
        Me.dgvBankPayV = New System.Windows.Forms.DataGridView()
        CType(Me.dgvBankPayV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvBankPayV
        '
        Me.dgvBankPayV.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvBankPayV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBankPayV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBankPayV.Location = New System.Drawing.Point(0, 0)
        Me.dgvBankPayV.Name = "dgvBankPayV"
        Me.dgvBankPayV.Size = New System.Drawing.Size(737, 305)
        Me.dgvBankPayV.TabIndex = 2
        '
        'frmBankPayV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 343)
        Me.Controls.Add(Me.dgvBankPayV)
        Me.Name = "frmBankPayV"
        Me.Text = "Bank Payment Vouchers"
        Me.Controls.SetChildIndex(Me.dgvBankPayV, 0)
        CType(Me.dgvBankPayV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvBankPayV As System.Windows.Forms.DataGridView
End Class

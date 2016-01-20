<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJournalV
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
        Me.dgvJournalV = New System.Windows.Forms.DataGridView()
        CType(Me.dgvJournalV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvJournalV
        '
        Me.dgvJournalV.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvJournalV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJournalV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvJournalV.Location = New System.Drawing.Point(0, 0)
        Me.dgvJournalV.Name = "dgvJournalV"
        Me.dgvJournalV.Size = New System.Drawing.Size(737, 305)
        Me.dgvJournalV.TabIndex = 2
        '
        'frmJournalV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 343)
        Me.Controls.Add(Me.dgvJournalV)
        Me.Name = "frmJournalV"
        Me.Text = "Journal Vouchers"
        Me.Controls.SetChildIndex(Me.dgvJournalV, 0)
        CType(Me.dgvJournalV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvJournalV As System.Windows.Forms.DataGridView
End Class

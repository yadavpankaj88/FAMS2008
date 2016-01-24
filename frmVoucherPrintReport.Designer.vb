<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVoucherPrintReport
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
        Me.crystalviewerVoucher = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crystalviewerVoucher
        '
        Me.crystalviewerVoucher.ActiveViewIndex = -1
        Me.crystalviewerVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crystalviewerVoucher.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crystalviewerVoucher.Location = New System.Drawing.Point(0, 0)
        Me.crystalviewerVoucher.Name = "crystalviewerVoucher"
        Me.crystalviewerVoucher.SelectionFormula = ""
        Me.crystalviewerVoucher.Size = New System.Drawing.Size(1242, 486)
        Me.crystalviewerVoucher.TabIndex = 0
        Me.crystalviewerVoucher.ViewTimeSelectionFormula = ""
        '
        'frmVoucherPrintReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1242, 486)
        Me.Controls.Add(Me.crystalviewerVoucher)
        Me.Name = "frmVoucherPrintReport"
        Me.Text = "Voucher"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crystalviewerVoucher As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class

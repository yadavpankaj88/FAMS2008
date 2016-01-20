<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
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
        Me.crystalRptVwr = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CashReceipt1 = New FAMS.rptCashBook()
        Me.rptCashBook1 = New FAMS.rptCashBook()
        Me.SuspendLayout()
        '
        'crystalRptVwr
        '
        Me.crystalRptVwr.ActiveViewIndex = 0
        Me.crystalRptVwr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crystalRptVwr.Cursor = System.Windows.Forms.Cursors.Default
        Me.crystalRptVwr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crystalRptVwr.Location = New System.Drawing.Point(0, 0)
        Me.crystalRptVwr.Name = "crystalRptVwr"
        Me.crystalRptVwr.ReportSource = Me.CashReceipt1
        Me.crystalRptVwr.Size = New System.Drawing.Size(927, 466)
        Me.crystalRptVwr.TabIndex = 0
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 466)
        Me.Controls.Add(Me.crystalRptVwr)
        Me.Name = "frmReports"
        Me.Text = "Report"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crystalRptVwr As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CashReceipt1 As FAMS.rptCashBook
    Friend WithEvents rptCashBook1 As FAMS.rptCashBook
End Class

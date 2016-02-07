<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class popupHelper
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
        Me.VoucherSelectionGrid = New System.Windows.Forms.DataGridView
        Me.AccountName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LedgerCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherNarration = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.VoucherSelectionGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VoucherSelectionGrid
        '
        Me.VoucherSelectionGrid.AllowUserToAddRows = False
        Me.VoucherSelectionGrid.AllowUserToDeleteRows = False
        Me.VoucherSelectionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.VoucherSelectionGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AccountName, Me.LedgerCode, Me.VoucherNumber, Me.VoucherDate, Me.VoucherNarration, Me.Amount})
        Me.VoucherSelectionGrid.Location = New System.Drawing.Point(13, 12)
        Me.VoucherSelectionGrid.MultiSelect = False
        Me.VoucherSelectionGrid.Name = "VoucherSelectionGrid"
        Me.VoucherSelectionGrid.ReadOnly = True
        Me.VoucherSelectionGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.VoucherSelectionGrid.Size = New System.Drawing.Size(644, 237)
        Me.VoucherSelectionGrid.TabIndex = 0
        '
        'AccountName
        '
        Me.AccountName.DataPropertyName = "AM_Acc_Nm"
        Me.AccountName.HeaderText = "Name"
        Me.AccountName.Name = "AccountName"
        Me.AccountName.ReadOnly = True
        Me.AccountName.Width = 200
        '
        'LedgerCode
        '
        Me.LedgerCode.DataPropertyName = "AM_Acc_Cd"
        Me.LedgerCode.HeaderText = "LedgerCode"
        Me.LedgerCode.Name = "LedgerCode"
        Me.LedgerCode.ReadOnly = True
        '
        'VoucherNumber
        '
        Me.VoucherNumber.DataPropertyName = "VH_Lnk_No"
        Me.VoucherNumber.HeaderText = "Link Voucher Number"
        Me.VoucherNumber.Name = "VoucherNumber"
        Me.VoucherNumber.ReadOnly = True
        Me.VoucherNumber.Width = 150
        '
        'VoucherDate
        '
        Me.VoucherDate.DataPropertyName = "VH_Lnk_Dt"
        Me.VoucherDate.HeaderText = "Link Voucher Date"
        Me.VoucherDate.Name = "VoucherDate"
        Me.VoucherDate.ReadOnly = True
        Me.VoucherDate.Width = 150
        '
        'VoucherNarration
        '
        Me.VoucherNarration.DataPropertyName = "vh_pty_nm"
        Me.VoucherNarration.HeaderText = "Narration"
        Me.VoucherNarration.Name = "VoucherNarration"
        Me.VoucherNarration.ReadOnly = True
        Me.VoucherNarration.Width = 150
        '
        'Amount
        '
        Me.Amount.DataPropertyName = "vh_abs_amt"
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        '
        'popupHelper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 261)
        Me.Controls.Add(Me.VoucherSelectionGrid)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "popupHelper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.VoucherSelectionGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VoucherSelectionGrid As System.Windows.Forms.DataGridView
    Friend WithEvents AccountName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LedgerCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNarration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

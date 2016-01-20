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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.LedgerCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VoucherNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VoucherDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VoucherNarration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LedgerCode, Me.VoucherNumber, Me.VoucherDate, Me.VoucherNarration, Me.Amount, Me.AccountName})
        Me.DataGridView1.Location = New System.Drawing.Point(13, 28)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(243, 205)
        Me.DataGridView1.TabIndex = 0
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
        '
        'VoucherDate
        '
        Me.VoucherDate.DataPropertyName = "VH_Lnk_Dt"
        Me.VoucherDate.HeaderText = "Link Voucher Date"
        Me.VoucherDate.Name = "VoucherDate"
        Me.VoucherDate.ReadOnly = True
        '
        'VoucherNarration
        '
        Me.VoucherNarration.DataPropertyName = "VD_Narr"
        Me.VoucherNarration.HeaderText = "Narration"
        Me.VoucherNarration.Name = "VoucherNarration"
        Me.VoucherNarration.ReadOnly = True
        '
        'Amount
        '
        Me.Amount.DataPropertyName = "VD_Amt"
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        '
        'AccountName
        '
        Me.AccountName.DataPropertyName = "AM_Acc_Nm"
        Me.AccountName.HeaderText = "Name"
        Me.AccountName.Name = "AccountName"
        Me.AccountName.ReadOnly = True
        '
        'popupHelper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.DataGridView1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "popupHelper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents LedgerCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherNarration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

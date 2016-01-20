<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashBankAccountManage
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btnconfirm = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.txtbank_od = New System.Windows.Forms.TextBox()
        Me.LabelBankOD = New System.Windows.Forms.Label()
        Me.txtaccount_no = New System.Windows.Forms.TextBox()
        Me.LabelAccountNumber = New System.Windows.Forms.Label()
        Me.txtbranch_nm = New System.Windows.Forms.TextBox()
        Me.LabelBranchName = New System.Windows.Forms.Label()
        Me.txtbank_nm = New System.Windows.Forms.TextBox()
        Me.LabelBankName = New System.Windows.Forms.Label()
        Me.ddlacc_code = New System.Windows.Forms.ComboBox()
        Me.LabelLedgerAccountCode = New System.Windows.Forms.Label()
        Me.ddldaybook_type = New System.Windows.Forms.ComboBox()
        Me.LabelDaybookType = New System.Windows.Forms.Label()
        Me.txtdaybook_nm = New System.Windows.Forms.TextBox()
        Me.LabelDaybookName = New System.Windows.Forms.Label()
        Me.txtdaybook_code = New System.Windows.Forms.TextBox()
        Me.labelDaybookCode = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btncancel)
        Me.GroupBox1.Controls.Add(Me.btnconfirm)
        Me.GroupBox1.Controls.Add(Me.btndelete)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Controls.Add(Me.txtbank_od)
        Me.GroupBox1.Controls.Add(Me.LabelBankOD)
        Me.GroupBox1.Controls.Add(Me.txtaccount_no)
        Me.GroupBox1.Controls.Add(Me.LabelAccountNumber)
        Me.GroupBox1.Controls.Add(Me.txtbranch_nm)
        Me.GroupBox1.Controls.Add(Me.LabelBranchName)
        Me.GroupBox1.Controls.Add(Me.txtbank_nm)
        Me.GroupBox1.Controls.Add(Me.LabelBankName)
        Me.GroupBox1.Controls.Add(Me.ddlacc_code)
        Me.GroupBox1.Controls.Add(Me.LabelLedgerAccountCode)
        Me.GroupBox1.Controls.Add(Me.ddldaybook_type)
        Me.GroupBox1.Controls.Add(Me.LabelDaybookType)
        Me.GroupBox1.Controls.Add(Me.txtdaybook_nm)
        Me.GroupBox1.Controls.Add(Me.LabelDaybookName)
        Me.GroupBox1.Controls.Add(Me.txtdaybook_code)
        Me.GroupBox1.Controls.Add(Me.labelDaybookCode)
        Me.GroupBox1.Location = New System.Drawing.Point(39, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(628, 283)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btncancel
        '
        Me.btncancel.Location = New System.Drawing.Point(458, 214)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(90, 23)
        Me.btncancel.TabIndex = 30
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'btnconfirm
        '
        Me.btnconfirm.Location = New System.Drawing.Point(301, 214)
        Me.btnconfirm.Name = "btnconfirm"
        Me.btnconfirm.Size = New System.Drawing.Size(90, 23)
        Me.btnconfirm.TabIndex = 29
        Me.btnconfirm.Text = "Confirm"
        Me.btnconfirm.UseVisualStyleBackColor = True
        '
        'btndelete
        '
        Me.btndelete.Location = New System.Drawing.Point(150, 214)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(89, 23)
        Me.btndelete.TabIndex = 28
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(14, 214)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 16
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'txtbank_od
        '
        Me.txtbank_od.Location = New System.Drawing.Point(457, 143)
        Me.txtbank_od.MaxLength = 16
        Me.txtbank_od.Name = "txtbank_od"
        Me.txtbank_od.Size = New System.Drawing.Size(120, 20)
        Me.txtbank_od.TabIndex = 15
        '
        'LabelBankOD
        '
        Me.LabelBankOD.AutoSize = True
        Me.LabelBankOD.Location = New System.Drawing.Point(353, 143)
        Me.LabelBankOD.Name = "LabelBankOD"
        Me.LabelBankOD.Size = New System.Drawing.Size(51, 13)
        Me.LabelBankOD.TabIndex = 14
        Me.LabelBankOD.Text = "Bank OD"
        '
        'txtaccount_no
        '
        Me.txtaccount_no.Location = New System.Drawing.Point(457, 106)
        Me.txtaccount_no.MaxLength = 16
        Me.txtaccount_no.Name = "txtaccount_no"
        Me.txtaccount_no.Size = New System.Drawing.Size(120, 20)
        Me.txtaccount_no.TabIndex = 13
        '
        'LabelAccountNumber
        '
        Me.LabelAccountNumber.AutoSize = True
        Me.LabelAccountNumber.Location = New System.Drawing.Point(353, 108)
        Me.LabelAccountNumber.Name = "LabelAccountNumber"
        Me.LabelAccountNumber.Size = New System.Drawing.Size(87, 13)
        Me.LabelAccountNumber.TabIndex = 12
        Me.LabelAccountNumber.Text = "Account Number"
        '
        'txtbranch_nm
        '
        Me.txtbranch_nm.Location = New System.Drawing.Point(457, 63)
        Me.txtbranch_nm.Name = "txtbranch_nm"
        Me.txtbranch_nm.Size = New System.Drawing.Size(120, 20)
        Me.txtbranch_nm.TabIndex = 11
        '
        'LabelBranchName
        '
        Me.LabelBranchName.AutoSize = True
        Me.LabelBranchName.Location = New System.Drawing.Point(353, 70)
        Me.LabelBranchName.Name = "LabelBranchName"
        Me.LabelBranchName.Size = New System.Drawing.Size(72, 13)
        Me.LabelBranchName.TabIndex = 10
        Me.LabelBranchName.Text = "Branch Name"
        '
        'txtbank_nm
        '
        Me.txtbank_nm.Location = New System.Drawing.Point(457, 28)
        Me.txtbank_nm.Name = "txtbank_nm"
        Me.txtbank_nm.Size = New System.Drawing.Size(120, 20)
        Me.txtbank_nm.TabIndex = 9
        '
        'LabelBankName
        '
        Me.LabelBankName.AutoSize = True
        Me.LabelBankName.Location = New System.Drawing.Point(353, 31)
        Me.LabelBankName.Name = "LabelBankName"
        Me.LabelBankName.Size = New System.Drawing.Size(63, 13)
        Me.LabelBankName.TabIndex = 8
        Me.LabelBankName.Text = "Bank Name"
        '
        'ddlacc_code
        '
        Me.ddlacc_code.FormattingEnabled = True
        Me.ddlacc_code.Location = New System.Drawing.Point(166, 138)
        Me.ddlacc_code.Name = "ddlacc_code"
        Me.ddlacc_code.Size = New System.Drawing.Size(118, 21)
        Me.ddlacc_code.TabIndex = 7
        '
        'LabelLedgerAccountCode
        '
        Me.LabelLedgerAccountCode.AutoSize = True
        Me.LabelLedgerAccountCode.Location = New System.Drawing.Point(5, 141)
        Me.LabelLedgerAccountCode.Name = "LabelLedgerAccountCode"
        Me.LabelLedgerAccountCode.Size = New System.Drawing.Size(111, 13)
        Me.LabelLedgerAccountCode.TabIndex = 6
        Me.LabelLedgerAccountCode.Text = "Ledger Account Code"
        '
        'ddldaybook_type
        '
        Me.ddldaybook_type.FormattingEnabled = True
        Me.ddldaybook_type.Location = New System.Drawing.Point(166, 103)
        Me.ddldaybook_type.Name = "ddldaybook_type"
        Me.ddldaybook_type.Size = New System.Drawing.Size(118, 21)
        Me.ddldaybook_type.TabIndex = 5
        '
        'LabelDaybookType
        '
        Me.LabelDaybookType.AutoSize = True
        Me.LabelDaybookType.Location = New System.Drawing.Point(7, 106)
        Me.LabelDaybookType.Name = "LabelDaybookType"
        Me.LabelDaybookType.Size = New System.Drawing.Size(77, 13)
        Me.LabelDaybookType.TabIndex = 4
        Me.LabelDaybookType.Text = "Daybook Type"
        '
        'txtdaybook_nm
        '
        Me.txtdaybook_nm.Location = New System.Drawing.Point(166, 65)
        Me.txtdaybook_nm.Name = "txtdaybook_nm"
        Me.txtdaybook_nm.Size = New System.Drawing.Size(118, 20)
        Me.txtdaybook_nm.TabIndex = 3
        '
        'LabelDaybookName
        '
        Me.LabelDaybookName.AutoSize = True
        Me.LabelDaybookName.Location = New System.Drawing.Point(7, 68)
        Me.LabelDaybookName.Name = "LabelDaybookName"
        Me.LabelDaybookName.Size = New System.Drawing.Size(81, 13)
        Me.LabelDaybookName.TabIndex = 2
        Me.LabelDaybookName.Text = "Daybook Name"
        '
        'txtdaybook_code
        '
        Me.txtdaybook_code.Location = New System.Drawing.Point(166, 26)
        Me.txtdaybook_code.Name = "txtdaybook_code"
        Me.txtdaybook_code.Size = New System.Drawing.Size(118, 20)
        Me.txtdaybook_code.TabIndex = 1
        '
        'labelDaybookCode
        '
        Me.labelDaybookCode.AutoSize = True
        Me.labelDaybookCode.Location = New System.Drawing.Point(7, 29)
        Me.labelDaybookCode.Name = "labelDaybookCode"
        Me.labelDaybookCode.Size = New System.Drawing.Size(78, 13)
        Me.labelDaybookCode.TabIndex = 0
        Me.labelDaybookCode.Text = "Daybook Code"
        '
        'frmCashBankAccountManage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 366)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmCashBankAccountManage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents labelDaybookCode As System.Windows.Forms.Label
    Friend WithEvents txtdaybook_code As System.Windows.Forms.TextBox
    Friend WithEvents ddldaybook_type As System.Windows.Forms.ComboBox
    Friend WithEvents LabelDaybookType As System.Windows.Forms.Label
    Friend WithEvents txtdaybook_nm As System.Windows.Forms.TextBox
    Friend WithEvents LabelDaybookName As System.Windows.Forms.Label
    Friend WithEvents ddlacc_code As System.Windows.Forms.ComboBox
    Friend WithEvents LabelLedgerAccountCode As System.Windows.Forms.Label
    Friend WithEvents txtbank_nm As System.Windows.Forms.TextBox
    Friend WithEvents LabelBankName As System.Windows.Forms.Label
    Friend WithEvents txtbranch_nm As System.Windows.Forms.TextBox
    Friend WithEvents LabelBranchName As System.Windows.Forms.Label
    Friend WithEvents txtaccount_no As System.Windows.Forms.TextBox
    Friend WithEvents LabelAccountNumber As System.Windows.Forms.Label
    Friend WithEvents txtbank_od As System.Windows.Forms.TextBox
    Friend WithEvents LabelBankOD As System.Windows.Forms.Label
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents btnconfirm As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
End Class

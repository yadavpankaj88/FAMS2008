<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddVoucher
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
        Me.LabelVoucherDate = New System.Windows.Forms.Label()
        Me.dtplinkVoucherdt = New System.Windows.Forms.DateTimePicker()
        Me.LabelDaybookCode = New System.Windows.Forms.Label()
        Me.txtpayeenm = New System.Windows.Forms.TextBox()
        Me.LabelNameOfPayee = New System.Windows.Forms.Label()
        Me.ddldaybookcode = New System.Windows.Forms.ComboBox()
        Me.LabelChequeNo = New System.Windows.Forms.Label()
        Me.txtchequeno = New System.Windows.Forms.TextBox()
        Me.LabelReferenceNo = New System.Windows.Forms.Label()
        Me.txtreferenceno = New System.Windows.Forms.TextBox()
        Me.LabelReferenceDate = New System.Windows.Forms.Label()
        Me.dtpreferencedt = New System.Windows.Forms.DateTimePicker()
        Me.ddlcr_dr = New System.Windows.Forms.ComboBox()
        Me.LabelCreditDebit = New System.Windows.Forms.Label()
        Me.LabelAmount = New System.Windows.Forms.Label()
        Me.txtamount = New System.Windows.Forms.TextBox()
        Me.dtpchequedt = New System.Windows.Forms.DateTimePicker()
        Me.LabelChequeDate = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnconfirm = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.txtlinkvoucherdt = New System.Windows.Forms.TextBox()
        Me.txtchequedt = New System.Windows.Forms.TextBox()
        Me.txtreferencedt = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelVoucherDate
        '
        Me.LabelVoucherDate.AutoSize = True
        Me.LabelVoucherDate.Location = New System.Drawing.Point(28, 19)
        Me.LabelVoucherDate.Name = "LabelVoucherDate"
        Me.LabelVoucherDate.Size = New System.Drawing.Size(93, 13)
        Me.LabelVoucherDate.TabIndex = 0
        Me.LabelVoucherDate.Text = "Link voucher date"
        '
        'dtplinkVoucherdt
        '
        Me.dtplinkVoucherdt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtplinkVoucherdt.Location = New System.Drawing.Point(298, 16)
        Me.dtplinkVoucherdt.Name = "dtplinkVoucherdt"
        Me.dtplinkVoucherdt.Size = New System.Drawing.Size(19, 20)
        Me.dtplinkVoucherdt.TabIndex = 1
        '
        'LabelDaybookCode
        '
        Me.LabelDaybookCode.AutoSize = True
        Me.LabelDaybookCode.Location = New System.Drawing.Point(28, 84)
        Me.LabelDaybookCode.Name = "LabelDaybookCode"
        Me.LabelDaybookCode.Size = New System.Drawing.Size(78, 13)
        Me.LabelDaybookCode.TabIndex = 2
        Me.LabelDaybookCode.Text = "Daybook Code"
        '
        'txtpayeenm
        '
        Me.txtpayeenm.Location = New System.Drawing.Point(143, 50)
        Me.txtpayeenm.Name = "txtpayeenm"
        Me.txtpayeenm.Size = New System.Drawing.Size(178, 20)
        Me.txtpayeenm.TabIndex = 3
        '
        'LabelNameOfPayee
        '
        Me.LabelNameOfPayee.AutoSize = True
        Me.LabelNameOfPayee.Location = New System.Drawing.Point(28, 53)
        Me.LabelNameOfPayee.Name = "LabelNameOfPayee"
        Me.LabelNameOfPayee.Size = New System.Drawing.Size(80, 13)
        Me.LabelNameOfPayee.TabIndex = 4
        Me.LabelNameOfPayee.Text = "Name of Payee"
        '
        'ddldaybookcode
        '
        Me.ddldaybookcode.FormattingEnabled = True
        Me.ddldaybookcode.Location = New System.Drawing.Point(143, 81)
        Me.ddldaybookcode.Name = "ddldaybookcode"
        Me.ddldaybookcode.Size = New System.Drawing.Size(178, 21)
        Me.ddldaybookcode.TabIndex = 5
        '
        'LabelChequeNo
        '
        Me.LabelChequeNo.AutoSize = True
        Me.LabelChequeNo.Location = New System.Drawing.Point(31, 120)
        Me.LabelChequeNo.Name = "LabelChequeNo"
        Me.LabelChequeNo.Size = New System.Drawing.Size(59, 13)
        Me.LabelChequeNo.TabIndex = 6
        Me.LabelChequeNo.Text = "Cheque no"
        '
        'txtchequeno
        '
        Me.txtchequeno.Location = New System.Drawing.Point(143, 114)
        Me.txtchequeno.Name = "txtchequeno"
        Me.txtchequeno.Size = New System.Drawing.Size(178, 20)
        Me.txtchequeno.TabIndex = 7
        '
        'LabelReferenceNo
        '
        Me.LabelReferenceNo.AutoSize = True
        Me.LabelReferenceNo.Location = New System.Drawing.Point(367, 19)
        Me.LabelReferenceNo.Name = "LabelReferenceNo"
        Me.LabelReferenceNo.Size = New System.Drawing.Size(74, 13)
        Me.LabelReferenceNo.TabIndex = 10
        Me.LabelReferenceNo.Text = "Reference No"
        '
        'txtreferenceno
        '
        Me.txtreferenceno.Location = New System.Drawing.Point(473, 17)
        Me.txtreferenceno.Name = "txtreferenceno"
        Me.txtreferenceno.Size = New System.Drawing.Size(177, 20)
        Me.txtreferenceno.TabIndex = 11
        '
        'LabelReferenceDate
        '
        Me.LabelReferenceDate.AutoSize = True
        Me.LabelReferenceDate.Location = New System.Drawing.Point(367, 53)
        Me.LabelReferenceDate.Name = "LabelReferenceDate"
        Me.LabelReferenceDate.Size = New System.Drawing.Size(83, 13)
        Me.LabelReferenceDate.TabIndex = 12
        Me.LabelReferenceDate.Text = "Reference Date"
        '
        'dtpreferencedt
        '
        Me.dtpreferencedt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpreferencedt.Location = New System.Drawing.Point(632, 53)
        Me.dtpreferencedt.Name = "dtpreferencedt"
        Me.dtpreferencedt.Size = New System.Drawing.Size(16, 20)
        Me.dtpreferencedt.TabIndex = 13
        '
        'ddlcr_dr
        '
        Me.ddlcr_dr.FormattingEnabled = True
        Me.ddlcr_dr.Location = New System.Drawing.Point(473, 84)
        Me.ddlcr_dr.Name = "ddlcr_dr"
        Me.ddlcr_dr.Size = New System.Drawing.Size(177, 21)
        Me.ddlcr_dr.TabIndex = 14
        '
        'LabelCreditDebit
        '
        Me.LabelCreditDebit.AutoSize = True
        Me.LabelCreditDebit.Location = New System.Drawing.Point(367, 87)
        Me.LabelCreditDebit.Name = "LabelCreditDebit"
        Me.LabelCreditDebit.Size = New System.Drawing.Size(64, 13)
        Me.LabelCreditDebit.TabIndex = 15
        Me.LabelCreditDebit.Text = "Credit/Debit"
        '
        'LabelAmount
        '
        Me.LabelAmount.AutoSize = True
        Me.LabelAmount.Location = New System.Drawing.Point(367, 121)
        Me.LabelAmount.Name = "LabelAmount"
        Me.LabelAmount.Size = New System.Drawing.Size(43, 13)
        Me.LabelAmount.TabIndex = 16
        Me.LabelAmount.Text = "Amount"
        '
        'txtamount
        '
        Me.txtamount.Location = New System.Drawing.Point(473, 121)
        Me.txtamount.Name = "txtamount"
        Me.txtamount.Size = New System.Drawing.Size(177, 20)
        Me.txtamount.TabIndex = 17
        '
        'dtpchequedt
        '
        Me.dtpchequedt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpchequedt.Location = New System.Drawing.Point(302, 153)
        Me.dtpchequedt.Name = "dtpchequedt"
        Me.dtpchequedt.Size = New System.Drawing.Size(19, 20)
        Me.dtpchequedt.TabIndex = 8
        '
        'LabelChequeDate
        '
        Me.LabelChequeDate.AutoSize = True
        Me.LabelChequeDate.Location = New System.Drawing.Point(32, 159)
        Me.LabelChequeDate.Name = "LabelChequeDate"
        Me.LabelChequeDate.Size = New System.Drawing.Size(68, 13)
        Me.LabelChequeDate.TabIndex = 9
        Me.LabelChequeDate.Text = "Cheque date"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(38, 269)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(675, 146)
        Me.DataGridView1.TabIndex = 25
        '
        'btnconfirm
        '
        Me.btnconfirm.Location = New System.Drawing.Point(379, 205)
        Me.btnconfirm.Name = "btnconfirm"
        Me.btnconfirm.Size = New System.Drawing.Size(90, 23)
        Me.btnconfirm.TabIndex = 22
        Me.btnconfirm.Text = "Confirm"
        Me.btnconfirm.UseVisualStyleBackColor = True
        '
        'btndelete
        '
        Me.btndelete.Location = New System.Drawing.Point(236, 205)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(89, 23)
        Me.btndelete.TabIndex = 20
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.Location = New System.Drawing.Point(106, 205)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(87, 23)
        Me.ButtonSave.TabIndex = 18
        Me.ButtonSave.Text = "Save"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'btncancel
        '
        Me.btncancel.Location = New System.Drawing.Point(514, 205)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(90, 23)
        Me.btncancel.TabIndex = 23
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'txtlinkvoucherdt
        '
        Me.txtlinkvoucherdt.Location = New System.Drawing.Point(143, 16)
        Me.txtlinkvoucherdt.Name = "txtlinkvoucherdt"
        Me.txtlinkvoucherdt.Size = New System.Drawing.Size(163, 20)
        Me.txtlinkvoucherdt.TabIndex = 1
        '
        'txtchequedt
        '
        Me.txtchequedt.Location = New System.Drawing.Point(143, 153)
        Me.txtchequedt.Name = "txtchequedt"
        Me.txtchequedt.Size = New System.Drawing.Size(163, 20)
        Me.txtchequedt.TabIndex = 8
        '
        'txtreferencedt
        '
        Me.txtreferencedt.Location = New System.Drawing.Point(474, 53)
        Me.txtreferencedt.Name = "txtreferencedt"
        Me.txtreferencedt.Size = New System.Drawing.Size(161, 20)
        Me.txtreferencedt.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelVoucherDate)
        Me.GroupBox1.Controls.Add(Me.btncancel)
        Me.GroupBox1.Controls.Add(Me.txtreferencedt)
        Me.GroupBox1.Controls.Add(Me.btnconfirm)
        Me.GroupBox1.Controls.Add(Me.dtplinkVoucherdt)
        Me.GroupBox1.Controls.Add(Me.btndelete)
        Me.GroupBox1.Controls.Add(Me.txtchequedt)
        Me.GroupBox1.Controls.Add(Me.ButtonSave)
        Me.GroupBox1.Controls.Add(Me.LabelDaybookCode)
        Me.GroupBox1.Controls.Add(Me.txtlinkvoucherdt)
        Me.GroupBox1.Controls.Add(Me.txtpayeenm)
        Me.GroupBox1.Controls.Add(Me.LabelNameOfPayee)
        Me.GroupBox1.Controls.Add(Me.txtamount)
        Me.GroupBox1.Controls.Add(Me.ddldaybookcode)
        Me.GroupBox1.Controls.Add(Me.LabelAmount)
        Me.GroupBox1.Controls.Add(Me.LabelChequeNo)
        Me.GroupBox1.Controls.Add(Me.LabelCreditDebit)
        Me.GroupBox1.Controls.Add(Me.txtchequeno)
        Me.GroupBox1.Controls.Add(Me.ddlcr_dr)
        Me.GroupBox1.Controls.Add(Me.dtpchequedt)
        Me.GroupBox1.Controls.Add(Me.dtpreferencedt)
        Me.GroupBox1.Controls.Add(Me.LabelChequeDate)
        Me.GroupBox1.Controls.Add(Me.LabelReferenceDate)
        Me.GroupBox1.Controls.Add(Me.txtreferenceno)
        Me.GroupBox1.Controls.Add(Me.LabelReferenceNo)
        Me.GroupBox1.Location = New System.Drawing.Point(38, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(675, 246)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        '
        'frmAddVoucher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 422)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmAddVoucher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelVoucherDate As System.Windows.Forms.Label
    Friend WithEvents dtplinkVoucherdt As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelDaybookCode As System.Windows.Forms.Label
    Friend WithEvents txtpayeenm As System.Windows.Forms.TextBox
    Friend WithEvents LabelNameOfPayee As System.Windows.Forms.Label
    Friend WithEvents LabelChequeNo As System.Windows.Forms.Label
    Friend WithEvents txtchequeno As System.Windows.Forms.TextBox
    Friend WithEvents LabelReferenceNo As System.Windows.Forms.Label
    Friend WithEvents txtreferenceno As System.Windows.Forms.TextBox
    Friend WithEvents LabelReferenceDate As System.Windows.Forms.Label
    Friend WithEvents dtpreferencedt As System.Windows.Forms.DateTimePicker
    Friend WithEvents ddlcr_dr As System.Windows.Forms.ComboBox
    Friend WithEvents LabelCreditDebit As System.Windows.Forms.Label
    Friend WithEvents LabelAmount As System.Windows.Forms.Label
    Friend WithEvents txtamount As System.Windows.Forms.TextBox
    Friend WithEvents ddldaybookcode As System.Windows.Forms.ComboBox
    Friend WithEvents dtpchequedt As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelChequeDate As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnconfirm As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents txtlinkvoucherdt As System.Windows.Forms.TextBox
    Friend WithEvents txtchequedt As System.Windows.Forms.TextBox
    Friend WithEvents txtreferencedt As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class

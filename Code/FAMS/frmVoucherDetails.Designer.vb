<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVoucherDetails
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
        Me.txtreferencedt = New System.Windows.Forms.TextBox()
        Me.btnconfirm = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.txtchequedt = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.LabelDaybookCode = New System.Windows.Forms.Label()
        Me.txtpayeenm = New System.Windows.Forms.TextBox()
        Me.LabelNameOfPayee = New System.Windows.Forms.Label()
        Me.txtamount = New System.Windows.Forms.TextBox()
        Me.ddldaybookcode = New System.Windows.Forms.ComboBox()
        Me.LabelAmount = New System.Windows.Forms.Label()
        Me.LabelChequeNo = New System.Windows.Forms.Label()
        Me.LabelCreditDebit = New System.Windows.Forms.Label()
        Me.txtchequeno = New System.Windows.Forms.TextBox()
        Me.ddlcr_dr = New System.Windows.Forms.ComboBox()
        Me.dtpchequedt = New System.Windows.Forms.DateTimePicker()
        Me.dtpreferencedt = New System.Windows.Forms.DateTimePicker()
        Me.LabelChequeDate = New System.Windows.Forms.Label()
        Me.LabelReferenceDate = New System.Windows.Forms.Label()
        Me.txtreferenceno = New System.Windows.Forms.TextBox()
        Me.LabelReferenceNo = New System.Windows.Forms.Label()
        Me.dgvdetail = New System.Windows.Forms.DataGridView()
        Me.txtvoucher_link = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtvoucher_date = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtconfirmedvoucher_dt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtconfirmedvoucher = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtnarration = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtvoucheramount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtcheckref_date = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtcheck_ref = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvdetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btncancel)
        Me.GroupBox1.Controls.Add(Me.txtreferencedt)
        Me.GroupBox1.Controls.Add(Me.btnconfirm)
        Me.GroupBox1.Controls.Add(Me.btndelete)
        Me.GroupBox1.Controls.Add(Me.txtchequedt)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.LabelDaybookCode)
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
        Me.GroupBox1.Location = New System.Drawing.Point(34, 198)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(675, 173)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'btncancel
        '
        Me.btncancel.Location = New System.Drawing.Point(489, 142)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(90, 23)
        Me.btncancel.TabIndex = 23
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'txtreferencedt
        '
        Me.txtreferencedt.Location = New System.Drawing.Point(458, 47)
        Me.txtreferencedt.Name = "txtreferencedt"
        Me.txtreferencedt.Size = New System.Drawing.Size(161, 20)
        Me.txtreferencedt.TabIndex = 12
        '
        'btnconfirm
        '
        Me.btnconfirm.Location = New System.Drawing.Point(354, 142)
        Me.btnconfirm.Name = "btnconfirm"
        Me.btnconfirm.Size = New System.Drawing.Size(90, 23)
        Me.btnconfirm.TabIndex = 22
        Me.btnconfirm.Text = "Confirm"
        Me.btnconfirm.UseVisualStyleBackColor = True
        '
        'btndelete
        '
        Me.btndelete.Location = New System.Drawing.Point(211, 142)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(89, 23)
        Me.btndelete.TabIndex = 20
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        'txtchequedt
        '
        Me.txtchequedt.Location = New System.Drawing.Point(127, 111)
        Me.txtchequedt.Name = "txtchequedt"
        Me.txtchequedt.Size = New System.Drawing.Size(163, 20)
        Me.txtchequedt.TabIndex = 8
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(81, 142)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 23)
        Me.btnSave.TabIndex = 18
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'LabelDaybookCode
        '
        Me.LabelDaybookCode.AutoSize = True
        Me.LabelDaybookCode.Location = New System.Drawing.Point(15, 52)
        Me.LabelDaybookCode.Name = "LabelDaybookCode"
        Me.LabelDaybookCode.Size = New System.Drawing.Size(78, 13)
        Me.LabelDaybookCode.TabIndex = 2
        Me.LabelDaybookCode.Text = "Daybook Code"
        '
        'txtpayeenm
        '
        Me.txtpayeenm.Location = New System.Drawing.Point(129, 19)
        Me.txtpayeenm.Name = "txtpayeenm"
        Me.txtpayeenm.Size = New System.Drawing.Size(178, 20)
        Me.txtpayeenm.TabIndex = 3
        '
        'LabelNameOfPayee
        '
        Me.LabelNameOfPayee.AutoSize = True
        Me.LabelNameOfPayee.Location = New System.Drawing.Point(12, 22)
        Me.LabelNameOfPayee.Name = "LabelNameOfPayee"
        Me.LabelNameOfPayee.Size = New System.Drawing.Size(80, 13)
        Me.LabelNameOfPayee.TabIndex = 4
        Me.LabelNameOfPayee.Text = "Name of Payee"
        '
        'txtamount
        '
        Me.txtamount.Location = New System.Drawing.Point(457, 107)
        Me.txtamount.Name = "txtamount"
        Me.txtamount.Size = New System.Drawing.Size(177, 20)
        Me.txtamount.TabIndex = 17
        '
        'ddldaybookcode
        '
        Me.ddldaybookcode.FormattingEnabled = True
        Me.ddldaybookcode.Location = New System.Drawing.Point(130, 49)
        Me.ddldaybookcode.Name = "ddldaybookcode"
        Me.ddldaybookcode.Size = New System.Drawing.Size(178, 21)
        Me.ddldaybookcode.TabIndex = 5
        '
        'LabelAmount
        '
        Me.LabelAmount.AutoSize = True
        Me.LabelAmount.Location = New System.Drawing.Point(351, 107)
        Me.LabelAmount.Name = "LabelAmount"
        Me.LabelAmount.Size = New System.Drawing.Size(43, 13)
        Me.LabelAmount.TabIndex = 16
        Me.LabelAmount.Text = "Amount"
        '
        'LabelChequeNo
        '
        Me.LabelChequeNo.AutoSize = True
        Me.LabelChequeNo.Location = New System.Drawing.Point(15, 87)
        Me.LabelChequeNo.Name = "LabelChequeNo"
        Me.LabelChequeNo.Size = New System.Drawing.Size(59, 13)
        Me.LabelChequeNo.TabIndex = 6
        Me.LabelChequeNo.Text = "Cheque no"
        '
        'LabelCreditDebit
        '
        Me.LabelCreditDebit.AutoSize = True
        Me.LabelCreditDebit.Location = New System.Drawing.Point(351, 78)
        Me.LabelCreditDebit.Name = "LabelCreditDebit"
        Me.LabelCreditDebit.Size = New System.Drawing.Size(64, 13)
        Me.LabelCreditDebit.TabIndex = 15
        Me.LabelCreditDebit.Text = "Credit/Debit"
        '
        'txtchequeno
        '
        Me.txtchequeno.Location = New System.Drawing.Point(127, 81)
        Me.txtchequeno.Name = "txtchequeno"
        Me.txtchequeno.Size = New System.Drawing.Size(178, 20)
        Me.txtchequeno.TabIndex = 7
        '
        'ddlcr_dr
        '
        Me.ddlcr_dr.FormattingEnabled = True
        Me.ddlcr_dr.Location = New System.Drawing.Point(457, 75)
        Me.ddlcr_dr.Name = "ddlcr_dr"
        Me.ddlcr_dr.Size = New System.Drawing.Size(177, 21)
        Me.ddlcr_dr.TabIndex = 14
        '
        'dtpchequedt
        '
        Me.dtpchequedt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpchequedt.Location = New System.Drawing.Point(286, 111)
        Me.dtpchequedt.Name = "dtpchequedt"
        Me.dtpchequedt.Size = New System.Drawing.Size(19, 20)
        Me.dtpchequedt.TabIndex = 8
        '
        'dtpreferencedt
        '
        Me.dtpreferencedt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpreferencedt.Location = New System.Drawing.Point(616, 47)
        Me.dtpreferencedt.Name = "dtpreferencedt"
        Me.dtpreferencedt.Size = New System.Drawing.Size(16, 20)
        Me.dtpreferencedt.TabIndex = 13
        '
        'LabelChequeDate
        '
        Me.LabelChequeDate.AutoSize = True
        Me.LabelChequeDate.Location = New System.Drawing.Point(16, 117)
        Me.LabelChequeDate.Name = "LabelChequeDate"
        Me.LabelChequeDate.Size = New System.Drawing.Size(68, 13)
        Me.LabelChequeDate.TabIndex = 9
        Me.LabelChequeDate.Text = "Cheque date"
        '
        'LabelReferenceDate
        '
        Me.LabelReferenceDate.AutoSize = True
        Me.LabelReferenceDate.Location = New System.Drawing.Point(351, 47)
        Me.LabelReferenceDate.Name = "LabelReferenceDate"
        Me.LabelReferenceDate.Size = New System.Drawing.Size(83, 13)
        Me.LabelReferenceDate.TabIndex = 12
        Me.LabelReferenceDate.Text = "Reference Date"
        '
        'txtreferenceno
        '
        Me.txtreferenceno.Location = New System.Drawing.Point(457, 17)
        Me.txtreferenceno.Name = "txtreferenceno"
        Me.txtreferenceno.Size = New System.Drawing.Size(177, 20)
        Me.txtreferenceno.TabIndex = 11
        '
        'LabelReferenceNo
        '
        Me.LabelReferenceNo.AutoSize = True
        Me.LabelReferenceNo.Location = New System.Drawing.Point(351, 19)
        Me.LabelReferenceNo.Name = "LabelReferenceNo"
        Me.LabelReferenceNo.Size = New System.Drawing.Size(74, 13)
        Me.LabelReferenceNo.TabIndex = 10
        Me.LabelReferenceNo.Text = "Reference No"
        '
        'dgvdetail
        '
        Me.dgvdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvdetail.Location = New System.Drawing.Point(34, 387)
        Me.dgvdetail.Name = "dgvdetail"
        Me.dgvdetail.Size = New System.Drawing.Size(675, 146)
        Me.dgvdetail.TabIndex = 28
        '
        'txtvoucher_link
        '
        Me.txtvoucher_link.Location = New System.Drawing.Point(141, 9)
        Me.txtvoucher_link.Name = "txtvoucher_link"
        Me.txtvoucher_link.ReadOnly = True
        Me.txtvoucher_link.Size = New System.Drawing.Size(152, 20)
        Me.txtvoucher_link.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Voucher Link"
        '
        'txtvoucher_date
        '
        Me.txtvoucher_date.Location = New System.Drawing.Point(463, 9)
        Me.txtvoucher_date.Name = "txtvoucher_date"
        Me.txtvoucher_date.ReadOnly = True
        Me.txtvoucher_date.Size = New System.Drawing.Size(138, 20)
        Me.txtvoucher_date.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(331, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Voucher Link Date"
        '
        'txtconfirmedvoucher_dt
        '
        Me.txtconfirmedvoucher_dt.Location = New System.Drawing.Point(463, 39)
        Me.txtconfirmedvoucher_dt.Name = "txtconfirmedvoucher_dt"
        Me.txtconfirmedvoucher_dt.ReadOnly = True
        Me.txtconfirmedvoucher_dt.Size = New System.Drawing.Size(138, 20)
        Me.txtconfirmedvoucher_dt.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(331, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Confirmed Voucher Date"
        '
        'txtconfirmedvoucher
        '
        Me.txtconfirmedvoucher.Location = New System.Drawing.Point(141, 43)
        Me.txtconfirmedvoucher.Name = "txtconfirmedvoucher"
        Me.txtconfirmedvoucher.ReadOnly = True
        Me.txtconfirmedvoucher.Size = New System.Drawing.Size(152, 20)
        Me.txtconfirmedvoucher.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Confirmed Voucher"
        '
        'txtnarration
        '
        Me.txtnarration.Location = New System.Drawing.Point(141, 130)
        Me.txtnarration.Name = "txtnarration"
        Me.txtnarration.ReadOnly = True
        Me.txtnarration.Size = New System.Drawing.Size(473, 20)
        Me.txtnarration.TabIndex = 38
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Voucher Narration"
        '
        'txtvoucheramount
        '
        Me.txtvoucheramount.Location = New System.Drawing.Point(141, 104)
        Me.txtvoucheramount.Name = "txtvoucheramount"
        Me.txtvoucheramount.ReadOnly = True
        Me.txtvoucheramount.Size = New System.Drawing.Size(152, 20)
        Me.txtvoucheramount.TabIndex = 36
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Voucher  Amount" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtcheckref_date
        '
        Me.txtcheckref_date.Location = New System.Drawing.Point(463, 70)
        Me.txtcheckref_date.Name = "txtcheckref_date"
        Me.txtcheckref_date.ReadOnly = True
        Me.txtcheckref_date.Size = New System.Drawing.Size(138, 20)
        Me.txtcheckref_date.TabIndex = 34
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(331, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 13)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Check/Reference Date"
        '
        'txtcheck_ref
        '
        Me.txtcheck_ref.Location = New System.Drawing.Point(141, 70)
        Me.txtcheck_ref.Name = "txtcheck_ref"
        Me.txtcheck_ref.ReadOnly = True
        Me.txtcheck_ref.Size = New System.Drawing.Size(152, 20)
        Me.txtcheck_ref.TabIndex = 32
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Check /Reference"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtcheck_ref)
        Me.GroupBox2.Controls.Add(Me.txtnarration)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtconfirmedvoucher_dt)
        Me.GroupBox2.Controls.Add(Me.txtvoucher_date)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtvoucher_link)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtconfirmedvoucher)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtcheckref_date)
        Me.GroupBox2.Controls.Add(Me.txtvoucheramount)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(34, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(675, 166)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        '
        'frmVoucherDetailsvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 545)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvdetail)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmVoucherDetailsvb"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvdetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents txtreferencedt As System.Windows.Forms.TextBox
    Friend WithEvents btnconfirm As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents txtchequedt As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents LabelDaybookCode As System.Windows.Forms.Label
    Friend WithEvents txtpayeenm As System.Windows.Forms.TextBox
    Friend WithEvents LabelNameOfPayee As System.Windows.Forms.Label
    Friend WithEvents txtamount As System.Windows.Forms.TextBox
    Friend WithEvents ddldaybookcode As System.Windows.Forms.ComboBox
    Friend WithEvents LabelAmount As System.Windows.Forms.Label
    Friend WithEvents LabelChequeNo As System.Windows.Forms.Label
    Friend WithEvents LabelCreditDebit As System.Windows.Forms.Label
    Friend WithEvents txtchequeno As System.Windows.Forms.TextBox
    Friend WithEvents ddlcr_dr As System.Windows.Forms.ComboBox
    Friend WithEvents dtpchequedt As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpreferencedt As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelChequeDate As System.Windows.Forms.Label
    Friend WithEvents LabelReferenceDate As System.Windows.Forms.Label
    Friend WithEvents txtreferenceno As System.Windows.Forms.TextBox
    Friend WithEvents LabelReferenceNo As System.Windows.Forms.Label
    Friend WithEvents dgvdetail As System.Windows.Forms.DataGridView
    Friend WithEvents txtnarration As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtvoucheramount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtcheckref_date As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcheck_ref As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtconfirmedvoucher_dt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtconfirmedvoucher As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtvoucher_date As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtvoucher_link As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class

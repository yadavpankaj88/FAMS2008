<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashBankContraV
    Inherits Form

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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblVchRefNo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxGoesOut = New System.Windows.Forms.ComboBox()
        Me.panelVoucherControls = New System.Windows.Forms.Panel()
        Me.ComboBoxGoesInto = New System.Windows.Forms.ComboBox()
        Me.LabelDescription1 = New System.Windows.Forms.Label()
        Me.TextBoxAmount = New System.Windows.Forms.TextBox()
        Me.LabelNameOfPayee = New System.Windows.Forms.Label()
        Me.TextBoxNameOfPayee = New System.Windows.Forms.TextBox()
        Me.datepickerChequeDate = New System.Windows.Forms.DateTimePicker()
        Me.LabelChequeDate = New System.Windows.Forms.Label()
        Me.LabelChequeNo = New System.Windows.Forms.Label()
        Me.TextBoxChequeNo = New System.Windows.Forms.TextBox()
        Me.LabelAmount = New System.Windows.Forms.Label()
        Me.pnlConfirm = New System.Windows.Forms.Panel()
        Me.lblVoucherConfNo = New System.Windows.Forms.Label()
        Me.lblConfirmedVoucherNumber = New System.Windows.Forms.Label()
        Me.lblVoucherNo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.datepickerVoucherConfirm = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLinkVoucherNumber = New System.Windows.Forms.TextBox()
        Me.DatePickerVoucherDate = New System.Windows.Forms.DateTimePicker()
        Me.LabelVoucherDate = New System.Windows.Forms.Label()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.panelVoucherControls.SuspendLayout()
        Me.pnlConfirm.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(14, 2)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblVchRefNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxGoesOut)
        Me.SplitContainer1.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.panelVoucherControls)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtLinkVoucherNumber)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DatePickerVoucherDate)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LabelVoucherDate)
        Me.SplitContainer1.Panel2Collapsed = True
        Me.SplitContainer1.Size = New System.Drawing.Size(757, 428)
        Me.SplitContainer1.SplitterDistance = 41
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 0
        '
        'lblVchRefNo
        '
        Me.lblVchRefNo.AutoSize = True
        Me.lblVchRefNo.Location = New System.Drawing.Point(400, 21)
        Me.lblVchRefNo.Name = "lblVchRefNo"
        Me.lblVchRefNo.Size = New System.Drawing.Size(0, 14)
        Me.lblVchRefNo.TabIndex = 23
        Me.lblVchRefNo.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Amount goes out of"
        '
        'ComboBoxGoesOut
        '
        Me.ComboBoxGoesOut.FormattingEnabled = True
        Me.ComboBoxGoesOut.Location = New System.Drawing.Point(135, 15)
        Me.ComboBoxGoesOut.Name = "ComboBoxGoesOut"
        Me.ComboBoxGoesOut.Size = New System.Drawing.Size(234, 22)
        Me.ComboBoxGoesOut.TabIndex = 0
        '
        'panelVoucherControls
        '
        Me.panelVoucherControls.Controls.Add(Me.ComboBoxGoesInto)
        Me.panelVoucherControls.Controls.Add(Me.LabelDescription1)
        Me.panelVoucherControls.Controls.Add(Me.TextBoxAmount)
        Me.panelVoucherControls.Controls.Add(Me.LabelNameOfPayee)
        Me.panelVoucherControls.Controls.Add(Me.TextBoxNameOfPayee)
        Me.panelVoucherControls.Controls.Add(Me.datepickerChequeDate)
        Me.panelVoucherControls.Controls.Add(Me.LabelChequeDate)
        Me.panelVoucherControls.Controls.Add(Me.LabelChequeNo)
        Me.panelVoucherControls.Controls.Add(Me.TextBoxChequeNo)
        Me.panelVoucherControls.Controls.Add(Me.LabelAmount)
        Me.panelVoucherControls.Controls.Add(Me.pnlConfirm)
        Me.panelVoucherControls.Location = New System.Drawing.Point(10, 29)
        Me.panelVoucherControls.Name = "panelVoucherControls"
        Me.panelVoucherControls.Size = New System.Drawing.Size(744, 190)
        Me.panelVoucherControls.TabIndex = 25
        '
        'ComboBoxGoesInto
        '
        Me.ComboBoxGoesInto.FormattingEnabled = True
        Me.ComboBoxGoesInto.Location = New System.Drawing.Point(156, 122)
        Me.ComboBoxGoesInto.Name = "ComboBoxGoesInto"
        Me.ComboBoxGoesInto.Size = New System.Drawing.Size(234, 22)
        Me.ComboBoxGoesInto.TabIndex = 3
        '
        'LabelDescription1
        '
        Me.LabelDescription1.AutoSize = True
        Me.LabelDescription1.Location = New System.Drawing.Point(10, 122)
        Me.LabelDescription1.Name = "LabelDescription1"
        Me.LabelDescription1.Size = New System.Drawing.Size(103, 14)
        Me.LabelDescription1.TabIndex = 10
        Me.LabelDescription1.Text = "Amount goes into"
        '
        'TextBoxAmount
        '
        Me.TextBoxAmount.Location = New System.Drawing.Point(156, 87)
        Me.TextBoxAmount.Name = "TextBoxAmount"
        Me.TextBoxAmount.Size = New System.Drawing.Size(122, 22)
        Me.TextBoxAmount.TabIndex = 2
        '
        'LabelNameOfPayee
        '
        Me.LabelNameOfPayee.AutoSize = True
        Me.LabelNameOfPayee.Location = New System.Drawing.Point(10, 157)
        Me.LabelNameOfPayee.Name = "LabelNameOfPayee"
        Me.LabelNameOfPayee.Size = New System.Drawing.Size(69, 14)
        Me.LabelNameOfPayee.TabIndex = 4
        Me.LabelNameOfPayee.Text = "Description"
        '
        'TextBoxNameOfPayee
        '
        Me.TextBoxNameOfPayee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxNameOfPayee.Location = New System.Drawing.Point(156, 157)
        Me.TextBoxNameOfPayee.Name = "TextBoxNameOfPayee"
        Me.TextBoxNameOfPayee.Size = New System.Drawing.Size(501, 22)
        Me.TextBoxNameOfPayee.TabIndex = 4
        '
        'datepickerChequeDate
        '
        Me.datepickerChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datepickerChequeDate.Location = New System.Drawing.Point(543, 52)
        Me.datepickerChequeDate.Name = "datepickerChequeDate"
        Me.datepickerChequeDate.Size = New System.Drawing.Size(114, 22)
        Me.datepickerChequeDate.TabIndex = 1
        '
        'LabelChequeDate
        '
        Me.LabelChequeDate.AutoSize = True
        Me.LabelChequeDate.Location = New System.Drawing.Point(454, 52)
        Me.LabelChequeDate.Name = "LabelChequeDate"
        Me.LabelChequeDate.Size = New System.Drawing.Size(76, 14)
        Me.LabelChequeDate.TabIndex = 9
        Me.LabelChequeDate.Text = "Cheque date"
        '
        'LabelChequeNo
        '
        Me.LabelChequeNo.AutoSize = True
        Me.LabelChequeNo.Location = New System.Drawing.Point(10, 52)
        Me.LabelChequeNo.Name = "LabelChequeNo"
        Me.LabelChequeNo.Size = New System.Drawing.Size(65, 14)
        Me.LabelChequeNo.TabIndex = 6
        Me.LabelChequeNo.Text = "Cheque no"
        '
        'TextBoxChequeNo
        '
        Me.TextBoxChequeNo.Location = New System.Drawing.Point(156, 52)
        Me.TextBoxChequeNo.MaxLength = 6
        Me.TextBoxChequeNo.Name = "TextBoxChequeNo"
        Me.TextBoxChequeNo.Size = New System.Drawing.Size(278, 22)
        Me.TextBoxChequeNo.TabIndex = 0
        '
        'LabelAmount
        '
        Me.LabelAmount.AutoSize = True
        Me.LabelAmount.Location = New System.Drawing.Point(10, 87)
        Me.LabelAmount.Name = "LabelAmount"
        Me.LabelAmount.Size = New System.Drawing.Size(147, 14)
        Me.LabelAmount.TabIndex = 16
        Me.LabelAmount.Text = "Amount being transferred"
        '
        'pnlConfirm
        '
        Me.pnlConfirm.Controls.Add(Me.lblVoucherConfNo)
        Me.pnlConfirm.Controls.Add(Me.lblConfirmedVoucherNumber)
        Me.pnlConfirm.Controls.Add(Me.lblVoucherNo)
        Me.pnlConfirm.Controls.Add(Me.Label3)
        Me.pnlConfirm.Controls.Add(Me.datepickerVoucherConfirm)
        Me.pnlConfirm.Location = New System.Drawing.Point(5, 6)
        Me.pnlConfirm.Name = "pnlConfirm"
        Me.pnlConfirm.Size = New System.Drawing.Size(736, 31)
        Me.pnlConfirm.TabIndex = 25
        Me.pnlConfirm.Visible = False
        '
        'lblVoucherConfNo
        '
        Me.lblVoucherConfNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVoucherConfNo.Location = New System.Drawing.Point(149, 5)
        Me.lblVoucherConfNo.Name = "lblVoucherConfNo"
        Me.lblVoucherConfNo.Size = New System.Drawing.Size(172, 22)
        Me.lblVoucherConfNo.TabIndex = 23
        Me.lblVoucherConfNo.Text = "Will Appear After Confirmation"
        '
        'lblConfirmedVoucherNumber
        '
        Me.lblConfirmedVoucherNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblConfirmedVoucherNumber.Location = New System.Drawing.Point(343, 5)
        Me.lblConfirmedVoucherNumber.Name = "lblConfirmedVoucherNumber"
        Me.lblConfirmedVoucherNumber.Size = New System.Drawing.Size(100, 22)
        Me.lblConfirmedVoucherNumber.TabIndex = 22
        '
        'lblVoucherNo
        '
        Me.lblVoucherNo.AutoSize = True
        Me.lblVoucherNo.Location = New System.Drawing.Point(5, 5)
        Me.lblVoucherNo.Name = "lblVoucherNo"
        Me.lblVoucherNo.Size = New System.Drawing.Size(116, 14)
        Me.lblVoucherNo.TabIndex = 20
        Me.lblVoucherNo.Text = "Confirmed Voucher #"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(461, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 14)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Confirmation Date"
        '
        'datepickerVoucherConfirm
        '
        Me.datepickerVoucherConfirm.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datepickerVoucherConfirm.Location = New System.Drawing.Point(617, 6)
        Me.datepickerVoucherConfirm.Name = "datepickerVoucherConfirm"
        Me.datepickerVoucherConfirm.Size = New System.Drawing.Size(114, 22)
        Me.datepickerVoucherConfirm.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 14)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Link Voucher Number"
        '
        'txtLinkVoucherNumber
        '
        Me.txtLinkVoucherNumber.AcceptsReturn = True
        Me.txtLinkVoucherNumber.Location = New System.Drawing.Point(161, 6)
        Me.txtLinkVoucherNumber.Name = "txtLinkVoucherNumber"
        Me.txtLinkVoucherNumber.Size = New System.Drawing.Size(172, 22)
        Me.txtLinkVoucherNumber.TabIndex = 0
        '
        'DatePickerVoucherDate
        '
        Me.DatePickerVoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatePickerVoucherDate.Location = New System.Drawing.Point(627, 6)
        Me.DatePickerVoucherDate.Name = "DatePickerVoucherDate"
        Me.DatePickerVoucherDate.Size = New System.Drawing.Size(110, 22)
        Me.DatePickerVoucherDate.TabIndex = 1
        '
        'LabelVoucherDate
        '
        Me.LabelVoucherDate.AutoSize = True
        Me.LabelVoucherDate.Location = New System.Drawing.Point(471, 7)
        Me.LabelVoucherDate.Name = "LabelVoucherDate"
        Me.LabelVoucherDate.Size = New System.Drawing.Size(102, 14)
        Me.LabelVoucherDate.TabIndex = 21
        Me.LabelVoucherDate.Text = "Link voucher date"
        '
        'frmCashBankContraV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 305)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCashBankContraV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cash Bank Contra Vouchers"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.panelVoucherControls.ResumeLayout(False)
        Me.panelVoucherControls.PerformLayout()
        Me.pnlConfirm.ResumeLayout(False)
        Me.pnlConfirm.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxGoesOut As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLinkVoucherNumber As System.Windows.Forms.TextBox
    Friend WithEvents DatePickerVoucherDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelVoucherDate As System.Windows.Forms.Label
    Friend WithEvents panelVoucherControls As System.Windows.Forms.Panel
    Friend WithEvents LabelDescription1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAmount As System.Windows.Forms.TextBox
    Friend WithEvents LabelAmount As System.Windows.Forms.Label
    Friend WithEvents LabelNameOfPayee As System.Windows.Forms.Label
    Friend WithEvents TextBoxNameOfPayee As System.Windows.Forms.TextBox
    Friend WithEvents datepickerChequeDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelChequeDate As System.Windows.Forms.Label
    Friend WithEvents LabelChequeNo As System.Windows.Forms.Label
    Friend WithEvents TextBoxChequeNo As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxGoesInto As System.Windows.Forms.ComboBox
    Friend WithEvents pnlConfirm As System.Windows.Forms.Panel
    Friend WithEvents lblConfirmedVoucherNumber As System.Windows.Forms.Label
    Friend WithEvents lblVoucherNo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents datepickerVoucherConfirm As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblVchRefNo As System.Windows.Forms.Label
    Friend WithEvents lblVoucherConfNo As System.Windows.Forms.Label
End Class

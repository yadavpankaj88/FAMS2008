<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddJournalVoucher
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.LabelNarration = New System.Windows.Forms.Label
        Me.TextBoxNarration = New System.Windows.Forms.TextBox
        Me.LabelVoucherDate = New System.Windows.Forms.Label
        Me.DatePickerVoucherLinkDate = New System.Windows.Forms.DateTimePicker
        Me.txtLinkVoucherNumber = New System.Windows.Forms.TextBox
        Me.lblLinkVoucherNumber = New System.Windows.Forms.Label
        Me.panelVoucherControls = New System.Windows.Forms.Panel
        Me.dgvVoucherDetails = New System.Windows.Forms.DataGridView
        Me.SeqNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LedgerAccount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccountName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.hiddenRowNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitCr = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.RefNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RefDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoucherDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlConfirm = New System.Windows.Forms.Panel
        Me.lblConfirmNumber = New System.Windows.Forms.Label
        Me.lblConfirmedVoucherNumber = New System.Windows.Forms.Label
        Me.lblVoucherNo = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.datepickerVoucherDateConfirm = New System.Windows.Forms.DateTimePicker
        Me.ComboBoxDaybookSelect = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblDaybookName = New System.Windows.Forms.Label
        Me.lblDbkNm = New System.Windows.Forms.Label
        Me.txtNextCount = New System.Windows.Forms.TextBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lableVoucherStatus = New System.Windows.Forms.Label
        Me.VoucherDetailsDeleteMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.panelVoucherControls.SuspendLayout()
        CType(Me.dgvVoucherDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConfirm.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.VoucherDetailsDeleteMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelNarration
        '
        Me.LabelNarration.AutoSize = True
        Me.LabelNarration.Location = New System.Drawing.Point(467, 95)
        Me.LabelNarration.Name = "LabelNarration"
        Me.LabelNarration.Size = New System.Drawing.Size(64, 15)
        Me.LabelNarration.TabIndex = 10
        Me.LabelNarration.Text = "Narration"
        '
        'TextBoxNarration
        '
        Me.TextBoxNarration.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxNarration.Location = New System.Drawing.Point(619, 95)
        Me.TextBoxNarration.MaxLength = 6
        Me.TextBoxNarration.Multiline = True
        Me.TextBoxNarration.Name = "TextBoxNarration"
        Me.TextBoxNarration.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxNarration.TabIndex = 10
        '
        'LabelVoucherDate
        '
        Me.LabelVoucherDate.AutoSize = True
        Me.LabelVoucherDate.Location = New System.Drawing.Point(477, 14)
        Me.LabelVoucherDate.Name = "LabelVoucherDate"
        Me.LabelVoucherDate.Size = New System.Drawing.Size(104, 15)
        Me.LabelVoucherDate.TabIndex = 0
        Me.LabelVoucherDate.Text = "Voucher Link Date"
        '
        'DatePickerVoucherLinkDate
        '
        Me.DatePickerVoucherLinkDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatePickerVoucherLinkDate.Location = New System.Drawing.Point(633, 12)
        Me.DatePickerVoucherLinkDate.Name = "DatePickerVoucherLinkDate"
        Me.DatePickerVoucherLinkDate.Size = New System.Drawing.Size(110, 23)
        Me.DatePickerVoucherLinkDate.TabIndex = 1
        '
        'txtLinkVoucherNumber
        '
        Me.txtLinkVoucherNumber.AcceptsReturn = True
        Me.txtLinkVoucherNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLinkVoucherNumber.Location = New System.Drawing.Point(167, 12)
        Me.txtLinkVoucherNumber.Name = "txtLinkVoucherNumber"
        Me.txtLinkVoucherNumber.Size = New System.Drawing.Size(172, 23)
        Me.txtLinkVoucherNumber.TabIndex = 0
        '
        'lblLinkVoucherNumber
        '
        Me.lblLinkVoucherNumber.AutoSize = True
        Me.lblLinkVoucherNumber.Location = New System.Drawing.Point(21, 15)
        Me.lblLinkVoucherNumber.Name = "lblLinkVoucherNumber"
        Me.lblLinkVoucherNumber.Size = New System.Drawing.Size(122, 15)
        Me.lblLinkVoucherNumber.TabIndex = 19
        Me.lblLinkVoucherNumber.Text = "Voucher Link Number"
        '
        'panelVoucherControls
        '
        Me.panelVoucherControls.Controls.Add(Me.dgvVoucherDetails)
        Me.panelVoucherControls.Location = New System.Drawing.Point(10, 92)
        Me.panelVoucherControls.Name = "panelVoucherControls"
        Me.panelVoucherControls.Size = New System.Drawing.Size(923, 342)
        Me.panelVoucherControls.TabIndex = 22
        '
        'dgvVoucherDetails
        '
        Me.dgvVoucherDetails.AllowUserToDeleteRows = False
        Me.dgvVoucherDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVoucherDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SeqNo, Me.LedgerAccount, Me.AccountName, Me.hiddenRowNumber, Me.Amount, Me.DebitCr, Me.RefNo, Me.RefDate, Me.VoucherDesc})
        Me.dgvVoucherDetails.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvVoucherDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvVoucherDetails.Location = New System.Drawing.Point(0, 3)
        Me.dgvVoucherDetails.Name = "dgvVoucherDetails"
        Me.dgvVoucherDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVoucherDetails.Size = New System.Drawing.Size(923, 339)
        Me.dgvVoucherDetails.TabIndex = 17
        '
        'SeqNo
        '
        Me.SeqNo.DataPropertyName = "VD_Seq_No"
        Me.SeqNo.HeaderText = "SeqNo"
        Me.SeqNo.Name = "SeqNo"
        Me.SeqNo.ReadOnly = True
        Me.SeqNo.Width = 60
        '
        'LedgerAccount
        '
        Me.LedgerAccount.DataPropertyName = "LedgerAccount"
        Me.LedgerAccount.HeaderText = "G/L Acc"
        Me.LedgerAccount.Name = "LedgerAccount"
        Me.LedgerAccount.Width = 80
        '
        'AccountName
        '
        Me.AccountName.DataPropertyName = "AccountName"
        Me.AccountName.HeaderText = "Account Name"
        Me.AccountName.Name = "AccountName"
        Me.AccountName.ReadOnly = True
        Me.AccountName.Width = 150
        '
        'hiddenRowNumber
        '
        Me.hiddenRowNumber.DataPropertyName = "RowNumber"
        Me.hiddenRowNumber.HeaderText = "RowNumber"
        Me.hiddenRowNumber.Name = "hiddenRowNumber"
        Me.hiddenRowNumber.Visible = False
        '
        'Amount
        '
        Me.Amount.DataPropertyName = "Amount"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle1
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        '
        'DebitCr
        '
        Me.DebitCr.DataPropertyName = "CrDr"
        Me.DebitCr.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DebitCr.HeaderText = ""
        Me.DebitCr.Items.AddRange(New Object() {"Dr", "Cr"})
        Me.DebitCr.Name = "DebitCr"
        Me.DebitCr.Width = 50
        '
        'RefNo
        '
        Me.RefNo.DataPropertyName = "RefNo"
        Me.RefNo.HeaderText = "Reference Number"
        Me.RefNo.Name = "RefNo"
        '
        'RefDate
        '
        Me.RefDate.DataPropertyName = "RefDate"
        Me.RefDate.HeaderText = "Reference Date"
        Me.RefDate.Name = "RefDate"
        '
        'VoucherDesc
        '
        Me.VoucherDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.VoucherDesc.DataPropertyName = "VoucherDesc"
        Me.VoucherDesc.HeaderText = "Voucher Description"
        Me.VoucherDesc.Name = "VoucherDesc"
        '
        'pnlConfirm
        '
        Me.pnlConfirm.Controls.Add(Me.lblConfirmNumber)
        Me.pnlConfirm.Controls.Add(Me.lblConfirmedVoucherNumber)
        Me.pnlConfirm.Controls.Add(Me.lblVoucherNo)
        Me.pnlConfirm.Controls.Add(Me.Label3)
        Me.pnlConfirm.Controls.Add(Me.datepickerVoucherDateConfirm)
        Me.pnlConfirm.Location = New System.Drawing.Point(3, 42)
        Me.pnlConfirm.Name = "pnlConfirm"
        Me.pnlConfirm.Size = New System.Drawing.Size(912, 46)
        Me.pnlConfirm.TabIndex = 20
        '
        'lblConfirmNumber
        '
        Me.lblConfirmNumber.AutoSize = True
        Me.lblConfirmNumber.Location = New System.Drawing.Point(161, 20)
        Me.lblConfirmNumber.Name = "lblConfirmNumber"
        Me.lblConfirmNumber.Size = New System.Drawing.Size(0, 15)
        Me.lblConfirmNumber.TabIndex = 23
        '
        'lblConfirmedVoucherNumber
        '
        Me.lblConfirmedVoucherNumber.AutoSize = True
        Me.lblConfirmedVoucherNumber.Location = New System.Drawing.Point(238, 20)
        Me.lblConfirmedVoucherNumber.Name = "lblConfirmedVoucherNumber"
        Me.lblConfirmedVoucherNumber.Size = New System.Drawing.Size(0, 15)
        Me.lblConfirmedVoucherNumber.TabIndex = 22
        '
        'lblVoucherNo
        '
        Me.lblVoucherNo.AutoSize = True
        Me.lblVoucherNo.Location = New System.Drawing.Point(18, 22)
        Me.lblVoucherNo.Name = "lblVoucherNo"
        Me.lblVoucherNo.Size = New System.Drawing.Size(119, 15)
        Me.lblVoucherNo.TabIndex = 20
        Me.lblVoucherNo.Text = "Confirmed Voucher #"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(474, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 15)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Confirmation Date"
        '
        'datepickerVoucherDateConfirm
        '
        Me.datepickerVoucherDateConfirm.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datepickerVoucherDateConfirm.Location = New System.Drawing.Point(630, 16)
        Me.datepickerVoucherDateConfirm.Name = "datepickerVoucherDateConfirm"
        Me.datepickerVoucherDateConfirm.Size = New System.Drawing.Size(114, 23)
        Me.datepickerVoucherDateConfirm.TabIndex = 19
        '
        'ComboBoxDaybookSelect
        '
        Me.ComboBoxDaybookSelect.FormattingEnabled = True
        Me.ComboBoxDaybookSelect.Location = New System.Drawing.Point(166, 7)
        Me.ComboBoxDaybookSelect.Name = "ComboBoxDaybookSelect"
        Me.ComboBoxDaybookSelect.Size = New System.Drawing.Size(278, 22)
        Me.ComboBoxDaybookSelect.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Daybook"
        '
        'lblDaybookName
        '
        Me.lblDaybookName.AutoSize = True
        Me.lblDaybookName.Location = New System.Drawing.Point(334, 10)
        Me.lblDaybookName.Name = "lblDaybookName"
        Me.lblDaybookName.Size = New System.Drawing.Size(0, 14)
        Me.lblDaybookName.TabIndex = 5
        '
        'lblDbkNm
        '
        Me.lblDbkNm.AutoSize = True
        Me.lblDbkNm.Location = New System.Drawing.Point(328, 10)
        Me.lblDbkNm.Name = "lblDbkNm"
        Me.lblDbkNm.Size = New System.Drawing.Size(0, 14)
        Me.lblDbkNm.TabIndex = 6
        Me.lblDbkNm.Visible = False
        '
        'txtNextCount
        '
        Me.txtNextCount.Location = New System.Drawing.Point(450, 7)
        Me.txtNextCount.Name = "txtNextCount"
        Me.txtNextCount.Size = New System.Drawing.Size(100, 22)
        Me.txtNextCount.TabIndex = 7
        Me.txtNextCount.Visible = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 12)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lableVoucherStatus)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtNextCount)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblDbkNm)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblDaybookName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxDaybookSelect)
        Me.SplitContainer1.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlConfirm)
        Me.SplitContainer1.Panel2.Controls.Add(Me.panelVoucherControls)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblLinkVoucherNumber)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtLinkVoucherNumber)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DatePickerVoucherLinkDate)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LabelVoucherDate)
        Me.SplitContainer1.Panel2Collapsed = True
        Me.SplitContainer1.Size = New System.Drawing.Size(935, 508)
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 22
        '
        'lableVoucherStatus
        '
        Me.lableVoucherStatus.AutoSize = True
        Me.lableVoucherStatus.Location = New System.Drawing.Point(749, 10)
        Me.lableVoucherStatus.Name = "lableVoucherStatus"
        Me.lableVoucherStatus.Size = New System.Drawing.Size(0, 14)
        Me.lableVoucherStatus.TabIndex = 9
        '
        'VoucherDetailsDeleteMenu
        '
        Me.VoucherDetailsDeleteMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.VoucherDetailsDeleteMenu.Name = "VoucherDetailsDeleteMenu"
        Me.VoucherDetailsDeleteMenu.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'frmAddJournalVoucher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 543)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddJournalVoucher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.panelVoucherControls.ResumeLayout(False)
        CType(Me.dgvVoucherDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConfirm.ResumeLayout(False)
        Me.pnlConfirm.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.VoucherDetailsDeleteMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelNarration As System.Windows.Forms.Label
    Friend WithEvents TextBoxNarration As System.Windows.Forms.TextBox
    Friend WithEvents LabelVoucherDate As System.Windows.Forms.Label
    Friend WithEvents DatePickerVoucherLinkDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtLinkVoucherNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblLinkVoucherNumber As System.Windows.Forms.Label
    Friend WithEvents panelVoucherControls As System.Windows.Forms.Panel
    Friend WithEvents dgvVoucherDetails As System.Windows.Forms.DataGridView
    Friend WithEvents pnlConfirm As System.Windows.Forms.Panel
    Friend WithEvents lblConfirmNumber As System.Windows.Forms.Label
    Friend WithEvents lblConfirmedVoucherNumber As System.Windows.Forms.Label
    Friend WithEvents lblVoucherNo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents datepickerVoucherDateConfirm As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboBoxDaybookSelect As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDaybookName As System.Windows.Forms.Label
    Friend WithEvents lblDbkNm As System.Windows.Forms.Label
    Friend WithEvents txtNextCount As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lableVoucherStatus As System.Windows.Forms.Label
    Friend WithEvents SeqNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LedgerAccount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hiddenRowNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitCr As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents RefNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoucherDetailsDeleteMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFAMSMain
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.msMainMenu = New System.Windows.Forms.MenuStrip()
        Me.mnuMasters = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUserMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLedgeAccMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCashBBmaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSubsidairyMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFinStatsScheduleMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstitutionalMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuStep = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCashBankContra = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAccCash = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAccCheque = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDDActivities = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCashReceiptV = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCashPayV = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBankReceiptV = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBankPayV = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCashContraV = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuJournalV = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEDCBank = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRandQ = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectiveCashBookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUtilities = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeOWNPasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnlockUserIdToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtractUserSpecifiedDetailsToExcelFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateCashVoucherForMiscReceiptsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeginNewFinancialYearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransferBalanceToNextFinancialYearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseFinancialYearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsDetails = New System.Windows.Forms.ToolStrip()
        Me.mnuInstitutionName = New System.Windows.Forms.ToolStripLabel()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUserID = New System.Windows.Forms.ToolStripLabel()
        Me.mnuFinancialYear = New System.Windows.Forms.ToolStripLabel()
        Me.mnuDateOfProcess = New System.Windows.Forms.ToolStripLabel()
        Me.mnuCash = New System.Windows.Forms.ToolStripLabel()
        Me.msMainMenu.SuspendLayout()
        Me.tsDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'msMainMenu
        '
        Me.msMainMenu.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMasters, Me.mnuStep, Me.mnuDDActivities, Me.mnuRandQ, Me.mnuUtilities})
        Me.msMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMainMenu.Name = "msMainMenu"
        Me.msMainMenu.Size = New System.Drawing.Size(1173, 24)
        Me.msMainMenu.TabIndex = 9
        Me.msMainMenu.Text = "MenuStrip"
        '
        'mnuMasters
        '
        Me.mnuMasters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUserMaster, Me.mnuLedgeAccMaster, Me.mnuCashBBmaster, Me.mnuSubsidairyMaster, Me.mnuFinStatsScheduleMaster, Me.InstitutionalMasterToolStripMenuItem})
        Me.mnuMasters.Name = "mnuMasters"
        Me.mnuMasters.Size = New System.Drawing.Size(63, 20)
        Me.mnuMasters.Text = "Masters"
        '
        'mnuUserMaster
        '
        Me.mnuUserMaster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuUserMaster.Name = "mnuUserMaster"
        Me.mnuUserMaster.Size = New System.Drawing.Size(293, 22)
        Me.mnuUserMaster.Text = "User Master"
        '
        'mnuLedgeAccMaster
        '
        Me.mnuLedgeAccMaster.Name = "mnuLedgeAccMaster"
        Me.mnuLedgeAccMaster.Size = New System.Drawing.Size(293, 22)
        Me.mnuLedgeAccMaster.Text = "Legder Account Master"
        '
        'mnuCashBBmaster
        '
        Me.mnuCashBBmaster.Name = "mnuCashBBmaster"
        Me.mnuCashBBmaster.Size = New System.Drawing.Size(293, 22)
        Me.mnuCashBBmaster.Text = "Cash-Bank Books Master"
        '
        'mnuSubsidairyMaster
        '
        Me.mnuSubsidairyMaster.Name = "mnuSubsidairyMaster"
        Me.mnuSubsidairyMaster.Size = New System.Drawing.Size(293, 22)
        Me.mnuSubsidairyMaster.Text = "Subsidairy Master"
        '
        'mnuFinStatsScheduleMaster
        '
        Me.mnuFinStatsScheduleMaster.Name = "mnuFinStatsScheduleMaster"
        Me.mnuFinStatsScheduleMaster.Size = New System.Drawing.Size(293, 22)
        Me.mnuFinStatsScheduleMaster.Text = "Financial Statements  Schedules Master"
        '
        'InstitutionalMasterToolStripMenuItem
        '
        Me.InstitutionalMasterToolStripMenuItem.Name = "InstitutionalMasterToolStripMenuItem"
        Me.InstitutionalMasterToolStripMenuItem.Size = New System.Drawing.Size(293, 22)
        Me.InstitutionalMasterToolStripMenuItem.Text = "Institutional Master"
        '
        'mnuStep
        '
        Me.mnuStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuStep.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCashBankContra, Me.mnuAccCash, Me.mnuAccCheque})
        Me.mnuStep.Name = "mnuStep"
        Me.mnuStep.Size = New System.Drawing.Size(50, 20)
        Me.mnuStep.Text = "Setup"
        '
        'mnuCashBankContra
        '
        Me.mnuCashBankContra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuCashBankContra.Name = "mnuCashBankContra"
        Me.mnuCashBankContra.Size = New System.Drawing.Size(302, 22)
        Me.mnuCashBankContra.Text = "Cash Bank Contra"
        '
        'mnuAccCash
        '
        Me.mnuAccCash.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuAccCash.Name = "mnuAccCash"
        Me.mnuAccCash.Size = New System.Drawing.Size(302, 22)
        Me.mnuAccCash.Text = "Account for Fees in Cash"
        '
        'mnuAccCheque
        '
        Me.mnuAccCheque.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuAccCheque.Name = "mnuAccCheque"
        Me.mnuAccCheque.Size = New System.Drawing.Size(302, 22)
        Me.mnuAccCheque.Text = "Account for Fees By Cheque/Demand Draft"
        '
        'mnuDDActivities
        '
        Me.mnuDDActivities.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuDDActivities.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCashReceiptV, Me.mnuCashPayV, Me.mnuBankReceiptV, Me.mnuBankPayV, Me.mnuCashContraV, Me.mnuJournalV, Me.mnuEDCBank})
        Me.mnuDDActivities.Name = "mnuDDActivities"
        Me.mnuDDActivities.Size = New System.Drawing.Size(127, 20)
        Me.mnuDDActivities.Text = "Day to Day Activities"
        '
        'mnuCashReceiptV
        '
        Me.mnuCashReceiptV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuCashReceiptV.Name = "mnuCashReceiptV"
        Me.mnuCashReceiptV.Size = New System.Drawing.Size(249, 22)
        Me.mnuCashReceiptV.Text = "Cash Receipt Vouchers"
        '
        'mnuCashPayV
        '
        Me.mnuCashPayV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuCashPayV.Name = "mnuCashPayV"
        Me.mnuCashPayV.Size = New System.Drawing.Size(249, 22)
        Me.mnuCashPayV.Text = "Cash Payment Vouchers"
        '
        'mnuBankReceiptV
        '
        Me.mnuBankReceiptV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuBankReceiptV.Name = "mnuBankReceiptV"
        Me.mnuBankReceiptV.Size = New System.Drawing.Size(249, 22)
        Me.mnuBankReceiptV.Text = "Bank Receipt Vouchers"
        '
        'mnuBankPayV
        '
        Me.mnuBankPayV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuBankPayV.Name = "mnuBankPayV"
        Me.mnuBankPayV.Size = New System.Drawing.Size(249, 22)
        Me.mnuBankPayV.Text = "Bank Payment Vouchers"
        '
        'mnuCashContraV
        '
        Me.mnuCashContraV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuCashContraV.Name = "mnuCashContraV"
        Me.mnuCashContraV.Size = New System.Drawing.Size(249, 22)
        Me.mnuCashContraV.Text = "Cash – Bank Contra Vouchers"
        '
        'mnuJournalV
        '
        Me.mnuJournalV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuJournalV.Name = "mnuJournalV"
        Me.mnuJournalV.Size = New System.Drawing.Size(249, 22)
        Me.mnuJournalV.Text = "Journal Vouchers"
        '
        'mnuEDCBank
        '
        Me.mnuEDCBank.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuEDCBank.Name = "mnuEDCBank"
        Me.mnuEDCBank.Size = New System.Drawing.Size(249, 22)
        Me.mnuEDCBank.Text = "Entry of Date of Clearing in bank"
        '
        'mnuRandQ
        '
        Me.mnuRandQ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuRandQ.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectiveCashBookToolStripMenuItem})
        Me.mnuRandQ.Name = "mnuRandQ"
        Me.mnuRandQ.Size = New System.Drawing.Size(110, 20)
        Me.mnuRandQ.Text = "Reports & Queries"
        '
        'SelectiveCashBookToolStripMenuItem
        '
        Me.SelectiveCashBookToolStripMenuItem.Name = "SelectiveCashBookToolStripMenuItem"
        Me.SelectiveCashBookToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.SelectiveCashBookToolStripMenuItem.Text = "Selective Cash Book"
        '
        'mnuUtilities
        '
        Me.mnuUtilities.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuUtilities.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeOWNPasswordToolStripMenuItem, Me.UnlockUserIdToolStripMenuItem, Me.ExtractUserSpecifiedDetailsToExcelFileToolStripMenuItem, Me.GenerateCashVoucherForMiscReceiptsToolStripMenuItem, Me.BeginNewFinancialYearToolStripMenuItem, Me.TransferBalanceToNextFinancialYearToolStripMenuItem, Me.CloseFinancialYearToolStripMenuItem})
        Me.mnuUtilities.Name = "mnuUtilities"
        Me.mnuUtilities.Size = New System.Drawing.Size(62, 20)
        Me.mnuUtilities.Text = "Utilities"
        '
        'ChangeOWNPasswordToolStripMenuItem
        '
        Me.ChangeOWNPasswordToolStripMenuItem.Name = "ChangeOWNPasswordToolStripMenuItem"
        Me.ChangeOWNPasswordToolStripMenuItem.Size = New System.Drawing.Size(301, 22)
        Me.ChangeOWNPasswordToolStripMenuItem.Text = "Change OWN Password"
        '
        'UnlockUserIdToolStripMenuItem
        '
        Me.UnlockUserIdToolStripMenuItem.Name = "UnlockUserIdToolStripMenuItem"
        Me.UnlockUserIdToolStripMenuItem.Size = New System.Drawing.Size(301, 22)
        Me.UnlockUserIdToolStripMenuItem.Text = "Unlock User-Id"
        '
        'ExtractUserSpecifiedDetailsToExcelFileToolStripMenuItem
        '
        Me.ExtractUserSpecifiedDetailsToExcelFileToolStripMenuItem.Name = "ExtractUserSpecifiedDetailsToExcelFileToolStripMenuItem"
        Me.ExtractUserSpecifiedDetailsToExcelFileToolStripMenuItem.Size = New System.Drawing.Size(301, 22)
        Me.ExtractUserSpecifiedDetailsToExcelFileToolStripMenuItem.Text = "Extract User Specified Details to Excel File"
        '
        'GenerateCashVoucherForMiscReceiptsToolStripMenuItem
        '
        Me.GenerateCashVoucherForMiscReceiptsToolStripMenuItem.Name = "GenerateCashVoucherForMiscReceiptsToolStripMenuItem"
        Me.GenerateCashVoucherForMiscReceiptsToolStripMenuItem.Size = New System.Drawing.Size(301, 22)
        Me.GenerateCashVoucherForMiscReceiptsToolStripMenuItem.Text = "Generate Cash Voucher For Misc. Receipts"
        '
        'BeginNewFinancialYearToolStripMenuItem
        '
        Me.BeginNewFinancialYearToolStripMenuItem.Name = "BeginNewFinancialYearToolStripMenuItem"
        Me.BeginNewFinancialYearToolStripMenuItem.Size = New System.Drawing.Size(301, 22)
        Me.BeginNewFinancialYearToolStripMenuItem.Text = "Begin New Financial Year"
        '
        'TransferBalanceToNextFinancialYearToolStripMenuItem
        '
        Me.TransferBalanceToNextFinancialYearToolStripMenuItem.Name = "TransferBalanceToNextFinancialYearToolStripMenuItem"
        Me.TransferBalanceToNextFinancialYearToolStripMenuItem.Size = New System.Drawing.Size(301, 22)
        Me.TransferBalanceToNextFinancialYearToolStripMenuItem.Text = "Transfer Balance To Next Financial Year"
        '
        'CloseFinancialYearToolStripMenuItem
        '
        Me.CloseFinancialYearToolStripMenuItem.Name = "CloseFinancialYearToolStripMenuItem"
        Me.CloseFinancialYearToolStripMenuItem.Size = New System.Drawing.Size(301, 22)
        Me.CloseFinancialYearToolStripMenuItem.Text = "Close Financial Year"
        '
        'tsDetails
        '
        Me.tsDetails.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tsDetails.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsDetails.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInstitutionName, Me.toolStripSeparator1, Me.mnuUserID, Me.mnuFinancialYear, Me.mnuDateOfProcess, Me.mnuCash})
        Me.tsDetails.Location = New System.Drawing.Point(0, 463)
        Me.tsDetails.Name = "tsDetails"
        Me.tsDetails.Size = New System.Drawing.Size(1173, 25)
        Me.tsDetails.TabIndex = 10
        Me.tsDetails.Text = "ToolStrip"
        '
        'mnuInstitutionName
        '
        Me.mnuInstitutionName.Name = "mnuInstitutionName"
        Me.mnuInstitutionName.Size = New System.Drawing.Size(63, 22)
        Me.mnuInstitutionName.Text = "Institution"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'mnuUserID
        '
        Me.mnuUserID.Name = "mnuUserID"
        Me.mnuUserID.Size = New System.Drawing.Size(53, 22)
        Me.mnuUserID.Text = "User ID :"
        '
        'mnuFinancialYear
        '
        Me.mnuFinancialYear.Name = "mnuFinancialYear"
        Me.mnuFinancialYear.Size = New System.Drawing.Size(36, 22)
        Me.mnuFinancialYear.Text = "Year :"
        '
        'mnuDateOfProcess
        '
        Me.mnuDateOfProcess.Name = "mnuDateOfProcess"
        Me.mnuDateOfProcess.Size = New System.Drawing.Size(39, 22)
        Me.mnuDateOfProcess.Text = "Date :"
        '
        'mnuCash
        '
        Me.mnuCash.Name = "mnuCash"
        Me.mnuCash.Size = New System.Drawing.Size(42, 22)
        Me.mnuCash.Text = "Cash : "
        '
        'frmFAMSMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 488)
        Me.Controls.Add(Me.tsDetails)
        Me.Controls.Add(Me.msMainMenu)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.msMainMenu
        Me.Name = "frmFAMSMain"
        Me.Text = "CASCADE – Financial Accounting Module Developed by ASTUTE Information Management " & _
            "Solutions, C.B.D.Belapur, Navi Mumbai – Contact 98193-12456"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.msMainMenu.ResumeLayout(False)
        Me.msMainMenu.PerformLayout()
        Me.tsDetails.ResumeLayout(False)
        Me.tsDetails.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Private WithEvents msMainMenu As System.Windows.Forms.MenuStrip
    Private WithEvents mnuMasters As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuUserMaster As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuLedgeAccMaster As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuCashBBmaster As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuSubsidairyMaster As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuFinStatsScheduleMaster As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuStep As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuCashBankContra As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuAccCash As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuAccCheque As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuDDActivities As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuCashReceiptV As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuCashPayV As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuBankReceiptV As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuBankPayV As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuCashContraV As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuJournalV As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuEDCBank As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuRandQ As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuUtilities As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsDetails As System.Windows.Forms.ToolStrip
    Private WithEvents mnuInstitutionName As System.Windows.Forms.ToolStripLabel
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuUserID As System.Windows.Forms.ToolStripLabel
    Private WithEvents mnuFinancialYear As System.Windows.Forms.ToolStripLabel
    Private WithEvents mnuDateOfProcess As System.Windows.Forms.ToolStripLabel
    Private WithEvents mnuCash As System.Windows.Forms.ToolStripLabel
    Friend WithEvents InstitutionalMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectiveCashBookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeOWNPasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnlockUserIdToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExtractUserSpecifiedDetailsToExcelFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateCashVoucherForMiscReceiptsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeginNewFinancialYearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransferBalanceToNextFinancialYearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseFinancialYearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class

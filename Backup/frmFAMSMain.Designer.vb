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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFAMSMain))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.mainBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.toolstripAdd = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.toolstripDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolstripedit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonView = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonPrint = New System.Windows.Forms.ToolStripButton()
        Me.toolstripSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonClear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonConfirm = New System.Windows.Forms.ToolStripButton()
        Me.pnlDetails = New System.Windows.Forms.Panel()
        Me.lblBankBalance = New System.Windows.Forms.Label()
        Me.lblCashBalance = New System.Windows.Forms.Label()
        Me.lblActivity = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblInstitution = New System.Windows.Forms.Label()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.msMainMenu = New System.Windows.Forms.MenuStrip()
        Me.mnuMasters = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUserMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLedgeAccMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCashBBmaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSubsidairyMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFinStatsScheduleMaster = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.mnuUtilities = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlNavigator = New System.Windows.Forms.Panel()
        CType(Me.mainBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainBindingNavigator.SuspendLayout()
        Me.pnlDetails.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.msMainMenu.SuspendLayout()
        Me.pnlNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainBindingNavigator
        '
        Me.mainBindingNavigator.AddNewItem = Me.toolstripAdd
        Me.mainBindingNavigator.BackColor = System.Drawing.Color.White
        Me.mainBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.mainBindingNavigator.DeleteItem = Me.toolstripDeleteItem
        Me.mainBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.toolstripAdd, Me.toolstripedit, Me.toolstripDeleteItem, Me.ToolStripButtonView, Me.ToolStripButtonPrint, Me.toolstripSave, Me.ToolStripButtonClear, Me.ToolStripButtonConfirm})
        Me.mainBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.mainBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.mainBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.mainBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.mainBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.mainBindingNavigator.Name = "mainBindingNavigator"
        Me.mainBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.mainBindingNavigator.Size = New System.Drawing.Size(1173, 25)
        Me.mainBindingNavigator.TabIndex = 12
        Me.mainBindingNavigator.Text = "BindingNavigator1"
        '
        'toolstripAdd
        '
        Me.toolstripAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolstripAdd.Image = CType(resources.GetObject("toolstripAdd.Image"), System.Drawing.Image)
        Me.toolstripAdd.Name = "toolstripAdd"
        Me.toolstripAdd.RightToLeftAutoMirrorImage = True
        Me.toolstripAdd.Size = New System.Drawing.Size(23, 22)
        Me.toolstripAdd.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'toolstripDeleteItem
        '
        Me.toolstripDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolstripDeleteItem.Image = Global.FAMS.My.Resources.Resources.delete
        Me.toolstripDeleteItem.Name = "toolstripDeleteItem"
        Me.toolstripDeleteItem.RightToLeftAutoMirrorImage = True
        Me.toolstripDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.toolstripDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolstripedit
        '
        Me.toolstripedit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolstripedit.Image = Global.FAMS.My.Resources.Resources.edit
        Me.toolstripedit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolstripedit.Name = "toolstripedit"
        Me.toolstripedit.Size = New System.Drawing.Size(23, 22)
        Me.toolstripedit.Text = "Edit"
        '
        'ToolStripButtonView
        '
        Me.ToolStripButtonView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonView.Image = Global.FAMS.My.Resources.Resources.view
        Me.ToolStripButtonView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonView.Name = "ToolStripButtonView"
        Me.ToolStripButtonView.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonView.Text = "View"
        Me.ToolStripButtonView.Visible = False
        '
        'ToolStripButtonPrint
        '
        Me.ToolStripButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonPrint.Image = Global.FAMS.My.Resources.Resources.print
        Me.ToolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonPrint.Name = "ToolStripButtonPrint"
        Me.ToolStripButtonPrint.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonPrint.Text = "Print"
        '
        'toolstripSave
        '
        Me.toolstripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolstripSave.Enabled = False
        Me.toolstripSave.Image = Global.FAMS.My.Resources.Resources.save
        Me.toolstripSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolstripSave.Name = "toolstripSave"
        Me.toolstripSave.Size = New System.Drawing.Size(23, 22)
        Me.toolstripSave.Text = "Save"
        Me.toolstripSave.ToolTipText = "Save"
        '
        'ToolStripButtonClear
        '
        Me.ToolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonClear.Image = Global.FAMS.My.Resources.Resources.clear
        Me.ToolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonClear.Name = "ToolStripButtonClear"
        Me.ToolStripButtonClear.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonClear.Text = "Clear"
        '
        'ToolStripButtonConfirm
        '
        Me.ToolStripButtonConfirm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonConfirm.Image = CType(resources.GetObject("ToolStripButtonConfirm.Image"), System.Drawing.Image)
        Me.ToolStripButtonConfirm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonConfirm.Name = "ToolStripButtonConfirm"
        Me.ToolStripButtonConfirm.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonConfirm.Text = "Confirm"
        Me.ToolStripButtonConfirm.Visible = False
        '
        'pnlDetails
        '
        Me.pnlDetails.Controls.Add(Me.lblBankBalance)
        Me.pnlDetails.Controls.Add(Me.lblCashBalance)
        Me.pnlDetails.Controls.Add(Me.lblActivity)
        Me.pnlDetails.Controls.Add(Me.lblDate)
        Me.pnlDetails.Controls.Add(Me.lblYear)
        Me.pnlDetails.Controls.Add(Me.lblUser)
        Me.pnlDetails.Controls.Add(Me.lblInstitution)
        Me.pnlDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetails.Location = New System.Drawing.Point(0, 0)
        Me.pnlDetails.Name = "pnlDetails"
        Me.pnlDetails.Size = New System.Drawing.Size(1173, 45)
        Me.pnlDetails.TabIndex = 14
        '
        'lblBankBalance
        '
        Me.lblBankBalance.AutoSize = True
        Me.lblBankBalance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankBalance.Location = New System.Drawing.Point(894, 7)
        Me.lblBankBalance.Name = "lblBankBalance"
        Me.lblBankBalance.Size = New System.Drawing.Size(80, 14)
        Me.lblBankBalance.TabIndex = 9
        Me.lblBankBalance.Text = "Bank Balance :"
        Me.lblBankBalance.Visible = False
        '
        'lblCashBalance
        '
        Me.lblCashBalance.AutoSize = True
        Me.lblCashBalance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashBalance.Location = New System.Drawing.Point(696, 7)
        Me.lblCashBalance.Name = "lblCashBalance"
        Me.lblCashBalance.Size = New System.Drawing.Size(78, 14)
        Me.lblCashBalance.TabIndex = 8
        Me.lblCashBalance.Text = "Cash Balance :"
        '
        'lblActivity
        '
        Me.lblActivity.AutoSize = True
        Me.lblActivity.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivity.Location = New System.Drawing.Point(12, 28)
        Me.lblActivity.Name = "lblActivity"
        Me.lblActivity.Size = New System.Drawing.Size(45, 14)
        Me.lblActivity.TabIndex = 7
        Me.lblActivity.Text = "Activity"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(1094, 7)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(37, 14)
        Me.lblDate.TabIndex = 6
        Me.lblDate.Text = "Date :"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.Location = New System.Drawing.Point(537, 7)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(34, 14)
        Me.lblYear.TabIndex = 5
        Me.lblYear.Text = "Year :"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Location = New System.Drawing.Point(364, 7)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(50, 14)
        Me.lblUser.TabIndex = 4
        Me.lblUser.Text = "User ID :"
        '
        'lblInstitution
        '
        Me.lblInstitution.AutoSize = True
        Me.lblInstitution.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstitution.Location = New System.Drawing.Point(12, 7)
        Me.lblInstitution.Name = "lblInstitution"
        Me.lblInstitution.Size = New System.Drawing.Size(63, 14)
        Me.lblInstitution.TabIndex = 3
        Me.lblInstitution.Text = "Institution :"
        '
        'pnlMenu
        '
        Me.pnlMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pnlMenu.Controls.Add(Me.msMainMenu)
        Me.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMenu.Location = New System.Drawing.Point(0, 45)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(1173, 29)
        Me.pnlMenu.TabIndex = 15
        '
        'msMainMenu
        '
        Me.msMainMenu.BackColor = System.Drawing.Color.Transparent
        Me.msMainMenu.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMasters, Me.mnuStep, Me.mnuDDActivities, Me.mnuRandQ, Me.mnuUtilities})
        Me.msMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMainMenu.Name = "msMainMenu"
        Me.msMainMenu.Size = New System.Drawing.Size(1173, 24)
        Me.msMainMenu.TabIndex = 10
        Me.msMainMenu.Text = "MenuStrip"
        '
        'mnuMasters
        '
        Me.mnuMasters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUserMaster, Me.mnuLedgeAccMaster, Me.mnuCashBBmaster, Me.mnuSubsidairyMaster, Me.mnuFinStatsScheduleMaster})
        Me.mnuMasters.Name = "mnuMasters"
        Me.mnuMasters.Size = New System.Drawing.Size(63, 20)
        Me.mnuMasters.Text = "Masters"
        '
        'mnuUserMaster
        '
        Me.mnuUserMaster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuUserMaster.Enabled = False
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
        Me.mnuSubsidairyMaster.Enabled = False
        Me.mnuSubsidairyMaster.Name = "mnuSubsidairyMaster"
        Me.mnuSubsidairyMaster.Size = New System.Drawing.Size(293, 22)
        Me.mnuSubsidairyMaster.Text = "Subsidairy Master"
        '
        'mnuFinStatsScheduleMaster
        '
        Me.mnuFinStatsScheduleMaster.Enabled = False
        Me.mnuFinStatsScheduleMaster.Name = "mnuFinStatsScheduleMaster"
        Me.mnuFinStatsScheduleMaster.Size = New System.Drawing.Size(293, 22)
        Me.mnuFinStatsScheduleMaster.Text = "Financial Statements  Schedules Master"
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
        Me.mnuRandQ.Name = "mnuRandQ"
        Me.mnuRandQ.Size = New System.Drawing.Size(110, 20)
        Me.mnuRandQ.Text = "Reports & Queries"
        '
        'mnuUtilities
        '
        Me.mnuUtilities.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuUtilities.Name = "mnuUtilities"
        Me.mnuUtilities.Size = New System.Drawing.Size(62, 20)
        Me.mnuUtilities.Text = "Utilities"
        '
        'pnlNavigator
        '
        Me.pnlNavigator.Controls.Add(Me.mainBindingNavigator)
        Me.pnlNavigator.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNavigator.Location = New System.Drawing.Point(0, 74)
        Me.pnlNavigator.Name = "pnlNavigator"
        Me.pnlNavigator.Size = New System.Drawing.Size(1173, 27)
        Me.pnlNavigator.TabIndex = 17
        Me.pnlNavigator.Visible = False
        '
        'frmFAMSMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 488)
        Me.Controls.Add(Me.pnlNavigator)
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.pnlDetails)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.Name = "frmFAMSMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "CASCADE – Financial Accounting Module Developed by ASTUTE Information Management " & _
    "Solutions, C.B.D.Belapur, Navi Mumbai – Contact 98193-12456"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.mainBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainBindingNavigator.ResumeLayout(False)
        Me.mainBindingNavigator.PerformLayout()
        Me.pnlDetails.ResumeLayout(False)
        Me.pnlDetails.PerformLayout()
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlMenu.PerformLayout()
        Me.msMainMenu.ResumeLayout(False)
        Me.msMainMenu.PerformLayout()
        Me.pnlNavigator.ResumeLayout(False)
        Me.pnlNavigator.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents mainBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents toolstripAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolstripDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolstripSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripedit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonView As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlDetails As System.Windows.Forms.Panel
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblInstitution As System.Windows.Forms.Label
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
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
    Friend WithEvents pnlNavigator As System.Windows.Forms.Panel
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lblActivity As System.Windows.Forms.Label
    Friend WithEvents ToolStripButtonConfirm As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblBankBalance As System.Windows.Forms.Label
    Friend WithEvents lblCashBalance As System.Windows.Forms.Label

End Class

Imports System.Windows.Forms

Public Class frmFAMSMain

    Dim objLedgerMaster As frmLedgerAccountManage
    Dim objCashBBMaster As frmCashBankAccountManage
    Dim objCashRecV As frmCashRecV
    Dim objCashPayV As frmCashPayV
    Dim objBankRecieptV As frmBankRecV
    Dim objBankPayV As frmBankPayV
    Dim objCashBankContraV As frmCashBankContraV
    Dim objJournal As frmJournalV
    Dim objVoucherAdd As frmAddVoucher
    Private _institutionDetails As InstitutionMasterData
    Dim legerAcc As LedgerAccountHelper

    Dim title As String = "CASCADE – Financial Accounting Module Developed by ASTUTE Information Management Solutions, C.B.D.Belapur, Navi Mumbai – Contact 98193-12456"

    Public Enum NavSettings
        Add
        Edit
        Clear
        Voucher
    End Enum

    Public Sub SetBalance()
        Me.lblCashBalance.Text = String.Format("Cash Balance : {0}", legerAcc.GetBalance())
    End Sub


    Property institutionDetailsGlobal() As InstitutionMasterData
        Get
            Return _institutionDetails
        End Get
        Set(ByVal Value As InstitutionMasterData)
            _institutionDetails = Value
        End Set
    End Property

    Property MenuVisibility() As Boolean
        Get
            Return msMainMenu.Visible
        End Get
        Set(ByVal Value As Boolean)
            msMainMenu.Visible = Value
        End Set
    End Property

    Property bindingNavigatorVisibility As Boolean
        Get
            Return pnlNavigator.Visible
        End Get
        Set(ByVal value As Boolean)
            pnlNavigator.Visible = value
        End Set
    End Property

    Dim validateClass As ValidateClass
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        validateClass = New ValidateClass
        ' Add any initialization after the InitializeComponent() call.
        legerAcc = New LedgerAccountHelper
    End Sub

    Sub New(institutionDetails As InstitutionMasterData)
        ' TODO: Complete member initialization 

        Try
            InitializeComponent()
            ' _institutionDetails = institutionDetails
            institutionDetailsGlobal = institutionDetails
            validateClass = New ValidateClass
            EnableDisableMenus()
            legerAcc = New LedgerAccountHelper
            ''mnuInstitutionName.Text = "Institute:" + InstitutionMasterData.XInstName.Trim()
            ''mnuFinancialYear.Text = "Year:" + InstitutionMasterData.XFinYr + "-" + (Integer.Parse(InstitutionMasterData.XFinYr) + 1).ToString()
        Catch ex As Exception
            MessageBox.Show("Exception Occured " + ex.Message, "Error", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub EnableDisableMenus()
        If validateClass.CheckFinancialYear(InstitutionMasterData.XFinYr, institutionDetailsGlobal.XInstCloseYear) Then
            Dim ddMenu As ToolStripMenuItem = DirectCast(msMainMenu.Items(mnuDDActivities.Name), ToolStripMenuItem)
            For Each item As ToolStripDropDownItem In ddMenu.DropDownItems
                Select Case item.Name
                    Case mnuEDCBank.Name
                        mnuEDCBank.Enabled = True
                    Case Else
                        item.Enabled = False
                End Select
            Next
        End If
    End Sub


    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As Form = sender
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me
        'ChildForm.Dock = DockStyle.Fill
        ChildForm.Dock = DockStyle.None
        'm_ChildFormNumber += 1
        'ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub ShowNewFormAsDialog(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As Form = sender
        ' Make it a child of this MDI form before showing it.
        'ChildForm.MdiParent = Me
        ChildForm.Dock = DockStyle.Fill
        'm_ChildFormNumber += 1
        'ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.ShowDialog()
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer


    Private Sub mnuLedgeAccMaster_Click(sender As Object, e As EventArgs) Handles mnuLedgeAccMaster.Click
        lblActivity.Text = "View"
        objLedgerMaster = New frmLedgerAccountManage
        mainBindingNavigator.BindingSource = objLedgerMaster.bindingSourceCtrl
        Me.pnlMenu.Visible = False
        Me.pnlNavigator.Visible = True
        pnlNavigator.Enabled = True
        EnableNavToolBar()
        ShowNewForm(objLedgerMaster, Nothing)
    End Sub

    Private Sub mnuCashBBmaster_Click(sender As Object, e As EventArgs) Handles mnuCashBBmaster.Click
        lblActivity.Text = "View"
        objCashBBMaster = New frmCashBankAccountManage
        mainBindingNavigator.BindingSource = objCashBBMaster.BindingSource1
        'objCashBBMaster.IsVoucherForm = False
        Me.pnlMenu.Visible = False
        Me.pnlNavigator.Visible = True
        pnlNavigator.Enabled = True
        EnableNavToolBar()

        ShowNewForm(objCashBBMaster, Nothing)
    End Sub

    Private Sub mnuCashReceiptV_Click(sender As Object, e As EventArgs) Handles mnuCashReceiptV.Click

        objVoucherAdd = New frmAddVoucher()
        objVoucherAdd.Text = "Cash Receipt voucher"
        objVoucherAdd.MDIForm = Me
        objVoucherAdd.VoucherType = "C"
        objVoucherAdd.PaymentReceipt = "R"
        objVoucherAdd.TransactionType = "CR"
        ShowNewForm(objVoucherAdd, Nothing)
        Me.lblCashBalance.Text = String.Format("Cash Balance : {0}", legerAcc.GetBalance())
        'objCashRecV = New frmCashRecV
        'objCashRecV.IsVoucherForm = False
        'ShowNewForm(objCashRecV, Nothing)

    End Sub

    Private Sub mnuCashPayV_Click(sender As Object, e As EventArgs) Handles mnuCashPayV.Click

        objVoucherAdd = New frmAddVoucher()
        objVoucherAdd.Text = "Cash Payment Voucher"
        objVoucherAdd.MDIForm = Me
        objVoucherAdd.VoucherType = "C"
        objVoucherAdd.PaymentReceipt = "P"
        objVoucherAdd.TransactionType = "CP"
        ShowNewForm(objVoucherAdd, Nothing)
        Me.lblCashBalance.Text = String.Format("Cash Balance : {0}", legerAcc.GetBalance())

        'objCashPayV = New frmCashPayV
        'objCashPayV.IsVoucherForm = False
        'ShowNewForm(objCashPayV, Nothing)


    End Sub

    Private Sub mnuBankReceiptV_Click(sender As Object, e As EventArgs) Handles mnuBankReceiptV.Click
        objVoucherAdd = New frmAddVoucher()
        objVoucherAdd.Text = "Bank Receipt Voucher"
        objVoucherAdd.MDIForm = Me
        objVoucherAdd.VoucherType = "B"
        objVoucherAdd.PaymentReceipt = "R"
        objVoucherAdd.TransactionType = "BR"
        ShowNewForm(objVoucherAdd, Nothing)
        Me.lblCashBalance.Text = String.Format("Cash Balance : {0}", legerAcc.GetBalance())

        'objBankRecieptV = New frmBankRecV
        'objBankRecieptV.IsVoucherForm = False
        'ShowNewForm(objBankRecieptV, Nothing)

    End Sub

    Private Sub mnuBankPayV_Click(sender As Object, e As EventArgs) Handles mnuBankPayV.Click

        objVoucherAdd = New frmAddVoucher()
        objVoucherAdd.Text = "Bank Payment Voucher"
        objVoucherAdd.MDIForm = Me
        objVoucherAdd.VoucherType = "B"
        objVoucherAdd.PaymentReceipt = "P"
        objVoucherAdd.TransactionType = "BP"

        ShowNewForm(objVoucherAdd, Nothing)
        Me.lblCashBalance.Text = String.Format("Cash Balance : {0}", legerAcc.GetBalance())
        'objBankPayV = New frmBankPayV
        'objBankPayV.IsVoucherForm = False
        'ShowNewForm(objBankPayV, Nothing)

    End Sub

    Private Sub mnuCashContraV_Click(sender As Object, e As EventArgs) Handles mnuCashContraV.Click
        objCashBankContraV = New frmCashBankContraV
        objCashBankContraV.MDIForm = Me
        ShowNewForm(objCashBankContraV, Nothing)
        Me.lblCashBalance.Text = String.Format("Cash Balance : {0}", legerAcc.GetBalance())
    End Sub

    Private Sub mnuJournalV_Click(sender As Object, e As EventArgs) Handles mnuJournalV.Click
        objJournal = New frmJournalV
        objJournal.IsVoucherForm = False
        ShowNewForm(objJournal, Nothing)
    End Sub

    Private Sub frmFAMSMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()

    End Sub

    Private Sub toolstripSave_Click(sender As Object, e As EventArgs) Handles toolstripSave.Click
        Dim activeForm As Form = Me.ActiveMdiChild

        If activeForm IsNot Nothing Then

            Select Case activeForm.GetType().Name
                Case "frmCashBankAccountManage"
                    DirectCast(Me.ActiveMdiChild, frmCashBankAccountManage).SaveDaybooks()
                Case "frmAddVoucher"
                    If DirectCast(Me.ActiveMdiChild, frmAddVoucher).SaveVoucher() Then
                        Call ToolStripButtonClear_Click(ToolStripButtonClear, Nothing)
                    Else
                        Return
                    End If
                Case "frmCashBankContraV"
                    Dim cashbankContra As frmCashBankContraV = DirectCast(activeForm, frmCashBankContraV)
                    If cashbankContra.SaveVoucher() Then
                        Call ToolStripButtonClear_Click(ToolStripButtonClear, Nothing)
                    End If
                Case "frmLedgerAccountManage"
                    Dim ledgerAcc As frmLedgerAccountManage = DirectCast(activeForm, frmLedgerAccountManage)
                    ledgerAcc.SaveData()

            End Select
            EnableNavToolBar()
            lblActivity.Text = "View"
        End If
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) Handles toolstripDeleteItem.Click
        Dim activeForm As Form = Me.ActiveMdiChild
        If activeForm IsNot Nothing Then
            Select Case activeForm.Name
                Case "frmCashBankAccountManage"
                    DirectCast(Me.ActiveMdiChild, frmCashBankAccountManage).DeleteDaybooks()
                    DirectCast(Me.ActiveMdiChild, frmCashBankAccountManage).FillRecords()
                    mainBindingNavigator.Refresh()

                Case "frmLedgerAccountManage"
                    Dim ledgerAcc As frmLedgerAccountManage = DirectCast(activeForm, frmLedgerAccountManage)
                    ledgerAcc.DeleteData()



                Case "frmAddVoucher"
                    Dim frmAddVoucher As frmAddVoucher = DirectCast(Me.ActiveMdiChild, frmAddVoucher)
                    frmAddVoucher.SetOperationMode("delete")
                    EnableToolStripForVouchers("delete")
                    frmAddVoucher.SetControls("delete")

                Case "frmCashBankContraV"
                    Dim cashbankContra As frmCashBankContraV = DirectCast(activeForm, frmCashBankContraV)
                    cashbankContra.SetControls("delete")
                    EnableToolStripForVouchers("delete")
            End Select

        End If
    End Sub

    Private Sub toolstripedit_Click(sender As Object, e As EventArgs) Handles toolstripedit.Click
        Dim activeForm As Form = Me.ActiveMdiChild
        If activeForm IsNot Nothing Then
            lblActivity.Text = "Edit"
            Select Case activeForm.Name
                Case "frmCashBankAccountManage"
                    Dim cashbbMaster As frmCashBankAccountManage = DirectCast(Me.ActiveMdiChild, frmCashBankAccountManage)
                    cashbbMaster.EnableDisableControls(True)
                    cashbbMaster.TextBoxDayBookCode.Enabled = False
                    toolstripSave.Enabled = True
                    cashbbMaster.EnableBankDetails()
                    DisableNavToolBar(NavSettings.Edit)
                Case "frmLedgerAccountManage"
                    Dim ledgerAcc As frmLedgerAccountManage = DirectCast(activeForm, frmLedgerAccountManage)
                    ledgerAcc.EnableDisableControls(True)
                    ledgerAcc.txtAccCode.Enabled = False
                    toolstripSave.Enabled = True
                    DisableNavToolBar(NavSettings.Edit)
                Case "frmAddVoucher"
                    ' DirectCast(Me.ActiveMdiChild, frmAddVoucher).SplitContainer1.Panel1Collapsed = True
                    'DirectCast(Me.ActiveMdiChild, frmAddVoucher).SplitContainer1.Panel2Collapsed = False
                    'DirectCast(Me.ActiveMdiChild, frmAddVoucher).panelVoucherControls.Visible = False
                    'DirectCast(Me.ActiveMdiChild, frmAddVoucher).LabelVoucherDate.Visible = False
                    'DirectCast(Me.ActiveMdiChild, frmAddVoucher).DatePickerVoucherDate.Visible = False
                    EnableToolStripForVouchers("edit")
                    DirectCast(Me.ActiveMdiChild, frmAddVoucher).SetOperationMode("edit")
                    DirectCast(Me.ActiveMdiChild, frmAddVoucher).ClearControls()
                    DirectCast(Me.ActiveMdiChild, frmAddVoucher).SetControls("edit")
                Case "frmCashBankContraV"
                    Dim cashbankContra As frmCashBankContraV = DirectCast(activeForm, frmCashBankContraV)
                    cashbankContra.SetControls("edit")
                    EnableToolStripForVouchers("edit")
            End Select

        End If
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs) Handles toolstripAdd.Click
        Dim activeForm As Form = Me.ActiveMdiChild
        If Not activeForm Is Nothing Then
            lblActivity.Text = "Add"
            Select Case activeForm.GetType().Name
                Case "frmCashBankAccountManage"
                    Dim cashbbMaster As frmCashBankAccountManage = DirectCast(Me.ActiveMdiChild, frmCashBankAccountManage)
                    cashbbMaster.SetToolStripMode("AddNew")
                    cashbbMaster.EnableDisableControls(True)
                    cashbbMaster.TextBoxDayBookCode.Enabled = True
                    toolstripSave.Enabled = True
                    DisableNavToolBar(NavSettings.Add)
                Case "frmAddVoucher"
                    'DirectCast(Me.ActiveMdiChild, frmAddVoucher).SplitContainer1.Panel1Collapsed = True
                    'DirectCast(Me.ActiveMdiChild, frmAddVoucher).SplitContainer1.Panel2Collapsed = False
                    'DirectCast(Me.ActiveMdiChild, frmAddVoucher).panelVoucherControls.Visible = True
                    'DirectCast(Me.ActiveMdiChild, frmAddVoucher).LabelVoucherDate.Visible = True
                    'DirectCast(Me.ActiveMdiChild, frmAddVoucher).DatePickerVoucherDate.Visible = True
                    EnableToolStripForVouchers("add")
                    DirectCast(Me.ActiveMdiChild, frmAddVoucher).SetOperationMode("add")
                    DirectCast(Me.ActiveMdiChild, frmAddVoucher).ClearControls()
                    DirectCast(Me.ActiveMdiChild, frmAddVoucher).SetControls("add")
                Case "frmCashBankContraV"
                    Dim cashbankContra As frmCashBankContraV = DirectCast(activeForm, frmCashBankContraV)
                    cashbankContra.SetControls("add")
                    EnableToolStripForVouchers("add")
                Case "frmLedgerAccountManage"
                    Dim ledgerAcc As frmLedgerAccountManage = DirectCast(activeForm, frmLedgerAccountManage)
                    ledgerAcc.EnableDisableControls(True)
                    ledgerAcc.LblLinkedTo.Text = "Not Linked"
                    toolstripSave.Enabled = True

                    DisableNavToolBar(NavSettings.Add)
            End Select

        End If
    End Sub

    Private Sub ToolStripButtonClear_Click(sender As Object, e As EventArgs) Handles ToolStripButtonClear.Click
        Dim activeForm As Form = Me.ActiveMdiChild
        If activeForm IsNot Nothing Then
            lblActivity.Text = "View"
            Select Case activeForm.GetType().Name
                Case "frmAddVoucher"
                    'DirectCast(Me.ActiveMdiChild, frmAddVoucher).SplitContainer1.Panel1Collapsed = False
                    'DirectCast(Me.ActiveMdiChild, frmAddVoucher).SplitContainer1.Panel2Collapsed = True

                    DirectCast(Me.ActiveMdiChild, frmAddVoucher).ClearControls()

                    EnableToolStripForVouchers("clear")
                Case "frmCashBankContraV"
                    Dim cashbankContra As frmCashBankContraV = DirectCast(activeForm, frmCashBankContraV)
                    cashbankContra.SetControls("clear")
                    EnableNavToolBar()
                    EnableToolStripForVouchers("clear")
                Case "frmCashBankAccountManage", "frmLedgerAccountManage"
                    If TypeOf (activeForm) Is frmLedgerAccountManage Then
                        DirectCast(activeForm, frmLedgerAccountManage).EnableDisableControls(False)
                    ElseIf TypeOf (activeForm) Is frmCashBankAccountManage Then
                        Dim frm As frmCashBankAccountManage = DirectCast(activeForm, frmCashBankAccountManage)
                        frm.EnableDisableControls(False)

                    End If
                    EnableNavToolBar()
                    mainBindingNavigator.BindingSource.CancelEdit()
                    mainBindingNavigator.BindingSource.MoveFirst()
                    toolstripSave.Enabled = False
            End Select
        End If
    End Sub

    Private Sub ToolStripButtonView_Click(sender As Object, e As EventArgs) Handles ToolStripButtonView.Click
        Dim activeForm As Form = Me.ActiveMdiChild
        If Not activeForm Is Nothing Then
            EnableToolStripForVouchers("view")
            If activeForm.GetType().Name = "frmAddVoucher" Then
                Dim frmAddVoucher As frmAddVoucher = DirectCast(Me.ActiveMdiChild, frmAddVoucher)
                frmAddVoucher.SetOperationMode("view")
                frmAddVoucher.ClearControls()

                frmAddVoucher.SetControls("view")
            End If

            If activeForm.GetType().Name = "frmCashBankContraV" Then
                Dim cashbankContra As frmCashBankContraV = DirectCast(activeForm, frmCashBankContraV)
                cashbankContra.SetControls("view")
            End If
        End If
    End Sub

    Private Sub EnableToolStripForVouchers(mode As String)

        Select Case mode
            Case "confirm"
                toolstripAdd.Enabled = False
                toolstripedit.Enabled = False
                toolstripDeleteItem.Enabled = False
                BindingNavigatorMoveNextItem.Enabled = False
                BindingNavigatorMoveFirstItem.Enabled = False
                BindingNavigatorMoveLastItem.Enabled = False
                BindingNavigatorMovePreviousItem.Enabled = False
                BindingNavigatorPositionItem.Enabled = False
                ToolStripButtonClear.Enabled = True
                toolstripSave.Enabled = False



            Case "view"
                toolstripAdd.Enabled = False
                toolstripedit.Enabled = False
                toolstripDeleteItem.Enabled = False
                ToolStripButtonConfirm.Enabled = False
                BindingNavigatorMoveNextItem.Enabled = False
                BindingNavigatorMoveFirstItem.Enabled = False
                BindingNavigatorMoveLastItem.Enabled = False
                BindingNavigatorMovePreviousItem.Enabled = False
                BindingNavigatorPositionItem.Enabled = False
                ToolStripButtonClear.Enabled = True
            Case "clear"
                toolstripAdd.Enabled = True
                toolstripedit.Enabled = True
                toolstripDeleteItem.Enabled = True
                BindingNavigatorMoveNextItem.Enabled = False
                BindingNavigatorMoveFirstItem.Enabled = False
                BindingNavigatorMoveLastItem.Enabled = False
                BindingNavigatorMovePreviousItem.Enabled = False
                BindingNavigatorPositionItem.Enabled = False
                ToolStripButtonClear.Enabled = True
                ToolStripButtonConfirm.Enabled = True
                ToolStripButtonView.Enabled = True
                ' pnlNavigator.Enabled = False
                If TypeOf Me.ActiveMdiChild Is frmAddVoucher Then
                    Dim frmAddVoucher As frmAddVoucher = DirectCast(Me.ActiveMdiChild, frmAddVoucher)
                    If frmAddVoucher IsNot Nothing Then
                        frmAddVoucher.ComboBoxDaybookSelect.Enabled = True
                        frmAddVoucher.ButtonNext.Enabled = True
                    End If
                End If
            Case "add"
                toolstripedit.Enabled = False
                toolstripDeleteItem.Enabled = False
                ToolStripButtonConfirm.Enabled = False
                BindingNavigatorMoveNextItem.Enabled = False
                BindingNavigatorMoveFirstItem.Enabled = False
                BindingNavigatorMoveLastItem.Enabled = False
                BindingNavigatorMovePreviousItem.Enabled = False
                BindingNavigatorPositionItem.Enabled = False
                ToolStripButtonClear.Enabled = True
                ToolStripButtonView.Enabled = False
                toolstripSave.Enabled = True
            Case "edit"
                toolstripedit.Enabled = False
                toolstripDeleteItem.Enabled = False
                toolstripAdd.Enabled = False
                ToolStripButtonConfirm.Enabled = False
                BindingNavigatorMoveNextItem.Enabled = False
                BindingNavigatorMoveFirstItem.Enabled = False
                BindingNavigatorMoveLastItem.Enabled = False
                BindingNavigatorMovePreviousItem.Enabled = False
                BindingNavigatorPositionItem.Enabled = False
                ToolStripButtonClear.Enabled = True
                ToolStripButtonView.Enabled = False
                toolstripSave.Enabled = True
            Case "delete"
                toolstripAdd.Enabled = False
                toolstripedit.Enabled = False
                ToolStripButtonConfirm.Enabled = False
                BindingNavigatorMoveNextItem.Enabled = False
                BindingNavigatorMoveFirstItem.Enabled = False
                BindingNavigatorMoveLastItem.Enabled = False
                BindingNavigatorMovePreviousItem.Enabled = False
                BindingNavigatorPositionItem.Enabled = False
                ToolStripButtonClear.Enabled = True
                toolstripSave.Enabled = True
                ToolStripButtonView.Enabled = False

        End Select

    End Sub

    Private Sub frmFAMSMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Try
            Me.Text = String.Empty
            Me.pnlMenu.Visible = False
            Me.lblActivity.Text = "Processing Date Acceptance"
            SelectProcessingDate()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SelectProcessingDate()
        Dim frmProcessingDate As New frmProcessingDateAcceptance
        Dim frmInstituteSelection As frmInstitutionSelection

        If frmProcessingDate.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.lblActivity.Text = "Institution Selection"
            frmInstituteSelection = New frmInstitutionSelection(frmProcessingDate.InstituInformation)
            _institutionDetails = frmInstituteSelection.InstituInformation
            If frmInstituteSelection.ShowDialog = Windows.Forms.DialogResult.OK Then

                Me.Text = title
                Me.pnlMenu.Visible = True
                Me.pnlDetails.Visible = True
                pnlNavigator.Visible = False
                Me.lblInstitution.Text = InstitutionMasterData.XInstName
                Me.lblUser.Text = String.Format("User ID : {0}", "Saurabh") ''TODO use user data when user master is avaiable.
                Me.lblYear.Text = String.Format("Year : {0}-{1}", InstitutionMasterData.XFinYr, (Convert.ToInt32(InstitutionMasterData.XFinYr) + 1))
                Me.lblDate.Text = String.Format("Date : {0}", InstitutionMasterData.XDate.ToString("dd-MM-yyyy"))
                Me.lblActivity.Text = String.Empty
                Me.lblCashBalance.Text = String.Format("Cash Balance : {0}", legerAcc.GetBalance())
                EnableDisableMenus()
            Else
                SelectProcessingDate()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Public Sub DisableNavToolBar(navOptions As NavSettings)
        mainBindingNavigator.MoveFirstItem = Nothing
        BindingNavigatorMoveFirstItem.Enabled = False
        mainBindingNavigator.MoveLastItem = Nothing
        BindingNavigatorMoveLastItem.Enabled = False
        mainBindingNavigator.MoveNextItem = Nothing
        BindingNavigatorMoveNextItem.Enabled = False
        mainBindingNavigator.MovePreviousItem = Nothing
        BindingNavigatorMovePreviousItem.Enabled = False
        mainBindingNavigator.DeleteItem = Nothing
        mainBindingNavigator.AddNewItem = Nothing

        Select Case navOptions
            Case NavSettings.Add
                toolstripedit.Enabled = False
                ToolStripButtonPrint.Enabled = False
                toolstripDeleteItem.Enabled = False
            Case NavSettings.Edit
                toolstripAdd.Enabled = False
                ToolStripButtonPrint.Enabled = False
                toolstripDeleteItem.Enabled = False
            Case NavSettings.Voucher
                toolstripAdd.Enabled = True
                toolstripedit.Enabled = True
                ToolStripButtonView.Visible = True
                ToolStripButtonView.Enabled = True
                ToolStripButtonConfirm.Visible = True
                ToolStripButtonConfirm.Enabled = True
                toolstripDeleteItem.Enabled = True
                ToolStripButtonClear.Enabled = True
        End Select
    End Sub

    Public Sub EnableNavToolBar()
        mainBindingNavigator.MoveFirstItem = BindingNavigatorMoveFirstItem
        BindingNavigatorMoveFirstItem.Enabled = True
        mainBindingNavigator.MoveLastItem = BindingNavigatorMoveLastItem
        BindingNavigatorMoveLastItem.Enabled = True
        mainBindingNavigator.MoveNextItem = BindingNavigatorMoveNextItem
        BindingNavigatorMoveNextItem.Enabled = True
        mainBindingNavigator.MovePreviousItem = BindingNavigatorMovePreviousItem
        BindingNavigatorMovePreviousItem.Enabled = True
        mainBindingNavigator.DeleteItem = toolstripDeleteItem
        mainBindingNavigator.AddNewItem = toolstripAdd
        toolstripedit.Enabled = True
        ToolStripButtonPrint.Enabled = True
        toolstripAdd.Enabled = True
    End Sub

    Private Sub ToolStripButtonConfirm_Click(sender As Object, e As EventArgs) Handles ToolStripButtonConfirm.Click
        Dim activeForm As Form = Me.ActiveMdiChild
        If Not activeForm Is Nothing Then
            If activeForm.GetType().Name = "frmAddVoucher" Then
                Dim frmAddVoucher As frmAddVoucher = DirectCast(Me.ActiveMdiChild, frmAddVoucher)
                frmAddVoucher.SetOperationMode("confirm")
                EnableToolStripForVouchers("confirm")
                frmAddVoucher.SetControls("confirm")
            End If
            If activeForm.GetType().Name = "frmCashBankContraV" Then
                Dim cashbankContra As frmCashBankContraV = DirectCast(activeForm, frmCashBankContraV)
                cashbankContra.SetControls("confirm")
                EnableToolStripForVouchers("confirm")
            End If
        End If



    End Sub


    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        '   mainBindingNavigator.BindingSource.MoveNext()
    End Sub
End Class

Imports System.Windows.Forms

Public Class frmFAMSMain

    Dim objLedgerMaster As frmLedgerAccMaster
    Dim objCashBBMaster As frmCashBBMaster
    Dim objCashRecV As frmCashRecV
    Dim objCashPayV As frmCashPayV
    Dim objBankRecieptV As frmBankRecV
    Dim objBankPayV As frmBankPayV
    Dim objCashBankContraV As frmCashBankContraV
    Dim objJournal As frmJournalV
    Private _institutionDetails As InstitutionMasterData
    Dim validateClass As ValidateUserClass
    Public chkvalue As Integer = 0
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        validateClass = New ValidateUserClass
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Sub New(institutionDetails As InstitutionMasterData)
        ' TODO: Complete member initialization 
        InitializeComponent()
        _institutionDetails = institutionDetails
        validateClass = New ValidateUserClass
        EnableDisableMenus()
    End Sub

    Private Sub EnableDisableMenus()
        If validateClass.CheckFinancialYear(_institutionDetails.XFinYr, _institutionDetails.XInstCloseYear) Then
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
        ChildForm.Dock = DockStyle.Fill
        'm_ChildFormNumber += 1
        'ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
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
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        'For Each f As Form In Application.OpenForms
        '    If TypeOf f Is frmLedgerAccMaster Then
        '        f.Activate()
        '        Return
        '    End If
        'Next
        Dim objLedgerAccountManage As New frmLedgerAccountManage
        With objLedgerAccountManage
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(200, 40)
            .Show()
        End With
    End Sub

    Private Sub mnuCashBBmaster_Click(sender As Object, e As EventArgs) Handles mnuCashBBmaster.Click
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
       
        Dim objCashBankAccountManage As New frmCashBankAccountManage
        With objCashBankAccountManage
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(250, 40)
            .Show()
        End With
    End Sub

    Private Sub mnuCashReceiptV_Click(sender As Object, e As EventArgs) Handles mnuCashReceiptV.Click
        chkvalue = 10
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        Dim objAddVoucher As New frmAddVoucher
        With objAddVoucher
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(250, 40)
            .Show()
        End With
        
    End Sub
  
    Private Sub mnuCashPayV_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuCashPayV.Click
        chkvalue = 20
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        Dim objAddVoucher As New frmAddVoucher
        With objAddVoucher
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(250, 40)
            .Show()
        End With
    End Sub

    Private Sub mnuBankReceiptV_Click(sender As Object, e As EventArgs) Handles mnuBankReceiptV.Click
        chkvalue = 30
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        Dim objAddVoucher As New frmAddVoucher
        With objAddVoucher
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(250, 40)
            .Show()
        End With
    End Sub

    Private Sub mnuBankPayV_Click(sender As Object, e As EventArgs) Handles mnuBankPayV.Click
        chkvalue = 40        
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        Dim objAddVoucher As New frmAddVoucher
        With objAddVoucher
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(250, 40)
            .Show()
        End With
    End Sub

    Private Sub mnuCashContraV_Click(sender As Object, e As EventArgs) Handles mnuCashContraV.Click
        chkvalue = 50
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
       
        Dim objAddVoucher As New frmAddVoucher
        With objAddVoucher
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(250, 40)
            .Show()
        End With
        'objcashbcv.MdiParent = Me
        'objcashbcv.Show()
    End Sub

    Private Sub mnuJournalV_Click(sender As Object, e As EventArgs) Handles mnuJournalV.Click
        chkvalue = 60
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        Dim objAddVoucher As New frmAddVoucher
        With objAddVoucher
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(250, 40)
            .Show()
        End With
       
    End Sub

    Private Sub frmFAMSMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub mnuCashBankContra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCashBankContra.Click

    End Sub

    Private Sub mnuUserMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUserMaster.Click
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        Dim objUserMaster As New frmUserMaster
        With objUserMaster
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(200, 40)
            .Show()
        End With
    End Sub

    Private Sub InstitutionalMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstitutionalMasterToolStripMenuItem.Click
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        Dim objInstituteDetails As New frmInstituteDetails
        With objInstituteDetails
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(200, 40)
            .Show()
        End With
    End Sub

    Private Sub mnuDDActivities_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDDActivities.Click

    End Sub

    Private Sub mnuEDCBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEDCBank.Click
        For Each f As Form In Me.MdiChildren
            f.Close()
        Next
        Dim objVoucherDetails As New frmVoucherDetails
        With objVoucherDetails
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(200, 40)
            .Show()
        End With
    End Sub
End Class

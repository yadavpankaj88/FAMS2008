Public Class frmUserMaster
    Dim user As New User
    Dim userhelper As UserHelper
    Dim Userstatus As String
    Private _mode As String
    Public UserID As String
    Public WithEvents bindingSourceCtrl As BindingSource

    Private Sub frmUserMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCombobox()
        BindData()
       
        Me.KeyPreview = True
    End Sub

    Public Sub SaveUserDetails()
        Dim userhelper As New UserHelper
        Dim dt As New DataTable
        Dim mandatoryFields As String = String.Empty
        Try
            dt = userhelper.GetUserDetails(txtUserID.Text)
            If (txtUserID.Text = "") Then
                mandatoryFields = "User ID" + " , "
            End If

            If (txtpassword.Text = "") Then
                mandatoryFields += "Password " + " , "
            End If

            If (txtusername.Text = "") Then
                mandatoryFields += "Username " + " ,  "
            End If

            If (ddlInstitutionType.Text = "") Then
                mandatoryFields += "Institution Type" + ",  "
            End If

            If (ddlmodulecode.Text = "") Then
                mandatoryFields += "Module Code" + " ,"
            End If

            If (ddlrole.Text = "") Then
                mandatoryFields += "Role"
            End If

            If (lblUserStatus.Text = "") Then
                lblUserStatus.Text = "N"
            End If

            If Not mandatoryFields = String.Empty Then
                MessageBox.Show(mandatoryFields + " are compulsory for saving User")
            Else
                user.UserId = txtUserID.Text
                user.UserName = txtusername.Text.ToString()
                user.password = txtpassword.Text.ToString()
                'user.Role = ddlrole.SelectedItem
                user.Role = ddlrole.Text
                user.ModuleCode = ddlmodulecode.Text
                user.InstitutionType = ddlInstitutionType.Text
                user.UserLocked = lblUserStatus.Text
                ' user.UserId = txtUserID.Text
                userhelper.SaveUser(user)
                MessageBox.Show("Data saved successfully")
                Me.Close()
                ' EnableDisableControls(False)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub bindingSourceCtrl_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles bindingSourceCtrl.PositionChanged
        If Not bindingSourceCtrl.Position >= DirectCast(bindingSourceCtrl.DataSource, DataTable).Rows.Count Then
            EnableDisableControls(False)
        Else
            EnableDisableControls(True)
        End If
    End Sub

    Public Function DeleteData() As Boolean
        Dim currentRec As DataRowView = DirectCast(bindingSourceCtrl.Current, DataRowView)
        Dim helper As UserHelper = New UserHelper()

        If currentRec("Usr_Id") IsNot DBNull.Value Then

            Dim transCount As Integer = helper.GetTransactionCount(currentRec("Usr_Id"))

            If transCount = 1 Then

                If MessageBox.Show("You are about to delete an Account , are you sure you want to delete?", "Deleting Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                    DialogResult.Yes Then
                    helper.DeleteAccount(currentRec.Row("Usr_Id").ToString)
                    txtUserID.Text = ""
                    txtusername.Text = ""
                    txtpassword.Text = ""
                    ddlInstitutionType.Text = ""
                    ddlmodulecode.Text = ""
                    ddlrole.Text = ""
                    Me.Close()
                    Return True
                Else

                    Return False
                End If
                'Else
                '    MessageBox.Show("This account is currently used in transactions, and cannot be deleted")
                '    Return False
            End If
        ElseIf currentRec("Usr_Id") Is DBNull.Value Then

            MessageBox.Show("It's empty record")
        Else
            If MessageBox.Show("You are about to delete an Account , are you sure you want to delete?", "Deleting Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                   DialogResult.Yes Then
                helper.DeleteAccount(currentRec.Row("Usr_Id").ToString)
                Return True
            Else
                Return False
            End If
        End If

    End Function

    Sub New()
        InitializeComponent()
        userhelper = New UserHelper
        bindingSourceCtrl = New BindingSource
    End Sub

    Private Sub BindData()
        Try
            ' Label8.Visible = False
            txtUserID.Visible = True
            btnsearch.Visible = True
            Dim usermaster As New UserHelper
            Dim dt As New DataTable
            dt = usermaster.GetUserDetails(String.Empty)

            dt.AcceptChanges()
            bindingSourceCtrl.DataSource = dt
            bindingSourceCtrl.Sort = "Usr_Id"

            txtUserID.DataBindings.Add("Text", bindingSourceCtrl, "Usr_Id", True)
            txtusername.DataBindings.Add("Text", bindingSourceCtrl, "Usr_Nm", True)
            txtpassword.DataBindings.Clear()
            txtpassword.DataBindings.Add("Text", bindingSourceCtrl, "Usr_Pwd", True)

            ddlInstitutionType.DataBindings.Clear()
            ddlInstitutionType.DataBindings.Add("Text", bindingSourceCtrl, "Usr_Inst_Typ", True)

            ddlmodulecode.DataBindings.Clear()
            ddlmodulecode.DataBindings.Add("Text", bindingSourceCtrl, "Usr_Mdl_Cd", True)

            ddlrole.DataBindings.Clear()
            ddlrole.DataBindings.Add("Text", bindingSourceCtrl, "Usr_Role", True)

            lblUserStatus.DataBindings.Add("Text", bindingSourceCtrl, "Usr_Lckd", True)

            chkUserLocked.Visible = False
            EnableDisableControls(False)

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Sub FillCombobox()
        'ddlmodulecode.Text = "Select"
        ddlmodulecode.Items.Add("SAM")
        ddlmodulecode.Items.Add("SAT")
        ddlmodulecode.Items.Add("EXAM")
        ddlmodulecode.Items.Add("FAM")
        ddlmodulecode.Items.Add("PAM")
        ddlmodulecode.Items.Add("LiM")
        ddlmodulecode.Items.Add("FAD")


        'ddlrole.DataSource = BindRole()
        'ddlrole.DisplayMember = "Text"
        'ddlrole.ValueMember = "Value"

        ddlrole.Text = "Select"
        ddlrole.Items.Add("JUNIOR CLERK")
        ddlrole.Items.Add("SENIOR CLERK")
        ddlrole.Items.Add("HEAD CLERK")
        ddlrole.Items.Add("EXAMINATION CLERK")
        ddlrole.Items.Add("OFF. SUPERINTENDENT")
        ddlrole.Items.Add("REGISTRAR")
        ddlrole.Items.Add("ACCOUNTANT")
        ddlrole.Items.Add("ADMIN OFFICER")
        ddlrole.Items.Add("VICE PRINCIPAL")
        ddlrole.Items.Add("PRINCIPAL")
        ddlrole.Items.Add("TREASURER")
        ddlrole.Items.Add("GENERAL SECRETARY")
        ddlrole.Items.Add("CHAIRMAN")
        ddlrole.Items.Add("System")

        'ddlInstitutionType.Text = "Select"
        ddlInstitutionType.Items.Add("UR")
        ddlInstitutionType.Items.Add("UP")
        ddlInstitutionType.Items.Add("JR")
        ddlInstitutionType.Items.Add("PG")
        ddlInstitutionType.Items.Add("VO")
        ddlInstitutionType.Items.Add("PO")
        ddlInstitutionType.Items.Add("EN")
        ddlInstitutionType.Items.Add("PP")
        ddlInstitutionType.Items.Add("PR")
        ddlInstitutionType.Items.Add("SE")
        ddlInstitutionType.Items.Add("SO")
        ddlInstitutionType.Items.Add("CG")

        'UR – Undergraduate Regular Section
        'UP – Undergraduate Professional Section
        'JR – Junior College Section
        'PG – Post Graduate Section
        'VO – Vocational (MCVC) Section
        'PO – Polytechnic
        'EN – Engineering College Section
        'PP – Pre-Primary Section
        'PR – Primary Section
        'SE – Secondary Section
        'SO – Society Section
        'AB – Apex Body (Education Trust)

    End Sub

    Public Sub SetControls(ByVal pMode As String)
        _mode = pMode
        Dim userhelper As New UserHelper
        Dim dt As New DataTable
        Try
            'ClearControls()
            Select Case _mode
                Case "add"
                    chkUserLocked.Visible = False
                    Label8.Visible = False
            End Select
        Catch ex As Exception
            MessageBox.Show("Error Occurred !!!")
        End Try
    End Sub

    Private Sub frmUserMaster_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
        If frmMain IsNot Nothing Then
            frmMain.mainBindingNavigator.BindingSource = Nothing
            frmMain.pnlNavigator.Visible = False
            frmMain.pnlMenu.Visible = True
            frmMain.EnableNavToolBar()
            CheckChanges()
        End If
    End Sub

    Function CheckChanges() As Boolean
        Dim dt As New DataTable
        Dim userhelper As New UserHelper
        dt = userhelper.GetUserDetailsByID(txtUserID.Text)
       
            If dt.Rows.Count() > 0 Then
            If ((dt.Rows(0)("Usr_Nm").ToString()).Trim() <> txtusername.Text.Trim() Or (dt.Rows(0)("Usr_Pwd").ToString()).Trim() <> txtpassword.Text.Trim() Or ((dt.Rows(0)("Usr_Inst_Typ").ToString()).Trim() <> ddlInstitutionType.Text) Or ((dt.Rows(0)("Usr_Role").ToString()).Trim() <> ddlrole.Text.Trim()) Or ((dt.Rows(0)("Usr_Mdl_Cd").ToString()).Trim() <> ddlmodulecode.Text.Trim()) Or ((dt.Rows(0)("Usr_Lckd").ToString()).Trim() <> lblUserStatus.Text.Trim())) Then
                If MessageBox.Show("do you want to save changes?", " User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    SaveUserDetails()
                    Return True
                Else
                    Return False
                    Me.Close()
                End If
            Else
                Return False
                Me.Close()
            End If
            End If

        'If (txtUserID.Text = "") Then
        'Else
        '    If MessageBox.Show("do you want to save changes?", " User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '        SaveUserDetails()
        '        Return True
        '    Else
        '        Return False
        '        Me.Close()
        '    End If
        'End If
    End Function

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        ' Label8.Visible = False
        txtUserID.Visible = True
        Dim userhelper As New UserHelper
        Dim username As New frmFillUserName
        Dim dt As New DataTable
        username.ShowDialog()
        txtUserID.Text = username.Val
        If (username.Val = Nothing) Then
            MessageBox.Show("Please select user")
            username.ShowDialog()
            txtUserID.Text = username.Val
        End If
        dt = userhelper.GetUserDetails(username.Val)
        txtusername.Text = dt.Rows(0)("Usr_Nm")
        txtpassword.Text = dt.Rows(0)("Usr_Pwd")
        ddlrole.Text = dt.Rows(0)("Usr_Role")
        ddlInstitutionType.Text = dt.Rows(0)("Usr_Inst_Typ")
        ddlmodulecode.Text = dt.Rows(0)("Usr_Mdl_Cd")
        lblUserStatus.Text = dt.Rows(0)("Usr_Lckd")
        If (lblUserStatus.Text = "N") Then
            lblUserStatus.Text = "No"
        Else
            lblUserStatus.Text = "Yes"
        End If
    End Sub

    Public Sub EnableDisableControls(ByVal pFlg As Boolean)

        txtUserID.Enabled = True
        btnSearch.Enabled = True
        txtusername.Enabled = pFlg
        txtpassword.Enabled = pFlg
        ddlInstitutionType.Enabled = pFlg
        ddlmodulecode.Enabled = pFlg
        ddlrole.Enabled = pFlg
        chkUserLocked.Enabled = pFlg
    End Sub

    Private Sub frmUserMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.KeyCode.ToString = "S" Then
            SaveUserDetails()
        End If
        If e.Control And e.KeyCode.ToString = "N" Then
            EnableDisableControls(True)
            ClearData()
            SetControls("add")
            frmFAMSMain.toolstripSave.Enabled = True
            frmFAMSMain.DisableNavToolBar(frmFAMSMain.NavSettings.Add)
        End If
    End Sub

    Sub ClearData()
        txtUserID.Text = ""
        btnsearch.Text = ""
        txtusername.Text = ""
        txtpassword.Text = ""
        ddlInstitutionType.Text = ""
        ddlmodulecode.Text = ""
        ddlrole.Text = ""
    End Sub

    Private Sub chkUserLocked_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUserLocked.CheckedChanged

        If (chkUserLocked.Checked = True) Then
            lblUserStatus.Text = "Y"
       
        End If
    End Sub
End Class
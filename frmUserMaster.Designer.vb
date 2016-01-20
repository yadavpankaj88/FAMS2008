<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserMaster
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtusername = New System.Windows.Forms.TextBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ddlInstitutionType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ddlmodulecode = New System.Windows.Forms.ComboBox()
        Me.ddlrole = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.btnsearch = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkUserLocked = New System.Windows.Forms.CheckBox()
        Me.lblUserStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password"
        '
        'txtusername
        '
        Me.txtusername.Location = New System.Drawing.Point(133, 60)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(164, 20)
        Me.txtusername.TabIndex = 2
        '
        'txtpassword
        '
        Me.txtpassword.Location = New System.Drawing.Point(133, 107)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(164, 20)
        Me.txtpassword.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "User Role"
        '
        'ddlInstitutionType
        '
        Me.ddlInstitutionType.FormattingEnabled = True
        Me.ddlInstitutionType.Location = New System.Drawing.Point(133, 197)
        Me.ddlInstitutionType.Name = "ddlInstitutionType"
        Me.ddlInstitutionType.Size = New System.Drawing.Size(121, 21)
        Me.ddlInstitutionType.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Institition Type"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 239)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Module Code"
        '
        'ddlmodulecode
        '
        Me.ddlmodulecode.FormattingEnabled = True
        Me.ddlmodulecode.Location = New System.Drawing.Point(133, 236)
        Me.ddlmodulecode.Name = "ddlmodulecode"
        Me.ddlmodulecode.Size = New System.Drawing.Size(121, 21)
        Me.ddlmodulecode.TabIndex = 20
        '
        'ddlrole
        '
        Me.ddlrole.FormattingEnabled = True
        Me.ddlrole.Location = New System.Drawing.Point(133, 154)
        Me.ddlrole.Name = "ddlrole"
        Me.ddlrole.Size = New System.Drawing.Size(106, 21)
        Me.ddlrole.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "User ID"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(130, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 22
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(133, 16)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(121, 20)
        Me.txtUserID.TabIndex = 0
        '
        'btnsearch
        '
        Me.btnsearch.Image = Global.FAMS.My.Resources.Resources.searchIcon
        Me.btnsearch.Location = New System.Drawing.Point(289, 16)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(26, 23)
        Me.btnsearch.TabIndex = 1
        Me.btnsearch.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 283)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "User Locked"
        '
        'chkUserLocked
        '
        Me.chkUserLocked.AutoSize = True
        Me.chkUserLocked.Location = New System.Drawing.Point(135, 284)
        Me.chkUserLocked.Name = "chkUserLocked"
        Me.chkUserLocked.Size = New System.Drawing.Size(44, 17)
        Me.chkUserLocked.TabIndex = 24
        Me.chkUserLocked.Text = "Yes"
        Me.chkUserLocked.UseVisualStyleBackColor = True
        '
        'lblUserStatus
        '
        Me.lblUserStatus.AutoSize = True
        Me.lblUserStatus.Location = New System.Drawing.Point(130, 277)
        Me.lblUserStatus.Name = "lblUserStatus"
        Me.lblUserStatus.Size = New System.Drawing.Size(68, 13)
        Me.lblUserStatus.TabIndex = 25
        Me.lblUserStatus.Text = "User Locked"
        '
        'frmUserMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 320)
        Me.Controls.Add(Me.lblUserStatus)
        Me.Controls.Add(Me.chkUserLocked)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnsearch)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ddlrole)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ddlmodulecode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ddlInstitutionType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.txtusername)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Master"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtusername As System.Windows.Forms.TextBox
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ddlInstitutionType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ddlmodulecode As System.Windows.Forms.ComboBox
    Friend WithEvents ddlrole As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnsearch As System.Windows.Forms.Button
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents chkUserLocked As System.Windows.Forms.CheckBox
    Friend WithEvents lblUserStatus As System.Windows.Forms.Label
End Class

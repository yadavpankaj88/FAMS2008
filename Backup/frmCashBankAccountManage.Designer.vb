<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashBankAccountManage
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblAcccodeErr = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBoxBankOD = New System.Windows.Forms.TextBox()
        Me.LabelBankOD = New System.Windows.Forms.Label()
        Me.TextBoxAccountNumber = New System.Windows.Forms.TextBox()
        Me.LabelAccountNumber = New System.Windows.Forms.Label()
        Me.TextBoxBranchName = New System.Windows.Forms.TextBox()
        Me.LabelBranchName = New System.Windows.Forms.Label()
        Me.TextBoxBankName = New System.Windows.Forms.TextBox()
        Me.LabelBankName = New System.Windows.Forms.Label()
        Me.ComboBoxLedgerAccountCode = New System.Windows.Forms.ComboBox()
        Me.LabelLedgerAccountCode = New System.Windows.Forms.Label()
        Me.ComboBoxDaybookType = New System.Windows.Forms.ComboBox()
        Me.LabelDaybookType = New System.Windows.Forms.Label()
        Me.TextBoxDaybookName = New System.Windows.Forms.TextBox()
        Me.LabelDaybookName = New System.Windows.Forms.Label()
        Me.TextBoxDayBookCode = New System.Windows.Forms.TextBox()
        Me.labelDaybookCode = New System.Windows.Forms.Label()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblAcccodeErr)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.TextBoxBankOD)
        Me.GroupBox1.Controls.Add(Me.LabelBankOD)
        Me.GroupBox1.Controls.Add(Me.TextBoxAccountNumber)
        Me.GroupBox1.Controls.Add(Me.LabelAccountNumber)
        Me.GroupBox1.Controls.Add(Me.TextBoxBranchName)
        Me.GroupBox1.Controls.Add(Me.LabelBranchName)
        Me.GroupBox1.Controls.Add(Me.TextBoxBankName)
        Me.GroupBox1.Controls.Add(Me.LabelBankName)
        Me.GroupBox1.Controls.Add(Me.ComboBoxLedgerAccountCode)
        Me.GroupBox1.Controls.Add(Me.LabelLedgerAccountCode)
        Me.GroupBox1.Controls.Add(Me.ComboBoxDaybookType)
        Me.GroupBox1.Controls.Add(Me.LabelDaybookType)
        Me.GroupBox1.Controls.Add(Me.TextBoxDaybookName)
        Me.GroupBox1.Controls.Add(Me.LabelDaybookName)
        Me.GroupBox1.Controls.Add(Me.TextBoxDayBookCode)
        Me.GroupBox1.Controls.Add(Me.labelDaybookCode)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 318)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblAcccodeErr
        '
        Me.lblAcccodeErr.AutoSize = True
        Me.lblAcccodeErr.ForeColor = System.Drawing.Color.Red
        Me.lblAcccodeErr.Location = New System.Drawing.Point(135, 163)
        Me.lblAcccodeErr.Name = "lblAcccodeErr"
        Me.lblAcccodeErr.Size = New System.Drawing.Size(167, 14)
        Me.lblAcccodeErr.TabIndex = 15
        Me.lblAcccodeErr.Text = "The account is already linked"
        Me.lblAcccodeErr.Visible = False
        '
        'Button2
        '
        Me.Button2.Image = Global.FAMS.My.Resources.Resources.searchIcon
        Me.Button2.Location = New System.Drawing.Point(213, 26)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(26, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBoxBankOD
        '
        Me.TextBoxBankOD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxBankOD.Location = New System.Drawing.Point(132, 289)
        Me.TextBoxBankOD.MaxLength = 16
        Me.TextBoxBankOD.Name = "TextBoxBankOD"
        Me.TextBoxBankOD.Size = New System.Drawing.Size(101, 22)
        Me.TextBoxBankOD.TabIndex = 8
        '
        'LabelBankOD
        '
        Me.LabelBankOD.AutoSize = True
        Me.LabelBankOD.Location = New System.Drawing.Point(12, 289)
        Me.LabelBankOD.Name = "LabelBankOD"
        Me.LabelBankOD.Size = New System.Drawing.Size(53, 14)
        Me.LabelBankOD.TabIndex = 14
        Me.LabelBankOD.Text = "Bank OD"
        '
        'TextBoxAccountNumber
        '
        Me.TextBoxAccountNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxAccountNumber.Location = New System.Drawing.Point(132, 254)
        Me.TextBoxAccountNumber.MaxLength = 16
        Me.TextBoxAccountNumber.Name = "TextBoxAccountNumber"
        Me.TextBoxAccountNumber.Size = New System.Drawing.Size(212, 22)
        Me.TextBoxAccountNumber.TabIndex = 7
        '
        'LabelAccountNumber
        '
        Me.LabelAccountNumber.AutoSize = True
        Me.LabelAccountNumber.Location = New System.Drawing.Point(12, 254)
        Me.LabelAccountNumber.Name = "LabelAccountNumber"
        Me.LabelAccountNumber.Size = New System.Drawing.Size(95, 14)
        Me.LabelAccountNumber.TabIndex = 12
        Me.LabelAccountNumber.Text = "Account Number"
        '
        'TextBoxBranchName
        '
        Me.TextBoxBranchName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxBranchName.Location = New System.Drawing.Point(132, 218)
        Me.TextBoxBranchName.MaxLength = 30
        Me.TextBoxBranchName.Name = "TextBoxBranchName"
        Me.TextBoxBranchName.Size = New System.Drawing.Size(212, 22)
        Me.TextBoxBranchName.TabIndex = 6
        '
        'LabelBranchName
        '
        Me.LabelBranchName.AutoSize = True
        Me.LabelBranchName.Location = New System.Drawing.Point(12, 218)
        Me.LabelBranchName.Name = "LabelBranchName"
        Me.LabelBranchName.Size = New System.Drawing.Size(79, 14)
        Me.LabelBranchName.TabIndex = 10
        Me.LabelBranchName.Text = "Branch Name"
        '
        'TextBoxBankName
        '
        Me.TextBoxBankName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxBankName.Location = New System.Drawing.Point(132, 186)
        Me.TextBoxBankName.MaxLength = 50
        Me.TextBoxBankName.Name = "TextBoxBankName"
        Me.TextBoxBankName.Size = New System.Drawing.Size(296, 22)
        Me.TextBoxBankName.TabIndex = 5
        '
        'LabelBankName
        '
        Me.LabelBankName.AutoSize = True
        Me.LabelBankName.Location = New System.Drawing.Point(11, 186)
        Me.LabelBankName.Name = "LabelBankName"
        Me.LabelBankName.Size = New System.Drawing.Size(69, 14)
        Me.LabelBankName.TabIndex = 8
        Me.LabelBankName.Text = "Bank Name"
        '
        'ComboBoxLedgerAccountCode
        '
        Me.ComboBoxLedgerAccountCode.FormattingEnabled = True
        Me.ComboBoxLedgerAccountCode.Location = New System.Drawing.Point(132, 138)
        Me.ComboBoxLedgerAccountCode.Name = "ComboBoxLedgerAccountCode"
        Me.ComboBoxLedgerAccountCode.Size = New System.Drawing.Size(192, 22)
        Me.ComboBoxLedgerAccountCode.TabIndex = 4
        '
        'LabelLedgerAccountCode
        '
        Me.LabelLedgerAccountCode.AutoSize = True
        Me.LabelLedgerAccountCode.Location = New System.Drawing.Point(11, 141)
        Me.LabelLedgerAccountCode.Name = "LabelLedgerAccountCode"
        Me.LabelLedgerAccountCode.Size = New System.Drawing.Size(118, 14)
        Me.LabelLedgerAccountCode.TabIndex = 6
        Me.LabelLedgerAccountCode.Text = "Ledger Account Code"
        '
        'ComboBoxDaybookType
        '
        Me.ComboBoxDaybookType.FormattingEnabled = True
        Me.ComboBoxDaybookType.Location = New System.Drawing.Point(132, 103)
        Me.ComboBoxDaybookType.Name = "ComboBoxDaybookType"
        Me.ComboBoxDaybookType.Size = New System.Drawing.Size(101, 22)
        Me.ComboBoxDaybookType.TabIndex = 3
        '
        'LabelDaybookType
        '
        Me.LabelDaybookType.AutoSize = True
        Me.LabelDaybookType.Location = New System.Drawing.Point(7, 106)
        Me.LabelDaybookType.Name = "LabelDaybookType"
        Me.LabelDaybookType.Size = New System.Drawing.Size(81, 14)
        Me.LabelDaybookType.TabIndex = 4
        Me.LabelDaybookType.Text = "Daybook Type"
        '
        'TextBoxDaybookName
        '
        Me.TextBoxDaybookName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxDaybookName.Location = New System.Drawing.Point(132, 65)
        Me.TextBoxDaybookName.MaxLength = 50
        Me.TextBoxDaybookName.Name = "TextBoxDaybookName"
        Me.TextBoxDaybookName.Size = New System.Drawing.Size(293, 22)
        Me.TextBoxDaybookName.TabIndex = 2
        '
        'LabelDaybookName
        '
        Me.LabelDaybookName.AutoSize = True
        Me.LabelDaybookName.Location = New System.Drawing.Point(7, 68)
        Me.LabelDaybookName.Name = "LabelDaybookName"
        Me.LabelDaybookName.Size = New System.Drawing.Size(89, 14)
        Me.LabelDaybookName.TabIndex = 2
        Me.LabelDaybookName.Text = "Daybook Name"
        '
        'TextBoxDayBookCode
        '
        Me.TextBoxDayBookCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxDayBookCode.Location = New System.Drawing.Point(132, 26)
        Me.TextBoxDayBookCode.MaxLength = 4
        Me.TextBoxDayBookCode.Name = "TextBoxDayBookCode"
        Me.TextBoxDayBookCode.Size = New System.Drawing.Size(75, 22)
        Me.TextBoxDayBookCode.TabIndex = 0
        '
        'labelDaybookCode
        '
        Me.labelDaybookCode.AutoSize = True
        Me.labelDaybookCode.Location = New System.Drawing.Point(7, 29)
        Me.labelDaybookCode.Name = "labelDaybookCode"
        Me.labelDaybookCode.Size = New System.Drawing.Size(84, 14)
        Me.labelDaybookCode.TabIndex = 0
        Me.labelDaybookCode.Text = "Daybook Code"
        '
        'BindingSource1
        '
        '
        'frmCashBankAccountManage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 318)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCashBankAccountManage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cash Bank Book Master"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents labelDaybookCode As System.Windows.Forms.Label
    Friend WithEvents TextBoxDayBookCode As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxDaybookType As System.Windows.Forms.ComboBox
    Friend WithEvents LabelDaybookType As System.Windows.Forms.Label
    Friend WithEvents TextBoxDaybookName As System.Windows.Forms.TextBox
    Friend WithEvents LabelDaybookName As System.Windows.Forms.Label
    Friend WithEvents ComboBoxLedgerAccountCode As System.Windows.Forms.ComboBox
    Friend WithEvents LabelLedgerAccountCode As System.Windows.Forms.Label
    Friend WithEvents TextBoxBankName As System.Windows.Forms.TextBox
    Friend WithEvents LabelBankName As System.Windows.Forms.Label
    Friend WithEvents TextBoxBranchName As System.Windows.Forms.TextBox
    Friend WithEvents LabelBranchName As System.Windows.Forms.Label
    Friend WithEvents TextBoxAccountNumber As System.Windows.Forms.TextBox
    Friend WithEvents LabelAccountNumber As System.Windows.Forms.Label
    Friend WithEvents TextBoxBankOD As System.Windows.Forms.TextBox
    Friend WithEvents LabelBankOD As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents lblAcccodeErr As System.Windows.Forms.Label
End Class

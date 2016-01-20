<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLedgerAccountManage
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
        Me.LblLinkedTo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtAccOpenBalance = New System.Windows.Forms.TextBox()
        Me.lblAccOpenBalance = New System.Windows.Forms.Label()
        Me.txtCYBudget = New System.Windows.Forms.TextBox()
        Me.txtLYActual = New System.Windows.Forms.TextBox()
        Me.txtLYBudget = New System.Windows.Forms.TextBox()
        Me.txtLLYActual = New System.Windows.Forms.TextBox()
        Me.txtLLYBudget = New System.Windows.Forms.TextBox()
        Me.lblCYBudget = New System.Windows.Forms.Label()
        Me.lblLLYActual = New System.Windows.Forms.Label()
        Me.lblLYActual = New System.Windows.Forms.Label()
        Me.lblLYBudget = New System.Windows.Forms.Label()
        Me.lblLLYBudget = New System.Windows.Forms.Label()
        Me.drpOpenBalEff = New System.Windows.Forms.ComboBox()
        Me.lblOpenbaleffect = New System.Windows.Forms.Label()
        Me.txtAccName = New System.Windows.Forms.TextBox()
        Me.lblAccName = New System.Windows.Forms.Label()
        Me.txtAccCode = New System.Windows.Forms.TextBox()
        Me.lblAccCode = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblLinkedTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtAccOpenBalance)
        Me.GroupBox1.Controls.Add(Me.lblAccOpenBalance)
        Me.GroupBox1.Controls.Add(Me.txtCYBudget)
        Me.GroupBox1.Controls.Add(Me.txtLYActual)
        Me.GroupBox1.Controls.Add(Me.txtLYBudget)
        Me.GroupBox1.Controls.Add(Me.txtLLYActual)
        Me.GroupBox1.Controls.Add(Me.txtLLYBudget)
        Me.GroupBox1.Controls.Add(Me.lblCYBudget)
        Me.GroupBox1.Controls.Add(Me.lblLLYActual)
        Me.GroupBox1.Controls.Add(Me.lblLYActual)
        Me.GroupBox1.Controls.Add(Me.lblLYBudget)
        Me.GroupBox1.Controls.Add(Me.lblLLYBudget)
        Me.GroupBox1.Controls.Add(Me.drpOpenBalEff)
        Me.GroupBox1.Controls.Add(Me.lblOpenbaleffect)
        Me.GroupBox1.Controls.Add(Me.txtAccName)
        Me.GroupBox1.Controls.Add(Me.lblAccName)
        Me.GroupBox1.Controls.Add(Me.txtAccCode)
        Me.GroupBox1.Controls.Add(Me.lblAccCode)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(414, 361)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'LblLinkedTo
        '
        Me.LblLinkedTo.Location = New System.Drawing.Point(141, 309)
        Me.LblLinkedTo.Name = "LblLinkedTo"
        Me.LblLinkedTo.Size = New System.Drawing.Size(100, 15)
        Me.LblLinkedTo.TabIndex = 23
        Me.LblLinkedTo.Text = "Not Linked"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 309)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 15)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Linked To Daybook"
        '
        'btnSearch
        '
        Me.btnSearch.Image = Global.FAMS.My.Resources.Resources.searchIcon
        Me.btnSearch.Location = New System.Drawing.Point(334, 24)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(26, 23)
        Me.btnSearch.TabIndex = 21
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtAccOpenBalance
        '
        Me.txtAccOpenBalance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccOpenBalance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccOpenBalance.Location = New System.Drawing.Point(141, 121)
        Me.txtAccOpenBalance.Name = "txtAccOpenBalance"
        Me.txtAccOpenBalance.Size = New System.Drawing.Size(177, 22)
        Me.txtAccOpenBalance.TabIndex = 3
        '
        'lblAccOpenBalance
        '
        Me.lblAccOpenBalance.AutoSize = True
        Me.lblAccOpenBalance.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccOpenBalance.Location = New System.Drawing.Point(10, 121)
        Me.lblAccOpenBalance.Name = "lblAccOpenBalance"
        Me.lblAccOpenBalance.Size = New System.Drawing.Size(120, 14)
        Me.lblAccOpenBalance.TabIndex = 20
        Me.lblAccOpenBalance.Text = "Acc Opening Balance"
        Me.lblAccOpenBalance.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtCYBudget
        '
        Me.txtCYBudget.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCYBudget.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCYBudget.Location = New System.Drawing.Point(140, 281)
        Me.txtCYBudget.Name = "txtCYBudget"
        Me.txtCYBudget.Size = New System.Drawing.Size(177, 22)
        Me.txtCYBudget.TabIndex = 8
        '
        'txtLYActual
        '
        Me.txtLYActual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLYActual.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLYActual.Location = New System.Drawing.Point(140, 249)
        Me.txtLYActual.Name = "txtLYActual"
        Me.txtLYActual.Size = New System.Drawing.Size(177, 22)
        Me.txtLYActual.TabIndex = 7
        '
        'txtLYBudget
        '
        Me.txtLYBudget.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLYBudget.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLYBudget.Location = New System.Drawing.Point(140, 217)
        Me.txtLYBudget.Name = "txtLYBudget"
        Me.txtLYBudget.Size = New System.Drawing.Size(177, 22)
        Me.txtLYBudget.TabIndex = 6
        '
        'txtLLYActual
        '
        Me.txtLLYActual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLLYActual.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLLYActual.Location = New System.Drawing.Point(140, 185)
        Me.txtLLYActual.Name = "txtLLYActual"
        Me.txtLLYActual.Size = New System.Drawing.Size(177, 22)
        Me.txtLLYActual.TabIndex = 5
        '
        'txtLLYBudget
        '
        Me.txtLLYBudget.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLLYBudget.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLLYBudget.Location = New System.Drawing.Point(140, 153)
        Me.txtLLYBudget.Name = "txtLLYBudget"
        Me.txtLLYBudget.Size = New System.Drawing.Size(177, 22)
        Me.txtLLYBudget.TabIndex = 4
        '
        'lblCYBudget
        '
        Me.lblCYBudget.AutoSize = True
        Me.lblCYBudget.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCYBudget.Location = New System.Drawing.Point(9, 281)
        Me.lblCYBudget.Name = "lblCYBudget"
        Me.lblCYBudget.Size = New System.Drawing.Size(60, 14)
        Me.lblCYBudget.TabIndex = 11
        Me.lblCYBudget.Text = "CY Budget"
        Me.lblCYBudget.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLLYActual
        '
        Me.lblLLYActual.AutoSize = True
        Me.lblLLYActual.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLYActual.Location = New System.Drawing.Point(9, 185)
        Me.lblLLYActual.Name = "lblLLYActual"
        Me.lblLLYActual.Size = New System.Drawing.Size(59, 14)
        Me.lblLLYActual.TabIndex = 10
        Me.lblLLYActual.Text = "LLY Actual"
        Me.lblLLYActual.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLYActual
        '
        Me.lblLYActual.AutoSize = True
        Me.lblLYActual.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLYActual.Location = New System.Drawing.Point(9, 249)
        Me.lblLYActual.Name = "lblLYActual"
        Me.lblLYActual.Size = New System.Drawing.Size(54, 14)
        Me.lblLYActual.TabIndex = 9
        Me.lblLYActual.Text = "LY Actual"
        Me.lblLYActual.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLYBudget
        '
        Me.lblLYBudget.AutoSize = True
        Me.lblLYBudget.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLYBudget.Location = New System.Drawing.Point(9, 217)
        Me.lblLYBudget.Name = "lblLYBudget"
        Me.lblLYBudget.Size = New System.Drawing.Size(58, 14)
        Me.lblLYBudget.TabIndex = 8
        Me.lblLYBudget.Text = "LY Budget"
        Me.lblLYBudget.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLLYBudget
        '
        Me.lblLLYBudget.AutoSize = True
        Me.lblLLYBudget.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLLYBudget.Location = New System.Drawing.Point(9, 153)
        Me.lblLLYBudget.Name = "lblLLYBudget"
        Me.lblLLYBudget.Size = New System.Drawing.Size(63, 14)
        Me.lblLLYBudget.TabIndex = 7
        Me.lblLLYBudget.Text = "LLY Budget"
        Me.lblLLYBudget.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'drpOpenBalEff
        '
        Me.drpOpenBalEff.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.drpOpenBalEff.FormattingEnabled = True
        Me.drpOpenBalEff.Items.AddRange(New Object() {"CR", "DR"})
        Me.drpOpenBalEff.Location = New System.Drawing.Point(140, 89)
        Me.drpOpenBalEff.Name = "drpOpenBalEff"
        Me.drpOpenBalEff.Size = New System.Drawing.Size(89, 22)
        Me.drpOpenBalEff.TabIndex = 2
        '
        'lblOpenbaleffect
        '
        Me.lblOpenbaleffect.AutoSize = True
        Me.lblOpenbaleffect.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpenbaleffect.Location = New System.Drawing.Point(9, 89)
        Me.lblOpenbaleffect.Name = "lblOpenbaleffect"
        Me.lblOpenbaleffect.Size = New System.Drawing.Size(46, 14)
        Me.lblOpenbaleffect.TabIndex = 4
        Me.lblOpenbaleffect.Text = "CR / DR"
        Me.lblOpenbaleffect.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtAccName
        '
        Me.txtAccName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccName.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccName.Location = New System.Drawing.Point(140, 57)
        Me.txtAccName.MaxLength = 50
        Me.txtAccName.Name = "txtAccName"
        Me.txtAccName.Size = New System.Drawing.Size(253, 22)
        Me.txtAccName.TabIndex = 1
        '
        'lblAccName
        '
        Me.lblAccName.AutoSize = True
        Me.lblAccName.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccName.Location = New System.Drawing.Point(9, 57)
        Me.lblAccName.Name = "lblAccName"
        Me.lblAccName.Size = New System.Drawing.Size(84, 14)
        Me.lblAccName.TabIndex = 2
        Me.lblAccName.Text = "Account Name"
        Me.lblAccName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtAccCode
        '
        Me.txtAccCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccCode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccCode.Location = New System.Drawing.Point(140, 25)
        Me.txtAccCode.MaxLength = 6
        Me.txtAccCode.Name = "txtAccCode"
        Me.txtAccCode.Size = New System.Drawing.Size(177, 22)
        Me.txtAccCode.TabIndex = 0
        '
        'lblAccCode
        '
        Me.lblAccCode.AutoSize = True
        Me.lblAccCode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccCode.Location = New System.Drawing.Point(9, 25)
        Me.lblAccCode.Name = "lblAccCode"
        Me.lblAccCode.Size = New System.Drawing.Size(79, 14)
        Me.lblAccCode.TabIndex = 0
        Me.lblAccCode.Text = "Account Code"
        Me.lblAccCode.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmLedgerAccountManage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 361)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLedgerAccountManage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ledger Account Master"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAccName As System.Windows.Forms.TextBox
    Friend WithEvents lblAccName As System.Windows.Forms.Label
    Friend WithEvents txtAccCode As System.Windows.Forms.TextBox
    Friend WithEvents lblAccCode As System.Windows.Forms.Label
    Friend WithEvents lblOpenbaleffect As System.Windows.Forms.Label
    Friend WithEvents drpOpenBalEff As System.Windows.Forms.ComboBox
    Friend WithEvents lblLLYActual As System.Windows.Forms.Label
    Friend WithEvents lblLYActual As System.Windows.Forms.Label
    Friend WithEvents lblLYBudget As System.Windows.Forms.Label
    Friend WithEvents lblLLYBudget As System.Windows.Forms.Label
    Friend WithEvents txtCYBudget As System.Windows.Forms.TextBox
    Friend WithEvents txtLYActual As System.Windows.Forms.TextBox
    Friend WithEvents txtLYBudget As System.Windows.Forms.TextBox
    Friend WithEvents txtLLYActual As System.Windows.Forms.TextBox
    Friend WithEvents txtLLYBudget As System.Windows.Forms.TextBox
    Friend WithEvents lblCYBudget As System.Windows.Forms.Label
    Friend WithEvents txtAccOpenBalance As System.Windows.Forms.TextBox
    Friend WithEvents lblAccOpenBalance As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents LblLinkedTo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

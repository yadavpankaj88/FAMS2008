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
        Me.ddltype = New System.Windows.Forms.ComboBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.txtuser_name = New System.Windows.Forms.TextBox()
        Me.txtuser_role = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.ddlmodule_code = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ddltype
        '
        Me.ddltype.FormattingEnabled = True
        Me.ddltype.Location = New System.Drawing.Point(152, 67)
        Me.ddltype.Name = "ddltype"
        Me.ddltype.Size = New System.Drawing.Size(155, 21)
        Me.ddltype.TabIndex = 7
        '
        'txtpassword
        '
        Me.txtpassword.Location = New System.Drawing.Point(154, 198)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Size = New System.Drawing.Size(155, 20)
        Me.txtpassword.TabIndex = 15
        '
        'txtuser_name
        '
        Me.txtuser_name.Location = New System.Drawing.Point(152, 115)
        Me.txtuser_name.Name = "txtuser_name"
        Me.txtuser_name.Size = New System.Drawing.Size(155, 20)
        Me.txtuser_name.TabIndex = 9
        '
        'txtuser_role
        '
        Me.txtuser_role.Location = New System.Drawing.Point(152, 157)
        Me.txtuser_role.Name = "txtuser_role"
        Me.txtuser_role.Size = New System.Drawing.Size(155, 20)
        Me.txtuser_role.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 202)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "User Role"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "User Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Institution Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Module Code"
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(86, 248)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 72
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'ddlmodule_code
        '
        Me.ddlmodule_code.FormattingEnabled = True
        Me.ddlmodule_code.Location = New System.Drawing.Point(152, 19)
        Me.ddlmodule_code.Name = "ddlmodule_code"
        Me.ddlmodule_code.Size = New System.Drawing.Size(155, 21)
        Me.ddlmodule_code.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtuser_name)
        Me.GroupBox1.Controls.Add(Me.btnsave)
        Me.GroupBox1.Controls.Add(Me.ddlmodule_code)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ddltype)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtpassword)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtuser_role)
        Me.GroupBox1.Location = New System.Drawing.Point(54, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(366, 277)
        Me.GroupBox1.TabIndex = 73
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'frmUserMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 358)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmUserMaster"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ddltype As System.Windows.Forms.ComboBox
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents txtuser_name As System.Windows.Forms.TextBox
    Friend WithEvents txtuser_role As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents ddlmodule_code As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class

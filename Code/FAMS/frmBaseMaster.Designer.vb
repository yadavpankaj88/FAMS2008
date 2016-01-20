<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBaseMaster
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
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.ColumnCount = 4
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.btnConfirm, 3, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.btnUpdate, 1, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.btnAdd, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.btnDelete, 2, 0)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tableLayoutPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 263)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 1
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(331, 38)
        Me.tableLayoutPanel1.TabIndex = 1
        '
        'btnConfirm
        '
        Me.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnConfirm.Location = New System.Drawing.Point(249, 3)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(79, 32)
        Me.btnConfirm.TabIndex = 3
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnUpdate.Location = New System.Drawing.Point(85, 3)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(76, 32)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAdd.Location = New System.Drawing.Point(3, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(76, 32)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDelete.Location = New System.Drawing.Point(167, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(76, 32)
        Me.btnDelete.TabIndex = 0
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'frmBaseMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 301)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmBaseMaster"
        Me.Text = "frmBaseMaster"
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents btnConfirm As System.Windows.Forms.Button
    Private WithEvents btnUpdate As System.Windows.Forms.Button
    Private WithEvents btnAdd As System.Windows.Forms.Button
    Private WithEvents btnDelete As System.Windows.Forms.Button
End Class

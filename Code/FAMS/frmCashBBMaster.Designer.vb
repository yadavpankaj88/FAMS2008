﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashBBMaster
    Inherits FAMS.frmBaseMaster

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
        Me.dgvCashBB = New System.Windows.Forms.DataGridView()
        CType(Me.dgvCashBB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCashBB
        '
        Me.dgvCashBB.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvCashBB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCashBB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCashBB.Location = New System.Drawing.Point(0, 0)
        Me.dgvCashBB.Name = "dgvCashBB"
        Me.dgvCashBB.Size = New System.Drawing.Size(737, 305)
        Me.dgvCashBB.TabIndex = 2
        '
        'frmCashBBMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 343)
        Me.Controls.Add(Me.dgvCashBB)
        Me.Name = "frmCashBBMaster"
        Me.Text = "Cash – Bank Books Master"
        Me.Controls.SetChildIndex(Me.dgvCashBB, 0)
        CType(Me.dgvCashBB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvCashBB As System.Windows.Forms.DataGridView
End Class
